// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

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
            DragTargetMode = DragTargetMode.Absolute;
            ClickList = new List<SingleClick>();

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
        public String LogicChoice { get; set; }


        private Boolean mIsColorPoint;
        /// <summary>
        /// When True : Used on Event Node types ColorPoint is system will search a list of colors and points for a match
        /// When False: Object Search is used.
        /// </summary>
        public Boolean IsColorPoint
        {
            get { return mIsColorPoint; }
            set { 
                mIsColorPoint = value;
                Utils.SetIcons(this);
            }
        }

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
        public Mode Mode {
            get { return mMode; }
            set { 
                mMode = value; 

                if (ActionType == ActionType.Action )
                {
                    Utils.SetIconsActionTypeAction(this);
                }
            } 
        }
        
        public int Points { get; set; }

        public int ThreadMatchCount { get; set; }
        public Boolean RuntimeOncePerSession { get; set; }

        public Boolean RuntimeWaitFirst { get; set; }
        public long RuntimeIterationsLeft { get; set; }
        public DateTime RuntimeNextAllowedTime { get; set; }
        public String Channel { get; set; }
        public long ObjectThreshold { get; set; }
        public Boolean IsRelativeStart { get; set; }
        public int RelativeXOffset { get; set; }
        public int RelativeYOffset { get; set; }
        public DragTargetMode DragTargetMode { get; set; }

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
            Action.IsRelativeStart = IsRelativeStart;
            Action.RelativeXOffset = RelativeXOffset;
            Action.RelativeYOffset = RelativeYOffset;
            Action.Mode = Mode;
            Action.Points = Points;
            Action.Text = Name;
            Action.ObjectName = ObjectName;
            Action.Channel = Channel;
            Action.IsColorPoint = IsColorPoint;  //must be set after Mode

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
                return IsColorPointTrue(bmp, ref detectedOffset);
            }
            else
            {
                return IsImageSearchTrue(bmp, game, ref centerX, ref centerY, ref detectedThreashold);
            }
        }

        /// <summary>
        /// Compares the clicklist agains the bitmap.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="offset">Returns the number of points on the first failure.</param>
        /// <returns>True if thie logic passes</returns>
        private bool IsColorPointTrue(Bitmap bmp, ref int offset)
        {
            //' no colors to click = pass.
            if (ClickList.Count == 0)
            {
                //'TB.AddReturnTrue()
                return true;
            }

            // if a click is out of X or Y range then fail
            foreach (SingleClick click in ClickList)
            {
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
                game.Log("Closest match " + (detectedThreashold * 100).ToString("F1") + " - x = " + centerX + "  y =" + centerY);
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


    }
}