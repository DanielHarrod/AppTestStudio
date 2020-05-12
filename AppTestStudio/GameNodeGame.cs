// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

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
using System.Windows.Forms;
using System.Xml;

namespace AppTestStudio
{
    public class GameNodeGame : GameNode
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
            InstanceToLaunch = "0";
            VideoFrameLimit = 2000;
            DefaultClickSpeed = 0;

            IsPaused = false;

        }

        public ConcurrentQueue<String> ThreadLog { get; set; }
        public ConcurrentQueue<AppTestStudioStatusControlItem> StatusControl { get; set; }

        public ConcurrentQueue<Bitmap> BitmapClones { get; set; }

        public ConcurrentQueue<MinimalBitmapNode> MinimalBitmapClones { get; set; }

        public OpenCvSharp.VideoWriter Video { get; set; }
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

        public void LogStatus(int item, long time)
        {
            AppTestStudioStatusControlItem StatusControlItem = new AppTestStudioStatusControlItem();
            StatusControlItem.Index = item;
            StatusControlItem.Time = time;
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

        private String mInstanceToLaunch;
        public String InstanceToLaunch
        {
            get { return mInstanceToLaunch; }
            set
            {
                if (value == "")
                {
                    value = "0";
                }
                mInstanceToLaunch = value;
            }
        }


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

        public int DefaultClickSpeed { get; set; }

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
            Target.DefaultClickSpeed = DefaultClickSpeed;

            Target.Nodes.Add(TargetEvents);

            return Target;
        }

        public GameNodeAction ThreadLastNodeAction { get; set; }
        public GameNodeAction ThreadLastNodeEvent { get; set; }
        public GameNodeAction AbsoluteLastNode { get; set; }

        public long ScreenShotsTaken { get; set; }
        public long VideoFrameLimit { get; set; }
        public Boolean SaveVideo { get; set; }

        public static GameNodeGame LoadGameFromFile(String fileName, Boolean loadBitmaps)
        {

            GameNodeGame Game = null;
            XmlDocument Document = new XmlDocument();
            Document.Load(fileName);

            if (Document.DocumentElement.SelectSingleNode("//App").IsSomething())
            {
                XmlNode ChildNode = Document.DocumentElement.SelectSingleNode("//App");
                Game = LoadGame(ChildNode, fileName, "", loadBitmaps);
            }

            return Game;
        }

        public static GameNodeGame LoadGame(XmlNode childNode, String fileName, String overrideGameName, Boolean loadBitmaps)
        {
            String GameName = childNode.Attributes["Name"].Value;
            if (overrideGameName.Length > 0)
            {
                GameName = overrideGameName;
            }

            String TargetGameBuild = childNode.Attributes["TargetGameBuild"].Value;

            String PackageName = "";
            long LoopDelay = 1000;
            String Resolution = "1024x768";
            Boolean SaveVideo = false;
            long VideoFrameLimit = 2000;
            String LaunchInstance = "";
            int DefaultClickSpeed = 0;

            if (childNode.Attributes.GetNamedItem("PackageName").IsSomething())
            {
                PackageName = childNode.Attributes["PackageName"].Value;
            }

            if (childNode.Attributes.GetNamedItem("DefaultClickSpeed").IsSomething())
            {
                try
                {
                    DefaultClickSpeed = Convert.ToInt32(childNode.Attributes["DefaultClickSpeed"].Value);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.Assert(false);//shoudl never happen.
                }
            }

            if (childNode.Attributes.GetNamedItem("SaveVideo").IsSomething())
            {
                SaveVideo = Convert.ToBoolean(childNode.Attributes["SaveVideo"].Value);
            }

            if (childNode.Attributes.GetNamedItem("LaunchInstance").IsSomething())
            {
                LaunchInstance = childNode.Attributes["LaunchInstance"].Value;
            }

            if (childNode.Attributes.GetNamedItem("LoopDelay").IsSomething())
            {
                LoopDelay = Convert.ToInt64(childNode.Attributes["LoopDelay"].Value);
            }

            if (childNode.Attributes.GetNamedItem("Resolution").IsSomething())
            {
                Resolution = childNode.Attributes["Resolution"].Value;
            }

            if (childNode.Attributes.GetNamedItem("VideoFrameLimit").IsSomething())
            {
                VideoFrameLimit = Convert.ToInt64(childNode.Attributes["VideoFrameLimit"].Value);
            }

            GameNodeGame Game = new GameNodeGame(GameName);
            Game.TargetGameBuild = TargetGameBuild;
            Game.PackageName = PackageName;

            Game.InstanceToLaunch = LaunchInstance;
            Game.Resolution = Resolution;
            Game.LoopDelay = LoopDelay;
            Game.FileName = fileName;
            Game.SaveVideo = SaveVideo;
            Game.VideoFrameLimit = VideoFrameLimit;
            Game.DefaultClickSpeed = DefaultClickSpeed;

            GameNodeEvents Events = new GameNodeEvents("Events");
            Game.Nodes.Add(Events);

            List<GameNodeAction> ActionNodesWithObjects = new List<GameNodeAction>();
            LoadEvents(childNode.FirstChild, Game, Events, ActionNodesWithObjects, loadBitmaps);

            GameNodeObjects Objects = new GameNodeObjects("Objects");
            Game.Nodes.Add(Objects);

            if (childNode.ChildNodes.Count > 1)
            {
                LoadObjects(childNode.ChildNodes[1], Objects, GameName, ActionNodesWithObjects, Game);
            }

            return Game;
        }

        public ExportGameResults SaveGame(XmlWriter Writer, ThreadManager threadManger, TreeView tv, Boolean UseMinimalSavingMethods)
        {
            ExportGameResults Results = new ExportGameResults();

            // 0 is always workspace node.
            GameNodeWorkspace WorkspaceNode = tv.Nodes[0] as GameNodeWorkspace;

            String Directory = System.IO.Path.Combine(Path.GetDirectoryName(FileName), "Pictures");
            if (System.IO.Directory.Exists(Directory))
            {
                // do nothing
            }
            else
            {
                System.IO.Directory.CreateDirectory(Directory);
            }

            Writer.WriteStartElement("App");
            Writer.WriteAttributeString("Name", Text);
            Writer.WriteAttributeString("TargetGameBuild", TargetGameBuild);
            Writer.WriteAttributeString("PackageName", PackageName);
            Writer.WriteAttributeString("LaunchInstance", InstanceToLaunch);
            Writer.WriteAttributeString("LoopDelay", LoopDelay.ToString());
            //'Writer.WriteAttributeString("FileName", Game.FileName);
            Writer.WriteAttributeString("Resolution", Resolution);
            Writer.WriteAttributeString("SaveVideo", SaveVideo.ToString());
            Writer.WriteAttributeString("VideoFrameLimit", VideoFrameLimit.ToString());
            Writer.WriteAttributeString("DefaultClickSpeed", DefaultClickSpeed.ToString());

            GameNode Events = Nodes[0] as GameNode;

            SaveEvents(Writer, WorkspaceNode, this, Events, Directory, UseMinimalSavingMethods, Results.PictureListExtract);
            if (Nodes.Count > 1)
            {
                // Objects is always 1
                GameNodeObjects Objects = Nodes[1] as GameNodeObjects;
                Results.ObjectListExtract = SaveObjects(Writer, WorkspaceNode, this, Objects, Directory);
            }
            Writer.WriteEndElement();

            threadManger.IncrementTestSaved();

            return Results;

        }

        private void SaveEvents(XmlWriter Writer, GameNodeWorkspace Workspace, GameNodeGame Game, GameNode ActionOrEvent, string Directory, Boolean UseMinimalSavingMethods, List<String> PictureListExtract)
        {
            Writer.WriteStartElement("Events");

            foreach (GameNodeAction Activites in ActionOrEvent.Nodes)
            {
                switch (Activites.ActionType)
                {
                    case ActionType.Action:
                        Writer.WriteStartElement("Action");
                        Writer.WriteAttributeString("Name", Activites.Name);
                        if (Activites.Enabled == false)
                        {
                            Writer.WriteAttributeString("IsEnabled", "False");
                        }

                        //' Writer.WriteAttributeString("ActionType", Activites.ActionType)
                        Writer.WriteAttributeString("UseParentPicture", Activites.UseParentPicture.ToString());
                        Writer.WriteAttributeString("AfterCompletionType", Activites.AfterCompletionType.ToString());
                        Writer.WriteAttributeString("Mode", Activites.Mode.ToString());

                        Writer.WriteAttributeString("ClickSpeed", Activites.ClickSpeed.ToString());

                        Writer.WriteAttributeString("RelativeXOffset", Activites.RelativeXOffset.ToString());
                        Writer.WriteAttributeString("RelativeYOffset", Activites.RelativeYOffset.ToString());

                        if (Activites.Mode == Mode.ClickDragRelease)
                        {
                            Writer.WriteStartElement("ClickDragRelease");
                            Writer.WriteAttributeString("Mode", Activites.ClickDragReleaseMode.ToString());
                            Writer.WriteAttributeString("Velocity", Activites.ClickDragReleaseVelocity.ToString());
                            Writer.WriteAttributeString("StartHeight", Activites.ClickDragReleaseStartHeight.ToString());
                            Writer.WriteAttributeString("StartWidth", Activites.ClickDragReleaseStartWidth.ToString());
                            Writer.WriteAttributeString("EndHeight", Activites.ClickDragReleaseEndHeight.ToString());
                            Writer.WriteAttributeString("EndWidth", Activites.ClickDragReleaseEndWidth.ToString());
                            //'ClickDragRelease
                            Writer.WriteEndElement();
                        }

                        Writer.WriteStartElement("Delay");
                        Writer.WriteAttributeString("MilliSeconds", Activites.DelayMS.ToString());
                        Writer.WriteAttributeString("Seconds", Activites.DelayS.ToString());
                        Writer.WriteAttributeString("Minutes", Activites.DelayM.ToString());
                        Writer.WriteAttributeString("Hours", Activites.DelayH.ToString());
                        //'Delay
                        Writer.WriteEndElement();

                        Writer.WriteStartElement("LimitDelay");
                        Writer.WriteAttributeString("MilliSeconds", Activites.LimitDelayMS.ToString());
                        Writer.WriteAttributeString("Seconds", Activites.LimitDelayS.ToString());
                        Writer.WriteAttributeString("Minutes", Activites.LimitDelayM.ToString());
                        Writer.WriteAttributeString("Hours", Activites.LimitDelayH.ToString());

                        //'/LimitDelay
                        Writer.WriteEndElement();

                        if (Activites.Rectangle.IsEmpty == false)
                        {
                            Writer.WriteStartElement("Rectangle");
                            Writer.WriteAttributeString("X", Activites.Rectangle.X.ToString());
                            Writer.WriteAttributeString("Y", Activites.Rectangle.Y.ToString());
                            Writer.WriteAttributeString("Height", Activites.Rectangle.Height.ToString());
                            Writer.WriteAttributeString("Width", Activites.Rectangle.Width.ToString());

                            //'rectanble
                            Writer.WriteEndElement();
                        }

                        if (Activites.Nodes.Count > 0)
                        {
                            //'Writer.WriteStartElement("Events")

                            SaveEvents(Writer, Workspace, Game, Activites, Directory, UseMinimalSavingMethods, PictureListExtract);

                            //' events
                            //'Writer.WriteEndElement()
                        }
                        Writer.WriteStartElement("Picture");
                        Writer.WriteAttributeString("ResolutionWidth", Activites.ResolutionWidth.ToString());
                        Writer.WriteAttributeString("ResolutionHeight", Activites.ResolutionHeight.ToString());

                        if (UseMinimalSavingMethods)
                        {
                            Writer.WriteAttributeString("FileName", "");
                        }
                        else
                        {
                            Writer.WriteAttributeString("FileName", Activites.FileName);
                        }

                        if (Activites.FileName.IsNothing())
                        {
                            //' do nothing
                        }
                        else
                        {
                            String ActionNodeFullPath = Path.Combine(Path.GetDirectoryName(Game.FileName), "Pictures", Activites.FileName);

                            PictureListExtract.Add(ActionNodeFullPath);
                            if (System.IO.File.Exists(ActionNodeFullPath))
                            {
                                //'do nothing
                            }
                            else
                            {
                                Activites.Bitmap.Save(ActionNodeFullPath);
                            }
                        }

                        //'Picture
                        Writer.WriteEndElement();

                        //'Action
                        Writer.WriteEndElement();
                        break;
                    case ActionType.Event:
                        Writer.WriteStartElement("Event");
                        Writer.WriteAttributeString("Name", Activites.Name);
                        if (Activites.Enabled == false)
                        {
                            Writer.WriteAttributeString("IsEnabled", "False");
                        }

                        Writer.WriteAttributeString("LogicChoice", Activites.LogicChoice);

                        if (Activites.LogicChoice == "CUSTOM")
                        {
                            Writer.WriteAttributeString("CustomLogic", Activites.CustomLogic);
                        }

                        Writer.WriteAttributeString("UseParentPicture", Activites.UseParentPicture.ToString());
                        //'Writer.WriteAttributeString("DelayMS", Activites.DelayMS)
                        Writer.WriteAttributeString("AfterCompletionType", Activites.AfterCompletionType.ToString());

                        Writer.WriteAttributeString("IsLimited", Activites.IsLimited.ToString());
                        Writer.WriteAttributeString("IsWaitFirst", Activites.IsWaitFirst.ToString());
                        Writer.WriteAttributeString("ExecutionLimit", Activites.ExecutionLimit.ToString());
                        Writer.WriteAttributeString("LimitRepeats", Activites.LimitRepeats.ToString());

                        switch (Activites.WaitType)
                        {
                            case AppTestStudio.WaitType.Iteration:
                                Writer.WriteAttributeString("WaitType", "Iteration");
                                break;
                            case AppTestStudio.WaitType.Time:
                                Writer.WriteAttributeString("WaitType", "Time");
                                break;
                            case AppTestStudio.WaitType.Session:
                                Writer.WriteAttributeString("WaitType", "Session");
                                break;
                            default:
                                Writer.WriteAttributeString("WaitType", "Iteration");
                                break;
                        }

                        Writer.WriteAttributeString("IsColorPoint", Activites.IsColorPoint.ToString());
                        Writer.WriteAttributeString("Repeats", Activites.RepeatsUntilFalse.ToString());
                        Writer.WriteAttributeString("RepeatsLimit", Activites.RepeatsUntilFalseLimit.ToString());

                        Writer.WriteStartElement("Delay");
                        Writer.WriteAttributeString("MilliSeconds", Activites.DelayMS.ToString());
                        Writer.WriteAttributeString("Seconds", Activites.DelayS.ToString());
                        Writer.WriteAttributeString("Minutes", Activites.DelayM.ToString());
                        Writer.WriteAttributeString("Hours", Activites.DelayH.ToString());

                        //'Delay
                        Writer.WriteEndElement();

                        Writer.WriteStartElement("LimitDelay");
                        Writer.WriteAttributeString("MilliSeconds", Activites.LimitDelayMS.ToString());
                        Writer.WriteAttributeString("Seconds", Activites.LimitDelayS.ToString());
                        Writer.WriteAttributeString("Minutes", Activites.LimitDelayM.ToString());
                        Writer.WriteAttributeString("Hours", Activites.LimitDelayH.ToString());

                        //'/LimitDelay
                        Writer.WriteEndElement();

                        Writer.WriteStartElement("ClickList");
                        Writer.WriteAttributeString("Points", Activites.Points.ToString());

                        foreach (SingleClick Click in Activites.ClickList)
                        {
                            Writer.WriteStartElement("Click");
                            Writer.WriteAttributeString("X", Click.X.ToString());
                            Writer.WriteAttributeString("Y", Click.Y.ToString());
                            Writer.WriteAttributeString("Color", Click.Color.ToHex());

                            //'Click
                            Writer.WriteEndElement();
                        }


                        //'ClickList
                        Writer.WriteEndElement();

                        //'Picture
                        Writer.WriteStartElement("Picture");

                        if (UseMinimalSavingMethods)
                        {
                            Writer.WriteAttributeString("FileName", "");
                        }
                        else
                        {
                            Writer.WriteAttributeString("FileName", Activites.FileName);
                        }

                        Writer.WriteAttributeString("ResolutionWidth", Activites.ResolutionWidth.ToString());
                        Writer.WriteAttributeString("ResolutionHeight", Activites.ResolutionHeight.ToString());
                        if (Activites.FileName.IsNothing())
                        {
                            //' do nothing
                        }
                        else
                        {
                            String FullPath = Path.Combine(Path.GetDirectoryName(Game.FileName), "Pictures", Activites.FileName);

                            if (System.IO.File.Exists(FullPath))
                            {
                                //'do nothing
                                PictureListExtract.Add(FullPath);
                            }
                            else
                            {
                                if (Activites.Bitmap.IsSomething())
                                {
                                    Activites.Bitmap.Save(FullPath);
                                    PictureListExtract.Add(FullPath);
                                }
                                else
                                {
                                    Debug.WriteLine("Activites.Bitmap is nothing");
                                }
                            }
                        }

                        //'/picture
                        Writer.WriteEndElement();

                        if (Activites.IsColorPoint == false)
                        {


                            //'ObjectSearch
                            Writer.WriteStartElement("ObjectSearch");
                            Writer.WriteAttributeString("ObjectName", Activites.ObjectName);
                            Writer.WriteAttributeString("Channel", Activites.Channel);
                            Writer.WriteAttributeString("Threshold", Activites.ObjectThreshold.ToString());

                            if (Activites.Rectangle.IsEmpty == false)
                            {
                                Writer.WriteStartElement("Rectangle");
                                Writer.WriteAttributeString("X", Activites.Rectangle.X.ToString());
                                Writer.WriteAttributeString("Y", Activites.Rectangle.Y.ToString());
                                Writer.WriteAttributeString("Height", Activites.Rectangle.Height.ToString());
                                Writer.WriteAttributeString("Width", Activites.Rectangle.Width.ToString());

                                //'rectanble
                                Writer.WriteEndElement();
                            }

                            Writer.WriteEndElement();
                            //'/ObjectSearch

                        }

                        if (Activites.Nodes.Count > 0)
                        {
                            //'Writer.WriteStartElement("Events")

                            SaveEvents(Writer, Workspace, Game, Activites, Directory, UseMinimalSavingMethods, PictureListExtract);

                            //' events
                            //'Writer.WriteEndElement()
                        }

                        //' EventNode.BitMap.Save(Workspace.WorkspaceFolder & "\" & EventNode.BitMap)


                        //'Event
                        Writer.WriteEndElement();
                        break;
                    case ActionType.RNG:
                        // Not done here, see RNGContainer for loop
                        break;
                    case ActionType.RNGContainer:
                        Writer.WriteStartElement("RNG-Container");

                        if (Activites.Enabled == false)
                        {
                            Writer.WriteAttributeString("IsEnabled", "False");
                        }
                        
                        Writer.WriteAttributeString("AutoBalance", Activites.AutoBalance.ToString());
                        Writer.WriteAttributeString("Name", Activites.Name.ToString());

                        //' Writer.WriteAttributeString("ActionType", Activites.ActionType)
                        Writer.WriteAttributeString("AfterCompletionType", Activites.AfterCompletionType.ToString());

                        Writer.WriteStartElement("Delay");
                        Writer.WriteAttributeString("MilliSeconds", Activites.DelayMS.ToString());
                        Writer.WriteAttributeString("Seconds", Activites.DelayS.ToString());
                        Writer.WriteAttributeString("Minutes", Activites.DelayM.ToString());
                        Writer.WriteAttributeString("Hours", Activites.DelayH.ToString());
                        //'Delay
                        Writer.WriteEndElement();

                        Writer.WriteStartElement("LimitDelay");
                        Writer.WriteAttributeString("MilliSeconds", Activites.LimitDelayMS.ToString());
                        Writer.WriteAttributeString("Seconds", Activites.LimitDelayS.ToString());
                        Writer.WriteAttributeString("Minutes", Activites.LimitDelayM.ToString());
                        Writer.WriteAttributeString("Hours", Activites.LimitDelayH.ToString());

                        //'/LimitDelay
                        Writer.WriteEndElement();

                        foreach (GameNodeAction RNGNode in Activites.Nodes)
                        {
                            Writer.WriteStartElement("RNG");
                            if (RNGNode.Enabled == false)
                            {
                                Writer.WriteAttributeString("IsEnabled", "False");
                            }

                            Writer.WriteAttributeString("Percentage", RNGNode.Percentage.ToString());
                            SaveEvents(Writer, Workspace, Game, RNGNode, Directory, UseMinimalSavingMethods, PictureListExtract);
                            Writer.WriteEndElement();
                        }


                        Writer.WriteEndElement();
                        break;
                    default:
                        break;
                }
            }
            //'Events
            Writer.WriteEndElement();

        }

        private List<String> SaveObjects(XmlWriter writer, GameNodeWorkspace workspaceNode, GameNodeGame gameNodeGame, GameNodeObjects objects, string directory)
        {
            List<String> ObjectList = new List<string>();
            writer.WriteStartElement("Objects");

            foreach (GameNodeObject O in objects.Nodes)
            {
                SaveObject(writer, workspaceNode, gameNodeGame, O, directory, ObjectList);
            }

            //'/Objects
            writer.WriteEndElement();

            return ObjectList;

        }

        private void SaveObject(XmlWriter writer, GameNodeWorkspace workspaceNode, GameNodeGame gameNodeGame, GameNodeObject obj, string directory, List<String> objectList)
        {
            writer.WriteStartElement("Object");

            writer.WriteAttributeString("Name", obj.GameNodeName);
            writer.WriteAttributeString("FileName", obj.FileName);

            String FullPath = Path.Combine(Path.GetDirectoryName(FileName), "Pictures", obj.FileName);

            if (System.IO.File.Exists(FullPath))
            {

                objectList.Add(FullPath);
            }
            else
            {
                if (obj.Bitmap.IsSomething())
                {
                    obj.Bitmap.Save(FullPath);
                    objectList.Add(FullPath);
                }
                else
                {
                    Debug.WriteLine("obj.Bitmap is nothing");
                }
            }


            //'/Object
            writer.WriteEndElement();
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
                                //Node.FileName = Path.GetFileName(FullPathP);
                            }
                            // Don't set Object Search filename to object search filename, --Node.FileName = Path.GetFileName(FullPathP);
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

        private static void LoadEvents(XmlNode eventsNode, GameNodeGame gameNode, GameNode treeEventNode, List<GameNodeAction> lst, Boolean loadBitmaps)
        {
            foreach (XmlNode ChildNode in eventsNode.ChildNodes)
            {
                switch (ChildNode.Name.ToUpper())
                {
                    case "EVENT":
                        GameNodeAction NewEvent = new GameNodeAction("New Node", ActionType.Event);
                        treeEventNode.Nodes.Add(NewEvent);
                        LoadEvent(ChildNode, gameNode, NewEvent, lst, loadBitmaps);
                        break;
                    case "ACTION":
                        GameNodeAction NewAction = new GameNodeAction("New Node", ActionType.Action);
                        treeEventNode.Nodes.Add(NewAction);
                        LoadAction(ChildNode, gameNode, NewAction, lst, loadBitmaps);
                        break;
                    case "RNG":
                        LoadAction(ChildNode, gameNode, treeEventNode as GameNodeAction, lst, loadBitmaps);
                        break;
                    case "RNG-CONTAINER":
                        GameNodeAction NewRNGContainer = new GameNodeAction("New Node", ActionType.RNGContainer);
                        treeEventNode.Nodes.Add(NewRNGContainer);
                        LoadAction(ChildNode, gameNode, NewRNGContainer, lst, loadBitmaps);
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
        }

        private static void LoadEvent(XmlNode eventNode, GameNodeGame gameNode, GameNodeAction newEvent, List<GameNodeAction> lst, bool loadBitmaps)
        {
            String EventName = eventNode.Attributes["Name"].Value;

            if (EventName == "White X")
            {
                int i = 1;
            }
            String LogicChoice = "";
            if (eventNode.Attributes.GetNamedItem("LogicChoice").IsSomething())
            {
                LogicChoice = eventNode.Attributes["LogicChoice"].Value.ToUpper();
            }

            if (LogicChoice == "CUSTOM")
            {
                if (eventNode.Attributes.GetNamedItem("CustomLogic").IsSomething())
                {
                    newEvent.CustomLogic = eventNode.Attributes["CustomLogic"].Value.ToUpper();
                }
            }

            Boolean UseParentPicture = false;
            if (eventNode.Attributes.GetNamedItem("UseParentPicture").IsSomething())
            {
                UseParentPicture = Convert.ToBoolean(eventNode.Attributes["UseParentPicture"].Value);
            }

            String AfterComletionType = "";
            if (eventNode.Attributes.GetNamedItem("AfterCompletionType").IsSomething())
            {
                AfterComletionType = eventNode.Attributes["AfterCompletionType"].Value;
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
                        Debug.WriteLine("Unexpected GameNodeGame.LoadEvent.AfterCompletionType {0}", eventNode.Attributes["AfterCompletionType"].Value);
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

            if (eventNode.Attributes.GetNamedItem("IsLimited").IsSomething())
            {
                newEvent.IsLimited = Convert.ToBoolean(eventNode.Attributes["IsLimited"].Value);
            }

            if (eventNode.Attributes.GetNamedItem("IsWaitFirst").IsSomething())
            {
                newEvent.IsWaitFirst = Convert.ToBoolean(eventNode.Attributes["IsWaitFirst"].Value);
            }

            if (eventNode.Attributes.GetNamedItem("ExecutionLimit").IsSomething())
            {
                String ExecutionLimit = eventNode.Attributes["ExecutionLimit"].Value;
                if (ExecutionLimit.IsNumeric())
                {
                    newEvent.ExecutionLimit = ExecutionLimit.ToLong();
                }
                else
                {
                    newEvent.ExecutionLimit = 1;
                }
            }

            if (eventNode.Attributes.GetNamedItem("WaitType").IsSomething())
            {
                String WaitType = eventNode.Attributes["WaitType"].Value;
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

            if (eventNode.Attributes.GetNamedItem("IsColorPoint").IsSomething())
            {
                Boolean IsColorPoint = Convert.ToBoolean(eventNode.Attributes["IsColorPoint"].Value);
                newEvent.IsColorPoint = IsColorPoint;
            }

            if (eventNode.Attributes.GetNamedItem("LimitRepeats").IsSomething())
            {
                switch (eventNode.Attributes["LimitRepeats"].Value.ToUpper())
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

            foreach (XmlNode childNode in eventNode.ChildNodes)
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

                        if (PictureFileName == "")
                        {
                            // do nothing
                        }
                        else
                        {
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
                                case "RED":
                                    newEvent.Channel = "Red";
                                    break;
                                case "GREEN":
                                    newEvent.Channel = "Green";
                                    break;
                                case "BLUE":
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


        private static void LoadAction(XmlNode actionNode, GameNodeGame gameNode, GameNodeAction treeActionNode, List<GameNodeAction> lst, Boolean loadBitmaps)
        {
            String ActionName = "";

            if (actionNode.Attributes.GetNamedItem("Name").IsSomething())
            {
                ActionName = actionNode.Attributes["Name"].Value;
            }




            Boolean UseParentPicture = false;
            if (actionNode.Attributes.GetNamedItem("UseParentPicture").IsSomething())
            {
                UseParentPicture = Convert.ToBoolean(actionNode.Attributes["UseParentPicture"].Value);
            }

            if (actionNode.Attributes.GetNamedItem("AfterCompletionType").IsSomething())
            {
                switch (actionNode.Attributes["AfterCompletionType"].Value)
                {
                    case "Home":
                        treeActionNode.AfterCompletionType = AfterCompletionType.Home;
                        break;
                    case "Continue":
                        treeActionNode.AfterCompletionType = AfterCompletionType.Continue;
                        break;
                    case "Parent":
                        treeActionNode.AfterCompletionType = AfterCompletionType.Parent;
                        break;
                    case "Stop":
                        treeActionNode.AfterCompletionType = AfterCompletionType.Stop;
                        break;
                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.AfterCompletionType {0}", actionNode.Attributes["AfterCompletionType"].Value);
                        break;
                }
            }
            else
            {
                treeActionNode.AfterCompletionType = AfterCompletionType.Continue;
            }

            if (actionNode.Attributes.GetNamedItem("RelativeXOffset").IsSomething())
            {
                int RelativeXOffset = Convert.ToInt32(actionNode.Attributes["RelativeXOffset"].Value);
                treeActionNode.RelativeXOffset = RelativeXOffset;
            }

            if (actionNode.Attributes.GetNamedItem("RelativeYOffset").IsSomething())
            {
                int RelativeYOffset = Convert.ToInt32(actionNode.Attributes["RelativeYOffset"].Value);
                treeActionNode.RelativeYOffset = RelativeYOffset;
            }

            if (actionNode.Attributes.GetNamedItem("Mode").IsSomething())
            {
                switch (actionNode.Attributes["Mode"].Value)
                {
                    case "RangeClick":
                        treeActionNode.Mode = Mode.RangeClick;
                        break;
                    case "ClickDragRelease":
                        treeActionNode.Mode = Mode.ClickDragRelease;
                        break;
                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.Mode {0}", actionNode.Attributes["Mode"].Value);
                        treeActionNode.Mode = Mode.RangeClick;
                        break;
                }
            }

            if (actionNode.Attributes.GetNamedItem("ClickSpeed").IsSomething())
            {
                int ClickSpeed = Convert.ToInt32(actionNode.Attributes["ClickSpeed"].Value);
                treeActionNode.ClickSpeed = ClickSpeed;
            }


            if (actionNode.Attributes.GetNamedItem("IsLimited").IsSomething())
            {
                treeActionNode.IsLimited = Convert.ToBoolean(actionNode.Attributes["IsLimited"].Value);
            }

            if (actionNode.Attributes.GetNamedItem("IsWaitFirst").IsSomething())
            {
                treeActionNode.IsWaitFirst = Convert.ToBoolean(actionNode.Attributes["IsWaitFirst"].Value);
            }

            if (actionNode.Attributes.GetNamedItem("ExecutionLimit").IsSomething())
            {
                String ExecutionLimit = actionNode.Attributes["ExecutionLimit"].Value;
                if (ExecutionLimit.IsNumeric())
                {
                    treeActionNode.ExecutionLimit = Convert.ToInt64(ExecutionLimit);
                }
                else
                {
                    treeActionNode.ExecutionLimit = 1;
                }
            }

            if (actionNode.Attributes.GetNamedItem("WaitType").IsSomething())
            {
                switch (actionNode.Attributes["WaitType"].Value)
                {
                    case "Iteration":
                        treeActionNode.WaitType = WaitType.Iteration;
                        break;
                    case "Time":
                        treeActionNode.WaitType = WaitType.Time;
                        break;
                    case "Session":
                        treeActionNode.WaitType = WaitType.Session;
                        break;
                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.WaitType {0}", actionNode.Attributes["WaitType"].Value);
                        treeActionNode.WaitType = WaitType.Iteration;
                        break;
                }
            }

            if (actionNode.Attributes.GetNamedItem("LimitRepeats").IsSomething())
            {
                switch (actionNode.Attributes["LimitRepeats"].Value.ToUpper())
                {
                    case "TRUE":
                        treeActionNode.LimitRepeats = true;
                        break;
                    case "FALSE":
                        treeActionNode.LimitRepeats = false;
                        break;

                    default:
                        Debug.WriteLine("Unexpected GameNodeGame.LoadAction.LimitRepeats {0}", actionNode.Attributes["LimitRepeats"].Value);
                        treeActionNode.LimitRepeats = false;
                        break;
                }
            }

            Boolean AutoBalanceAttribue = false;
            if (actionNode.Attributes.GetNamedItem("AutoBalance").IsSomething())
            {
                AutoBalanceAttribue = Convert.ToBoolean(actionNode.Attributes["AutoBalance"].Value);
            }
            treeActionNode.AutoBalance = AutoBalanceAttribue;

            treeActionNode.GameNodeName = ActionName;

            treeActionNode.UseParentPicture = UseParentPicture;

            foreach (XmlNode ActionNodeChildNode in actionNode.ChildNodes)
            {
                switch (ActionNodeChildNode.Name.ToUpper())
                {
                    case "CLICKDRAGRELEASE":
                        if (ActionNodeChildNode.Attributes.GetNamedItem("Mode").IsSomething())
                        {
                            switch (ActionNodeChildNode.Attributes["Mode"].Value.ToString().Trim().ToUpper())
                            {
                                case "NONE":
                                    treeActionNode.ClickDragReleaseMode = ClickDragReleaseMode.None;
                                    break;
                                case "START":
                                    treeActionNode.ClickDragReleaseMode = ClickDragReleaseMode.Start;
                                    break;
                                case "END":
                                    treeActionNode.ClickDragReleaseMode = ClickDragReleaseMode.End;
                                    break;
                                default:
                                    Debug.WriteLine("Unexpected:" + ActionNodeChildNode.Attributes["Mode"].Value.ToString().Trim().ToUpper());
                                    break;
                            }
                        }

                        if (ActionNodeChildNode.Attributes.GetNamedItem("StartHeight").IsSomething())
                        {
                            try
                            {
                                treeActionNode.ClickDragReleaseStartHeight = Convert.ToInt32(ActionNodeChildNode.Attributes["StartHeight"].Value);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("StartHeight:" + ex.Message);
                            }
                        }
                        if (ActionNodeChildNode.Attributes.GetNamedItem("EndHeight").IsSomething())
                        {
                            try
                            {
                                treeActionNode.ClickDragReleaseEndHeight = Convert.ToInt32(ActionNodeChildNode.Attributes["EndHeight"].Value);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("EndHeight:" + ex.Message);
                            }
                        }
                        if (ActionNodeChildNode.Attributes.GetNamedItem("StartWidth").IsSomething())
                        {
                            try
                            {
                                treeActionNode.ClickDragReleaseStartWidth = Convert.ToInt32(ActionNodeChildNode.Attributes["StartWidth"].Value);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("StartWidth:" + ex.Message);
                            }
                        }
                        if (ActionNodeChildNode.Attributes.GetNamedItem("EndWidth").IsSomething())
                        {
                            try
                            {
                                treeActionNode.ClickDragReleaseEndWidth = Convert.ToInt32(ActionNodeChildNode.Attributes["EndWidth"].Value);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("EndWidth:" + ex.Message);
                            }
                        }
                        if (ActionNodeChildNode.Attributes.GetNamedItem("Velocity").IsSomething())
                        {
                            try
                            {
                                treeActionNode.ClickDragReleaseVelocity = Convert.ToInt32(ActionNodeChildNode.Attributes["Velocity"].Value);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("Velocity:" + ex.Message);
                            }
                        }

                        break;
                    case "LIMITDELAY":
                        treeActionNode.LimitDelayMS = Convert.ToInt32(ActionNodeChildNode.Attributes["MilliSeconds"].Value);
                        treeActionNode.LimitDelayS = Convert.ToInt32(ActionNodeChildNode.Attributes["Seconds"].Value);
                        treeActionNode.LimitDelayM = Convert.ToInt32(ActionNodeChildNode.Attributes["Minutes"].Value);
                        treeActionNode.LimitDelayH = Convert.ToInt32(ActionNodeChildNode.Attributes["Hours"].Value);
                        break;
                    case "DELAY":
                        treeActionNode.DelayMS = Convert.ToInt32(ActionNodeChildNode.Attributes["MilliSeconds"].Value);
                        treeActionNode.DelayS = Convert.ToInt32(ActionNodeChildNode.Attributes["Seconds"].Value);
                        treeActionNode.DelayM = Convert.ToInt32(ActionNodeChildNode.Attributes["Minutes"].Value);
                        treeActionNode.DelayH = Convert.ToInt32(ActionNodeChildNode.Attributes["Hours"].Value);
                        break;
                    case "RECTANGLE":
                        int Rectanglex = ActionNodeChildNode.Attributes["X"].Value.ToInt();
                        int Rectangley = ActionNodeChildNode.Attributes["Y"].Value.ToInt();
                        int RectangleHeight = ActionNodeChildNode.Attributes["Height"].Value.ToInt();
                        int RectangleWidth = ActionNodeChildNode.Attributes["Width"].Value.ToInt();
                        treeActionNode.Rectangle = new Rectangle(Rectanglex, Rectangley, RectangleWidth, RectangleHeight);
                        break;
                    case "PICTURE":
                        String ActionNodeFileName = ActionNodeChildNode.Attributes["FileName"].Value;

                        String ActionNodeFullPath = Path.Combine(Path.GetDirectoryName(gameNode.FileName), "Pictures", ActionNodeFileName);

                        if (System.IO.File.Exists(ActionNodeFullPath))
                        {
                            if (loadBitmaps)
                            {
                                treeActionNode.Bitmap = Bitmap.FromFile(ActionNodeFullPath) as Bitmap;
                            }
                            treeActionNode.FileName = ActionNodeFileName;
                        }
                        else
                        {
                            Debug.WriteLine("filenot found:" + ActionNodeFullPath);
                        }

                        if (ActionNodeChildNode.Attributes.GetNamedItem("ResolutionHeight").IsSomething())
                        {
                            treeActionNode.ResolutionHeight = ActionNodeChildNode.Attributes["ResolutionHeight"].Value.ToInt();
                        }
                        if (ActionNodeChildNode.Attributes.GetNamedItem("ResolutionWidth").IsSomething())
                        {
                            treeActionNode.ResolutionWidth = ActionNodeChildNode.Attributes["ResolutionWidth"].Value.ToInt();
                        }
                        break;
                    case "RNG":
                        GameNodeAction rngAction = new GameNodeAction("", ActionType.RNG);
                        rngAction.Percentage = ActionNodeChildNode.Attributes["Percentage"].Value.ToInt();
                        treeActionNode.Nodes.Add(rngAction);

                        LoadEvents(ActionNodeChildNode.FirstChild, gameNode, rngAction, lst, loadBitmaps);
                        break;
                    case "EVENTS":
                        LoadEvents(ActionNodeChildNode, gameNode, treeActionNode, lst, loadBitmaps);
                        break;
                    default:
                        break;
                }

            }
            Utils.SetIcons(gameNode);
        }

        public GameNodeEvents GetEventsNode()
        {
            GameNode GameNode = GetGameNodeGame();
            foreach (GameNode node in GameNode.Nodes)
            {
                if (node is GameNodeEvents)
                {
                    return node as GameNodeEvents;
                }
            }
            return null;
        }
    }
}
