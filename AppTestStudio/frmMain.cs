using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AppTestStudio
{
    public partial class frmMain : Form
    {
        private enum PanelMode
        {
            Workspace,
            Games,
            Game,
            AddNewGame,
            Events,
            Actions,
            PanelColorEvent,
            Thread,
            TestAllEvents,
            Schedule,
            Objects,
            ObjectScreenshot,
            Object
        }


        public ThreadManager ThreadManager { get; set; }
        private GameNodeWorkspace WorkspaceNode { get; set; }
        private GameNode LastNode { get; set; }
        private Boolean IsPictureObjectScreenshotMouseDown = false;
        private Rectangle PictureObjectScreenshotRectanble = new Rectangle();


        private Boolean IsPanelLoading = false;
        private Boolean IsLoadingSchedule = false;

        private GameNodeAction PanelLoadNode;

        private int NoxInstances = -1;

        // Log buffer
        // Logging is stored here and updated on a textbox on a timer.  
        private StringBuilder sb = new StringBuilder();

        private Bitmap UndoScreenshot;

        private int PictureBox1X;
        private int PictureBox1Y;
        private Color PictureBox1Color;
        private Boolean PictureBox1MouseDown = false;

        private Schedule Schedule = new Schedule();

        public frmMain()
        {
            InitializeComponent();
            ThreadManager = new ThreadManager();
            sb = new StringBuilder();
            PictureObjectScreenshotRectanble = new Rectangle();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ThreadManager.Load();
            InitializeToolbars();


            WorkspaceNode = new GameNodeWorkspace("Apps");
            WorkspaceNode.WorkspaceFolder = Utils.GetApplicationFolder();
            tv.Nodes.Add(WorkspaceNode);
        }

        private void InitializeToolbars()
        {

            toolStripButtonStartEmmulator.Enabled = false;
            toolStripButtonStartEmmulatorLaunchApp.Enabled = false;
            toolStripButtonStartEmmulatorLaunchAppRunScript.Enabled = false;

            toolStripButtonRunScript.Enabled = false;
            toolStripButtonSaveScript.Enabled = false;
        }

        private void toolStripButtonToggleScript_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("TEst");
        }

        private void toolStripLoadScript_Click(object sender, EventArgs e)
        {
            if (tv.Nodes.Count > 0)
            {
                if (tv.Nodes[0].Nodes.Count > 0)
                {
                    frmLoadCheck LoadCheck = new frmLoadCheck();
                    LoadCheck.StartPosition = FormStartPosition.CenterParent;
                    LoadCheck.ShowDialog();

                    switch (LoadCheck.Result)
                    {
                        case frmLoadCheck.LoadCheckResult.Save:
                            SaveCurrentProject();
                            break;
                        case frmLoadCheck.LoadCheckResult.DontSave:
                            break;
                        case frmLoadCheck.LoadCheckResult.Cancel:
                            return;
                        case frmLoadCheck.LoadCheckResult.DefaultValue:
                            return;
                        default:
                            Debug.Assert(false);  //should not be here.
                            break;
                    }
                }
            }
            OpenFileDialog openDLG = new OpenFileDialog();
            openDLG.InitialDirectory = Utils.GetApplicationFolder();
            openDLG.Filter = "App Test Studio files|Default.xml";
            openDLG.RestoreDirectory = true;
            openDLG.Multiselect = false;

            DialogResult Result = openDLG.ShowDialog();
            if (Result == DialogResult.OK)
            {
                String FileName = openDLG.FileName;
                GameNodeGame Game = GameNodeGame.LoadGameFromFile(FileName, true);

                if (Game.IsSomething())
                {
                    LoadGameToTree(Game);
                }
            }
        }

        private void LoadGameToTree(GameNodeGame game)
        {
            ThreadManager.IncrementTestLoaded();
            GameNode gt = WorkspaceNode;

            gt.Nodes.Clear();

            gt.Nodes.Add(game);

            game.EnsureVisible();
            game.ExpandAll();
            LastNode = game;
            tv.SelectedNode = game;
            tv_AfterSelect(null, new TreeViewEventArgs(game));
            tabTree.SelectedIndex = 0;

            Log("Loaded Script: " + game.GameNodeName);




        }

        private void SaveCurrentProject()
        {
            throw new NotImplementedException();
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public void Log(String s)
        {
            int index = txtLog.SelectionStart;
            sb.Insert(0, s + System.Environment.NewLine);
            if (sb.Length > 10000)
            {
                sb.Remove(9700, 300);
            }
            txtLog.Text = sb.ToString();
            txtLog.SelectionStart = index;

        }

        private void toolStripButtonSaveScript_Click(object sender, EventArgs e)
        {
            GameNode CurrentNode = tv.SelectedNode as GameNode;
            while (CurrentNode.GameNodeType != GameNodeType.Game && CurrentNode.GameNodeType != GameNodeType.Games && CurrentNode.GameNodeType != GameNodeType.Workspace)
            {
                CurrentNode = CurrentNode.Parent as GameNode;
            }

            if (CurrentNode.GameNodeType == GameNodeType.Game)
            {
                GameNodeGame GameNode = CurrentNode as GameNodeGame;

                // Make Backup folder if necessary.
                String Directory = System.IO.Path.Combine(WorkspaceNode.WorkspaceFolder, GameNode.Text, "Backup");
                if (System.IO.Directory.Exists(Directory))
                {
                    //'do nothing
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Directory);
                }

                // Make a Backup file if necessary.
                if (System.IO.File.Exists(GameNode.FileName))
                {

                    String NewFileName = System.IO.Path.Combine(Directory, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                    if (System.IO.File.Exists(NewFileName))
                    {
                        // do nothing
                    }
                    else
                    {
                        System.IO.File.Copy(GameNode.FileName, NewFileName);
                    }
                }

                GameNode.SaveGame(ThreadManager, tv);
            }
        }

        private void toolStripButtonStartEmmulator_Click(object sender, EventArgs e)
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNode();

            if (GameNode.IsSomething())
            {

                Utils.LaunchInstance("", "", GameNode.InstanceToLaunch, GameNode.Resolution);
                Log("Launching Instance " + GameNode.InstanceToLaunch.Trim());
                ThreadManager.IncrementInstanceLaunched();
            }
        }

        private void toolStripButtonStartEmmulatorLaunchApp_Click(object sender, EventArgs e)
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNode();

            Utils.LaunchInstance(GameNode.PackageName, "", GameNode.InstanceToLaunch, GameNode.Resolution);
        }

        private void toolStripButtonStartEmmulatorLaunchAppRunScript_Click(object sender, EventArgs e)
        {
            LaunchAndLoadInstance();
        }

        private void LaunchAndLoadInstance()
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNode();

            Utils.LaunchInstance(GameNode.PackageName, "", GameNode.InstanceToLaunch, GameNode.Resolution);

            LoadInstance(GameNode);
        }

        private void LoadInstance(GameNodeGame gameNode)
        {
            Log("Starting Instance " + gameNode.GameNodeName);

            foreach (GameNodeGame RunningThreadGames in ThreadManager.Games)
            {
                if (RunningThreadGames.ThreadandWindowName == gameNode.ThreadandWindowName)
                {
                    ThreadManager.RemoveGame(RunningThreadGames);
                    RunningThreadGames.Thread.Abort();
                    Log("Stopping existing Instance" + RunningThreadGames.GameNodeName);
                    break;

                }
            }

            GameNodeGame GameCopy = gameNode.CloneMe();

            RunThread RT = new RunThread(GameCopy);
            RT.ThreadManager = ThreadManager;

            Thread t = new Thread(new ThreadStart(RT.Run));
            GameCopy.Thread = t;
            ThreadManager.Games.Add(GameCopy);

            RefreshThreadList();

            RefreshStatusList();

            t.Start();
            SetThreadPauseState(false);

            ThreadManager.IncrementInstanceLoaded();

            tabTree.SelectTab(1);
            lstThreads.SelectedIndex = lstThreads.Items.Count - 1;
        }

        private void RefreshStatusList()
        {
            int Ordinal = 0;
            List<String> lst = new List<string>();
            foreach (GameNodeGame game in ThreadManager.Games)
            {
                lst.Add(game.Name);
                game.StatusNodeID = Ordinal;
                Ordinal++;
                Ordinate(ref Ordinal, lst, game.Nodes[0] as GameNode);
            }

            // AtsStatusControl1.Items = lst;

        }

        private void Ordinate(ref int ID, List<string> lst, GameNode gameNode)
        {
            if (gameNode.GameNodeType == GameNodeType.Action)
            {
                GameNodeAction n2 = gameNode as GameNodeAction;
                if (n2.ActionType == ActionType.Action)
                {
                    gameNode.StatusNodeID = ID;
                    ID = ID + 1;

                    lst.Add(gameNode.Text);
                }
            }

            foreach (GameNode CurrentNode in gameNode.Nodes)
            {
                Ordinate(ref ID, lst, CurrentNode);

            }
        }

        private void RefreshThreadList()
        {
            lstThreads.Items.Clear();
            foreach (GameNodeGame Game in ThreadManager.Games)
            {
                lstThreads.Items.Add(Game.ThreadandWindowName);
                toolStripButtonToggleScript.Enabled = true;

            }
        }

        private void SetThreadPauseState(Boolean isPaused)
        {
            foreach (GameNodeGame Game in ThreadManager.Games)
            {
                Game.IsPaused = isPaused;
                if (isPaused)
                {
                    Log("Un-Pausing Thread " + Game.ThreadandWindowName);
                }
                else
                {
                    Log("Pausing Thread " + Game.ThreadandWindowName);
                }
            }


            if (isPaused)
            {
                toolStripButtonToggleScript.Text = "Un-Pause Scripts";
                toolStripButtonToggleScript.Image = AppTestStudio.Properties.Resources.StartWithoutDebug_16x_24;

            }
            else
            {
                toolStripButtonToggleScript.Text = "Pause Script";
                toolStripButtonToggleScript.Image = AppTestStudio.Properties.Resources.Pause_64x_64;
            }

        }

        private void splitContainerSeconds_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            appTestStudioStatusControl1.ShowPercent = e.SplitX;
        }

        private void lblHowToFixEmmulatorInstalled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.appteststudio.com/#FixEmmulatorInstalled");
        }

        private void lblHowToFixEmmulatorInstancesFound_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.appteststudio.com/#FixEmmulatorInstances");
        }

        private void cmdObjectScreenshotsTakeAScreenshot_Click(object sender, EventArgs e)
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNode();
            String TargetWindow = GameNode.TargetWindow;

            IntPtr MainWindowHandle = Utils.GetWindowHandleByWindowName(TargetWindow);

            Debug.Print("cmdObjectScreenshotsTakeAScreenshot_Click TW=" + TargetWindow + " MWH= " + MainWindowHandle);

            if (MainWindowHandle.ToInt32() > 0)
            {
                Bitmap bmp = Utils.GetBitmapFromWindowHandle(MainWindowHandle);

                PictureObjectScreenshot.Image = bmp;
            }


        }

        private GameNodeObjects GetObjectsNode()
        {
            return tv.Nodes[0].Nodes[0].Nodes[1] as GameNodeObjects;
        }

        private String FindNextObjectNameIncrement(String txt)
        {
            long Increment = 1;
            GameNodeObjects ObjectsNode = GetObjectsNode();
        Restart:
            foreach (GameNodeObject obj in ObjectsNode.Nodes)
            {
                Increment = Increment + 1;
                goto Restart;
            }
            return txt + Increment.ToString();
        }

        private void cmdMakeObject_Click(object sender, EventArgs e)
        {
            GameNodeObjects ObjectsNode = GetObjectsNode();

            foreach (GameNodeObject obj in ObjectsNode.Nodes)
            {
                if (obj.GameNodeName.ToUpper() == txtObjectScreenshotName.Text.Trim().ToUpper())
                {
                    txtObjectScreenshotName.Text = FindNextObjectNameIncrement(txtObjectScreenshotName.Text);
                    break;
                }
            }

            if (PictureObjectScreenshotRectanble.Width <= 0 || PictureObjectScreenshotRectanble.Height <= 0)
            {
                return;
            }
            Bitmap CropImage = new Bitmap(PictureObjectScreenshotRectanble.Width, PictureObjectScreenshotRectanble.Height);
            using (Graphics grp = Graphics.FromImage(CropImage))
            {
                grp.DrawImage(PictureObjectScreenshot.Image, new Rectangle(0, 0, PictureObjectScreenshotRectanble.Width, PictureObjectScreenshotRectanble.Height), PictureObjectScreenshotRectanble, GraphicsUnit.Pixel);
                //'grp.DrawEllipse(Pens.Black, 40, 40, 40, 40)

                grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                GameNodeObject o = new GameNodeObject(txtObjectScreenshotName.Text.Trim());
                o.Bitmap = CropImage;

                GetObjectsNode().Nodes.Add(o);

                SetPanel(PanelMode.Object);
                tv.SelectedNode = o;
            }
        }

        private void SetPanel(PanelMode PanelMode)
        {
            PanelWorkspace.Visible = false;
            PanelGames.Visible = false;
            PanelGame.Visible = false;
            PanelAddNewGames.Visible = false;
            PanelActions.Visible = false;
            PanelEvents.Visible = false;
            PanelColorEvent.Visible = false;
            PanelThread.Visible = false;
            PanelTestAllEvents.Visible = false;
            PanelSchedule.Visible = false;
            PanelObjects.Visible = false;
            PanelObjectScreenshot.Visible = false;
            PanelObject.Visible = false;


            switch (PanelMode)
            {
                case PanelMode.Workspace:
                    PanelWorkspace.Visible = true;
                    break;
                case PanelMode.Games:
                    PanelGames.Visible = true;
                    break;
                case PanelMode.Game:
                    PanelGame.Visible = true;
                    LoadGamePanel();
                    break;
                case PanelMode.AddNewGame:
                    PanelAddNewGames.Visible = true;
                    break;
                case PanelMode.Events:
                    PanelEvents.Visible = true;
                    break;
                case PanelMode.Actions:
                    PanelActions.Visible = true;
                    break;
                case PanelMode.PanelColorEvent:
                    PanelColorEvent.Visible = true;
                    break;
                case PanelMode.Thread:
                    PanelThread.Visible = true;
                    break;
                case PanelMode.TestAllEvents:
                    PanelTestAllEvents.Visible = true;
                    break;
                case PanelMode.Schedule:
                    PanelSchedule.Visible = true;
                    break;
                case PanelMode.Objects:
                    PanelObjects.Visible = true;
                    break;
                case PanelMode.ObjectScreenshot:
                    PanelObjectScreenshot.Visible = true;
                    break;
                case PanelMode.Object:
                    PanelObject.Visible = true;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        private void LoadGamePanel()
        {
            GameNode GameNode = tv.SelectedNode as GameNode;

            if (GameNode.IsSomething())
            {
                lblGamePanelGameName.Text = GameNode.Text;
            }

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String SearchText = txtFilter.Text;
            FilterChildNodes(SearchText, tv.Nodes[0] as GameNode);
        }

        private void FilterChildNodes(string searchText, GameNode Game)
        {
            foreach (GameNode gameNode in Game.Nodes)
            {
                if (searchText.Length == 0)
                {
                    gameNode.BackColor = Color.White;
                }
                else
                {
                    if (gameNode.Name.ToUpper().Contains(searchText.ToUpper()))
                    {
                        gameNode.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        gameNode.BackColor = Color.White;
                    }
                }
                FilterChildNodes(searchText, gameNode);

            }
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Debug.WriteLine("tv_NodeMouseClick");
            LastNode = e.Node as GameNode;
        }

        private void tv_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("tv_MouseUp");
            //' Show menu only if Right Mouse button is clicked
            if (e.Button == MouseButtons.Right)
            {

                //' Point where mouse is clicked
                Point p = new Point(e.X, e.Y);

                //' Go to the node that the user clicked
                GameNode node = tv.GetNodeAt(p) as GameNode;

                if (node.IsSomething())
                {

                    //' select the node that was right clicked on.
                    tv.SelectedNode = node;
                    LastNode = node;
                    mnuAddAction.Visible = true;

                    mnuAddRNG.Visible = true;
                    Debug.Print("tv_MouseUp " + node.GameNodeType.ToString());

                    switch (node.GameNodeType)
                    {
                        case GameNodeType.Workspace:
                            break;
                        case GameNodeType.Games:
                            mnuPopupGames.Show(tv, p);
                            break;
                        case GameNodeType.Game:
                            mnuPopupGame.Show(tv, p);
                            break;
                        case GameNodeType.Events:
                            mnuTestAllEvents.Visible = true;
                            mnuAddAction.Visible = false;
                            mnuEvents.Show(tv, p);
                            break;
                        case GameNodeType.Event:
                            mnuTestAllEvents.Visible = false;
                            mnuEvents.Show(tv, p);
                            break;
                        case GameNodeType.Action:
                            mnuTestAllEvents.Visible = false;
                            GameNodeAction Action = node as GameNodeAction;
                            switch (Action.ActionType)
                            {
                                case ActionType.Action:
                                    break;
                                case ActionType.Event:
                                    break;
                                case ActionType.RNG:
                                    break;
                                case ActionType.RNGContainer:
                                    mnuAddRNG.Visible = false;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case GameNodeType.Objects:
                            mnuObjects.Show(tv, p);
                            break;
                        case GameNodeType.ObjectScreenshot:
                            // do nothing
                            break;
                        case GameNodeType.Object:
                            // do nothing
                            break;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                }
            }

        }

        private void tv_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Debug.WriteLine("tv_ItemDrag");
            if (e.Item is GameNodeAction)
            {
                GameNodeAction Action = e.Item as GameNodeAction;
                switch (Action.ActionType)
                {
                    case ActionType.RNG:
                        // no rng dropping
                        break;
                    default:
                        DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy);
                        break;
                }
            }
        }

        private void tv_DragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine("tv_DragOver");

            GameNodeAction Action = e.Data.GetData("AppTestStudio.GameNodeAction") as GameNodeAction;

            //' Point where mouse is clicked
            Point p = tv.PointToClient(new Point(e.X, e.Y));
            e.Effect = DragDropEffects.None;
            //' Go to the node that the user clicked
            GameNode node = tv.GetNodeAt(p) as GameNode;
            if (node.IsSomething())
            {
                GameNodeAction OGNTAction = node as GameNodeAction;
                switch (node.GameNodeType)
                {
                    case GameNodeType.Workspace:
                        break;
                    case GameNodeType.Games:
                        break;
                    case GameNodeType.Game:
                        break;
                    case GameNodeType.Events:
                        Debug.WriteLine("Need to test if this should be node or Action");
                        switch (OGNTAction.ActionType)
                        {
                            case ActionType.Action:
                                e.Effect = DragDropEffects.None;
                                break;
                            case ActionType.Event:
                                e.Effect = DragDropEffects.Move;
                                break;
                            case ActionType.RNG:
                                e.Effect = DragDropEffects.Move;
                                break;
                            case ActionType.RNGContainer:
                                e.Effect = DragDropEffects.Move;
                                break;
                            default:
                                e.Effect = DragDropEffects.None;
                                break;
                        }
                        break;
                    case GameNodeType.Event:
                        e.Effect = DragDropEffects.Move;
                        break;
                    case GameNodeType.Action:

                        switch (OGNTAction.ActionType)
                        {
                            case ActionType.Action:
                                e.Effect = DragDropEffects.None;
                                break;
                            case ActionType.Event:
                                e.Effect = DragDropEffects.Move;
                                break;
                            case ActionType.RNG:
                                e.Effect = DragDropEffects.Move;
                                break;
                            case ActionType.RNGContainer:
                                e.Effect = DragDropEffects.Move;
                                break;
                            default:
                                e.Effect = DragDropEffects.None;
                                break;
                        }
                        break;
                    case GameNodeType.Objects:
                        break;
                    case GameNodeType.ObjectScreenshot:
                        break;
                    case GameNodeType.Object:
                        break;
                    default:
                        break;
                }



                if (e.Effect == DragDropEffects.Move)
                {
                    if ((e.KeyState & 8) == 8)
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                }
                Debug.WriteLine(node.GameNodeType);
            }
            if (node.IsSomething())
            {
                if (node.PrevVisibleNode.IsSomething())
                {
                    node.PrevVisibleNode.BackColor = Color.White;
                }

                if (node.NextVisibleNode.IsSomething())
                {
                    node.NextVisibleNode.BackColor = Color.White;
                }
                node.BackColor = SystemColors.MenuHighlight;
            }

        }

        private void tv_DragDrop(object sender, DragEventArgs e)
        {
            GameNodeAction Action = e.Data.GetData("AppTestStudio.OctoGameNodeAction") as GameNodeAction;
            //' Point where mouse is clicked
            Point p = tv.PointToClient(new Point(e.X, e.Y));

            //' Go to the node that the user clicked
            GameNode node = tv.GetNodeAt(p) as GameNode;

            if (Action == node)
            {
                return;
            }

            GameNode Target = Action;
            GameNode Parent = node;

            //' check to see if action is the parent of the target(Node)

            while (Parent is GameNodeEvents == false)
            {
                if (Target.Equals(Parent))
                {
                    Log("Cannot set a Child Node using a Node from the Parent");
                    return;
                }
                Parent = Parent.Parent as GameNode;
            }

            if (e.Effect == DragDropEffects.Copy)
            {
                //'do nothing
            }
            else
            {
                //' Remove from current location
                Action.Remove();
            }

            Boolean Handled = false;

            if (node is GameNodeAction)
            {
                GameNodeAction TargetAction = node as GameNodeAction;
                switch (TargetAction.ActionType)
                {
                    case ActionType.RNGContainer:
                        if (TargetAction.AutoBalance)
                        {
                            GameNodeAction GameNodeAction = AddRNGNode(TargetAction);
                            GameNodeAction.Nodes.Insert(0, Action);
                            Action.EnsureVisible();
                            tv.SelectedNode = Action;

                            Action.BackColor = Color.White;
                            GameNodeAction.BackColor = Color.White;
                            Handled = true;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (Handled == false)
            {
                if (e.Effect == DragDropEffects.Copy)
                {
                    GameNodeAction NewNode = Action.CloneMe();
                    node.Nodes.Insert(0, NewNode);
                    NewNode.EnsureVisible();
                    tv.SelectedNode = NewNode;
                }
                else
                {
                    node.Nodes.Insert(0, Action);
                    Action.EnsureVisible();
                    tv.SelectedNode = Action;
                }
            }

            //' clear the entire stack
            ResetBackground(tv.Nodes[0] as GameNode);


        }

        private void ResetBackground(GameNode node)
        {
            node.BackColor = Color.White;
            foreach (GameNode node1 in node.Nodes)
            {
                ResetBackground(node1);
            }
        }

        private GameNodeAction AddRNGNode(GameNodeAction targetAction)
        {
            int Count = targetAction.Nodes.Count;

            int EachResult = 100 / (Count + 1);

            int WhatsLeft = 100;

            for (int i = 0; i < Count; i++)
            {

                GameNodeAction ChildAction = targetAction.Nodes[i] as GameNodeAction;

                ChildAction.Percentage = EachResult;

                WhatsLeft = WhatsLeft - EachResult;
            }


            GameNodeAction GameNodeAction = new GameNodeAction("", ActionType.RNG);
            GameNodeAction.Percentage = WhatsLeft;

            targetAction.Nodes.Add(GameNodeAction);
            tv.SelectedNode = GameNodeAction;
            ThreadManager.IncrementNewRNGContainer();
            return GameNodeAction;


        }

        private void PictureObjectScreenshot_MouseDown(object sender, MouseEventArgs e)
        {
            IsPictureObjectScreenshotMouseDown = true;
            PictureObjectScreenshotRectanble = new Rectangle();
            PictureObjectScreenshotRectanble.X = e.X;
            PictureObjectScreenshotRectanble.Y = e.Y;

        }

        private void PictureObjectScreenshot_Click(object sender, EventArgs e)
        {

        }

        private void PictureObjectScreenshot_MouseMove(object sender, MouseEventArgs e)
        {
            Label label = new Label();  // not sure this is necessary
            int x = 1;
            int y = 0;
            Color color = new Color();
            ShowZoom(PictureObjectScreenshot, PictureObjectScreenshotZoomBox, e, panelObjectScreenshotColor, lblObjectScreenshotColorXY, lblObjectScreenshotRHSXY, label, ref x, ref y, ref color, IsPictureObjectScreenshotMouseDown, PictureObjectScreenshotRectanble);
            cmdMakeObject.Enabled = IsCreateScreenshotReadyToCreate();

        }

        private void ShowZoom(PictureBox pb, PictureBox pb2, MouseEventArgs e, Panel PSC, Label lblColor, Label lblXY, Label lblWarning, ref int PB1x, ref int PB1Y, ref Color PB1Color, bool pb1MouseDown, Rectangle PB1R)
        {
            if (pb.Image.IsSomething())
            {
                Bitmap MyBitmap = pb.Image as Bitmap;
                if (e.X >= MyBitmap.Width)
                {
                    return;
                }
                if (e.Y >= MyBitmap.Height - 1)
                {
                    return;
                }

                if (e.X <= -1)
                {
                    return;
                }

                if (e.Y <= -1)
                {
                    return;
                }

                Color Color = MyBitmap.GetPixel(e.X, e.Y);

                //' Debug.Print(Color.ToString())

                PSC.BackColor = Color;

                Single brightness = Color.GetBrightness();
                if (brightness < 0.55)
                {
                    lblColor.ForeColor = Color.WhiteSmoke;
                    lblXY.ForeColor = Color.WhiteSmoke;
                }
                else
                {
                    lblColor.ForeColor = Color.Black;
                    lblXY.ForeColor = Color.Black;
                }

                lblColor.Text = Color.ToRGBString();
                lblXY.Text = " X=" + e.X + " Y= " + e.Y;

                //' for click code.
                PB1x = e.X;
                PB1Y = e.Y;
                PB1Color = Color;

                int TargetX = e.X;
                int TargetY = e.Y;

                //'center x 
                if (TargetX > 20)
                {
                    TargetX = TargetX - 20;
                }

                //'center y
                if (TargetY > 20)
                {
                    TargetY = TargetY - 20;
                }


                if ((Color.R == 255 && Color.G == 255 && Color.B == 255) || (Color.R == 0 && Color.G == 0 && Color.B == 0))
                {
                    lblWarning.Visible = true;
                }
                else
                {
                    lblWarning.Visible = false;
                }

                Rectangle CropRect = new Rectangle(TargetX, TargetY, 40, 40);
                Bitmap CropImage = new Bitmap(CropRect.Width, CropRect.Height);

                using (Graphics grp = Graphics.FromImage(CropImage))
                {
                    grp.DrawImage(MyBitmap, new Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel);
                    //'grp.DrawEllipse(Pens.Black, 40, 40, 40, 40)

                    grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                    using (Pen Pen = new Pen(Color.Black, 2))
                    {

                        //'draw top on 40,40
                        grp.DrawLine(Pen, 20, 0, 20, 18);

                        //'draw bottom
                        grp.DrawLine(Pen, 20, 22, 20, 40);
                    }

                    pb2.Image.Dispose();

                    pb2.Image = CropImage;
                    pb2.Refresh();
                    //'CropImage.Save("C:\Incoming\abc.jpg")
                }

                if (pb1MouseDown)
                {
                    //'if (e.X > PictureBox1Rectangle.X ) {
                    //'    PictureBox1Rectangle.Width = e.X - PictureBox1Rectangle.X
                    //'}

                    //'if (e.Y > PictureBox1Rectangle.Y ) {
                    //'    PictureBox1Rectangle.Height = e.Y - PictureBox1Rectangle.Y
                    //'}

                    //' if (e.X > PictureBox1Rectangle.X ) {
                    PB1R.Width = e.X - PB1R.X;
                    //' }

                    //'  if (e.Y > PictureBox1Rectangle.Y ) {
                    PB1R.Height = e.Y - PB1R.Y;
                    //' }
                    pb.Refresh();
                }

            }


        }

        private bool IsCreateScreenshotReadyToCreate()
        {
            if (txtObjectScreenshotName.Text.Trim().Length > 0)
            {
                //' Do nothing
            }
            else
            {
                return false;
            }

            if (PictureObjectScreenshotRectanble.IsEmpty)
            {
                return false;
            }

            if (PictureObjectScreenshotRectanble.Width <= 0 || PictureObjectScreenshotRectanble.Height <= 0)
            {
                return false;
            }

            return true;

        }

        private void PictureObjectScreenshot_MouseUp(object sender, MouseEventArgs e)
        {
            IsPictureObjectScreenshotMouseDown = false;

        }

        private void PictureObjectScreenshot_Paint(object sender, PaintEventArgs e)
        {
            if (PictureObjectScreenshotRectanble.Width > 0 && PictureObjectScreenshotRectanble.Height > 0)
            {
                using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                {
                    e.Graphics.FillRectangle(br, PictureObjectScreenshotRectanble);
                }

                using (Pen p = new Pen(Color.Blue, 1))
                {
                    e.Graphics.DrawRectangle(p, PictureObjectScreenshotRectanble);
                }

            }

        }

        private void txtObjectScreenshotName_TextChanged(object sender, EventArgs e)
        {
            cmdMakeObject.Enabled = IsCreateScreenshotReadyToCreate();
        }

        private void txtPackageName_TextChanged(object sender, EventArgs e)
        {
            GameNodeGame Game = tv.SelectedNode as GameNodeGame;
            if (Game.IsSomething())
            {
                Game.PackageName = txtPackageName.Text.Trim();
            }
        }

        private void txtGamePanelLaunchInstance_TextChanged(object sender, EventArgs e)
        {
            GameNodeGame Game = tv.SelectedNode as GameNodeGame;
            if (Game.IsSomething())
            {
                Game.InstanceToLaunch = txtGamePanelLaunchInstance.Text.Trim();
            }
        }

        private void cboGameInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGamePanelLaunchInstance.Text = cboGameInstances.Text;
        }

        private void txtGamePanelLoopDelay_TextChanged(object sender, EventArgs e)
        {
            GameNodeGame Game = tv.SelectedNode as GameNodeGame;
            if (Game.IsSomething())
            {
                if (txtGamePanelLoopDelay.Text.Trim().IsNumeric())
                {
                    Game.LoopDelay = Convert.ToInt64(txtGamePanelLoopDelay.Text.Trim());
                }
            }

        }

        private void cboResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameNodeGame Game = tv.SelectedNode as GameNodeGame;
            if (Game.IsSomething())
            {
                if (cboResolution.Text.Length > 0)
                {
                    Game.Resolution = cboResolution.Text;
                }
            }
        }

        private void cmdStartEmmulator_Click(object sender, EventArgs e)
        {
            Utils.LaunchInstance("", "", txtGamePanelLaunchInstance.Text, cboResolution.Text);
        }

        private void cmdRunScript_Click(object sender, EventArgs e)
        {
            LoadInstance(tv.SelectedNode as GameNodeGame);
        }

        private void cmdStartEmmulatorAndPackage_Click(object sender, EventArgs e)
        {
            Utils.LaunchInstance(txtPackageName.Text, "", txtGamePanelLaunchInstance.Text, cboResolution.Text);
        }

        private void cmdStartEmmulatorPackageAndRunScript_Click(object sender, EventArgs e)
        {
            Utils.LaunchInstance(txtPackageName.Text, "", txtGamePanelLaunchInstance.Text, cboResolution.Text);
            LoadInstance(tv.SelectedNode as GameNodeGame);
        }

        private void chkSaveVideo_CheckedChanged(object sender, EventArgs e)
        {
            GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
            GameNode.SaveVideo = chkSaveVideo.Checked;
        }

        private void NumericVideoFrameLimit_ValueChanged(object sender, EventArgs e)
        {
            GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
            GameNode.VideoFrameLimit = (long)NumericVideoFrameLimit.Value;
        }

        private void chkEnableSchedule_CheckedChanged(object sender, EventArgs e)
        {
            timerScheduler.Enabled = chkEnableSchedule.Checked;
            Schedule.IsEnabled = chkEnableSchedule.Checked;
            if (IsLoadingSchedule)
            {

            }
            else
            {
                SaveSchedule();
            }

            if (chkEnableSchedule.Checked)
            {
                toolSchedulerRunning.Text = "Scheduler Running";
                toolSchedulerRunning.BackColor = Color.LightGreen;
            }
            else
            {
                toolSchedulerRunning.Text = "Scheduler Paused";
                toolSchedulerRunning.BackColor = SystemColors.ButtonFace;
            }
        }

        private void SaveSchedule()
        {
            String FileName = GetScheduleFileName();

            TextWriter TR = new StreamWriter(FileName);
            XmlSerializer Serializer = new XmlSerializer(Schedule.GetType());

            Serializer.Serialize(TR, Schedule);
            TR.Close();

        }

        private string GetScheduleFileName()
        {
            return WorkspaceNode.WorkspaceFolder + @"\Schedule.config";
        }

        private void cmdAddSchedule_Click(object sender, EventArgs e)
        {
            frmScheduler frm = new frmScheduler(null);
            frm.IsAdding = true;

            frm.ShowDialog();

            if (frm.IsSaving)
            {
                if (frm.IsAdding)
                {
                    ScheduleItem si = frm.getItem();
                    Schedule.ScheduleList.Add(si);
                    SaveSchedule();
                    ReloadScheduleView();
                }
            }

        }

        private void ReloadScheduleView()
        {
            dgSchedule.Rows.Clear();
            foreach (ScheduleItem item in Schedule.ScheduleList)
            {

                String ItemName = item.Name;
                String WindowName = item.WindowName;
                String InstanceNumber = item.InstanceNumber.ToString();
                String StartsAt = item.StartsAt.ToString("hh:mm tt");
                String Monday = item.Monday.ToX();
                String Tuesday = item.Tuesday.ToX();
                String Wednesday = item.Wednesday.ToX();
                String Thursday = item.Thursday.ToX();
                String Friday = item.Friday.ToX();
                String Saturday = item.Saturday.ToX();
                String Sunday = item.Sunday.ToX();
                String Repeats = "";

                if (item.Repeats)
                {
                    Repeats = "Yes Every " + item.RepeatsEvery + " minutes, " + item.StopsAfter + " times.";
                }
                else
                {
                    Repeats = "No";
                }

                String[] k = {
                    ItemName,
                WindowName,
                InstanceNumber,
                StartsAt, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, Repeats};
                dgSchedule.Rows.Add(k);
                item.CurrentRun = DateTime.MinValue;
            }


        }

        private void chkUseParentScreenshot_CheckedChanged(object sender, EventArgs e)
        {
            LoadParentScreenshotIfNecessary();
            if (IsPanelLoading == false)
            {
                cmdSaveSingleColorLocation.PerformClick();
            }
        }

        private void LoadParentScreenshotIfNecessary()
        {
            if (chkUseParentScreenshot.Checked)
            {
                GameNode CurrentParent = PanelLoadNode.Parent as GameNode;
                Bitmap CurrentBitmap = null;

                while (CurrentParent is GameNodeAction)
                {

                    GameNodeAction Action = CurrentParent as GameNodeAction;
                    if (Action.Bitmap.IsSomething())
                    {
                        PictureBox1.Image = Action.Bitmap;
                        return;
                    }
                    CurrentParent = CurrentParent.Parent as GameNode;
                }

                cmdAddSingleColorAtSingleLocationTakeASceenshot.PerformClick();
            }
        }

        private void cmdUndoScreenshot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UndoScreenshot.IsSomething())
            {
                lblResolution.Text = UndoScreenshot.Width + "x" + UndoScreenshot.Height;
                PictureBox1.Image = UndoScreenshot;
                cmdSaveSingleColorLocation.PerformClick();
                cmdUndoScreenshot.Visible = false;

                if (dgv.Rows.Count > 1)
                {
                    if (lblMode.Text == "Event")
                    {
                        DialogResult Result = MessageBox.Show("Screenshot Reverted, do you want to re-sample the colors?", "Resample Colors?", MessageBoxButtons.YesNo);

                        if (Result == DialogResult.Yes)
                        {
                            ResampleColors();
                        }
                    }
                }
            }
        }

        private void ResampleColors()
        {
            Bitmap bmp = PictureBox1.Image as Bitmap;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int x = Convert.ToInt32(dgv.Rows[i].Cells["dgvX"].Value);
                int y = Convert.ToInt32(dgv.Rows[i].Cells["dgvY"].Value);
                Color Color = bmp.GetPixel(x, y);

                dgv.Rows[i].Cells["dgvColor"].Value = Color.ToRGBString();
                DataGridViewCellStyle Style = Utils.GetDataGridViewCellStyleFromColor(Color);

                dgv.Rows[i].Cells["dgvColor"].Style = Style;
            }
        }

        private void rdoModeRangeClick_Click(object sender, EventArgs e)
        {
            PictureBox1.Refresh();
            if (IsPanelLoading)
            {
                cmdSaveSingleColorLocation.PerformClick();
            }
        }

        private void rdoModeClickDragRelease_Click(object sender, EventArgs e)
        {
            PictureBox1.Refresh();
            if (IsPanelLoading)
            {
                cmdSaveSingleColorLocation.PerformClick();
            }
        }

        private void rdoColorPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading)
            {
                HideShowObjectvsAndOR();
                GameNodeAction GameNode = tv.SelectedNode as GameNodeAction;
                GameNode.IsColorPoint = rdoColorPoint.Checked;

                PictureBox1.Refresh();
            }
        }

        private void HideShowObjectvsAndOR()
        {
            GameNodeAction Node = tv.SelectedNode as GameNodeAction;
            if (Node.IsColorPoint)
            {
                grpAndOr.Visible = true;
                grpObject.Visible = false;
            }
            else
            {
                grpAndOr.Visible = false;
                grpObject.Visible = true;
            }
        }

        private void rdoObjectSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                HideShowObjectvsAndOR();
                GameNodeAction GameNode = tv.SelectedNode as GameNodeAction;
                GameNode.IsColorPoint = rdoColorPoint.Checked;

                if (GameNode.Rectangle.IsEmpty)
                {
                    GameNode.Rectangle = new Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height);
                }
                PictureBox1.Refresh();
            }
        }

        // Removes a tree node and sets focus to parent tree node.
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            GameNode p = PanelLoadNode.Parent as GameNode;
            PanelLoadNode.Remove();
            tv.SelectedNode = p;

        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            RunSingleTest();
        }

        private void RunSingleTest()
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNode GameNode = Node.GetGameNode();
            GameNodeAction ActionNode = Node as GameNodeAction;

            if (GameNode.IsSomething())
            {
                //' do nothing
            }
            else
            {
                Log("Unable to find Node During test");
                return;
            }

            if (ActionNode.IsRelativeStart && (ActionNode.Rectangle.Width <= 0 || ActionNode.Rectangle.Height <= 0))
            {
                Log("Please Draw a rectangle on the workspace.");
                return;


            }

            GameNodeGame game = GameNode as GameNodeGame;

            IntPtr MainWindowHandle = Utils.GetWindowHandleByWindowName(game.TargetWindow);


            //For Each P As Process In Process.GetProcesses()
            //    if (P.MainWindowTitle.Length() > 0)
            //    {
            //    String TargetWindow = game.TargetWindow
            if (MainWindowHandle.ToInt32() > 0)
            {
                ThreadManager.IncrementSingleTestRun();

                switch (lblMode.Text)
                {
                    case "Action":
                        Boolean IsObjectSearchParent = false;

                        // should check for null instead of this, due to Language conversion.
                        GameNode Parent = Node.Parent as GameNode;

                        if (Parent is GameNodeAction)
                        {
                            GameNodeAction ActionNodeParent = Parent as GameNodeAction;

                            if (ActionNodeParent.IsColorPoint == false)
                            {
                                IsObjectSearchParent = true;
                            }
                        }

                        if (IsObjectSearchParent && ActionNode.IsRelativeStart)
                        {

                            frmTestObjectSearch frm2 = new frmTestObjectSearch(game, Node as GameNodeAction, this, MainWindowHandle, Parent as GameNodeAction);
                            frm2.StartPosition = FormStartPosition.CenterParent;

                            ThreadManager.IncrementSingleEventTest();

                            frm2.ShowDialog(this);
                        }
                        else
                        {
                            if (rdoModeRangeClick.Checked)
                            {
                                int x = ActionNode.Rectangle.Left;
                                int y = ActionNode.Rectangle.Top;
                                Utils.ClickOnWindow(MainWindowHandle, x, y);
                                Log("Click attempt: x=" + x + ",Y = " + y);
                                ThreadManager.IncrementSingleTestClick();
                            }
                            else
                            {
                                int x = ActionNode.Rectangle.Left;
                                int y = ActionNode.Rectangle.Top;
                                Utils.ClickDragRelease(MainWindowHandle, x, y, x + ActionNode.Rectangle.Width, y + ActionNode.Rectangle.Height);
                                Log("ClickDragRelease( x=" + x + ",Y = " + y + ", ex=" + (x + ActionNode.Rectangle.Width) + ",ey=" + (y + ActionNode.Rectangle.Height) + ")");
                                ThreadManager.IncrementSingleTestClickDragRelease();

                            }
                        }
                        break;
                    case "Event":
                        if (rdoColorPoint.Checked)
                        {
                            frmTest frm2 = new frmTest(game, Node, this, MainWindowHandle);
                            frm2.StartPosition = FormStartPosition.CenterParent;

                            ThreadManager.IncrementSingleEventTest();

                            frm2.ShowDialog(this);
                        }
                        else
                        {
                            if (PictureBoxEventObjectSelection.Image.IsSomething())
                            {
                                if (cboChannel.SelectedIndex == 0)
                                {
                                    Log("Please select choose a Color Channel to test with.");
                                    //FlashLabel(lblColorChannel);
                                    Debug.Assert(false);// need to preset REd Channel if one's not selected
                                }
                                else
                                {
                                    frmTestObjectSearch frm2 = new frmTestObjectSearch(game, Node as GameNodeAction, this, MainWindowHandle, null);
                                    frm2.StartPosition = FormStartPosition.CenterParent;
                                    ThreadManager.IncrementSingleEventTest();

                                    frm2.ShowDialog(this);
                                }

                            }
                            else
                            {
                                Log("Please select An Object to test with from the list in the Object group before testing.");
                                // FlashLabel(lblSearchObject)
                                Debug.Assert(false);// need to preset REd Channel if one's not selected
                            }
                        }

                        break;

                    default:
                        Debug.Assert(false);
                        break;
                }

                return;

            }
            else
            {
                Log("Unable to find window with title: " + game.TargetWindow);
            }

        }
    }
}
