using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AppTestStudio.Data
{
    [XmlRoot("ThreadManager")]
    public class OldSerializedThreadmanager
    {
        public long ClickCount;
        public long WaithLength;
        public long ScreenShots;
        public long GoHome;
        public long GoContinue;
        public long GoChild;
        public long RNG;
        public long AppLaunches;
    }
}
