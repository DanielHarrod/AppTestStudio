//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppTestStudioControls
{
    public partial class ATSGraph : UserControl
    {
        public ATSGraph()
        {
            InitializeComponent();
        }

        private void ProcessVisualization_Load(object sender, EventArgs e)
        {
            MaxBuckets = SecondsToShow;

            Buckets = new int[MaxBuckets];
            LightGreenPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }

        int SideMargin = 0;
        int VerticalMargin = 0;

        public List<long> Queue = new List<long>();

        private static Pen GreenPen = new Pen(Color.Green);
        private static Pen LightGreenPen = new Pen(Color.Green);        

        int MaxFound = 0;

        int currentIndex = 0;

        int SecondsToShow = 60;
        int MaxBuckets;

        int[] Buckets;
        int Highest = 0;

        int LowestMax = 0;

        public string Prepender = " ms";
        public int TopShift = 50;

        private void ProcessVisualization_Paint(object sender, PaintEventArgs e)
        {
            Buckets[currentIndex % MaxBuckets] = (int)Queue.Sum();
            //Debug.WriteLine(Queue.Count);
            Queue.Clear();
            currentIndex++;

            MaxFound = Buckets.Max() + TopShift;

            if (MaxFound > Highest)
            {
                Highest = MaxFound;
            }
            
            if (MaxFound > 0)
            {
                int MaxSnapTo100s = (int)Math.Ceiling((double)MaxFound / 100d) * 100;
                lblMax.Text = MaxSnapTo100s.ToString() + Prepender; ;
                lblMid.Text = (MaxSnapTo100s / 2).ToString() + Prepender; ;
                MaxFound = MaxSnapTo100s;
                int MaxTick = Environment.TickCount;


                int WorkAreaWidth = Width - SideMargin - SideMargin;
                int WorkAreaHeight = Height - VerticalMargin - VerticalMargin;

                double XSpacing = (double) WorkAreaWidth / (double)Buckets.Length;

                double YSingleUnitSpacing = (double)WorkAreaHeight / (double)MaxFound;

                //e.Graphics.DrawLine(GreenPen, 0, 0, 500, 0);

                //// Draw Top Line
                int x1 = SideMargin;
                int y1 = VerticalMargin;
                int x2 = WorkAreaWidth + SideMargin;
                int y2 = y1;
                //e.Graphics.DrawLine(GreenPen, x1, y1, x2, y2);

                //// Draw Bottom Line
                //x1 = SideMargin;
                //y1 = WorkAreaHeight + VerticalMargin;
                //x2 = WorkAreaWidth + SideMargin;
                //y2 = y1;
                //e.Graphics.DrawLine(GreenPen, x1, y1, x2, y2);

                // Draw Left Line
                //x1 = SideMargin;
                //y1 = VerticalMargin;
                //x2 = x1;
                //y2 = WorkAreaHeight + VerticalMargin;
                //e.Graphics.DrawLine(GreenPen, x1, y1, x2, y2);

                //// Draw Right Line
                //x1 = WorkAreaWidth + SideMargin ;
                //y1 = VerticalMargin;
                //x2 = x1;
                //y2 = WorkAreaHeight + VerticalMargin;
                //e.Graphics.DrawLine(GreenPen, x1, y1, x2, y2);

                // Draw Middle Line
                x1 = SideMargin ;
                y1 = (WorkAreaHeight/2) + VerticalMargin;
                x2 = WorkAreaWidth + SideMargin;
                y2 = y1;
                e.Graphics.DrawLine(LightGreenPen, x1, y1, x2, y2);

                long Average = 0;
                long AverageCount = 0;

                int LowestCurrent = 0;

                List<Point> points = new List<Point>();
                for (int i = 0; i < MaxBuckets; i++)
                {
                    int kIndex = (currentIndex + i) % MaxBuckets;
                    if (i == (MaxBuckets-1))
                    {
                        lblCurrent.Text = "Last:" + Buckets[kIndex].ToString() + Prepender; ;
                        //lblAverage.Text = "Average:" + Buckets.Average().ToString();
                    }

                    if (LowestCurrent ==0 || Buckets[kIndex] > 0)
                    {
                        if (LowestCurrent == 0)
                        {
                            LowestCurrent = Buckets[kIndex];
                        }
                        else
                        {
                            if (Buckets[kIndex] < LowestCurrent)
                            {
                                LowestCurrent = Buckets[kIndex];
                            }

                        }
                    }

                    Point point = new Point();

                    //point.X = SideMargin + WorkAreaWidth - (i * XSpacing);
                    point.X =  WorkAreaWidth - (int)(i * XSpacing);

                    point.Y = WorkAreaHeight + VerticalMargin - (int)((YSingleUnitSpacing * Buckets[kIndex]) *0.99)+1;
                    // Move the (cursor)
                    points.Add(point);

                    if (Buckets[kIndex] > 0)
                    {
                        Average += Buckets[kIndex];
                        AverageCount++;
                    }
                }

                if (points.Count > 1)
                {
                    //Graphics.DrawBeziers
                    e.Graphics.DrawLines(GreenPen, points.ToArray());
                    if (AverageCount > 0)
                    {
                        lblAverage.Text = "Average: " + (Average / AverageCount) + Prepender; ;
                    }                    
                }
                lblHighest.Text = $"Highest: {Highest}/{MaxFound} {Prepender}"; 


                if (LowestCurrent < LowestMax || LowestMax ==0)
                {
                    LowestMax = LowestCurrent; 
                }
                lblLowest.Text = $"Low: {LowestCurrent}/{LowestMax} {Prepender}" ;
            }
        }

        private void ProcessVisualization_SizeChanged(object sender, EventArgs e)
        {
            lblHighest.Left = 2;
            lblHighest.Top = lblHighest.Height;

            lblLowest.Top = Height - lblLowest.Height;
            lblLowest.Left = 2;

            lblMid.Top = (Height / 2) - (lblMid.Height);
            lblMid.Left = SideMargin + 2; // Plus 2 pixels right to move from lines drawn.

            lblCurrent.Left = 2;
            // +1 for space for the middle line.
            lblCurrent.Top = lblMid.Top + lblMid.Height + 1;

            lblAverage.Top = lblCurrent.Top + lblCurrent.Height;
            lblAverage.Left = 2;

        }
    }
}
