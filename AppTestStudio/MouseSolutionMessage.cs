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
    }
}
