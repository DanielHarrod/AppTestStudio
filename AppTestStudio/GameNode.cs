using System;
using System.Collections.Generic;
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
            Utils.SetIcons(this);

            NodeID = NextNodeID;
            NextNodeID++;
        }

        internal GameNodeGame GetGameNode()
        {
            GameNode Node = this;
            while (Node is GameNodeGame == false )
            {
                Node = Node.Parent as GameNode;
            }

            return Node as GameNodeGame;
        }

        internal GameNodeObjects GetObjectsNode()
        {
            GameNode GameNode = GetGameNode();
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
