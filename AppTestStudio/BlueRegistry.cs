//AppTestStudio 
//Copyright(C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    [SupportedOSPlatform("windows")]
    public class BlueRegistry
    {
        //Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks\Config\PartnerExePath
        public String ExePath { get; set; }

        public List<String> InstanceNames { get; set; }

        //Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Config\PartnerExePath
        public String ExePath64 { get; set; }

        public List<String> InstanceName64s { get; set; }

        public String ExceptionMessage { get; set; }

        public Boolean IsValid32 { get; set; }
        public Boolean IsValid64 { get; set; }

        public BlueRegistry()
        {
            IsValid32 = false;
            IsValid64 = false;
            ExceptionMessage = "";
            ExePath = "";
            ExePath64 = "";
            InstanceName64s = new List<string>();
            InstanceNames = new List<string>();

            GuestList32 = new List<BlueGuest>();
            GuestList64 = new List<BlueGuest>();
            GuestList = new List<BlueGuest>();

            try
            {
                Object PartnerExePath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks\Config", "PartnerExePath", "");
                if (PartnerExePath.IsSomething())
                {
                    ExePath = PartnerExePath.ToString();
                    if (System.IO.File.Exists(ExePath))
                    {
                        IsValid32 = true;
                    }
                }

                Object PartnerExePath64 = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Config", "PartnerExePath", "");
                if (PartnerExePath64.IsSomething())
                {
                    ExePath64 = PartnerExePath64.ToString();
                    if (System.IO.File.Exists(ExePath64))
                    {
                        IsValid64 = true;
                    }
                }

                RegistryKey Guests = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\BlueStacks\Guests\");
                if (Guests.IsSomething())
                {
                    InstanceNames = Guests.GetSubKeyNames().ToList<String>();

                    foreach (String InstanceName in InstanceNames)
                    {
                        BlueGuest guest = new BlueGuest();
                        guest.ExePath = PartnerExePath.ToString();
                        guest.Is32Bit = true;
                        guest.KeyName = InstanceName;

                        Object DisplayNameRegistry = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks\Guests\" + InstanceName + @"\Config\", "DisplayName", "");
                        if (DisplayNameRegistry.IsSomething())
                        {
                            if (InstanceName == "Android")
                            {
                                guest.WindowTitle = "BlueStacks";
                            }
                            else
                            {
                                guest.WindowTitle = DisplayNameRegistry.ToString();
                            }
                            guest.DisplayName = DisplayNameRegistry.ToString();
                        }
                        GuestList32.Add(guest);
                        GuestList.Add(guest);
                    }
                }

                RegistryKey Guests64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\BlueStacks_bgp64\Guests\");
                if (Guests64.IsSomething())
                {
                    InstanceName64s = Guests64.GetSubKeyNames().ToList<String>();

                    foreach (String InstanceName in InstanceName64s)
                    {
                        BlueGuest guest = new BlueGuest();
                        guest.ExePath = PartnerExePath64.ToString();
                        guest.Is32Bit = false;
                        guest.KeyName = InstanceName;

                        Object DisplayNameRegistry = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Guests\" + InstanceName + @"\Config\", "DisplayName", "");
                        if (DisplayNameRegistry.IsSomething())
                        {
                            if (InstanceName == "Android")
                            {
                                guest.WindowTitle = "BlueStacks";
                            }
                            else
                            {
                                guest.WindowTitle = DisplayNameRegistry.ToString();
                            }
                            guest.DisplayName = DisplayNameRegistry.ToString();
                        }
                        GuestList64.Add(guest);
                        GuestList.Add(guest);
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }
        }

        public List<BlueGuest> GuestList32 { get; set; }
        public List<BlueGuest> GuestList64 { get; set; }

        // Combined Guest 32/64, these share the pointer to blueguest with the 32/64 versions.
        public List<BlueGuest> GuestList { get; set; }
    }
}
