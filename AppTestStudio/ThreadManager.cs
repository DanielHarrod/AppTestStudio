// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AppTestStudio
{
    public class ThreadManager
    {

        public ThreadManager()
        {
            Games = new List<GameNodeGame>();
            RemoveGameLock = new object();
        }
        [XmlIgnore] public List<GameNodeGame> Games { get; set; }

        // Store Stats from last run.
        [XmlIgnore] public ThreadManager LoadThreadManager { get; set; }

        public String GetFileName()
        {
            return Utils.GetApplicationFolder() + @"\ThreadManager.xml";
        }
        
        [XmlIgnore] private Object RemoveGameLock { get; set; }

        [XmlIgnore] public Boolean IsDirty { get; set; }

        public void RemoveGame(GameNodeGame Game )
        {
            lock(RemoveGameLock)
            {
                Games.Remove(Game);
                IsDirty = true;
            }
        }

        public void Load()
        {
			try
			{
			   String ThreadManagerFileName = GetFileName();

				if (System.IO.File.Exists(ThreadManagerFileName))
				{
					ThreadManager XMLThreadManger = new ThreadManager();
					XmlSerializer Serializer = new XmlSerializer(XMLThreadManger.GetType());
					TextReader TRead = new StreamReader(ThreadManagerFileName);
					XMLThreadManger = Serializer.Deserialize(TRead) as ThreadManager;

					this.LoadThreadManager = XMLThreadManger;

					TRead.Close();
				}
				else
				{

					LoadThreadManager = new ThreadManager();
				}
			}
			catch (Exception ex)
			{

				Debug.WriteLine("threadManager.Load:" + ex.Message);
			}
 
        }

        public void Save()
        {
            String FileName = GetFileName();

            StreamWriter SR = new StreamWriter(FileName);
            XmlSerializer Serializer = new XmlSerializer(this.GetType());

			ClickCount += LoadThreadManager.ClickCount;
			WaitLength += LoadThreadManager.WaitLength;
			ScreenShots += LoadThreadManager.ScreenShots;
			GoHome += LoadThreadManager.GoHome;
			GoContinue += LoadThreadManager.GoContinue;
			GoChild += LoadThreadManager.GoChild;
			RNG += LoadThreadManager.RNG;
			AppLaunches += LoadThreadManager.AppLaunches;			

            Serializer.Serialize(SR, this);
            SR.Close();
			SR.Dispose();
        }
		
		private long mClickCount;

		public long ClickCount
		{
			get { return mClickCount; }
			set { mClickCount = value; }
		}
		public long IncrementClickCount()
		{
			return Interlocked.Increment(ref mClickCount);
		}
		
		private long mWaitLength;

		public long WaitLength
		{
			get { return mWaitLength; }
			set { mWaitLength = value; }
		}

		public long AddWaitLength(long value)
		{
			return Interlocked.Add(ref mWaitLength, value);
		}

		public long IncrementWaitLength()
		{
			return Interlocked.Increment(ref mWaitLength);
		}

		private long mClickDragRelease;

		private long ClickDragRelease
		{
			get { return mClickDragRelease; }
			set { mClickDragRelease = value; }
		}

		public long IncrementClickDragRelease()
		{
			return Interlocked.Increment(ref mClickDragRelease);
		}

		private long mScreenShots;

		public long ScreenShots
		{
			get { return mScreenShots; }
			set { mScreenShots = value; }
		}

		public long IncrementScreenShots()
		{
			return Interlocked.Increment(ref mScreenShots);
		}

		private long mGoParent;

		private long GoParent
		{
			get { return mGoParent; }
			set { mGoParent = value; }
		}

		public long IncrementGoParent()
		{
			return Interlocked.Increment(ref mGoParent);
		}

		private long mGoHome;

		public long GoHome
		{
			get { return mGoHome; }
			set { mGoHome = value; }
		}

		public long IncrementGoHome()
		{
			return Interlocked.Increment(ref mGoHome);
		}

		private long mGoStop;

		private long GoStop
		{
			get { return mGoStop; }
			set { mGoStop = value; }
		}

		public long IncrementGoStop()
		{
			return Interlocked.Increment(ref mGoStop);
		}

		private long mGoContinue;

		public long GoContinue
		{
			get { return mGoContinue; }
			set { mGoContinue = value; }
		}

		public long IncrementGoContinue()
		{
			return Interlocked.Increment(ref mGoContinue);
		}

		private long mGoChild;

		public long GoChild
		{
			get { return mGoChild; }
			set { mGoChild = value; }
		}

		public long IncrementGoChild()
		{
			return Interlocked.Increment(ref mGoChild);
		}

		private long mRNG;
		public long RNG
		{
			get { return mRNG; }
			set { mRNG = value; }
		}

		public long IncrementRNG()
		{
			return Interlocked.Increment(ref mRNG);
		}

		private long mAppLaunches;

		public long AppLaunches
		{
			get { return mAppLaunches; }
			set { mAppLaunches = value; }
		}

		public long IncrementAppLaunches()
		{
			return Interlocked.Increment(ref mAppLaunches);
		}

		private long mTestLoaded;

		private long TestLoaded
		{
			get { return mTestLoaded; }
			set { mTestLoaded = value; }
		}

		public long IncrementTestLoaded()
		{
			return Interlocked.Increment(ref mTestLoaded);
		}

		private long mTestSaved;

		private long TestSaved
		{
			get { return mTestSaved; }
			set { mTestSaved = value; }
		}

		public long IncrementTestSaved()
		{
			return Interlocked.Increment(ref mTestSaved);
		}

		private long mNewAppAdded;

		private long NewAppAdded
		{
			get { return mNewAppAdded; }
			set { mNewAppAdded = value; }
		}

		public long IncrementNewAppAdded()
		{
			return Interlocked.Increment(ref mNewAppAdded);
		}

		private long mNewEventAdded;

		private long NewEventAdded
		{
			get { return mNewEventAdded; }
			set { mNewEventAdded = value; }
		}

		public long IncrementNewEventAdded()
		{
			return Interlocked.Increment(ref mNewEventAdded);
		}

		private long mNewActionAdded;

		private long NewActionAdded
		{
			get { return mNewActionAdded; }
			set { mNewActionAdded = value; }
		}

		public long IncrementNewActionAdded()
		{
			return Interlocked.Increment(ref mNewActionAdded);
		}

		private long mInstanceLoaded;

		private long InstanceLoaded
		{
			get { return mInstanceLoaded; }
			set { mInstanceLoaded = value; }
		}

		public long IncrementInstanceLoaded()
		{
			return Interlocked.Increment(ref mInstanceLoaded);
		}

		private long mInstanceLaunched;

		private long InstanceLaunched
		{
			get { return mInstanceLaunched; }
			set { mInstanceLaunched = value; }
		}

		public long IncrementInstanceLaunched()
		{
			return Interlocked.Increment(ref mInstanceLaunched);
		}

		private long mNewRNGContainer;

		private long NewRNGContainer
		{
			get { return mNewRNGContainer; }
			set { mNewRNGContainer = value; }
		}

		public long IncrementNewRNGContainer()
		{
			return Interlocked.Increment(ref mNewRNGContainer);
		}

		private long mSingleTestRun;

		private long SingleTestRun
		{
			get { return mSingleTestRun; }
			set { mSingleTestRun = value; }
		}

		public long IncrementSingleTestRun()
		{
			return Interlocked.Increment(ref mSingleTestRun);
		}

		private long mSingleTestClick;

		private long SingleTestClick
		{
			get { return mSingleTestClick; }
			set { mSingleTestClick = value; }
		}

		public long IncrementSingleTestClick()
		{
			return Interlocked.Increment(ref mSingleTestClick);
		}

		private long mSingleTestClickDragRelease;

		private long SingleTestClickDragRelease
		{
			get { return mSingleTestClickDragRelease; }
			set { mSingleTestClickDragRelease = value; }
		}

		public long IncrementSingleTestClickDragRelease()
		{
			return Interlocked.Increment(ref mSingleTestClickDragRelease);
		}

		private long mSingleEventTest;

		private long SingleEventTest
		{
			get { return mSingleEventTest; }
			set { mSingleEventTest = value; }
		}

		public long IncrementSingleEventTest()
		{
			return Interlocked.Increment(ref mSingleEventTest);
		}
	}
}
