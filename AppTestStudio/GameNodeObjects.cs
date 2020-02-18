﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    class GameNodeObjects : GameNode
    {
        public GameNodeObjects(String name) : base(name, GameNodeType.Objects)
        {

        }
        
        public GameNodeObjects CloneMe()
        {
            GameNodeObjects NewObject = new GameNodeObjects(GameNodeName);

            foreach (GameNodeObject Node in Nodes)
            {
                NewObject.Nodes.Add(Node.CloneMe());
            }

            return NewObject;
        }
    }
}