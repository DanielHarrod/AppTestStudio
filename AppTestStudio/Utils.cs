﻿// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ServiceModel.Security;

namespace AppTestStudio
{
    public static class Utils
    {
        public static void SetIcons(GameNode Node)
        {
            Color EnabledColor = Color.Black;
            Color DisabledColor = Color.LightGray;
            switch (Node.GameNodeType)
            {
                case GameNodeType.Workspace:
                    Node.ImageIndex = IconNames.AppRoot();
                    Node.SelectedImageIndex = IconNames.AppRoot();

                    break;
                case GameNodeType.Games:
                    break;
                case GameNodeType.Game:
                    break;
                case GameNodeType.Events:
                    Node.ImageIndex = IconNames.Home();
                    Node.SelectedImageIndex = IconNames.Home();
                    break;
                case GameNodeType.Action:
                    GameNodeAction ActionNode = Node as GameNodeAction;
                    if (ActionNode.IsSomething())
                    {
                        switch (ActionNode.ActionType)
                        {
                            case ActionType.Action:
                                SetIconsActionTypeAction(ActionNode);
                                break;
                            case ActionType.Event:
                                if (ActionNode.IsColorPoint)
                                {
                                    if (ActionNode.Enabled)
                                    {
                                        Node.ImageIndex = IconNames.Event();
                                        Node.SelectedImageIndex = IconNames.Event();
                                        Node.ForeColor = EnabledColor;
                                    }
                                    else
                                    {
                                        Node.ImageIndex = IconNames.EventGray();
                                        Node.SelectedImageIndex = IconNames.EventGray();
                                        Node.ForeColor = DisabledColor;
                                    }
                                }
                                else
                                {
                                    if (ActionNode.Enabled)
                                    {
                                        Node.ImageIndex = IconNames.SearchAndApps();
                                        Node.SelectedImageIndex = IconNames.SearchAndApps();
                                        Node.ForeColor = EnabledColor;
                                    }
                                    else
                                    {
                                        Node.ImageIndex = IconNames.SearchGray();
                                        Node.SelectedImageIndex = IconNames.SearchGray();
                                        Node.ForeColor = DisabledColor;
                                    }
                                }
                                break;
                            case ActionType.RNG:
                                if (ActionNode.Enabled)
                                {
                                    Node.ImageIndex = IconNames.RNG();
                                    Node.SelectedImageIndex = IconNames.RNG();
                                    Node.ForeColor = EnabledColor;
                                }
                                else
                                {
                                    Node.ImageIndex = IconNames.RNG();
                                    Node.SelectedImageIndex = IconNames.RNG();
                                    Node.ForeColor = DisabledColor;
                                }
                                break;
                            case ActionType.RNGContainer:
                                if (ActionNode.Enabled)
                                {
                                    Node.ImageIndex = IconNames.RNGContainer();
                                    Node.SelectedImageIndex = IconNames.RNGContainer();
                                    Node.ForeColor = EnabledColor;
                                }
                                else
                                {
                                    Node.ImageIndex = IconNames.RNGContainerGray();
                                    Node.SelectedImageIndex = IconNames.RNGContainerGray();
                                    Node.ForeColor = DisabledColor;
                                }
                                break;
                            default:
                                Node.ImageIndex = IconNames.Event();
                                Node.SelectedImageIndex = IconNames.Event();
                                break;
                        }
                    }
                    break;
                case GameNodeType.Objects:
                    Node.ImageIndex = IconNames.EditMulitpleObjects();
                    Node.SelectedImageIndex = IconNames.EditMulitpleObjects();
                    break;
                case GameNodeType.ObjectScreenshot:
                    Node.ImageIndex = IconNames.RectangularScreenshot();
                    Node.SelectedImageIndex = IconNames.RectangularScreenshot();
                    break;
                case GameNodeType.Object:
                    Node.ImageIndex = IconNames.RectangularSelection();
                    Node.SelectedImageIndex = IconNames.RectangularSelection();
                    break;
                default:
                    Node.ImageIndex = IconNames.VideoGameController();
                    Node.SelectedImageIndex = IconNames.VideoGameController();
                    break;
            }

        }

