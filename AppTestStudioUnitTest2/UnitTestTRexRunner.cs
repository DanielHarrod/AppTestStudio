using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestTRexRunner
    {
        [TestMethod]
        public void TestMethod1()
        {
            AppTestStudio.KeyboardProcessor kp = new AppTestStudio.KeyboardProcessor();
            String s = " ";

            List<KeyboardCommand> list = kp.ParseScript(s);

            GameNodeAction ActionNode = new GameNodeAction("", ActionType.Action);

            List<KeyboardCommand> CompleteList = list;
            for (int i = 0; i < 10; i++)
            {
                foreach (KeyboardCommand command in CompleteList)
                {
                    Utils.ProcessKeyboardCommand(command);
                    Debug.WriteLine(command);
                }
                System.Threading.Thread.Sleep(1000);

            }



        }
    }
}
