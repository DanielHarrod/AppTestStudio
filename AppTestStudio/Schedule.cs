using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppTestStudio
{
    public class Schedule
    {
        public Boolean IsEnabled { get; set; }

        public List<ScheduleItem> ScheduleList { get; set; }

        public String GetFileName()
        {
            return Utils.GetApplicationFolder() + @"\Schedule.xml";
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

    }
}
