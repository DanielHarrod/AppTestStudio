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

            KeyboardCommand[] list = kp.ParseScript(s).ToArray();

            GameNodeAction ActionNode = new GameNodeAction("", ActionType.Action);
            ActionNode.KeyboardBetweenDuration = 30;
            ActionNode.KeyboardBetweenDurationRandom = 3;

            ActionNode.KeyboardDownDuration = 50;
            ActionNode.KeyboardDownDurationRandom = 5;


            List<KeyboardCommand> CompleteList = kp.SequenceAndApplyPreWaits(list, ActionNode);
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
