using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public class GameNodeWorkspace : GameNode
    {
        public GameNodeWorkspace(String name)
            :base(name,GameNodeType.Workspace)
        {

        }
        public String SaveFileName { get; set; }
        public String WorkspaceFolder { get; set; }
        public String ProjectName { get; set; }
    }
}
