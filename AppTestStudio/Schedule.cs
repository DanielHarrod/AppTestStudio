// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

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
        public List<ScheduleItem> GenerateRuntimeSchedule()
        {
            List<ScheduleItem> RuntimeSchedule = new List<ScheduleItem>();

            foreach (ScheduleItem ScheduleTemplate in ScheduleList)
            {
                if ( ScheduleTemplate.IsEnabled )
                {
                    ScheduleItem FirstScheduledItem = ScheduleTemplate.CloneMe();

                    // ScheduleTemplate.StartsAt contains the date + time it was scheduled.  We only care about the time.  
                    // Add Current Day + time from ScheduleTemplate.StartsAt
                    FirstScheduledItem.NextRun = DateTime.Today.Add(ScheduleTemplate.StartsAt.TimeOfDay);

                    RuntimeSchedule.Add(FirstScheduledItem);

                    // if it repeats then calculate the other times to launch.
                    if (ScheduleTemplate.Repeats)
                    {
                        DateTime NextPotentialDateTime = FirstScheduledItem.NextRun;
                        NextPotentialDateTime = NextPotentialDateTime.AddMinutes(ScheduleTemplate.RepeatsEvery);

                        while ( NextPotentialDateTime < DateTime.Today.AddDays(1) )
                        {
                            ScheduleItem NextItem = ScheduleTemplate.CloneMe();
                            NextItem.NextRun = NextPotentialDateTime;
                            RuntimeSchedule.Add(NextItem);

                            NextPotentialDateTime = NextPotentialDateTime.AddMinutes(ScheduleTemplate.RepeatsEvery);
                        }
                    }
                }
            }

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
