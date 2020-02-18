﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        public NoxRegistry()
        {
            ExePath = "";
            WorkingDirectory = "";
            String ReadValue = Registry.GetValue(@"HKEY_CLASSES_ROOT\Nox\shell\open\command", null, "").ToString();

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
    }
}