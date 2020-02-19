using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using OpenCvSharp;
using System.Threading;
using System.Windows.Forms;

namespace AppTestStudio
{
    public class RunThread
    {
        public GameNodeGame Game { get; set; }
        public int WindowHandle { get; set; }

        public bool ThreadIsShuttingDown { get; set; }

        // number of times to look for a window before closing the thread.
        public long RunTimeWindowTimeout { get; set; }

        public ThreadManager ThreadManager { get; set; }

        private static Object GetBitMapLock;

        static RunThread()
        {
            GetBitMapLock = new Object();
        }

        public RunThread(GameNodeGame Game)
        {
            this.Game = Game;
            ThreadIsShuttingDown = false;
            RunTimeWindowTimeout = 100;
        }

        private Bitmap GetBitMap(ref Boolean Success)
        {
            Success = false;
            lock (GetBitMapLock)
            {

                //', Release what you Get, and Delete what you Create. 
                IntPtr IntPtrWindowHandle = new IntPtr(WindowHandle);

                IntPtr hdcSrc = API.GetWindowDC(IntPtrWindowHandle);
                if (hdcSrc.ToInt32() == 0)
                {
                    Game.Log("GetWindowDC = 0 " + WindowHandle);
                    Game.Log("Refetching Window for " + Game.TargetWindow);
                    WindowHandle = Utils.GetWindowHandleByWindowName(Game.TargetWindow);
                    IntPtrWindowHandle = new IntPtr(WindowHandle);

                }
                API.RECT WindowRectangle = new API.RECT();

                API.GetWindowRect(IntPtrWindowHandle, out WindowRectangle);

                int TargetWindowHeight = WindowRectangle.Bottom - WindowRectangle.Top;
                int TargetWindowWidth = WindowRectangle.Right - WindowRectangle.Left;

                if (TargetWindowHeight < 1 || TargetWindowWidth < 1)
                {
                    return null;
                }

                IntPtr hdcDest = API.CreateCompatibleDC(hdcSrc);

                IntPtr hBitmap = API.CreateCompatibleBitmap(hdcSrc, TargetWindowWidth, TargetWindowHeight);

                IntPtr hOld = API.SelectObject(hdcDest, hBitmap);

                //'modAPI.BitBlt(hdcDest, 0, 0, TargetWindowWidth, TargetWindowHeight, hdcSrc, 0, 0, &HCC0020)

                API.PrintWindow(IntPtrWindowHandle, hdcDest, 2);

                API.SelectObject(hdcDest, hOld);
                API.DeleteDC(hdcDest);
                API.ReleaseDC(IntPtrWindowHandle, hdcSrc);

                Bitmap bmp = Image.FromHbitmap(hBitmap);
                API.DeleteObject(hBitmap);

                Success = true;

                if (Game.SaveVideo)
                {
                    Game.BitmapClones.Enqueue(bmp.Clone() as Bitmap);
                }

                return bmp;
            }
        }


        private Boolean IsTrue(Bitmap bmp, GameNodeAction node, ref int centerX, ref int centerY)
        {
            if (node.IsColorPoint)
            {
                return IsColorPointTrue(bmp, node);
            }
            else
            {
                return IsImageSearchTrue(bmp, node, ref centerX, ref centerY);

            }
        }

