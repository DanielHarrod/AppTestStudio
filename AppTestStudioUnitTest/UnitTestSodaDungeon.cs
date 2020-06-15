using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestSodaDungeon
    {
        [TestMethod]
        public void TestNonNoxgame()
        {
            IntPtr k = AppTestStudio.Utils.GetWindowHandleByWindowName("Soda Dungeon","");

            Bitmap b = AppTestStudio.Utils.GetBitmapFromWindowHandle(k);

            AppTestStudio.Utils.ClickOnWindow(k, 100, 100, 0);
        }
    }
}
