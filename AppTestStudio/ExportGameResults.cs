using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public class ExportGameResults
    {
        public List<String> PictureListExtract { get; set; }
        public List<String> ObjectListExtract { get; set; }

        public ExportGameResults()
        {
            PictureListExtract = new List<string>();
            ObjectListExtract = new List<string>();
        }
    }
}
