//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;

namespace AppTestStudio
{

    public class KeyboardCommand
    {
        public uint ScanCode { get; set; }
        public KeyboardButtonStates ButtonState { get; set; }

        public int Delayms { get; set; }

        public KeyboardCommand(Boolean IsError)
        {
            ButtonState = KeyboardButtonStates.Error;
        }

        public KeyboardCommand(String Command)
        {
            ButtonState = KeyboardButtonStates.Normal;
            switch (Command.ToLower())
            {
                case Definitions.VirtualKeyCodeText.VK_F1:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F1, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F2:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F2, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F3:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F3, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F4:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F4, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F5:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F5, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F6:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F6, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F7:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F7, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F8:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F8, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F9:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F9, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F10:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F10, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F11:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F11, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F12:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F12, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_RETURN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RETURN, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_BACK:
                case Definitions.VirtualKeyCodeText.VK_BACKSPACE:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_TAB:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_TAB, 0);
                    break;

                case Definitions.VirtualKeyCodeText.VK_LEFT:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LEFT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_UP, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_RIGHT:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RIGHT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_DOWN, 0);
                    break;

                case Definitions.VirtualKeyCodeText.VK_PRIOR:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_PRIOR, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_NEXT:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_NEXT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_END:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_END, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_HOME:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_HOME, 0);
                    break;

                case Definitions.VirtualKeyCodeText.VK_NUMLOCK:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_NUMLOCK, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_SCROLL:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_SCROLL, 0);
                    break;

                // LSHIFT
                case Definitions.VirtualKeyCodeText.VK_LSHIFT:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LSHIFT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_LSHIFT_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LSHIFT, 0);
                    ButtonState = KeyboardButtonStates.Down;
                    break;
                case Definitions.VirtualKeyCodeText.VK_LSHIFT_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LSHIFT, 0);
                    ButtonState = KeyboardButtonStates.Up;
                    break;

                // RSHIFT
                case Definitions.VirtualKeyCodeText.VK_RSHIFT:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RSHIFT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_RSHIFT_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RSHIFT, 0);
                    ButtonState = KeyboardButtonStates.Down;
                    break;
                case Definitions.VirtualKeyCodeText.VK_RSHIFT_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RSHIFT, 0);
                    ButtonState = KeyboardButtonStates.Up;
                    break;

                //LCONTROL
                case Definitions.VirtualKeyCodeText.VK_LCONTROL:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LCONTROL, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_LCONTROL_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LCONTROL, 0);
                    ButtonState = KeyboardButtonStates.Down;
                    break;
                case Definitions.VirtualKeyCodeText.VK_LCONTROL_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LCONTROL, 0);
                    ButtonState = KeyboardButtonStates.Up;
                    break;

                // RCONTROL
                case Definitions.VirtualKeyCodeText.VK_RCONTROL:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RCONTROL, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_RCONTROL_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RCONTROL, 0);
                    ButtonState = KeyboardButtonStates.Down;
                    break;
                case Definitions.VirtualKeyCodeText.VK_RCONTROL_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RCONTROL, 0);
                    ButtonState = KeyboardButtonStates.Up;
                    break;

                // LMENU
                case Definitions.VirtualKeyCodeText.VK_LMENU:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LMENU, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_LMENU_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LMENU, 0);
                    ButtonState = KeyboardButtonStates.Down;
                    break;
                case Definitions.VirtualKeyCodeText.VK_LMENU_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LMENU, 0);
                    ButtonState = KeyboardButtonStates.Up;
                    break;

                // RMENU
                case Definitions.VirtualKeyCodeText.VK_RMENU:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RMENU, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_RMENU_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RMENU, 0);
                    ButtonState = KeyboardButtonStates.Down;
                    break;
                case Definitions.VirtualKeyCodeText.VK_RMENU_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RMENU, 0);
                    ButtonState = KeyboardButtonStates.Up;
                    break;

                case Definitions.VirtualKeyCodeText.VK_ESCAPE:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_ESCAPE, 0);
                    break;

                // RWIN
                case Definitions.VirtualKeyCodeText.VK_RWIN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RWIN, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_RWIN_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RWIN, 0);
                    ButtonState = KeyboardButtonStates.Down;
                    break;
                case Definitions.VirtualKeyCodeText.VK_RWIN_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RWIN, 0);
                    ButtonState = KeyboardButtonStates.Up;
                    break;

                // LWIN
                case Definitions.VirtualKeyCodeText.VK_LWIN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LWIN, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_LWIN_DOWN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LWIN, 0);
                    ButtonState = KeyboardButtonStates.Down;
                    break;
                case Definitions.VirtualKeyCodeText.VK_LWIN_UP:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LWIN, 0);
                    ButtonState = KeyboardButtonStates.Up;
                    break;

                case Definitions.VirtualKeyCodeText.VK_INSERT:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_INSERT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_DELETE:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_DELETE, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_CAPITAL:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_CAPITAL, 0);
                    break;


                default:
                    if (Command.Length > 0)
                    {
                        Debug.WriteLine($"KeyboardCommand = {Command}");
                        ButtonState = KeyboardButtonStates.Error;
                    }
                    //ScanCode = (ushort)API.MapVirtualKey((uint)API.VkKeyScan(Command.ToCharArray()[0]), (uint)0);
                    break;
            }
            Debug.WriteLine(ScanCode);
        }

        public KeyboardCommand(char Command)
        {
            ButtonState = KeyboardButtonStates.Normal;
            Command = Char.ToLower(Command);
            switch (Command)
            {
                case '~':
                    ScanCode = (ushort)API.MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_3, 0);
                    break;
                default:
                    ScanCode = (ushort)API.MapVirtualKey((uint)API.VkKeyScan(Command), 0);
                    break;
            }

            if (ScanCode==0)
            {
                ButtonState = KeyboardButtonStates.Error;
            }
            Debug.WriteLine(ScanCode);
        }
    }
}
