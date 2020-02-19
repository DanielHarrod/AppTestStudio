using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                                        Node.ImageIndex = IconNames.DependencyArrow();
                                        Node.SelectedImageIndex = IconNames.DependencyArrow();
                                        break;
                                    case Mode.ClickDragRelease:
                                        Node.ImageIndex = IconNames.ButtonClick();
                                        Node.SelectedImageIndex = IconNames.ButtonClick();
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

        public static PointF Center(RectangleF r)
        {
            PointF Loc = r.Location;
            Loc.X += r.Width / 2;
            Loc.Y += r.Height / 2;
            return Loc;
        }

        public static int GetWindowHandleByWindowName(String WindowName)
        {              
            foreach (Process P in Process.GetProcesses())
            {
                if (P.MainWindowTitle.Length > 0)
                {
                    if (P.MainWindowTitle == WindowName)
                    {
                        return P.MainWindowHandle.ToInt32();
                    }
                }
            }
            return 0;
        }

        public static String CalculateDelay(DateTime dt)
        {
            if ( dt < DateTime.Now)
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

            if ( Hours > 0 )
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

        public static Bitmap GetBitmapFromWindowHandle( int WindowHandle)
        {
            IntPtr IntPtrWindowHandle = new IntPtr(WindowHandle);

            IntPtr IntPtrDeviceContext = API.GetDC(IntPtrWindowHandle);  //GDI Alloc 1
            IntPtr IntPtrContext = API.CreateCompatibleDC(IntPtrDeviceContext);  // GDI Alloc 2

            API.RECT WindowRectangle = new API.RECT();

            API.GetWindowRect(IntPtrWindowHandle, out WindowRectangle);

            int TargetWindowHeight = WindowRectangle.Bottom - WindowRectangle.Top;
            int TargetWindowWidth = WindowRectangle.Right - WindowRectangle.Left;

            IntPtr CompatibleBitmap = API.CreateCompatibleBitmap(IntPtrDeviceContext, TargetWindowWidth, TargetWindowHeight);   // GDI Alloc 3

            API.SelectObject(IntPtrContext, CompatibleBitmap);

            API.PrintWindow(IntPtrWindowHandle, IntPtrContext, 2);

            Bitmap bmp = System.Drawing.Image.FromHbitmap(CompatibleBitmap);

            API.DeleteObject(CompatibleBitmap);  // GDI Dealloc 3
            API.DeleteDC(IntPtrContext); // GDI DeAlloc 2
            API.ReleaseDC(IntPtrWindowHandle, IntPtrDeviceContext);  //GDI Dealloc 1

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
            if (brightness > 0.55)
            {
                Style.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                Style.ForeColor = Color.Black;
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

        if (packageName.Trim().Length > 0 )
            {
                Arguments = " -package:" + packageName.Trim();
        }

            Arguments = Arguments + " -title:ATS" + instanceToLaunch + "Window";


            if (instanceToLaunch.Trim().Length > 0) { 
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


    }
}
