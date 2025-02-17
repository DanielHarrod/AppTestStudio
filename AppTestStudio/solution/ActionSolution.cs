//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

namespace AppTestStudio.solution
{
    internal class ActionSolution : ISolution
    {
        public ActionSolution()
        {
            EventType = SolutionType.Action;
            Messages = new List<MouseSolutionMessage>();
            ATSInputs = new List<ATSInput>();
        }

        // Target Window Handle
        public nint WindowHandle { get; set; }

        // PostMessages (Passive)
        public List<MouseSolutionMessage> Messages { get; set; }

        // Send Input (Active)
        public List<ATSInput> ATSInputs { get; set; }

        // Keyboard Commands
        public List<KeyboardCommand> KeyboardCommands { get; set; }

        // Final Mouse Position.
        public int TargetX { get; set; }
        public int TargetY { get; set; }

        // Do we activate before playing the script.
        public bool ActivateWindow { get; set; }

        public Bitmap Bitmap { get; set; }

        internal void AddMessage(nint windowHandle, int msg, int wParam, int lParam, int afterDelay = 0)
        {
            MouseSolutionMessage message = new MouseSolutionMessage();
            message.WindowHandle = windowHandle;
            message.Message = msg;
            message.wParam = wParam;
            message.lParam = lParam;
            message.AfterDelay = afterDelay;
            Messages.Add(message);
        }

        internal void AddInput(int Type, int X, int Y, uint MouseData, uint Flags, int afterDelay = 0)
        {
            ATSInput atsInput = new ATSInput();

            atsInput.Type = Type;
            atsInput.X = X;
            atsInput.Y = Y;
            atsInput.MouseData = MouseData;
            atsInput.Flags = Flags;

            atsInput.AfterDelay = afterDelay;

            ATSInputs.Add(atsInput);
        }

        public int RuntimeMS
        {
            get
            {
                int runtimeMS = 0;
                foreach (MouseSolutionMessage message in Messages)
                {
                    runtimeMS += message.AfterDelay;
                }

                foreach (ATSInput input in ATSInputs)
                {
                    runtimeMS += input.AfterDelay;
                }
                return runtimeMS;
            }
        }

        public void AddKeyboardCommands(List<KeyboardCommand> lst)
        {
            KeyboardCommands = new List<KeyboardCommand>(lst);
        }
    }

    internal class ATSInput
    {
        public ATSInput()
        {
            AfterDelay = 0;
        }
        public int Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public uint MouseData { get; set; }
        public uint Flags { get; set; }
        public int AfterDelay { get; set; }
    }
}
