using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    //"C:\Program Files\BlueStacks\Bluestacks.exe" -vmname Android
    //"C:\Program Files\BlueStacks_bgp64\Bluestacks.exe" -vmname Android
    //"C:\Program Files\BlueStacks_bgp64\Bluestacks.exe" -vmname Android_1
    //Don't use - "C:\Program Files\BlueStacks\HD-RunApp.exe" -vmname Android_1 -json "{\"app_icon_url\":\"\",\"app_name\":\"Holyday City\",\"app_url\":\"\",\"app_pkg\":\"com.HolydayStudios.HolydayCityTycoon1\"}"

    //"C:\Program Files\BlueStacks_bgp64\Bluestacks.exe" -vmname Android_1 -json "{\"app_icon_url\":\"\",\"app_name\":\"Holyday City\",\"app_url\":\"\",\"app_pkg\":\"com.HolydayStudios.HolydayCityTycoon1\"}"
    //Don't use - "C:\Program Files\BlueStacks\HD-RunApp.exe" -vmname Android_1 -json "{\"app_icon_url\":\"\",\"app_name\":\"Holyday City\",\"app_url\":\"\",\"app_pkg\":\"com.HolydayStudios.HolydayCityTycoon1\"}"
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
                        }
                    }
                }

                RegistryKey Guests64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\BlueStacks_bgp64\Guests\");
                if (Guests64.IsSomething())
                {
                    InstanceName64s = Guests64.GetSubKeyNames().ToList<String>();

                    foreach (String InstanceName in InstanceName64s)
                    {
                        BlueGuest guest = new BlueGuest();
                        guest.ExePath = PartnerExePath.ToString();
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
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }
        }
    }
}
