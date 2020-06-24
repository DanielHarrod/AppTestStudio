using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

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
