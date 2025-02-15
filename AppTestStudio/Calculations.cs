
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;
using static AppTestStudio.NativeMethods;


namespace AppTestStudio
{
    internal class Calculations
    {
        [System.Diagnostics.DebuggerStepThrough]
        internal static ActionSolution CalculateClickOnWindow(IntPtr windowHandle, MouseMode mouseMode, Boolean moveMouseFirst, WindowAction windowAction, int xStart, int yStart, int xTarget, int yTarget, int clickDurationMS, int mouseSpeedPixelsPerSecond)
        {

            return CalculateClickOnWindow(windowHandle, mouseMode, moveMouseFirst, windowAction, (short)xStart, (short)yStart, (short)xTarget, (short)yTarget, clickDurationMS, mouseSpeedPixelsPerSecond);

        }
        internal static ActionSolution CalculateClickOnWindow(IntPtr windowHandle, MouseMode mouseMode, Boolean moveMouseFirst, WindowAction windowAction, short xStart, short yStart, short xTarget, short yTarget, int clickDuration, int mouseSpeedPixelsPerSecond)
        {
            ActionSolution solution = new ActionSolution();
            switch (mouseMode)
            {
                case MouseMode.Passive:
                    //if (moveMouseFirst)
                    //{
                    //    int MoveDurationMS = GetMoveDurationMSFromPixelsPerSecond(xStart, yStart, xTarget, yTarget, mouseSpeedPixelsPerSecond);
                    //    MoveMousePassive(windowHandle, Definitions.MouseKeyStates.MK_NONE, xStart, yStart, xTarget, yTarget, MoveDurationMS);
                    //}
                    CalculateClickOnWindowPassiveMode(windowHandle, xTarget, yTarget, clickDuration, solution);
                    break;
                case MouseMode.Active:

                    if (moveMouseFirst)
                    {
                        CalculateMoveMouseActiveFromSystemPosition(windowHandle, MouseEventFlags.Blank, xTarget, yTarget, mouseSpeedPixelsPerSecond, solution);
                    }

                    CalculateClickOnWindowActiveMode(windowHandle, xTarget, yTarget, clickDuration, solution);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            return solution;
        }

        internal static void CalculateClickOnWindowPassiveMode(IntPtr windowHandle, short xTarget, short yTarget, int mouseUpDelayMS, ActionSolution solution)
        {
            solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, 0, Utils.HiLoWord(xTarget, yTarget), 0);

            solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_LBUTTONDOWN, Definitions.MouseKeyStates.MK_LBUTTON, Utils.HiLoWord(xTarget, yTarget), mouseUpDelayMS);

            solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_LBUTTONUP, 0, Utils.HiLoWord(xTarget, yTarget));
        }


        [System.Diagnostics.DebuggerStepThrough]
        internal static void CalculateMoveMouseActiveFromSystemPosition(IntPtr windowHandle, MouseEventFlags mouseEventFlags, int xClientTarget, int yClientTarget, int mouseSpeedPixelsPerSecond, ActionSolution solution, EasingFunctionBase easingFunction = null)
        {
            CalculateMoveMouseActiveFromSystemPosition(windowHandle, mouseEventFlags, (short)xClientTarget, (short)yClientTarget, mouseSpeedPixelsPerSecond, solution, easingFunction);
        }

        internal static void CalculateMoveMouseActiveFromSystemPosition(IntPtr windowHandle, MouseEventFlags mouseEventFlags, short xClientTarget, short yClientTarget, int mouseSpeedPixelsPerSecond, ActionSolution solution, EasingFunctionBase easingFunction = null)
        {
            //Debug.WriteLine($"MoveMouseActiveFromSystemPosition(windowHandle={windowHandle}, mouseEventFlags={mouseEventFlags}, xClientTarget={xClientTarget}, yClientTarget={yClientTarget}, mouseSpeedPixelsPerSecond={mouseSpeedPixelsPerSecond}, easingFunction=...");
            RECT TargetWindowRectangle;

            //Retrieves the dimensions of the bounding rectangle of the specified window.
            //The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
            Boolean WindowRectResult = GetWindowRect(windowHandle, out TargetWindowRectangle);

            RECT ClientRect;

            //Retrieves the coordinates of a window's client area. The client coordinates specify the upper-left and lower-right corners of the client area.
            //Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the upper-left corner are (0,0).
            GetClientRect(windowHandle, out ClientRect);

            short xSystemTarget = (xClientTarget + TargetWindowRectangle.Left).ToShort();

            short ySystemTarget = (yClientTarget + TargetWindowRectangle.Top).ToShort();

            //Retrieves the position of the mouse cursor, in screen coordinates.
            GetCursorPos(out NativeMethods.Point point);
            int xStart = point.X;
            int yStart = point.Y;

            int PostEveryMS = 30;

            float CurrentX = xStart;
            float CurrentY = yStart;

            //Debug.WriteLine($"System Mouse is at {point.X},{point.Y}");
            //Debug.WriteLine($"Target window is at {TargetWindowRectangle.Left},{TargetWindowRectangle.Top}");
            //Debug.WriteLine($"Target window Client is at {xClientTarget},{yClientTarget}");

            int velocityMS = Utils.GetMoveDurationMSFromPixelsPerSecond(xStart, yStart, xSystemTarget.ToInt(), ySystemTarget.ToInt(), mouseSpeedPixelsPerSecond);

            int NumberOfActions = velocityMS / PostEveryMS;

            int AbsoluteX = 0;
            int AbsoluteY = 0;
            int INPUT_MOUSE = 0;

            uint Flags = 0;

            // Don't post the Start move if there's a 0ms delay
            if (velocityMS > 0)
            {
                AbsoluteX = CalculateAbsoluteCoordinateX(CurrentX);
                AbsoluteY = CalculateAbsoluteCoordinateY(CurrentY);

                Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);
                solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, Flags);
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

                    AbsoluteX = CalculateAbsoluteCoordinateX(CurrentXPosition);
                    AbsoluteY = CalculateAbsoluteCoordinateY(CurrentYPosition);

                    // Adding Easing
                    //AbsoluteX = CalculateAbsoluteCoordinateX(CurrentX);
                    //AbsoluteY = CalculateAbsoluteCoordinateY(CurrentY);

                    //Debug.WriteLine(CurrentX + "x:" + CurrentXPosition);
                    //Debug.WriteLine(CurrentY + "y:" + CurrentYPosition);

                    //Debug.WriteLine($"CA: {CurrentAction}, NOA: {NumberOfActions}, X={CurrentXPosition}, Y={CurrentYPosition}");

                    Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);
                    solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, Flags, PostEveryMS);

                    // Adding Easing
                    //CurrentX = CurrentX + XIncrement;
                    //CurrentY = CurrentY + YIncrement;
                }
            }

            // Send the final mouse move position
            AbsoluteX = CalculateAbsoluteCoordinateX(xSystemTarget);
            AbsoluteY = CalculateAbsoluteCoordinateY(ySystemTarget);

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

            Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);
            solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, Flags);

            //Debug.WriteLine($"MoveMouseActiveFromSystemPostion,PostCount={PostCount}");
        }
        internal static int CalculateClickOnWindowActiveMode(IntPtr windowHandle, short xClientTarget, short yClientTarget, int mouseUpDelayMS, ActionSolution solution)
        {
            RECT TargetWindowRectangle;
            Boolean WindowRectResult = GetWindowRect(windowHandle, out TargetWindowRectangle);

            //Debug.WriteLine("xClientTarget:" + xClientTarget);
            //Debug.WriteLine("yClientTarget:" + yClientTarget);
            //Debug.WriteLine("Right:" + TargetWindowRectangle.Right);
            //Debug.WriteLine("Left:" + TargetWindowRectangle.Left);

            //RECT WindowFrame;

            ////Retrieves the current value of a specified Desktop Window Manager(DWM) attribute applied to a window.
            ////Retrieves the extended frame bounds rectangle in screen space.
            //int Result = DwmGetWindowAttribute(windowHandle, DWMWINDOWATTRIBUTE.ExtendedFrameBounds, out WindowFrame, Marshal.SizeOf(typeof(RECT)));

            RECT ClientRect;
            //Retrieves the coordinates of a window's client area.
            GetClientRect(windowHandle, out ClientRect);

            short xSystemTarget = (xClientTarget + TargetWindowRectangle.Left).ToShort();

            short ySystemTarget = (yClientTarget + TargetWindowRectangle.Top).ToShort();

            int AbsoluteX = CalculateAbsoluteCoordinateX(xSystemTarget);
            int AbsoluteY = CalculateAbsoluteCoordinateY(ySystemTarget);

            int INPUT_MOUSE = 0;
            uint Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute);
            solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, Flags);

            solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, (uint)(MouseEventFlags.LeftDown), mouseUpDelayMS);

            solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, (uint)(MouseEventFlags.LeftUp));

            return mouseUpDelayMS;
        }



        [System.Diagnostics.DebuggerStepThrough]
        static int CalculateAbsoluteCoordinateX(double x)
        {
            return CalculateAbsoluteCoordinateX(x.ToInt());
        }

        [System.Diagnostics.DebuggerStepThrough]
        static int CalculateAbsoluteCoordinateX(float x)
        {
            return CalculateAbsoluteCoordinateX(x.ToInt());
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

        public static ActionSolution CalculateClickDragRelease(IntPtr windowHandle, MouseMode mouseMode, Boolean moveMouseFirst, WindowAction windowAction, int startX, int startY, int endX, int endY, int velocityMS, int mouseSpeedPixelsPerSecond, int mouseInitialClickDelayMS)
        {
            ActionSolution solution = new ActionSolution();
            int MouseTimeMS = 0;
            switch (mouseMode)
            {
                case MouseMode.Passive:
                     CalculateClickDragReleasePassive(windowHandle, startX, startY, endX, endY, velocityMS, mouseInitialClickDelayMS, solution);
                    break;
                case MouseMode.Active:
                    if (moveMouseFirst)
                    {
                         CalculateMoveMouseActiveFromSystemPosition(windowHandle, MouseEventFlags.Blank, startX, startY, mouseSpeedPixelsPerSecond, solution);
                    }
                    CalculateClickDragReleaseActive(windowHandle, startX, startY, endX, endY, velocityMS, mouseInitialClickDelayMS, solution);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            return solution;
        }

        public static void CalculateClickDragReleasePassive(IntPtr windowHandle, int startX, int startY, int endX, int endY, int velocityMS, int mouseInitialClickDelayMS, ActionSolution solution)
        {
            // Move the mouse to start position.
            solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, Definitions.MouseKeyStates.MK_NONE, Utils.HiLoWord(startX, startY));

            // Left Mouse Down
            solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_LBUTTONDOWN, Definitions.MouseKeyStates.MK_LBUTTON, Utils.HiLoWord(startX, startY));

            // Move to position
            CalculateMoveMousePassive(windowHandle, Definitions.MouseKeyStates.MK_LBUTTON, startX, startY, endX, endY, velocityMS, mouseInitialClickDelayMS, solution);

            // Left Mouse Up
            solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_LBUTTONUP, Definitions.MouseKeyStates.MK_NONE, (int)Utils.HiLoWordIntptr(endX, endY));

        }

        public static void CalculateMoveMousePassive(IntPtr windowHandle, int mouseKeyState, int xStart, int yStart, int xTarget, int yTarget, int velocityMS, int mouseInitialClickDelayMS, ActionSolution solution)
        {
            CalculateMoveMousePassive(windowHandle, mouseKeyState, (short)xStart, (short)yStart, (short)xTarget, (short)yTarget, (short)velocityMS, mouseInitialClickDelayMS, solution);
        }

        public static void CalculateMoveMousePassive(IntPtr windowHandle, int mouseKeyState, short xStart, short yStart, short xTarget, short yTarget, int velocityMS, int mouseInitialClickDelayMS, ActionSolution solution)
        {
            int PostEveryMS = 5;

            float CurrentX = xStart;
            float CurrentY = yStart;

            int NumberOfActions = velocityMS / PostEveryMS;

            // Don't post the Start move if there's a 0ms delay
            if (velocityMS > 0)
            {
                solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, mouseKeyState, Utils.HiLoWord(CurrentX, CurrentY));
            }

            if (NumberOfActions > 0)
            {
                float XIncrement = (float)(xTarget - xStart) / NumberOfActions;
                float YIncrement = (float)(yTarget - yStart) / NumberOfActions;
                int CurrentAction = 0;
                for (CurrentAction = 0; CurrentAction < NumberOfActions; CurrentAction++)
                {
                    int Sleeptime = PostEveryMS;

                    if (CurrentAction == 0)
                    {
                        Sleeptime = PostEveryMS + mouseInitialClickDelayMS;
                    }
                    solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, mouseKeyState, Utils.HiLoWord(CurrentX, CurrentY),Sleeptime);

                    CurrentX = CurrentX + XIncrement;
                    CurrentY = CurrentY + YIncrement;
                }
            }
            solution.AddMessage(windowHandle, Definitions.MouseInputNotifications.WM_MOUSEMOVE, mouseKeyState, Utils.HiLoWord(xTarget, yTarget));
        }

        // 1. Mouse Down at startx/y
        // 2. Mouse Move to endx/y
        // 3. Mouse Up at endx/y
        public static void CalculateClickDragReleaseActive(IntPtr windowHandle, int startX, int startY, int endX, int endY, int velocityMS, int mouseInitialClickDelayMS, ActionSolution solution)
        {
            CalculateMoveMouseActiveFromStartPosition(windowHandle, MouseEventFlags.LeftDown, (short)startX, (short)startY, (short)endX, (short)endY, velocityMS, mouseInitialClickDelayMS, solution);
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static void CalculateMoveMouseActiveFromStartPosition(IntPtr windowHandle, MouseEventFlags mouseEventFlags, int xClientStart, int yClientStart, int xClientTarget, int yClientTarget, int velocityMS, int mouseInitialClickDelayMS, ActionSolution solution)
        {
            CalculateMoveMouseActiveFromStartPosition(windowHandle, mouseEventFlags, (short)xClientStart, (short)yClientStart, (short)xClientTarget, (short)yClientTarget, velocityMS, mouseInitialClickDelayMS, solution);
        }

        public static void CalculateMoveMouseActiveFromStartPosition(IntPtr windowHandle, MouseEventFlags mouseEventFlags, short xClientStart, short yClientStart, short xClientTarget, short yClientTarget, int velocityMS, int mouseInitialClickDelayMS, ActionSolution solution)
        {
            uint Flags = 0;
            RECT TargetWindowRectangle;
            Boolean WindowRectResult = GetWindowRect(windowHandle, out TargetWindowRectangle);

            RECT ClientRect;
            GetClientRect(windowHandle, out ClientRect);

            short xSystemTarget = (short)(xClientTarget + TargetWindowRectangle.Left);
            short ySystemTarget = (short)(yClientTarget + TargetWindowRectangle.Top);
            short xSystemStart = (short)(xClientStart + TargetWindowRectangle.Left);
            short ySystemStart = (short)(yClientStart + TargetWindowRectangle.Top);

            int PostCount = 0;
            int PostEveryMS = 30;

            float CurrentX = xSystemStart;
            float CurrentY = ySystemStart;

            int Distance = Utils.GetDistanceABS(xSystemStart, ySystemStart, xSystemTarget, ySystemTarget);

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

                Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);
                solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, Flags);
                PostCount++;
            }

            if (NumberOfActions > 0)
            {
                float XIncrement = (float)(xSystemTarget - xSystemStart) / NumberOfActions;
                float YIncrement = (float)(ySystemTarget - ySystemStart) / NumberOfActions;
                int CurrentAction = 0;
                for (CurrentAction = 0; CurrentAction < NumberOfActions; CurrentAction++)
                {
                    int CurrentSleepTime = PostEveryMS;
                    if (CurrentAction == 0)
                    {
                        CurrentSleepTime = PostEveryMS + mouseInitialClickDelayMS;
                    }
                    AbsoluteX = CalculateAbsoluteCoordinateX(CurrentX);
                    AbsoluteY = CalculateAbsoluteCoordinateY(CurrentY);
                    
                    PostCount++;
                    Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);
                    solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, Flags, CurrentSleepTime);

                    CurrentX = CurrentX + XIncrement;
                    CurrentY = CurrentY + YIncrement;
                }
            }

            AbsoluteX = CalculateAbsoluteCoordinateX(xSystemTarget);
            AbsoluteY = CalculateAbsoluteCoordinateY(ySystemTarget);

            Flags = (uint)(MouseEventFlags.Move | MouseEventFlags.Absolute | mouseEventFlags);
            solution.AddInput(INPUT_MOUSE, AbsoluteX, AbsoluteY, 0, Flags);
        }

        public static ActionSolution CalculateMouseMove(IntPtr windowHandle, MouseMode mouseMode, Boolean moveMouseFirst, WindowAction windowAction, int startX, int startY, int endX, int endY, int velocityMS, int mouseSpeedPixelsPerSecond, int mouseInitialClickDelayMS)
        {
            ActionSolution solution = new ActionSolution();

            switch (mouseMode)
            {
                case MouseMode.Passive:
                    CalculateMoveMousePassive(windowHandle, Definitions.MouseKeyStates.MK_LBUTTON, startX, startY, endX, endY, velocityMS, mouseInitialClickDelayMS,solution);
                    break;
                case MouseMode.Active:
                    if (moveMouseFirst)
                    {
                        CalculateMoveMouseActiveFromSystemPosition(windowHandle, MouseEventFlags.Blank, startX, startY, mouseSpeedPixelsPerSecond,solution);
                    }
                    CalculateMoveMouseActiveFromStartPosition(windowHandle, MouseEventFlags.Blank, startX, startY, endX, endY, velocityMS, mouseInitialClickDelayMS,solution);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            return solution;
        }




    }
}
