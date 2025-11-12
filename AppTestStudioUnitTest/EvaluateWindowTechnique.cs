using AppTestStudio;
using AppTestStudio.solution;
using OpenCvSharp;
using OpenCvSharp.Dnn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppTestStudio.Utils;

namespace AppTestStudioUnitTest
{

    [TestClass]
    public class EvaluateWindowTechnique
    {
        [TestMethod]
        public void EvaluateWindowTechniqueTestMethod1()
        {
            IntPtr WindowHandle = Utils.GetWindowHandleByWindowName("SodaDungeon2","");
            bool Success = false;
            Bitmap b = Utils.GetBitMap(ref Success, WindowHandle);
            b.Save("C:\\Temp\\EvaluateWindowTechniqueTestMethod1.png");

            Bitmap c = AppTestStudio.Utils.GetBitmapFromWindowHandle(ref Success, WindowHandle);
            c.Save("C:\\Temp\\EvaluateWindowTechniqueTestMethod1_2.png");

            Debug.WriteLine($"B{b.Height},{b.Width}");
            Debug.WriteLine($"C{c.Height},{c.Width}");

        }

        [TestMethod]
        public void MoveMouse()
        {
            Thread.Sleep(700);
            IntPtr WindowHandle = Utils.GetWindowHandleByWindowName("SodaDungeon2", "");

            ActionSolution solution = new ActionSolution();
            Calculations.CalculateClickOnWindowActiveMode(WindowHandle, 1, 1, 100, solution);

            SolutionPlayer.Play(solution);
        }

        [TestMethod]
        public void GetDpiForWindow()
        {
            IntPtr WindowHandle = Utils.GetWindowHandleByWindowName("SodaDungeon2", "");
            var Dpi = NativeMethods.GetDpiForWindow(WindowHandle);
            Debug.WriteLine($"DPI:{Dpi}");
        }
    }
}