        private bool IsImageSearchTrue(Bitmap bmp, GameNodeAction node, ref int centerX, ref int centerY)
        {
            if (node.Rectangle.Width <= 0 || node.Rectangle.Height <= 0)
            {
                //'Debug.Assert(False)
                //'TB.AddReturnFalse()
                return false;
            }

            //' False if no object to search
            if (node.ObjectName == "")
            {
                //' TB.AddReturnFalse()
                return false;
            }

            if (node.Channel == "")
            {
                //' TB.AddReturnFalse()
                return false;
            }

            if (node.ObjectSearchBitmap.IsNothing())
            {
                Game.Log(node.GameNodeName + " configuration is invalid Search Object Not Configured.");
                //' TB.AddReturnFalse()
                return false;
            }

            Bitmap CropImage = new Bitmap(node.Rectangle.Width, node.Rectangle.Height);

            using (Graphics grp = Graphics.FromImage(CropImage))
            {
                grp.DrawImage(bmp, new Rectangle(0, 0, node.Rectangle.Width, node.Rectangle.Height), node.Rectangle, GraphicsUnit.Pixel);
                //'grp.DrawEllipse(Pens.Black, 40, 40, 40, 40)

                grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grp.PixelOffsetMode = PixelOffsetMode.HighQuality;
                grp.CompositingQuality = CompositingQuality.HighQuality;

            }

            Mat m1 = OpenCvSharp.Extensions.BitmapConverter.ToMat(CropImage);

            //'213 ms
            //'Dim Red As Mat = m1.ExtractChannel(2)
            Mat[] BGR = m1.Split();

            Mat Blue = BGR[0];
            Mat Green = BGR[1];
            Mat Red = BGR[2];

            Mat m2 = OpenCvSharp.Extensions.BitmapConverter.ToMat(node.ObjectSearchBitmap);
            BGR = m2.Split();
            Mat BlueTarget = BGR[0];
            Mat GreenTarget = BGR[1];
            Mat RedTarget = BGR[2];

            double Percent = 0;
            if (node.ObjectThreshold == 0)
            {
                Percent = 99;
            }
            else
            {
                Percent = node.ObjectThreshold / 100;
            }

            int Rows = Red.Rows - RedTarget.Rows + 1;
            int Cols = Red.Cols - RedTarget.Cols + 1;

            if (Rows < 1)
            {
                Game.Log(node.Name + " search item height " + RedTarget.Rows + "px is larger than the height of the mask of " + Red.Rows + "px, Please increase the mask size so the search image can be searched.");
                return false;
            }

            if (Cols < 1)
            {
                Game.Log(node.Name + " search item width is " + RedTarget.Cols + "px is larger than the width of the mask of " + Red.Cols + "px, Please increase the mask size so the search image can be searched.");
                return false;
            }

            Mat res = new Mat(Rows, Cols, MatType.CV_8U);
            //'Cv2.CvtColor(m1, m2, ColorConversionCodes.)

            Mat SearchTarget = null;
            Mat ObjectTarget = null;
            switch (node.Channel.ToUpper())
            {
                case "Red":
                    SearchTarget = Red;
                    ObjectTarget = RedTarget;
                    break;
                case "Green":
                    SearchTarget = Green;
                    ObjectTarget = GreenTarget;
                    break;
                case "Blue":
                    SearchTarget = Blue;
                    ObjectTarget = BlueTarget;
                    break;
                default:
                    Game.Log(node.Name + " missing Channel using Red");
                    SearchTarget = Red;
                    ObjectTarget = RedTarget;
                    break;
            }
            try
            {
                Cv2.MatchTemplate(SearchTarget, ObjectTarget, res, TemplateMatchModes.CCoeffNormed);
            }
            catch (Exception)
            {
                Game.Log("Search Failure, possible resolution mismatch");
                return false;
            }

            OpenCvSharp.Point p = new OpenCvSharp.Point();
            OpenCvSharp.Point DetectedPoint = new OpenCvSharp.Point();
            Cv2.MinMaxLoc(res, out p, out DetectedPoint);

            Mat.Indexer<Single> indexer = res.GetGenericIndexer<Single>();
            var j = indexer[DetectedPoint.Y, DetectedPoint.X];

            long ObjectThreshold = node.ObjectThreshold;
            if (ObjectThreshold == 0)
            {
                ObjectThreshold = 100;
            }

            centerX = DetectedPoint.X + (node.ObjectSearchBitmap.Width / 2);
            centerY = DetectedPoint.Y + (node.ObjectSearchBitmap.Height / 2);

            if (j >= ObjectThreshold / 100)
            {
                Game.Log("Closest match " + (j * 100).ToString("F1") + " - x = " + centerX + "  y =" + centerY);
                //'TB.AddReturnTrue()
                return true;
            }
            else
            {
                //'TB.AddReturnFalse()
                return false;
            }
        }

