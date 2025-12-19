//AppTestStudio 
//Copyright(C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System.CodeDom;

namespace AppTestStudio.Data
{    internal class Counter 
    {
        public Counter()
        {
			ClickCount = 0;
			WaitLength = 0;
			ScreenShots = 0;
			GoHome = 0;
			GoContinue = 0;
			GoChild = 0;
			GoParent = 0;
			ClickDragRelease = 0;
			MouseMove = 0;
			GoStop = 0;
			RNG = 0;
			RNGContainer = 0;
			AppLaunches = 0;
			TestLoaded = 0;
			TestSaved = 0;
        }
        internal String CounterName = "";
		internal long ClickCount;
		internal long WaitLength;
		internal long ScreenShots;
		internal long GoHome;
		internal long GoContinue;
		internal long GoChild;
		internal long GoParent;
		internal long ClickDragRelease;
		internal long MouseMove;
		internal long GoStop;
		internal long RNG;
		internal long RNGContainer;
        internal long AppLaunches;
		internal long TestLoaded;
		internal long TestSaved;

		internal Counter CloneMe() { 
			Counter NewCounter = new Counter();
			NewCounter.CounterName = CounterName;
			NewCounter.ClickCount = ClickCount;
			NewCounter.WaitLength = WaitLength;
			NewCounter.ScreenShots = ScreenShots;
			NewCounter.GoHome = GoHome;
			NewCounter.GoContinue = GoContinue;
			NewCounter.GoChild = GoChild;
			NewCounter.GoParent = GoParent;
			NewCounter.ClickDragRelease = ClickDragRelease;
			NewCounter.MouseMove = MouseMove;
			NewCounter.GoStop = GoStop;
			NewCounter.RNG = RNG;
			NewCounter.RNGContainer = RNGContainer;
			NewCounter.AppLaunches = AppLaunches;
			NewCounter.TestLoaded = TestLoaded;
			NewCounter.TestSaved = TestSaved;
			return NewCounter;
        }
    }
}
