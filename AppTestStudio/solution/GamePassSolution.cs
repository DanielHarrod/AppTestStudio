using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio.solution
{
    internal class GamePassSolution : IDisposable
    {
        public GamePassSolution() { }
        public List<ISolution> Solutions { get; set; } = new List<ISolution>();

        public Bitmap? Bitmap { get; set; } = null;

        public void AddSolution(ISolution solution) { Solutions.Add(solution); }

        public void Dispose()
        {
            if (Bitmap != null) { Bitmap.Dispose(); }
        }
    }
}
