//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestKeyboardProcessor
    {
        [TestMethod]
        public void TestBasicWithCommands()
        {
            AppTestStudio.KeyboardProcessor kp = new AppTestStudio.KeyboardProcessor();
            String s = "{Enter}abc{Tab}ghi{Enter}";

            kp.ParseScript(s);
        }

        [TestMethod]
        public void TestWithBadFormattingMissingEnding()
        {
            AppTestStudio.KeyboardProcessor kp = new AppTestStudio.KeyboardProcessor();
            String s = "{Enterabc{Tab}ghi{Enter}";

            kp.ParseScript(s);
        }

        [TestMethod]
        public void TestWithBadFormattingMissingStart()
        {
            AppTestStudio.KeyboardProcessor kp = new AppTestStudio.KeyboardProcessor();
            String s = "Enter}abc{Tab}ghi{Enter}";

            kp.ParseScript(s);
        }

        [TestMethod]
        public void TestWithCoreKeys()
        {
            AppTestStudio.KeyboardProcessor kp = new AppTestStudio.KeyboardProcessor();
            String s = "{ESC}{F1}{F2}{F3}{F4}{F5}{F6}{F7}{F8}{F9}{F10}{F11}{F12}~1234567890-={BACKSPACE}{TAB}qwertyuiop[]\\{CAPS}sadfghjkl;'{ENTER}{LSHIFT}zcvbnm,./{RSHIFT}{LCTRL}{LWIN}{LALT} {RALT}{RWIN}{RCTRL}{INSERT}{DELETE}{HOME}{END}{PGUP}{PGDOWN}{UP}{LEFT}{DOWN}{RIGHT}";

            kp.ParseScript(s);
        }

        [TestMethod]
        public void TestWithStickyKeys()
        {
            AppTestStudio.KeyboardProcessor kp = new AppTestStudio.KeyboardProcessor();
            String s = "{F3}w{LSHIFTDOWN}e{LCTRLDOWN}r{LWINDOWN}t{LALTDOWN}y{LSHIFTUP}i{LCTRLUP}j{LWINUP}b{LALTUP}";

            kp.ParseScript(s);
        }

        [TestMethod]
        public void TestBasicWithCommandsErrorCheck()
        {
            AppTestStudio.KeyboardProcessor kp = new AppTestStudio.KeyboardProcessor();
            String s = "{Enter}abc{Tab}ghi{Enter}";

            List<KeyboardCommand> keyboardCommands = kp.ParseScript(s);

            int index = 0;
            foreach (KeyboardCommand command in keyboardCommands)
            {                
               // Assert.AreNotEqual<uint>(command.ScanCode, 0,$"Scan Code not found at index {index}.");
                Assert.AreNotEqual<KeyboardButtonStates>(command.ButtonState, KeyboardButtonStates.Error);
                index++;
            }
        }


    }
}
