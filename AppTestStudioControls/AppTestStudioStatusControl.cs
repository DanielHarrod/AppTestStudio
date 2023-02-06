//AppTestStudio 
//Copyright (C) 2016-2023 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AppTestStudioControls
{
    public partial class AppTestStudioStatusControl : UserControl
    {
        public AppTestStudioStatusControl()
        {
            InitializeComponent();
        }

        private long mShowPercent;

        public long ShowPercent
        {
            get { return mShowPercent; }
            set { 
                mShowPercent = value;
                Invalidate();
            }
        }

        public List<String> Items { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<AppTestStudioStatusControlItem> Queue { get; set; }
        private List<long> Modes { get; set; }

        private List<Brush> Brushes { get; set; }
        private List<Pen> Pens { get; set; }

        private static int HeaderArea = 200;
        private static long MiddleBufferWidth = 8;
        private static long HeaderHeight = 20;
        private static long HeaderWorkArea = HeaderHeight - 1;
        private static long RowSeparaterHeight = 1;
        private static long RowBottomBorderHeight = 1;
        private static long RowShadowOffSet = 1;
        private static long RowHeaderSeparatorLine = 1;


        private static Pen BlackPen = new Pen(Color.Black);
        private static Pen RowLineColor = new Pen(Color.FromArgb(38, 38, 38));

        private static Font HeaderFont = new Font("Veranda", 8, FontStyle.Regular);
        private static Brush HeaderBrush = new SolidBrush(Color.FromArgb(167, 167, 167));
        private static Pen LightGrayPen = new Pen(Color.FromArgb(167, 167, 167));
        private static Pen LightGrayPenShadow = new Pen(Color.FromArgb(105, 105, 105));
        private static Font HeaderTopLeftFont = new Font("Verdana", 12, FontStyle.Regular);
        private static Brush HeaderTopLeftBrush = new SolidBrush(Color.FromArgb(167, 167, 167));

        private void AppTestStudioStatusControl_Load(object sender, EventArgs e)
        {
            Queue = new List<AppTestStudioStatusControlItem>();
            Brushes = new List<Brush>();
            Pens = new List<Pen>();
            Modes = new List<long>();
            Items = new List<string>();

            int BrushAlpha = 140;
            SolidBrush AquaBrush = new SolidBrush(Color.FromArgb(BrushAlpha, 115, 132, 129));
            Pen AquaHighlight = new Pen(Color.FromArgb(92, 107, 105));

            Brushes.Add(AquaBrush);
            Pens.Add(AquaHighlight);

            SolidBrush RedBrush = new SolidBrush(Color.FromArgb(BrushAlpha, 121, 58, 58));
            Pen RedHighlight = new Pen(Color.FromArgb(97, 41, 41));
            Brushes.Add(RedBrush);
            Pens.Add(RedHighlight);

            SolidBrush YellowBrush = new SolidBrush(Color.FromArgb(BrushAlpha, 144, 138, 68));
            Pen YellowHighlight = new Pen(Color.FromArgb(118, 113, 50));
            Brushes.Add(YellowBrush);
            Pens.Add(YellowHighlight);

            SolidBrush PinkBrush = new SolidBrush(Color.FromArgb(BrushAlpha, 145, 124, 131));
            Pen PinkHighlight = new Pen(Color.FromArgb(119, 100, 106));
            Brushes.Add(PinkBrush);
            Pens.Add(PinkHighlight);

            //'lavendar
            Brushes.Add(new SolidBrush(Color.FromArgb(BrushAlpha, 115, 115, 131)));
            Pens.Add(new Pen(Color.FromArgb(92, 92, 107)));

            //'peach
            Brushes.Add(new SolidBrush(Color.FromArgb(BrushAlpha, 146, 127, 109)));
            Pens.Add(new Pen(Color.FromArgb(120, 103, 87)));

            //'sea foam
            Brushes.Add(new SolidBrush(Color.FromArgb(BrushAlpha, 120, 130, 120)));
            Pens.Add(new Pen(Color.FromArgb(96, 105, 96)));

            //'blue
            Brushes.Add(new SolidBrush(Color.FromArgb(BrushAlpha, 82, 93, 142)));
            Pens.Add(new Pen(Color.FromArgb(62, 72, 117)));

            //'green
            Brushes.Add(new SolidBrush(Color.FromArgb(BrushAlpha, 67, 112, 68)));
            Pens.Add(new Pen(Color.FromArgb(49, 90, 50)));

            //'brown
            Brushes.Add(new SolidBrush(Color.FromArgb(BrushAlpha, 94, 65, 51)));
            Pens.Add(new Pen(Color.FromArgb(73, 47, 35)));

            //'cyan
            Brushes.Add(new SolidBrush(Color.FromArgb(BrushAlpha, 152, 85, 137)));
            Pens.Add(new Pen(Color.FromArgb(126, 65, 112)));

            //'sandstone
            Brushes.Add(new SolidBrush(Color.FromArgb(BrushAlpha, 114, 105, 90)));
            Pens.Add(new Pen(Color.FromArgb(91, 83, 69)));

            //'Dim te As New StatusControlItem With {.Index = 8, .Time = 1000}
            //'Queue.Add(te)



            //'Queue.Add(New StatusControlItem With {.Index = 1, .Time = 10})

            //'Queue.Add(New StatusControlItem With {.Index = 2, .Time = 200})

            //'Queue.Add(New StatusControlItem With {.Index = 3, .Time = 800})

            //'Queue.Add(New StatusControlItem With {.Index = 2, .Time = 1500})

            //'Queue.Add(New StatusControlItem With {.Index = 1, .Time = 350})

            DoubleBuffered = true;

            ShowPercent = 10;


            Modes.Add(1);
            Modes.Add(2);
            Modes.Add(5);
            Modes.Add(15);
            Modes.Add(30);
            Modes.Add(60);
            Modes.Add(120);
            Modes.Add(600);
        }

        private int FindIndex(List<int> ary, long value)
        {
            for (int i = 0; i < ary.Count(); i++)
            {
                if (value == ary[i])
                {
                    return i;
                }
            }
            return 0;
        }


        private void DrawHeaderTopRight(PaintEventArgs e)
        {
            long HashSize = 5;
            long HashShadowSize = HashSize - 1;

            //' start ~7 pixels from the top
            long HashTop = HeaderWorkArea - HashSize;
            long HashShadowTop = HeaderWorkArea - HashShadowSize;

            //'stop right above the black line
            long HashBottom = HashTop + HashSize;
            long HashShadowBottom = HashShadowTop + HashShadowSize;

            long DistanceFromWorkAreaToFirstHash = 8;
            long FirstHashPositionX = HeaderArea + DistanceFromWorkAreaToFirstHash;
            long FirstHashPositionXShadow = FirstHashPositionX - 1;

            e.Graphics.DrawLine(LightGrayPen, FirstHashPositionX, HashTop, FirstHashPositionX, HashBottom);
            e.Graphics.DrawLine(LightGrayPenShadow, FirstHashPositionXShadow, HashShadowTop, FirstHashPositionXShadow, HashShadowBottom);

            //'Me.ShowPercent 
            long HashWorkArea = Width - FirstHashPositionX;

            HashMode TickMode = CalcModeIncrement();

            long DistancePerHash = HashWorkArea / TickMode.Entries;

            for (int i = 0; i < TickMode.Entries; i++)
            {

                long X = FirstHashPositionX + (DistancePerHash * i);

                e.Graphics.DrawLine(LightGrayPen, X, HashTop, X, HashBottom);
                e.Graphics.DrawLine(LightGrayPenShadow, X - 1, HashShadowTop, X - 1, HashShadowBottom);

                String HeaderText = TickMode.Print(i * TickMode.Mode);

                long TextStartX = HeaderArea + i * DistancePerHash;

                if (HeaderText.Length == 3)
                {
                    TextStartX = TextStartX - 3;
                }
                else if (HeaderText.Length == 4)
                {
                    TextStartX = TextStartX - 6;
                }
                e.Graphics.DrawString(HeaderText, HeaderFont, HeaderBrush, TextStartX, 0);

            }

        }



        private HashMode CalcModeIncrement()
        {
            HashMode Result = new HashMode();

            long MaxEntries = 25;
            long MinEntries = 13;

            foreach (long Mode in Modes)
            {
                Result.Entries = ShowPercent / Mode;
                Result.Mode = Mode;

                if (Result.Entries <= MaxEntries)
                {
                    return Result;
                }
            }
            //' Never happens?
            Debug.Assert(false);
            return Result;

        }


        private void DrawHeaderTopLeft(PaintEventArgs e)
        {
            e.Graphics.DrawString(ShowPercent + " sec", HeaderTopLeftFont, HeaderTopLeftBrush, 0, 0);
        }

        private long RowTop(long index, long rowHeight)
        {
            return index * rowHeight;
        }

        private long RowShadowTop(long index, long rowHeight)
        {
            return RowTop(index, rowHeight) + CellHeight(rowHeight) - RowBottomBorderHeight;
        }

        private long CellHeight(long rowHeight)
        {
            return rowHeight - RowSeparaterHeight;
        }


        private Boolean DrawCell(PaintEventArgs e, long startTime, int yPositionIndex, long Ticks, long length, long rowHeight)
        {
            Brush Brush = Brushes[yPositionIndex % Brushes.Count];
            Pen Pen = Pens[yPositionIndex % Pens.Count];

            long TimeInSeconds = ShowPercent;

            long TimeInMiliseconds = TimeInSeconds * 1000;

            long TimeInTicks = TimeInMiliseconds * TimeSpan.TicksPerMillisecond;

            long RangeArea = Width - HeaderArea;
            Double AreaPerPoint = TimeInTicks / RangeArea;


            long StartPosition = (long)((startTime - Ticks) / AreaPerPoint);
            long FirstWidth = (long)((length * TimeSpan.TicksPerMillisecond) / AreaPerPoint);

            if (FirstWidth == 0)
            {
                FirstWidth = 1;
            }

            //' no need to draw off the screen
            if (StartPosition > RangeArea)
            {
                Brush = null;
                Pen = null;
                return false;
            }

            long RectangleX1 = HeaderArea + StartPosition;
            long RectangelY1 = HeaderHeight + RowHeaderSeparatorLine + RowTop(yPositionIndex, rowHeight);
            long Height = CellHeight(rowHeight);

            long StartX = RectangleX1 - FirstWidth;
            long PaintWidth = FirstWidth;

            // Header adjustment
            if (StartX <= HeaderArea )
            {
                PaintWidth = PaintWidth - (HeaderArea - StartX);
                StartX = HeaderArea;
            }
            
            if (PaintWidth == 1)
            {
                // just draw a line
                e.Graphics.FillRectangle(Brush, StartX, RectangelY1, PaintWidth, Height);
            }
            else
            {
                // make room for the shadow
                e.Graphics.FillRectangle(Brush, StartX, RectangelY1, PaintWidth - 1, Height);
            }

            if (FirstWidth == 1)
            {
                return true;
            }

            //'underneath Shadow
            long x1 = StartX + RowShadowOffSet;
            long x2 = x1 + PaintWidth -1 -RowShadowOffSet - 1 ;
            long y1 = HeaderHeight + RowHeaderSeparatorLine + RowShadowTop(yPositionIndex, rowHeight);
            long y2 = HeaderHeight + RowHeaderSeparatorLine + RowShadowTop(yPositionIndex, rowHeight);
            e.Graphics.DrawLine(Pen, x1, y1, x2, y2);

            //'rigth hilight
            //y1 = RowTop(1 + yPositionIndex)
            //y2 = RowShadowTop(1 + yPositionIndex)
            //e.Graphics.DrawLine(Pen, x2, y1, x2, y2)

            Brush = null;
            Pen = null;
            return true;

        }

        private void AppTestStudioStatusControl_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (Queue.Count > 120000)
                {
                    Queue.Clear();
                    return;
                }

                //'Black line + 18 header + black line + 16 + 38xline
                //'Dim RowHeight As Long = 16


                long LinesRange = Height - HeaderHeight;

                long WorkingAreaLeft = Width - HeaderArea;

                //' Dim LightGrayPen As New Pen(Color.FromArgb(60, 60, 60))

                using (SolidBrush DarkGrayBrush = new SolidBrush(Color.FromArgb(48, 48, 48)))
                {
                    using (Region region = new Region(new Rectangle(1, 1, HeaderArea, Height)))
                    {
                        e.Graphics.FillRegion(DarkGrayBrush, region);
                    }
                }

                using (SolidBrush GrayBrush = new SolidBrush(Color.FromArgb(60, 60, 60)))
                {
                    using (Region region = new Region(new Rectangle(HeaderArea, 1, Width - HeaderArea, Height)))
                    {
                        e.Graphics.FillRegion(GrayBrush, region);
                    }
                }



                //' Top header top black line
                e.Graphics.DrawLine(BlackPen, 1, 1, Width, 1);

                //' Top header bottom black line
                e.Graphics.DrawLine(BlackPen, 1, HeaderHeight, Width, HeaderHeight);

                //' Middle black line
                e.Graphics.DrawLine(BlackPen, HeaderArea - MiddleBufferWidth, 1, HeaderArea - MiddleBufferWidth, Height);


                //' Row Lines all the way across


                long Scale = 21;
                long FontSize = 11;

                //'Scale = 12
                //' FontSize = Scale * 0.41

                //'Scale = 12
                //'FontSize = 5

                //'Scale = 8
                //'FontSize = 3

                long LinestoDraw = LinesRange / (Scale);

                for (int i = 1; i < LinestoDraw; i++)
                {
                    e.Graphics.DrawLine(RowLineColor, 1, HeaderHeight + (i * Scale), Width, HeaderHeight + (i * Scale));
                }

                List<int> ShortItems = new List<int>(new int[Items.Count]);
                for (int i = 0; i < ShortItems.Count; i++)
                {
                    ShortItems[i] = -1;
                }

                if (ShortItems.Count > 0)
                {
                    foreach (AppTestStudioStatusControlItem item in Queue)
                    {
                        if (item.Index < ShortItems.Count())
                        {
                            if (ShortItems[item.Index] == -1)
                            {
                                ShortItems[item.Index] = 1;
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Short Items>Itemindex");
                        }
                    }
                }

                int SIcount = 0;

                for (int i = 0; i < ShortItems.Count; i++)
                {
                    if (ShortItems[i] == 1)
                    {
                        ShortItems[i] = i;
                        SIcount = SIcount + 1;
                    }
                }

                List<int> ActiveItems = new List<int>( new int[SIcount]);


                int ActiveItemCount = 0;

                for (int i = 0; i < ShortItems.Count; i++)
                {
                    if (ShortItems[i] >= 0)
                    {
                        ActiveItems[ActiveItemCount] = ShortItems[i];
                        ActiveItemCount = ActiveItemCount + 1;
                    }
                }



                using (Font VerandaFont = new Font("Verdana", FontSize, FontStyle.Regular))
                {
                    using (SolidBrush lightGrayBrush = new SolidBrush(Color.FromArgb(167, 167, 167)))
                    {

                        long FontStart = 22;
                        for (int i = 0; i < ActiveItems.Count; i++)
                        {
                            e.Graphics.DrawString(Items[ActiveItems[i]], VerandaFont, lightGrayBrush, 10, FontStart + (i * Scale));
                        }


                        long StartTime = DateTime.Now.ToUniversalTime().Ticks;
                        Boolean Result = true;

                        List<AppTestStudioStatusControlItem> lstToRemove = new List<AppTestStudioStatusControlItem>();
                        foreach (AppTestStudioStatusControlItem item in Queue)
                        {
                            Result = DrawCell(e, StartTime, FindIndex(ActiveItems, item.Index), item.Ticks, item.Time, Scale);
                            if (Result == false)
                            {
                                lstToRemove.Add(item);
                            }
                        }

                        foreach (AppTestStudioStatusControlItem item in lstToRemove)
                        {
                            Queue.Remove(item);
                        }

                        lstToRemove.Clear();

                        DrawHeaderTopLeft(e);
                        DrawHeaderTopRight(e);

                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }


    class HashMode
    {
        public long Entries { get; set; }
        public long Mode { get; set; }
        public HashMode()
        { }

        public String Print(long i)
        {

            switch (Mode)
            {
                case 1:
                case 2:
                case 5:
                case 15:
                case 30:
                    if (i < 10)
                    {
                        return "0" + i + "s";
                    }
                    else
                    {
                        return i + "s";
                    }
                default:
                    long Result = i / 60;

                    if (Result < 10)
                    {
                        return "0" + Result + "m";
                    }
                    else
                    {
                        return Result + "m";
                    }
            }
        }
    }
}
