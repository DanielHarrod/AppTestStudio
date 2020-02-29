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
    public class SingleClick : ICloneable
    {

        public Color Color { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
        public object Clone()
        {
            SingleClick Target = new SingleClick();
            Target.Color = Color.FromArgb(Color.A, Color.R, Color.G, Color.B);
            Target.X = X;
            Target.Y = Y;
            return Target;
            {
                throw new NotImplementedException();
            }
        }
        public SingleClick CloneMe()
        {
            return (SingleClick)Clone();
        }

    }

}
