//AppTestStudio 
//Copyright (C) 2016-2021 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public class NoxRegistry
    {
        public String ExePath { get; set; }
        public String BigNoxVMSFolder { get; set; }

        public String WorkingDirectory { get; set; }

        public String ErrorMessage { get; set; }

        public Boolean IsNoxInstalled { get; set; }
        public NoxRegistry()
        {
            try
            {

                IsNoxInstalled = false;
                ExePath = "";
                WorkingDirectory = "";
                Object NoxCommand = Registry.GetValue(@"HKEY_CLASSES_ROOT\Nox\shell\open\command", null, "");
                String ReadValue = "";
                if (NoxCommand.IsSomething())
                {
                    IsNoxInstalled = true;
                    ReadValue = NoxCommand.ToString();
                }

                if (ReadValue.Length > 0)
                {
                    String[] keys = { " %1 " };
                    String[] Results = ReadValue.Split(keys, 2, StringSplitOptions.None);
                    if (Results.Length == 2)
                    {
                        ExePath = Results[0];

                        WorkingDirectory = ExePath.Replace(@"bin\Nox.exe", "");

                        BigNoxVMSFolder = ExePath.Replace("Nox.exe", "BignoxVMS");
                    }
                    else
                    {
                        // do nothing
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ErrorMessage = ex.Message;
                Debug.Assert(false);
            }
        }
    }
}
