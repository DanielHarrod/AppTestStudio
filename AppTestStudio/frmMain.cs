using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            int MainWindowHandle = Utils.GetWindowHandleByWindowName(TargetWindow);

            Debug.Print("cmdObjectScreenshotsTakeAScreenshot_Click TW=" + TargetWindow + " MWH= " + MainWindowHandle);

            if (MainWindowHandle > 0)
            {
                Bitmap bmp = Utils.GetBitmapFromWindowHandle(MainWindowHandle);

                PictureBox3.Image = bmp;
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
                grp.DrawImage(PictureBox3.Image, new Rectangle(0, 0, PictureObjectScreenshotRectanble.Width, PictureObjectScreenshotRectanble.Height), PictureObjectScreenshotRectanble, GraphicsUnit.Pixel);
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
    }
}
