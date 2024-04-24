//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static AppTestStudio.Definitions;

namespace AppTestStudio
{
    public class KeyboardProcessor
    {
        /// <summary>
        /// Serially reads a script and checks for begin and end {}'s to determine special keys.
        /// </summary>
        /// <param name="Script"></param>
        /// <param name="Speedms"></param>
        /// <returns></returns>
        public List<KeyboardCommand> ParseScript(String Script)
        {
            List<KeyboardCommand> list = new List<KeyboardCommand>();
            Boolean InCommand = false;
            String Command = "";
            foreach (char c in Script)
            {
                if (c == '{')
                {
                    // A command start inside a command start is a [r
                    if(InCommand)
                    {
                        // This should be be here.
                        Debug.WriteLine($"Error parsing found unexpected command [{Command}] check {{'s'");
                    }
                    Command = "";
                    InCommand = true;
                }

                if (c == '}')
                {
                    if (InCommand == false)
                    {
                        Debug.WriteLine("Keyboard Processing found } without beginning {");
                    }
                    else
                    {
                        list.Add(new KeyboardCommand(Command));
                    }
                    InCommand = false;
                    Command = "";
                }

                if (c == '}' || c == '{')
                {
                    // Do nothing
                }
                else
                {
                    if (InCommand)
                    {
                        Command = Command + c;
                    }
                    else
                    {
                        list.Add(new KeyboardCommand(c));
                    }
                }
            }

            // Should not be in a command at this point.
            if (InCommand)
            {
                KeyboardCommand Error = new KeyboardCommand(Command);
                Error.ButtonState = KeyboardButtonStates.Error;
                list.Add(Error);
            }

            if (Command.Length > 0)
            {
                Debug.WriteLine($"Error parsing found unexpected command {Command}");
            }
            return list;
        }
  
    }
}
