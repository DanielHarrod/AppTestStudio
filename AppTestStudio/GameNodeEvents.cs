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
    public class GameNodeEvents: GameNode
    {
        public GameNodeEvents(String name) : base(name, GameNodeType.Events)
        {
            Utils.SetIcons(this);
        }

        public GameNodeEvents CloneMe()
        {
            GameNodeEvents Events = new GameNodeEvents(GameNodeName);
            foreach (GameNodeAction Node in Nodes)
            {
                GameNodeAction Child = Node.CloneMe();
                Events.Nodes.Add(Child);

            }
            return Events;
        }
    }
}
