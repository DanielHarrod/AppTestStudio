//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

namespace AppTestStudio.solution
{
    /// <summary>
    /// Stores solutions for a single pass of the game node.
    /// Stores the Bitmap used.
    /// This consists of a list of Event and Corresponding Actions taken.
    /// 
    /// Todo Later: Need to handle the internal re-scan of a bitmap.
    /// </summary>
    internal class GamePassSolution : IDisposable
    {
        private static int SolutionCounter = 0;
        public int SolutionID { get; private set; }
        public GamePassSolution() 
        {
            SolutionCounter++;
            SolutionID = SolutionCounter;
        }
        public List<ISolution> Solutions { get; set; } = new List<ISolution>();

        public Bitmap? Bitmap { get; set; } = null;

        public string LastNodeName { get; internal set; }

        public void AddSolution(ISolution solution, GameNode node) { 
            Solutions.Add(solution);
            solution.NodeName = node.GameNodeName;
            GameName = node.GetGameNodeGame().Name;
            LastNodeName = node.GameNodeName;   
        }   

        public void Dispose()
        {
            if (Bitmap != null) { Bitmap.Dispose(); }
        }

        public String GameName { get; set; } = string.Empty;


    }
}