        public static void SetIconsActionTypeAction(GameNodeAction Action)
        {
            switch (Action.Mode)
            {
                case Mode.RangeClick:
                    if (Action.Enabled)
                    {
                        Action.ImageIndex = IconNames.ButtonClick();
                        Action.SelectedImageIndex = IconNames.ButtonClick();
                        Action.ForeColor = Color.Black;
                    }
                    else
                    {
                        Action.ImageIndex = IconNames.ButtonClickGray();
                        Action.SelectedImageIndex = IconNames.ButtonClickGray();
                        Action.ForeColor = Color.LightGray;
                    }
                    break;
                case Mode.ClickDragRelease:
                    if (Action.Enabled)
                    {
                        Action.ImageIndex = IconNames.DependencyArrow();
                        Action.SelectedImageIndex = IconNames.DependencyArrow();
                        Action.ForeColor = Color.Black;

                    }
                    else
                    {
                        Action.ImageIndex = IconNames.DependencyArrow();
                        Action.SelectedImageIndex = IconNames.DependencyArrow();
                        Action.ForeColor = Color.LightGray;
                    }
                    break;
                default:
                    break;
            }
        }

        public static void DrawColorPoints(PaintEventArgs e, DataGridView dgv, String cellColorName, String xName, String yName)
        {
            int i = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    // do nothing
                }
                else
                {
                    if (row.Cells[cellColorName + "Red"].Value.IsSomething())
                    {
                        int R = row.Cells[cellColorName + "Red"].Value.ToString().ToInt();
                        int G = row.Cells[cellColorName + "Green"].Value.ToString().ToInt();
                        int B = row.Cells[cellColorName + "Blue"].Value.ToString().ToInt();

                        Color c = Color.FromArgb(R, G, B);

                        int x = row.Cells[xName].Value.ToString().ToInt();
                        int y = row.Cells[yName].Value.ToString().ToInt();
                        using (SolidBrush br = new SolidBrush(c))
                        {
                            using (Font f = new Font("Arial", 16, FontStyle.Bold))
                            {
                                SizeF fSize = e.Graphics.MeasureString(i.ToString(), f);

                                Single brightness = br.Color.GetBrightness();
                                if (brightness < 0.55)
                                {
                                    using (SolidBrush white = new SolidBrush(Color.WhiteSmoke))
                                    {
                                        e.Graphics.FillRectangle(white, x, y, fSize.Width, fSize.Height);
                                        using (Pen BlackPen = new Pen(Color.Black, 1))
                                        {
                                            e.Graphics.DrawRectangle(BlackPen, x, y, fSize.Width, fSize.Height);
                                        }
                                    }
                                }
                                else
                                {
                                    using (SolidBrush black = new SolidBrush(Color.Black))
                                    {
                                        using (Pen WhitePen = new Pen(Color.White, 1))
                                        {
                                            e.Graphics.FillRectangle(black, x, y, fSize.Width, fSize.Height);
                                            e.Graphics.DrawRectangle(WhitePen, x, y, fSize.Width, fSize.Height);
                                        }
                                    }
                                }
                                e.Graphics.DrawString(i.ToString(), f, br, x, y);
                            }
                            i++;
                        }
                    }
                }
            }
        }


        public static PointF Center(RectangleF r)
        {
            PointF Loc = r.Location;
            Loc.X += r.Width / 2;
            Loc.Y += r.Height / 2;
            return Loc;
        }

        public static void ClickDragRelease(IntPtr windowHandle, int startX, int startY, int endX, int endY, int VelocityMS)
        {
            int WM_PARENTNOTIFY = 0x210;
            uint WM_MOUSEMOVE = 0x200;
            uint WM_LBUTTONDOWN = 0x201;
            int WM_LBUTTONUP = 0x202;
            int MK_LBUTTON = 0x1;

            float CurrentX = (short)startX;
            float CurrentY = (short)startY;

            int MaxSteps = Math.Abs(endX - startX);

            if (Math.Abs(endY - startY) > MaxSteps)
            {
                MaxSteps = Math.Abs(endY - startY);
            }

            float XIncrement = (float)(endX - startX) / MaxSteps;
            float YIncrement = (float)(endY - startY) / MaxSteps;

            API.PostMessage(windowHandle, WM_MOUSEMOVE, 0, Utils.HiLoWord((short)CurrentX, (short)CurrentY));
            //'Send Mouse Down
            API.PostMessage(windowHandle, WM_LBUTTONDOWN, MK_LBUTTON, Utils.HiLoWord((short)CurrentX, (short)CurrentY));
            Thread.Sleep(10);

            int SleepTime = 1;
            int SkipEvery = 0;
            if (MaxSteps < VelocityMS)
            {
                if (MaxSteps > 0)
                {
                    SleepTime = VelocityMS / MaxSteps;
                }
            }
            else
            {
                SleepTime = 1;
                if (VelocityMS > 0)
                {
                    SkipEvery = MaxSteps / VelocityMS;
                }
            }

            int CurrentSkipEvery = SkipEvery;

            //'Send draging
            for (int i = 0; i < MaxSteps; i++)
            {
                API.PostMessage(windowHandle, WM_MOUSEMOVE, MK_LBUTTON, Utils.HiLoWord((short)CurrentX, (short)CurrentY));

                if (SkipEvery > 0)
                {
                    if (CurrentSkipEvery == 0)
                    {
                        Thread.Sleep(SleepTime);
                        CurrentSkipEvery = SkipEvery;
                    }
                    else if (CurrentSkipEvery > 0)
                    {
                        CurrentSkipEvery--;
                    }
                }
                else
                {
                    Thread.Sleep(SleepTime);
                }
                CurrentX = CurrentX + XIncrement;
                CurrentY = CurrentY + YIncrement;
            }

            Thread.Sleep(10);

            //' Send mouse Up
            API.SendMessage(windowHandle, WM_LBUTTONUP, 0, Utils.HiLoWordIntptr((short)CurrentX, (short)CurrentY));
        }


        public static void ClickOnWindow(IntPtr windowHandle, short xTarget, short yTarget, int MouseUpDelayMS)
        {
            int WM_SETCURSOR = 0x20;
            int HTCLIENT = 0x1;

            uint WM_MOUSEMOVE = 0x200;
            uint WM_LBUTTONDOWN = 0x201;
            uint WM_LBUTTONUP = 0x202;

            int MK_LBUTTON = 0x0001;
            //' PostMessage(WindowHandle, WM_MOUSEMOVE, 0, getHiLoWord(X, Y))
            //' SendMessage(WindowHandle, WM_SETCURSOR, WindowHandle, getHiLoWord(1, WM_MOUSEMOVE))
            //'Thread.Sleep(25)

            //'SendMessage(WindowHandle, WM_SETCURSOR, WindowHandle, getHiLoWord(1, WM_LBUTTONDOWN))

            API.PostMessage(windowHandle, WM_MOUSEMOVE, 0, Utils.HiLoWord(xTarget, yTarget));

            API.PostMessage(windowHandle, WM_LBUTTONDOWN, (int)MK_LBUTTON, Utils.HiLoWord(xTarget, yTarget));
            if (MouseUpDelayMS > 0)
            {
                Thread.Sleep(MouseUpDelayMS);
            }
            API.PostMessage(windowHandle, WM_LBUTTONUP, 0, Utils.HiLoWord(xTarget, yTarget));

        }

        static System.Random Generator = new System.Random();

        public static short RandomNumber(int min, int max)
        {
            if (max < 0)
            {
                return (short)-Generator.Next(min, Math.Abs(max));
            }
            else
            {
                return (short)Generator.Next(min, max);
            }
        }

        public class WindowHandles
        {
            public IntPtr MainWindowHandle;
            public IntPtr ChildWindowHandle;
        }

        public static string GetText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = API.GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            API.GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        public static IntPtr GetWindowHandleByWindowName(GameNodeGame game)
        {
            WindowNameFilterType PrimaryWindowNameFilter = WindowNameFilterType.Equals;
            WindowNameFilterType SecondaryWindowNameFilter = WindowNameFilterType.Equals;
            String PrimaryWindowName = "";
            String SecondaryWindowName = "";

            switch (game.Platform)
            {
                case Platform.NoxPlayer:
                    PrimaryWindowName = game.TargetWindow;
                    PrimaryWindowNameFilter = WindowNameFilterType.Equals;

                    SecondaryWindowName = Definitions.NoxWorkWindowName;
                    SecondaryWindowNameFilter = WindowNameFilterType.Equals;
                    break;
                case Platform.Steam:
                    PrimaryWindowName = game.SteamPrimaryWindowName;
                    SecondaryWindowName = game.SteamSecondaryWindowName;
                    PrimaryWindowNameFilter = game.SteamPrimaryWindowFilter;
                    SecondaryWindowNameFilter = game.SteamSecondaryWindowFilter;
                    break;
                case Platform.Application:
                    PrimaryWindowName = game.ApplicationPrimaryWindowName;
                    SecondaryWindowName = game.ApplicationSecondaryWindowName;
                    PrimaryWindowNameFilter = game.ApplicationPrimaryWindowFilter;
                    SecondaryWindowNameFilter = game.ApplicationSecondaryWindowFilter;
                    break;
                default:
                    break;
            }

            PrimaryWindowName = PrimaryWindowName.ToUpper();
            SecondaryWindowName = SecondaryWindowName.ToUpper();

            WindowHandles Handles = new WindowHandles();
            Process[] Processes = Process.GetProcesses();
            foreach (Process P in Processes)
            {
                if (P.MainWindowTitle.Length > 0)
                {
                    Boolean IsThisThePrimaryWindow = false;

                    switch (PrimaryWindowNameFilter)
                    {
                        case WindowNameFilterType.Equals:
                            if (P.MainWindowTitle.ToUpper() == PrimaryWindowName)
                            {
                                IsThisThePrimaryWindow = true;
                            }

                            break;
                        case WindowNameFilterType.StartsWith:
                            if (P.MainWindowTitle.ToUpper().StartsWith(PrimaryWindowName))
                            {
                                IsThisThePrimaryWindow = true;
                            }
                            break;
                        case WindowNameFilterType.Contains:
                            if (P.MainWindowTitle.ToUpper().Contains(PrimaryWindowName))
                            {
                                IsThisThePrimaryWindow = true;
                            }
                            break;
                        default:
                            break;
                    }

                    if (IsThisThePrimaryWindow)
                    {
                        Handles.MainWindowHandle = P.MainWindowHandle;

                        if (SecondaryWindowName.Length > 0)
                        {
                            WindowHandleInfo hi = new WindowHandleInfo(Handles.MainWindowHandle);
                            List<IntPtr> ChildWindowHandles = hi.GetAllChildHandles();

                            // ChildWindowName = "BlueStacks Android PluginAndroid";

                            foreach (IntPtr ChildHandle in ChildWindowHandles)
                            {
                                String ChildText = GetText(ChildHandle).ToUpper();

                                Boolean IsThisTheSecondaryWindow = false;

                                switch (SecondaryWindowNameFilter)
                                {
                                    case WindowNameFilterType.Equals:
                                        if (ChildText == SecondaryWindowName)
                                        {
                                            IsThisTheSecondaryWindow = true;
                                        }

                                        break;
                                    case WindowNameFilterType.StartsWith:
                                        if (ChildText.StartsWith(SecondaryWindowName))
                                        {
                                            IsThisTheSecondaryWindow = true;
                                        }
                                        break;
                                    case WindowNameFilterType.Contains:
                                        if (ChildText.Contains(SecondaryWindowName))
                                        {
                                            IsThisTheSecondaryWindow = true;
                                        }
                                        break;
                                    default:
                                        break;
                                }

                                if (IsThisTheSecondaryWindow)
                                {
                                    Handles.ChildWindowHandle = ChildHandle;
                                    return Handles.ChildWindowHandle;
                                }
                            }
                        }
                        break;
                    }
                }
            }
            if (SecondaryWindowName.Length > 0)
            {
                return Handles.ChildWindowHandle;
            }
            else
            {
                return Handles.MainWindowHandle;
            }
        }


        public static IntPtr GetWindowHandleByWindowName(String WindowName, String ChildWindowName)
        {
            WindowHandles Handles = new WindowHandles();
            Process[] Processes = Process.GetProcesses();
            foreach (Process P in Processes)
            {
                if (P.MainWindowTitle.Length > 0)
                {
                    if (P.MainWindowTitle == WindowName)
                    {
                        Handles.MainWindowHandle = P.MainWindowHandle;

                        WindowHandleInfo hi = new WindowHandleInfo(Handles.MainWindowHandle);
                        List<IntPtr> ChildWindowHandles = hi.GetAllChildHandles();

                        // ChildWindowName = "BlueStacks Android PluginAndroid";

                        if (ChildWindowName.Length > 0)
                        {
                            foreach (IntPtr ChildHandle in ChildWindowHandles)
                            {
                                String ChildText = GetText(ChildHandle);
                                if (ChildText.StartsWith(ChildWindowName))
                                {
                                    Handles.ChildWindowHandle = ChildHandle;
                                    return Handles.ChildWindowHandle;
                                }
                            }
                        }
                        break;
                    }
                }
            }
            if (ChildWindowName.Length > 0)
            {
                return Handles.ChildWindowHandle;
            }
            else
            {
                return Handles.MainWindowHandle;
            }
        }

        public static String CalculateDelay(DateTime dt)
        {
            if (dt < DateTime.Now)
            {
                return "";
            }

            TimeSpan ts = dt.Subtract(DateTime.Now);

            long Seconds = ts.TotalSeconds.ToLong();

            long Hours = Seconds / (60 * 60);
            Seconds = Seconds - (Hours * 60 * 60);

            long Minutes = Seconds / 60;
            Seconds = Seconds - (Minutes * 60);

            String Result = "";

            if (Hours > 0)
            {
                Result = Result + String.Format("{0}h ", Hours);
            }

            if (Minutes > 0)
            {
                Result = Result + String.Format("{0}m ", Minutes);
            }

            if (Seconds > 0)
            {
                Result = Result + String.Format("{0}s ", Seconds);
            }

            return Result;
        }

        public static Bitmap GetBitmapFromWindowHandle(IntPtr WindowHandle)
        {
            IntPtr IntPtrDeviceContext = API.GetDC(WindowHandle);  //GDI Alloc 1
            IntPtr IntPtrContext = API.CreateCompatibleDC(IntPtrDeviceContext);  // GDI Alloc 2

            API.RECT WindowRectangle = new API.RECT();

            API.GetWindowRect(WindowHandle, out WindowRectangle);

            int TargetWindowHeight = WindowRectangle.Bottom - WindowRectangle.Top;
            int TargetWindowWidth = WindowRectangle.Right - WindowRectangle.Left;

            IntPtr CompatibleBitmap = API.CreateCompatibleBitmap(IntPtrDeviceContext, TargetWindowWidth, TargetWindowHeight);   // GDI Alloc 3

            API.SelectObject(IntPtrContext, CompatibleBitmap);

            API.PrintWindow(WindowHandle, IntPtrContext, 2);

            Bitmap bmp = System.Drawing.Image.FromHbitmap(CompatibleBitmap);

            API.DeleteObject(CompatibleBitmap);  // GDI Dealloc 3
            API.DeleteDC(IntPtrContext); // GDI DeAlloc 2
            API.ReleaseDC(WindowHandle, IntPtrDeviceContext);  //GDI Dealloc 1

            return bmp;
        }

        public readonly static String ApplicationName = "App Test Studio";

        public static String GetApplicationFolder()
        {
            String MyDocuments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String DirectoryPath = System.IO.Path.Combine(MyDocuments, ApplicationName);
            return DirectoryPath;
        }

        // Makes sure the text displays white on black or black on white but not white on white.
        public static DataGridViewCellStyle GetDataGridViewCellStyleFromColor(Color color)
        {
            DataGridViewCellStyle Style = new DataGridViewCellStyle();
            Style.BackColor = color;

            Single brightness = color.GetBrightness();
            if (brightness > 0.80)
            {
                Style.ForeColor = Color.Black;
            }
            else if (brightness > 0.55)
            {
                Style.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                Style.ForeColor = Color.White;
            }

            return Style;

        }

        public static string LaunchApplication(String SteamExePath, String Arguments)
        {
            string Result;
            ProcessStartInfo info = new ProcessStartInfo(SteamExePath);
            //info.FileName = SteamExePath;
            info.WorkingDirectory = System.IO.Path.GetDirectoryName(SteamExePath);
            info.Arguments = Arguments;

            Result = "Launching: " + info.FileName + " " + info.Arguments;
            Process.Start(info);

            return Result;
        }

        public static string LaunchSteamInstance(String SteamExePath, long SteamID)
        {
            string Result;
            ProcessStartInfo info = new ProcessStartInfo(SteamExePath);

            info.WorkingDirectory = System.IO.Path.GetDirectoryName(SteamExePath);
            info.Arguments = @"-applaunch " + SteamID;

            //DOCO -hijack Take control of an existing instance of the game, if any, instead of complaining about already running.
            // We just want it running, if it's already running that's ok.
            info.Arguments = @"-applaunch " + SteamID + " -hijack";

            // Take hijack off, don't want to scare anyone in the log file.
            Result = "Launching: " + info.FileName + " " + info.Arguments.Replace(" -hijack", "");

            Process.Start(info);

            return Result;
        }

        public static String LaunchInstance(string packageName, string targetWindow, string instanceToLaunch, string resolution, int DPI)
        {
            String Result = "";
            ProcessStartInfo info = new ProcessStartInfo();
            NoxRegistry Registry = new NoxRegistry();


            info.FileName = Registry.ExePath;  //' "C:\Program Files (x86)\Nox\bin\nox.exe"
            info.WorkingDirectory = Registry.WorkingDirectory; //'"C:\Program Files (x86)\Nox\"

            String Arguments = "";

            if (packageName.Trim().Length > 0)
            {
                Arguments = " -package:" + packageName.Trim();
            }

            Arguments = Arguments + " -title:ATS" + instanceToLaunch + "Window";


            if (instanceToLaunch.Trim().Length > 0)
            {
                if (instanceToLaunch.Trim().IsNumeric())
                {
                    if (Arguments.Length > 0)
                    {
                        Arguments = Arguments + " ";
                    }
                    Arguments = Arguments + " -clone:Nox_" + instanceToLaunch.Trim();
                }
            }

            Arguments = Arguments + " -resolution:" + resolution;

            Arguments = Arguments + " -dpi:" + DPI.ToString();

            //'-clone:Nox_1
            info.Arguments = Arguments;

            Result = "Launching: " + info.FileName + " " + info.Arguments;
            Process.Start(info);

            return Result;
        }

        public static int HiLoWord(short lo, short hi)
        {
            int hi2 = hi << 16;
            hi2 = hi2 | lo;

            return hi2;
        }

        public static IntPtr HiLoWordIntptr(short lo, short hi)
        {
            return new IntPtr(HiLoWord(lo, hi));
        }

        public static String CalculateDelay(int hour, int minute, int second, int ms)
        {
            String Time = "";

            if (hour > 0)
            {
                Time = hour + "h ";
            }



            if (minute > 0)
            {
                Time = Time + minute + "m ";
            }



            if (second > 0)
            {
                Time = Time + second + "s ";
            }



            if (ms > 0)
            {
                Time = Time + ms + "ms";
            }


            if (Time.Length == 0)
            {
                return "0 ms";
            }
            return Time;
        }

        internal static void DrawMask(GameNodeAction Node, PictureBox pictureBox1, Rectangle pictureBox1Rectangle, PaintEventArgs e)
        {
            try
            {

                if (pictureBox1.Image.IsSomething())
                {
                    if (pictureBox1Rectangle.Width > 0 && pictureBox1Rectangle.Height > 0)
                    {
                        using (Pen p = new Pen(Color.FromArgb(0, 0, 255)))
                        {
                            int TargetWidth = pictureBox1.Width;
                            int TargetHeight = pictureBox1.Height;

                            int CenterX = pictureBox1Rectangle.X + (pictureBox1Rectangle.Width / 2);
                            int CenterY = pictureBox1Rectangle.Y + (pictureBox1Rectangle.Height / 2);

                            int TopOfMaskY = pictureBox1Rectangle.Y;
                            int BottomOfMaskY = pictureBox1Rectangle.Height + pictureBox1Rectangle.Y;

                            int StartOfMaskX = pictureBox1Rectangle.X;
                            int RightOfMaskX = pictureBox1Rectangle.Width + pictureBox1Rectangle.X;



                            Font stringFont = new Font("Arial", 16);

                            SizeF TextSize = e.Graphics.MeasureString("Testing123", stringFont);


                            Debug.WriteLine("Node.Anchor" + Node.Anchor);
                            Debug.WriteLine("pictureBox1Rectangle: " + pictureBox1Rectangle);
                            Debug.WriteLine("Width:" + TargetWidth + " Height:" + TargetHeight);
                            Debug.WriteLine("TS:" + TextSize.Width + "," + TextSize.Height);

                            // Draw Blue Line from Top to Center of the Top of the Mask
                            e.Graphics.DrawLine(p, CenterX, 0, CenterX, TopOfMaskY);

                            // Draw Blue Line from Center of the Bottom of the Mask to the bottom of the image
                            e.Graphics.DrawLine(p, CenterX, BottomOfMaskY, CenterX, TargetHeight);

                            // Draw Blue Line from 0 to Middle of the Right Mask.
                            e.Graphics.DrawLine(p, 0, CenterY, StartOfMaskX, CenterY);


                            // Draw Blue Line from Right of Mask to the right of the image
                            e.Graphics.DrawLine(p, RightOfMaskX, CenterY, TargetWidth, CenterY);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("DrawMask:" + ex.Message);
            }


            DrawMask(pictureBox1, pictureBox1Rectangle, e);
        }

        internal static void DrawMask(PictureBox pictureBox1, Rectangle pictureBox1Rectangle, PaintEventArgs e)
        {
            if (pictureBox1.Image.IsSomething())
            {
                if (pictureBox1Rectangle.Width > 0 && pictureBox1Rectangle.Height > 0)
                {
                    using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                    {
                        Rectangle Top = new Rectangle();
                        Top.X = 0;
                        Top.Y = 0;
                        Top.Height = pictureBox1Rectangle.Y;
                        Top.Width = pictureBox1.Image.Width;
                        e.Graphics.FillRectangle(br, Top);

                        Rectangle Bottom = new Rectangle();
                        Bottom.X = 0;
                        Bottom.Y = pictureBox1Rectangle.Y + pictureBox1Rectangle.Height;
                        Bottom.Height = pictureBox1.Image.Height - Bottom.Y;
                        Bottom.Width = pictureBox1.Image.Width;
                        e.Graphics.FillRectangle(br, Bottom);

                        Rectangle Left = new Rectangle();
                        Left.Y = pictureBox1Rectangle.Y;
                        Left.X = 0;
                        Left.Height = pictureBox1Rectangle.Height;
                        Left.Width = pictureBox1Rectangle.X;
                        e.Graphics.FillRectangle(br, Left);

                        Rectangle Right = new Rectangle();
                        Right.Y = pictureBox1Rectangle.Y;
                        Right.X = pictureBox1Rectangle.X + pictureBox1Rectangle.Width;
                        Right.Height = pictureBox1Rectangle.Height;
                        Right.Width = pictureBox1.Image.Width - Right.X;
                        e.Graphics.FillRectangle(br, Right);
                    }

                    using (Pen p = new Pen(Color.Blue, 1))
                    {
                        e.Graphics.DrawRectangle(p, pictureBox1Rectangle);
                    }
                }
            }
        }

        internal static String ExtendCustomLogic(String expression)
        {
            return expression.ToUpper().Replace("AND", " AND ").Replace("OR", " OR ").Replace("NOT", " NOT ").Replace("(", " ( ").Replace(")", " ) ").Replace("||", " OR ").Replace("&&", " AND ").Replace("|", " OR ").Replace("&", " AND ").Replace("!", " NOT ");
        }

        public static WindowNameFilterType GetEnumTypeFromFilterName(String FilterNameText)
        {
            FilterNameText = FilterNameText.Trim().ToUpper();
            WindowNameFilterType FilterType = WindowNameFilterType.Equals;

            switch (FilterNameText)
            {
                case "EQUALS":
                    FilterType = WindowNameFilterType.Equals;
                    break;
                case "STARTS WITH":
                    FilterType = WindowNameFilterType.StartsWith;
                    break;
                case "CONTAINS":
                    FilterType = WindowNameFilterType.Contains;
                    break;
                default:
                    FilterType = WindowNameFilterType.Equals;
                    break;
            }

            return FilterType;
        }
    }

}
