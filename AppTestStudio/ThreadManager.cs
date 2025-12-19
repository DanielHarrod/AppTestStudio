//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using AppTestStudio.Data;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml.Serialization;

namespace AppTestStudio
{
    public class ThreadManager
    {
		public ThreadManager()
		{
			Games = new List<GameNodeGame>();
			RemoveGameLock = new object();
			ThreadLog = new ConcurrentQueue<String>();
			ProcessingTime = new ConcurrentQueue<int>();
		}
		[XmlIgnore] public List<GameNodeGame> Games { get; set; }

		// Store Stats from last run.
		[XmlIgnore] public ThreadManager LoadThreadManager { get; set; }

        public String GetFileNameDeprecated()
        {
            return Utils.GetApplicationFolder() + @"\ThreadManager.xml";
        }
        
        [XmlIgnore] private Object RemoveGameLock { get; set; }

		[XmlIgnore] public Boolean IsDirty { get; set; }

		[XmlIgnore] public ConcurrentQueue<String> ThreadLog { get; set; }

		[XmlIgnore] public ConcurrentQueue<int> ProcessingTime { get; set; }

		CounterRepository counterRepository = new CounterRepository();

        public void AddProcessingTime(int time)
        {
			if (ProcessingTime.Count() > 5000)
			{
				int result = 0;
				ProcessingTime.TryDequeue(out result);
			}
			ProcessingTime.Enqueue(time);
        }

		public int DequeueProcessingTime()
        {
			int Total = 0;
			int result = 0;
			while (ProcessingTime.TryDequeue(out result))
            {
				Total += result;
            }
			return Total;
        }

		public void RemoveGame(GameNodeGame Game)
		{
			lock (RemoveGameLock)
			{
				Games.Remove(Game);
				IsDirty = true;
			}
		}

		public void Load()
        {
			try
			{
			    String ThreadManagerFileName = GetFileNameDeprecated();

                LoadThreadManager = new ThreadManager();
				LoadThreadManager.StartCounter.CounterName = "$App$Test$Studio$System";

                if (System.IO.File.Exists(ThreadManagerFileName))
				{
					OldSerializedThreadmanager otm = new OldSerializedThreadmanager();
                    XmlSerializer Serializer = new XmlSerializer(otm.GetType());
                    TextReader TRead = new StreamReader(ThreadManagerFileName);
                    otm = Serializer.Deserialize(TRead) as OldSerializedThreadmanager;

					LoadThreadManager.StartCounter.AppLaunches = otm.AppLaunches;
					LoadThreadManager.StartCounter.ClickCount = otm.ClickCount;
					LoadThreadManager.StartCounter.WaitLength = otm.WaithLength;
					LoadThreadManager.StartCounter.ScreenShots = otm.ScreenShots;
					LoadThreadManager.StartCounter.GoHome = otm.GoHome;
					LoadThreadManager.StartCounter.GoContinue = otm.GoContinue;
					LoadThreadManager.StartCounter.GoChild = otm.GoChild;
					LoadThreadManager.StartCounter.RNG = otm.RNG;
					LoadThreadManager.StartCounter.AppLaunches = otm.AppLaunches;

                    TRead.Close();

					counterRepository.Upsert(LoadThreadManager.StartCounter);

                    System.IO.File.Move(ThreadManagerFileName, $"{ThreadManagerFileName}.history" );
				}
				else
				{
					LoadThreadManager.StartCounter = counterRepository.Get("$App$Test$Studio$System");
                }
				
			}
			catch (Exception ex)
			{
				Debug.WriteLine("threadManager.Load:" + ex.Message);
				LoadThreadManager = new ThreadManager();
			} 
        }

