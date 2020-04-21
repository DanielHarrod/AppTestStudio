// This code is distributed under MIT license. 
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

namespace AppTestStudio
{
    public static class Utils
    {
        public static void SetIcons(GameNode Node)
        {
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
                case GameNodeType.Event:
                    Node.ImageIndex = IconNames.Event();
                    Node.SelectedImageIndex = IconNames.Event();
                    break;
                case GameNodeType.Action:
                    GameNodeAction ActionNode = Node as GameNodeAction;
                    if (ActionNode.IsSomething())
                    {
                        switch (ActionNode.ActionType)
                        {
                            case ActionType.Action:
                                switch (ActionNode.Mode)
                                {
                                    case Mode.RangeClick:
                                        Node.ImageIndex = IconNames.ButtonClick();
                                        Node.SelectedImageIndex = IconNames.ButtonClick();
                                        break;
                                    case Mode.ClickDragRelease:
                                        Node.ImageIndex = IconNames.DependencyArrow();
                                        Node.SelectedImageIndex = IconNames.DependencyArrow();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case ActionType.Event:
                                if (ActionNode.IsColorPoint)
                                {
                                    Node.ImageIndex = IconNames.Event();
                                    Node.SelectedImageIndex = IconNames.Event();
                                }
                                else
                                {
                                    Node.ImageIndex = IconNames.SearchAndApps();
                                    Node.SelectedImageIndex = IconNames.SearchAndApps();
                                }
                                break;
                            case ActionType.RNG:
                                Node.ImageIndex = IconNames.RNG();
                                Node.SelectedImageIndex = IconNames.RNG();
                                break;
                            case ActionType.RNGContainer:
                                Node.ImageIndex = IconNames.RNGContainer();
                                Node.SelectedImageIndex = IconNames.RNGContainer();
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
                    Color c = Color.Empty;
                    c = c.FromRGBString(row.Cells[cellColorName].Value.ToString());
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


        public static PointF Center(RectangleF r)
        {
            PointF Loc = r.Location;
            Loc.X += r.Width / 2;
            Loc.Y += r.Height / 2;
            return Loc;
        }

        public static void ClickDragRelease(IntPtr windowHandle, int startX, int startY, int endX, int endY)
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

            //'Send Mouse Down
            API.PostMessage(windowHandle, WM_LBUTTONDOWN, MK_LBUTTON, Utils.HiLoWord((short)CurrentX, (short)CurrentY));
            Thread.Sleep(10);


            //'Send draging
            for (int i = 0; i < MaxSteps; i++)
            {
                API.PostMessage(windowHandle, WM_MOUSEMOVE, MK_LBUTTON, Utils.HiLoWord((short)CurrentX, (short)CurrentY));
                Thread.Sleep(1);

                CurrentX = CurrentX + XIncrement;
                CurrentY = CurrentY + YIncrement;
            }

            Thread.Sleep(10);

            //' Send mouse Up
            API.SendMessage(windowHandle, WM_LBUTTONUP, 0, Utils.HiLoWordIntptr((short)CurrentX, (short)CurrentY));
        }


        public static void ClickOnWindow(IntPtr windowHandle, short xTarget, short yTarget)
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

            API.PostMessage(windowHandle, WM_LBUTTONDOWN, (int)WM_LBUTTONDOWN, Utils.HiLoWord(xTarget, yTarget));
            //'Thread.Sleep(25)
            API.PostMessage(windowHandle, WM_LBUTTONUP, 0, Utils.HiLoWord(xTarget, yTarget));

        }

        static System.Random Generator = new System.Random();

        public static short RandomNumber(int min, int max)
        {
            return (short)Generator.Next(min, max);
        }

        public static IntPtr GetWindowHandleByWindowName(String WindowName)
        {
            foreach (Process P in Process.GetProcesses())
            {
                if (P.MainWindowTitle.Length > 0)
                {
                    if (P.MainWindowTitle == WindowName)
                    {
                        return P.MainWindowHandle;
                    }
                }
            }
            return new IntPtr(0);
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
            if ( brightness > 0.80)
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


        public static void LaunchInstance(string packageName, string targetWindow, string instanceToLaunch, string resolution)
        {
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

            //'-clone:Nox_1
            info.Arguments = Arguments;
            Process.Start(info);
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
    }

}
