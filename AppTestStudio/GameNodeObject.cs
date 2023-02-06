//AppTestStudio 
//Copyright (C) 2016-2023 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    // Game Node Object represents a bitmap to be used for searching.
    class GameNodeObject: GameNode 
    {
        public GameNodeObject(String name) : base(name, GameNodeType.Object)
        {
            Utils.SetIcons(this);
        }

        private Bitmap mbitMap;

        public Bitmap Bitmap
        {
            get { 

                return mbitMap; 
            }
            set { 
                mbitMap = value;
                FileName = String.Format("{0}{1}.bmp", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-"), Environment.TickCount & int.MaxValue);
            }
        }

        public String FileName { get; set; }

        public GameNodeObject CloneMe()
        {
            GameNodeObject Node = new GameNodeObject(GameNodeName);
            if (Bitmap.IsSomething())
            {
                Node.Bitmap = Bitmap.CloneMe();
            }

            Node.FileName = FileName;
            return Node;
        }

    }
}
