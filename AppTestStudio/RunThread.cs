//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System.Diagnostics;

namespace AppTestStudio
{
    
    public class RunThread
    {
        public GameNodeGame Game { get; set; }
        public IntPtr WindowHandle { get; set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }

        // number of times to look for a window before closing the thread.
        public long RunTimeWindowTimeout { get; set; }

        public ThreadManager ThreadManager { get; set; }

        private static Object GetBitMapLock;

        private String GoToNodeName { get; set; }

        static RunThread()
        {
            GetBitMapLock = new Object();
        }

        public RunThread(GameNodeGame Game, CancellationTokenSource cancellationTokenSource)
        {
            this.Game = Game;
            CancellationTokenSource = cancellationTokenSource;
            RunTimeWindowTimeout = 100;
            WindowHandle = IntPtr.Zero;            
        }

        public void ShutDownThread()
        {
            CancellationTokenSource.Cancel();
        }

        private Bitmap GetBitMap(ref Boolean Success)
        {
            Success = false;

            IntPtr hdcSrc = NativeMethods.GetWindowDC(WindowHandle);
            if (hdcSrc.ToInt32() == 0)
            {
                // Likely the WindowHandle was lost, refetch a window handle.
                Game.Log("GetWindowDC = 0 " + WindowHandle);
                Game.Log("Refetching Window for " + Game.TargetWindow);
                WindowHandle = Game.GetWindowHandleByWindowName();
            }
            NativeMethods.RECT WindowRectangle = new NativeMethods.RECT();

            NativeMethods.GetWindowRect(WindowHandle, out WindowRectangle);

            int TargetWindowHeight = WindowRectangle.Bottom - WindowRectangle.Top;
            int TargetWindowWidth = WindowRectangle.Right - WindowRectangle.Left;

            if (TargetWindowHeight < 1 || TargetWindowWidth < 1)
            {
                return null;
            }

            IntPtr hdcDest = NativeMethods.CreateCompatibleDC(hdcSrc);

            IntPtr hBitmap = NativeMethods.CreateCompatibleBitmap(hdcSrc, TargetWindowWidth, TargetWindowHeight);

            if (hBitmap.ToInt32() == 0)
            {
                NativeMethods.DeleteDC(hdcDest);
                return null;
            }

            IntPtr hOld = NativeMethods.SelectObject(hdcDest, hBitmap);

            //'modAPI.BitBlt(hdcDest, 0, 0, TargetWindowWidth, TargetWindowHeight, hdcSrc, 0, 0, &HCC0020)

            NativeMethods.PrintWindow(WindowHandle, hdcDest, 2);

            NativeMethods.SelectObject(hdcDest, hOld);
            NativeMethods.DeleteDC(hdcDest);
            NativeMethods.ReleaseDC(WindowHandle, hdcSrc);

            Bitmap bmp = Image.FromHbitmap(hBitmap);
            NativeMethods.DeleteObject(hBitmap);

            Success = true;

            return bmp;
        }

        private void StopThreadCloseWindow(GameNode node, IntPtr windowHandle, Boolean AbortThread)
        {
            Game.Log(node.GameNodeName + ":" + "Stop Thread");
            Game.Log("Closing Emmulator #" + Game.InstanceToLaunch);

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

            ShutdownThread(Game, AbortThread);
        }

        private void ShutdownThread(GameNodeGame game, Boolean abortThread)
        {
            if (abortThread)
            {

                CancellationTokenSource.Cancel();

                if (Game.SaveVideo)
                {
                    Game.Video.Release();
                    Game.Video = null;
                }

                ThreadManager.RemoveGame(Game);

                Game.Log("Shutting down thread:" + Game.GameNodeName + " on instance " + Game.InstanceToLaunch);
                //Debug.WriteLine("Shutting down thread:" + Game.GameNodeName + " on instance " + Game.InstanceToLaunch);
            }
        }

