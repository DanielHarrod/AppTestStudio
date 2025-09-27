using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    internal class MouseSolutionMessage
    {
        public IntPtr WindowHandle;
        public int Message;
        public int wParam;
        public int lParam;
        public int AfterDelay;

        public int CalcX {
            get {
                return lParam & 0xFFFF;
            }
        }

        public int CalcY
        {
            get
            {
                return (lParam >> 16) & 0xFFFF;
            }
        }
    }
}
