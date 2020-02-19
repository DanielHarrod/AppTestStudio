using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public class Schedule
    {
        public String ID { get; set; }
        public Boolean IsEnabled { get; set; }

        public List<ScheduleItem> ScheduleList { get; set; }

    }
}
