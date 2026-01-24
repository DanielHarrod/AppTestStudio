using AppTestStudio;
using AppTestStudio.solution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp.Dnn;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using static AppTestStudio.Utils;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestMouseMove
    {
        [TestMethod]
        public void MonitorConfiguration2_1_Setup()
        {
            ActionSolution solution = new ActionSolution(0);


            String TargetWindow = "SodaDungeon2";

            IntPtr windowHandle = WindowFinder.GetWindowHandleByWindowName(TargetWindow, WindowNameFilterType.Equals);

            Boolean WindowRectResult = NativeMethods.GetWindowRect(windowHandle, out Rectangle TargetWindowRectangle);
            //{X = -2560 Y = 194 Width = 0 Height = 1634}

            short xTarget = 10;
            short yTarget = 10;
            int clickDuration = 50;

            Calculations.CalculateClickOnWindowActiveMode(windowHandle, xTarget, yTarget, clickDuration, solution);

            SolutionPlayer.Play(solution);
        }
    }
}