        private bool IsColorPointTrue(Bitmap bmp, GameNodeAction node)
        {
            //' no colors to click = pass.
            if (node.ClickList.Count == 0)
            {
                //'TB.AddReturnTrue()
                return true;
            }

            // if a click is out of X or Y range then fail
            foreach (SingleClick click in node.ClickList)
            {
                if (bmp.Width <= click.X)
                {
                    return false;
                }

                if (bmp.Height <= click.Y)
                {
                    return false;
                }

                Color Color = bmp.GetPixel(click.X, click.Y);
                switch (node.LogicChoice.ToUpper())
                {
                    case "AND":
                        int OffsetAND = 0;
                        if (click.Color.CompareColorWithPoints(Color, node.Points, ref OffsetAND))
                        {
                            //'TB.AddColorTest(click.Color, Color, Node.Points, Node.LogicChoice, True)
                        }
                        else
                        {
                            //'TB.AddColorTest(click.Color, Color, Node.Points, Node.LogicChoice, False)
                            //'TB.AddReturnFalse()
                            return false;
                        }
                        break;
                    case "OR":
                        int OffsetOR = 0;
                        if (click.Color.CompareColorWithPoints(Color, node.Points, ref OffsetOR))
                        {
                            //'TB.AddColorTest(click.Color, Color, Node.Points, Node.LogicChoice, True)
                            //'TB.AddReturnTrue()
                            return true;
                        }
                        else
                        {

                            //'TB.AddColorTest(click.Color, Color, Node.Points, Node.LogicChoice, False)
                        }
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
            // found no true's with the OR logic
            if (node.LogicChoice == "OR")
            {
                //' TB.AddReturnFalse()
                return false;
            }

            return true;

        }

        private void StopThreadCloseWindow(int windowHandle)
        {
            Game.Log("Closing Emmulator");

            NoxRegistry Registry = new NoxRegistry();

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = Registry.ExePath; //'  "C:\Program Files (x86)\Nox\bin\nox.exe"
            info.WorkingDirectory = Registry.WorkingDirectory; //' "C:\Program Files (x86)\Nox\"

            String instance = Game.InstanceToLaunch;

            String Arguments = "";

            if (instance.Trim().Length > 0)
            {
                if (instance.Trim().IsNumeric())
                {
                    if (Arguments.Length > 0)
                    {
                        Arguments = Arguments + " ";
                    }
                    Arguments = Arguments + " -clone:Nox_" + instance.Trim();
                }
            }

            Arguments = Arguments + " -quit";
            info.Arguments = Arguments;
            Process.Start(info);
            //'Game.InstanceToLaunch 

            ThreadIsShuttingDown = true;


            if (Game.SaveVideo)
            {
                Game.Video.Release();
                Game.Video = null;
            }

            ThreadManager.RemoveGame(Game);
            Thread.Sleep(3000);
            Thread.CurrentThread.Abort();
        }


        private AfterCompletionType ProcessChildren(Bitmap bmp, GameNodeAction node, int centerX, int centerY)
        {

            ThreadManager.IncrementGoChild();
            switch (node.ActionType)
            {
                case ActionType.Action:
                    Game.AbsoluteLastNode = node;
                    Game.ThreadLastNodeAction = node;

                    int xPos = node.Rectangle.X;
                    int yPos = node.Rectangle.Y;

                    if (node.IsLimited)
                    {
                        AfterCompletionType Result = CheckLimit(node);
                        switch (Result)
                        {
                            case AfterCompletionType.ContinueProcess:
                                break;
                            default:
                                return Result;
                        }
                    }

                    switch (node.Mode)
                    {
                        case Mode.RangeClick:
                            short RandomX = RandomNumber(0, node.Rectangle.Width);
                            short RandomY = RandomNumber(0, node.Rectangle.Height);

                            Boolean Failed = false;

                            if (node.IsRelativeStart)
                            {

                                GameNode Parent = node.Parent as GameNode;
                                if (Parent is GameNodeAction)
                                {
                                    GameNodeAction ParentNode = Parent as GameNodeAction;
                                    xPos = centerX + ParentNode.Rectangle.X + node.RelativeXOffset - (node.Rectangle.Width / 2);
                                    yPos = centerY + ParentNode.Rectangle.Y + node.RelativeYOffset - (node.Rectangle.Height / 2);

                                    //' xPos = CenterX + ParentNode.Rectangle.X + Node.RelativeXOffset - (Node.Rectangle.Width / 2) + RandomNumber(0, Node.Rectangle.Width)
                                    //' yPos = CenterY + ParentNode.Rectangle.Y + Node.RelativeYOffset - (Node.Rectangle.Height / 2) + RandomNumber(0, Node.Rectangle.Height)
                                }
                                else
                                {
                                    xPos = centerX + node.RelativeXOffset - (node.Rectangle.Width / 2);
                                    yPos = centerY + node.RelativeYOffset - (node.Rectangle.Height / 2);
                                }

                                if (xPos < 0)
                                {
                                    Game.Log("Check Relative offset X, calculated to a negative position " + xPos);
                                    Failed = true;
                                }

                                if (yPos < 0)
                                {
                                    Game.Log("Check Relative offset Y, calculated to a negative position " + yPos);
                                    Failed = true;
                                }

                                if (yPos <= 34)
                                {
                                    Game.Log("Check Relative offset Y, calculated to a position on the Window Title  " + yPos);
                                    Failed = true;
                                }
                            }

                            if (Failed)
                            {
                                //'do nothing
                                return AfterCompletionType.ContinueProcess;
                            }
                            else
                            {
                                short xTarget = (short)(xPos + RandomX);
                                short yTarget = (short)(yPos + RandomY);

                                Game.Log(node.Name + " Click(" + xTarget + "," + yTarget + ")");
                                ClickOnWindow(WindowHandle, xTarget, yTarget);
                                ThreadManager.IncrementClickCount();
                            }

                            break;
                        case Mode.ClickDragRelease:
                            int ex = xPos + node.Rectangle.Width;
                            int ey = yPos + node.Rectangle.Height;
                            Failed = false;

                            if (node.IsRelativeStart)
                            {

                                if (node.Rectangle.Width <= 0)
                                {
                                    Game.Log(node.GameNodeName + " has width of " + node.Rectangle.Width + " please redraw");
                                    Failed = true;
                                }

                                if (node.Rectangle.Height <= 0)
                                {
                                    Game.Log(node.GameNodeName + " has Height of " + node.Rectangle.Height + " please redraw");
                                    Failed = true;
                                }

                                ex = xPos - (node.Rectangle.Width / 2) + RandomNumber(0, node.Rectangle.Width);
                                ey = yPos - (node.Rectangle.Height / 2) + RandomNumber(0, node.Rectangle.Height);

                                GameNode Parent = node.Parent as GameNode;
                                if (Parent is GameNodeAction)
                                {
                                    GameNodeAction ParentNode = Parent as GameNodeAction;
                                    xPos = centerX + ParentNode.Rectangle.X + node.RelativeXOffset - (node.Rectangle.Width / 2) + RandomNumber(0, node.Rectangle.Width);
                                    yPos = centerY + ParentNode.Rectangle.Y + node.RelativeYOffset - (node.Rectangle.Height / 2) + RandomNumber(0, node.Rectangle.Height);
                                }

                                if (xPos < 0)
                                {
                                    Game.Log("Check Relative offset X, calculated to a negative position " + xPos);
                                    Failed = true;
                                }

                                if (yPos < 0)
                                {
                                    Game.Log("Check Relative offset Y, calculated to a negative position " + yPos);
                                    Failed = true;
                                }

                                if (yPos <= 34)
                                {
                                    Game.Log("Check Relative offset Y, calculated to a position on the Window Title  " + yPos);
                                    Failed = true;
                                }

                                ex = node.Rectangle.X + node.Rectangle.Width / 2;
                                ey = node.Rectangle.Y + node.Rectangle.Height / 2;
                            }

                            if (Failed)
                            {
                                //'do nothing
                            }
                            else
                            {
                                Game.Log("Swipe from ( x=" + xPos + ",y = " + yPos + " to x=" + ex + ",y=" + ey + ")");
                                ClickDragRelease(WindowHandle, xPos, yPos, ex, ey);
                                ThreadManager.IncrementClickDragRelease();
                                //'if (UseThreadBitmap ) {
                                //'    TB.AddClickDragRelease(xPos, yPos, Node.Rectangle.Width, Node.Rectangle.Height, ex, ey, Node.Name)
                                //'}
                            }



                            break;
                        default:
                            break;
                    }

                    int DelayCalc = node.DelayMS + (node.DelayS * 1000) + (node.DelayM * 60 * 1000);

                    Thread.Sleep(DelayCalc);
                    Game.LogStatus(node.StatusNodeID, DelayCalc);
                    ThreadManager.AddWaitLength(DelayCalc);

                    switch (node.AfterCompletionType)
                    {
                        case AfterCompletionType.Continue:
                            ThreadManager.IncrementGoContinue();
                            Boolean ExitFor = false;
                            foreach (TreeNode t in node.Nodes)
                            {
                                AfterCompletionType ACT = ProcessChildren(bmp, t as GameNodeAction, centerX, centerY);

                                switch (ACT)
                                {
                                    case AfterCompletionType.Home:
                                        ThreadManager.IncrementGoHome();
                                        return AfterCompletionType.Home;
                                    case AfterCompletionType.Parent:
                                        ThreadManager.IncrementGoParent();
                                        ExitFor = true;
                                        break;
                                    case AfterCompletionType.Stop:
                                        ThreadManager.IncrementGoStop();
                                        StopThreadCloseWindow(WindowHandle);
                                        return AfterCompletionType.Stop;
                                    case AfterCompletionType.Continue:
                                        ThreadManager.IncrementGoContinue();
                                        break;
                                    default:
                                        Debug.Assert(false);
                                        break;
                                }

                                if (ExitFor)
                                {
                                    break;
                                }
                            }
                            break;
                        case AfterCompletionType.Home:
                            ThreadManager.IncrementGoHome();
                            return AfterCompletionType.Home;
                        case AfterCompletionType.Parent:
                            ThreadManager.IncrementGoParent();
                            return AfterCompletionType.Parent;
                        case AfterCompletionType.Stop:
                            ThreadManager.IncrementGoStop();
                            StopThreadCloseWindow(WindowHandle);
                            return AfterCompletionType.Stop;
                        default:
                            break;
                    }
                    break;
                case ActionType.Event:
                    if (node.UseParentPicture == false)
                    {
                        Boolean Success = false;
                        bmp.Dispose();
                        bmp = GetBitMap(ref Success);
                        if (Success == false)
                        {
                            Game.Log(node.Name + " Lost Window");
                            Game.Log(node.Name + " Lost Returning to Home");
                            return AfterCompletionType.Home;
                        }
                        else
                        {
                            ThreadManager.IncrementScreenShots();
                            Game.ScreenShotsTaken = Game.ScreenShotsTaken + 1;
                        }
                        Game.Log(node.Name + " Taking Screenshot");
                    }

                    if (IsTrue(bmp, node, ref centerX, ref centerY))
                    {
                        if (node.IsLimited)
                        {
                            AfterCompletionType Result = CheckLimit(node);
                            switch (Result)
                            {
                                case AfterCompletionType.ContinueProcess:
                                    // do nothing
                                    break;
                                default:
                                    return Result;
                            }
                        }

                        if (node.FileName.IsNothing())
                        {
                            MinimalBitmapNode mbn = new MinimalBitmapNode();
                            mbn.NodeName = node.Name;
                            mbn.ResolutionWidth = node.ResolutionWidth;
                            mbn.ResolutionHeight = node.ResolutionHeight;
                            mbn.Bitmap = bmp.Clone() as Bitmap;
                            node.FileName = "";
                            Game.MinimalBitmapClones.Enqueue(mbn);
                        }

                        node.ThreadMatchCount++;

                        //'Track the Last Node Event
                        Game.AbsoluteLastNode = node;
                        Game.ThreadLastNodeEvent = node;

                        //'if (Node.Nodes.Count <> 0 ) {
                        //'    Game.Log(Node.Name & " Action Match (" & Node.Nodes.Count() & ")")
                        //'}

                        DelayCalc = node.DelayMS + (node.DelayS * 1000) + (node.DelayM * 60 * 1000);

                        if (DelayCalc > 0)
                        {
                            Game.Log(node.Name + " Waiting " + DelayCalc);
                        }
                        Thread.Sleep(DelayCalc);
                        ThreadManager.AddWaitLength(DelayCalc);

                        //' show status control
                        Game.LogStatus(node.StatusNodeID, DelayCalc);


                        switch (node.AfterCompletionType)
                        {
                            case AfterCompletionType.Continue:

                                ThreadManager.IncrementGoContinue();
                                foreach (TreeNode t in node.Nodes)
                                {
                                    AfterCompletionType ACT = ProcessChildren(bmp, t as GameNodeAction, centerX, centerY);

                                    switch (ACT)
                                    {
                                        case AfterCompletionType.Continue:
                                            ThreadManager.IncrementGoContinue();
                                            break;
                                        case AfterCompletionType.Home:
                                            ThreadManager.IncrementGoHome();
                                            return AfterCompletionType.Home;
                                        case AfterCompletionType.Parent:
                                            ThreadManager.IncrementGoParent();
                                            // do nothing if a child returns a parent;
                                            break;
                                        case AfterCompletionType.Stop:
                                            ThreadManager.IncrementGoStop();
                                            StopThreadCloseWindow(WindowHandle);
                                            return AfterCompletionType.Stop;
                                        default:
                                            Debug.Assert(false);
                                            break;
                                    }
                                }
                                break;
                            case AfterCompletionType.Home:
                                ThreadManager.IncrementGoHome();
                                return AfterCompletionType.Home;
                            case AfterCompletionType.Parent:
                                ThreadManager.IncrementGoParent();
                                return AfterCompletionType.Parent;
                            case AfterCompletionType.Stop:
                                ThreadManager.IncrementGoStop();
                                StopThreadCloseWindow(WindowHandle);
                                return AfterCompletionType.Stop;
                            default:
                                Debug.Assert(false);
                                break;
                        }
                    }

                    break;
                case ActionType.RNGContainer:
                    if (node.IsLimited)
                    {
                        AfterCompletionType Result = CheckLimit(node);
                        switch (Result)
                        {
                            case AfterCompletionType.ContinueProcess:
                                // do nothing, lets continue;
                                break;
                            default:
                                return Result;
                        }
                    }

                    ThreadManager.IncrementNewRNGContainer();

                    if (node.Nodes.Count > 0)
                    {
                        int Increment = 100 / node.Nodes.Count;

                        int RNG = RandomNumber(1, 100);

                        int TargetIndex = (int)Math.Ceiling((double)RNG / Increment) - 1;

                        Game.Log(node.Name + " RNG (" + RNG + ") Node Index chosen (" + TargetIndex + ")");

                        DelayCalc = node.DelayMS + (node.DelayS * 1000) + (node.DelayM * 60 * 1000);


                        if (DelayCalc > 0)
                        {
                            Game.Log(node.Name + " Waiting " + DelayCalc);
                        }
                        Thread.Sleep(DelayCalc);

                        ThreadManager.IncrementWaitLength();

                        GameNodeAction RNGNode = node.Nodes[TargetIndex] as GameNodeAction;


                        if (RNGNode.IsLimited)
                        {
                            AfterCompletionType Result = CheckLimit(RNGNode);
                            switch (Result)
                            {
                                case AfterCompletionType.ContinueProcess:
                                    // do nothing
                                    break;
                                default:
                                    return Result;
                            }
                        }

                        foreach (TreeNode t in RNGNode.Nodes)
                        {
                            AfterCompletionType ACT = ProcessChildren(bmp, t as GameNodeAction, centerX, centerY);

                            switch (ACT)
                            {
                                case AfterCompletionType.Home:
                                    ThreadManager.IncrementGoHome();
                                    return AfterCompletionType.Home;
                                case AfterCompletionType.Parent:
                                    ThreadManager.IncrementGoParent();
                                    // do nothing when child returns a parent...
                                    break;
                                case AfterCompletionType.Continue:
                                    // do nothing
                                    break;
                                default:
                                    Debug.Assert(false);
                                    break;
                            }
                        }
                    }

                    break;
                default:
                    Debug.Assert(false);
                    break;

            }

            ThreadManager.IncrementGoContinue();
            return AfterCompletionType.Continue;
        }

        private void ClickOnWindow(int windowHandle, short xTarget, short yTarget)
        {
            int WM_SETCURSOR = 0x20;
            int HTCLIENT = 0x1;

            int WM_MOUSEMOVE = 0x200;
            uint WM_LBUTTONDOWN = 0x201;
            uint WM_LBUTTONUP = 0x202;
            //' PostMessage(WindowHandle, WM_MOUSEMOVE, 0, getHiLoWord(X, Y))
            //' SendMessage(WindowHandle, WM_SETCURSOR, WindowHandle, getHiLoWord(1, WM_MOUSEMOVE))
            //'Thread.Sleep(25)

            //'SendMessage(WindowHandle, WM_SETCURSOR, WindowHandle, getHiLoWord(1, WM_LBUTTONDOWN))

            //'sendmessage(hwnd, WM_SETCURSOR, WM_MOUSEMOVE, MakeLParam(1, WM_MOUSEMOVE))

            API.PostMessage(new IntPtr(WindowHandle), WM_LBUTTONDOWN, (int)WM_LBUTTONDOWN, Utils.HiLoWord(xTarget, yTarget));
        //'Thread.Sleep(25)
        API.PostMessage(new IntPtr(WindowHandle), WM_LBUTTONUP, 0, Utils.HiLoWord(xTarget, yTarget));

        }

        private void ClickDragRelease(int windowHandle, int startX, int startY, int endX, int endY)
        {
            int WM_PARENTNOTIFY = 0x210;
            uint WM_MOUSEMOVE = 0x200;
            uint WM_LBUTTONDOWN = 0x201;
            int WM_LBUTTONUP = 0x202;
            int MK_LBUTTON = 0x1;

            short CurrentX = (short)startX;
            short CurrentY = (short)startY;

            int MaxSteps = Math.Abs(endX - startX);

        if (Math.Abs(endY - startY) > MaxSteps)
            {
                MaxSteps = Math.Abs(endY - startY);
        }

            Double XIncrement = (endX - startX) / MaxSteps;
            Double YIncrement = (endY - startY) / MaxSteps;

            //'Send Mouse Down
            API.PostMessage( new IntPtr(WindowHandle), WM_LBUTTONDOWN, MK_LBUTTON, Utils.HiLoWord( CurrentX,  CurrentY));
            Thread.Sleep(10);

            //'Send draging
            for (int i = 0; i < MaxSteps; i++)
            {
                API.PostMessage(new IntPtr(WindowHandle), WM_MOUSEMOVE, MK_LBUTTON, Utils.HiLoWord( CurrentX,  CurrentY));
                Thread.Sleep(1);

                CurrentX = (short) ( CurrentX + XIncrement);
                CurrentY = (short)(CurrentY + YIncrement);
            }

        Thread.Sleep(10);

            //' Send mouse Up
            API.SendMessage(new IntPtr(WindowHandle), WM_LBUTTONUP, 0, Utils.HiLoWordIntptr(CurrentX, CurrentY));

        }


        private short RandomNumber(int min, int max)
        {
            System.Random Generator = new System.Random();
            return (short) Generator.Next(min, max);
        }

        private AfterCompletionType CheckLimit(GameNodeAction node)
        {
            if (node.IsLimited)
            {
                switch (node.WaitType)
                {
                    case WaitType.Iteration:
                        if (node.RuntimeIterationsLeft > 0)
                        {
                            node.RuntimeIterationsLeft = node.RuntimeIterationsLeft - 1;
                            //'Game.Log("Iteration Limit " & Node.RuntimeIterationsLeft)
                            return AfterCompletionType.Continue;
                        }
                        else
                        {
                            if (node.RuntimeIterationsLeft == 0)
                            {
                                if (node.LimitRepeats)
                                {
                                    node.RuntimeIterationsLeft = node.ExecutionLimit - 1;
                                }
                                else
                                {
                                    node.RuntimeIterationsLeft = -1;
                                }
                            }
                            else
                            {
                                if (node.RuntimeIterationsLeft == -1)
                                {
                                    return AfterCompletionType.Continue;
                                }
                            }
                        }
                        break;
                    case WaitType.Time:
                        if (node.RuntimeNextAllowedTime > DateTime.Now)
                        {
                            //'Game.Log("Time Limit " & DateDiff(DateInterval.Second, Now, Node.RuntimeNextAllowedTime))
                            return AfterCompletionType.Continue;
                        }
                        else
                        {
                            if (node.RuntimeNextAllowedTime <= DateTime.Now)
                            {
                                if (node.LimitRepeats)
                                {
                                    DateTime CurrentTime = DateTime.Now;

                                    CurrentTime = CurrentTime.AddHours(node.LimitDelayH);
                                    CurrentTime = CurrentTime.AddMinutes(node.LimitDelayM);
                                    CurrentTime = CurrentTime.AddSeconds(node.LimitDelayS);
                                    CurrentTime = CurrentTime.AddMilliseconds(node.LimitDelayMS);
                                    node.RuntimeNextAllowedTime = CurrentTime;
                                }
                                else
                                {
                                    node.RuntimeNextAllowedTime = DateTime.MaxValue;
                                }
                            }
                        }
                        break;
                    case WaitType.Session:
                        if (node.RuntimeOncePerSession)
                        {
                            //'already ran
                            return AfterCompletionType.Continue;
                        }
                        else
                        {
                            Game.Log("Session Limit Reached");
                            node.RuntimeOncePerSession = true;
                        }
                        break;
                    default:
                        break;
                }

            }

            return AfterCompletionType.ContinueProcess;

        }

        public void Run()
        {
            WindowHandle = Utils.GetWindowHandleByWindowName(Game.TargetWindow);
            while (WindowHandle == 0)
            {
                while (Game.IsPaused)
                {
                    Thread.Sleep(1000);
                }

                Debug.WriteLine("Can't find window " + Game.TargetWindow + " attempts left " + RunTimeWindowTimeout);
                Game.Log("Can//'t find Window " + Game.TargetWindow + " the window may have been closed - Press Start Emmulator");

                long LoopDelay = Game.LoopDelay;
                while (LoopDelay > 1000)
                {
                    LoopDelay = LoopDelay - 1000;
                    Thread.Sleep(1000);
                }

                if (LoopDelay > 0)
                {
                    Thread.Sleep((int)LoopDelay);
                }

                WindowHandle = Utils.GetWindowHandleByWindowName(Game.TargetWindow);
                RunTimeWindowTimeout = RunTimeWindowTimeout - 1;

                if (RunTimeWindowTimeout < 0)
                {
                    Game.Log("Unable to locate window during startup met timeout limit");
                    Game.Log("Exiting thread");
                }

            }

            foreach (GameNodeAction node in Game.Events.Nodes)
            {
                InitializeChildren(node);
            }

            while (ThreadIsShuttingDown == false)
            {
                Boolean BitMapSuccess = false;
                Bitmap bmp = GetBitMap(ref BitMapSuccess);
                if (BitMapSuccess)
                {
                    ThreadManager.IncrementScreenShots();
                    Game.ScreenShotsTaken++;
                    Game.GameLoops++;

                    int CenterX = 0;
                    int CenterY = 0;

                    foreach (TreeNode node in Game.Events.Nodes)
                    {
                        AfterCompletionType ACT = ProcessChildren(bmp, node as GameNodeAction, CenterX, CenterY);
                        Boolean ExitFor = false;
                        switch (ACT)
                        {
                            case AppTestStudio.AfterCompletionType.Continue:
                                ThreadManager.IncrementGoContinue();
                                break;
                            case AppTestStudio.AfterCompletionType.Home:
                                ThreadManager.IncrementGoHome();
                                ExitFor = true;  // Exit for in C#?
                                break;
                            case AppTestStudio.AfterCompletionType.Parent:
                                ThreadManager.IncrementGoParent();
                                break;
                            case AppTestStudio.AfterCompletionType.Stop:
                                ThreadManager.IncrementGoStop();
                                ExitFor = true;
                                break;
                            case AppTestStudio.AfterCompletionType.ContinueProcess:
                                // should not be here?
                                Debug.Assert(false);
                                break;
                            default:
                                Debug.Assert(false);
                                break;
                        }

                        if (ExitFor)
                        {
                            break;
                        }

                    }
                }
                else
                {
                    Game.Log("Lost window");
                }

                long LoopDelay = Game.LoopDelay;
                while (LoopDelay > 1000)
                {

                    Game.LogStatus(Game.StatusNodeID, LoopDelay);

                    LoopDelay = LoopDelay - 1000;
                    Thread.Sleep(1000);
                    ThreadManager.AddWaitLength(1000);
                }

                if (LoopDelay > 0)
                {
                    Thread.Sleep((int)LoopDelay);
                    ThreadManager.AddWaitLength(LoopDelay);
                    Game.LogStatus(Game.StatusNodeID, LoopDelay);

                    //'8/2 Game.LogStatus(0, LoopDelay)
                }

                while (Game.IsPaused)
                {
                    Thread.Sleep(1000);
                }

                if (bmp.IsNothing())
                {
                    //'do nothing
                }
                else
                {
                    bmp.Dispose();
                }
                bmp = null;
            }
        }

        // Initialize runtime values
        private void InitializeChildren(GameNodeAction node)
        {
            switch (node.WaitType)
            {
                case WaitType.Iteration:
                    if (node.IsWaitFirst)
                    {
                        node.RuntimeIterationsLeft = node.ExecutionLimit;
                    }
                    else
                    {
                        node.RuntimeIterationsLeft = 0;
                    }

                    if (node.ExecutionLimit == 0)
                    {
                        node.IsLimited = false;
                    }

                    break;
                case WaitType.Time:
                    if (node.IsWaitFirst)
                    {
                        DateTime CurrentTime = DateTime.Now;

                        CurrentTime = CurrentTime.AddHours(node.LimitDelayH);
                        CurrentTime = CurrentTime.AddMinutes(node.LimitDelayM); 
                        CurrentTime = CurrentTime.AddSeconds(node.LimitDelayS);
                        CurrentTime = CurrentTime.AddMilliseconds(node.LimitDelayMS);
                        node.RuntimeNextAllowedTime = CurrentTime;
                    }
                    else
                    {
                        // Trigger an immediate execution next time.
                        node.RuntimeNextAllowedTime = DateTime.Now.AddMilliseconds(-100);
                    }

                    break;
                case WaitType.Session:
                    // do nothing
                    break;
                default:
                    break;
            }

            foreach (GameNodeAction Node in node.Nodes)
            {
                InitializeChildren(Node);
            }
        }
    }
}

