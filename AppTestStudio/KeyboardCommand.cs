//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System.Diagnostics;
using static AppTestStudio.NativeMethods;

namespace AppTestStudio
{

    public class KeyboardCommand : ICloneable
    {
        public ushort ScanCode { get; set; }
        public KeyboardButtonStates ButtonState { get; set; }

        public int Delayms { get; set; }

        public String Origin { get; set; }

        public int MaxRNG { get; set; }

        public DateTime ExecutionTime { get; set; }

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
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F1, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F2:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F2, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F3:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F3, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F4:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F4, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F5:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F5, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F6:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F6, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F7:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F7, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F8:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F8, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F9:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F9, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F10:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F10, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F11:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F11, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_F12:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F12, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_RETURN:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_RETURN, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_BACK:
                case Definitions.VirtualKeyCodeText.VK_BACKSPACE:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_TAB:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_TAB, 0);
                    break;

                case Definitions.VirtualKeyCodeText.VK_LEFT:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_LEFT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_UP:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_UP, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_RIGHT:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_RIGHT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_DOWN:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_DOWN, 0);
                    break;

                case Definitions.VirtualKeyCodeText.VK_PRIOR:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_PRIOR, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_NEXT:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_NEXT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_END:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_END, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_HOME:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_HOME, 0);
                    break;

                case Definitions.VirtualKeyCodeText.VK_NUMLOCK:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_NUMLOCK, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_SCROLL:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_SCROLL, 0);
                    break;

                // LSHIFT
                case Definitions.VirtualKeyCodeText.VK_LSHIFT:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_LSHIFT, 0);
                    break;

                // RSHIFT
                case Definitions.VirtualKeyCodeText.VK_RSHIFT:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_RSHIFT, 0);
                    break;

                //LCONTROL
                case Definitions.VirtualKeyCodeText.VK_LCONTROL:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_LCONTROL, 0);
                    break;

                // RCONTROL
                case Definitions.VirtualKeyCodeText.VK_RCONTROL:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_RCONTROL, 0);
                    break;


                // LMENU
                case Definitions.VirtualKeyCodeText.VK_LMENU:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_LMENU, 0);
                    break;


                // RMENU
                case Definitions.VirtualKeyCodeText.VK_RMENU:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_RMENU, 0);
                    break;


                case Definitions.VirtualKeyCodeText.VK_ESCAPE:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_ESCAPE, 0);
                    break;

                // RWIN
                case Definitions.VirtualKeyCodeText.VK_RWIN:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_RWIN, 0);
                    break;

                // LWIN
                case Definitions.VirtualKeyCodeText.VK_LWIN:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_LWIN, 0);
                    break;

                case Definitions.VirtualKeyCodeText.VK_INSERT:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_INSERT, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_DELETE:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_DELETE, 0);
                    break;
                case Definitions.VirtualKeyCodeText.VK_CAPITAL:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_CAPITAL, 0);
                    break;

                // Custom
                case Definitions.VirtualKeyCodeText.VK_SPACE:
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_SPACE, 0);
                    break;
                case "a":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_A, 0);
                    break;
                case "b":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_B, 0);
                    break;
                case "c":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_C, 0);
                    break;
                case "d":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_D, 0);
                    break;
                case "e":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_E, 0);
                    break;

                case "f":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_F, 0);
                    break;
                case "g":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_G, 0);
                    break;
                case "h":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_H, 0);
                    break;
                case "i":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_I, 0);
                    break;
                case "j":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_J, 0);
                    break;
                case "k":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_K, 0);
                    break;
                case "l":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_L, 0);
                    break;
                case "m":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_M, 0);
                    break;
                case "n":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_N, 0);
                    break;
                case "o":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_O, 0);
                    break;
                case "p":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_P, 0);
                    break;
                case "q":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_Q, 0);
                    break;
                case "r":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_R, 0);
                    break;
                case "s":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_S, 0);
                    break;
                case "t":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_T, 0);
                    break;
                case "u":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_U, 0);
                    break;
                case "v":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_V, 0);
                    break;
                case "w":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_W, 0);
                    break;
                case "x":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_X, 0);
                    break;
                case "y":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_Y, 0);
                    break;
                case "z":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_Z, 0);
                    break;

                case "`":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK_QUOTE, 0);
                    break;
                case "~":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK_QUOTE, 0);
                    break;
                case "-":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_SUBTRACT, 0);
                    break;
                case "+":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_PLUS, 0);
                    break;
                case "[":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_OPEN_BRACKET, 0);
                    break;
                case "]":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_CLOSE_BRACKET, 0);
                    break;
                case "\\":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK_SLASH, 0);
                    break;
                case ":":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_COLON, 0);
                    break;
                case ";":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_COLON, 0);
                    break;
                case "'":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_QUOTE, 0);
                    break;
                case ",":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_COMMA, 0);
                    break;
                case ".":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_PERIOD, 0);
                    break;
                case "/":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_SLASH, 0);
                    break;
                case "=":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_OEM_PLUS, 0);
                    break;
                case "0":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_0, 0);
                    break;
                case "1":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_1, 0);
                    break;
                case "2":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_2, 0);
                    break;
                case "3":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_3, 0);
                    break;
                case "4":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_4, 0);
                    break;
                case "5":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_5, 0);
                    break;
                case "6":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_6, 0);
                    break;
                case "7":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_7, 0);
                    break;
                case "8":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_8, 0);
                    break;
                case "9":
                    ScanCode = MapVirtualKey(Definitions.VirtualKeyCode.VK_9, 0);
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
                    ScanCode = (ushort)MapVirtualKey(Definitions.VirtualKeyCode.VK_BACK_QUOTE, 0);
                    break;
                default:
                    ScanCode = (ushort)MapVirtualKey((uint)VkKeyScan(Command), 0);
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

        object ICloneable.Clone()
        {
            KeyboardCommand command = (KeyboardCommand)this.MemberwiseClone();

            return command;
        }

        public String PrintScanCode()
        {
            switch (ScanCode)
            {
                case 0x39:
                    return "Space";
                case 0x1C:
                    return "Enter";
                case 0x0E:
                    return "Backspace";
                case 0x0F:
                    return "Tab";
                case 0x01:
                    return "Esc";
                case 0x2A:
                    return "LShift";
                case 0x36:
                    return "RShift";
                case 0x1D:
                    return "LControl";
                case 0x9D:
                    return "RControl";
                case 0x38:
                    return "LAlt";
                case 0xB8:
                    return "RAlt";
                case 0x3A:
                    return "CapsLock";
                case 0x52:
                    return "Insert";
                case 0x53:
                    return "Delete";
                case 0x47:
                    return "Home";
                case 0x4F:
                    return "End";
                case 0x49:
                    return "PageUp";
                    case 0x51:
                        return "PageDown";
                    case 0x4B:
                        return "LeftArrow";
                    case 0x48:
                        return "UpArrow";
                    case 0x4D:
                        return "RightArrow";
                    case 0x50:
                        return "DownArrow";
                    case 0x3B:
                        return "F1";
                    case 0x3C:
                        return "F2";
                    case 0x3D:
                        return "F3";
                    case 0x3E:
                        return "F4";
                    case 0x3F:
                        return "F5";
                    case 0x40:
                        return "F6";
                    case 0x41:
                        return "F7";
                    case 0x42:
                        return "F8";
                    case 0x43:
                        return "F9";
                    case 0x44:
                        return "F10";
                    case 0x57:
                        return "F11";
                    case 0x58:
                        return "F12";
                    case 0x45:
                        return "NumLock";
                    case 0x46:
                        return "ScrollLock";
                    case 0xE05B:
                        return "LWin";
                    case 0xE05C:
                        return "RWin";
                    case 0x0C:
                        return "-";
                    case 0x0D:
                        return "=";
                    case 0x1A:
                        return "[";
                    case 0x1B:
                        return "]";
                    case 0x2B:
                        return "\\";
                    case 0x27:
                        return ";";
                    case 0x28:
                        return "'";
                    case 0x33:
                        return ",";
                    case 0x34:
                        return ".";
                    case 0x35:
                        return "/";
                    case 0x29:
                        return "`";
                    case 0x0B:
                        return "0";
                    case 0x02:
                        return "1";
                    case 0x03:
                        return "2";
                    case 0x04:
                        return "3";
                    case 0x05:
                        return "4";
                    case 0x06:
                        return "5";
                    case 0x07:
                        return "6";
                    case 0x08:
                        return "7";
                    case 0x09:
                        return "8";
                    case 0x0A:
                        return "9";
                    case 0x10:
                        return "q";
                    case 0x11:
                        return "w";
                    case 0x12:
                        return "e";
                    case 0x13:
                        return "r";
                    case 0x14:
                        return "t";
                    case 0x15:
                        return "y";
                    case 0x16:
                        return "u";
                    case 0x17:
                        return "i";
                    case 0x18:
                        return "o";
                    case 0x19:
                        return "p";
                    case 0x1E:
                        return "a";
                    case 0x1F:
                        return "s";
                    case 0x20:
                        return "d";
                    case 0x21:
                        return "f";
                    case 0x22:
                        return "g";
                    case 0x23:
                        return "h";
                    case 0x24:
                        return "j";
                    case 0x25:
                        return "k";
                    case 0x26:
                        return "l";
                    case 0x2C:
                        return "z";
                    case 0x2D:
                        return "x";
                    case 0x2E:
                        return "c";
                    case 0x2F:
                        return "v";
                    case 0x30:
                        return "b";
                    case 0x31:
                        return "n";
                    case 0x32:
                        return "m";
                default:
                    return $"Not Defined {ScanCode}";
            }
            return $"ScanCode: {ScanCode}";
        }
    }
}
