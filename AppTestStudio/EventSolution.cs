//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.


namespace AppTestStudio
{
    internal class EventSolution
    {
        public String LogicChoice { get; set; } = "";
        public List<SingleClick> ClickList { get; private set; }

        public List<EventSolutionItem> EventSolutionItems { get; private set; } = new List<EventSolutionItem>();
        public String CustomExpression { get; set; }
        public Boolean Result { get; set; }

        public float DetectedThreashold { get; set; }
        public int CenterX { get; set; } = 0;
        public int CenterY { get; set; } = 0;

        public int AnchorX { get; set; } = 0;
        public int AnchorY { get; set; } = 0;
        public int AnchorWidth { get; set; } = 0;   
        public int AnchorHeight {  get; set; } = 0;    

        public String ErrorMessage {  get; set; }
        public long ObjectThreshold { get; internal set; }
        public long ImageSearchTime { get; internal set; }

        public int Offset { get; internal set; }
        public int QualifyingPoints { get; set; }

        internal void AddClickList(List<SingleClick> clickList)
        {
            this.ClickList = new List<SingleClick>(clickList);
        }

        internal void AddColorTest(Color color1, Color color2, int points, bool result)
        {
            EventSolutionItem item = new EventSolutionItem();
            item.Color1 = color1;
            item.Color2 = color2;
            item.Points = points;
            item.Result = result;
            EventSolutionItems.Add(item);
        }
    }
}
