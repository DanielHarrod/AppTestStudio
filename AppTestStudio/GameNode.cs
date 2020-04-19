// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudio
{
    public class GameNode : TreeNode
    {
        // To Track between components
        public static long NextNodeID = 0;

        // Node ID
        public long NodeID { get; set; }

        // Runtime Tracking
        public int StatusNodeID { get; set; }

        //Which panel to show
        public GameNodeType GameNodeType { get; set; }

        private String mGameNodeName;

        public String GameNodeName
        {
            get { return mGameNodeName; }
            set { 
                mGameNodeName = value;
                Name = value;
                Text = value;
            }
        }

        public long GameLoops { get; set; }

        public GameNode(String Name, GameNodeType Type, ActionType ActionType = ActionType.Action )
        {
            GameNodeName = Name;
            this.Name = Name;
            this.Text = Name;
            GameNodeType = Type;
            NodeID = NextNodeID;
            NextNodeID++;
        }

        internal GameNodeGame GetGameNodeGame()
        {
            switch (this.GameNodeType)
            {
                case GameNodeType.Workspace:
                    // check before
                    if (Nodes.Count > 0)
                    {
                        return Nodes[0] as GameNodeGame ;
                    }
                    break;
                case GameNodeType.Games:
                    // not used.
                    Debug.Assert(false);
                    break;
                case GameNodeType.Game:
                    // check equals
                    return this as GameNodeGame;
                    break;
                //case GameNodeType.Events:
                //    break;
                //case GameNodeType.Event:
                //    break;
                //case GameNodeType.Action:
                //    break;
                //case GameNodeType.Objects:
                //    break;
                //case GameNodeType.ObjectScreenshot:
                //    break;
                //case GameNodeType.Object:
                //    break;
                default:
                    // Walk up the parents until it's found.
                    GameNode Node = this;
                    while (Node is GameNodeGame == false)
                    {
                        Node = Node.Parent as GameNode;
                    }

                    return Node as GameNodeGame;
                    break;
            }

            return null;
        }

        internal GameNodeObjects GetObjectsNode()
        {
            GameNode GameNode = GetGameNodeGame();
            foreach (GameNode node in GameNode.Nodes)
            {
                if ( node is GameNodeObjects)
                {
                    return node as GameNodeObjects;
                }

            }
        return null;

        }


    }
}
