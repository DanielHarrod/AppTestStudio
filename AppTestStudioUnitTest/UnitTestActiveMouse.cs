using System;
using System.Diagnostics;
using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestActiveMouse
    {
        [TestMethod]
        public void TestClickOnWindowActiveMode()
        {
            IntPtr x = new IntPtr(0x028B2682);
            AppTestStudio.Utils.ClickOnWindowActiveMode(x, 100, 100,100);
        }

        [TestMethod]
        public void TestGetWindowRectOnDualMonitor()
        {
            IntPtr x = new IntPtr(0x028B2682);
            AppTestStudio.API.RECT R;
            AppTestStudio.API.GetWindowRect(x, out R);
        }

        [TestMethod]
        public void TestSetForegroundWindow()
        {
            IntPtr x = new IntPtr(0x028B2682);
            bool Result = AppTestStudio.API.SetForegroundWindow(x);
            Debug.WriteLine("SetForegroundWindow returns:" +Result);
        }

        [TestMethod]
        public void TestGetForegroundWindow()
        {
            IntPtr x = AppTestStudio.API.GetForegroundWindow();
            Debug.WriteLine("GetForegroundWindow returns:" + x.ToInt32().ToString("X"));
        }

        [TestMethod]
        public void GetAncestor()
        {
            IntPtr x = AppTestStudio.API.GetForegroundWindow();

            x = AppTestStudio.Utils.GetWindowHandleByWindowName("Hades' Star", "");

            IntPtr Parent = API.GetAncestor(x, API.GetAncestorFlags.GetParent);
            IntPtr Root = API.GetAncestor(x, API.GetAncestorFlags.GetRoot);
            IntPtr RootOwner = API.GetAncestor(x, API.GetAncestorFlags.GetRootOwner);


        }
    }
}
