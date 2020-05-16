// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AppTestStudio
{
    public class GameNodeAction : GameNode
    {
        public GameNodeAction(string name, ActionType actionType)
            : base(name, GameNodeType.Action, actionType)
        {
            this.ActionType = actionType;
            AfterCompletionType = AfterCompletionTypeDefault();
            LogicChoice = "AND";

            DelayMS = DefaultDelayMS();
            DelayS = DefaultDelayS();
            DelayM = DefaultDelayM();
            DelayH = DefaultDelayH();
            LimitDelayMS = 0;
            LimitDelayS = 0;
            LimitDelayM = 0;
            LimitDelayH = 0;
            Mode = Mode.RangeClick;
            Points = 0;
            UseParentPicture = true;
            IsColorPoint = true;
            ObjectName = "";
            ObjectThreshold = 70;
            ClickList = new List<SingleClick>();
            ClickSpeed = 0;
            ClickDragReleaseVelocity = 500;
            ClickDragReleaseMode = ClickDragReleaseMode.None;

            Enabled = true;
            RepeatsUntilFalse = false;
            RepeatsUntilFalseLimit = 0;

            ClickDragReleaseEndHeight = 25;
            ClickDragReleaseEndWidth = 25;
            ClickDragReleaseStartHeight = 25;
            ClickDragReleaseStartWidth = 25;

            Channel = "";
            Utils.SetIcons(this);

        }

        public int DefaultDelayS()
        {
            switch (ActionType)
            {
                case ActionType.Action:
                    return 1;
                case ActionType.Event:
                    return 0;
                case ActionType.RNG:
                    return 0;
                case ActionType.RNGContainer:
                    return 0;
                default:
                    return 0;
            }
        }

        public int DefaultDelayMS()
        {
            return 0;
        }

        public int DefaultDelayM()
        {
            return 0;
        }

        /// <summary>
        /// Default Delay Hours
        /// </summary>
        /// <returns></returns>
        public int DefaultDelayH()
        {
            return 0;
        }

        public List<SingleClick> ClickList { get; set; }


        /// <summary>
        /// LogicChoice - Used to determine the logic choice when a screenshot is taken and the clickList is evaluated
        /// When And: All color/point combinations must match for a true result.
        /// When Or : At least one color/point combination must match for a true result.
        /// </summary>
        private String mLogicChoice;

        public String LogicChoice
        {
            get { return mLogicChoice; }
            set
            {
                mLogicChoice = value;
            }
        }

        /// <summary>
        /// When Logic Choice is CUSTOM this contains AND/OR/NOT/(/)/#'s logic
        /// where the #'s represent the ClickList in a 1 based format
        /// eg. 1 AND not (2)
        /// </summary>
        public String CustomLogic { get; set; }

        private Boolean mIsColorPoint;
        /// <summary>
        /// When True : Used on Event Node types ColorPoint is system will search a list of colors and points for a match
        /// When False: Object Search is used.
        /// </summary>
        public Boolean IsColorPoint
        {
            get { return mIsColorPoint; }
            set
            {
                mIsColorPoint = value;
                Utils.SetIcons(this);
            }
        }

        /// <summary>
        /// The delay between the mouse going down and the mouse going up in a click event.
        /// </summary>
        public int ClickSpeed { get; set; }

        public Boolean Enabled { get; set; }

        public Boolean RepeatsUntilFalse { get; set; }
        public int RepeatsUntilFalseLimit { get; set; }

        public ActionType ActionType { get; set; }

        public Rectangle Rectangle;
        public Boolean UseParentPicture { get; set; }
        public Bitmap ObjectSearchBitmap { get; set; }
        public int ResolutionWidth { get; set; }
        public int ResolutionHeight { get; set; }
        public String ObjectName { get; set; }

        private String mFileName;

        public String FileName
        {
            get { return mFileName; }
            set { mFileName = value; }
        }

        public AfterCompletionType AfterCompletionType { get; set; }

        public int DelayMS { get; set; }
        public int DelayS { get; set; }
        public int DelayM { get; set; }
        public int DelayH { get; set; }
        public Boolean LimitRepeats { get; set; }
        public int LimitDelayMS { get; set; }
        public int LimitDelayS { get; set; }
        public int LimitDelayM { get; set; }
        public int LimitDelayH { get; set; }
        public Boolean AutoBalance { get; set; }
        private int mPercentage;

        public int Percentage
        {
            get { return mPercentage; }
            set
            {
                mPercentage = value;
                Text = String.Format("{0}%", mPercentage);
            }
        }

        public Boolean IsLimited { get; set; }
        public WaitType WaitType { get; set; }
        public Boolean IsWaitFirst { get; set; }
        public long ExecutionLimit { get; set; }

        private Mode mMode;
        public Mode Mode
        {
            get { return mMode; }
            set
            {
                mMode = value;

                if (ActionType == ActionType.Action)
                {
                    Utils.SetIconsActionTypeAction(this);
                }
            }
        }

        public int Points { get; set; }

        /// <summary>
        /// Where to provide X,Y Coordinates Start/End = from object search.
        /// </summary>
        public ClickDragReleaseMode ClickDragReleaseMode { get; set; }
        public int ClickDragReleaseStartHeight { get; set; }
        public int ClickDragReleaseStartWidth { get; set; }
        public int ClickDragReleaseEndHeight { get; set; }
        public int ClickDragReleaseEndWidth { get; set; }
        public int ClickDragReleaseVelocity { get; set; }

        public int ThreadMatchCount { get; set; }
        public Boolean RuntimeOncePerSession { get; set; }

        public Boolean RuntimeWaitFirst { get; set; }
        public long RuntimeIterationsLeft { get; set; }
        public DateTime RuntimeNextAllowedTime { get; set; }
        public String Channel { get; set; }
        public long ObjectThreshold { get; set; }
        public int RelativeXOffset { get; set; }
        public int RelativeYOffset { get; set; }

        private Bitmap mBitmap;
        public Bitmap Bitmap
        {
            get { return mBitmap; }
            set
            {
                mBitmap = value;
                FileName = String.Format("{0}{1}.bmp", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-"), Environment.TickCount & int.MaxValue);
            }
        }

        AfterCompletionType AfterCompletionTypeDefault()
        {
            switch (ActionType)
            {
                case ActionType.Action:
                    return AfterCompletionType.Home;
                case ActionType.Event:
                    return AfterCompletionType.Continue;
                case ActionType.RNG:
                    return AfterCompletionType.Continue;
                case ActionType.RNGContainer:
                    return AfterCompletionType.Continue;
                default:
                    return AfterCompletionType.Continue;
            }
        }

        // Don't Clone
        public String LastLogicChoice { get; set; }

        public GameNodeAction CloneMe()
        {
            GameNodeAction Action = new GameNodeAction(GameNodeName, ActionType);

            foreach (SingleClick Item in ClickList)
            {
                Action.ClickList.Add(Item.CloneMe());
            }

            Action.LogicChoice = LogicChoice;
            Action.Rectangle = new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            Action.UseParentPicture = UseParentPicture;
            if (Bitmap.IsSomething())
            {
                Action.Bitmap = Bitmap.CloneMe();
            }

            if (ObjectSearchBitmap.IsSomething())
            {
                Action.ObjectSearchBitmap = ObjectSearchBitmap.CloneMe();
            }

            Action.ResolutionHeight = ResolutionHeight;
            Action.ResolutionWidth = ResolutionWidth;
            Action.FileName = FileName;
            Action.AfterCompletionType = AfterCompletionType;
            Action.DelayMS = DelayMS;
            Action.DelayS = DelayS;
            Action.DelayH = DelayH;
            Action.DelayM = DelayM;
            Action.AutoBalance = AutoBalance;
            Action.Percentage = Percentage;
            Action.IsLimited = IsLimited;
            Action.IsWaitFirst = IsWaitFirst;
            Action.ExecutionLimit = ExecutionLimit;
            Action.WaitType = WaitType;
            Action.LimitRepeats = LimitRepeats;
            Action.LimitDelayMS = LimitDelayMS;
            Action.LimitDelayS = LimitDelayS;
            Action.LimitDelayH = LimitDelayH;
            Action.LimitDelayM = LimitDelayM;
            Action.ObjectThreshold = ObjectThreshold;
            Action.RelativeXOffset = RelativeXOffset;
            Action.RelativeYOffset = RelativeYOffset;
            Action.Mode = Mode;
            Action.Points = Points;
            Action.Text = Text;
            Action.ObjectName = ObjectName;
            Action.Channel = Channel;
            Action.IsColorPoint = IsColorPoint;  //must be set after Mode
            Action.CustomLogic = CustomLogic;
            Action.ClickSpeed = ClickSpeed;

            Action.ClickDragReleaseMode = ClickDragReleaseMode;
            Action.ClickDragReleaseEndHeight = ClickDragReleaseEndHeight;
            Action.ClickDragReleaseEndWidth = ClickDragReleaseEndWidth;
            Action.ClickDragReleaseStartHeight = ClickDragReleaseStartHeight;
            Action.ClickDragReleaseStartWidth = ClickDragReleaseStartWidth;
            Action.ClickDragReleaseVelocity = ClickDragReleaseVelocity;

            Action.Enabled = Enabled;
            Action.RepeatsUntilFalse = RepeatsUntilFalse;
            Action.RepeatsUntilFalseLimit = RepeatsUntilFalseLimit;

            foreach (GameNodeAction ChildAction in Nodes)
            {
                GameNodeAction CA = ChildAction.CloneMe();
                Action.Nodes.Add(CA);
            }
            Utils.SetIcons(Action);

            return Action;
        }

        public GameNode ToGameNode()
        {
            return (GameNode)this;
        }

        // Removing use IsTrue
        //public Boolean IsActionMatch(Bitmap bmp, ref int qualifyingPoints)
        //{
        //    Boolean Result = false;
        //    Boolean FinalResult = false;

        //    foreach (SingleClick singleClick in ClickList)
        //    {
        //        Color color = Color.Empty;
        //        if (bmp.Height >= singleClick.Y)
        //        {
        //            if (bmp.Width >= singleClick.X)
        //            {
        //                color = bmp.GetPixel(singleClick.X, singleClick.Y);
        //            }
        //        }


        //        if (LogicChoice == "AND")
        //        {

        //            if (singleClick.Color.CompareColorWithPoints(color, Points, ref qualifyingPoints))
        //            {
        //                // First one always OK.
        //                if (FinalResult == false)
        //                {
        //                    Result = true;
        //                }
        //            }
        //            else
        //            {
        //                Result = false;
        //                FinalResult = true;
        //            }
        //        }
        //        else
        //        {
        //            if (singleClick.Color.CompareColorWithPoints(color, Points, ref qualifyingPoints))
        //            {
        //                Result = true;
        //            }
        //        }

        //        if (ClickList.Count == 0)
        //        {
        //            Result = true;
        //        }
        //    }
        //    return Result;
        //}

        internal bool IsTrue(Bitmap bmp, GameNodeGame game, ref int centerX, ref int centerY, ref int detectedOffset, ref float detectedThreashold)
        {
            if (IsColorPoint)
            {
                return IsColorPointTrue(game, bmp, ref detectedOffset);
            }
            else
            {
                return IsImageSearchTrue(bmp, game, ref centerX, ref centerY, ref detectedThreashold);
            }
        }

        /// <summary>
        /// Compares the clicklist agains the bitmap.
        /// </summary>
        /// <param name="game">For Logging custom exceptions</param>
        /// <param name="bmp"></param>
        /// <param name="offset">Returns the number of points on the first failure.</param>
        /// <returns>True if thie logic passes</returns>
        private bool IsColorPointTrue(GameNodeGame game, Bitmap bmp, ref int offset)
        {
            //' no colors to click = pass.
            if (ClickList.Count == 0)
            {
                //'TB.AddReturnTrue()
                return true;
            }

            String Expression = "";

            Boolean UsingCustomLogic = false;

            if (LogicChoice == "CUSTOM")
            {
                UsingCustomLogic = true;
            }

            String PreExpression = CustomLogic;
            if (UsingCustomLogic)
            {
                // add spaces to beginning and end.
                Expression = " " + CustomLogic + " ";

                // Lets add space between everything and expand mix the logic to allow for C# and VB Logic.
                Expression = Utils.ExtendCustomLogic(Expression);
            }

            String OriginalExpression = Expression;

            // need to traverse reverse for customlogic

            for (int i = ClickList.Count - 1; i >= 0; i--)
            {
                SingleClick click = ClickList[i];

                // if a click is out of X or Y range then hard fail.
                if (bmp.Width <= click.X)
                {
                    return false;
                }

                if (bmp.Height <= click.Y)
                {
                    return false;
                }

                Color Color = bmp.GetPixel(click.X, click.Y);
                switch (LogicChoice.ToUpper())
                {
                    case "AND":

                        if (click.Color.CompareColorWithPoints(Color, Points, ref offset))
                        {
                            //'TB.AddColorTest(click.Color, Color, Node.Points, Node.LogicChoice, True)
                        }
                        else
                        {
                            //'TB.AddColorTest(click.Color, Color, Node.Points, Node.LogicChoice, False)
                            //'TB.AddReturnFalse()
                            return false;
                        }
                        break;
                    case "OR":
                        if (click.Color.CompareColorWithPoints(Color, Points, ref offset))
                        {
                            //'TB.AddColorTest(click.Color, Color, Node.Points, Node.LogicChoice, True)
                            //'TB.AddReturnTrue()
                            return true;
                        }
                        else
                        {

                            //'TB.AddColorTest(click.Color, Color, Node.Points, Node.LogicChoice, False)
                        }
                        break;
                    case "CUSTOM":
                        Boolean Result = click.Color.CompareColorWithPoints(Color, Points, ref offset);
                        if (Result)
                        {
                            Expression = Expression.Replace((i + 1).ToString(), "TRUE");
                        }
                        else
                        {
                            Expression = Expression.Replace((i + 1).ToString(), "FALSE");
                        }

                        // Write custom logic
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
            // found no true's with the OR logic
            if (LogicChoice == "OR")
            {
                //' TB.AddReturnFalse()
                return false;
            }

            if (UsingCustomLogic)
            {
                BooleanParser.Parser parser = new BooleanParser.Parser(Expression);
                try
                {
                    return parser.Parse();
                }
                catch (Exception ex)
                {
                    game.Log("Encountered Parse excetion");
                    String NewExpress = OriginalExpression.Replace("(", "").Replace(")", "").Replace("TRUE", "").Replace("FALSE", "").Replace("AND", "").Replace("OR", "").Replace("NOT", "").Replace(" ", "");

                    if (NewExpress.Length > 0)
                    {
                        game.Log("Precompile says: " + NewExpress);
                    }

                    game.Log("Parser Says:" + ex.Message);
                    return false;
                }
            }

            return true;

        }

        private bool IsImageSearchTrue(Bitmap bmp, GameNodeGame game, ref int centerX, ref int centerY, ref float detectedThreashold)
        {
            if (Rectangle.Width <= 0 || Rectangle.Height <= 0)
            {
                //'Debug.Assert(False)
                //'TB.AddReturnFalse()
                return false;
            }

            //' False if no object to search
            if (ObjectName == "")
            {
                //' TB.AddReturnFalse()
                return false;
            }

            if (Channel == "")
            {
                //' TB.AddReturnFalse()
                return false;
            }

            if (ObjectSearchBitmap.IsNothing())
            {
                game.Log(GameNodeName + " configuration is invalid Search Object Not Configured.");
                //' TB.AddReturnFalse()
                return false;
            }

            Bitmap CropImage = new Bitmap(Rectangle.Width, Rectangle.Height);

            using (Graphics grp = Graphics.FromImage(CropImage))
            {
                grp.DrawImage(bmp, new Rectangle(0, 0, Rectangle.Width, Rectangle.Height), Rectangle, GraphicsUnit.Pixel);
                //'grp.DrawEllipse(Pens.Black, 40, 40, 40, 40)

                grp.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grp.PixelOffsetMode = PixelOffsetMode.HighQuality;
                grp.CompositingQuality = CompositingQuality.HighQuality;

            }

            Mat m1 = OpenCvSharp.Extensions.BitmapConverter.ToMat(CropImage);

            //'213 ms
            //'Dim Red As Mat = m1.ExtractChannel(2)
            Mat[] BGR = m1.Split();

            Mat Blue = BGR[0];
            Mat Green = BGR[1];
            Mat Red = BGR[2];

            Mat m2 = OpenCvSharp.Extensions.BitmapConverter.ToMat(ObjectSearchBitmap);
            BGR = m2.Split();
            Mat BlueTarget = BGR[0];
            Mat GreenTarget = BGR[1];
            Mat RedTarget = BGR[2];

            double Percent = 0;
            if (ObjectThreshold == 0)
            {
                Percent = 99;
            }
            else
            {
                Percent = ObjectThreshold / 100;
            }

            int Rows = Red.Rows - RedTarget.Rows + 1;
            int Cols = Red.Cols - RedTarget.Cols + 1;

            if (Rows < 1)
            {
                game.Log(Name + " search item height " + RedTarget.Rows + "px is larger than the height of the mask of " + Red.Rows + "px, Please increase the mask size so the search image can be searched.");
                return false;
            }

            if (Cols < 1)
            {
                game.Log(Name + " search item width is " + RedTarget.Cols + "px is larger than the width of the mask of " + Red.Cols + "px, Please increase the mask size so the search image can be searched.");
                return false;
            }

            Mat res = new Mat(Rows, Cols, MatType.CV_8U);
            //'Cv2.CvtColor(m1, m2, ColorConversionCodes.)

            Mat SearchTarget = null;
            Mat ObjectTarget = null;
            switch (Channel.ToUpper())
            {
                case "RED":
                    SearchTarget = Red;
                    ObjectTarget = RedTarget;
                    break;
                case "GREEN":
                    SearchTarget = Green;
                    ObjectTarget = GreenTarget;
                    break;
                case "BLUE":
                    SearchTarget = Blue;
                    ObjectTarget = BlueTarget;
                    break;
                default:
                    game.Log(Name + " missing Channel using Red");
                    SearchTarget = Red;
                    ObjectTarget = RedTarget;
                    break;
            }
            try
            {
                Cv2.MatchTemplate(SearchTarget, ObjectTarget, res, TemplateMatchModes.CCoeffNormed);
            }
            catch (Exception)
            {
                game.Log("Search Failure, possible resolution mismatch");
                return false;
            }

            OpenCvSharp.Point p = new OpenCvSharp.Point();
            OpenCvSharp.Point DetectedPoint = new OpenCvSharp.Point();
            Cv2.MinMaxLoc(res, out p, out DetectedPoint);

            Mat.Indexer<Single> indexer = res.GetGenericIndexer<Single>();
            detectedThreashold = indexer[DetectedPoint.Y, DetectedPoint.X];

            long iObjectThreshold = ObjectThreshold;
            if (iObjectThreshold == 0)
            {
                iObjectThreshold = 100;
            }

            centerX = DetectedPoint.X + (ObjectSearchBitmap.Width / 2);
            centerY = DetectedPoint.Y + (ObjectSearchBitmap.Height / 2);


            if (detectedThreashold >= ((float)iObjectThreshold / 100))
            {
                game.Log("Closest match " + (detectedThreashold * 100).ToString("F1") + ", x = " + (centerX + Rectangle.X) + "  y =" + (centerY + Rectangle.Y));
                //'TB.AddReturnTrue()

                if (FileName.IsNothing())
                {
                    SendBitmapToProject(bmp, game);
                }
                return true;
            }
            else
            {
                //'TB.AddReturnFalse()
                return false;
            }
        }

        public void SendBitmapToProject(Bitmap bmp, GameNodeGame game)
        {
            MinimalBitmapNode mbn = new MinimalBitmapNode();
            mbn.NodeName = Name;
            mbn.ResolutionWidth = ResolutionWidth;
            mbn.ResolutionHeight = ResolutionHeight;
            mbn.Bitmap = bmp.Clone() as Bitmap;
            FileName = "";
            game.MinimalBitmapClones.Enqueue(mbn);
        }

        public Boolean IsParentObjectSearch()
        {
            GameNodeAction Node = Parent as GameNodeAction;
            if (Node.IsSomething())
            {
                if (Node.IsColorPoint == false)
                {
                    return true;
                }
            }
            return false;
        }



        public void PaintNode(Graphics graphics)
        {
            switch (Mode)
            {
                case Mode.RangeClick:
                    if (Rectangle.Width > 0 && Rectangle.Height > 0)
                    {
                        //Draw a box at 50% transparency to show the click area.
                        using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                        {
                            graphics.FillRectangle(br, Rectangle);
                        }

                        // Draw a blue outline around the click area.
                        using (Pen p = new Pen(Color.Blue, 1))
                        {
                            graphics.DrawRectangle(p, Rectangle);
                        }

                        // Draw a white outline to show the offset window.
                        if (RelativeXOffset != 0 || RelativeYOffset != 0)
                        {
                            using (Pen DashPen = new Pen(Color.WhiteSmoke))
                            {
                                Rectangle Outline = Rectangle;
                                Outline.X = Outline.X + RelativeXOffset;
                                Outline.Y = Outline.Y + RelativeYOffset;
                                graphics.DrawRectangle(DashPen, Outline);
                            }
                        }
                    }
                    break;
                case Mode.ClickDragRelease:
                    // Draw Drag Drop Line
                    using (Pen linePen = new Pen(Color.FromArgb(128, 0, 0, 255), 8))
                    {
                        linePen.StartCap = LineCap.RoundAnchor;
                        linePen.EndCap = LineCap.ArrowAnchor;
                        linePen.DashStyle = DashStyle.Dot;

                        int x1 = Rectangle.X;
                        int y1 = Rectangle.Y;
                        int x2 = Rectangle.X + Rectangle.Width;
                        int y2 = Rectangle.Y + Rectangle.Height;

                        // Draw a Dashed line with a Circle for start, and Pointer for end.
                        Debug.WriteLine("Drawline x={0}, y={1}, Width={2}, Height={3}", x1, y1, x2, y2);
                        graphics.DrawLine(linePen, x1, y1, x2, y2);

                        // Draw a Box around the start range area.
                        using (Pen DashPen = new Pen(Color.WhiteSmoke))
                        {
                            x1 = Rectangle.X - (ClickDragReleaseStartWidth / 2);
                            y1 = Rectangle.Y - (ClickDragReleaseStartHeight / 2);
                            int Width = ClickDragReleaseStartWidth;
                            int Height = ClickDragReleaseStartHeight;
                            graphics.DrawRectangle(DashPen, x1, y1, Width, Height);
                        }

                        // Draw a Box around the end range area.
                        using (Pen DashPen = new Pen(Color.FromArgb(226, 68, 47)))
                        {
                            x1 = Rectangle.X + Rectangle.Width - (ClickDragReleaseEndWidth / 2);
                            y1 = Rectangle.Y + Rectangle.Height - (ClickDragReleaseEndHeight / 2);
                            int Width = ClickDragReleaseEndWidth;
                            int Height = ClickDragReleaseEndHeight;
                            graphics.DrawRectangle(DashPen, x1, y1, Width, Height);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public class RangeClickResult
        {
            public int x;
            public int y;
        }

        public class ClickDragReleaseResult
        {
            public int StartX;
            public int StartY;
            public int EndX;
            public int EndY;
        }

        public ClickDragReleaseResult CalculateClickDragReleaseResult(int centerX, int centerY)
        {
            ClickDragReleaseResult Result = new ClickDragReleaseResult();

            // Calculate how much to add/remove from the Center  1/2 the distance - random(total) 
            short RandomXStart = (short)((ClickDragReleaseStartWidth / 2) - Convert.ToInt32(Utils.RandomNumber(0, ClickDragReleaseStartWidth)));
            short RandomYStart = (short)((ClickDragReleaseStartHeight / 2) - Convert.ToInt32(Utils.RandomNumber(0, ClickDragReleaseStartHeight)));
            short RandomXEnd = (short)((ClickDragReleaseEndWidth / 2) - Convert.ToInt32(Utils.RandomNumber(0, ClickDragReleaseEndWidth)));
            short RandomYEnd = (short)((ClickDragReleaseEndHeight / 2) - Convert.ToInt32(Utils.RandomNumber(0, ClickDragReleaseEndHeight)));

            int x = Rectangle.Left;
            int y = Rectangle.Top;

            int x2 = Rectangle.Width;
            int y2 = Rectangle.Height;

            if (IsParentObjectSearch() && (ClickDragReleaseMode != ClickDragReleaseMode.None))
            {
                GameNodeAction ParentNode = Parent as GameNodeAction;
                if (ParentNode.IsSomething())
                {
                    if (ClickDragReleaseMode == ClickDragReleaseMode.Start)
                    {
                        // Click Drag Release Start at Center + Mask + Relative Offset
                        x = centerX + ParentNode.Rectangle.X + RelativeXOffset;
                        y = centerY + ParentNode.Rectangle.Y + RelativeYOffset;

                        // Fixed Target
                        x2 = Rectangle.Width + Rectangle.X;
                        y2 = Rectangle.Height + Rectangle.Y;
                    }
                    else // == Stop
                    {
                        // Click Drag Release Start at Center + Mask + Relative Offset
                        // Do nothing here already set.
                        //x = x;
                        //y = y;

                        // Fixed Target
                        x2 = centerX + ParentNode.Rectangle.X + RelativeXOffset;
                        y2 = centerY + ParentNode.Rectangle.Y + RelativeYOffset;

                    }
                }
                else
                {
                    Debug.Assert(false);
                }
            }
            else
            {
                x2 = x + x2;
                y2 = y + y2;
            }

            x = x + RandomXStart;
            y = y + RandomYStart;
            x2 = x2 + RandomXEnd;
            y2 = y2 + RandomYEnd;

            Result.StartX = x;
            Result.StartY = y;
            Result.EndX = x2;
            Result.EndY = y2;

            return Result;
        }

        public RangeClickResult CalculateRangeClickResult(int centerX, int centerY)
        {
            RangeClickResult Result = new RangeClickResult();

            int xPos = Rectangle.X;
            int yPos = Rectangle.Y;

            short RandomX = Utils.RandomNumber(0, Rectangle.Width);
            short RandomY = Utils.RandomNumber(0, Rectangle.Height);

            if (IsParentObjectSearch())
            {
                if (Parent is GameNodeAction)
                {
                    GameNodeAction ParentNode = Parent as GameNodeAction;
                    //     center(reative to mask)  + Mask  + Relative Offset -  1/2 the size of the box to click + random.
                    xPos = centerX + ParentNode.Rectangle.X + RelativeXOffset - (Rectangle.Width / 2) + RandomX;
                    yPos = centerY + ParentNode.Rectangle.Y + RelativeYOffset - (Rectangle.Height / 2) + RandomY;
                }
                else
                {
                    Debug.Assert(false);
                }
            }
            else
            {
                xPos = xPos + RandomX;
                yPos = yPos + RandomY;
            }

            Result.x = xPos;
            Result.y = yPos;
            return Result;
        }
    }
}