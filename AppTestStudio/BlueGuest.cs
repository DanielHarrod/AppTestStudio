using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public class BlueGuest
    {
        // Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Guests
        public String KeyName { get; set; }

        // Key0 is always BlueStacks
        // Key[1*] Computer\HKEY_LOCAL_MACHINE\SOFTWARE\BlueStacks_bgp64\Guests\Key[1+]\Config\DisplayName
        public String WindowTitle { get; set; }

        public Boolean Is32Bit { get; set; }

        public String ExePath { get; set; }
    }
}
