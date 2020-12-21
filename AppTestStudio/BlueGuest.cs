using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public class BlueGuest 
    {
        public BlueGuest()
        {
            KeyName = "";
            WindowTitle = "";
            DisplayName = "";
            Is32Bit = false;
            ExePath = "";
        }
        // Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Guests
        public String KeyName { get; set; }

        // Key0 is always BlueStacks
        // Key[1*] Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Guests\Key[1+]\Config\DisplayName
        public String WindowTitle { get; set; }

        //Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Guests\Key\Config\DisplayName
        public String DisplayName { get; set; }

        public Boolean Is32Bit { get; set; }

        public String ExePath { get; set; }

        public String BitDashDisplayName
        {
            get { 
                if (Is32Bit)
                {
                    return "32bit - " + DisplayName;
                }
                else
                {
                    return "64bit - " + DisplayName;
                }            
            }
        }

        public BlueGuest CloneMe()
        {
            BlueGuest Guest = new BlueGuest();
            Guest.ExePath = ExePath;
            Guest.Is32Bit = Is32Bit;
            Guest.WindowTitle = WindowTitle;
            Guest.KeyName = KeyName;
            Guest.DisplayName = DisplayName;
            return Guest;
        }
    }
}
