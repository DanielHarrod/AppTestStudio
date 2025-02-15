//AppTestStudio 
//Copyright(C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System.Diagnostics;

namespace AppTestStudio
{
    public class HistoryManager
    {
        private const String FileName = "History.config";
        private String WorkspaceFolder = "";
        public HistoryManager(String WorkspaceFolder)
        {
            this.WorkspaceFolder = WorkspaceFolder;

            try
            {
                String FileName = GetHistoryFileName();
                if (System.IO.File.Exists(FileName))
                {
                    String[] Lines = System.IO.File.ReadAllLines(FileName);
                    foreach (String Line in Lines.Reverse<String>())
                    {
                        HistoricalLaunches.Add(Line);

                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        private string GetHistoryFileName()
        {
            return $"{WorkspaceFolder}\\{FileName}";
        }

        public List<String> HistoricalLaunches = new List<string>();

        public void AddNew(String Filename)
        {
            HistoricalLaunches.Insert(0, Filename);
        }

        public void Save()
        {
            try
            {
                List<string> OutputFiles = GetOutputFiles();

                if (OutputFiles.Count() > 0)
                {
                    String FileName = GetHistoryFileName();

                    System.IO.File.WriteAllLines(FileName, OutputFiles.ToArray());
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        public List<string> GetOutputFiles()
        {
            List<String> OutputFiles = new List<string>();

            try
            {
                int SaveLimit = 5;

                foreach (String item in HistoricalLaunches)
                {
                    if (OutputFiles.Contains(item))
                    {
                        // do nothing
                    }
                    else
                    {
                        SaveLimit--;
                        OutputFiles.Add(item);
                    }
                    if (SaveLimit == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            return OutputFiles;
        }
    }
}
