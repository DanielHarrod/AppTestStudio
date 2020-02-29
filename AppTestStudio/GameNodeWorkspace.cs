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
