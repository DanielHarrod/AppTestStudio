using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppTestStudio;
using static AppTestStudio.GameNodeAction;
using System.Diagnostics;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestClickDragRelease
    {
        GameNodeAction Parent;
        GameNodeAction Action;
        [TestInitialize]
        public void TestInitialize()
        {
            Parent = new GameNodeAction("Parent", ActionType.Event);
            Action = new GameNodeAction("TestBaselineCalculation", ActionType.Action);
            Parent.Nodes.Add(Action);
        }

        [TestMethod]
        public void TestBaselineCalculation()
        {
            //int Width = 10;
            //int Height = 10;
            //int CenterX = 0;
            //int CenterY = 0;

            //Action.Rectangle.X = 0;
            //Action.Rectangle.Y = 0;
            //Action.Rectangle.Height = Height;
            //Action.Rectangle.Width = Width;

            //for (int i = 0; i < 1000; i++)
            //{
            //    RangeClickResult Result = Action.CalculateRangeClickResult(CenterX, CenterY);
            //    Assert.IsTrue(Result.x < Width);
            //    Assert.IsTrue(Result.x >= 0);
            //    Assert.IsTrue(Result.y < Height);
            //    Assert.IsTrue(Result.y >= 0);
            //}
        }

        [TestMethod]
        public void TestBaselineCalculationObjectSearch()
        {
            // Mask
            //Parent.Rectangle.X = 25;
            //Parent.Rectangle.Width = 50;

            //Parent.Rectangle.Y = 25;            
            //Parent.Rectangle.Height = 50;
            

            //Parent.IsColorPoint = false;

            //int Width = 10;
            //int Height = 10;
            //int CenterX = 0;
            //int CenterY = 0;

            //Action.Rectangle.X = 0;
            //Action.Rectangle.Y = 0;
            //Action.Rectangle.Height = Height;
            //Action.Rectangle.Width = Width;

            //// Validate the test parameters are reasonable.
            //Assert.IsTrue(CenterY < Parent.Rectangle.Height - Parent.Rectangle.Y);
            //Assert.IsTrue(CenterX < Parent.Rectangle.Width - Parent.Rectangle.X);

            //for (int i = 0; i < 1000; i++)
            //{
            //    RangeClickResult Result = Action.CalculateRangeClickResult(CenterX, CenterY);
            //    //Debug.WriteLine(Result.ToString());
            //    Assert.IsTrue(Result.x >= Parent.Rectangle.X +Action.RelativeXOffset - (Action.Rectangle.Width/2));
            //    Assert.IsTrue(Result.y >= Parent.Rectangle.Y + Action.RelativeYOffset - (Action.Rectangle.Height/2));


            //    //Assert.IsTrue(Result.y < Height);
            //    //Assert.IsTrue(Result.y >= 0);
            //}
        }

    }
}
