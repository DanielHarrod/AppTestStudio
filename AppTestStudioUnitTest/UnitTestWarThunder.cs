using System;
using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestWarThunder
    {
        [TestMethod]
        public void ClickTest()
        {
            ThreadManager Manager = new ThreadManager();

            GameNodeGame Game = new GameNodeGame("Test", Manager);
            Game.Platform = Platform.Application;
            Game.ApplicationPrimaryWindowName = "War Thunder";
            Game.ApplicationPrimaryWindowFilter = WindowNameFilterType.StartsWith;
            Game.ApplicationSecondaryWindowFilter = WindowNameFilterType.Equals;
            Game.ApplicationSecondaryWindowName = "";

            IntPtr WindowHandle = AppTestStudio.Utils.GetWindowHandleByWindowName(Game);

            int MouseSpeedPixelsPerSecond = 6000;
            int ClickDurationMS = 10;

            int xStart = 3846;
            int yStart = 2200;
            int xEnd = 2967;
            int yEnd = 1794;

            // Deprecated
            //Utils.ClickOnWindow(WindowHandle, MouseMode.Active, true, WindowAction.ActivateWindow, xStart, yStart, xEnd, yEnd, ClickDurationMS, MouseSpeedPixelsPerSecond);
        }
    }
}
