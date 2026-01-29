using AppTestStudio;
using OpenCvSharp;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestFindFirstColor
    {
        [TestMethod]
        public void TestMethod1()
        {

            IntPtr k = Utils.GetWindowHandleByWindowName("Clicker Heroes", "");

            Boolean Success = false;
            Bitmap b = Utils.GetBitmapFromWindowHandle(ref Success, k);


            var k1 = Utils.FindFirstColor(b, Color.FromArgb(121, 4, 30), 0);
            Debug.WriteLine(k1);
        }   
    }
}
