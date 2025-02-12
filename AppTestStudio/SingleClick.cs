//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

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
