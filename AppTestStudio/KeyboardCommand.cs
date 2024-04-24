//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;

namespace AppTestStudio
{

    public class KeyboardCommand
    {
        public ushort ScanCode { get; set; }
        public KeyboardButtonStates ButtonState { get; set; }

        public int Delayms { get; set; }

        public String Origin { get; set; }

        public int MaxRNG { get; set; }

        public KeyboardCommand(ushort ScanCode, KeyboardButtonStates ButtonState, int Delayms, String Origin, int MaxRNG)
        {
            this.ScanCode = ScanCode;
            this.ButtonState = ButtonState;
            this.Delayms = Delayms;
            this.Origin = Origin;
            this.MaxRNG = MaxRNG;
        }

        public KeyboardCommand(Boolean IsError)
        {
            ButtonState = KeyboardButtonStates.Error;
        }

        public KeyboardCommand(String Command)
        {
            Origin = Command;
            ButtonState = KeyboardButtonStates.Normal;
            String KeyCommand = Command.ToLower();

            if (KeyCommand.StartsWith("wait."))
            {
                ButtonState = KeyboardButtonStates.Delay;
                String PotentiallyInt = KeyCommand.Substring(5, KeyCommand.Length - 5);
                int delay = 0;

                if (int.TryParse(PotentiallyInt, out delay))
                {
                    Delayms = delay;
                    return;
                }
                else
                {
                    Debug.WriteLine($"Keyboard wait. Expected integer found {PotentiallyInt}");
                    ButtonState = KeyboardButtonStates.Error;
                    return;
                }
            }
            if (KeyCommand.EndsWith("up"))
            {
                ButtonState = KeyboardButtonStates.Up;
                KeyCommand = KeyCommand.Substring(0,KeyCommand.Length - 2);
            }

            if (KeyCommand.EndsWith("down"))
            {
                ButtonState = KeyboardButtonStates.Down;
                KeyCommand = KeyCommand.Substring(0,KeyCommand.Length - 4);
            }

            switch (KeyCommand)
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

                // RSHIFT
                case Definitions.VirtualKeyCodeText.VK_RSHIFT:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RSHIFT, 0);
                    break;

                //LCONTROL
                case Definitions.VirtualKeyCodeText.VK_LCONTROL:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LCONTROL, 0);
                    break;

                // RCONTROL
                case Definitions.VirtualKeyCodeText.VK_RCONTROL:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RCONTROL, 0);
                    break;


                // LMENU
                case Definitions.VirtualKeyCodeText.VK_LMENU:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LMENU, 0);
                    break;


                // RMENU
                case Definitions.VirtualKeyCodeText.VK_RMENU:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RMENU, 0);
                    break;


                case Definitions.VirtualKeyCodeText.VK_ESCAPE:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_ESCAPE, 0);
                    break;

                // RWIN
                case Definitions.VirtualKeyCodeText.VK_RWIN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_RWIN, 0);
                    break;

                // LWIN
                case Definitions.VirtualKeyCodeText.VK_LWIN:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_LWIN, 0);
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

                // Custom
                case Definitions.VirtualKeyCodeText.VK_SPACE:
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_SPACE, 0);
                    break;
                case "a":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_A, 0);
                    break;
                case "b":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_B, 0);
                    break;
                case "c":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_C, 0);
                    break;
                case "d":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_D, 0);
                    break;
                case "e":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_E, 0);
                    break;

                case "f":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_F, 0);
                    break;
                case "g":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_G, 0);
                    break;
                case "h":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_H, 0);
                    break;
                case "i":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_I, 0);
                    break;
                case "j":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_J, 0);
                    break;
                case "k":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_K, 0);
                    break;
                case "l":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_L, 0);
                    break;
                case "m":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_M, 0);
                    break;
                case "n":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_N, 0);
                    break;
                case "o":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_O, 0);
                    break;
                case "p":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_P, 0);
                    break;
                case "q":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_Q, 0);
                    break;
                case "r":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_R, 0);
                    break;
                case "s":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_S, 0);
                    break;
                case "t":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_T, 0);
                    break;
                case "u":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_U, 0);
                    break;
                case "v":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_V, 0);
                    break;
                case "w":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_W, 0);
                    break;
                case "x":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_X, 0);
                    break;
                case "y":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_Y, 0);
                    break;
                case "z":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_Z, 0);
                    break;

                case "`":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK_QUOTE, 0);
                    break;
                case "~":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK_QUOTE, 0);
                    break;
                case "-":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_SUBTRACT, 0);
                    break;
                case "+":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_PLUS, 0);
                    break;
                case "[":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_OPEN_BRACKET, 0);
                    break;
                case "]":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_CLOSE_BRACKET, 0);
                    break;
                case "\\":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK_SLASH, 0);
                    break;
                case ":":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_COLON, 0);
                    break;
                case ";":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_COLON, 0);
                    break;
                case "'":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_QUOTE, 0);
                    break;
                case ",":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_COMMA, 0);
                    break;
                case ".":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_PERIOD, 0);
                    break;
                case "/":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_SLASH, 0);
                    break;
                case "=":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_PLUS, 0);
                    break;
                case "0":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_0, 0);
                    break;
                case "1":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_1, 0);
                    break;
                case "2":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_2, 0);
                    break;
                case "3":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_3, 0);
                    break;
                case "4":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_4, 0);
                    break;
                case "5":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_5, 0);
                    break;
                case "6":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_6, 0);
                    break;
                case "7":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_7, 0);
                    break;
                case "8":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_8, 0);
                    break;
                case "9":
                    ScanCode = API.MapVirtualKey(Definitions.VirtualKeyCode.VK_9, 0);
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
            Origin = Command.ToString();
            ButtonState = KeyboardButtonStates.Normal;
            Command = Char.ToLower(Command);
            switch (Command)
            {
                case '~':
                    ScanCode = (ushort)API.MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK_QUOTE, 0);
                    break;
                default:
                    ScanCode = (ushort)API.MapVirtualKey((uint)API.VkKeyScan(Command), 0);
                    break;
            }

            if (ScanCode == 0)
            {
                ButtonState = KeyboardButtonStates.Error;
            }
            Debug.WriteLine(ScanCode);
        }

        public KeyboardCommand Clone()
        {
            return new KeyboardCommand(ScanCode, ButtonState, Delayms, Origin, MaxRNG);
        }
        public override string ToString()
        {
            return $"Origin: {Origin}, State: {ButtonState.ToString()}, Delay ms: {Delayms}/{MaxRNG}, ScanCode: {ScanCode}";
        }
    }
}
