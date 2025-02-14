//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System.Diagnostics;
using System.Runtime.InteropServices;
using static AppTestStudio.NativeMethods;

namespace AppTestStudio
{
    internal static class SolutionPlayer
    {
        public static void Play(MouseSolution solution)
        {
            foreach (SolutionMessage solutionMessage in solution.Messages)
            {
                Debug.WriteLine($"handle={solutionMessage.WindowHandle},wParam={solutionMessage.wParam}");
                PostMessage(solutionMessage.WindowHandle, solutionMessage.Message, solutionMessage.wParam, solutionMessage.lParam);
                if (solutionMessage.AfterDelay > 0)
                {
                    Thread.Sleep(solutionMessage.AfterDelay);
                }
            }

            foreach (ATSInput atsInput in solution.ATSInputs)
            {
                Input input = new Input();
                input.Type = atsInput.Type;
                input.u.MouseInput.X = atsInput.X;
                input.u.MouseInput.Y = atsInput.Y;
                input.u.MouseInput.MouseData = atsInput.MouseData;
                input.u.MouseInput.Flags = atsInput.Flags;

                Input[] inputToSend = { input };
                SendInput((uint)inputToSend.Length, inputToSend, Marshal.SizeOf(typeof(Input)));

                if (atsInput.AfterDelay > 0)
                {
                    Thread.Sleep(atsInput.AfterDelay);
                }
            }
        }
    }
}
