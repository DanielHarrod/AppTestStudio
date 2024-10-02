//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using static AppTestStudio.API;
using static AppTestStudio.Definitions;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestKeyboard
    {
        [TestMethod]
        public void TestKeyboardSendingMessageToNotepadV1()
        {
            ThreadManager threadManger = new ThreadManager();
            GameNodeGame game = new GameNodeGame("Testing",threadManger);
            game.Platform = Platform.Application;
            game.ApplicationPrimaryWindowName = "*Untitled - Notepad";
            IntPtr hWnd = AppTestStudio.Utils.GetWindowHandleByWindowName(game);
            if (hWnd.Equals(IntPtr.Zero))
            {
                // Fail
            }
            else
            {   //a
                //001E0001
                //000000065432109876543210
                //000111100000000000000001
                //0100 0000 0001 1110 0000 0000 0000 0001

                //0100 0000 0000 0000 0000 0000 0000 0000 - Previous Key State
                int repeatcount = 0x1;
                int previousStateTrue = 0x40000000;
                int previousStateFalse = 0x0;
                IntPtr lparam = new IntPtr(previousStateFalse | repeatcount | ScanCodes.SK_A);
                Debug.WriteLine(AppTestStudio.Utils.ActivateWindowIfNecessary((IntPtr)0xCF0696, WindowAction.ActivateWindow, 20, 20));
                AppTestStudio.API.SendMessage(hWnd, KeyboardStates.WM_KEYDOWN, VirtualKeyCode.VK_A, lparam);
                AppTestStudio.API.SendMessage(hWnd, KeyboardStates.WM_CHAR,0x61, lparam);
                AppTestStudio.API.SendMessage(hWnd, KeyboardStates.WM_KEYUP, VirtualKeyCode.VK_A, lparam);
            }
        }

        [TestMethod]
        public void TestKeyboardSendingMessageToNotepadV2()
        {
            ThreadManager threadManger = new ThreadManager();
            GameNodeGame game = new GameNodeGame("Testing", threadManger);
            game.Platform = Platform.Application;
            game.ApplicationPrimaryWindowName = "*Untitled - Notepad";
            IntPtr hWnd = AppTestStudio.Utils.GetWindowHandleByWindowName(game);
            if (hWnd.Equals(IntPtr.Zero))
            {
                Debug.WriteLine($"Unable to locate {game.ApplicationPrimaryWindowName}");
            }
            else
            {
                int INPUT_KEYBOARD = 1;
                uint KEYEVENTF_KEYUP = 0x0002;
                //a
                Input[] inputs = new Input[4];
                inputs[0].Type = INPUT_KEYBOARD;
                inputs[0].u.KeyboardInput.VirtualKeyCode = VirtualKeyCode.VK_D;

                inputs[1].Type = INPUT_KEYBOARD;
                inputs[1].u.KeyboardInput.VirtualKeyCode = VirtualKeyCode.VK_D;
                inputs[1].u.KeyboardInput.Flags = KEYEVENTF_KEYUP;

                inputs[2].Type = INPUT_KEYBOARD;
                inputs[2].u.KeyboardInput.VirtualKeyCode = VirtualKeyCode.VK_A;

                inputs[3].Type = INPUT_KEYBOARD;
                inputs[3].u.KeyboardInput.VirtualKeyCode = VirtualKeyCode.VK_A;
                inputs[3].u.KeyboardInput.Flags = KEYEVENTF_KEYUP;

                IntPtr root = API.GetAncestor(hWnd, GetAncestorFlags.GetRoot);
                bool Worked = API.SetForegroundWindow(root);

                Debug.WriteLine($"Worked={Worked}");

                Worked = API.SetForegroundWindow(hWnd);

                Debug.WriteLine($"Worked={Worked}");

                uint uSent = SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
            }
        }

        int INPUT_KEYBOARD = 1;
        uint KEYEVENTF_SCANCODE = 0x0008;
        uint KEYEVENTF_KEYUP = 0x0002;

        [TestMethod]
        public void TestKeyboardToSkyrim()
        {
            ThreadManager threadManger = new ThreadManager();
            GameNodeGame game = new GameNodeGame("Testing", threadManger);
            game.Platform = Platform.Application;
            game.ApplicationPrimaryWindowName = "Skyrim Special Edition";
            IntPtr hWnd = AppTestStudio.Utils.GetWindowHandleByWindowName(game);
            if (hWnd.Equals(IntPtr.Zero))
            {
                Debug.WriteLine($"Unable to locate {game.ApplicationPrimaryWindowName}");
            }
            else
            {

                //a
                Input[] inputs = new Input[4];
                inputs[0].Type = INPUT_KEYBOARD;
                inputs[0].u.KeyboardInput.Flags = 0;

                IntPtr root = API.GetAncestor(hWnd, GetAncestorFlags.GetRoot);
                bool Worked = API.SetForegroundWindow(root);

                Debug.WriteLine($"Worked={Worked}");

                Worked = API.SetForegroundWindow(hWnd);

                Debug.WriteLine($"Worked={Worked}");
                for (int i = 0; i < 10; i++)
                {
                    uint uxSent = SendInput(1, inputs, Marshal.SizeOf(typeof(Input)));
                    Thread.Sleep(50);
                }

                inputs[0].u.KeyboardInput.Flags = KEYEVENTF_KEYUP;
                inputs[0].u.KeyboardInput.Time = 500;
                uint uSent = SendInput(1, inputs, Marshal.SizeOf(typeof(Input)));

            }
        }

        [TestMethod]
        public void TestKeyboardToSkyrim2()
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 5; i++)
            {
                SendKeys('w',500);
            }
  
        }

        void SendKeys(char key, int delay)
        {
            Input[] inputs = new Input[1];
            inputs[0].Type = INPUT_KEYBOARD;
            inputs[0].u.KeyboardInput.Flags = KEYEVENTF_SCANCODE;
            inputs[0].u.KeyboardInput.ScanCode = (ushort)API.MapVirtualKey((uint)VkKeyScan(key),(uint) 0);
            uint uSent = SendInput(1, inputs, Marshal.SizeOf(typeof(Input)));
            Thread.Sleep(delay); ;
            inputs[0].u.KeyboardInput.Flags = KEYEVENTF_KEYUP | KEYEVENTF_SCANCODE;
            SendInput(1,inputs, Marshal.SizeOf(typeof(Input)));

        }

        [TestMethod]
        public void ScanKeyTest()
        {
            // 87
            Debug.WriteLine(VkKeyScan('w'));

        }

    }
}
