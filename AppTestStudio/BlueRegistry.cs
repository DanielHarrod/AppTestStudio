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
        //"C:\Program Files\BlueStacks\HD-RunApp.exe" -vmname Android_1 -json "{\"app_icon_url\":\"\",\"app_name\":\"Holyday City\",\"app_url\":\"\",\"app_pkg\":\"com.HolydayStudios.HolydayCityTycoon1\"}"
    public class BlueRegistry
    {
        //Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks\Config\PartnerExePath
        public String ExePath { get; set; }

        public List<String> InstanceName { get; set; }

        //Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Config\PartnerExePath
        public String ExePath64 { get; set; }

        public List<String> InstanceName64 { get; set; }

        public String ExceptionMessage { get; set; }

        public Boolean IsValid { get; set; }

        public BlueRegistry()
        {
            IsValid = false;
            ExceptionMessage = "";
            ExePath = "";
            ExePath64 = "";
            InstanceName64 = new List<string>();
            InstanceName = new List<string>();


            try
            {
                Object PartnerExePath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks\Config", "PartnerExePath", "");
                if (PartnerExePath.IsSomething())
                {
                    ExePath = PartnerExePath.ToString();
                }

                Object PartnerExePath64 = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Config", "PartnerExePath", "");
                if (PartnerExePath64.IsSomething())
                {
                    ExePath64 = PartnerExePath64.ToString();
                }

                RegistryKey Guests = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\BlueStacks\Guests\");
                if (Guests.IsSomething())
                {
                    InstanceName = Guests.GetSubKeyNames().ToList<String>();
                }

                RegistryKey Guests64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\BlueStacks_bgp64\Guests\");
                if (Guests64.IsSomething())
                {
                    InstanceName64 = Guests64.GetSubKeyNames().ToList<String>();
                }

                IsValid = true;
            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message;
            }
        }
    }
}
