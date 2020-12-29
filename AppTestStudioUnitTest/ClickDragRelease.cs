//AppTestStudio 
//Copyright (C) 2016-2021 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

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
