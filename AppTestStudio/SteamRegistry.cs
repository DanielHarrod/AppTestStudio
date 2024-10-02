//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public class SteamRegistry
    {
        public String ErrorMessage { get; set; }

        public String InstallPath { get; set; }

        public String GetExePath()
        {
            if (IsSteamInstalled)
            {
                return InstallPath + @"\Steam.exe";
            }
            return "";
        }

        public Boolean IsSteamInstalled { get; set; }
  
        public SteamRegistry()
        {
            try
            {
                Object NoxCommand = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", "");
                String ReadValue = "";
                if (NoxCommand.IsSomething())
                {
                    IsSteamInstalled = true;
                    ReadValue = NoxCommand.ToString();
                }

                if (ReadValue.Length > 0)
                {
                    InstallPath = ReadValue;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ErrorMessage = ex.Message;
            }
        }
    }


}
