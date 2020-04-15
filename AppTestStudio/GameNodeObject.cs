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
