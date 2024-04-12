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
        public void ParseScriptV1Old(String Script, int Speedms)
        {

            string[] Keys = Script.Split('}');
            foreach (String key in Keys)
            {
                if (key.Contains('{'))
                {
                    Debug.WriteLine(key);
                    String[] L1 = key.Split('{');
                    foreach (String L1Value in L1)
                    {
                        KeyboardCommand command = new KeyboardCommand(L1Value);
                        Debug.WriteLine(L1Value);
                    }

                    Debug.WriteLine("/" + key);
                }
                else
                {

                    Debug.WriteLine(key);
                    foreach (char c in key)
                    {
                        KeyboardCommand command2 = new KeyboardCommand(c);
                    }
                    Debug.WriteLine("/" + key);
                }
            }
        }


        /// <summary>
        /// This looks at the KeyboardCommand input in list(parameter 1), this list is the high level steps to press the keys as a user would enter them.
        /// This function converts the user input into what's needed to process the keystrokes at the background/system level.
        /// It also assigns Delay ms to each command, input down events such as [Ctrl Down + a] treats the Ctrl and a key as done in the same time.
        /// Assigns appropriate ActionNode KeyboardBetween Duration and Key Down durations.
        /// </summary>
        /// <param name="list">(Input) User level Keyboard Commands</param>
        /// <param name="ActionNode">(Input) Used to capture setting.</param>
        /// <param name="CompletePlayList">(Output) Sequence of keystrokes at the system level.</param>
        public List<KeyboardCommand> SequenceAndApplyPreWaits(KeyboardCommand[] list, GameNodeAction ActionNode)
        {
            List<KeyboardCommand> CompletePlayList = new List<KeyboardCommand>();
            KeyboardButtonStates LastState = KeyboardButtonStates.None;

            if (ActionNode.KeyboardLeftAlt)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand LeftAltCommand = new KeyboardCommand(VirtualKeyCodeText.VK_LMENU_DOWN);
                LeftAltCommand.ButtonState = KeyboardButtonStates.Down;
                CompletePlayList.Add(LeftAltCommand);
            }

            if (ActionNode.KeyboardLeftCtrl)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand LeftCtrlCommand = new KeyboardCommand(VirtualKeyCodeText.VK_LCONTROL_DOWN);
                LeftCtrlCommand.ButtonState = KeyboardButtonStates.Down;
                CompletePlayList.Add(LeftCtrlCommand);
            }

            if (ActionNode.KeyboardLeftShift)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand LeftShiftCommand = new KeyboardCommand(VirtualKeyCodeText.VK_LSHIFT_DOWN);
                LeftShiftCommand.ButtonState = KeyboardButtonStates.Down;
                CompletePlayList.Add(LeftShiftCommand);
            }

            if (ActionNode.KeyboardLeftWin)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand LeftWinCommand = new KeyboardCommand(VirtualKeyCodeText.VK_LWIN_DOWN);
                LeftWinCommand.ButtonState = KeyboardButtonStates.Down;
                CompletePlayList.Add(LeftWinCommand);
            }

            if (ActionNode.KeyboardRightAlt)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand RightAltCommand = new KeyboardCommand(VirtualKeyCodeText.VK_RMENU_DOWN);
                RightAltCommand.ButtonState = KeyboardButtonStates.Down;
                CompletePlayList.Add(RightAltCommand);
            }

            if (ActionNode.KeyboardRightCtrl)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand RightCtrlCommand = new KeyboardCommand(VirtualKeyCodeText.VK_RCONTROL_DOWN);
                RightCtrlCommand.ButtonState = KeyboardButtonStates.Down;
                CompletePlayList.Add(RightCtrlCommand);
            }

            if (ActionNode.KeyboardRightShift)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand RightShiftCommand = new KeyboardCommand(VirtualKeyCodeText.VK_RSHIFT_DOWN);
                RightShiftCommand.ButtonState = KeyboardButtonStates.Down;
                CompletePlayList.Add(RightShiftCommand);
            }

            if (ActionNode.KeyboardRightWin)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand RightWinCommand = new KeyboardCommand(VirtualKeyCodeText.VK_RWIN_DOWN);
                RightWinCommand.ButtonState = KeyboardButtonStates.Down;
                CompletePlayList.Add(RightWinCommand);
            }

            for (int i = 0; i < list.Length; i++)
            {
                KeyboardCommand CurrentCommand = list[i];
                switch (CurrentCommand.ButtonState)
                {
                    case KeyboardButtonStates.Normal:
                        KeyboardCommand NormalStart = CurrentCommand.Clone();
                        NormalStart.ButtonState = KeyboardButtonStates.Down;
                        if (i > 0)
                        {
                            // Explicit down + next key has no delay.
                            if (LastState == KeyboardButtonStates.Down)
                            {
                                NormalStart.Delayms = 0;
                            }
                            else
                            {
                                NormalStart.Delayms = ActionNode.KeyboardBetweenDuration;
                                NormalStart.MaxRNG = ActionNode.KeyboardBetweenDurationRandom;
                            }
                        }
                        else
                        {
                            // First don't wait.
                            NormalStart.Delayms = 0;
                        }
                        KeyboardCommand NormalEnd = CurrentCommand.Clone();
                        NormalEnd.Delayms = ActionNode.KeyboardDownDuration;
                        NormalEnd.MaxRNG = ActionNode.KeyboardDownDurationRandom;
                        NormalEnd.ButtonState = KeyboardButtonStates.Up;
                        CompletePlayList.Add(NormalStart);
                        CompletePlayList.Add(NormalEnd);
                        break;
                    case KeyboardButtonStates.Down:
                        KeyboardCommand Down = CurrentCommand.Clone();
                        if (LastState == KeyboardButtonStates.Down)
                        {
                            // Explicit down followed by down has no delay.
                            Down.Delayms = 0;
                        }
                        else
                        {
                            Down.Delayms = ActionNode.KeyboardBetweenDuration;
                            Down.MaxRNG = ActionNode.KeyboardBetweenDurationRandom;
                        }

                        CompletePlayList.Add(Down);
                        break;
                    case KeyboardButtonStates.Up:
                        KeyboardCommand Up = CurrentCommand.Clone();
                        Up.Delayms = 0;
                        CompletePlayList.Add(Up);
                        break;
                    case KeyboardButtonStates.Error:
                        KeyboardCommand ErrorState = CurrentCommand.Clone();
                        CompletePlayList.Add(ErrorState);
                        break;
                    default:
                        break;
                }

                LastState = CurrentCommand.ButtonState;
            }

            if (ActionNode.KeyboardLeftAlt)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand LeftAltCommand = new KeyboardCommand(VirtualKeyCodeText.VK_LMENU_UP);
                LeftAltCommand.ButtonState = KeyboardButtonStates.Up;
                CompletePlayList.Add(LeftAltCommand);
            }

            if (ActionNode.KeyboardLeftCtrl)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand LeftCtrlCommand = new KeyboardCommand(VirtualKeyCodeText.VK_LCONTROL_UP);
                LeftCtrlCommand.ButtonState = KeyboardButtonStates.Up;
                CompletePlayList.Add(LeftCtrlCommand);
            }

            if (ActionNode.KeyboardLeftShift)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand LeftShiftCommand = new KeyboardCommand(VirtualKeyCodeText.VK_LSHIFT_UP);
                LeftShiftCommand.ButtonState = KeyboardButtonStates.Up;
                CompletePlayList.Add(LeftShiftCommand);
            }

            if (ActionNode.KeyboardLeftWin)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand LeftWinCommand = new KeyboardCommand(VirtualKeyCodeText.VK_LWIN_UP);
                LeftWinCommand.ButtonState = KeyboardButtonStates.Up;
                CompletePlayList.Add(LeftWinCommand);
            }

            if (ActionNode.KeyboardRightAlt)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand RightAltCommand = new KeyboardCommand(VirtualKeyCodeText.VK_RMENU_UP);
                RightAltCommand.ButtonState = KeyboardButtonStates.Up;
                CompletePlayList.Add(RightAltCommand);
            }

            if (ActionNode.KeyboardRightCtrl)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand RightCtrlCommand = new KeyboardCommand(VirtualKeyCodeText.VK_RCONTROL_UP);
                RightCtrlCommand.ButtonState = KeyboardButtonStates.Up;
                CompletePlayList.Add(RightCtrlCommand);
            }

            if (ActionNode.KeyboardRightShift)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand RightShiftCommand = new KeyboardCommand(VirtualKeyCodeText.VK_RSHIFT_UP);
                RightShiftCommand.ButtonState = KeyboardButtonStates.Up;
                CompletePlayList.Add(RightShiftCommand);
            }

            if (ActionNode.KeyboardRightWin)
            {
                LastState = KeyboardButtonStates.Down;
                KeyboardCommand RightWinCommand = new KeyboardCommand(VirtualKeyCodeText.VK_RWIN_UP);
                RightWinCommand.ButtonState = KeyboardButtonStates.Up;
                CompletePlayList.Add(RightWinCommand);
            }
            return CompletePlayList;
        }
    }
}
