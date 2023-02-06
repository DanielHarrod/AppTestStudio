//AppTestStudio 
//Copyright (C) 2016-2023 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

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
        private GameNodeType mGameNodeType ;
        public GameNodeType GameNodeType
        {
            get 
            { 
                return mGameNodeType; 
            }
            set 
            { 
                mGameNodeType = value;
                Utils.SetIcons(this);
            }
        }

        private String mGameNodeName;

        public String GameNodeName
        {
            get { return mGameNodeName; }
            set {
                if (IsLoading == false)
                {
                    if (mGameNodeName != value)
                    {
                        IsDirty = true;
                    }
                }
                mGameNodeName = value;
                Name = value;
                Text = value;
            }
        }

        // Used to determine if any changes have occurred since the last checkpoint.
        private Boolean mIsDirty;

        public Boolean IsDirty
        {
            get { return mIsDirty; }
            protected set {
                if (value == true)
                {
                    int k = 3;
                }
                mIsDirty = value; 
            }
        }
        public void FlagAsDirty()
        {
            IsDirty = true;
        }

        // Used to determine if change tracking should be calculated.
        private Boolean mIsLoading;

        public Boolean IsLoading
        {
            get { return mIsLoading; }
            set
            {
                mIsLoading = value;
            }
        }


        public long GameLoops { get; set; }

        public GameNode(String Name, GameNodeType Type, ActionType ActionType = ActionType.Action )
        {
            IsLoading = true;
            GameNodeName = Name;
            this.Name = Name;
            this.Text = Name;
            GameNodeType = Type;
            NodeID = NextNodeID;
            NextNodeID++;
            IsLoading = false;
        }

        public void AddGameNode(GameNode gameNode)
        {
            if (IsLoading == false)
            {
                IsDirty = true;
            }
            Nodes.Add(gameNode);
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

        public Boolean IsAnythingDirty()
        {
            if (mIsDirty)
                return true;
            foreach (GameNode childNodes in Nodes)
            {
                if (childNodes.IsAnythingDirty())
                    return true;
            }
            return false;
        }

        public void ClearIsDirty()
        {
            mIsDirty = false;
            foreach (GameNode childNodes in Nodes)
            {
                childNodes.ClearIsDirty();
            }
        }
    }
}
