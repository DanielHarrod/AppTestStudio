//AppTestStudio 
//Copyright (C) 2016-2021 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using static AppTestStudio.API;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;

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
                    Node.ImageIndex = IconNames.AppRoot;
                    Node.SelectedImageIndex = IconNames.AppRoot;

                    break;
                case GameNodeType.Games:
                    break;
                case GameNodeType.Game:
                    break;
                case GameNodeType.Events:
                    Node.ImageIndex = IconNames.Home;
                    Node.SelectedImageIndex = IconNames.Home;
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
                                        if ( ActionNode.ClickList.Count > 0 )
                                        {
                                            Node.ImageIndex = IconNames.Event;
                                            Node.SelectedImageIndex = IconNames.Event;
                                        }
                                        else
                                        {
                                            Node.ImageIndex = IconNames.Group;
                                            Node.SelectedImageIndex = IconNames.Group;
                                        }

                                        Node.ForeColor = EnabledColor;
                                    }
                                    else
                                    {
                                        if (ActionNode.ClickList.IsSomething())
                                        {
                                            if (ActionNode.ClickList.Count > 0)
                                            {
                                                Node.ImageIndex = IconNames.EventGray;
                                                Node.SelectedImageIndex = IconNames.EventGray;
                                            }
                                            else
                                            {
                                                Node.ImageIndex = IconNames.GroupGray;
                                                Node.SelectedImageIndex = IconNames.GroupGray;
                                            }
                                        }
                                        else
                                        {
                                            Node.ImageIndex = IconNames.GroupGray;
                                            Node.SelectedImageIndex = IconNames.GroupGray;
                                        }

                                        Node.ForeColor = DisabledColor;
                                    }
                                }
                                else
                                {
                                    if (ActionNode.Enabled)
                                    {
                                        Node.ImageIndex = IconNames.SearchAndApps;
                                        Node.SelectedImageIndex = IconNames.SearchAndApps;
                                        Node.ForeColor = EnabledColor;
                                    }
                                    else
                                    {
                                        Node.ImageIndex = IconNames.SearchGray;
                                        Node.SelectedImageIndex = IconNames.SearchGray;
                                        Node.ForeColor = DisabledColor;
                                    }
                                }
                                break;
                            case ActionType.RNG:
                                if (ActionNode.Enabled)
                                {
                                    Node.ImageIndex = IconNames.RNG;
                                    Node.SelectedImageIndex = IconNames.RNG;
                                    Node.ForeColor = EnabledColor;
                                }
                                else
                                {
                                    Node.ImageIndex = IconNames.RNG;
                                    Node.SelectedImageIndex = IconNames.RNG;
                                    Node.ForeColor = DisabledColor;
                                }
                                break;
                            case ActionType.RNGContainer:
                                if (ActionNode.Enabled)
                                {
                                    Node.ImageIndex = IconNames.RNGContainer;
                                    Node.SelectedImageIndex = IconNames.RNGContainer;
                                    Node.ForeColor = EnabledColor;
                                }
                                else
                                {
                                    Node.ImageIndex = IconNames.RNGContainerGray;
                                    Node.SelectedImageIndex = IconNames.RNGContainerGray;
                                    Node.ForeColor = DisabledColor;
                                }
                                break;
                            default:
                                Node.ImageIndex = IconNames.Event;
                                Node.SelectedImageIndex = IconNames.Event;
                                break;
                        }
                    }
                    break;
                case GameNodeType.Objects:
                    Node.ImageIndex = IconNames.EditMulitpleObjects;
                    Node.SelectedImageIndex = IconNames.EditMulitpleObjects;
                    break;
                case GameNodeType.ObjectScreenshot:
                    Node.ImageIndex = IconNames.RectangularScreenshot;
                    Node.SelectedImageIndex = IconNames.RectangularScreenshot;
                    break;
                case GameNodeType.Object:
                    Node.ImageIndex = IconNames.RectangularSelection;
                    Node.SelectedImageIndex = IconNames.RectangularSelection;
                    break;
                default:
                    Node.ImageIndex = IconNames.VideoGameController;
                    Node.SelectedImageIndex = IconNames.VideoGameController;
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
                        Action.ImageIndex = IconNames.ButtonClick;
                        Action.SelectedImageIndex = IconNames.ButtonClick;
                        Action.ForeColor = Color.Black;
                    }
                    else
                    {
                        Action.ImageIndex = IconNames.ButtonClickGray;
                        Action.SelectedImageIndex = IconNames.ButtonClickGray;
                        Action.ForeColor = Color.LightGray;
                    }
                    break;
                case Mode.ClickDragRelease:
                    if (Action.Enabled)
                    {
                        Action.ImageIndex = IconNames.DependencyArrow;
                        Action.SelectedImageIndex = IconNames.DependencyArrow;
                        Action.ForeColor = Color.Black;

                    }
                    else
                    {
                        Action.ImageIndex = IconNames.DependencyArrow;
                        Action.SelectedImageIndex = IconNames.DependencyArrow;
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

        // 1. Mouse Down at startx/y
        // 2. Mouse Move to endx/y
        // 3. Mouse Up at endx/y
        public static void ClickDragReleaseActive(IntPtr windowHandle, int startX, int startY, int endX, int endY, int velocityMS, int mouseInitialClickDelayMS)
        {
            MoveMouseActiveFromStartPosition(windowHandle, MouseEventFlags.LeftDown, (short)startX, (short)startY, (short)endX, (short)endY, velocityMS, mouseInitialClickDelayMS);
        }

        private static Boolean ActivateWindowIfNecessary(IntPtr windowHandle, WindowAction windowAction, int startX, int startY)
        {
            Boolean Result = false;
            API.RECT TargetWindowRectangle;
            Boolean WindowRectResult = AppTestStudio.API.GetWindowRect(windowHandle, out TargetWindowRectangle);
            short xSystemTargetStartPosition = (short)(startX + TargetWindowRectangle.Left);
            short ySystemTargetStartPosition = (short)(startY + +TargetWindowRectangle.Top);
            System.Drawing.Point p = new System.Drawing.Point();
            p.X = xSystemTargetStartPosition;
            p.Y = ySystemTargetStartPosition;
            IntPtr WindowHandleAtStartPosition = API.WindowFromPoint(p);

            IntPtr ParentWindowHandleAtStartPosition = API.GetAncestor(WindowHandleAtStartPosition, GetAncestorFlags.GetRoot);
            IntPtr ParentWindowHandleOfApplication = API.GetAncestor(windowHandle, GetAncestorFlags.GetRoot);
            if (ParentWindowHandleOfApplication != ParentWindowHandleAtStartPosition)
            {
                switch (windowAction)
                {
                    case WindowAction.DoNothing:
                        break;
                    case WindowAction.ActivateWindow:
                        API.SetForegroundWindow(ParentWindowHandleOfApplication);
                        Result = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Result = true;
            }

            return Result;
        }

        public static void ClickDragReleasePassive(IntPtr windowHandle, int startX, int startY, int endX, int endY, int velocityMS, int mouseInitialClickDelayMS)
        {
            API.PostMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, Definitions.MouseKeyStates.MK_NONE, Utils.HiLoWord(startX, startY));

            //'Send Mouse Down
            API.PostMessage(windowHandle, Definitions.MouseInputNotifications.WM_LBUTTONDOWN, Definitions.MouseKeyStates.MK_LBUTTON, Utils.HiLoWord(startX, startY));

            MoveMousePassive(windowHandle, Definitions.MouseKeyStates.MK_LBUTTON, startX, startY, endX, endY, velocityMS, mouseInitialClickDelayMS);

            //' Send mouse Up
            API.SendMessage(windowHandle, Definitions.MouseInputNotifications.WM_LBUTTONUP, Definitions.MouseKeyStates.MK_NONE, Utils.HiLoWordIntptr(endX, endY));
        }

        public static void ClickDragRelease(IntPtr windowHandle, MouseMode mouseMode, Boolean moveMouseFirst, WindowAction windowAction, int startX, int startY, int endX, int endY, int velocityMS, int mouseSpeedPixelsPerSecond, int mouseInitialClickDelayMS)
        {
            switch (mouseMode)
            {
                case MouseMode.Passive:
                    ClickDragReleasePassive(windowHandle, startX, startY, endX, endY, velocityMS, mouseInitialClickDelayMS);
                    break;
                case MouseMode.Active:
                    Boolean Continue = ActivateWindowIfNecessary(windowHandle, windowAction, startX, startY);
                    if ( Continue == false)
                    {
                        return;
                    }
                    if (moveMouseFirst)
                    {
                        MoveMouseActiveFromSystemPosition(windowHandle, MouseEventFlags.Blank, startX, startY, mouseSpeedPixelsPerSecond);
                    }
                    ClickDragReleaseActive(windowHandle, startX, startY, endX, endY, velocityMS, mouseInitialClickDelayMS);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        public static int MoveMousePassive(IntPtr windowHandle, int mouseKeyState, int xStart, int yStart, int xTarget, int yTarget, int velocityMS, int mouseInitialClickDelayMS)
        {
            return MoveMousePassive(windowHandle, mouseKeyState, (short)xStart, (short)yStart, (short)xTarget, (short)yTarget, (short)velocityMS, mouseInitialClickDelayMS);
        }

        public static int MoveMouseActiveFromStartPosition(IntPtr windowHandle, MouseEventFlags mouseEventFlags, short xClientStart, short yClientStart, short xClientTarget, short yClientTarget, int velocityMS, int mouseInitialClickDelayMS)
        {
            //windowHandle = GetAncestor(windowHandle, GetAncestorFlags.GetRoot);
            API.RECT TargetWindowRectangle;
            Boolean WindowRectResult = AppTestStudio.API.GetWindowRect(windowHandle, out TargetWindowRectangle);

            //Debug.WriteLine("xClientTarget:" + xClientTarget);
            //Debug.WriteLine("yClientTarget:" + yClientTarget);
            //Debug.WriteLine("Right:" + TargetWindowRectangle.Right);
            //Debug.WriteLine("Left:" + TargetWindowRectangle.Left);

            //RECT WindowFrame;

            //int Result = API.DwmGetWindowAttribute(windowHandle, DWMWINDOWATTRIBUTE.ExtendedFrameBounds, out WindowFrame, Marshal.SizeOf(typeof(RECT)));

            RECT ClientRect;
            API.GetClientRect(windowHandle, out ClientRect);

            short xSystemTarget = (short)(xClientTarget + TargetWindowRectangle.Left);

            //short ySystemTarget = (short)(yClientTarget + WindowFrame.Bottom - ClientRect.Bottom);
            short ySystemTarget = (short)(yClientTarget + TargetWindowRectangle.Top);

            short xSystemStart = (short)(xClientStart + TargetWindowRectangle.Left);
            short ySystemStart = (short)(yClientStart + TargetWindowRectangle.Top);

            int PostCount = 0;
            int PostEveryMS = 30;

            float CurrentX = xSystemStart;
            float CurrentY = ySystemStart;
           
            int Distance = GetDistanceABS(xSystemStart, ySystemStart, xSystemTarget, ySystemTarget);
            Debug.WriteLine(Distance);

            int NumberOfActions = velocityMS / PostEveryMS;

            int AbsoluteX = 0;
            int AbsoluteY = 0;
            int INPUT_MOUSE = 0;

            Input MouseMove = new Input();


            // Don't post the Start move if there's a 0ms delay 
            if (velocityMS > 0)
            {

                AbsoluteX = CalculateAbsoluteCoordinateX(CurrentX);
                AbsoluteY = CalculateAbsoluteCoordinateY(CurrentY);

                MouseMove.Type = INPUT_MOUSE;
                MouseMove.u.MouseInput.X = AbsoluteX;
                MouseMove.u.MouseInput.Y = AbsoluteY;
                MouseMove.u.MouseInput.MouseData = 0;
                MouseMove.u.MouseInput.Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);

                Input[] InputInitial = { MouseMove };
                SendInput((uint)InputInitial.Length, InputInitial, Marshal.SizeOf(typeof(Input)));
                PostCount++;
            }

            if (NumberOfActions > 0)
            {
                float XIncrement = (float)(xSystemTarget - xSystemStart) / NumberOfActions;
                float YIncrement = (float)(ySystemTarget - ySystemStart) / NumberOfActions;
                int CurrentAction = 0;
                for (CurrentAction = 0; CurrentAction < NumberOfActions; CurrentAction++)
                {
                    AbsoluteX = CalculateAbsoluteCoordinateX(CurrentX);
                    AbsoluteY = CalculateAbsoluteCoordinateY(CurrentY);

                    MouseMove.Type = INPUT_MOUSE;
                    MouseMove.u.MouseInput.X = AbsoluteX;
                    MouseMove.u.MouseInput.Y = AbsoluteY;
                    MouseMove.u.MouseInput.MouseData = 0;
                    MouseMove.u.MouseInput.Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);

                    Input[] InputMove = { MouseMove };
                    SendInput((uint)InputMove.Length, InputMove, Marshal.SizeOf(typeof(Input)));

                    PostCount++;
                    if (CurrentAction == 0)
                    {
                        Thread.Sleep(mouseInitialClickDelayMS);
                    }

                    Thread.Sleep(PostEveryMS);

                    CurrentX = CurrentX + XIncrement;
                    CurrentY = CurrentY + YIncrement;
                }
            }

            AbsoluteX = CalculateAbsoluteCoordinateX(xSystemTarget);
            AbsoluteY = CalculateAbsoluteCoordinateY(ySystemTarget);

            MouseMove.Type = INPUT_MOUSE;
            MouseMove.u.MouseInput.X = AbsoluteX;
            MouseMove.u.MouseInput.Y = AbsoluteY;
            MouseMove.u.MouseInput.MouseData = 0;

            switch (mouseEventFlags)
            {
                case MouseEventFlags.Move:
                    break;
                case MouseEventFlags.LeftDown:
                    mouseEventFlags = MouseEventFlags.LeftUp;
                    break;
                case MouseEventFlags.LeftUp:
                    break;
                case MouseEventFlags.RightDown:
                    mouseEventFlags = MouseEventFlags.RightUp;
                    break;
                case MouseEventFlags.RightUp:
                    break;
                case MouseEventFlags.MiddleDown:
                    mouseEventFlags = MouseEventFlags.MiddleUp;
                    break;
                case MouseEventFlags.MiddleUp:
                    break;
                case MouseEventFlags.XDown:
                    mouseEventFlags = MouseEventFlags.XUp;
                    break;
                case MouseEventFlags.XUp:
                    break;
                case MouseEventFlags.Wheel:
                    break;
                case MouseEventFlags.VirtualDesk:
                    break;
                case MouseEventFlags.Absolute:
                    break;
                case MouseEventFlags.Blank:
                    break;
                default:
                    break;
            }

            MouseMove.u.MouseInput.Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);

            Input[] InputEnd = { MouseMove };
            SendInput((uint)InputEnd.Length, InputEnd, Marshal.SizeOf(typeof(Input)));
            PostCount++;

            return PostCount;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static int MoveMouseActiveFromSystemPosition(IntPtr windowHandle, MouseEventFlags mouseEventFlags, int xClientTarget, int yClientTarget, int mouseSpeedPixelsPerSecond, EasingFunctionBase easingFunction = null)
        {
            return MoveMouseActiveFromSystemPosition(windowHandle, mouseEventFlags, (short) xClientTarget, (short)yClientTarget, mouseSpeedPixelsPerSecond);
        }
        public static int MoveMouseActiveFromSystemPosition(IntPtr windowHandle, MouseEventFlags mouseEventFlags, short xClientTarget, short yClientTarget, int mouseSpeedPixelsPerSecond, EasingFunctionBase easingFunction = null)
        {
             API.RECT TargetWindowRectangle;
            Boolean WindowRectResult = AppTestStudio.API.GetWindowRect(windowHandle, out TargetWindowRectangle);

            RECT ClientRect;
            API.GetClientRect(windowHandle, out ClientRect);

            short xSystemTarget = (xClientTarget + TargetWindowRectangle.Left).ToShort();

            short ySystemTarget = (yClientTarget + +TargetWindowRectangle.Top).ToShort();

            GetCursorPos(out API.Point point);
            int xStart = point.X;
            int yStart = point.Y;

            int PostCount = 0;
            int PostEveryMS = 30;

            float CurrentX = xStart;
            float CurrentY = yStart;

            int velocityMS = GetMoveDurationMSFromPixelsPerSecond(xStart, yStart, xSystemTarget.ToInt(), ySystemTarget.ToInt(), mouseSpeedPixelsPerSecond);

            int NumberOfActions = velocityMS / PostEveryMS;

            int AbsoluteX = 0;
            int AbsoluteY = 0;
            int INPUT_MOUSE = 0;

            Input MouseMove = new Input();

            // Don't post the Start move if there's a 0ms delay
            if (velocityMS > 0)
            {
                AbsoluteX = CalculateAbsoluteCoordinateX(CurrentX);
                AbsoluteY = CalculateAbsoluteCoordinateY(CurrentY);

                MouseMove.Type = INPUT_MOUSE;
                MouseMove.u.MouseInput.X = AbsoluteX;
                MouseMove.u.MouseInput.Y = AbsoluteY;
                MouseMove.u.MouseInput.MouseData = 0;
                MouseMove.u.MouseInput.Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);

                Input[] InputInitial = { MouseMove };
                SendInput((uint)InputInitial.Length, InputInitial, Marshal.SizeOf(typeof(Input)));

                PostCount++;
            }

            if (NumberOfActions > 0)
            {
                if (easingFunction.IsNothing())
                {
                    // if no easing function use power ease 2, if you want a consistent velocity pass in "easingFuction = new PowerEase() { Power = 1 };
                    easingFunction = new PowerEase() { Power = 2 };
                }

                float xDistance = (float)(xSystemTarget - xStart);
                float yDistance = (float)(ySystemTarget - yStart);

                //Adding Easing
                //float XIncrement = (float)(xSystemTarget - xStart) / NumberOfActions;
                //float YIncrement = (float)(ySystemTarget - yStart) / NumberOfActions;
                int CurrentAction = 0;
                for (CurrentAction = 0; CurrentAction < NumberOfActions; CurrentAction++)
                {
                    // Easing
                    double CurrentPercent = easingFunction.Ease((double)CurrentAction / NumberOfActions);

                    double CurrentXPosition = xStart + (xDistance * CurrentPercent);
                    double CurrentYPosition = yStart + (yDistance * CurrentPercent);

                    Debug.WriteLine("CA:" + CurrentAction + ", NOA: " + NumberOfActions);

                    AbsoluteX = CalculateAbsoluteCoordinateX(CurrentXPosition);
                    AbsoluteY = CalculateAbsoluteCoordinateY(CurrentYPosition);

                    // Adding Easing
                    //AbsoluteX = CalculateAbsoluteCoordinateX(CurrentX);
                    //AbsoluteY = CalculateAbsoluteCoordinateY(CurrentY);

                    //Debug.WriteLine(CurrentX + "x:" + CurrentXPosition);
                    //Debug.WriteLine(CurrentY + "y:" + CurrentYPosition);

                    MouseMove.Type = INPUT_MOUSE;
                    MouseMove.u.MouseInput.X = AbsoluteX;
                    MouseMove.u.MouseInput.Y = AbsoluteY;
                    MouseMove.u.MouseInput.MouseData = 0;
                    MouseMove.u.MouseInput.Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);

                    Input[] InputMove = { MouseMove };
                    SendInput((uint)InputMove.Length, InputMove, Marshal.SizeOf(typeof(Input)));

                    PostCount++;

                    Thread.Sleep(PostEveryMS);

                    // Adding Easing
                    //CurrentX = CurrentX + XIncrement;
                    //CurrentY = CurrentY + YIncrement;
                }
            }

            AbsoluteX = CalculateAbsoluteCoordinateX(xSystemTarget);
            AbsoluteY = CalculateAbsoluteCoordinateY(ySystemTarget);

            MouseMove.Type = INPUT_MOUSE;
            MouseMove.u.MouseInput.X = AbsoluteX;
            MouseMove.u.MouseInput.Y = AbsoluteY;
            MouseMove.u.MouseInput.MouseData = 0;

            switch (mouseEventFlags)
            {
                case MouseEventFlags.Move:
                    break;
                case MouseEventFlags.LeftDown:
                    mouseEventFlags = MouseEventFlags.LeftUp;
                    break;
                case MouseEventFlags.LeftUp:
                    break;
                case MouseEventFlags.RightDown:
                    mouseEventFlags = MouseEventFlags.RightUp;
                    break;
                case MouseEventFlags.RightUp:
                    break;
                case MouseEventFlags.MiddleDown:
                    mouseEventFlags = MouseEventFlags.MiddleUp;
                    break;
                case MouseEventFlags.MiddleUp:
                    break;
                case MouseEventFlags.XDown:
                    mouseEventFlags = MouseEventFlags.XUp;
                    break;
                case MouseEventFlags.XUp:
                    break;
                case MouseEventFlags.Wheel:
                    break;
                case MouseEventFlags.VirtualDesk:
                    break;
                case MouseEventFlags.Absolute:
                    break;
                case MouseEventFlags.Blank:
                    break;
                default:
                    break;
            }

            MouseMove.u.MouseInput.Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);

            Input[] InputEnd = { MouseMove };
            SendInput((uint)InputEnd.Length, InputEnd, Marshal.SizeOf(typeof(Input)));
            PostCount++;

            return PostCount;
        }


        public static int MoveMousePassive(IntPtr windowHandle, int mouseKeyState, short xStart, short yStart, short xTarget, short yTarget, int velocityMS, int mouseInitialClickDelayMS)
        {
            //Debug.WriteLine("AppTestStudio.Utils.MoveMousePassive(new IntPtr(" + windowHandle.ToInt32() + ")," + MouseKeyState + "," + xStart + "," + yStart + "," + xTarget + "," + yTarget + "," + VelocityMS + ");");
            int PostCount = 0;
            int PostEveryMS = 5;

            float CurrentX = xStart;
            float CurrentY = yStart;

            int NumberOfActions = velocityMS / PostEveryMS;

            // Don't post the Start move if there's a 0ms delay
            if (velocityMS > 0)
            {
                API.PostMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, mouseKeyState, Utils.HiLoWord(CurrentX, CurrentY));
                PostCount++;
            }

            if (NumberOfActions > 0)
            {
                float XIncrement = (float)(xTarget - xStart) / NumberOfActions;
                float YIncrement = (float)(yTarget - yStart) / NumberOfActions;
                int CurrentAction = 0;
                for (CurrentAction = 0; CurrentAction < NumberOfActions; CurrentAction++)
                {
                    API.PostMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, mouseKeyState, Utils.HiLoWord(CurrentX, CurrentY));
                    PostCount++;

                    if (CurrentAction == 0)
                    {
                        Thread.Sleep(mouseInitialClickDelayMS);
                    }

                    Thread.Sleep(PostEveryMS);

                    CurrentX = CurrentX + XIncrement;
                    CurrentY = CurrentY + YIncrement;
                }
            }

            API.PostMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, mouseKeyState, Utils.HiLoWord(xTarget, yTarget));
            PostCount++;
            return PostCount;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static void ClickOnWindow(IntPtr windowHandle, MouseMode mouseMode, Boolean moveMouseFirst, WindowAction windowAction, int xStart, int yStart, int xTarget, int yTarget, int clickDurationMS, int mouseSpeedPixelsPerSecond)
        {
            ClickOnWindow(windowHandle, mouseMode, moveMouseFirst, windowAction, (short)xStart, (short)yStart, (short)xTarget, (short)yTarget, clickDurationMS, mouseSpeedPixelsPerSecond);
        }
        public static void ClickOnWindow(IntPtr windowHandle, MouseMode mouseMode, Boolean moveMouseFirst, WindowAction windowAction, short xStart, short yStart, short xTarget, short yTarget, int clickDuration, int mouseSpeedPixelsPerSecond)
        {
            switch (mouseMode)
            {
                case MouseMode.Passive:
                    //if (moveMouseFirst)
                    //{
                    //    int MoveDurationMS = GetMoveDurationMSFromPixelsPerSecond(xStart, yStart, xTarget, yTarget, mouseSpeedPixelsPerSecond);
                    //    MoveMousePassive(windowHandle, Definitions.MouseKeyStates.MK_NONE, xStart, yStart, xTarget, yTarget, MoveDurationMS);
                    //}
                    ClickOnWindowPassiveMode(windowHandle, xTarget, yTarget, clickDuration);
                    break;
                case MouseMode.Active:
                    
                    Boolean Continue = ActivateWindowIfNecessary(windowHandle, windowAction, xTarget, yTarget);
                    if (Continue == false)
                    {
                        // Project configuration indicates that if the window isn't visible: to not perform any actions.
                        // Check the project settings checkbox [Move System Mouse To Start Location Before Action] to avoid this.
                        return;
                    }

                    if (moveMouseFirst)
                    {
                        MoveMouseActiveFromSystemPosition(windowHandle, MouseEventFlags.Blank, xTarget, yTarget, mouseSpeedPixelsPerSecond);
                    }

                    ClickOnWindowActiveMode(windowHandle, xTarget, yTarget, clickDuration);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static int GetMoveDurationMSFromPixelsPerSecond(int xStart, int yStart, int xTarget, int yTarget, int mouseSpeedPixelsPerSecond)
        {
            return GetMoveDurationMSFromPixelsPerSecond((short)xStart, (short)yStart, (short)xTarget, (short)yTarget, mouseSpeedPixelsPerSecond);
        }
        public static int GetMoveDurationMSFromPixelsPerSecond(short xStart, short yStart, short xTarget, short yTarget, int mouseSpeedPixelsPerSecond)
        {
            if (mouseSpeedPixelsPerSecond > 0)
            {
                int Distance = GetDistanceABS(xStart, yStart, xTarget, yTarget);
                double MouseSpeedPixelsPerMS = mouseSpeedPixelsPerSecond / 1000.0d;
                if (MouseSpeedPixelsPerMS > 0)
                {
                    double MoveDurationMS = Distance / MouseSpeedPixelsPerMS;
                    return MoveDurationMS.ToInt();
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        [System.Diagnostics.DebuggerStepThrough]
        static int CalculateAbsoluteCoordinateX(double x)
        {
            return CalculateAbsoluteCoordinateX(x.ToInt());
        }

        [System.Diagnostics.DebuggerStepThrough]
        static int CalculateAbsoluteCoordinateX(float x)
        {
            return CalculateAbsoluteCoordinateX(x);
        }

        static int CalculateAbsoluteCoordinateX(int x)
        {
            int XScreen = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            return (x * 65536) / XScreen;
        }

        [System.Diagnostics.DebuggerStepThrough]
        static int CalculateAbsoluteCoordinateY(double y)
        {
            return CalculateAbsoluteCoordinateY(y.ToInt());
        }
        [System.Diagnostics.DebuggerStepThrough]
        static int CalculateAbsoluteCoordinateY(float y)
        {
            return CalculateAbsoluteCoordinateY(y.ToInt());
        }
        static int CalculateAbsoluteCoordinateY(int y)
        {
            int YScreen = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
            return (y * 65536) / YScreen;
        }

        public static void ClickOnWindowActiveMode(IntPtr windowHandle, short xClientTarget, short yClientTarget, int mouseUpDelayMS)
        {
            API.RECT TargetWindowRectangle;
            Boolean WindowRectResult = AppTestStudio.API.GetWindowRect(windowHandle, out TargetWindowRectangle);

            Debug.WriteLine("xClientTarget:" + xClientTarget);
            Debug.WriteLine("yClientTarget:" + yClientTarget);
            Debug.WriteLine("Right:" + TargetWindowRectangle.Right);
            Debug.WriteLine("Left:" + TargetWindowRectangle.Left);

            //RECT WindowFrame;

            ////Retrieves the current value of a specified Desktop Window Manager(DWM) attribute applied to a window.
            ////Retrieves the extended frame bounds rectangle in screen space.
            //int Result = API.DwmGetWindowAttribute(windowHandle, DWMWINDOWATTRIBUTE.ExtendedFrameBounds, out WindowFrame, Marshal.SizeOf(typeof(RECT)));

            RECT ClientRect;
            //Retrieves the coordinates of a window's client area.
            API.GetClientRect(windowHandle, out ClientRect);

            short xSystemTarget = (xClientTarget + TargetWindowRectangle.Left).ToShort();

            short ySystemTarget = (yClientTarget + TargetWindowRectangle.Top).ToShort();

            int AbsoluteX = CalculateAbsoluteCoordinateX(xSystemTarget);
            int AbsoluteY = CalculateAbsoluteCoordinateY(ySystemTarget);

            int INPUT_MOUSE = 0;
            Input MouseMove = new Input();
            MouseMove.Type = INPUT_MOUSE;
            MouseMove.u.MouseInput.X = AbsoluteX;
            MouseMove.u.MouseInput.Y = AbsoluteY;
            MouseMove.u.MouseInput.MouseData = 0;
            MouseMove.u.MouseInput.Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute);

            Input LeftDown = new Input();
            LeftDown.Type = INPUT_MOUSE;
            LeftDown.u.MouseInput.X = AbsoluteX;
            LeftDown.u.MouseInput.Y = AbsoluteY;
            LeftDown.u.MouseInput.MouseData = 0;
            LeftDown.u.MouseInput.Flags = (uint)(MouseEventFlags.LeftDown);

            Input[] InputsPreTimeout = { MouseMove, LeftDown };
            SendInput((uint)InputsPreTimeout.Length, InputsPreTimeout, Marshal.SizeOf(typeof(Input)));

            Thread.Sleep(mouseUpDelayMS);

            Input LeftUp = new Input();
            LeftUp.Type = INPUT_MOUSE;
            LeftUp.u.MouseInput.X = AbsoluteX;
            LeftUp.u.MouseInput.Y = AbsoluteY;
            LeftUp.u.MouseInput.MouseData = 0;
            LeftUp.u.MouseInput.Flags = (uint)(MouseEventFlags.LeftUp);

            Input[] InputsPostTimeout = { LeftUp };

            SendInput((uint)InputsPostTimeout.Length, InputsPostTimeout, Marshal.SizeOf(typeof(Input)));
        }

        public static void ClickOnWindowPassiveMode(IntPtr windowHandle, short xTarget, short yTarget, int mouseUpDelayMS)
        {
             //' SendMessage(WindowHandle, WM_SETCURSOR, WindowHandle, getHiLoWord(HTCLIENT, Definitions.WM_MOUSEMOVE))

            API.PostMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, 0, Utils.HiLoWord(xTarget, yTarget));

            API.PostMessage(windowHandle, Definitions.MouseInputNotifications.WM_LBUTTONDOWN, Definitions.MouseKeyStates.MK_LBUTTON, Utils.HiLoWord(xTarget, yTarget));
            if (mouseUpDelayMS > 0)
            {
                Thread.Sleep(mouseUpDelayMS);
            }
            API.PostMessage(windowHandle, Definitions.MouseInputNotifications.WM_LBUTTONUP, 0, Utils.HiLoWord(xTarget, yTarget));
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
                case Platform.BlueStacks:
                    PrimaryWindowName = game.BlueGuest.WindowTitle;
                    PrimaryWindowNameFilter = WindowNameFilterType.Equals;

                    SecondaryWindowName = Definitions.BlueStacksSecondaryWindowNameFilter;
                    SecondaryWindowNameFilter = WindowNameFilterType.StartsWith;
                    break;
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
                    //Debug.WriteLine(P.MainWindowTitle);
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
            if (SecondaryWindowName.Length > 0 && Handles.ChildWindowHandle != IntPtr.Zero)
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


        //"C:\Program Files\BlueStacks\Bluestacks.exe" -vmname Android
        //"C:\Program Files\BlueStacks_bgp64\Bluestacks.exe" -vmname Android
        //"C:\Program Files\BlueStacks_bgp64\Bluestacks.exe" -vmname Android_1
        //Don't use - "C:\Program Files\BlueStacks\HD-RunApp.exe" -vmname Android_1 -json "{\"app_icon_url\":\"\",\"app_name\":\"Holyday City\",\"app_url\":\"\",\"app_pkg\":\"com.HolydayStudios.HolydayCityTycoon1\"}"
        //"C:\Program Files\BlueStacks_bgp64\Bluestacks.exe" -vmname Android_1 -json "{\"app_icon_url\":\"\",\"app_name\":\"Holyday City\",\"app_url\":\"\",\"app_pkg\":\"com.HolydayStudios.HolydayCityTycoon1\"}"
        //Don't use - "C:\Program Files\BlueStacks\HD-RunApp.exe" -vmname Android_1 -json "{\"app_icon_url\":\"\",\"app_name\":\"Holyday City\",\"app_url\":\"\",\"app_pkg\":\"com.HolydayStudios.HolydayCityTycoon1\"}"

        public static String LaunchBlueStacksInstance(string packageName, BlueGuest guest)
        {
            String Result = "";
            BlueRegistry blueRegistry = new BlueRegistry();
            //BlueGuest guest = null;

            //if (Is64Bit)
            //{
            //    foreach (BlueGuest blueGuest in blueRegistry.GuestList64)
            //    {
            //        if (blueGuest.KeyName == targetWindow)
            //        {
            //            guest = blueGuest;
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (BlueGuest blueGuest in blueRegistry.GuestList32)
            //    {
            //        if (blueGuest.KeyName == targetWindow)
            //        {
            //            guest = blueGuest;
            //            break;
            //        }
            //    }
            //}

            if (guest.IsSomething())
            {
                ProcessStartInfo info = new ProcessStartInfo();

                info.FileName = guest.ExePath;
                System.IO.Path.GetDirectoryName(guest.ExePath);
                info.WorkingDirectory = System.IO.Path.GetDirectoryName(guest.ExePath);

                String Arguments = "";

                Arguments = Arguments + "-vmname " + guest.KeyName;

                if (packageName.Trim().Length > 0)
                {
                    Arguments = Arguments + @" -json ""{\""app_icon_url\"":\""\"",\""app_name\"":\""Application Name\"",\""app_url\"":\""\"",\""app_pkg\"":\""" + packageName + @"\""}""";
                }

                info.Arguments = Arguments;

                Result = "Launching: " + info.FileName + " " + info.Arguments;
                Process.Start(info);
            }
            else
            {
                Result = Result + "Failed to find BlueStacks Instance";
            }

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

        [System.Diagnostics.DebuggerStepThrough]
        public static int HiLoWord(short lo, short hi)
        {
            int hi2 = hi << 16;
            hi2 = hi2 | lo;

            return hi2;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static int HiLoWord(int lo, int hi)
        {
            return HiLoWord((short)lo, (short)hi);
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static int HiLoWord(float lo, float hi)
        {
            return HiLoWord((short)lo, (short)hi);
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static IntPtr HiLoWordIntptr(short lo, short hi)
        {
            return new IntPtr(HiLoWord(lo, hi));
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static IntPtr HiLoWordIntptr(int lo, int hi)
        {
            return new IntPtr(HiLoWord((short)lo, (short)hi));
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

                            Font Arial = new Font("Arial", 16, FontStyle.Bold);

                            SizeF WidthTextSize = e.Graphics.MeasureString(pictureBox1Rectangle.Width.ToString(), Arial);
                            SizeF HeightTextSize = e.Graphics.MeasureString(pictureBox1Rectangle.Height.ToString(), Arial);

                            int MiddleOfTextWidth = (WidthTextSize.Width / 2).ToInt();
                            int MiddleOfTextHeight = (WidthTextSize.Height / 2).ToInt();

                            //Debug.WriteLine("Node.Anchor" + Node.Anchor);
                            //Debug.WriteLine("pictureBox1Rectangle: " + pictureBox1Rectangle);
                            //Debug.WriteLine("Width:" + TargetWidth + " Height:" + TargetHeight);
                            //Debug.WriteLine("TS:" + WidthTextSize.Width + "," + WidthTextSize.Height);

                            // Draw Blue Line from Top to Center of the Top of the Mask
                            e.Graphics.DrawLine(p, CenterX, 0, CenterX, TopOfMaskY);

                            // Draw Blue Line from Center of the Bottom of the Mask to the bottom of the image
                            e.Graphics.DrawLine(p, CenterX, BottomOfMaskY, CenterX, TargetHeight);

                            // Draw Blue Line from 0 to Middle of the Right Mask.
                            e.Graphics.DrawLine(p, 0, CenterY, StartOfMaskX, CenterY);

                            // Draw Blue Line from Right of Mask to the right of the image
                            e.Graphics.DrawLine(p, RightOfMaskX, CenterY, TargetWidth, CenterY);

                            // Draw the width inside the mask at the top.
                            // Use Blue with 200 opacity
                            using (SolidBrush br = new SolidBrush(Color.FromArgb(200, 0, 0, 255)))
                            {
                                // Only draw the text if it will display inside the Mask.
                                if (WidthTextSize.Width + 2 < pictureBox1Rectangle.Width)
                                {
                                    // Draw the Width Text
                                    e.Graphics.DrawString(pictureBox1Rectangle.Width.ToString(), Arial, br, CenterX - MiddleOfTextWidth, TopOfMaskY);
                                }
                            }

                            // Draw the height inside the mask at the right center of the Mask.
                            // Use Blue with 200 opacity
                            using (SolidBrush br = new SolidBrush(Color.FromArgb(200, 0, 0, 255)))
                            {
                                // Only draw the text if it will display inside the Mask.
                                if (HeightTextSize.Height + 2 < pictureBox1Rectangle.Height)
                                {
                                    // Draw the Height Text
                                    e.Graphics.DrawString(pictureBox1Rectangle.Height.ToString(), Arial, br, StartOfMaskX, CenterY - MiddleOfTextHeight);
                                }
                            }
                        }
                    }
                }
                DrawMask(pictureBox1, pictureBox1Rectangle, e);
            }
            catch (Exception ex)
            {

                Debug.WriteLine("DrawMask:" + ex.Message);
            }
        }

        internal static void DrawMask(PictureBox pictureBox1, Rectangle pictureBox1Rectangle, PaintEventArgs e)
        {
            if (pictureBox1.Image.IsSomething())
            {
                if (pictureBox1Rectangle.Width > 0 && pictureBox1Rectangle.Height > 0)
                {
                    using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                    {
                        // Draw a blue 50% Mask on Top 1/2 above the mask.
                        Rectangle Top = new Rectangle();
                        Top.X = 0;
                        Top.Y = 0;
                        Top.Height = pictureBox1Rectangle.Y;
                        Top.Width = pictureBox1.Image.Width;
                        e.Graphics.FillRectangle(br, Top);

                        // Draw a blue 50% Mask on Bottom 1/2 Below the mask.
                        Rectangle Bottom = new Rectangle();
                        Bottom.X = 0;
                        Bottom.Y = pictureBox1Rectangle.Y + pictureBox1Rectangle.Height;
                        Bottom.Height = pictureBox1.Image.Height - Bottom.Y;
                        Bottom.Width = pictureBox1.Image.Width;
                        e.Graphics.FillRectangle(br, Bottom);

                        // Draw a blue 50% Mask on left side of the mask.
                        Rectangle Left = new Rectangle();
                        Left.Y = pictureBox1Rectangle.Y;
                        Left.X = 0;
                        Left.Height = pictureBox1Rectangle.Height;
                        Left.Width = pictureBox1Rectangle.X;
                        e.Graphics.FillRectangle(br, Left);

                        // Draw a blue 50% Mask on Right side of the mask.
                        Rectangle Right = new Rectangle();
                        Right.Y = pictureBox1Rectangle.Y;
                        Right.X = pictureBox1Rectangle.X + pictureBox1Rectangle.Width;
                        Right.Height = pictureBox1Rectangle.Height;
                        Right.Width = pictureBox1.Image.Width - Right.X;
                        e.Graphics.FillRectangle(br, Right);

                        Font Arial = new Font("Arial", 16, FontStyle.Bold);

                        String TopLeftXY = "(" + pictureBox1Rectangle.X + "," + pictureBox1Rectangle.Y + ")";
                        SizeF TopLeftTextSize = e.Graphics.MeasureString(TopLeftXY, Arial);

                        String BottomRightXY = "(" + (pictureBox1Rectangle.X + pictureBox1Rectangle.Width) + "," + (pictureBox1Rectangle.Y + pictureBox1Rectangle.Height) + ")";
                        SizeF BottomRightTextSize = e.Graphics.MeasureString(TopLeftXY, Arial);

                        using (SolidBrush RedBrush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                        {
                            // Draw TopLeft Coordinates right above the mask.
                            e.Graphics.DrawString(TopLeftXY, Arial, RedBrush, pictureBox1Rectangle.X, pictureBox1Rectangle.Y - TopLeftTextSize.Height - 1);

                            // Draw Bottom Right Coordinates below the mask.
                            e.Graphics.DrawString(BottomRightXY, Arial, RedBrush, pictureBox1Rectangle.X + pictureBox1Rectangle.Width, pictureBox1Rectangle.Y + pictureBox1Rectangle.Height + 1);
                        }
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

        public static void ShowInactiveTopmostFormCenterScreen(Form frm)
        {
            const int SW_SHOWNOACTIVATE = 4;
            const int HWND_TOPMOST = -1;
            const uint SWP_NOACTIVATE = 0x0010;
            API.ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            int Left = (Screen.PrimaryScreen.WorkingArea.Width - frm.Width) / 2;
            int Top = (Screen.PrimaryScreen.WorkingArea.Height - frm.Height) / 2;

            API.SetWindowPos(frm.Handle, new IntPtr(HWND_TOPMOST), Left, Top, frm.Width, frm.Height, SWP_NOACTIVATE);             
        }

        public static int GetDistanceABS(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(GetDistance(x1, y1, x2, y2));
        }

        public static int GetDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)).ToInt();
        }


        public static void DrawRectangleWithGuidesOnGraphics(Graphics graphics, Bitmap bitmap, Rectangle rectangle)
        {
            //Draw a box at 50% transparency to show the click area.
            using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
            {
                graphics.FillRectangle(br, rectangle);
            }

            // Draw a blue outline around the click area.
            using (Pen p = new Pen(Color.Blue, 1))
            {
                graphics.DrawRectangle(p, rectangle);

                float CenterX = rectangle.Left + (rectangle.Width / 2);
                float CenterY = rectangle.Top + (rectangle.Height / 2);
                float TopOfRange = rectangle.Top;
                float BottomOfRangeY = rectangle.Top + rectangle.Height;
                float TargetHeight = rectangle.Top;
                float StartOfRangeX = rectangle.Left;
                float RightOfRangeX = rectangle.Left + rectangle.Width;

                // Draw Blue Line from Top to Center of the Top of the Range
                graphics.DrawLine(p, CenterX, 0, CenterX, TopOfRange);

                // Draw Blue Line from Center of the Bottom of the Range to the bottom of the image
                if (bitmap.IsSomething())
                {
                    graphics.DrawLine(p, CenterX, BottomOfRangeY, CenterX, bitmap.Height);
                }

                // Draw Blue Line from 0 to Middle of the Right Range.
                graphics.DrawLine(p, 0, CenterY, StartOfRangeX, CenterY);

                // Draw Blue Line from Right of Range to the right of the image
                if (bitmap.IsSomething())
                {
                    graphics.DrawLine(p, RightOfRangeX, CenterY, bitmap.Width, CenterY);
                }
            }
        }
    }

}
