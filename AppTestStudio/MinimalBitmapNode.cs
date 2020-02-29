// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

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
