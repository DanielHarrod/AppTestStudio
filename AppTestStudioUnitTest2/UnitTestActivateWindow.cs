using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestActivateWindow
    {
        [TestMethod]
        public void CheckWithNotepad()
        {
            ThreadManager threadManger = new ThreadManager();
            GameNodeGame game = new GameNodeGame("Testing", threadManger);
            game.Platform = Platform.Application;
            game.ApplicationPrimaryWindowName = "*Untitled - Notepad";
            IntPtr hWnd = AppTestStudio.Utils.GetWindowHandleByWindowName(game);
            if (hWnd.Equals(IntPtr.Zero))
            {
                Debug.WriteLine($"Unable to locate {game.ApplicationPrimaryWindowName}");
            }
            else
            {
                Utils.ActivateWindowIfNecessary2(hWnd,4000,100);

            }
        }
    }
}
