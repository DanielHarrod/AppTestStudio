//AppTestStudio 
//Copyright(C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

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