        /// <summary>
        /// Walks down the tree
        /// </summary>
        /// <param name="bmp">This is not always constant through the tree, it may be replaced if the node is marked to not follow parent screenshots so self and children get new screenshots, but siblings don't</param>
        /// <param name="node"></param>
        /// <param name="centerX"></param>
        /// <param name="centerY"></param>
        /// <returns></returns>
        private AfterCompletionType ProcessChildren(Bitmap bmp, GameNodeAction node, int centerX, int centerY, ref long ChildSleepTimeMS, List<String> NodeList)
        {
            MouseSolution solution = null;
            //Debug.WriteLine($"ProcessChildren: {node.Name}");
            Stopwatch Watch = System.Diagnostics.Stopwatch.StartNew();
            while (Game.IsPaused)
            {
                Thread.Sleep(1000);
                ChildSleepTimeMS = ChildSleepTimeMS + 1000;
            }

            if (node.Enabled == false)
            {
                return AfterCompletionType.Continue;
            }

            ThreadManager.IncrementGoChild();

            Boolean PreLimitCheck = false;

            switch (node.ActionType)
            {
                case ActionType.Action:
                    PreLimitCheck = true;
                    break;
                case ActionType.Event:
                    PreLimitCheck = false;  // Events are checked after they are considered true.
                    break;
                case ActionType.RNG:
                    PreLimitCheck = false;  // RNG Nodes are checked in RNGContainer code.
                    break;
                case ActionType.RNGContainer:
                    PreLimitCheck = true;
                    break;
                default:
                    PreLimitCheck = true;
                    break;
            }

            if (PreLimitCheck)
            {
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
            }

            Boolean ActionTypeEventResult = false;

            switch (node.ActionType)
            {
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///             Action
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                case ActionType.Action:
                    ActivateWindowResult ActivationResult = ActivateWindowResult.WindowAlreadyActivated;
                    Game.AbsoluteLastNode = node;
                    Game.ThreadLastNodeAction = node;

                    int xPos = node.Rectangle.X;
                    int yPos = node.Rectangle.Y;

                    GameNode Parent = node.Parent as GameNode;
                    switch (node.Mode)
                    {
                        case Mode.RangeClick:

                            GameNodeAction.RangeClickResult Result = node.CalculateRangeClickResult(bmp, centerX, centerY);

                            Boolean Failed = false;

                            if (Result.x < 0)
                            {
                                Game.Log("Check Relative offset X, calculated to a negative position " + xPos);
                                Failed = true;
                            }

                            if (Result.y < 0)
                            {
                                Game.Log("Check Relative offset Y, calculated to a negative position " + yPos);
                                Failed = true;
                            }

                            if (Failed)
                            {
                                //Debug.WriteLine($"ProcessChildren.ActionTypeAction.RangeClick.Failed: {node.Name},{Watch.ElapsedMilliseconds}");
                                //'do nothing
                                return AfterCompletionType.ContinueProcess;
                            }
                            else
                            {
                                // Activate if needed
                                ActivationResult = ActivateIfNecessary(node);
                                if (ActivationResult == ActivateWindowResult.Timeout)
                                {
                                    if (node.PreActionFailureAction == TimeoutAction.Abort)
                                    {
                                        //Debug.WriteLine($"ProcessChildren.ActionTypeAction.RangeClick.Abort: {node.Name},{Watch.ElapsedMilliseconds}");
                                        return AfterCompletionType.ContinueProcess;
                                    }
                                }
                                //if (Game.MouseMode == MouseMode.Active)
                                //{
                                //    if (node.FromCurrentMousePos)
                                //    {
                                //        API.GetCursorPos(out API.Point point);
                                //        Game.MouseX = (short)point.X;
                                //        Game.MouseY = (short)point.Y;
                                //        Result.x = point.X;
                                //        Result.y = point.Y;
                                //    }
                                //}

                                Game.Log(node.Name + " Click(" + Result.x + "," + Result.y + ")");
                                int MousePixelSpeedPerSecond = Game.CalculateNextMousePixelSpeedPerSecond();
                                
                                solution = Calculations.CalculateClickOnWindow(WindowHandle, Game.MouseMode, node.FromCurrentMousePos, Game.WindowAction, Game.MouseX, Game.MouseY, Result.x, Result.y, node.ClickSpeed, MousePixelSpeedPerSecond);
                                solution.TargetX = Result.x;
                                solution.TargetY = Result.y;
                                solution.ActivateWindow = node.AppActivateIfNotActive;
                                SolutionPlayer.Play(solution);
                                node.RuntimeMouseMS = solution.RuntimeMS;

                                Game.MouseX = (short)Result.x;
                                Game.MouseY = (short)Result.y;

                                ThreadManager.IncrementClickCount();

                                node.RuntimeActionCount++;

                                // Draw solution marker
                                if (Game.SaveVideo)
                                {
                                    Game.BitmapClones.Enqueue(bmp.Clone() as Bitmap);
                                }
                            }

                            break;
                        case Mode.Keyboard:
                            // Activate if needed
                            ActivationResult = ActivateIfNecessary(node);
                            if (ActivationResult == ActivateWindowResult.Timeout)
                            {
                                if (node.PreActionFailureAction == TimeoutAction.Abort)
                                {
                                    //Debug.WriteLine($"ProcessChildren.ActionTypeAction.Keyboard.Abort: {node.Name},{Watch.ElapsedMilliseconds}");
                                    return AfterCompletionType.ContinueProcess;
                                }
                            }

                            if(node.RumtimeIsKeyboardCompiled==false)
                            {
                                Game.Log($"First use Compiling keyboard script {node.Name}");
                                AppTestStudio.KeyboardProcessor kp = new AppTestStudio.KeyboardProcessor();
                                node.RuntimeCompiledKeyboardCommands = kp.ParseScript(node.KeyboardScript);

                                // Calculate how long the keyboard command will take.
                                int RuntimeKeyboardMS = 0;
                                foreach (KeyboardCommand keyboardCommand in node.RuntimeCompiledKeyboardCommands)
                                {
                                    RuntimeKeyboardMS = RuntimeKeyboardMS + keyboardCommand.Delayms;
                                }
                                node.RuntimeKeyboardMS = RuntimeKeyboardMS;

                                node.RumtimeIsKeyboardCompiled = true;
                            }

                            foreach (KeyboardCommand command in node.RuntimeCompiledKeyboardCommands)
                            {
                                Utils.ProcessKeyboardCommand(command);
                            }
                            solution = new MouseSolution();
                            solution.ActivateWindow = true; // Always true.
                            solution.AddKeyboardCommands(node.RuntimeCompiledKeyboardCommands);


                            break;
                        case Mode.MouseMove:
                            GameNodeAction.ClickDragReleaseResult MouseMoveResult = node.CalculateClickDragReleaseResult(centerX, centerY);


                            Failed = false;

                            if (MouseMoveResult.StartX < 0 || MouseMoveResult.EndX < 0)
                            {
                                Game.Log(node.GameNodeName + " has a horizontal start positon of " + MouseMoveResult.StartX + " and a calculated end positon of " + MouseMoveResult.EndX + " please redraw, unable to move to negative position.  Aborting.");
                                Failed = true;
                            }

                            if (MouseMoveResult.StartY < 0 || MouseMoveResult.EndY < 0)
                            {
                                Game.Log(node.GameNodeName + " has a vertical start positon of " + MouseMoveResult.StartY + " and a calculated end positon of " + MouseMoveResult.EndY + " please redraw, unable to move to negative position.  Aborting.");
                                Failed = true;
                            }

                            if (Failed)
                            {
                                //'do nothing
                            }
                            else
                            {
                                ActivationResult = ActivateIfNecessary(node);
                                if (ActivationResult == ActivateWindowResult.Timeout)
                                {
                                    if (node.PreActionFailureAction == TimeoutAction.Abort)
                                    {
                                        //Debug.WriteLine($"ProcessChildren.ActionTypeAction.MouseMove.Abort: {node.Name},{Watch.ElapsedMilliseconds}");
                                        return AfterCompletionType.ContinueProcess;
                                    }
                                }

                                Game.Log("MouseMove from ( x=" + MouseMoveResult.StartX + ",y = " + MouseMoveResult.StartY + " to x=" + MouseMoveResult.EndX + ",y=" + MouseMoveResult.EndY + ")");
                                
                                solution = Calculations.CalculateMouseMove(WindowHandle, Game.MouseMode, node.FromCurrentMousePos, Game.WindowAction, MouseMoveResult.StartX, MouseMoveResult.StartY, MouseMoveResult.EndX, MouseMoveResult.EndY, node.ClickDragReleaseVelocity, Game.MouseSpeedPixelsPerSecond, Game.DefaultClickSpeed);
                                solution.TargetX = MouseMoveResult.StartX;
                                solution.TargetY = MouseMoveResult.StartY;
                                solution.ActivateWindow = node.AppActivateIfNotActive;
                                SolutionPlayer.Play(solution);
                                node.RuntimeMouseMS = solution.RuntimeMS;

                                Game.Log("/MouseMove)");
                                Game.MouseX = (short)MouseMoveResult.EndX;
                                Game.MouseY = (short)MouseMoveResult.EndY;
                                ThreadManager.IncrementMouseMove();
                                node.RuntimeActionCount++;

                                // Draw solution marker
                                if (Game.SaveVideo)
                                {
                                    Game.BitmapClones.Enqueue(bmp.Clone() as Bitmap);
                                }
                            }

                            break;

                        case Mode.ClickDragRelease:
                            GameNodeAction.ClickDragReleaseResult CDRResult = node.CalculateClickDragReleaseResult(centerX, centerY);
                            // xPos = X Start Position
                            // yPos = Y Start Position


                            // node.Rectangle.Width = direction relative to xPosition to move.
                            // node.Rectangle.Height = direction relative to the yPosition to move.

                            Failed = false;

                            if (CDRResult.StartX < 0 || CDRResult.EndX < 0)
                            {
                                Game.Log(node.GameNodeName + " has a horizontal start positon of " + CDRResult.StartX + " and a calculated end positon of " + CDRResult.EndX + " please redraw, unable to drag to negative position.  Aborting.");
                                Failed = true;
                            }

                            if (CDRResult.StartY < 0 || CDRResult.EndY < 0)
                            {
                                Game.Log(node.GameNodeName + " has a vertical start positon of " + CDRResult.StartY + " and a calculated end positon of " + CDRResult.EndY + " please redraw, unable to drag to negative position.  Aborting.");
                                Failed = true;
                            }

                            if (Failed)
                            {
                                //'do nothing
                            }
                            else
                            {
                                ActivationResult = ActivateIfNecessary(node);
                                if (ActivationResult == ActivateWindowResult.Timeout)
                                {
                                    if (node.PreActionFailureAction == TimeoutAction.Abort)
                                    {
                                        //Debug.WriteLine($"ProcessChildren.ActionTypeAction.ClickDragRelease.Abort: {node.Name},{Watch.ElapsedMilliseconds}");
                                        return AfterCompletionType.ContinueProcess;
                                    }
                                }

                                Game.Log("Swipe from ( x=" + CDRResult.StartX + ",y = " + CDRResult.StartY + " to x=" + CDRResult.EndX + ",y=" + CDRResult.EndY + ")");
                                solution = Calculations.CalculateClickDragRelease(WindowHandle, Game.MouseMode, node.FromCurrentMousePos, Game.WindowAction, CDRResult.StartX, CDRResult.StartY, CDRResult.EndX, CDRResult.EndY, node.ClickDragReleaseVelocity, Game.MouseSpeedPixelsPerSecond, Game.DefaultClickSpeed);
                                solution.TargetX = CDRResult.EndX;
                                solution.TargetY = CDRResult.EndY;
                                solution.ActivateWindow = node.AppActivateIfNotActive;

                                SolutionPlayer.Play(solution);
                                node.RuntimeMouseMS = solution.RuntimeMS;

                                Game.MouseX = (short)CDRResult.EndX;
                                Game.MouseY = (short)CDRResult.EndY;
                                ThreadManager.IncrementClickDragRelease();
                                node.RuntimeActionCount++;
                                //'if (UseThreadBitmap ) {
                                //'    TB.AddClickDragRelease(xPos, yPos, Node.Rectangle.Width, Node.Rectangle.Height, ex, ey, Node.Name)
                                //'}

                                // Draw solution marker
                                if (Game.SaveVideo)
                                {
                                    Game.BitmapClones.Enqueue(bmp.Clone() as Bitmap);
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    break;
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///             Event
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                case ActionType.Event:
                    int Offset = 0;
                    float DetectedThreashold = 0;
                    int CurrentRepeatsUntilFalseLimit = node.RepeatsUntilFalseLimit;

                    Boolean AlwaysTakeScreenshot = false;

                // This is a GOTO Tag not commonly used.  Greatly simplifies the code to use it.
                RepeatAction:
                    if (node.UseParentPicture == false || AlwaysTakeScreenshot)
                    {
                        Boolean Success = false;
                        //bmp.Dispose();// not good
                        if (Game.DontTakeScreenshot)
                        {
                            Game.Log("Don't Take Screenshot is incompaibile with Repeats");
                            bmp = null;
                            Success = true;
                        }
                        else
                        {
                            bmp = GetBitMap(ref Success);
                        }
                        
                        if (Success == false)
                        {
                            Game.Log(node.Name + " Lost Window");
                            Game.Log(node.Name + " Lost Returning to Home");
                            //Debug.WriteLine($"ProcessChildren.RepeatAction.Failure: {node.Name},{Watch.ElapsedMilliseconds}");
                            return AfterCompletionType.Home;
                        }
                        else
                        {
                            ThreadManager.IncrementScreenShots();
                            Game.ScreenShotsTaken = Game.ScreenShotsTaken + 1;
                        }
                        Game.Log(node.Name + " Taking Screenshot");
                    }

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
                    EventSolution eventSolution = node.IsTrue(bmp, Game);
                    if (eventSolution.Result)
                    {
                        if (node.IsColorPoint == false)
                        {
                            // is Object search.
                            // Draw solution marker
                            if (Game.SaveVideo)
                            {
                                Game.BitmapClones.Enqueue(bmp.Clone() as Bitmap);
                            }

                        }

                        // if there's not a filename assigned to the node then we didn't locate a file, so it can be synced since there's a valid event.
                        if (node.FileName.Length == 0)
                        {
                            node.SendBitmapToProject(bmp, Game);
                        }

                        node.RuntimeActionCount++;

                        //'Track the Last Node Event
                        Game.AbsoluteLastNode = node;
                        Game.ThreadLastNodeEvent = node;

                        if (node.RepeatsUntilFalse)
                        {
                            if (CurrentRepeatsUntilFalseLimit > 0)
                            {
                                AlwaysTakeScreenshot = true;

                                // Process children and throw away the result
                                foreach (GameNodeAction ChildNode in node.Nodes)
                                {
                                    if (NodeList.Count > 0)
                                    {
                                        if (ChildNode.Name == NodeList[0])
                                        {
                                            NodeList.RemoveAt(0);
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    ProcessChildren(bmp, ChildNode as GameNodeAction, centerX, centerY, ref ChildSleepTimeMS, NodeList);
                                }
                                CurrentRepeatsUntilFalseLimit--;
                                goto RepeatAction;
                            }
                        }
                        ActionTypeEventResult = true;
                    }

                    break;
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///             RNGContainer
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                case ActionType.RNGContainer:

                    ThreadManager.IncrementNewRNGContainer();

                    if (node.Nodes.Count > 0)
                    {
                        int Increment = 100 / node.Nodes.Count;

                        int RNG = Utils.RandomNumber(1, 100);

                        int TargetIndex = Math.Ceiling((double)RNG / Increment).ToInt() - 1;

                        //Extremely rare this returns > # nodes
                        if (TargetIndex >= node.Nodes.Count)
                        {
                            if (node.Nodes.Count > 0)
                            {
                                TargetIndex = node.Nodes.Count - 1;
                            }
                            else
                            {
                                Debug.Assert(false);
                                return AfterCompletionType.Home;
                            }
                        }

                        Game.Log(node.Name + " RNG (" + RNG + ") Node Index chosen (" + TargetIndex + ")");

                        int DelayCalc = node.CalculateDelayInMS();


                        if (DelayCalc > 0)
                        {
                            Game.Log(node.Name + " Waiting " + DelayCalc);
                        }
                        Thread.Sleep(DelayCalc);
                        ChildSleepTimeMS = ChildSleepTimeMS + DelayCalc;

                        ThreadManager.IncrementWaitLength();

                        GameNodeAction RNGNode = node.Nodes[TargetIndex] as GameNodeAction;

                        if (RNGNode.Enabled == false)
                        {
                            //Debug.WriteLine($"ProcessChildren.RngNode.!.Enabled: {node.Name},{Watch.ElapsedMilliseconds}");
                            return AfterCompletionType.Continue;
                        }

                        if (RNGNode.IsLimited)
                        {
                            AfterCompletionType Result = CheckLimit(RNGNode);
                            switch (Result)
                            {
                                case AfterCompletionType.ContinueProcess:
                                    // do nothing
                                    break;
                                default:
                                    //Debug.WriteLine($"ProcessChildren.RngNode.IsLimited.!ContinueProcess {node.Name},{Watch.ElapsedMilliseconds}");
                                    return Result;
                            }
                        }

                        foreach (TreeNode t in RNGNode.Nodes)
                        {
                            if (NodeList.Count > 0)
                            {
                                if (t.Name == NodeList[0])
                                {
                                    NodeList.RemoveAt(0);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            AfterCompletionType ACT = ProcessChildren(bmp, t as GameNodeAction, centerX, centerY, ref ChildSleepTimeMS, NodeList);

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
                                case AfterCompletionType.Stop:
                                    ThreadManager.IncrementGoStop();
                                    StopThreadCloseWindow(t as GameNode, WindowHandle, true);
                                    return AfterCompletionType.Stop;
                                case AfterCompletionType.Recycle:
                                    Recycle(node, WindowHandle);
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

            }  // switch (node.ActionType)

            if ((node.ActionType == ActionType.Event && ActionTypeEventResult) || node.ActionType == ActionType.Action)
            {
                int DelayCalc = node.CalculateDelayInMS();
                int Addition = 0;
                if (node.Mode == Mode.MouseMove || node.Mode == Mode.ClickDragRelease)
                {
                    Addition = node.ClickDragReleaseVelocity;
                }

                // Log status to status control.
                if (node.RuntimeKeyboardMS > 0)
                {
                    // Pass in negative keyboard runtime, this will generate a block on the tracking board of the keyboard time.
                    Game.LogStatus(node.StatusNodeID, -node.RuntimeKeyboardMS, Addition);
                }

                // Log status to stats control for positioning.
                if (node.RuntimeMouseMS > 0)
                {
                    // Pass in negative mouseMS runtime, this will generate a block on the tracking board of the keyboard time.
                    Game.LogStatus(node.StatusNodeID, -node.RuntimeMouseMS, Addition);

                }

                //This adds a tracking artifact on the runtime screen, but this only shows the wait time after an action/event.
                Game.LogStatus(node.StatusNodeID, DelayCalc, Addition);
                if (DelayCalc > 0)
                {
                    
                    Thread.Sleep(DelayCalc);
                    //Debug.WriteLine($"ProcessChildren, Sleep={DelayCalc}");
                    ChildSleepTimeMS = ChildSleepTimeMS + DelayCalc;
                }
                ThreadManager.AddWaitLength(DelayCalc);

                //Debug.WriteLine($"ProcessChildren.ATCReturns: {node.Name},{Watch.ElapsedMilliseconds}");
                switch (node.AfterCompletionType)
                {
                    case AfterCompletionType.Continue:
                        ThreadManager.IncrementGoContinue();
                        Boolean ExitFor = false;
                        foreach (TreeNode t in node.Nodes)
                        {
                            if (NodeList.Count > 0)
                            {
                                if (t.Name == NodeList[0])
                                {
                                    NodeList.RemoveAt(0);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            AfterCompletionType ACT = ProcessChildren(bmp, t as GameNodeAction, centerX, centerY, ref ChildSleepTimeMS, NodeList);

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
                                    StopThreadCloseWindow(t as GameNode, WindowHandle, true);
                                    return AfterCompletionType.Stop;
                                case AfterCompletionType.Continue:
                                    ThreadManager.IncrementGoContinue();
                                    break;
                                case AfterCompletionType.Recycle:
                                    Recycle(node, WindowHandle);
                                    break;
                                case AfterCompletionType.ContinueProcess:
                                    ThreadManager.IncrementGoContinue();
                                    break;
                                case AfterCompletionType.GoToParent:

                                    GoToNodeName = (t as GameNodeAction).GotoNode;
                                    return AfterCompletionType.GoToChild;
                                case AfterCompletionType.GoToChild:
                                    return AfterCompletionType.GoToChild;

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
                        StopThreadCloseWindow(node as GameNode, WindowHandle, true);
                        return AfterCompletionType.Stop;
                    case AfterCompletionType.Recycle:
                        Recycle(node, WindowHandle);
                        break;
                    case AfterCompletionType.GoToParent:
                        GoToNodeName = (node as GameNodeAction).GotoNode;
                        return AfterCompletionType.GoToChild;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }

            //Debug.WriteLine($"ProcessChildren./: {node.Name},{Watch.ElapsedMilliseconds}");
            ThreadManager.IncrementGoContinue();
            return AfterCompletionType.Continue;
        } // ProcessChildren

        private ActivateWindowResult ActivateIfNecessary(GameNodeAction node)
        {
            ActivateWindowResult Result = ActivateWindowResult.WindowAlreadyActivated;
            if (node.AppActivateIfNotActive)
            {
                Result = Utils.ActivateWindowIfNecessary2(Game.GetWindowHandleByWindowName(), node.KeyboardTimeoutToActivateMS, node.KeyboardAfterSendingActivationMS);
                switch (Result)
                {
                    case ActivateWindowResult.WindowAlreadyActivated:
                        // Do nothing
                        break;
                    case ActivateWindowResult.WindowActivated:
                        Game.Log("Window Activated");
                        break;
                    case ActivateWindowResult.Timeout:

                        if (node.PreActionFailureAction == TimeoutAction.Abort)
                        {
                            Game.Log("Window Timeout Abort");                            
                        }
                        else
                        {
                            Game.Log("Window Timeout Continue");
                        }
                        break;
                    default:
                        break;
                }
            }
            return Result;
        }

        /// <summary>
        /// Restart of Emmulator Event
        /// </summary>
        /// <param name="node"></param>
        /// <param name="windowHandle"></param>
        private void Recycle(GameNodeAction node, IntPtr windowHandle)
        {
            GameNodeGame Game = node.GetGameNodeGame();
            Game.Log(node.GameNodeName + " Recycle");
            StopThreadCloseWindow(node as GameNode, WindowHandle, false);

            Game.Log("Waiting 15 sec... to restart");
            Thread.Sleep(15000);
            Game.Log("Restarting: " + Game.TargetWindow);
            Utils.LaunchInstance(Game.PackageName, Game.TargetWindow, Game.InstanceToLaunch, Game.Resolution, Game.DPI);
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
            foreach (GameNodeAction node in Game.Events.Nodes)
            {
                InitializeChildren(node);
            }

            long LoopDelay = 0;
            while ( CancellationTokenSource.Token.IsCancellationRequested == false)
            {
                long ChildSleepTimeMS = 0;
                if (WindowHandle == IntPtr.Zero)
                {
                    WindowHandle = Game.GetWindowHandleByWindowName();
                }
                else
                {
                    // verify window exists.
                    IntPtr ParentHwnd = NativeMethods.GetAncestor(WindowHandle, NativeMethods.GetAncestorFlags.GetRoot);
                    if (ParentHwnd == IntPtr.Zero)
                    {
                        WindowHandle = IntPtr.Zero;
                    }
                }

                while (WindowHandle.ToInt32() == 0)
                {
                    while (Game.IsPaused && CancellationTokenSource.Token.IsCancellationRequested == false)
                    {
                        Thread.Sleep(1000);
                    }

                    if (Game.NeverQuitIfWindowNotFound)
                    {
                        Game.Log($"Can't find Window [{Game.TargetWindow}] the window may have been closed - Retrying in {Game.LoopDelay}ms");
                    }
                    else
                    {
                        Debug.WriteLine($"Can't find window [{Game.TargetWindow}] attempts left {RunTimeWindowTimeout}");
                        Game.Log($"Can't find Window [{Game.TargetWindow}] the window may have been closed - Retry Attempts left: {RunTimeWindowTimeout}");
                    }

                    LoopDelay = Game.LoopDelay;
                    while (LoopDelay > 1000 && CancellationTokenSource.Token.IsCancellationRequested == false)
                    {
                        LoopDelay = LoopDelay - 1000;
                        Thread.Sleep(1000);
                    }

                    if (LoopDelay > 0)
                    {
                        Thread.Sleep(LoopDelay.ToInt());
                    }

                    WindowHandle = Game.GetWindowHandleByWindowName();

                    if (Game.NeverQuitIfWindowNotFound)
                    {
                        // do nothing
                    }
                    else
                    {
                        RunTimeWindowTimeout = RunTimeWindowTimeout - 1;
                    }

                    if (RunTimeWindowTimeout < 0)
                    {
                        Game.Log("Unable to locate window during startup met timeout limit");
                        Game.Log("Exiting thread");
                        Game.Log("You can disable early stopping by setting [Never Quit if Window Not Found] on the General Settings for the project.");
                        Thread.Sleep(1000);
                        ShutdownThread(Game, true);
                    }

                    if (WindowHandle.ToInt32() > 0)
                    {
                        Game.Log("Located window " + Game.TargetWindow);
                    }
                }

                Boolean BitMapSuccess = false;

                Stopwatch Watch = System.Diagnostics.Stopwatch.StartNew();

                Bitmap bmp = null;
                if (Game.DontTakeScreenshot)
                {
                    BitMapSuccess = true;
                }
                else
                {
                    bmp = GetBitMap(ref BitMapSuccess);
                }
                //Debug.WriteLine($"Bitmap in: {Watch.ElapsedMilliseconds}");

                if (BitMapSuccess)
                {
                    ThreadManager.IncrementScreenShots();
                    Game.ScreenShotsTaken++;
                    Game.GameLoops++;

                    AfterCompletionType afterCompletionType = ProcessTreeNodes(ref ChildSleepTimeMS, bmp, new List<String>());

                    int GotoLimit = 100;
                    while( afterCompletionType == AfterCompletionType.GoToChild && GotoLimit > 0)
                    {
                        List<String> NodeList = new List<String>(GoToNodeName.Split('\\'));

                        afterCompletionType = ProcessTreeNodes(ref ChildSleepTimeMS, bmp, NodeList);
                        GotoLimit--;
                        if(GotoLimit == 0)
                        {
                            Game.Log("Recursive/Chaining/Circular GoTo only supported up to 100 iterations.");
                            Game.Log("Please try to limit Recursive/Chaining/Circular GoTo use or modify ATS by setting the GotoLimit to a higher value.");
                        }
                        while (Game.IsPaused && CancellationTokenSource.Token.IsCancellationRequested == false)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
                else
                {
                    Game.Log("Lost window #" + WindowHandle.ToInt32());
                    WindowHandle = IntPtr.Zero;
                }

                Watch.Stop();
                long ProcessingTimeMS = Watch.ElapsedMilliseconds - ChildSleepTimeMS;
                Debug.WriteLine("Main Loop ms: " + Watch.ElapsedMilliseconds);
                Debug.WriteLine("Child Sleep Time ms:" + ChildSleepTimeMS);
                Debug.WriteLine("Processing Time ms:" + ProcessingTimeMS);
                ThreadManager.AddProcessingTime(ProcessingTimeMS.ToInt());

                LoopDelay = Game.LoopDelay;
                while (LoopDelay > 1000 && CancellationTokenSource.Token.IsCancellationRequested == false)
                {
                    Game.LogStatus(Game.StatusNodeID, LoopDelay, 0);

                    LoopDelay = LoopDelay - 1000;
                    Thread.Sleep(1000);
                    ThreadManager.AddWaitLength(1000);
                }

                if (LoopDelay > 0)
                {
                    Game.LogStatus(Game.StatusNodeID, LoopDelay, 0);

                    Thread.Sleep(LoopDelay.ToInt());
                    ThreadManager.AddWaitLength(LoopDelay);
                }

                while (Game.IsPaused && CancellationTokenSource.Token.IsCancellationRequested == false)
                {
                    Thread.Sleep(1000);
                }

                // Clean up Screenshot
                if (bmp.IsNothing())
                {
                    //'do nothing
                }
                else
                {
                    bmp.Dispose();
                }
                bmp = null;
            }  // ThreadIsShuttingDown == false
        }  // Run()

        private AfterCompletionType ProcessTreeNodes(ref long ChildSleepTimeMS, Bitmap bmp, List<String> NodeList)
        {
            int CenterX = 0;
            int CenterY = 0;
            int InitialNodeListCount = NodeList.Count;
            Boolean FoundNode = false;
            AfterCompletionType afterCompletionType = AfterCompletionType.Continue;
            foreach (TreeNode node in Game.Events.Nodes)
            {

                if (NodeList.Count > 0 )
                {
                    if (node.Name == NodeList[0])
                    {
                        FoundNode = true;
                        NodeList.RemoveAt(0);
                    }
                    else
                    {
                        continue;
                    }
                }

                //long PreProcessChildren = Watch.ElapsedMilliseconds;
                afterCompletionType = ProcessChildren(bmp, node as GameNodeAction, CenterX, CenterY, ref ChildSleepTimeMS, NodeList);
                //long PostProcessChildren = Watch.ElapsedMilliseconds;
                //Debug.WriteLine($"Main Processchildren time{PostProcessChildren - PreProcessChildren}");
                Boolean ExitFor = false;
                switch (afterCompletionType)
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
                    case AfterCompletionType.Recycle:
                        Recycle(node as GameNodeAction, WindowHandle);
                        break;
                    case AppTestStudio.AfterCompletionType.ContinueProcess:
                        // should not be here?
                        Debug.Assert(false);
                        break;
                    case AfterCompletionType.GoToParent:
                        ExitFor = true;
                        break;
                    case AfterCompletionType.GoToChild:
                        ExitFor = true;
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

            if ( InitialNodeListCount > 0 && FoundNode == false)
            {
                Game.Log($"Expected to see node {NodeList[0]} but didn't find it.");
                Game.Log($"Since we are looking for {NodeList[0]} no nodes were processed on this section.");
                Game.Log($"This indicates a problem with the following with the Goto node.");
            }
            else
            {
                Debug.WriteLine("hrml.");
            }

            return afterCompletionType;
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

            switch (node.ActionType)
            {
                case AppTestStudio.ActionType.RNGContainer:
                    break;
                case ActionType.RNG:
                    break;
                case ActionType.Event:
                    if (node.IsColorPoint)
                    {
                        if (node.ClickList.Count == 0)
                        {
                        }
                        else
                        {
                        }

                    }
                    else
                    {
                        if (node.Rectangle.IsFullScreenMask())
                        {
                            node.Rectangle = node.Rectangle.SetFullScreenFromDefault();
                        }
                        // Object search
                    }
                    break;
            }



            foreach (GameNodeAction Node in node.Nodes)
            {
                InitializeChildren(Node);
            }
        }
    }
}

