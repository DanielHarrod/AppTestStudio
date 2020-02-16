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
        public long StatusNodeID { get; set; }

        //Which panel to show
        public GameNodeType GameNodeType { get; set; }

        public String GameNodeName { get; set; }

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

    }
}
