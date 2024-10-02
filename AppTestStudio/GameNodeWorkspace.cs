//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;

namespace AppTestStudio
{
    public class GameNodeWorkspace : GameNode
    {
        public GameNodeWorkspace(String name)
            :base(name,GameNodeType.Workspace)
        {
            Utils.SetIcons(this);
        }
        public String SaveFileName { get; set; }
        public String WorkspaceFolder { get; set; }
        public String ProjectName { get; set; }
    }
}
