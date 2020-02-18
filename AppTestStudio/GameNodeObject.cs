﻿using System;
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

        }

        private Bitmap mbitMap;

        public Bitmap Bitmap
        {
            get { return mbitMap; }
            set { 
                mbitMap = value;
                FileName = String.Format("{0}{0}.bmp", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-"), Environment.TickCount & int.MaxValue);
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