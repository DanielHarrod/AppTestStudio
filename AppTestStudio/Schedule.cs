//AppTestStudio 
//Copyright (C) 2016-2021 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AppTestStudio
{
    public class Schedule
    {
        public Boolean IsEnabled { get; set; }

        public List<ScheduleItem> ScheduleList { get; set; }

        [XmlIgnore]
        public List<ScheduleItem> RuntimeSchedule { get; set; }

        public String GetFileName()
        {
            return Utils.GetApplicationFolder() + @"\Schedule.xml";
        }

        public Schedule()
        {
            ScheduleList = new List<ScheduleItem>();
            RuntimeSchedule = new List<ScheduleItem>();
        }

        public void Load()
        {
            String FileName = GetFileName();

            if (System.IO.File.Exists(FileName))
            {
                Schedule XMLSchedule = new Schedule();
                XmlSerializer Serializer = new XmlSerializer(GetType());
                TextReader TRead = new StreamReader(FileName);
                XMLSchedule = Serializer.Deserialize(TRead) as Schedule;

                IsEnabled = XMLSchedule.IsEnabled;
                ScheduleList = XMLSchedule.ScheduleList;

                TRead.Close();
            }
            else
            {
                IsEnabled = false;

            }
        }

        public void Save()
        {
            String FileName = GetFileName();

            StreamWriter SR = new StreamWriter(FileName);
            XmlSerializer Serializer = new XmlSerializer(GetType());

            Serializer.Serialize(SR, this);
            SR.Close();
        }

        /// <summary>
        /// I may want to show the calculated full schedule for the entire day, and need a way to get it easily.
        /// This shows all the times for the day for all the schedules.
        /// </summary>
        /// <returns></returns>
        public List<ScheduleItem> GenerateRuntimeSchedule(DateTime DayToStart)
        {
            List<ScheduleItem> RuntimeSchedule = new List<ScheduleItem>();

            foreach (ScheduleItem ScheduleTemplate in ScheduleList)
            {
                if ( ScheduleTemplate.IsEnabled )
                {
                    ScheduleItem FirstScheduledItem = ScheduleTemplate.CloneMe();

                    // ScheduleTemplate.StartsAt contains the date + time it was scheduled.  We only care about the time.  
                    // Add Current Day + time from ScheduleTemplate.StartsAt
                    FirstScheduledItem.NextRun = DayToStart.Date.Add(ScheduleTemplate.StartsAt.TimeOfDay);

                    if (FirstScheduledItem.NextRun > DateTime.Now)
                    {
                        RuntimeSchedule.Add(FirstScheduledItem);
                    }

                    // if it repeats then calculate the other times to launch.
                    if (ScheduleTemplate.Repeats)
                    {
                        DateTime NextPotentialDateTime = FirstScheduledItem.NextRun;
                        NextPotentialDateTime = NextPotentialDateTime.AddMinutes(ScheduleTemplate.RepeatsEvery);

                        while ( NextPotentialDateTime < DayToStart.Date.AddDays(1) )
                        {
                            ScheduleItem NextItem = ScheduleTemplate.CloneMe();
                            NextItem.NextRun = NextPotentialDateTime;

                            if(NextItem.NextRun > DateTime.Now)
                            {
                                RuntimeSchedule.Add(NextItem);
                            }

                            NextPotentialDateTime = NextPotentialDateTime.AddMinutes(ScheduleTemplate.RepeatsEvery);
                        }
                    }
                }
            }

            RuntimeSchedule.Sort(ScheduleItem.CompareByDate);
            
            return RuntimeSchedule;
        }

        public void RemoveHistoricalScheduleItems()
        {
            // go backwards
            for (int i = RuntimeSchedule.Count - 1; i >=0; i--)
            {
                if (RuntimeSchedule[i].NextRun < DateTime.Now)
                {
                    RuntimeSchedule.RemoveAt(i);
                }
            }
        }
    }
}
