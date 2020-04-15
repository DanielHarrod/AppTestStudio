// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
using System.Collections.Generic;
using System.Drawing;

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

        public int DefaultDelayH()
        {
            return 0;
        }

        public List<SingleClick> ClickList { get; set; }
        public String LogicChoice { get; set; }

        private Boolean mIsColorPoint;

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
        public Mode Mode { get; set; }
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

        public Boolean IsActionMatch(Bitmap bmp, ref int qualifyingPoints)
        {
            Boolean Result = false;
            Boolean FinalResult = false;

            foreach (SingleClick singleClick in ClickList)
            {
                Color color = Color.Empty;
                if (bmp.Height >= singleClick.Y)
                {
                    if (bmp.Width >= singleClick.X)
                    {
                        color = bmp.GetPixel(singleClick.X, singleClick.Y);
                    }
                }


                if (LogicChoice == "AND")
                {

                    if (singleClick.Color.CompareColorWithPoints(color, Points, ref qualifyingPoints))
                    {
                        // First one always OK.
                        if (FinalResult == false)
                        {
                            Result = true;
                        }
                    }
                    else
                    {
                        Result = false;
                        FinalResult = true;
                    }
                }
                else
                {
                    if (singleClick.Color.CompareColorWithPoints(color, Points, ref qualifyingPoints))
                    {
                        Result = true;
                    }
                }

                if (ClickList.Count == 0)
                {
                    Result = true;
                }
            }
            return Result;
        }
    }
}