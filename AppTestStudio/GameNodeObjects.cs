// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
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
            Utils.SetIcons(this);
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