        public void Save()
        {
			if (LoadThreadManager.IsSomething())
			{
				Counter StartAndSessionCounter = LoadThreadManager.StartCounter.CloneMe();
                StartAndSessionCounter.ClickCount += ClickCount;
                StartAndSessionCounter.WaitLength += WaitLength;
                StartAndSessionCounter.ScreenShots +=ScreenShots;
                StartAndSessionCounter.GoHome += GoHome;
                StartAndSessionCounter.GoContinue += GoContinue;
                StartAndSessionCounter.GoChild += GoChild;
                StartAndSessionCounter.RNG += RNG;

                counterRepository.Upsert(StartAndSessionCounter);
            }
        }

		private Counter StartCounter = new Counter();

		public long ClickCount
		{
			get { return StartCounter.ClickCount; }
			private set { StartCounter.ClickCount = value; }
		}

		[System.Diagnostics.DebuggerStepThrough]
		public long IncrementClickCount()
		{
			return Interlocked.Increment(ref StartCounter.ClickCount);
		}

		public long WaitLength
		{
			get { return StartCounter.WaitLength; }
			private set { StartCounter.WaitLength = value; }
		}

		[System.Diagnostics.DebuggerStepThrough]
		public long AddWaitLength(long value)
		{
			return Interlocked.Add(ref StartCounter.WaitLength, value);
		}

		[System.Diagnostics.DebuggerStepThrough]
		public long IncrementWaitLength()
		{
			return Interlocked.Increment(ref StartCounter.WaitLength);
		}

		private long ClickDragRelease
		{
			get { return StartCounter.ClickDragRelease; }
			set { StartCounter.ClickDragRelease = value; }
		}

		public long IncrementClickDragRelease()
		{
			return Interlocked.Increment(ref StartCounter.ClickDragRelease);
		}

		private long MouseMove
		{
			get { return StartCounter.MouseMove; }
			set { StartCounter.MouseMove = value; }
		}

		public long IncrementMouseMove()
		{
			return Interlocked.Increment(ref StartCounter.MouseMove);
		}

		public long ScreenShots
		{
			get { return StartCounter.ScreenShots; }
			set { StartCounter.ScreenShots = value; }
		}

		public long IncrementScreenShots()
		{
			return Interlocked.Increment(ref StartCounter.ScreenShots);
		}

		private long GoParent
		{
			get { return StartCounter.GoParent; }
			set { StartCounter.GoParent = value; }
		}
		[System.Diagnostics.DebuggerStepThrough]
		public long IncrementGoParent()
		{
			return Interlocked.Increment(ref StartCounter.GoParent);
		}

		public long GoHome
		{
			get { return StartCounter.GoHome; }
			set { StartCounter.GoHome = value; }
		}
		[System.Diagnostics.DebuggerStepThrough]
		public long IncrementGoHome()
		{
			return Interlocked.Increment(ref StartCounter.GoHome);
		}

		private long GoStop
		{
			get { return StartCounter.GoStop; }
			set { StartCounter.GoStop = value; }
		}

		[System.Diagnostics.DebuggerStepThrough]
		public long IncrementGoStop()
		{
			return Interlocked.Increment(ref StartCounter.GoStop);
		}

		public long GoContinue
		{
			get { return StartCounter.GoContinue; }
			set { StartCounter.GoContinue = value; }
		}

		[System.Diagnostics.DebuggerStepThrough]
		public long IncrementGoContinue()
		{
			return Interlocked.Increment(ref StartCounter.GoContinue);
		}
	
		public long GoChild
		{
			get { return StartCounter.GoChild; }
			set { StartCounter.GoChild = value; }
		}

		[System.Diagnostics.DebuggerStepThrough]
		public long IncrementGoChild()
		{
			StartCounter.GoChild += 1;
            return Interlocked.Increment(ref StartCounter.GoChild);
		}

		public long RNG
		{
			get { return StartCounter.RNG; }
			set { StartCounter.RNG = value; }
		}

		[System.Diagnostics.DebuggerStepThrough]
		public long IncrementRNG()
		{
			return Interlocked.Increment(ref StartCounter.RNG);
		}

        internal long IncrementRNGContainer()
        {
            return Interlocked.Increment(ref StartCounter.RNGContainer);
        }
    }
}
