using AppTestStudioControls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace AppTestStudio
{
    class GameNodeGame : GameNode
    {
        public GameNodeGame(String name) : base(name, GameNodeType.Game)
        {
            ThreadLog = new ConcurrentQueue<string>();
            StatusControl = new ConcurrentQueue<AppTestStudioStatusControlItem>();
            MinimalBitmapClones = new ConcurrentQueue<MinimalBitmapNode>();

            StartTime = DateTime.Now;
            TargetGameBuild = "";
            LoopDelay = 1000;
            Resolution = "1024x768";

            IsPaused = false;

        }

        public ConcurrentQueue<String> ThreadLog { get; set; }
        public ConcurrentQueue<AppTestStudioStatusControlItem> StatusControl { get; set; }

        public ConcurrentQueue<Bitmap> BitmapClones { get; set; }

        public ConcurrentQueue<MinimalBitmapNode> MinimalBitmapClones { get; set; }

        public void Log(String s)
        {
            String Log = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss.");
            String Ticks = "000" + Math.Abs(Environment.TickCount % 1000).ToString();

            String FormattedLog = String.Format(
                "{0}{1} {2} [{3}] {4}",
                DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss."),
                "000" + Math.Abs(Environment.TickCount % 1000).ToString(),
                Name,
                InstanceToLaunch,
                s);


            ThreadLog.Enqueue(FormattedLog);
        }

        public void LogStatus(int Item, long Time)
        {
            AppTestStudioStatusControlItem StatusControlItem = new AppTestStudioStatusControlItem();
            StatusControlItem.Index = Item;
            StatusControlItem.Time = Time;
            StatusControlItem.Ticks = DateTime.UtcNow.Ticks;

            StatusControl.Enqueue(StatusControlItem);
        }

        public Thread Thread { get; set; }

        public String ThreadandWindowName
        {
            get { return Text + " - " + TargetWindow; }
        }

        public Boolean IsPaused { get; set; }

        public String TargetWindow
        {
            get
            {
                return "ATS" + InstanceToLaunch + "Window";
            }
        }

        public String TargetGameBuild { get; set; }
        public String PackageName { get; set; }
        public String InstanceToLaunch { get; set; }

        public GameNodeEvents Events
        {
            get
            {
                return Nodes[0] as GameNodeEvents;
            }
        }

        public DateTime StartTime { get; private set; }

        public long LoopDelay { get; set; }

        public String Resolution { get; set; }
        public String FileName { get; set; }
        public int VideoHeight { get; set; }
        public int VideoWidth { get; set; }

        public GameNodeGame CloneMe()
        {
            GameNodeGame Target = new GameNodeGame(Name);

            Target.TargetGameBuild = TargetGameBuild;
            Target.LoopDelay = LoopDelay;
            Target.PackageName = PackageName;
            Target.InstanceToLaunch = InstanceToLaunch;
            Target.Name = Name;
            Target.FileName = FileName;
            GameNodeEvents TargetEvents = Events.CloneMe();
            TargetEvents.Text = Name;

            Target.VideoFrameLimit = VideoFrameLimit;
            Target.SaveVideo = SaveVideo;

            Target.VideoHeight = VideoHeight;
            Target.VideoWidth = VideoWidth;

            Target.Nodes.Add(TargetEvents);

            return Target;
        }

        public GameNodeAction ThreadLastNodeAction { get; set; }
        public GameNodeAction ThreadLastNodeEvent { get; set; }
        public GameNodeAction AbsoluteLastNode { get; set; }

        public long ScreenShotsTaken { get; set; }
        public long GameLoops { get; set; }
        public long VideoFrameLimit { get; set; }
        public Boolean SaveVideo { get; set; }

        public static GameNodeGame LoadGameFromFile(String FileName, Boolean LoadBitmaps)
        {
            GameNodeGame Game = null;
            XmlDocument Document = new XmlDocument();
            Document.Load(FileName);

            if (Document.DocumentElement.SelectSingleNode("//App").IsSomething())
            {
                XmlNode ChildNode = Document.DocumentElement.SelectSingleNode("//App");
                Game = LoadGame(ChildNode, FileName, "", LoadBitmaps);
            }

            return Game;
        }

        public static GameNodeGame LoadGame(XmlNode ChildNode, String FileName, String OverrideGameName, Boolean LoadBitmaps)
        {
            String GameName = ChildNode.Attributes["Name"].Value;
            if (OverrideGameName.Length > 0)
            {
                GameName = OverrideGameName;
            }

            String TargetGameBuild = ChildNode.Attributes["TargetGameBuild"].Value;

            String PackageName = "";
            long LoopDelay = 1000;
            String Resolution = "1024x768";
            Boolean SaveVideo = false;
            long VideoFrameLimit = 2000;
            String LaunchInstance = "";

            if (ChildNode.Attributes.GetNamedItem("PackageName").IsSomething())
            {
                PackageName = ChildNode.Attributes["PackageName"].Value;
            }

            if (ChildNode.Attributes.GetNamedItem("SaveVideo").IsSomething())
            {
                SaveVideo = Convert.ToBoolean(ChildNode.Attributes["SaveVideo"].Value);
            }

            if (ChildNode.Attributes.GetNamedItem("LaunchInstance").IsSomething())
            {
                LaunchInstance = ChildNode.Attributes["LaunchInstance"].Value;
            }

            if (ChildNode.Attributes.GetNamedItem("LoopDelay").IsSomething())
            {
                LoopDelay = Convert.ToInt64(ChildNode.Attributes["LoopDelay"].Value);
            }

            if (ChildNode.Attributes.GetNamedItem("Resolution").IsSomething())
            {
                Resolution = ChildNode.Attributes["Resolution"].Value;
            }

            if (ChildNode.Attributes.GetNamedItem("VideoFrameLimit").IsSomething())
            {
                VideoFrameLimit = Convert.ToInt64(ChildNode.Attributes["VideoFrameLimit"].Value);
            }

            GameNodeGame Game = new GameNodeGame(GameName);
            Game.TargetGameBuild = TargetGameBuild;
            Game.PackageName = PackageName;
            Game.InstanceToLaunch = LaunchInstance;
            Game.Resolution = Resolution;
            Game.LoopDelay = LoopDelay;
            Game.FileName = FileName;
            Game.SaveVideo = SaveVideo;
            Game.VideoFrameLimit = VideoFrameLimit;

            GameNodeEvents Events = new GameNodeEvents("Events");
            Game.Nodes.Add(Events);

            List<GameNodeAction> ActionNodesWithObjects = new List<GameNodeAction>();
            LoadEvents(ChildNode.FirstChild, Game, Events, ActionNodesWithObjects, LoadBitmaps);

            GameNodeObjects Objects = new GameNodeObjects("Objects");
            Game.Nodes.Add(Objects);

            if (ChildNode.ChildNodes.Count > 1)
            {
                LoadObjects(ChildNode.ChildNodes[1], Objects, GameName, ActionNodesWithObjects, Game);
            }

            return Game;
        }

        private static void LoadObjects(XmlNode xmlNode, GameNodeObjects objects, string gameName, List<GameNodeAction> actionNodesWithObjects, GameNodeGame game)
        {
            foreach (XmlNode LoadObjectNode in xmlNode.ChildNodes)
            {
                String oName = "";
                if (LoadObjectNode.Attributes.GetNamedItem("Name").IsSomething())
                {
                    oName = LoadObjectNode.Attributes["Name"].Value;
                }

                String oFileName = "";
                if (LoadObjectNode.Attributes.GetNamedItem("FileName").IsSomething())
                {
                    oFileName = LoadObjectNode.Attributes["FileName"].Value;
                    foreach (GameNodeAction Node in actionNodesWithObjects)
                    {
                        if (Node.ObjectName == oName)
                        {
                            String FullPathP = Path.Combine(Path.GetDirectoryName(game.FileName), "Pictures", oFileName);
                            if (System.IO.File.Exists(FullPathP))
                            {
                                Node.ObjectSearchBitmap = Bitmap.FromFile(FullPathP) as Bitmap;
                            }
                        }
                    }
                }

                GameNodeObject o = new GameNodeObject(oName);

                String FullPath = Path.Combine(Path.GetDirectoryName(game.FileName), "Pictures", oFileName);

                if (System.IO.File.Exists(FullPath))
                {
                    o.Bitmap = Bitmap.FromFile(FullPath) as Bitmap;
                    o.FileName = oFileName;
                }
                else
                {

                    Debug.WriteLine("filenot found:" + FullPath);
                }
                objects.Nodes.Add(o);
            }
        }

        public static void LoadEvents(XmlNode EventsNode, GameNodeGame GameNode, GameNode TreeEventNode, List<GameNodeAction> lst, Boolean LoadBitmaps)
        {
            foreach (XmlNode ChildNode in EventsNode.ChildNodes)
            {
                switch (ChildNode.Name)
                {
                    case "Event":
                        GameNodeAction NewEvent = new GameNodeAction("New Node", ActionType.Event);
                        TreeEventNode.Nodes.Add(NewEvent);
                        LoadEvent(ChildNode, GameNode, NewEvent, lst, LoadBitmaps);
                        break;
                    case "Action":
                        GameNodeAction NewAction = new GameNodeAction("New Node", ActionType.Action);
                        TreeEventNode.Nodes.Add(NewAction);
                        LoadAction(ChildNode, GameNode, NewAction, lst, LoadBitmaps);
                        break;
                    case "RNG":
                        LoadAction(ChildNode, GameNode, TreeEventNode as GameNodeAction, lst, LoadBitmaps);
                        break;
                    case "RNG-Container":
                        GameNodeAction NewRNGContainer = new GameNodeAction("New Node", ActionType.RNGContainer);
                        TreeEventNode.Nodes.Add(NewRNGContainer);
                        LoadAction(ChildNode, GameNode, NewRNGContainer, lst, LoadBitmaps);
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
        }

        private static void LoadEvent(XmlNode EventNode, GameNodeGame gameNode, GameNodeAction newEvent, List<GameNodeAction> lst, bool loadBitmaps)
        {
            String EventName = EventNode.Attributes["Name"].Value;
            String LogicChoice = "";
            if (EventNode.Attributes.GetNamedItem("LogicChoice").IsSomething())
            {
                LogicChoice = EventNode.Attributes["LogicChoice"].Value;
            }

            Boolean UseParentPicture = false;
            if (EventNode.Attributes.GetNamedItem("UseParentPicture").IsSomething())
            {
                UseParentPicture = Convert.ToBoolean(EventNode.Attributes["UseParentPicture"].Value);
            }

            String AfterComletionType = "";
            if (EventNode.Attributes.GetNamedItem("AfterCompletionType").IsSomething())
            {
                AfterComletionType = EventNode.Attributes["AfterCompletionType"].Value;
                switch (AfterComletionType.ToUpper())
                {
                    case "HOME":
                        newEvent.AfterCompletionType = AfterCompletionType.Home;
                        break;
                    case "CONTINUE":
                        newEvent.AfterCompletionType = AfterCompletionType.Continue;
                        break;
                    case "PARENT":
                        newEvent.AfterCompletionType = AfterCompletionType.Parent;
                        break;
                    case "STOP":
                        newEvent.AfterCompletionType = AfterCompletionType.Stop;
                        break;
                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadEvent.AfterCompletionType {0}", EventNode.Attributes["AfterCompletionType"].Value);
                        newEvent.AfterCompletionType = AfterCompletionType.Home;
                        break;
                }
            }
            else
            {
                newEvent.AfterCompletionType = AfterCompletionType.Continue;
            }

            newEvent.GameNodeName = EventName;
            newEvent.LogicChoice = LogicChoice;
            newEvent.UseParentPicture = UseParentPicture;

            if (EventNode.Attributes.GetNamedItem("IsLimited").IsSomething())
            {
                newEvent.IsLimited = Convert.ToBoolean(EventNode.Attributes["IsLimited"].Value);
            }

            if (EventNode.Attributes.GetNamedItem("IsWaitFirst").IsSomething())
            {
                newEvent.IsWaitFirst = Convert.ToBoolean(EventNode.Attributes["IsWaitFirst"].Value);
            }

            if (EventNode.Attributes.GetNamedItem("ExecutionLimit").IsSomething())
            {
                String ExecutionLimit = EventNode.Attributes["ExecutionLimit"].Value;
                if (ExecutionLimit.IsNumeric())
                {
                    newEvent.ExecutionLimit = ExecutionLimit.ToLong();
                }
                else
                {
                    newEvent.ExecutionLimit = 1;
                }
            }

            if (EventNode.Attributes.GetNamedItem("WaitType").IsSomething())
            {
                String WaitType = EventNode.Attributes["WaitType"].Value;
                switch (WaitType.ToUpper())
                {
                    case "ITERATION":
                        newEvent.WaitType = AppTestStudio.WaitType.Iteration;
                        break;
                    case "TIME":
                        newEvent.WaitType = AppTestStudio.WaitType.Time;
                        break;
                    case "SESSION":
                        newEvent.WaitType = AppTestStudio.WaitType.Session;
                        break;
                    default:
                        newEvent.WaitType = AppTestStudio.WaitType.Iteration;
                        break;
                }
            }

            if (EventNode.Attributes.GetNamedItem("IsColorPoint").IsSomething())
            {
                Boolean IsColorPoint = Convert.ToBoolean(EventNode.Attributes["IsColorPoint"].Value);
                newEvent.IsColorPoint = IsColorPoint;
            }

            if (EventNode.Attributes.GetNamedItem("LimitRepeats").IsSomething())
            {
                switch (EventNode.Attributes["LimitRepeats"].Value.ToUpper())
                {
                    case "TRUE":
                        newEvent.LimitRepeats = true;
                        break;
                    case "FALSE":
                        newEvent.LimitRepeats = false;
                        break;
                    default:
                        break;
                }
            }

            foreach (XmlNode childNode in EventNode.ChildNodes)
            {
                switch (childNode.Name.ToUpper())
                {
                    case "LIMITDELAY":
                        newEvent.LimitDelayMS = childNode.Attributes["MilliSeconds"].Value.ToInt();
                        newEvent.LimitDelayS = childNode.Attributes["Seconds"].Value.ToInt();
                        newEvent.LimitDelayM = childNode.Attributes["Minutes"].Value.ToInt();
                        newEvent.LimitDelayH = childNode.Attributes["Hours"].Value.ToInt();
                        break;
                    case "DELAY":
                        newEvent.DelayMS = childNode.Attributes["MilliSeconds"].Value.ToInt();
                        newEvent.DelayS = childNode.Attributes["Seconds"].Value.ToInt();
                        newEvent.DelayM = childNode.Attributes["Minutes"].Value.ToInt();
                        newEvent.DelayH = childNode.Attributes["Hours"].Value.ToInt();
                        break;
                    case "CLICKLIST":

                        if (childNode.Attributes.GetNamedItem("Points").IsSomething())
                        {
                            newEvent.Points = childNode.Attributes["Points"].Value.ToInt();
                        }

                        ColorConverter Converter = new ColorConverter();
                        foreach (XmlNode Click in childNode.ChildNodes)
                        {
                            int ChildX = Click.Attributes["X"].Value.ToInt();
                            int ChildY = Click.Attributes["Y"].Value.ToInt();
                            String ChildColor = Click.Attributes["Color"].Value;

                            SingleClick ChildSC = new SingleClick();
                            ChildSC.X = ChildX;
                            ChildSC.Y = ChildY;

                            ChildSC.Color = ColorTranslator.FromHtml(ChildColor);

                            newEvent.ClickList.Add(ChildSC);
                        }
                        break;
                    case "PICTURE":
                        String PictureFileName = childNode.Attributes["FileName"].Value;


                        String PictureFullPath = Path.Combine(Path.GetDirectoryName(gameNode.FileName), "Pictures", PictureFileName);

                        if (System.IO.File.Exists(PictureFullPath))
                        {
                            if (loadBitmaps)
                            {
                                newEvent.Bitmap = Bitmap.FromFile(PictureFullPath) as Bitmap;
                            }
                            newEvent.FileName = PictureFileName;
                        }
                        else
                        {
                            Debug.WriteLine("filenot found:" + PictureFullPath);
                        }

                        if (childNode.Attributes.GetNamedItem("ResolutionHeight").IsSomething())
                        {
                            newEvent.ResolutionHeight = childNode.Attributes["ResolutionHeight"].Value.ToInt();
                        }
                        if (childNode.Attributes.GetNamedItem("ResolutionWidth").IsSomething())
                        {
                            newEvent.ResolutionWidth = childNode.Attributes["ResolutionWidth"].Value.ToInt();
                        }

                        break;
                    case "EVENTS":
                        LoadEvents(childNode, gameNode, newEvent, lst, loadBitmaps);
                        break;
                    case "RNG":
                        //NewEvent.AutoBalance = childnode.Attributes["AutoBalance"].Value
                        LoadEvents(childNode, gameNode, newEvent, lst, loadBitmaps);
                        break;
                    case "OBJECTSEARCH":
                        if (childNode.Attributes.GetNamedItem("ObjectName").IsSomething())
                        {
                            newEvent.ObjectName = childNode.Attributes["ObjectName"].Value;
                            lst.Add(newEvent);
                        }

                        if (childNode.Attributes.GetNamedItem("Threshold").IsSomething())
                        {
                            newEvent.ObjectThreshold = childNode.Attributes["Threshold"].Value.ToLong();
                        }

                        if (childNode.Attributes.GetNamedItem("Channel").IsSomething())
                        {
                            String Channel = childNode.Attributes["Channel"].Value;
                            switch (Channel.ToUpper())
                            {
                                case "Red":
                                    newEvent.Channel = "Red";
                                    break;
                                case "Green":
                                    newEvent.Channel = "Green";
                                    break;
                                case "Blue":
                                    newEvent.Channel = "Blue";
                                    break;

                                default:
                                    Debug.WriteLine("Unexpected GameNodeGame.LoadEvent.Channel {0}", childNode.Attributes["Channel"].Value);
                                    newEvent.Channel = "Red";
                                    break;
                            }

                        }


                        //< ObjectSearch ObjectName = "You Got:" Channel = "Blue" Threshold = "70" >
                        //       < Rectangle X = "164" Y = "471" Height = "156" Width = "446" />
                        //</ ObjectSearch >
                        if (childNode.ChildNodes.Count > 0)
                        {
                            XmlNode objectChildNode = childNode.ChildNodes[0];
                            int objectChildNodex = objectChildNode.Attributes["X"].Value.ToInt();
                            int objectChildNodey = objectChildNode.Attributes["Y"].Value.ToInt();
                            int objectChildNodeHeight = objectChildNode.Attributes["Height"].Value.ToInt();
                            int objectChildNodeWidth = objectChildNode.Attributes["Width"].Value.ToInt();
                            newEvent.Rectangle = new Rectangle(objectChildNodex, objectChildNodey, objectChildNodeWidth, objectChildNodeHeight);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void LoadAction(XmlNode ActionNode, GameNodeGame GameNode, GameNodeAction TreeActionNode, List<GameNodeAction> lst, Boolean LoadBitmaps)
        {
            String ActionName = "";

            if (ActionNode.Attributes.GetNamedItem("Name").IsSomething())
            {
                ActionName = ActionNode.Attributes["Name"].Value;
            }

            Boolean UseParentPicture = false;
            if (ActionNode.Attributes.GetNamedItem("UseParentPicture").IsSomething())
            {
                UseParentPicture = Convert.ToBoolean(ActionNode.Attributes["UseParentPicture"].Value);
            }

            if (ActionNode.Attributes.GetNamedItem("AfterCompletionType").IsSomething())
            {
                switch (ActionNode.Attributes["AfterCompletionType"].Value)
                {
                    case "Home":
                        TreeActionNode.AfterCompletionType = AfterCompletionType.Home;
                        break;
                    case "Continue":
                        TreeActionNode.AfterCompletionType = AfterCompletionType.Continue;
                        break;
                    case "Parent":
                        TreeActionNode.AfterCompletionType = AfterCompletionType.Parent;
                        break;
                    case "Stop":
                        TreeActionNode.AfterCompletionType = AfterCompletionType.Stop;
                        break;
                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.AfterCompletionType {0}", ActionNode.Attributes["AfterCompletionType"].Value);
                        break;
                }
            }
            else
            {
                TreeActionNode.AfterCompletionType = AfterCompletionType.Continue;
            }

            if (ActionNode.Attributes.GetNamedItem("IsRelativeStart").IsSomething())
            {
                Boolean IsRelativeStart = Convert.ToBoolean(ActionNode.Attributes["IsRelativeStart"].Value);
                TreeActionNode.IsRelativeStart = IsRelativeStart;
            }

            if (ActionNode.Attributes.GetNamedItem("DragTargetMode").IsSomething())
            {
                String DragTargetMode = ActionNode.Attributes["DragTargetMode"].Value;
                switch (DragTargetMode)
                {
                    case "Absolute":
                        TreeActionNode.DragTargetMode = AppTestStudio.DragTargetMode.Absolute;
                        break;
                    case "Relative":
                        TreeActionNode.DragTargetMode = AppTestStudio.DragTargetMode.Relative;
                        break;
                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.DragTargetMode {0}", ActionNode.Attributes["DragTargetMode"].Value);
                        break;
                }
            }

            if (ActionNode.Attributes.GetNamedItem("RelativeXOffset").IsSomething())
            {
                long RelativeXOffset = Convert.ToInt64(ActionNode.Attributes["RelativeXOffset"].Value);
                TreeActionNode.RelativeXOffset = RelativeXOffset;
            }

            if (ActionNode.Attributes.GetNamedItem("RelativeYOffset").IsSomething())
            {
                long RelativeYOffset = Convert.ToInt64(ActionNode.Attributes["RelativeYOffset"].Value);
                TreeActionNode.RelativeYOffset = RelativeYOffset;
            }

            if (ActionNode.Attributes.GetNamedItem("Mode").IsSomething())
            {
                switch (ActionNode.Attributes["Mode"].Value)
                {
                    case "RangeClick":
                        TreeActionNode.Mode = Mode.RangeClick;
                        break;
                    case "ClickDragRelease":
                        TreeActionNode.Mode = Mode.ClickDragRelease;
                        break;
                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.Mode {0}", ActionNode.Attributes["Mode"].Value);
                        TreeActionNode.Mode = Mode.RangeClick;
                        break;
                }
            }

            if (ActionNode.Attributes.GetNamedItem("IsLimited").IsSomething())
            {
                TreeActionNode.IsLimited = Convert.ToBoolean(ActionNode.Attributes["IsLimited"].Value);
            }

            if (ActionNode.Attributes.GetNamedItem("IsWaitFirst").IsSomething())
            {
                TreeActionNode.IsWaitFirst = Convert.ToBoolean(ActionNode.Attributes["IsWaitFirst"].Value);
            }

            if (ActionNode.Attributes.GetNamedItem("ExecutionLimit").IsSomething())
            {
                String ExecutionLimit = ActionNode.Attributes["ExecutionLimit"].Value;
                if (ExecutionLimit.IsNumeric())
                {
                    TreeActionNode.ExecutionLimit = Convert.ToInt64(ExecutionLimit);
                }
                else
                {
                    TreeActionNode.ExecutionLimit = 1;
                }
            }

            if (ActionNode.Attributes.GetNamedItem("WaitType").IsSomething())
            {
                switch (ActionNode.Attributes["WaitType"].Value)
                {
                    case "Iteration":
                        TreeActionNode.WaitType = WaitType.Iteration;
                        break;
                    case "Time":
                        TreeActionNode.WaitType = WaitType.Time;
                        break;
                    case "Session":
                        TreeActionNode.WaitType = WaitType.Session;
                        break;
                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.WaitType {0}", ActionNode.Attributes["WaitType"].Value);
                        TreeActionNode.WaitType = WaitType.Iteration;
                        break;
                }
            }

            if (ActionNode.Attributes.GetNamedItem("LimitRepeats").IsSomething())
            {
                switch (ActionNode.Attributes["LimitRepeats"].Value.ToUpper())
                {
                    case "TRUE":
                        TreeActionNode.LimitRepeats = true;
                        break;
                    case "FALSE":
                        TreeActionNode.LimitRepeats = false;
                        break;

                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.LimitRepeats {0}", ActionNode.Attributes["LimitRepeats"].Value);
                        TreeActionNode.LimitRepeats = false;
                        break;
                }
            }

            Boolean AutoBalanceAttribue = false;
            if (ActionNode.Attributes.GetNamedItem("AutoBalance").IsSomething())
            {
                AutoBalanceAttribue = Convert.ToBoolean(ActionNode.Attributes["AutoBalance"].Value);
            }
            TreeActionNode.AutoBalance = AutoBalanceAttribue;


            TreeActionNode.GameNodeName = ActionName;

            TreeActionNode.UseParentPicture = UseParentPicture;

            foreach (XmlNode ActionNodeChildNode in ActionNode.ChildNodes)
            {
                switch (ActionNodeChildNode.Name.ToUpper())
                {
                    case "LimitDelay":
                        TreeActionNode.LimitDelayMS = Convert.ToInt32(ActionNodeChildNode.Attributes["MilliSeconds"].Value);
                        TreeActionNode.LimitDelayS = Convert.ToInt32(ActionNodeChildNode.Attributes["Seconds"].Value);
                        TreeActionNode.LimitDelayM = Convert.ToInt32(ActionNodeChildNode.Attributes["Minutes"].Value);
                        TreeActionNode.LimitDelayH = Convert.ToInt32(ActionNodeChildNode.Attributes["Hours"].Value);
                        break;
                    case "Delay":
                        TreeActionNode.DelayMS = Convert.ToInt32(ActionNodeChildNode.Attributes["MilliSeconds"].Value);
                        TreeActionNode.DelayS = Convert.ToInt32(ActionNodeChildNode.Attributes["Seconds"].Value);
                        TreeActionNode.DelayM = Convert.ToInt32(ActionNodeChildNode.Attributes["Minutes"].Value);
                        TreeActionNode.DelayH = Convert.ToInt32(ActionNodeChildNode.Attributes["Hours"].Value);
                        break;
                    case "Rectangle":
                        int Rectanglex = ActionNodeChildNode.Attributes["X"].Value.ToInt();
                        int Rectangley = ActionNodeChildNode.Attributes["Y"].Value.ToInt();
                        int RectangleHeight = ActionNodeChildNode.Attributes["Height"].Value.ToInt();
                        int RectangleWidth = ActionNodeChildNode.Attributes["Width"].Value.ToInt();
                        TreeActionNode.Rectangle = new Rectangle(Rectanglex, Rectangley, RectangleWidth, RectangleHeight);
                        break;
                    case "Picture":
                        String ActionNodeFileName = ActionNodeChildNode.Attributes["FileName"].Value;

                        String ActionNodeFullPath = Path.Combine(Path.GetDirectoryName(GameNode.FileName), "Pictures", ActionNodeFileName);

                        if (System.IO.File.Exists(ActionNodeFullPath))
                        {
                            if (LoadBitmaps)
                            {
                                TreeActionNode.Bitmap = Bitmap.FromFile(ActionNodeFullPath) as Bitmap;
                            }
                            TreeActionNode.FileName = ActionNodeFileName;
                        }
                        else
                        {
                            Debug.WriteLine("filenot found:" + ActionNodeFullPath);
                        }

                        if (ActionNodeChildNode.Attributes.GetNamedItem("ResolutionHeight").IsSomething())
                        {
                            TreeActionNode.ResolutionHeight = ActionNodeChildNode.Attributes["ResolutionHeight"].Value.ToInt();
                        }
                        if (ActionNodeChildNode.Attributes.GetNamedItem("ResolutionWidth").IsSomething())
                        {
                            TreeActionNode.ResolutionWidth = ActionNodeChildNode.Attributes["ResolutionWidth"].Value.ToInt();
                        }
                        break;
                    case "RNG":
                        GameNodeAction rngAction = new GameNodeAction("", ActionType.RNG);
                        rngAction.Percentage = ActionNodeChildNode.Attributes["Percentage"].Value.ToInt();
                        TreeActionNode.Nodes.Add(rngAction);

                        LoadEvents(ActionNodeChildNode.FirstChild, GameNode, rngAction, lst, LoadBitmaps);
                        break;
                    case "Events":
                        LoadEvents(ActionNodeChildNode, GameNode, TreeActionNode, lst, LoadBitmaps);
                        break;
                    default:
                        break;
                }

            }
        }

    }
}
