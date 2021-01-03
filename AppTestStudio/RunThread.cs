//AppTestStudio 
//Copyright (C) 2016-2021 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

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
using System.Web.Hosting;

namespace AppTestStudio
{
    public class RunThread
    {
        public GameNodeGame Game { get; set; }
        public IntPtr WindowHandle { get; set; }

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
            WindowHandle = IntPtr.Zero;
        }

        private Bitmap GetBitMap(ref Boolean Success)
        {
            Success = false;

            IntPtr hdcSrc = API.GetWindowDC(WindowHandle);
            if (hdcSrc.ToInt32() == 0)
            {
                Game.Log("GetWindowDC = 0 " + WindowHandle);
                Game.Log("Refetching Window for " + Game.TargetWindow);
                WindowHandle = Game.GetWindowHandleByWindowName();
            }
            API.RECT WindowRectangle = new API.RECT();

            API.GetWindowRect(WindowHandle, out WindowRectangle);

            int TargetWindowHeight = WindowRectangle.Bottom - WindowRectangle.Top;
            int TargetWindowWidth = WindowRectangle.Right - WindowRectangle.Left;

            if (TargetWindowHeight < 1 || TargetWindowWidth < 1)
            {
                return null;
            }

            IntPtr hdcDest = API.CreateCompatibleDC(hdcSrc);

            IntPtr hBitmap = API.CreateCompatibleBitmap(hdcSrc, TargetWindowWidth, TargetWindowHeight);

            if (hBitmap.ToInt32() == 0)
            {
                API.DeleteDC(hdcDest);
                return null;
            }

            IntPtr hOld = API.SelectObject(hdcDest, hBitmap);

            //'modAPI.BitBlt(hdcDest, 0, 0, TargetWindowWidth, TargetWindowHeight, hdcSrc, 0, 0, &HCC0020)

            API.PrintWindow(WindowHandle, hdcDest, 2);

            API.SelectObject(hdcDest, hOld);
            API.DeleteDC(hdcDest);
            API.ReleaseDC(WindowHandle, hdcSrc);

            Bitmap bmp = Image.FromHbitmap(hBitmap);
            API.DeleteObject(hBitmap);

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
                ThreadIsShuttingDown = true;

                if (Game.SaveVideo)
                {
                    Game.Video.Release();
                    Game.Video = null;
                }

                ThreadManager.RemoveGame(Game);

                Game.Log("Shutting down thread:" + Game.GameNodeName + " on instance " + Game.InstanceToLaunch);
                //Debug.WriteLine("Shutting down thread:" + Game.GameNodeName + " on instance " + Game.InstanceToLaunch);

                Thread.CurrentThread.Abort();
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
        private AfterCompletionType ProcessChildren(Bitmap bmp, GameNodeAction node, int centerX, int centerY, ref long ChildSleepTimeMS)
        {
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
                                //'do nothing
                                return AfterCompletionType.ContinueProcess;
                            }
                            else
                            {
                                Game.Log(node.Name + " Click(" + Result.x + "," + Result.y + ")");
                                int MousePixelSpeedPerSecond = Game.CalculateNextMousePixelSpeedPerSecond();
                                Utils.ClickOnWindow(WindowHandle, node.MouseMode, node.MoveMouseBeforeClicking, Game.MouseX, Game.MouseY, Result.x, Result.y, node.ClickSpeed, MousePixelSpeedPerSecond);
                                Game.MouseX = (short)Result.x;
                                Game.MouseY = (short)Result.y;

                                ThreadManager.IncrementClickCount();

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
                                Game.Log("Swipe from ( x=" + CDRResult.StartX + ",y = " + CDRResult.StartY + " to x=" + CDRResult.EndX + ",y=" + CDRResult.EndY + ")");
                                Utils.ClickDragRelease(WindowHandle, Game.MouseMode, CDRResult.StartX, CDRResult.StartY, CDRResult.EndX, CDRResult.EndY, node.ClickDragReleaseVelocity, Game.MouseSpeedPixelsPerSecond);
                                Game.MouseX = (short)CDRResult.EndX;
                                Game.MouseY = (short)CDRResult.EndY;
                                ThreadManager.IncrementClickDragRelease();
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

                RepeatAction:
                    if (node.UseParentPicture == false || AlwaysTakeScreenshot)
                    {
                        Boolean Success = false;
                        //bmp.Dispose();// not good
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

                    if (node.IsTrue(bmp, Game, ref centerX, ref centerY, ref Offset, ref DetectedThreashold))
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

                        node.ThreadMatchCount++;

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
                                    ProcessChildren(bmp, ChildNode as GameNodeAction, centerX, centerY, ref ChildSleepTimeMS);
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

                        int TargetIndex = (int)Math.Ceiling((double)RNG / Increment) - 1;

                        Game.Log(node.Name + " RNG (" + RNG + ") Node Index chosen (" + TargetIndex + ")");

                        int DelayCalc = node.DelayMS + (node.DelayS * 1000) + (node.DelayM * 60 * 1000);


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
                                    return Result;
                            }
                        }

                        foreach (TreeNode t in RNGNode.Nodes)
                        {
                            AfterCompletionType ACT = ProcessChildren(bmp, t as GameNodeAction, centerX, centerY, ref ChildSleepTimeMS);

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
                int DelayCalc = node.DelayMS + (node.DelayS * 1000) + (node.DelayM * 60 * 1000);

                // Log status to status control.
                Game.LogStatus(node.StatusNodeID, DelayCalc);

                if (DelayCalc > 0)
                {
                    Thread.Sleep(DelayCalc);
                    ChildSleepTimeMS = ChildSleepTimeMS + DelayCalc;
                }
                ThreadManager.AddWaitLength(DelayCalc);

                switch (node.AfterCompletionType)
                {
                    case AfterCompletionType.Continue:
                        ThreadManager.IncrementGoContinue();
                        Boolean ExitFor = false;
                        foreach (TreeNode t in node.Nodes)
                        {
                            AfterCompletionType ACT = ProcessChildren(bmp, t as GameNodeAction, centerX, centerY, ref ChildSleepTimeMS);

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
                    default:
                        break;
                }
            }

            ThreadManager.IncrementGoContinue();
            return AfterCompletionType.Continue;
        } // ProcessChildren

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
            while (ThreadIsShuttingDown == false)
            {
                long ChildSleepTimeMS = 0;
                if (WindowHandle == IntPtr.Zero)
                {
                    WindowHandle = Game.GetWindowHandleByWindowName();
                }

                while (WindowHandle.ToInt32() == 0)
                {
                    while (Game.IsPaused)
                    {
                        Thread.Sleep(1000);
                    }

                    Debug.WriteLine("Can't find window [" + Game.TargetWindow + "] attempts left " + RunTimeWindowTimeout);
                    Game.Log("Can't find Window [" + Game.TargetWindow + "] the window may have been closed - Retry Attempts left: " + RunTimeWindowTimeout);

                    LoopDelay = Game.LoopDelay;
                    while (LoopDelay > 1000)
                    {
                        LoopDelay = LoopDelay - 1000;
                        Thread.Sleep(1000);
                    }

                    if (LoopDelay > 0)
                    {
                        Thread.Sleep((int)LoopDelay);
                    }

                    WindowHandle = Game.GetWindowHandleByWindowName();
                    RunTimeWindowTimeout = RunTimeWindowTimeout - 1;

                    if (RunTimeWindowTimeout < 0)
                    {
                        Game.Log("Unable to locate window during startup met timeout limit");
                        Game.Log("Exiting thread");
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
                        AfterCompletionType ACT = ProcessChildren(bmp, node as GameNodeAction, CenterX, CenterY, ref ChildSleepTimeMS);
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
                            case AfterCompletionType.Recycle:
                                Recycle(node as GameNodeAction, WindowHandle);
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
                    Game.Log("Lost window #" + WindowHandle.ToInt32());
                    WindowHandle = IntPtr.Zero;
                }

                Watch.Stop();
                long ProcessingTimeMS = Watch.ElapsedMilliseconds - ChildSleepTimeMS;
                //Debug.WriteLine("Main Loop ms: " + Watch.ElapsedMilliseconds);
                //Debug.WriteLine("Child Sleep Time ms:" + ChildSleepTimeMS);
                //Debug.WriteLine("Processing Time ms:" + ProcessingTimeMS);

                LoopDelay = Game.LoopDelay;
                while (LoopDelay > 1000)
                {

                    Game.LogStatus(Game.StatusNodeID, LoopDelay);

                    LoopDelay = LoopDelay - 1000;
                    Thread.Sleep(1000);
                    ThreadManager.AddWaitLength(1000);
                }

                if (LoopDelay > 0)
                {
                    Game.LogStatus(Game.StatusNodeID, LoopDelay);

                    Thread.Sleep((int)LoopDelay);
                    ThreadManager.AddWaitLength(LoopDelay);
                }

                while (Game.IsPaused)
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

