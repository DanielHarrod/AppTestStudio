using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public class MinimalBitmapNode
    {
        public Bitmap Bitmap { get; set; }

        public String NodeName { get; set; }

        public long ResolutionHeight { get; set; }
        public long ResolutionWidth { get; set; }
    }
}
