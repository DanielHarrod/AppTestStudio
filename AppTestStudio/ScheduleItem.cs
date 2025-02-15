//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System.Xml.Serialization;

namespace AppTestStudio
{
    public class ScheduleItem 
    {
        public ScheduleItem()
        {
            CurrentRun = DateTime.MinValue;
        }
        public String Name { get; set; }
        public String AppPath { get; set; }
        public String WindowName { get; set; }
        public int InstanceNumber { get; set; }
        public DateTime StartsAt { get; set; }
        public Boolean Monday { get; set; }
        public Boolean Tuesday { get; set; }
        public Boolean Wednesday { get; set; }
        public Boolean Thursday { get; set; }
        public Boolean Friday { get; set; }
        public Boolean Saturday { get; set; }
        public Boolean Sunday { get; set; }
        public Boolean Repeats { get; set; }
        public int RepeatsEvery { get; set; }
        public int StopsAfter { get; set; }

        private Boolean mIsEnabld;

        public Boolean IsEnabled
        {
            get { return mIsEnabld; }
            set { mIsEnabld = value; }
        }

        public ScheduleItem CloneMe()
        {
            ScheduleItem si = new ScheduleItem();
            si.InstanceNumber = InstanceNumber;
            si.AppPath = AppPath;
            si.CurrentRun = CurrentRun;
            si.Friday = Friday;
            si.IsEnabled = IsEnabled;
            si.Monday = Monday;
            si.Name = Name;
            si.NextRun = NextRun;
            si.Repeats = Repeats;
            si.RepeatsEvery = RepeatsEvery;
            si.Running = Running;
            si.Saturday = Saturday;
            si.StartsAt = StartsAt;
            si.StopsAfter = StopsAfter;
            si.Sunday = Sunday;
            si.Thursday = Thursday;
            si.Tuesday = Tuesday; 
            si.Wednesday = Wednesday;
            si.WindowName = WindowName;
            return si;
        }

        // Runtime Property
        [XmlIgnore] public Boolean Running { get; set; }
        [XmlIgnore] public DateTime NextRun { get; set; }
        [XmlIgnore] public DateTime CurrentRun { get; set; }


        public void CalculateAndSetNextRun()
        {
            NextRun = CalculateNextRun();
        }

        public DateTime CalculateNextRun()
        {
            if (IsEnabled == false)
            {
                return DateTime.MaxValue;
            }
            int Hour = DateTime.Now.Hour;
            int Minute = DateTime.Now.Minute;
            DateTime NR = DateTime.MinValue;
            if (Repeats && CurrentRun != DateTime.MinValue)
            {
                NR = CurrentRun.AddMinutes(RepeatsEvery);
            }
            else
            {
                if (CurrentRun == DateTime.MinValue)
                {
                    if (StartsAt.Hour > Hour)
                    {
                        NR = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy ") + StartsAt.ToString("HH:mm"));
                    }
                    else
                    {
                        if (StartsAt.Hour == Hour)
                        {
                            if (StartsAt.Minute >= Minute)
                            {
                                NR = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy ") + StartsAt.ToString("HH:mm"));
                            }
                            else
                            {
                                NR = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy ") + StartsAt.ToString("HH:mm")).AddDays(1);
                            }
                        }
                        else
                        {
                            NR = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy ") + StartsAt.ToString("HH:mm")).AddDays(1);
                        }
                    }
                    //'do nothing

                }
                else
                {
                    //' not sure this ever runs.
                    if (CurrentRun.Hour < Hour)
                    {
                        NR = CurrentRun;
                    }
                    else
                    {
                        if (CurrentRun.Hour == Hour)
                        {
                            if (CurrentRun.Minute < Minute)
                            {
                                NR = CurrentRun;
                            }
                            else
                            {
                                NR = CurrentRun.AddDays(1);
                            }
                        }
                    }
                }

            }

            return NR;

        }


        public static int CompareByDate(ScheduleItem x, ScheduleItem y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal.
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater.
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    if (x.NextRun > y.NextRun)
                    {
                        return 1;
                    }
                    else if (x.NextRun == y.NextRun)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
    }
}
