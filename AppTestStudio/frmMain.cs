// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using AppTestStudioControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
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

        private GameNodeAction mPanelLoadNode;
        private GameNodeAction LastPanelLoadNode = null;
        public GameNodeAction PanelLoadNode
        {
            get { return mPanelLoadNode; }
            set
            {
                if (LastPanelLoadNode.IsSomething())
                {
                    LastPanelLoadNode.BackColor = Color.White;
                }
                LastPanelLoadNode = mPanelLoadNode;
                mPanelLoadNode = value;

                if (mPanelLoadNode.IsSomething())
                {
                    mPanelLoadNode.BackColor = SystemColors.MenuHighlight;
                }
            }
        }

        private int NoxInstances = -1;

        // Log buffer
        // Logging is stored here and updated on a textbox on a timer.  
        private StringBuilder sb = new StringBuilder();

        private int PictureBox1X;
        private int PictureBox1Y;
        private Color PictureBox1Color;
        private Boolean PictureBox1MouseDown = false;

        private Schedule Schedule = new Schedule();

        private int InitialPanelRightColorAtPointerHeight;
        private int InitialPanelRightLimitHeight;
        private int InitialPanelRightAnchorHeight;
        private int InitialPanelRightOffsetHeight;
        private int InitialPanelRightDragModeHeight;
        private int InitialPanelRightResolutionHeight;
        private int InitialPanelRightAfterCompletionHeight;
        private int InitialPanelRightObjectHeight;
        private int InitialPanelRightLogicHeight;
        private int InitialPanelRightCustomLogicHeight;
        private int InitialPanelRightPointGridHeight;
        private int InitialPanelRightClickPropertiesHeight;
        private int InitialPanelRightSwipePropertiesHeight;
        private int TitleBarHeight;

        public SteamRegistry SteamRegistry { get; set; }

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

            FirstFormost();
            InitializedInstances();

            TitleBarHeight = this.RectangleToScreen(this.ClientRectangle).Top - this.Top;

            InitialPanelRightColorAtPointerHeight = panelRightColorAtPointer.Height;

            InitialPanelRightLimitHeight = panelRightLimit.Height;
            InitialPanelRightOffsetHeight = panelRightOffset.Height;
            InitialPanelRightDragModeHeight = panelRightDragMode.Height;
            InitialPanelRightResolutionHeight = panelRightProperties.Height;
            InitialPanelRightAfterCompletionHeight = panelRightAfterCompletion.Height;
            InitialPanelRightObjectHeight = panelRightObject.Height;
            InitialPanelRightLogicHeight = panelRightLogic.Height;
            InitialPanelRightCustomLogicHeight = panelRightCustomLogic.Height;
            InitialPanelRightPointGridHeight = panelRightCustomLogic.Height;
            InitialPanelRightClickPropertiesHeight = panelRightClickProperties.Height;
            InitialPanelRightSwipePropertiesHeight = panelRightSwipeProperties.Height;
            InitialPanelRightAnchorHeight = panelRightAnchor.Height;

            Timer1.Enabled = true;
            //'Debug.Assert(false, "Fix")

            ThreadManager.IncrementAppLaunches();

            //'Default the first Panel to system
            SetPanel(PanelMode.Workspace);

            PanelWorkspace.Dock = DockStyle.Fill;
            PanelGames.Dock = DockStyle.Fill;
            PanelGame.Dock = DockStyle.Fill;
            PanelAddNewGames.Dock = DockStyle.Fill;
            PanelEvents.Dock = DockStyle.Fill;
            PanelActions.Dock = DockStyle.Fill;
            PanelColorEvent.Dock = DockStyle.Fill;
            PanelColorEvent.Location = new Point(0, 0);
            PanelThread.Dock = DockStyle.Fill;
            PanelTestAllEvents.Dock = DockStyle.Fill;
            PanelSchedule.Dock = DockStyle.Fill;
            PanelObjects.Dock = DockStyle.Fill;
            PanelObjectScreenshot.Dock = DockStyle.Fill;
            PanelObject.Dock = DockStyle.Fill;

            WorkspaceNode = new GameNodeWorkspace("Apps");
            WorkspaceNode.WorkspaceFolder = Utils.GetApplicationFolder();
            tv.Nodes.Add(WorkspaceNode);

            LoadSchedule();
            ReloadScheduleView();

            //'GamesTreeNode = New OctoGameNode("Apps", OctoGameNodeType.Games)
            //'WorkspaceNode.Nodes.Add(GamesTreeNode)

            //'   AddNewGameToTree("Holy Day City")

            //'LoadDefaultProject()

            tv.ExpandAll();

            LoadRanges();

            // Initialize
            appTestStudioStatusControl1.ShowPercent = 120;

            // Hide Custom Logic controls
            panelRightCustomLogic.Visible = false;

        }

        private void LoadSchedule()
        {
            String FileName = GetScheduleFileName();

            if (System.IO.File.Exists(FileName))
            {

                XmlSerializer Serializer = new XmlSerializer(Schedule.GetType());
                TextReader TRead = new StreamReader(FileName);
                Schedule = Serializer.Deserialize(TRead) as Schedule;
                TRead.Close();

                chkEnableSchedule.Checked = Schedule.IsEnabled;
                chkEnableSchedule_CheckedChanged(null, null);
            }
            else
            {
                Schedule = new Schedule();
            }
        }

        private void LoadRanges()
        {
            for (int i = 0; i < 255; i++)
            {
                cboPoints.Items.Add(i);
            }
        }

        private void InitializedInstances()
        {
            NoxRegistry Registry = new NoxRegistry();

            for (int i = 0; i < NoxInstances; i++)
            {
                cboGameInstances.Items.Add(i);
                ToolStripItem Item = toolStripInstances.DropDownItems.Add(i.ToString());
                Item.Click += new System.EventHandler(this.ToolStripItem_Click);
            }

            if (cboGameInstances.Items.Count > 0)
            {
                cboGameInstances.SelectedIndex = 0;
                toolStripInstances.Text = "0";
            }
        }

        private void ToolStripItem_Click(object sender, EventArgs e)
        {
            ToolStripItem Item = sender as ToolStripItem;

            if (Item.IsSomething())
            {
                cboGameInstances.Text = Item.Text;
                txtGamePanelLaunchInstance.Text = Item.Text;
                toolStripInstances.Text = Item.Text;
                GetGameNode().InstanceToLaunch = Item.Text;

            }
        }

        private void FirstFormost()
        {
            NoxRegistry NoxRegistry = new NoxRegistry();
            //' Make App Test Studio Working Folder
            String DirectoryPath = Utils.GetApplicationFolder();

            if (System.IO.Directory.Exists(DirectoryPath) == false)
            {
                System.IO.Directory.CreateDirectory(DirectoryPath);
            }

            String ExportPath = DirectoryPath + @"\Exports\";
            if (System.IO.Directory.Exists(ExportPath) == false)
            {
                System.IO.Directory.CreateDirectory(ExportPath);
            }

            //'Count Nox instances
            String TargetPath = NoxRegistry.BigNoxVMSFolder;
            if (System.IO.Directory.Exists(TargetPath))
            {
                String[] Directories = System.IO.Directory.GetDirectories(TargetPath);

                int DirectoryCount = 0;

                foreach (String Folder in Directories)
                {
                    if (Folder.Contains("nox-prev"))
                    {
                        //'donothing
                    }
                    else
                    {
                        DirectoryCount = DirectoryCount + 1;
                    }
                }

                NoxInstances = DirectoryCount;
                lblEmmulatorInstancesFound.Text = NoxInstances.ToString();
                lblEmmulatorInstancesFound.ForeColor = Color.Green;
            }
            else
            {
                lblEmmulatorInstancesFound.Text = "0";
                lblEmmulatorInstancesFound.ForeColor = Color.Red;
            }

            //'info.FileName = "C:\Program Files (x86)\Nox\bin\nox.exe"
            //'Check for Nox Emmulator
            //'TargetPath = X86Folder & "\Nox\bin\nox.exe"
            TargetPath = NoxRegistry.ExePath;

            if (System.IO.File.Exists(TargetPath))
            {
                lblEmmulatorInstalled.Text = "Yes";
                lblEmmulatorInstalled.ForeColor = Color.Green;

            }
            else
            {
                lblEmmulatorInstalled.Text = "No";
                lblEmmulatorInstalled.ForeColor = Color.Red;
            }

            SteamRegistry = new SteamRegistry();
        }

        private void InitializeToolbars()
        {

            toolStripButtonStartEmmulator.Enabled = false;
            toolStripButtonStartEmmulatorLaunchApp.Enabled = false;

            toolStripButtonRunScript.Enabled = false;
            toolStripButtonSaveScript.Enabled = false;
            toolStripButtonRunStartLaunch.Enabled = false;
            DisableSecondToolbarButtons();
        }

        const String PauseScript = "Pause Script";
        const String UnPauseScript = "Un-Pause Scripts";
        private void toolStripButtonToggleScript_Click(object sender, EventArgs e)
        {
            Boolean IsPaused = false;

            if (toolStripButtonToggleScript.Text == PauseScript)
            {
                IsPaused = true;
            }
            else
            {
                IsPaused = false;
            }

            SetThreadPauseState(IsPaused);

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
                            toolStripButtonSaveScript_Click(null, null);
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
                try
                {
                    String FileName = openDLG.FileName;
                    GameNodeGame Game = GameNodeGame.LoadGameFromFile(FileName, true, TitleBarHeight);

                    if (Game.IsSomething())
                    {
                        LoadGameToTree(Game);
                    }
                }
                catch (Exception Ex)
                {
                    Log(Ex.Message);
                    Debug.WriteLine(Ex.Message);
                    Debug.Assert(false);
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
            toolStripInstances.Text = game.InstanceToLaunch;

            Log("Loaded Script: " + game.GameNodeName);

            // if the instance to launch that's saved matches the instances loaded use the files settings
            // otherwise set the launch instance to instance 0.
            if (game.InstanceToLaunch.Trim().Length > 0)
            {
                int instance = game.InstanceToLaunch.Trim().ToInt();
                if (cboGameInstances.Items.Count - 1 >= instance)
                {
                    cboGameInstances.SelectedIndex = instance;
                }
                else
                {
                    cboGameInstances.SelectedIndex = 0;
                    txtGamePanelLaunchInstance.Text = "0";
                    game.InstanceToLaunch = "0";
                }
            }
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Debug.WriteLine("tv_AfterSelect");

            if (e.IsNothing())
            {
                e = new TreeViewEventArgs(tv.SelectedNode);
            }

            GameNode Node = e.Node as GameNode;

            PanelLoadNode = null;

            mnuAddRNGNode.Enabled = false;

            toolStripButtonRunScript.Enabled = false;
            toolStripButtonRunStartLaunch.Enabled = false;
            toolStripButtonStartEmmulatorLaunchApp.Enabled = false;
            toolStripButtonStartEmmulatorLaunchApp.Enabled = false;
            toolStripButtonStartEmmulator.Enabled = false;

            moveToolStripMenuItem.Enabled = false;

            toolStripButtonSaveScript.Enabled = false;

            panelRightClickProperties.Visible = false;
            panelRightSwipeProperties.Visible = false;

            DisableSecondToolbarButtons();

            if (Node.IsNothing())
            {
                return;
            }
            Console.WriteLine(Node.GameNodeType);

            // Do we have any thing to test?
            GameNodeGame GameNodeGameNode = Node.GetGameNodeGame();
            if (GameNodeGameNode.IsSomething())
            {
                GameNodeEvents Events = GameNodeGameNode.GetEventsNode();
                if (Events.IsSomething())
                {
                    if (Events.Nodes.Count > 0)
                    {
                        toolTestAll.Enabled = true;
                    }
                }
            }

            switch (Node.GameNodeType)
            {
                case GameNodeType.Workspace:
                    SetPanel(PanelMode.Workspace);
                    break;
                case GameNodeType.Games:
                    SetPanel(PanelMode.Games);
                    break;
                case GameNodeType.Game:
                    SetPanel(PanelMode.Game);
                    LoadGamePanel(Node as GameNodeGame);

                    toolStripButtonStartEmmulatorLaunchApp.Enabled = true;
                    toolStripButtonStartEmmulatorLaunchApp.Enabled = true;
                    toolStripButtonStartEmmulator.Enabled = true;

                    toolStripButtonRunScript.Enabled = true;
                    toolStripButtonRunStartLaunch.Enabled = true;
                    toolStripButtonSaveScript.Enabled = true;
                    break;
                case GameNodeType.Events:
                    SetPanel(PanelMode.Events);

                    toolStripButtonSaveScript.Enabled = true;
                    toolStripButtonStartEmmulatorLaunchApp.Enabled = true;
                    toolStripButtonStartEmmulator.Enabled = true;

                    toolStripButtonRunScript.Enabled = true;
                    toolStripButtonRunStartLaunch.Enabled = true;

                    //second toolbar
                    toolAddRNG.Enabled = true;
                    toolAddEvent.Enabled = true;
                    toolAddAction.Enabled = true;

                    break;
                case GameNodeType.Action:
                    moveToolStripMenuItem.Enabled = true;
                    toolStripButtonSaveScript.Enabled = true;
                    toolStripButtonStartEmmulatorLaunchApp.Enabled = true;
                    toolStripButtonStartEmmulator.Enabled = true;

                    toolStripButtonRunScript.Enabled = true;
                    toolStripButtonRunStartLaunch.Enabled = true;

                    SetPanel(PanelMode.PanelColorEvent);
                    LoadPanelSingleColorAtSingleLocation(e.Node as GameNodeAction);

                    GameNodeAction Action = e.Node as GameNodeAction;

                    panelRightDragMode.Visible = false;
                    panelRightOffset.Visible = false;

                    switch (Action.ActionType)
                    {
                        case AppTestStudio.ActionType.RNGContainer:
                            mnuAddRNGNode.Enabled = true;

                            //second toolbar
                            toolAddRNGNode.Enabled = true;
                            break;
                        case ActionType.RNG:
                            //second toolbar
                            toolAddRNG.Enabled = true;
                            toolAddEvent.Enabled = true;
                            toolAddAction.Enabled = true;
                            break;
                        case ActionType.Event:

                            //second toolbar
                            toolAddRNG.Enabled = true;
                            toolAddEvent.Enabled = true;
                            toolAddAction.Enabled = true;
                            toolTest.Enabled = true;
                            break;
                        case ActionType.Action:

                            //second toolbar
                            toolAddRNG.Enabled = true;
                            toolAddEvent.Enabled = true;
                            toolAddAction.Enabled = true;
                            toolTest.Enabled = true;

                            if (Action.IsParentObjectSearch())
                            {
                                panelRightOffset.Visible = true;
                                if (Action.Mode == Mode.ClickDragRelease)
                                {
                                    panelRightDragMode.Visible = true;
                                }
                            }

                            switch (Action.Mode)
                            {
                                case Mode.RangeClick:
                                    panelRightClickProperties.Visible = true;
                                    break;
                                case Mode.ClickDragRelease:
                                    panelRightSwipeProperties.Visible = true;

                                    if (Action.IsParentObjectSearch())
                                    {
                                        groupBoxClickDragReleaseObjectSearch.Enabled = true;
                                    }
                                    else
                                    {
                                        groupBoxClickDragReleaseObjectSearch.Enabled = false;
                                        rdoObjectSearchNone.Checked = true;
                                    }
                                    // do nothing
                                    break;
                                default:
                                    // do nothing
                                    break;
                            }

                            break;
                        default:
                            break;
                    }
                    break;
                case GameNodeType.Objects:
                    SetPanel(PanelMode.Objects);
                    break;
                case GameNodeType.ObjectScreenshot:
                    break;
                case GameNodeType.Object:
                    SetPanel(PanelMode.Object);
                    LoadObject(e.Node as GameNodeObject);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            // Resets button labels.
            cboPlatform_SelectedIndexChanged(null, null);

        }

        private void DisableSecondToolbarButtons()
        {
            //Second Toolbar
            toolAddEvent.Enabled = false;
            toolAddAction.Enabled = false;
            toolAddRNG.Enabled = false;
            toolAddRNGNode.Enabled = false;
            toolTest.Enabled = false;
            toolTestAll.Enabled = false;
        }

        private void LoadGamePanel(GameNodeGame gameNode)
        {
            txtGamePanelVersion.Text = gameNode.TargetGameBuild;
            txtPackageName.Text = gameNode.PackageName;

            txtGamePanelLaunchInstance.Text = gameNode.InstanceToLaunch;
            txtGamePanelLaunchInstance.Enabled = true;

            txtGamePanelLoopDelay.Text = gameNode.LoopDelay.ToString();
            cboResolution.Text = gameNode.Resolution;
            chkSaveVideo.Checked = gameNode.SaveVideo;
            NumericVideoFrameLimit.Value = gameNode.VideoFrameLimit;
            numericApplicationDefaultClickSpeed.Value = gameNode.DefaultClickSpeed;
            cboDPI.Text = gameNode.DPI.ToString();

            cboPlatform.Text = gameNode.Platform.ToString();
            txtSteamID.Text = gameNode.SteamID.ToString();
            txtPathToApplicationExe.Text = gameNode.PathToApplicationEXE;
            txtSteamWindowName.Text = gameNode.SteamWindowName;
            txtApplicationWindowName.Text = gameNode.ApplicationWindowName;
            chkApplicationIsFullScreen.Checked = gameNode.IsFullScreen;
            chkIsSteamFullScreen.Checked = gameNode.IsFullScreen;
            cboPlatform_TextChanged(null, null);
        }

        private void LoadObject(GameNodeObject node)
        {
            txtObjectName.Text = node.Name;
            PictureBoxObject.Image = node.Bitmap;

            String References = "";
            foreach (GameNodeAction Action in GetGameNodeEvents().Nodes)
            {
                GatherObjectReferences(node, ref References, Action);
            }

            if (References.Length > 0)
            {
                txtObjectReferencedBy.Text = References;
                cmdDeleteObject.Enabled = false;
            }
            else
            {
                cmdDeleteObject.Enabled = true;
                txtObjectReferencedBy.Text = "";
            }
        }

        private void GatherObjectReferences(GameNodeObject node, ref string References, GameNodeAction Action)
        {
            if (Action.ObjectName == node.Name)
            {
                if (References.Length > 0)
                {
                    References = References + Environment.NewLine;
                }
                References = References + Action.Name;
            }
            foreach (GameNodeAction ChildAction in Action.Nodes)
            {
                GatherObjectReferences(node, ref References, ChildAction);

            }
        }

        private GameNodeGame GetGameNode()
        {
            if (tv.Nodes.Count > 0)
            {
                return tv.Nodes[0].Nodes[0] as GameNodeGame;
            }
            return null;
        }

        private GameNodeEvents GetGameNodeEvents()
        {
            GameNodeGame Game = GetGameNode();
            if (Game.IsSomething())
            {
                if (Game.Nodes.Count > 0)
                {
                    return Game.Nodes[0] as GameNodeEvents;
                }
            }
            return null;
        }

        private GameNodeObjects GetGameNodeObjects()
        {
            GameNodeGame Game = GetGameNode();
            if (Game.IsSomething())
            {
                if (Game.Nodes.Count > 1)
                {
                    return Game.Nodes[1] as GameNodeObjects;
                }
            }
            return null;
        }


        private void LoadPanelSingleColorAtSingleLocation(GameNodeAction GameNode)
        {
            IsPanelLoading = true;
            PanelLoadNode = GameNode;
            if (tv.SelectedNode is GameNodeEvents)
            {
                chkUseParentScreenshot.Visible = false;
                //'cmdHelpUseParentScreenshot.Visible = false
            }

            switch (GameNode.ActionType)
            {
                case AppTestStudio.ActionType.Action:
                    lblMode.Text = "Action";
                    break;
                case AppTestStudio.ActionType.Event:
                    lblMode.Text = "Event";
                    break;
                case AppTestStudio.ActionType.RNG:
                    lblMode.Text = "Random Generator Success";
                    break;
                case AppTestStudio.ActionType.RNGContainer:
                    lblMode.Text = "Random Number Generator (RNG)";
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            dgv.Rows.Clear();

            dgv.Visible = false;

            panelRightAnchor.Visible = false;
            panelRightLogic.Visible = false;
            panelRightCustomLogic.Visible = false;
            panelRightPointGrid.Visible = false;

            PictureBox2.Visible = false;
            PanelSelectedColor.Visible = false;

            cmdAddSingleColorAtSingleLocationTakeASceenshot.Visible = false;
            //'cmdHelpTakeAScreenshot.Visible = false

            chkUseParentScreenshot.Visible = false;
            //'cmdHelpUseParentScreenshot.Visible = false

            lblRHSColor.Visible = false;
            lblRHSXY.Visible = false;

            //'if (PanelLoadNode.Nodes.Count = 0 ) {
            //'    cmdDelete.Enabled = true
            //'} else {
            //'   cmdDelete.Enabled = false
            //'}

            cboPoints.Text = GameNode.Points.ToString();

            cboDelayMS.Text = GameNode.DelayMS.ToString();
            cboDelayS.Text = GameNode.DelayS.ToString();
            cboDelayH.Text = GameNode.DelayH.ToString();
            cboDelayM.Text = GameNode.DelayM.ToString();

            NumericClickSpeed.Value = GameNode.ClickSpeed;

            if (GameNode.IsColorPoint)
            {
                rdoColorPoint.Checked = true;
            }
            else
            {
                rdoObjectSearch.Checked = true;
            }

            switch (GameNode.AfterCompletionType)
            {
                case AppTestStudio.AfterCompletionType.Continue:
                    rdoAfterCompletionContinue.Checked = true;
                    break;
                case AppTestStudio.AfterCompletionType.Home:
                    rdoAfterCompletionHome.Checked = true;
                    break;
                case AppTestStudio.AfterCompletionType.Parent:
                    rdoAfterCompletionParent.Checked = true;
                    break;
                case AppTestStudio.AfterCompletionType.Stop:
                    rdoAfterCompletionStop.Checked = true;
                    break;
                case AppTestStudio.AfterCompletionType.ContinueProcess:
                    rdoAfterCompletionParent.Checked = true;
                    break;
                case AfterCompletionType.Recycle:
                    rdoAfterCompletionRecycle.Checked = true;
                    break;
                default:
                    rdoAfterCompletionParent.Checked = true;
                    break;
            }

            chkUseParentScreenshot.Checked = GameNode.UseParentPicture;
            txtEventName.Text = GameNode.Text;

            chkUseLimit.Checked = GameNode.IsLimited;
            chkWaitFirst.Checked = GameNode.IsWaitFirst;
            numIterations.Value = GameNode.ExecutionLimit;
            chkLimitRepeats.Checked = GameNode.LimitRepeats;

            switch (GameNode.WaitType)
            {
                case AppTestStudio.WaitType.Iteration:
                    cboWaitType.Text = "Iteration";
                    break;
                case AppTestStudio.WaitType.Time:
                    cboWaitType.Text = "Time";
                    break;
                case AppTestStudio.WaitType.Session:
                    cboWaitType.Text = "Once Per Session";
                    break;
                default:
                    cboWaitType.Text = "Iteration";
                    break;
            }
            lnkLimitTime.Text = Utils.CalculateDelay(GameNode.LimitDelayH, GameNode.LimitDelayM, GameNode.LimitDelayS, GameNode.LimitDelayMS);

            if (GameNode.Mode == Mode.RangeClick)
            {
                rdoModeRangeClick.Checked = true;
            }
            else
            {
                rdoModeClickDragRelease.Checked = true;
            }

            chkPropertiesEnabled.Checked = GameNode.Enabled;

            AnchorChange(GameNode);

            switch (GameNode.ActionType)
            {
                case AppTestStudio.ActionType.Action:
                    chkPropertiesRepeatsUntilFalse.Visible = false;
                    grpPropertiesRepeatsUntilFalse.Visible = false;
                    panelRightProperties.Height = 122;  // hiding repeats so remove the space they are taking up.

                    grpEventMode.Visible = false;
                    grpMode.Visible = true;
                    panelRightObject.Visible = false;
                    //'cmdHelpAddAction.Visible = true

                    //' cmdHelpAddAction.Visible = true
                    PictureBox2.Visible = true;
                    PanelSelectedColor.Visible = true;

                    cmdAddSingleColorAtSingleLocationTakeASceenshot.Visible = true;
                    //'cmdHelpTakeAScreenshot.Visible = true

                    //'                if (TypeOf (GameNode.Parent) Is OctoGameNodeEvents ) {
                    //'               chkUseParentScreenshot.Visible = false
                    //'              } else {
                    chkUseParentScreenshot.Visible = true;
                    //'cmdHelpUseParentScreenshot.Visible = true
                    //'             }
                    lblRHSColor.Visible = true;
                    lblRHSXY.Visible = true;

                    if (GameNode.ClickDragReleaseStartHeight <= numericSwipeStartHeight.Maximum)
                    {
                        numericSwipeStartHeight.Value = GameNode.ClickDragReleaseStartHeight;
                    }
                    else
                    {
                        numericSwipeStartHeight.Value = 10;
                        Log("Swipe Start Height(" + GameNode.ClickDragReleaseStartHeight + ") is invalid setting to 10");
                    }

                    if (GameNode.ClickDragReleaseEndHeight <= numericSwipeEndHeight.Maximum)
                    {
                        numericSwipeEndHeight.Value = GameNode.ClickDragReleaseEndHeight;
                    }
                    else
                    {
                        numericSwipeEndHeight.Value = 10;
                        Log("Swipe End Height(" + GameNode.ClickDragReleaseEndHeight + ") is invalid setting to 10");
                    }

                    if (GameNode.ClickDragReleaseStartWidth <= numericSwipeStartWidth.Maximum)
                    {
                        numericSwipeStartWidth.Value = GameNode.ClickDragReleaseStartWidth;
                    }
                    else
                    {
                        numericSwipeStartWidth.Value = 10;
                        Log("Swipe Start Width(" + GameNode.ClickDragReleaseStartWidth + ") is invalid setting to 10");
                    }

                    if (GameNode.ClickDragReleaseEndWidth <= numericSwipeEndWidth.Maximum)
                    {
                        numericSwipeEndWidth.Value = GameNode.ClickDragReleaseEndWidth;
                    }
                    else
                    {
                        numericSwipeEndWidth.Value = 10;
                        Log("Swipe End Width(" + GameNode.ClickDragReleaseEndWidth + ") is invalid setting to 10");
                    }


                    if (GameNode.ClickDragReleaseVelocity <= numericSwipeVelocity.Maximum)
                    {
                        numericSwipeVelocity.Value = GameNode.ClickDragReleaseVelocity;
                    }
                    else
                    {
                        numericSwipeVelocity.Value = 500;
                        Log("Swipe End Width(" + GameNode.ClickDragReleaseVelocity + ") is invalid setting to 500");
                    }

                    if (GameNode.IsParentObjectSearch())
                    {
                        panelRightAnchor.Visible = false;
                    }
                    else
                    {
                        panelRightAnchor.Visible = true;
                    }

                    switch (GameNode.ClickDragReleaseMode)
                    {
                        case ClickDragReleaseMode.Start:
                            rdoObjectSearchStart.Checked = true;
                            break;
                        case ClickDragReleaseMode.End:
                            rdoObjectSearchEnd.Checked = true;
                            break;
                        case ClickDragReleaseMode.None:
                            rdoObjectSearchNone.Checked = true;
                            break;
                        default:
                            break;
                    }

                    break;
                case AppTestStudio.ActionType.Event:
                    chkPropertiesRepeatsUntilFalse.Visible = true;
                    grpPropertiesRepeatsUntilFalse.Visible = true;
                    panelRightProperties.Height = 170;

                    chkPropertiesRepeatsUntilFalse.Checked = GameNode.RepeatsUntilFalse;
                    chkPropertiesRepeatsUntilFalse_CheckedChanged(null, null); // lazy - enable/disable code is on the change event.

                    numericPropertiesRepeatsUntilFalse.Value = GameNode.RepeatsUntilFalseLimit;

                    rdoColorPoint.Checked = GameNode.IsColorPoint;
                    grpMode.Visible = false;
                    grpEventMode.Visible = true;
                    //'cmdHelpAddAction.Visible = false

                    //' cmdHelpAddAction.Visible = false
                    dgv.Visible = true;

                    PictureBox2.Visible = true;
                    PanelSelectedColor.Visible = true;

                    cmdAddSingleColorAtSingleLocationTakeASceenshot.Visible = true;
                    //'cmdHelpTakeAScreenshot.Visible = true

                    //'                if (TypeOf (GameNode.Parent) Is OctoGameNodeEvents ) {
                    //'               chkUseParentScreenshot.Visible = false
                    //'              } else {
                    chkUseParentScreenshot.Visible = true;
                    //'cmdHelpUseParentScreenshot.Visible = true
                    //'             }
                    lblRHSColor.Visible = true;
                    lblRHSXY.Visible = true;

                    //'load existing
                    PictureBox1.Image = GameNode.Bitmap;

                    panelRightCustomLogic.Visible = false;
                    if (GameNode.LogicChoice.ToUpper() == "OR")
                    {
                        rdoOR.Checked = true;
                        GameNode.LastLogicChoice = "OR";
                    }
                    else if (GameNode.LogicChoice.ToUpper() == "AND")
                    {
                        rdoAnd.Checked = true;
                        GameNode.LastLogicChoice = "AND";
                    }
                    else
                    {
                        rdoCustom.Checked = true;
                        GameNode.LastLogicChoice = "CUSTOM";
                        txtCustomLogic.Text = GameNode.CustomLogic;
                        panelRightCustomLogic.Visible = true;
                    }

                    int RowCount = 1;
                    foreach (SingleClick Click in GameNode.ClickList)
                    {
                        int RowIndex = dgv.Rows.Add();
                        dgv.Rows[RowIndex].Cells["dgvID"].Value = RowIndex + 1;
                        dgv.Rows[RowIndex].Cells["dgvRed"].Value = Click.Color.R.ToString();
                        dgv.Rows[RowIndex].Cells["dgvGreen"].Value = Click.Color.G.ToString();
                        dgv.Rows[RowIndex].Cells["dgvBlue"].Value = Click.Color.B.ToString();
                        dgv.Rows[RowIndex].Cells["dgvX"].Value = Click.X;
                        dgv.Rows[RowIndex].Cells["dgvY"].Value = Click.Y;
                        dgv.Rows[RowIndex].Cells["dgvRemove"].Value = "Rem";
                        dgv.Rows[RowIndex].Cells["dgvScan"].Value = "Scn";

                        // Attempt to set adaptive colors for background color and font, tries to avoid white font with white background.
                        DataGridViewCellStyle Style = Utils.GetDataGridViewCellStyleFromColor(Click.Color);

                        dgv.Rows[RowIndex].Cells["dgvRed"].Style = Style;
                        dgv.Rows[RowIndex].Cells["dgvGreen"].Style = Style;
                        dgv.Rows[RowIndex].Cells["dgvBlue"].Style = Style;

                        RowCount++;
                    }

                    lblRHSColor.Text = "";
                    lblRHSXY.Text = "";

                    HideShowObjectvsAndOR();

                    //'do nothing
                    LoadObjectNodeSection();

                    break;
                case AppTestStudio.ActionType.RNG:
                    grpEventMode.Visible = false;
                    break;
                case AppTestStudio.ActionType.RNGContainer:
                    grpEventMode.Visible = false;
                    grpMode.Visible = false;
                    //' cmdHelpAddAction.Visible = false
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }



            PictureBox1.Image = GameNode.Bitmap;
            PictureBox1.Refresh();

            InitalizeOffsets();

            lblResolution.Text = GameNode.ResolutionWidth + "x" + GameNode.ResolutionHeight;
            IsPanelLoading = false;

        }

        private void InitalizeOffsets()
        {
            GameNodeAction CurrentNode = tv.SelectedNode as GameNodeAction;

            //'check for parent 

            GameNodeAction CurrentParent;

            if (CurrentNode.Parent is GameNodeAction)
            {
                CurrentParent = CurrentNode.Parent as GameNodeAction;
            }
            else
            {
                //grpObjectAction.Visible = false;
                return;
            }

            NumericYOffset.Minimum = -PictureBox1.Height;
            NumericYOffset.Maximum = PictureBox1.Height;

            NumericXOffset.Maximum = PictureBox1.Width;
            NumericXOffset.Minimum = -PictureBox1.Width;
            NumericXOffset.Value = CurrentNode.RelativeXOffset;
            NumericYOffset.Value = CurrentNode.RelativeYOffset;

            lblXOffsetRange.Text = "-" + PictureBox1.Width + " to " + PictureBox1.Width;
            lblYOffsetRange.Text = "-" + PictureBox1.Height + " to " + PictureBox1.Height;

            if (CurrentParent is GameNodeAction)
            {
                if (CurrentParent.IsColorPoint == false)
                {
                    //grpObjectAction.Visible = true;
                    return;
                }
                else
                {
                    //grpObjectAction.Visible = false;
                    return;
                }
            }


        }

        private void LoadObjectNodeSection()
        {
            GameNodeAction EventNode = tv.SelectedNode as GameNodeAction;

            if (EventNode.IsColorPoint)
            {
                return;
            }
            LoadEventObjectList();

            LoadObjectSelectionImage();
            if (EventNode.ObjectName == "")
            {
                cboObject.SelectedIndex = 0;
            }
            else
            {
                cboObject.Text = EventNode.ObjectName;
            }

            switch (EventNode.Channel.ToUpper())
            {
                case "RED":
                    cboChannel.Text = "Red Channel";
                    break;
                case "GREEN":
                    cboChannel.Text = "Green Channel";
                    break;
                case "BLUE":
                    cboChannel.Text = "Blue Channel";
                    break;
                default:
                    SetChannelDefaults(EventNode);
                    break;
            }


            NumericObjectThreshold.Value = EventNode.ObjectThreshold;

        }

        private void SetChannelDefaults(GameNodeAction EventNode)
        {
            cboChannel.Text = "Red Channel";
            EventNode.Channel = "Red";
        }

        private void LoadObjectSelectionImage()
        {
            GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
            if (ActionNode.IsColorPoint)
            {
                //'do nothing
            }
            else
            {
                if (ActionNode.ObjectName.Trim() == "")
                {
                    //'do nothing
                }
                else
                {
                    GameNode Node = tv.SelectedNode as GameNode;
                    GameNode GameNode = Node.GetGameNodeGame();
                    GameNodeObjects ObjectsNode = GameNode.GetObjectsNode();
                    //'For Each Screenshot As OctoGameNodeObjectScreenshot In ObjectsNode.Nodes

                    foreach (GameNodeObject gameNodeObject in ObjectsNode.Nodes)
                    {
                        if (gameNodeObject.GameNodeName.Trim() == ActionNode.ObjectName.Trim())
                        {
                            PictureBoxEventObjectSelection.Image = gameNodeObject.Bitmap;
                            ActionNode.ObjectSearchBitmap = gameNodeObject.Bitmap;
                            return;
                        }
                    }

                }
            }
            PictureBoxEventObjectSelection.Image = null;
            ActionNode.ObjectSearchBitmap = null;
        }

        private void LoadEventObjectList()
        {
            cboObject.Items.Clear();
            cboObject.Items.Add("Choose a Object");

            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeObjects ObjectsNode = Node.GetObjectsNode();

            if (ObjectsNode.IsSomething())
            {
                foreach (GameNodeObject ATSObject in ObjectsNode.Nodes)
                {
                    cboObject.Items.Add(ATSObject.GameNodeName);
                }
            }
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

                XmlTextWriter Writer = new XmlTextWriter(GameNode.FileName, System.Text.Encoding.UTF8);
                Writer.Formatting = Formatting.Indented;

                Writer.WriteStartDocument();

                Writer.WriteStartElement("AppTestStudio");  // Root.

                GameNode.SaveGame(Writer, ThreadManager, tv, false);
                Writer.WriteEndElement();
                Writer.WriteEndDocument();
                Writer.Close();
            }
        }

        private void toolStripButtonStartEmmulator_Click(object sender, EventArgs e)
        {
            GameNodeGame Game = GetGameNode();
            StartEmmulator(Game, "", Game.InstanceToLaunch);
        }

        private void toolStripButtonStartEmmulatorLaunchApp_Click(object sender, EventArgs e)
        {
            GameNodeGame Game = GetGameNode();
            StartEmmulator(Game, Game.PackageName, Game.InstanceToLaunch);
        }


        private void LaunchAndLoadInstance()
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();

            String Result = Utils.LaunchInstance(GameNode.PackageName, "", GameNode.InstanceToLaunch, GameNode.Resolution, GameNode.DPI);
            Log(Result);

            LoadInstance(GameNode);
        }

        private void LoadInstance(GameNodeGame gameNode)
        {
            Log("Starting Instance " + gameNode.GameNodeName);

            // Stop any existing threads that are running on this instance.
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

            appTestStudioStatusControl1.Items = lst;

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

                    lst.Add("  " + gameNode.Text);
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
                toolStripButtonToggleScript.Text = UnPauseScript;
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

        private void cmdObjectScreenshotsTakeAScreenshot_Click(object sender, EventArgs e)
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();
            String TargetWindow = GameNode.TargetWindow;

            IntPtr MainWindowHandle = GameNode.GetWindowHandleByWindowName();

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
                if (obj.GameNodeName == txt + Increment)
                {
                    Increment = Increment + 1;
                    goto Restart;
                }
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
                    LoadPanelEvents();
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

        private void LoadPanelEvents()
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame Game = Node.GetGameNodeGame();
            lblEventsPanelTargetWindow.Text = Game.TargetWindow;
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
            GameNode FirstGameNode = null;
            FilterChildNodes(SearchText, tv.Nodes[0] as GameNode, ref FirstGameNode);

            if (FirstGameNode.IsSomething())
            {
                FirstGameNode.EnsureVisible();
            }
        }

        private void FilterChildNodes(string searchText, GameNode Game, ref GameNode firstGameNode)
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
                        if (firstGameNode.IsNothing())
                        {
                            firstGameNode = gameNode;
                        }
                        gameNode.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        gameNode.BackColor = Color.White;
                    }
                }
                FilterChildNodes(searchText, gameNode, ref firstGameNode);

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
                            //mnuPopupGame.Show(tv, p);
                            break;
                        case GameNodeType.Events:
                            mnuAddAction.Visible = false;
                            mnuEvents.Show(tv, p);
                            break;
                        case GameNodeType.Action:
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
                            mnuEvents.Show(tv, p);
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
            // Scrolling
            TreeView tv = sender as TreeView;
            Point pt = tv.PointToClient(new Point(e.X, e.Y));

            int delta = tv.Height - pt.Y;
            if ((delta < tv.Height / 2) && (delta > 0))
            {
                TreeNode tn = tv.GetNodeAt(pt.X, pt.Y);
                if (tn.NextVisibleNode != null)
                    tn.NextVisibleNode.EnsureVisible();
            }
            if ((delta > tv.Height / 2) && (delta < tv.Height))
            {
                TreeNode tn = tv.GetNodeAt(pt.X, pt.Y);
                if (tn.IsSomething())
                {
                    if (tn.PrevVisibleNode.IsSomething())
                    {
                        tn.PrevVisibleNode.EnsureVisible();
                    }
                }
            }
            // /Scrolling

            Debug.WriteLine("tv_DragOver");

            GameNodeAction Action = e.Data.GetData("AppTestStudio.GameNodeAction") as GameNodeAction;

            //' Point where mouse is clicked
            Point p = tv.PointToClient(new Point(e.X, e.Y));
            e.Effect = DragDropEffects.None;
            //' Go to the node that the user clicked
            GameNode node = tv.GetNodeAt(p) as GameNode;
            if (node.IsSomething())
            {
                switch (node.GameNodeType)
                {
                    case GameNodeType.Workspace:
                        break;
                    case GameNodeType.Games:
                        break;
                    case GameNodeType.Game:
                        break;
                    case GameNodeType.Events:

                        if (node is GameNodeEvents)
                        {
                            e.Effect = DragDropEffects.Move;
                            break;
                        }
                        else
                        {
                            GameNodeAction ActionNode = node as GameNodeAction;

                            switch (ActionNode.ActionType)
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
                                    e.Effect = DragDropEffects.Move;
                                    break;
                                default:
                                    e.Effect = DragDropEffects.None;
                                    break;
                            }
                        }
                        break;
                    case GameNodeType.Action:
                        if (node is GameNodeEvents)
                        {
                            e.Effect = DragDropEffects.Move;
                            break;
                        }
                        else
                        {
                            GameNodeAction ActionNode2 = node as GameNodeAction;
                            switch (ActionNode2.ActionType)
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
            GameNodeAction Action = e.Data.GetData("AppTestStudio.GameNodeAction") as GameNodeAction;
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
            Debug.WriteLine("PictureObjectScreenshot_MouseDown");
            IsPictureObjectScreenshotMouseDown = true;
            PictureObjectScreenshotRectanble = new Rectangle();
            PictureObjectScreenshotRectanble.X = e.X;
            PictureObjectScreenshotRectanble.Y = e.Y;

        }

        private void PictureObjectScreenshot_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("PictureObjectScreenshot_MouseMove");
            int x = 1;
            int y = 0;
            Color color = new Color();
            ShowZoom(PictureObjectScreenshot, PictureObjectScreenshotZoomBox, e, panelObjectScreenshotColor, lblObjectScreenshotColorXY, lblObjectScreenshotRHSXY, ref x, ref y, ref color, IsPictureObjectScreenshotMouseDown, ref PictureObjectScreenshotRectanble);
            cmdMakeObject.Enabled = IsCreateScreenshotReadyToCreate();

        }

        // Zoom and Crop/Mask
        private void ShowZoom(PictureBox pb, PictureBox pb2, MouseEventArgs e, Panel PSC, Label lblColor, Label lblXY, ref int PB1x, ref int PB1Y, ref Color PB1Color, bool pb1MouseDown, ref Rectangle rect)
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
                TargetX = TargetX - 20;

                //'center y
                TargetY = TargetY - 20;

                Rectangle CropRect = new Rectangle(TargetX, TargetY, 40, 40);
                Bitmap CropImage = new Bitmap(CropRect.Width, CropRect.Height);

                using (Graphics grp = Graphics.FromImage(CropImage))
                {
                    grp.DrawImage(MyBitmap, new Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel);

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
                    rect.Width = e.X - rect.X;
                    //' }

                    //'  if (e.Y > PictureBox1Rectangle.Y ) {
                    rect.Height = e.Y - rect.Y;
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
                int Result = 0;
                if (int.TryParse(txtGamePanelLaunchInstance.Text, out Result))
                {
                    Game.InstanceToLaunch = Result.ToString();
                }
                else
                {
                    txtGamePanelLaunchInstance.Text = Game.InstanceToLaunch;
                }
            }
        }

        private void cboGameInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGamePanelLaunchInstance.Text = cboGameInstances.Text;
            toolStripInstances.Text = cboGameInstances.Text;
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
            GameNodeGame Game = GetGameNode();
            StartEmmulator(Game, "",Game.InstanceToLaunch);
        }

        /// <summary>
        /// Checks is Path exists and that the application ends in .EXE
        /// </summary>
        /// <param name="Path"></param>
        /// <returns>Path is Valid</returns>
        private Boolean IsPathValidForLaunch(String Path)
        {
            if (System.IO.File.Exists(Path))
            {
                if (Path.ToUpper().Trim().EndsWith(".EXE"))
                {
                    return true;
                }
            }
            return false;
        }

        private void StartEmmulator(GameNodeGame Game, String PackageName, String InstanceToLaunch)
        {
            try
            {
                String Result = "";
                String ApplicationPath = "";
                switch (Game.Platform)
                {
                    case Platform.NoxPlayer:
                        Result = Utils.LaunchInstance(PackageName, "", InstanceToLaunch.ToString(), Game.Resolution, Game.DPI);
                        break;
                    case Platform.Steam:
                        ApplicationPath = SteamRegistry.GetExePath();

                        if (IsPathValidForLaunch(ApplicationPath))
                        {
                            Result = Utils.LaunchSteamInstance(ApplicationPath, Game.SteamID);
                        }
                        else
                        {
                            Result = ApplicationPath + " is invalid - Launch aborted";
                            return;
                        }

                        break;
                    case Platform.Application:
                        ApplicationPath = Game.PathToApplicationEXE;

                        if (IsPathValidForLaunch(ApplicationPath))
                        {
                            Result = Utils.LaunchApplication(ApplicationPath, Game.ApplicationParameters);
                        }
                        else
                        {
                            Result = ApplicationPath + " is invalid - Launch aborted";
                            return;
                        }
                        break;
                    default:
                        break;
                }
                Log(Result);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void cmdRunScript_Click(object sender, EventArgs e)
        {
            LoadInstance(tv.SelectedNode as GameNodeGame);
        }

        private void cmdStartEmmulatorAndPackage_Click(object sender, EventArgs e)
        {
            GameNodeGame Game = GetGameNode();
            StartEmmulator(Game, Game.PackageName, Game.InstanceToLaunch);
        }

        private void cmdStartEmmulatorPackageAndRunScript_Click(object sender, EventArgs e)
        {
            GameNodeGame Game = GetGameNode();
            StartEmmulator(Game, Game.PackageName, Game.InstanceToLaunch);
            LoadInstance(Game);
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
                ArchaicSave();
            }
        }

        private void LoadParentScreenshotIfNecessary(Boolean AlwaysPull = false)
        {
            if (chkUseParentScreenshot.Checked || AlwaysPull)
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

        //private void cmdUndoScreenshot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    if (UndoScreenshot.IsSomething())
        //    {
        //        lblResolution.Text = UndoScreenshot.Width + "x" + UndoScreenshot.Height;
        //        PictureBox1.Image = UndoScreenshot;
        //        ArchaicSave();
        //        cmdUndoScreenshot.Visible = false;

        //        if (dgv.Rows.Count > 1)
        //        {
        //            if (lblMode.Text == "Event")
        //            {
        //                DialogResult Result = MessageBox.Show("Screenshot Reverted, do you want to re-sample the colors?", "Resample Colors?", MessageBoxButtons.YesNo);

        //                if (Result == DialogResult.Yes)
        //                {
        //                    ResampleColors();
        //                }
        //            }
        //        }
        //    }
        //}

        private void ResampleColors()
        {
            try
            {
                Bitmap bmp = PictureBox1.Image as Bitmap;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    int x = Convert.ToInt32(dgv.Rows[i].Cells["dgvX"].Value);
                    int y = Convert.ToInt32(dgv.Rows[i].Cells["dgvY"].Value);
                    Color Color = bmp.GetPixel(x, y);

                    dgv.Rows[i].Cells["dgvRed"].Value = Color.R.ToString();
                    dgv.Rows[i].Cells["dgvGreen"].Value = Color.G.ToString();
                    dgv.Rows[i].Cells["dgvBlue"].Value = Color.B.ToString();


                    // Attempt to set adaptive colors for background color and font, tries to avoid white font with white background.
                    DataGridViewCellStyle Style = Utils.GetDataGridViewCellStyleFromColor(Color);

                    dgv.Rows[i].Cells["dgvRed"].Style = Style;
                    dgv.Rows[i].Cells["dgvGreen"].Style = Style;
                    dgv.Rows[i].Cells["dgvBlue"].Style = Style;
                }
            }
            catch (Exception ex)
            {
                Log("Error sampling Colors typically the points are outside the image that was captured.");
                Log(ex.Message);

                // Clear the points out.
                dgv.Rows.Clear();

                // Redraw the picture box.
                PictureBox1.Refresh();

                // Save 0 points.
                ArchaicSave();

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

                LoadObjectNodeSection();
            }
        }

        private void rdoColorPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
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
                panelRightLogic.Visible = true;

                if (Node.LogicChoice.ToUpper() == "CUSTOM")
                {
                    panelRightCustomLogic.Visible = true;
                }
                else
                {
                    panelRightCustomLogic.Visible = false;
                }
                panelRightPointGrid.Visible = true;
                panelRightObject.Visible = false;
                panelRightAnchor.Visible = false;
            }
            else
            {
                panelRightLogic.Visible = false;
                panelRightCustomLogic.Visible = false;
                panelRightPointGrid.Visible = false;
                panelRightObject.Visible = true;
                panelRightAnchor.Visible = true;
            }
        }

        private void DeleteSelectedTreeNode()
        {
            try
            {
                GameNode p = PanelLoadNode.Parent as GameNode;
                PanelLoadNode.Remove();
                tv.SelectedNode = p;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Debug.Assert(false);  // need to fix.
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            RunSingleTest();
        }

        private void RunSingleTest()
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNode GameNode = Node.GetGameNodeGame();
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

            GameNodeGame game = GameNode as GameNodeGame;

            if (ActionNode.ActionType == ActionType.Action)
            {
                if (ActionNode.Mode == Mode.RangeClick)
                {
                    // A button is needed 
                    if (ActionNode.Rectangle.Width <= 0 || ActionNode.Rectangle.Height <= 0)
                    {
                        Log("Please Draw a rectangle to indicate the click location.");
                        return;
                    }
                }
            }

            IntPtr MainWindowHandle = game.GetWindowHandleByWindowName();

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
                        Boolean IsObjectSearchParent = ActionNode.IsParentObjectSearch();

                        if (IsObjectSearchParent)
                        {
                            frmTestObjectSearch frm2 = new frmTestObjectSearch(game, Node as GameNodeAction, this, MainWindowHandle, Node.Parent as GameNodeAction);
                            frm2.StartPosition = FormStartPosition.CenterParent;

                            ThreadManager.IncrementSingleEventTest();

                            frm2.ShowDialog(this);
                        }
                        else
                        {
                            if (rdoModeRangeClick.Checked)
                            {
                                Bitmap bmp = Utils.GetBitmapFromWindowHandle(MainWindowHandle);
                                GameNodeAction.RangeClickResult Result = ActionNode.CalculateRangeClickResult(bmp, 0, 0);
                                Boolean Failed = false;
                                if (Result.x < 0)
                                {
                                    Log("Check Relative offset X, calculated to a negative position " + Result.x);
                                    Failed = true;
                                }

                                if (Result.y < 0)
                                {
                                    Log("Check Relative offset Y, calculated to a negative position " + Result.y);
                                    Failed = true;
                                }

                                Utils.ClickOnWindow(MainWindowHandle, (short)Result.x, (short)Result.y, ActionNode.ClickSpeed);
                                Log("Click attempt: x=" + Result.x + ",Y = " + Result.y);
                                ThreadManager.IncrementSingleTestClick();
                            }
                            else
                            {
                                GameNodeAction.ClickDragReleaseResult Result = ActionNode.CalculateClickDragReleaseResult(0, 0);

                                Utils.ClickDragRelease(MainWindowHandle, Result.StartX, Result.StartY, Result.EndX, Result.EndY, ActionNode.ClickDragReleaseVelocity);
                                Log("ClickDragRelease( x=" + Result.StartX + ",Y = " + Result.StartY + ", ex=" + Result.EndX + ",ey=" + Result.EndY + ")");
                                ThreadManager.IncrementSingleTestClickDragRelease();
                            }
                        }
                        break;
                    case "Event":
                        if (rdoColorPoint.Checked)
                        {
                            frmTest frm2 = new frmTest(game, ActionNode, this, MainWindowHandle);
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
                                // Debug.Assert(false);// need to preset REd Channel if one's not selected
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (GameNodeGame Game in ThreadManager.Games)
                {
                    if (Game.ThreadLog.Count() > 0)
                    {
                        String s = "";

                        if (Game.ThreadLog.TryDequeue(out s))
                        {
                            Log(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Log(ex.Message);
                //Debug.Assert(false);

                ThreadManager.IsDirty = true;
            }

            if (ThreadManager.IsDirty)
            {
                RefreshThreadList();
                ThreadManager.IsDirty = false;
            }

            //'wow not good.
            int lstthreadsSelectedIndex = lstThreads.SelectedIndex;
            if (lstthreadsSelectedIndex == -1)
            {
                if (lstThreads.Items.Count > 0)
                {
                    lstThreads.SelectedIndex = 0;
                }
            }

            Boolean NeedRedraw = false;

            foreach (GameNodeGame game in ThreadManager.Games)
            {
                if (game.IsSomething())
                {

                    int OriginalCount = game.StatusControl.Count;
                    while (game.StatusControl.Count > 0)
                    {
                        AppTestStudioStatusControlItem sci = null;
                        if (game.StatusControl.TryDequeue(out sci))
                        {
                            appTestStudioStatusControl1.Queue.Add(sci);
                        }
                    }

                    if (OriginalCount > 0)
                    {
                        NeedRedraw = true;
                    }

                    if (game.MinimalBitmapClones.Count > 0)
                    {
                        //'walk the tree to find a bitmpa

                        MinimalBitmapNode mbmc = null;
                        if (game.MinimalBitmapClones.TryDequeue(out mbmc))
                        {
                            TreeNode[] tns = tv.Nodes.Find(mbmc.NodeName, true);

                            if (tns.Length == 1)
                            {
                                GameNodeAction ActionNode = tns[0] as GameNodeAction;

                                if (mbmc.ResolutionHeight == ActionNode.ResolutionHeight)
                                {
                                    if (mbmc.ResolutionWidth == ActionNode.ResolutionWidth)
                                    {
                                        ActionNode.Bitmap = mbmc.Bitmap.Clone() as Bitmap;
                                        Log("Synching Screenshot: " + ActionNode.Name);
                                        BitmapChildren(ActionNode, ActionNode.Bitmap);
                                    }
                                }
                            }
                            else
                            {
                                Log("Attempted to sync screenshots but two nodes have the same name: " + mbmc.NodeName);
                            }
                            mbmc.Bitmap.Dispose();
                            mbmc.Bitmap = null;
                        }
                    }
                }
            }

            //'if (mPaintCount > 0 and ) {
            //'    cmdGraph.Text = "Time Left " & mPaintCount
            //'    //'DANIEL type 1
            //'    Dim OLDBMP As Bitmap = pb.Image
            //'    Dim xbmp As New Bitmap(pb.Width, pb.Height)
            //'    Using gr As Graphics = Graphics.FromImage(xbmp)
            //'        //'Dim hdc As Integer = gr.GetHdc
            //'        //'Try
            //'        StatusControl1.UserControl1_Paint(gr, pb.Height, pb.Width)
            //'        //' Catch ex As Exception
            //'        //' Debug.WriteLine(ex.Message)
            //'        //'Finally
            //'        //'gr.ReleaseHdc(hdc)
            //'        //' End Try
            //'        Dim hdc As Integer = gr.GetHdc
            //'        gr.ReleaseHdc(hdc)


            //'        pb.Image = xbmp
            //'        if (OLDBMP Is Nothing = false ) {
            //'            OLDBMP.Dispose()
            //'        }
            //'    End Using
            //'    mPaintCount = mPaintCount - 1
            //'} else {
            //'    cmdGraph.Text = "Press to refresh"
            //'}

            //'//'DANIEL type 1
            //'Dim OLDBMP As Bitmap = pb.Image
            //'Dim xbmp As New Bitmap(pb.Width, pb.Height)
            //'Using gr As Graphics = Graphics.FromImage(xbmp)
            //'    //'Dim hdc As Integer = gr.GetHdc
            //'    //'Try
            //'    StatusControl1.UserControl1_Paint(gr, pb.Height, pb.Width)
            //'    //' Catch ex As Exception
            //'    //' Debug.WriteLine(ex.Message)
            //'    //'Finally
            //'    //'gr.ReleaseHdc(hdc)
            //'    //' End Try
            //'    Dim hdc As Integer = gr.GetHdc
            //'    gr.ReleaseHdc(hdc)


            //'    pb.Image = xbmp
            //'    if (OLDBMP Is Nothing = false ) {
            //'        OLDBMP.Dispose()
            //'    }
            //'End Using

            //'DANIEL Type 2
            //'if (pb.Image Is Nothing ) {
            //'    pb.Image = New Bitmap(pb.Width, pb.Height)
            //'}
            appTestStudioStatusControl1.Invalidate();
            //'pb.Invalidate()


            //'type 3
            //'Dim bmp3 As Bitmap = New Bitmap(pb.Width, pb.Height)
            //'Using g As Graphics = Graphics.FromImage(bmp3)
            //'    Dim hdc As Integer = g.GetHdc()
            //'    Try
            //'        StatusControl1.UserControl1_Paint(g, pb.Height, pb.Width)
            //'    Catch ex As Exception
            //'        Debug.WriteLine(ex.Message)
            //'    Finally
            //'        g.ReleaseHdc(hdc)
            //'    End Try
            //'End Using

            //'if (pb.Image Is Nothing = false ) {
            //'    pb.Image.Dispose()
            //'}

            //'pb.Image = bmp3
            //'pb.Invalidate()


            //' Me.DoubleBuffered = true

            //'if (lstThreads.SelectedIndex >= 0 ) {
            //'    //' if (ThreadManager.Games.Count() >= lstThreads.SelectedIndex ) {

            //'    //' ThreadManager.Games can become 0 in a thread.
            //'    Dim Game As OctoGameNodeGame = Nothing
            //'        Try
            //'            Game = ThreadManager.Games(lstThreads.SelectedIndex)
            //'        Catch ex As Exception
            //'            Debug.WriteLine("Timer1.Tick " & ex.Message)
            //'        End Try

            //'        if (Game.IsSomething() ) {
            //'            Dim OriginalCount As Long = Game.StatusControl.Count
            //'            While Game.StatusControl.Count > 0
            //'                Dim sci As StatusControlItem = Nothing
            //'                if (Game.StatusControl.TryDequeue(sci) ) {
            //'                    StatusControl1.Queue.Add(sci)

            //'                }
            //'            End While

            //'            if (OriginalCount > 0 ) {
            //'                StatusControl1.Invalidate()
            //'            }
            //'        }
            //'    //' }
            //'}

            if (ThreadManager.LoadThreadManager.IsSomething())
            {


                lblClickCount.Text = String.Format("{0:n0}", ThreadManager.ClickCount);
                lblClickCountTotal.Text = String.Format("{0:n0}", ThreadManager.ClickCount + ThreadManager.LoadThreadManager.ClickCount);


                lblWaiting.Text = String.Format("{0:n0} s", ThreadManager.WaitLength / 1000);
                TimeSpan t = TimeSpan.FromSeconds((ThreadManager.WaitLength + ThreadManager.LoadThreadManager.WaitLength) / 1000);

                String Time = "";
                if (t.Days > 0)
                {
                    Time = Time + t.Days.ToString().PadLeft(2, '0') + "d ";
                }

                Time = Time + t.Hours.ToString().PadLeft(2, '0') + "h ";
                Time = Time + t.Minutes.ToString().PadLeft(2, '0') + "m ";
                Time = Time + t.Seconds.ToString().PadLeft(2, '0') + "s ";


                lblWaitingTotal.Text = Time;

                lblScreenshots.Text = String.Format("{0:n0}", ThreadManager.ScreenShots);
                lblScreenshotsTotal.Text = String.Format("{0:n0}", ThreadManager.ScreenShots + ThreadManager.LoadThreadManager.ScreenShots);

                lblContinue.Text = String.Format("{0:n0}", ThreadManager.GoContinue);
                lblContinueTotal.Text = String.Format("{0:n0}", ThreadManager.GoContinue + ThreadManager.LoadThreadManager.GoContinue);

                lblChild.Text = String.Format("{0:n0}", ThreadManager.GoChild);
                lblChildTotal.Text = String.Format("{0:n0}", ThreadManager.GoChild + ThreadManager.LoadThreadManager.GoChild);

                lblHome.Text = String.Format("{0:n0}", ThreadManager.GoHome);
                lblHomeTotal.Text = String.Format("{0:n0}", ThreadManager.GoHome + ThreadManager.LoadThreadManager.GoHome);


            }
            //'            if (Game.ThreadLastNodeAction.IsSomething ) {
            //'                lblLastNodeAction.Text = Game.ThreadLastNodeAction.Text
            //'            }

            //'            if (Game.ThreadLastNodeEvent.IsSomething ) {
            //'                lblLastNodeEvent.Text = Game.ThreadLastNodeEvent.Text
            //'            }

            //'            lblGameLoops.Text = Game.GameLoops
            //'            lblScreenshots.Text = Game.ScreenShotsTaken

            //'            if (Game.AbsoluteLastNode.IsSomething ) {

            //'                lblLastNode.Text = Game.AbsoluteLastNode.Text
            //'                lblStartTime.Text = Game.StartTime.ToString()

            //'                Dim Seconds As Long = DateDiff(DateInterval.Second, Game.StartTime, Now)

            //'                lblRunDuration.Text = Seconds & " Seconds "

            //'                //' RT.Game.AbsoluteLastNode.BackColor = Color.LightGray

            //'                if (TimerList.Contains(Game.AbsoluteLastNode) ) {
            //'                    TimerList.Remove(Game.AbsoluteLastNode)
            //'                }

            //'                if (TimerList.Count > 5 ) {
            //'                    TimerList(4).BackColor = Nothing
            //'                    TimerList.RemoveAt(4)
            //'                }

            //'                TimerList.Insert(0, Game.AbsoluteLastNode)

            //'                Dim R As Integer = 180
            //'                Dim G As Integer = 180
            //'                Dim B As Integer = 180

            //'                For Each node In TimerList
            //'                    node.BackColor = Color.FromArgb(R, G, B)
            //'                    R = R + 15
            //'                    G = G + 15
            //'                    B = B + 15
            //'                Next
            //'            }
            //'        }
            //'    }
            //'}


            foreach (GameNodeGame game in ThreadManager.Games)
            {

                if (game.IsSomething())
                {
                    if (game.SaveVideo)
                    {
                        if (game.VideoFrameLimit > 0)
                        {
                            if (game.Video.IsSomething() == false)
                            {
                                if (game.BitmapClones.IsSomething())
                                {
                                    if (game.BitmapClones.Count > 0)
                                    {
                                        Bitmap bmp = game.BitmapClones.First();
                                        String FileName = StartNewVideo(game, bmp);
                                        Log("Starting new video");
                                        Log(FileName);
                                        bmp = null;
                                        //'don//'t dispose re-reading it later.
                                    }
                                }
                            }

                            if (game.Video.IsSomething())
                            {
                                while (game.BitmapClones.Count > 0)
                                {


                                    Bitmap bmp = null;
                                    if (game.BitmapClones.TryDequeue(out bmp))
                                    {
                                        if (game.VideoWidth != bmp.Width || game.VideoHeight != bmp.Height)
                                        {
                                            game.Video.Release();
                                            game.Video = null;
                                            String FileName = StartNewVideo(game, bmp);
                                            Log("New Video Due to New Resolution:" + bmp.Width + "x" + bmp.Height);
                                            Log(FileName);
                                        }
                                        OpenCvSharp.Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);
                                        game.Video.Write(mat);
                                        game.VideoFrameLimit = game.VideoFrameLimit - 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            while (game.BitmapClones.Count > 0)
                            {
                                Bitmap bmp = null;
                                game.BitmapClones.TryDequeue(out bmp);
                                bmp.Dispose();
                                bmp = null;

                            }

                        }
                    }
                }
            }

        }

        private String StartNewVideo(GameNodeGame game, Bitmap bmp)
        {
            String MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String Directory = System.IO.Path.Combine(MyDocuments, Utils.ApplicationName, game.GameNodeName, "Video");
            if (System.IO.Directory.Exists(Directory))
            {
                //'do nothing
            }
            else
            {
                System.IO.Directory.CreateDirectory(Directory);
            }

            String Filename = Directory + @"\" + game.GameNodeName + DateTime.Now.ToString("ATSyyyyMMddHHmmss") + ".avi";
            game.Video = new OpenCvSharp.VideoWriter(Filename, OpenCvSharp.FourCCValues.DIVX, 1, new OpenCvSharp.Size(bmp.Width, bmp.Height), true);
            game.VideoHeight = bmp.Height;
            game.VideoWidth = bmp.Width;

            return Filename;
        }

        private void BitmapChildren(GameNodeAction node, Bitmap bmp)
        {
            foreach (GameNodeAction child in node.Nodes)
            {
                if (child.GameNodeType == GameNodeType.Action)
                {
                    if (child.UseParentPicture)
                    {
                        if (child.ActionType == ActionType.Action)
                        {
                            Log("Linking Child: " + child.Name);
                            child.Bitmap = bmp.Clone() as Bitmap;
                            BitmapChildren(child, bmp);
                        }
                    }
                }
            }


        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            switch (lblMode.Text)
            {
                case "Event":
                    if (rdoColorPoint.Checked)
                    {
                        DataGridViewRow Row = dgv.Rows[0].Clone() as DataGridViewRow;

                        int RowIndex = dgv.Rows.Add();
                        dgv.Rows[RowIndex].Cells["dgvID"].Value = RowIndex + 1;
                        dgv.Rows[RowIndex].Cells["dgvRed"].Value = PictureBox1Color.R.ToString();
                        dgv.Rows[RowIndex].Cells["dgvGreen"].Value = PictureBox1Color.G.ToString();
                        dgv.Rows[RowIndex].Cells["dgvBlue"].Value = PictureBox1Color.B.ToString();

                        dgv.Rows[RowIndex].Cells["dgvX"].Value = PictureBox1X;
                        dgv.Rows[RowIndex].Cells["dgvY"].Value = PictureBox1Y;
                        dgv.Rows[RowIndex].Cells["dgvScan"].Value = "Scn";
                        dgv.Rows[RowIndex].Cells["dgvRemove"].Value = "Rem";

                        // Attempt to set adaptive colors for background color and font, tries to avoid white font with white background.
                        DataGridViewCellStyle Style = Utils.GetDataGridViewCellStyleFromColor(PictureBox1Color);

                        dgv.Rows[RowIndex].Cells["dgvRed"].Style = Style;
                        dgv.Rows[RowIndex].Cells["dgvGreen"].Style = Style;
                        dgv.Rows[RowIndex].Cells["dgvBlue"].Style = Style;

                        PictureBox1.Refresh();

                        ArchaicSave();

                    }
                    break;
                case "Action":

                    break;
                default:
                    break;
            }
        }

        public void ArchaicSave()
        {
            AfterCompletionType ChosenAfterCompletionType = AfterCompletionType.Continue;

            if (rdoAfterCompletionContinue.Checked)
            {
                ChosenAfterCompletionType = AfterCompletionType.Continue;
            }

            if (rdoAfterCompletionHome.Checked)
            {
                ChosenAfterCompletionType = AfterCompletionType.Home;
            }

            if (rdoAfterCompletionParent.Checked)
            {
                ChosenAfterCompletionType = AfterCompletionType.Parent;
            }

            if (rdoAfterCompletionStop.Checked)
            {
                ChosenAfterCompletionType = AfterCompletionType.Stop;
            }

            if (rdoAfterCompletionRecycle.Checked)
            {
                ChosenAfterCompletionType = AfterCompletionType.Recycle;
            }

            GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

            if (cboDelayMS.Text.IsNumeric())
            {
                Picturable.DelayMS = cboDelayMS.Text.ToInt();
            }
            else
            {
                Picturable.DelayMS = Picturable.DefaultDelayMS();
            }

            if (cboDelayS.Text.IsNumeric())
            {
                Picturable.DelayS = cboDelayS.Text.ToInt();
            }
            else
            {
                Picturable.DelayS = Picturable.DefaultDelayS();
            }

            if (cboDelayM.Text.IsNumeric())
            {
                Picturable.DelayM = cboDelayM.Text.ToInt();
            }
            else
            {
                Picturable.DelayM = Picturable.DefaultDelayM();
            }

            if (cboDelayH.Text.IsNumeric())
            {
                Picturable.DelayH = cboDelayH.Text.ToInt();
            }
            else
            {
                Picturable.DelayH = Picturable.DefaultDelayH();
            }

            Picturable.Points = cboPoints.Text.ToInt();

            Picturable.UseParentPicture = chkUseParentScreenshot.Checked;

            if (PictureBox1.Image.IsSomething())
            {
                Picturable.Bitmap = PictureBox1.Image as Bitmap;
                Picturable.ResolutionWidth = PictureBox1.Image.Width;
                Picturable.ResolutionHeight = PictureBox1.Image.Height;
            }

            Picturable.AfterCompletionType = ChosenAfterCompletionType;

            Picturable.IsLimited = chkUseLimit.Checked;
            Picturable.ExecutionLimit = Convert.ToInt32(numIterations.Value);
            Picturable.IsWaitFirst = chkWaitFirst.Checked;
            Picturable.LimitRepeats = chkLimitRepeats.Checked;
            switch (cboWaitType.Text)
            {
                case "Iteration":
                    Picturable.WaitType = WaitType.Iteration;
                    break;
                case "Once Per Session":
                    Picturable.WaitType = WaitType.Session;
                    break;
                case "Time":
                    Picturable.WaitType = WaitType.Time;
                    break;
                default:
                    break;
            }


            if (lblMode.Text == "Event")
            {
                GameNodeAction EventNode = PanelLoadNode;
                if (EventNode.IsNothing())
                {
                    Log("Unable to identify selected node.");
                    return;
                }

                EventNode.GameNodeName = txtEventName.Text;

                //'      Color.
                EventNode.ClickList.Clear();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow == false)
                    {
                        if (row.Cells["dgvRed"].Value.IsSomething())
                        {
                            SingleClick SingleClick = new SingleClick();

                            int R = row.Cells["dgvRed"].Value.ToString().ToInt();
                            int G = row.Cells["dgvGreen"].Value.ToString().ToInt();
                            int B = row.Cells["dgvBlue"].Value.ToString().ToInt();

                            SingleClick.Color = Color.FromArgb(R, G, B);

                            SingleClick.X = row.Cells["dgvX"].Value.ToString().ToInt();
                            SingleClick.Y = row.Cells["dgvY"].Value.ToString().ToInt();
                            EventNode.ClickList.Add(SingleClick);

                            if (rdoAnd.Checked)
                            {
                                EventNode.LogicChoice = "AND";
                            }
                            else if (rdoOR.Checked)
                            {
                                EventNode.LogicChoice = "OR";
                            }
                            else
                            {
                                EventNode.LogicChoice = "CUSTOM";
                            }
                        }
                    }
                }
                //' LoadPanelSingleColorAtSingleLocation(PanelLoadNode)
                //'tv.SelectedNode = EventNode
            }
            else
            {
                GameNodeAction ActionNode = PanelLoadNode as GameNodeAction;
                //'Action
                if (ActionNode.IsNothing())
                {
                    Log("Unable to identify selected node.");
                    return;
                }

                if (rdoModeRangeClick.Checked)
                {
                    ActionNode.Mode = Mode.RangeClick;
                }
                else
                {
                    ActionNode.Mode = Mode.ClickDragRelease;
                }
                ActionNode.GameNodeName = txtEventName.Text;

                if (cboDelayMS.Text.IsNumeric())
                {
                    ActionNode.DelayMS = cboDelayMS.Text.ToInt();
                }
                else
                {
                    ActionNode.DelayMS = ActionNode.DefaultDelayMS();
                }

                //' LoadPanelSingleColorAtSingleLocation(PanelLoadNode)
                //'tv.SelectedNode = ActionNode
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("PictureBox1_MouseDown");
            GameNodeAction Node = tv.SelectedNode as GameNodeAction;
            switch (lblMode.Text)
            {
                case "Action":
                    PictureBox1MouseDown = true;
                    Node.Rectangle = new Rectangle(e.X, e.Y, 0, 0);
                    break;
                case "Event":
                    if (rdoColorPoint.Checked)
                    {
                        // do nothing
                    }
                    else
                    {
                        PictureBox1MouseDown = true;
                        Node.Rectangle = new Rectangle(e.X, e.Y, 0, 0);
                    }
                    break;
                default:
                    break;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            GameNodeAction Node = tv.SelectedNode as GameNodeAction;
            ShowZoom(PictureBox1, PictureBox2, e, PanelSelectedColor, lblRHSColor, lblRHSXY, ref PictureBox1X, ref PictureBox1Y, ref PictureBox1Color, PictureBox1MouseDown, ref Node.Rectangle);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (lblMode.Text)
            {
                case "Action":
                    PictureBox1MouseDown = false;
                    break;
                case "Event":
                    if (rdoColorPoint.Checked)
                    {
                        // do nothing
                    }
                    else
                    {
                        PictureBox1MouseDown = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            GameNodeAction Node = tv.SelectedNode as GameNodeAction;

            switch (Node.ActionType)
            {
                case ActionType.Action:
                    Node.PaintNode(e.Graphics);
                    break;

                case ActionType.Event:
                    if (rdoColorPoint.Checked)
                    {
                        Utils.DrawColorPoints(e, dgv, "dgv", "dgvX", "dgvY");
                    }
                    else
                    {
                        if (Node.Rectangle.IsEmpty)
                        {
                            Node.Rectangle = new Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height);
                        }
                        Utils.DrawMask(PictureBox1, Node.Rectangle, e);

                        UpdateMaskSize();
                    }
                    break;
                case ActionType.RNG:
                    break;
                case ActionType.RNGContainer:
                    break;
                default:
                    break;
            }
        }

        private void UpdateMaskSize()
        {
            GameNodeAction Node = tv.SelectedNode as GameNodeAction;
            lblMaskSize.Text = Node.Rectangle.ToString();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {

                    return;
                }

                if (e.ColumnIndex == dgv.Columns["dgvRemove"].Index)
                {
                    dgv.Rows.Remove(dgv.Rows[e.RowIndex]);

                    for (int i = e.RowIndex; i < dgv.Rows.Count - 1; i++)
                    {
                        dgv.Rows[i].Cells["dgvID"].Value = i + 1;
                    }

                    if (IsPanelLoading == false)
                    {
                        ArchaicSave();
                    }

                    PictureBox1.Refresh();
                    return;
                }

                if (e.ColumnIndex == dgv.Columns["dgvScan"].Index)
                {
                    int X = dgv.Rows[e.RowIndex].Cells[dgv.Columns["dgvX"].Index].Value.ToString().ToInt();
                    int Y = dgv.Rows[e.RowIndex].Cells[dgv.Columns["dgvY"].Index].Value.ToString().ToInt();

                    int R = dgv.Rows[e.RowIndex].Cells["dgvRed"].Value.ToString().ToInt();
                    int G = dgv.Rows[e.RowIndex].Cells["dgvGreen"].Value.ToString().ToInt();
                    int B = dgv.Rows[e.RowIndex].Cells["dgvBlue"].Value.ToString().ToInt();

                    Color CurrentColor = Color.FromArgb(R, G, B);

                    Color TargetColor = GetColorAtTargetWindowXY(X, Y);

                    if (TargetColor != CurrentColor)
                    {
                        //'Count how many rows already have this xycolor combination

                        int XYColorCount = 0;

                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow == false)
                            {
                                if (row.Cells["dgvRed"].Value.IsSomething())
                                {
                                    int RowR = row.Cells["dgvRed"].Value.ToString().ToInt();
                                    int RowG = row.Cells["dgvGreen"].Value.ToString().ToInt();
                                    int RowB = row.Cells["dgvBlue"].Value.ToString().ToInt();

                                    Color RowColor = Color.FromArgb(RowR, RowG, RowB);

                                    Boolean ColorMatches = RowColor == TargetColor;
                                    Boolean XMatches = row.Cells["dgvX"].Value.ToString().ToInt() == X;
                                    Boolean YMatches = row.Cells["dgvY"].Value.ToString().ToInt() == Y;
                                    if (ColorMatches && XMatches && YMatches)
                                    {
                                        XYColorCount = XYColorCount + 1;
                                    }
                                }
                            }
                        }

                        if (XYColorCount == 0)
                        {
                            //' add new row.
                            int RowIndex = dgv.Rows.Add();
                            dgv.Rows[RowIndex].Cells["dgvID"].Value = RowIndex + 1;
                            dgv.Rows[RowIndex].Cells["dgvRed"].Value = TargetColor.R.ToString();
                            dgv.Rows[RowIndex].Cells["dgvGreen"].Value = TargetColor.G.ToString();
                            dgv.Rows[RowIndex].Cells["dgvBlue"].Value = TargetColor.B.ToString();

                            dgv.Rows[RowIndex].Cells["dgvX"].Value = X;
                            dgv.Rows[RowIndex].Cells["dgvY"].Value = Y;
                            dgv.Rows[RowIndex].Cells["dgvRemove"].Value = "Rem";
                            dgv.Rows[RowIndex].Cells["dgvScan"].Value = "Scn";

                            // Attempt to set adaptive colors for background color and font, tries to avoid white font with white background.
                            DataGridViewCellStyle Style = Utils.GetDataGridViewCellStyleFromColor(TargetColor);
                            dgv.Rows[RowIndex].Cells["dgvRed"].Style = Style;
                            dgv.Rows[RowIndex].Cells["dgvGreen"].Style = Style;
                            dgv.Rows[RowIndex].Cells["dgvBlue"].Style = Style;

                            if (IsPanelLoading == false)
                            {
                                ArchaicSave();
                            }
                        }
                    }
                    PictureBox1.Refresh();
                }
            }
            catch (System.InvalidOperationException ex)
            {
                Log("Can't remove on the Insert row");
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private Color GetColorAtTargetWindowXY(int x, int y)
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();

            String MainWindowTitle = GameNode.TargetWindow;

            IntPtr MainWindowHandle = GameNode.GetWindowHandleByWindowName();

            if (MainWindowHandle.ToInt32() > 0)
            {
                Bitmap bmp = Utils.GetBitmapFromWindowHandle(MainWindowHandle);
                Color Color = bmp.GetPixel(x, y);
                return Color;

            }

            return Color.Empty;
        }

        private void cmdAddObject2_Click(object sender, EventArgs e)
        {
            //' Change the Panel to Object Screenshot
            SetPanel(PanelMode.ObjectScreenshot);

            //' Hide the Make object buttone because the name is not long enough
            cmdMakeObject.Enabled = false;

            //' Reset the Rectangle in case it//'s already being used.
            PictureObjectScreenshotRectanble = new Rectangle();

            //' Set the current image.
            PictureObjectScreenshot.Image = PictureBox1.Image;

            PanelLoadNode.BackColor = Color.White;
        }

        private void toolStripButtonRunScript_Click(object sender, EventArgs e)
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();

            LoadInstance(GameNode);
        }

        private void tabTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Event tabTree_SelectedIndexChanged");

            switch (tabTree.SelectedIndex)
            {
                case 0:
                    tv_AfterSelect(null, null);
                    break;
                case 1:
                    SetPanel(PanelMode.Thread);
                    if (lstThreads.Items.Count > 0)
                    {
                        lstThreads.SelectedIndex = 0;
                    }
                    break;
                case 2:
                    SetPanel(PanelMode.Schedule);

                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void cmdAddSingleColorAtSingleLocationTakeASceenshot_Click(object sender, EventArgs e)
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();

            String TargetWindow = GameNode.TargetWindow;

            IntPtr MainWindowHandle = GameNode.GetWindowHandleByWindowName();

            Debug.Print("cmdAddSingleColorAtSingleLocationTakeASceenshot_Click TW=" + TargetWindow + " MWH= " + MainWindowHandle);

            if (MainWindowHandle.ToInt32() > 0)
            {
                Bitmap bmp = Utils.GetBitmapFromWindowHandle(MainWindowHandle);
                lblResolution.Text = bmp.Width + "x" + bmp.Height;

                PictureBox1.Image = bmp;

                if (dgv.Rows.Count > 1)
                {
                    if (lblMode.Text == "Event")
                    {
                        DialogResult Result = MessageBox.Show("Screenshot taken, do you want to re-sample the colors?", "Resample Colors?", MessageBoxButtons.YesNo);

                        if (Result == DialogResult.Yes)
                        {
                            ResampleColors();
                        }
                    }
                }

                if (IsPanelLoading == false)
                {
                    ArchaicSave();

                }
            }
            else
            {
                Log("Unable to locate window: " + TargetWindow);
            }

        }

        private void rdoAfterCompletionContinue_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void rdoAfterCompletionHome_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void rdoAfterCompletionParent_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void rdoAfterCompletionStop_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void cboDelayMS_TextChanged(object sender, EventArgs e)
        {
            if (cboDelayMS.Text.Trim().Length > 0)
            {
                if (cboDelayMS.Text.IsNumeric())
                {
                    // do nothing
                }
                else
                {
                    Log("Delay 1/1000 sec must be numberic 0-999.");
                }
            }
            lblDelayCalc.Text = Utils.CalculateDelay(cboDelayH.Text.ToInt(), cboDelayM.Text.ToInt(), cboDelayS.Text.ToInt(), cboDelayMS.Text.ToInt());

            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }

        }

        private void cboDelayS_TextChanged(object sender, EventArgs e)
        {
            if (cboDelayS.Text.Trim().Length > 0)
            {
                if (cboDelayS.Text.IsNumeric())
                {

                }
                else
                {
                    Log("Delay Seconds must be numeric 0 - 59");
                }
            }

            lblDelayCalc.Text = Utils.CalculateDelay(cboDelayH.Text.ToInt(), cboDelayM.Text.ToInt(), cboDelayS.Text.ToInt(), cboDelayMS.Text.ToInt());

            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }

        }

        private void cboDelayM_TextChanged(object sender, EventArgs e)
        {
            if (cboDelayM.Text.Trim().Length > 0)
            {
                if (cboDelayM.Text.IsNumeric())
                {
                    // do nothing
                }
                else
                {
                    Log("Delay Minutes must be numeric 0 - 59");
                }
            }

            lblDelayCalc.Text = Utils.CalculateDelay(cboDelayH.Text.ToInt(), cboDelayM.Text.ToInt(), cboDelayS.Text.ToInt(), cboDelayMS.Text.ToInt());
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }

        }

        private void cboDelayH_TextChanged(object sender, EventArgs e)
        {
            if (cboDelayH.Text.Trim().Length > 0)
            {
                if (cboDelayH.Text.IsNumeric())
                {
                    // do nothing
                }
                else
                {
                    Log("Delay Hours must be numeric");
                }
            }

            lblDelayCalc.Text = Utils.CalculateDelay(cboDelayH.Text.ToInt(), cboDelayM.Text.ToInt(), cboDelayS.Text.ToInt(), cboDelayMS.Text.ToInt());
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void chkUseLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                Node.IsLimited = chkUseLimit.Checked;
            }

            // Gray out other controls if not using.
            cboWaitType.Enabled = chkUseLimit.Checked;
            chkWaitFirst.Enabled = chkUseLimit.Checked;
            numIterations.Enabled = chkUseLimit.Checked;
            lnkLimitTime.Enabled = chkUseLimit.Checked;
            chkLimitRepeats.Enabled = chkUseLimit.Checked;
            lblLimitIterationsLabel.Enabled = chkUseLimit.Checked;
            lblLimitWaitType.Enabled = chkUseLimit.Checked;
        }

        private void cboWaitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }

            switch (cboWaitType.Text)
            {
                case "Iteration":
                    lblLimitTimeLabel.Visible = false;
                    lnkLimitTime.Visible = false;
                    lblLimitIterationsLabel.Visible = true;
                    numIterations.Visible = true;
                    chkLimitRepeats.Visible = true;
                    chkWaitFirst.Visible = true;
                    break;
                case "Time":
                    lblLimitTimeLabel.Visible = true;
                    lnkLimitTime.Visible = true;
                    lblLimitIterationsLabel.Visible = false;
                    numIterations.Visible = false;
                    chkLimitRepeats.Visible = true;
                    chkWaitFirst.Visible = true;
                    break;
                case "Once Per Session":
                    lblLimitTimeLabel.Visible = false;
                    lnkLimitTime.Visible = false;
                    lblLimitIterationsLabel.Visible = false;
                    numIterations.Visible = false;
                    chkLimitRepeats.Visible = false;
                    chkWaitFirst.Visible = false;

                    break;
                default:
                    break;
            }
        }

        private void chkWaitFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                Node.IsWaitFirst = chkWaitFirst.Checked;
            }

        }

        private void numIterations_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                Node.ExecutionLimit = (long)numIterations.Value;
            }

        }

        private void chkLimitRepeats_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                Node.LimitRepeats = chkLimitRepeats.Checked;
            }

        }

        private void lnkLimitTime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GameNodeAction Picturable = PanelLoadNode as GameNodeAction;
            frmTimeCapture frm = new frmTimeCapture();
            frm.DelayH = Picturable.LimitDelayH;
            frm.DelayM = Picturable.LimitDelayM;
            frm.DelayS = Picturable.LimitDelayS;
            frm.DelayMS = Picturable.LimitDelayMS;

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            if (frm.IsSaved)
            {

                Picturable.LimitDelayH = frm.DelayH;
                Picturable.LimitDelayM = frm.DelayM;
                Picturable.LimitDelayS = frm.DelayS;
                Picturable.LimitDelayMS = frm.DelayMS;

                lnkLimitTime.Text = Utils.CalculateDelay(frm.DelayH, frm.DelayM, frm.DelayS, frm.DelayMS);

            }

        }


        private void cboPoints_TextChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void NumericXOffset_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.RelativeXOffset = (int)NumericXOffset.Value;
                PictureBox1.Invalidate();
            }
        }

        private void NumericYOffset_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.RelativeYOffset = (int)NumericYOffset.Value;
                PictureBox1.Invalidate();
            }
        }

        private void cboObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                String TargetSearch = cboObject.Text;
                if (TargetSearch == "Choose a Object")
                {
                    PictureBoxEventObjectSelection.Image = null;
                    ActionNode.ObjectName = "";
                    return;
                }

                //'Save cboObject
                ActionNode.ObjectName = cboObject.Text;

                LoadObjectSelectionImage();
            }
        }

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;

                switch (cboChannel.Text)
                {
                    case "Red Channel":
                        ActionNode.Channel = "Red";
                        break;
                    case "Green Channel":
                        ActionNode.Channel = "Green";
                        break;
                    case "Blue Channel":
                        ActionNode.Channel = "Blue";
                        break;
                    default:
                        ActionNode.Channel = "Red";
                        break;
                }
            }
        }

        private void NumericObjectThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ObjectThreshold = (long)NumericObjectThreshold.Value;
            }
        }

        private void cmdMaxMask_Click(object sender, EventArgs e)
        {
            GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
            ActionNode.Rectangle = new Rectangle(0, 0, PictureBox1.Image.Width, PictureBox1.Image.Height);
            PictureBox1.Invalidate();
        }

        private void dgSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = sender as DataGridView;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                ScheduleItem Item = Schedule.ScheduleList[e.RowIndex];

                frmScheduler frm = new frmScheduler(Item);
                frm.IsAdding = false;

                frm.ShowDialog();

                if (frm.IsSaving)
                {
                    if (frm.IsAdding)
                    {
                        ScheduleItem si = frm.getItem();
                        Schedule.ScheduleList.Add(si);
                    }
                    else
                    {
                        frm.getItem();
                    }
                    SaveSchedule();
                }
                else
                {
                    if (frm.IsDeleting)
                    {
                        Schedule.ScheduleList.Remove(Item);
                    }
                    SaveSchedule();
                }
                ReloadScheduleView();
            }
        }

        //This could use some work, 
        // Attempts to determine the next event and displays the time.
        // Also launches a new thread if it's time to run.
        private void timerScheduler_Tick(object sender, EventArgs e)
        {
            DateTime LowestNextRun = DateTime.MinValue;

            foreach (ScheduleItem si in Schedule.ScheduleList)
            {

                if (si.IsEnabled)
                {
                    DateTime StartsTodayAt = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy ") + si.StartsAt.ToString("HH:mm"));

                    if (si.CurrentRun == DateTime.MinValue)
                    {
                        if (StartsTodayAt.Hour == DateTime.Now.Hour && StartsTodayAt.Minute == DateTime.Now.Minute)
                        {
                            LaunchScheduledGame(si);
                        }
                    }
                    else
                    {
                        if (si.NextRun.Day == DateTime.Now.Day && si.NextRun.Hour == DateTime.Now.Hour && si.NextRun.Minute == DateTime.Now.Minute)
                        {
                            LaunchScheduledGame(si);
                        }

                    }

                    DateTime CalcNextRun = si.CalculateNextRun();

                    //' Is First Run
                    if (LowestNextRun == DateTime.MinValue)
                    {
                        LowestNextRun = CalcNextRun;
                    }
                    else
                    {

                        if (LowestNextRun > CalcNextRun)
                        {
                            LowestNextRun = CalcNextRun;
                        }

                    }
                }

            }
            if (LowestNextRun == DateTime.MaxValue || LowestNextRun == DateTime.MinValue)
            {
                toolSchedulerRunning.Text = "Scheduler running, but no Schedules enabled.";
            }
            else
            {
                toolSchedulerRunning.Text = "Next Scheduled Event: " + LowestNextRun.ToString("MM/dd/yyyy hh:mm tt") + " in " + Utils.CalculateDelay(LowestNextRun);
            }

        }

        private void LaunchScheduledGame(ScheduleItem si)
        {
            si.CurrentRun = DateTime.Now;
            si.CalculateAndSetNextRun();

            if (System.IO.File.Exists(si.AppPath))
            {
                GameNodeGame Game = GameNodeGame.LoadGameFromFile(si.AppPath, false, TitleBarHeight);

                if (Game.IsSomething())
                {
                    Game.InstanceToLaunch = si.InstanceNumber.ToString();

                    StartEmmulator(Game, Game.PackageName, Game.InstanceToLaunch);

                    LoadInstance(Game);
                }
            }
            else
            {
                Log("File not found: " + si.AppPath);
            }

        }

        private void rdoModeRangeClick_CheckedChanged(object sender, EventArgs e)
        {
            PictureBox1.Refresh();
            if (IsPanelLoading == false)
            {

                ArchaicSave();
            }
            Utils.SetIcons(PanelLoadNode);

            if (rdoModeRangeClick.Checked)
            {
                panelRightSwipeProperties.Visible = false;
            }

        }

        private void rdoModeClickDragRelease_CheckedChanged(object sender, EventArgs e)
        {
            PictureBox1.Refresh();
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
            Utils.SetIcons(PanelLoadNode);

            if (rdoModeClickDragRelease.Checked)
            {
                if (IsPanelLoading == false)
                {
                    panelRightSwipeProperties.Visible = true;
                    GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                    if (ActionNode.IsParentObjectSearch())
                    {
                        groupBoxClickDragReleaseObjectSearch.Enabled = true;
                        ActionNode.ClickDragReleaseMode = ClickDragReleaseMode.Start;
                        rdoObjectSearchStart.Checked = true;
                    }
                    else
                    {
                        groupBoxClickDragReleaseObjectSearch.Enabled = false;
                        ActionNode.ClickDragReleaseMode = ClickDragReleaseMode.None;
                    }

                }
                panelRightClickProperties.Visible = false;
            }



        }

        private void mnuAddEvent_Click(object sender, EventArgs e)
        {
            AddNewEvent();
        }

        private void AddNewEvent()
        {
            GameNodeAction Event = new GameNodeAction("New Event", ActionType.Event);
            tv.SelectedNode.Nodes.Add(Event);
            tv.SelectedNode = Event;
            SetPanel(PanelMode.PanelColorEvent);
            LoadPanelSingleColorAtSingleLocation(Event);
            //LoadParentScreenshotIfNecessary();
            cmdAddSingleColorAtSingleLocationTakeASceenshot.PerformClick();
            ArchaicSave();
            ThreadManager.IncrementNewEventAdded();
        }

        private void mnuAddAction_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        private void AddAction()
        {
            GameNode OriginalNode = tv.SelectedNode as GameNode;
            GameNodeAction GameNodeAction = new GameNodeAction("Click " + tv.SelectedNode.Text, ActionType.Action);

            OriginalNode.Nodes.Add(GameNodeAction);
            tv.SelectedNode = GameNodeAction;

            // must be after Node is added to tree.
            GameNodeAction.ClickSpeed = GameNodeAction.GetGameNodeGame().DefaultClickSpeed;

            SetPanel(PanelMode.PanelColorEvent);

            LoadPanelSingleColorAtSingleLocation(GameNodeAction);
            cmdAddSingleColorAtSingleLocationTakeASceenshot.PerformClick();
            //LoadParentScreenshotIfNecessary();

            InitalizeOffsets();

            ThreadManager.IncrementNewActionAdded();
            ArchaicSave();
        }

        private void mnuAddRNG_Click(object sender, EventArgs e)
        {
            AddRNGContainer();
        }

        private void AddRNGContainer()
        {
            GameNodeAction RNGContainer = new GameNodeAction("New RNG", ActionType.RNGContainer);
            RNGContainer.AutoBalance = true;
            tv.SelectedNode.Nodes.Add(RNGContainer);
            tv.SelectedNode = RNGContainer;

            //'  SetPanel(PanelMode.PanelColorEvent)
            //' LoadPanelSingleColorAtSingleLocation(RNGContainer)

            GameNodeAction GameNodeAction = new GameNodeAction("", ActionType.RNG);
            GameNodeAction.Percentage = 100;
            RNGContainer.Nodes.Add(GameNodeAction);
            tv.SelectedNode = GameNodeAction;

            SetPanel(PanelMode.PanelColorEvent);
            LoadPanelSingleColorAtSingleLocation(GameNodeAction);
            ThreadManager.IncrementNewRNGContainer();
        }

        private void mnuAddRNGNode_Click(object sender, EventArgs e)
        {
            AddRNGNode(tv.SelectedNode as GameNodeAction);
        }

        private void mnuTestAllEvents_Click(object sender, EventArgs e)
        {
            TestAllEvents();
        }

        private void TestAllEvents()
        {
            SetPanel(PanelMode.TestAllEvents);

            //'walk to Event//'s node
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();
            GameNodeEvents EventsNode = GameNode.GetEventsNode();

            tvTestAllEvents.Nodes.Clear();
            tvTestAllEvents.Nodes.Add(EventsNode.CloneMe());
            tvTestAllEvents.ExpandAll();

            String TargetWindow = GameNode.TargetWindow;
            IntPtr MainWindowHandle = GameNode.GetWindowHandleByWindowName();

            if (MainWindowHandle.ToInt32() > 0)
            {
                PictureTestAllTest.Image = Utils.GetBitmapFromWindowHandle(MainWindowHandle);
            }
            else
            {
                Log("Unable to locate window: " + TargetWindow);
                SetPanel(PanelMode.Events);
                return;
            }

            if (PictureTestAllTest.Image.IsSomething())
            {
                lblTestWindowResolution.Text = PictureTestAllTest.Image.Width + " x " + PictureTestAllTest.Image.Height;
            }

            // Calculate each node for true or false
            foreach (GameNodeEvents nodeEvents in tvTestAllEvents.Nodes)
            {
                foreach (GameNodeAction action in nodeEvents.Nodes)
                {
                    CheckEvents(action);
                }
            }

            // Attempt to set the node on the test tree to the selected node in main.
            TreeNode LocatedNode = GetFirstNodeByName(tvTestAllEvents.Nodes[0], tv.SelectedNode.Name);
            if (LocatedNode.IsSomething())
            {
                LocatedNode.EnsureVisible();
                // Simulate a click on the tree to populate tables.
                TreeViewEventArgs Arg = new TreeViewEventArgs(LocatedNode);
                tvTestAllEvents_AfterSelect(null, Arg);
            }
        }

        private TreeNode GetFirstNodeByName(TreeNode parent, String Name)
        {
            foreach (TreeNode Node in parent.Nodes)
            {
                if (Node.Name.StartsWith(Name))
                {
                    return Node;
                }
                TreeNode ChildNode = GetFirstNodeByName(Node, Name);
                if (ChildNode.IsSomething())
                {
                    return ChildNode;
                }
            }
            return null;
        }

        private void CheckEvents(GameNodeAction Node)
        {
            if (Node.ActionType == ActionType.Event)
            {
                Bitmap Bmp = PictureTestAllTest.Image as Bitmap;
                int QualifyingEvents = 0;
                int CenterX = 0;
                int CenterY = 0;
                float DetectedThreashold = 0;

                GameNode AppNode = tv.SelectedNode as GameNode;
                GameNodeGame GameNode = AppNode.GetGameNodeGame();

                if (Node.IsTrue(Bmp, GameNode, ref CenterX, ref CenterY, ref QualifyingEvents, ref DetectedThreashold))
                {
                    //'6 = no
                    //'7 = yes
                    Node.ImageIndex = 7;
                    Node.SelectedImageIndex = 7;
                    Node.BackColor = Color.LightGreen;

                    if (Node.IsColorPoint)
                    {
                        // do nothing
                    }
                    else
                    {
                        int intDetectedThreashold = (int)(DetectedThreashold * 100);
                        Node.GameNodeName = Node.Name + " (x=" + CenterX + " ,y=" + CenterY + ", Detected=" + intDetectedThreashold + ", Limit=" + Node.ObjectThreshold + ")";
                    }
                }
                else
                {
                    //Node.Bitmap = Bmp;
                    Node.ImageIndex = 6;
                    Node.SelectedImageIndex = 6;

                    if (Node.IsColorPoint)
                    {
                        if (Node.LogicChoice == "CUSTOM")
                        {

                        }
                        else
                        {
                            Node.GameNodeName = Node.Name + " - Points(" + QualifyingEvents + ")";

                            if (QualifyingEvents < 10)
                            {
                                Node.BackColor = Color.LightYellow;
                            }
                        }
                    }
                    else
                    {
                        int intDetectedThreashold = (int)(DetectedThreashold * 100);
                        Node.GameNodeName = Node.Name + " (x=" + CenterX + " ,y=" + CenterY + ", Detected=" + intDetectedThreashold + ", Limit=" + Node.ObjectThreshold + ")";
                    }

                }
            }
            else
            {
                // Node it Test All have no purpose so set light gray.
                Node.ForeColor = Color.LightGray;
            }

            foreach (GameNodeAction n in Node.Nodes)
            {
                CheckEvents(n);
            }
        }

        private void mnuAddObject_Click(object sender, EventArgs e)
        {
            //' Change the Panel to Object Screenshot
            SetPanel(PanelMode.ObjectScreenshot);

            //' Hide the Make object buttone because the name is not long enough
            cmdMakeObject.Enabled = false;

            //' Reset the Rectangle in case it//'s already being used.
            PictureObjectScreenshotRectanble = new Rectangle();

            //' Take a screenshot
            cmdObjectScreenshotsTakeAScreenshot_Click(null, null);

            // Clear the Name box
            txtObjectScreenshotName.Text = "";

            // set the cursor
            txtObjectScreenshotName.Focus();
        }

        private void ShowHideTestAllEventsGridsAndLabels(Boolean SetVisible)
        {
            dgvTestAllReference.Visible = SetVisible;
            dgvTest.Visible = SetVisible;
        }

        private void tvTestAllEvents_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                Debug.WriteLine("tvTestAllEvents_AfterSelect");
                lblTestAllCustom.Text = "";

                GameNode GameNode = e.Node as GameNode;

                GameNodeAction Node = null;

                // Make sure that we don't test all actions otherwise it will click/drag everywhere
                switch (GameNode.GameNodeType)
                {
                    case GameNodeType.Action:
                        Node = GameNode as GameNodeAction;
                        if (Node.ActionType == ActionType.Event)
                        {
                            //' do nothing :)
                        }
                        else
                        {
                            Log("Please choose an event note");
                            return;
                        }
                        break;
                    default:
                        Log("Please choose an event note");
                        return;
                        break;
                }

                // show hide grids depending on node type
                if (Node.IsColorPoint)
                {
                    ShowHideTestAllEventsGridsAndLabels(true);
                }
                else
                {
                    // Object Search
                    ShowHideTestAllEventsGridsAndLabels(false);
                }


                // Result is the calculation of true with OR or AND Logic
                // It does not short circuit on first true for OR or first false for AND.
                Boolean Result = false;

                // Final result 
                Boolean FinalResult = false;

                dgvTestAllReference.Rows.Clear();
                dgvTest.Rows.Clear();


                if (Node.LogicChoice == "CUSTOM")
                {
                    lblTestAllCustom.Text = Node.CustomLogic;
                }

                foreach (SingleClick Item in Node.ClickList)
                {
                    int Rowindex = dgvTestAllReference.Rows.Add();
                    dgvTestAllReference.Rows[Rowindex].Cells["dgvTestAllReferenceRed"].Value = Item.Color.R.ToString();
                    dgvTestAllReference.Rows[Rowindex].Cells["dgvTestAllReferenceGreen"].Value = Item.Color.G.ToString();
                    dgvTestAllReference.Rows[Rowindex].Cells["dgvTestAllReferenceBlue"].Value = Item.Color.B.ToString();


                    dgvTestAllReference.Rows[Rowindex].Cells["dgvTestAllReferenceX"].Value = Item.X;
                    dgvTestAllReference.Rows[Rowindex].Cells["dgvTestAllReferenceY"].Value = Item.Y;

                    // Attempt to set adaptive colors for background color and font, tries to avoid white font with white background.
                    DataGridViewCellStyle Style = Utils.GetDataGridViewCellStyleFromColor(Item.Color);

                    dgvTestAllReference.Rows[Rowindex].Cells["dgvTestAllReferenceRed"].Style = Style;
                    dgvTestAllReference.Rows[Rowindex].Cells["dgvTestAllReferenceGreen"].Style = Style;
                    dgvTestAllReference.Rows[Rowindex].Cells["dgvTestAllReferenceBlue"].Style = Style;

                    Rowindex = dgvTest.Rows.Add();

                    //With dgvTest.Rows[Rowindex];
                    DataGridViewRow Row = dgvTest.Rows[Rowindex];
                    Color TargetColor;
                    if (PictureTestAllReference.Height >= Item.Y && PictureTestAllReference.Width >= Item.X && PictureTestAllTest.Image.Height >= Item.Y && PictureTestAllTest.Image.Width >= Item.X)
                    {
                        Bitmap bmp = PictureTestAllTest.Image as Bitmap;
                        TargetColor = bmp.GetPixel(Item.X, Item.Y);
                    }
                    else
                    {
                        TargetColor = Color.Black;
                        Style.ForeColor = Color.White;
                    }

                    Row.Cells["dgvColorTestRed"].Value = TargetColor.R.ToString();
                    Row.Cells["dgvColorTestGreen"].Value = TargetColor.G.ToString();
                    Row.Cells["dgvColorTestBlue"].Value = TargetColor.B.ToString();

                    // Attempt to set adaptive colors for background color and font, tries to avoid white font with white background.
                    Row.Cells["dgvColorTestRed"].Style = Utils.GetDataGridViewCellStyleFromColor(TargetColor);
                    Row.Cells["dgvColorTestGreen"].Style = Utils.GetDataGridViewCellStyleFromColor(TargetColor);
                    Row.Cells["dgvColorTestBlue"].Style = Utils.GetDataGridViewCellStyleFromColor(TargetColor);

                    Row.Cells["dgvXTest"].Value = Item.X;
                    Row.Cells["dgvYTest"].Value = Item.Y;

                    // How far of was the test from the target color.
                    int QualifyingPoints = 0;

                    if (Node.LogicChoice == "AND")
                    {
                        if (TargetColor.CompareColorWithPoints(Item.Color, Node.Points, ref QualifyingPoints))
                        {
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
                    else if (Node.LogicChoice == "OR")
                    {
                        if (TargetColor.CompareColorWithPoints(Item.Color, Node.Points, ref QualifyingPoints))
                        {
                            Result = true;
                        }
                    }
                    else
                    {
                        // Do nothing fancy, just show logic.
                        // Write Custom Logic
                        //Debug.Assert(false);
                    }

                    if (TargetColor.CompareColorWithPoints(Item.Color, Node.Points, ref QualifyingPoints))
                    {
                        Row.Cells["dgvPassFail"].Value = "Test Passed";
                        Style = new DataGridViewCellStyle();
                        Style.BackColor = Color.Green;
                        Row.Cells["dgvPassFail"].Style = Style;

                    }
                    else
                    {
                        Row.Cells["dgvPassFail"].Value = "Test Failed";
                        Style = new DataGridViewCellStyle();
                        Style.BackColor = Color.Red;
                        Row.Cells["dgvPassFail"].Style = Style;
                    }

                    int r = Math.Abs(TargetColor.R - Item.Color.R);
                    int g = Math.Abs(TargetColor.G - Item.Color.G);
                    int b = Math.Abs(TargetColor.B - Item.Color.B);

                    int Largest = 0;
                    if (r > Largest)
                    {
                        Largest = r;
                    }
                    if (g > Largest)
                    {
                        Largest = g;
                    }
                    if (b > Largest)
                    {
                        Largest = b;
                    }

                    Row.Cells["dvgRange"].Value = Largest;

                }

                PictureTestAllReference.Image = Node.Bitmap;
                lblReferenceWindowResolution.Text = Node.Bitmap.Width + " x " + Node.Bitmap.Height;

                // Force redraw.
                PictureTestAllTest.Invalidate();

            }
            catch (Exception ex)
            {

                Log(ex.Message);
            }


        }

        private void tvTestAllEvents_MouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("tvTestAllEvents_MouseUp");
            //' Show menu only if Right Mouse button is clicked
            if (e.Button == MouseButtons.Right)
            {

                //' Point where mouse is clicked
                Point p = new Point(e.X, e.Y);

                //' Go to the node that the user clicked
                GameNode node = tvTestAllEvents.GetNodeAt(p) as GameNode;

                String Name = node.Name;

                if (Name.Contains(" - Points("))
                {
                    String[] SplitKey = { " - Points(" };
                    String[] Keys = Name.Split(SplitKey, StringSplitOptions.None);

                    if (Keys.Length > 0)
                    {
                        txtFilter.Text = Keys[0];
                        txtSearch_KeyUp(null, null);
                    }
                }
                else
                {
                    txtFilter.Text = node.Name;
                    txtSearch_KeyUp(null, null);
                }
            }

        }

        private void wizardRecommendedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuLaunchWizard();
        }

        private void MenuLaunchWizard()
        {
            if (tv.Nodes[0].Nodes.Count > 0)
            {
                frmLoadCheck frmLC = new frmLoadCheck();
                frmLC.StartPosition = FormStartPosition.CenterParent;
                frmLC.ShowDialog();

                switch (frmLC.Result)
                {
                    case AppTestStudio.frmLoadCheck.LoadCheckResult.Save:
                        toolStripButtonSaveScript_Click(null, null);
                        break;
                    case AppTestStudio.frmLoadCheck.LoadCheckResult.DontSave:
                        // do nothing
                        break;
                    case AppTestStudio.frmLoadCheck.LoadCheckResult.Cancel:
                        // quit
                        return;
                    case AppTestStudio.frmLoadCheck.LoadCheckResult.DefaultValue:
                        // quit
                        return;
                    default:
                        break;
                }

            }
            AddNewGameWizard();
        }

        private void AddNewGameWizard()
        {
            frmAddNewGameWizard frm = new frmAddNewGameWizard();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            if (frm.IsReadyToCreate)
            {
                String ApplicationName = frm.lblSafeName.Text;

                String ApplicationFolder = Utils.GetApplicationFolder();
                String ProjectFolder = System.IO.Path.Combine(ApplicationFolder, ApplicationName);

                if (System.IO.Directory.Exists(ProjectFolder))
                {
                    DialogResult Result = DialogResult.Yes;
                    int FolderIncrement = 1;
                    String NewApplicationName = System.IO.Path.Combine(ApplicationFolder, ApplicationName + FolderIncrement.ToString());
                    while (System.IO.Directory.Exists(NewApplicationName))
                    {
                        FolderIncrement++;
                        NewApplicationName = System.IO.Path.Combine(ApplicationFolder, ApplicationName + FolderIncrement.ToString());
                    }

                    Result = MessageBox.Show("Project Folder already exists with that name: " + ApplicationName + " Do you want to use " + ApplicationName + FolderIncrement.ToString() + " instead?", "Rename?", MessageBoxButtons.YesNoCancel);

                    if (Result == DialogResult.Yes)
                    {
                        ProjectFolder = System.IO.Path.Combine(ApplicationFolder, ApplicationName + FolderIncrement.ToString());
                        ApplicationName = ApplicationName + FolderIncrement.ToString();
                    }

                    if (Result == DialogResult.Cancel || Result == DialogResult.No)
                    {
                        return;
                    }
                }

                String TargetFileName = System.IO.Path.Combine(ProjectFolder, "Default.xml");


                //'assumed already saved, lets clear the other apps.
                tv.Nodes[0].Nodes.Clear();

                GameNodeGame Game = AddNewGameToTree(ApplicationName, TargetFileName);
                txtPackageName.Text = frm.lblAppID.Text;
                Game.PackageName = frm.lblAppID.Text;

                toolStripButtonSaveScript_Click(null, null);
                ThreadManager.IncrementNewAppAdded();
            }

        }

        private GameNodeGame AddNewGameToTree(string applicationName, string targetFileName)
        {
            GameNodeGame NewGame = new GameNodeGame(applicationName, TitleBarHeight);

            WorkspaceNode.Nodes.Add(NewGame);
            NewGame.FileName = targetFileName;

            tv.SelectedNode = NewGame;

            GameNodeEvents Events = new GameNodeEvents("Events");
            NewGame.Nodes.Add(Events);

            GameNodeObjects GameNodeObjects = new GameNodeObjects("Objects");
            NewGame.Nodes.Add(GameNodeObjects);

            return NewGame;
            //'Dim Actions As GameNode = New GameNode("Actions", GameNodeType.Actions)
            //'NewGame.Nodes.Add(Actions)

        }

        private void MenuNewManual(Platform platform)
        {
            if (tv.Nodes[0].Nodes.Count > 0)
            {
                frmLoadCheck frmLC = new frmLoadCheck();
                frmLC.StartPosition = FormStartPosition.CenterParent;
                frmLC.ShowDialog();

                switch (frmLC.Result)
                {
                    case AppTestStudio.frmLoadCheck.LoadCheckResult.Save:
                        toolStripButtonSaveScript_Click(null, null);
                        break;
                    case AppTestStudio.frmLoadCheck.LoadCheckResult.DontSave:
                        // do nothing
                        break;
                    case AppTestStudio.frmLoadCheck.LoadCheckResult.Cancel:
                        // quit
                        return;
                    case AppTestStudio.frmLoadCheck.LoadCheckResult.DefaultValue:
                        //quit
                        return;
                    default:
                        //quit
                        return;
                }

            }
            AddNewGame(platform);
        }

        private void AddNewGame(Platform platform)
        {
            frmAddNewGame frm = new frmAddNewGame();

            DialogResult Result = frm.ShowDialog();

            if (frm.IsValid)
            {

                //'assumed already saved, lets clear the other apps.
                tv.Nodes[0].Nodes.Clear();

                String GameName = frm.txtName.Text.Trim();
                String TargetFileName = frm.TargetFileName;
                GameNodeGame Game = AddNewGameToTree(GameName, TargetFileName);
                Game.Platform = platform;

                Game.FileName = frm.TargetFileName;

                toolStripButtonSaveScript_Click(null, null); ;
                ThreadManager.IncrementNewAppAdded();

                // force a reset of current panel
                tv_AfterSelect(null, null);
            }

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            DialogResult DR = openFileDialog1.ShowDialog();
            if (DR == DialogResult.OK)
            {
                //'do nothing
            }
            else
            {
                return;
            }

            String XMLATS = "";
            using (ZipArchive Archive = ZipFile.OpenRead(openFileDialog1.FileName))
            {
                int ATSXML = 0;
                int Pictures = 0;
                foreach (ZipArchiveEntry Entry in Archive.Entries)
                {
                    if (Entry.FullName.EndsWith("Default.xml"))
                    {
                        ATSXML = ATSXML + 1;

                        StreamReader SR = new StreamReader(Entry.Open());
                        XMLATS = SR.ReadToEnd();

                        continue;
                    }

                    if (Entry.FullName.StartsWith(@"Pictures\"))
                    {
                        if (Entry.FullName.EndsWith(".bmp"))
                        {
                            Pictures = Pictures + 1;
                            continue;
                        }
                    }

                    //if (Entry.FullName.StartsWith(@"Objects\"))
                    //{
                    //    if (Entry.FullName.EndsWith(".bmp"))
                    //    {
                    //        Pictures = Pictures + 1;
                    //        continue;
                    //    }
                    //}
                    Log("Unknown Entry: " + Entry.FullName);
                }

                if (ATSXML == 1)
                {
                    //'do nothing
                }
                else
                {
                    if (ATSXML == 0)
                    {
                        Log("Not Enough Default.xml files");
                    }
                    else
                    {
                        Log("Too Many Default.xml files");
                    }
                    return;
                }

                Boolean IsValid = false;
                String NewGameName = LoadGameFromString(XMLATS, ref IsValid);

                if (IsValid)
                {
                    String DirectoryPath = Utils.GetApplicationFolder();

                    String TargetFolder = DirectoryPath + @"\" + NewGameName;

                    if (System.IO.Directory.Exists(TargetFolder) == false)
                    {
                        System.IO.Directory.CreateDirectory(TargetFolder);
                    }

                    String PictureFolder = TargetFolder + @"\Pictures";

                    if (System.IO.Directory.Exists(PictureFolder) == false)
                    {
                        System.IO.Directory.CreateDirectory(PictureFolder);
                    }


                    foreach (ZipArchiveEntry Entry in Archive.Entries)
                    {


                        if (Entry.FullName.EndsWith("Default.xml"))
                        {
                            //'need pictures extracted first.
                            continue;
                        }

                        if (Entry.FullName.StartsWith(@"Pictures\"))
                        {
                            if (Entry.FullName.EndsWith(".bmp"))
                            {

                                String TargetFile = TargetFolder + @"\" + Entry.FullName;
                                try
                                {
                                    Entry.ExtractToFile(TargetFile, true);
                                    Log("Extracting " + TargetFile);
                                }
                                catch (Exception ex)
                                {
                                    Debug.Write(ex.Message);
                                    Debug.Assert(false);
                                }
                            }
                        }

                        //if (Entry.FullName.StartsWith(@"Objects\"))
                        //{
                        //    if (Entry.FullName.EndsWith(".bmp"))
                        //    {

                        //        String RemoveObjects = Entry.FullName.Substring(7, Entry.FullName.Length - 7);
                        //        String EntryName = "Pictures" + RemoveObjects;

                        //        String TargetFile = TargetFolder + @"\" + EntryName;
                        //        try
                        //        {
                        //            Entry.ExtractToFile(TargetFile, true);
                        //            Log("Extracting " + TargetFile);
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            Debug.Write(ex.Message);
                        //            Debug.Assert(false);
                        //        }
                        //    }
                        //}
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(XMLATS);

                    GameNodeGame Game = GameNodeGame.LoadGame(doc.DocumentElement.SelectSingleNode("//App"), TargetFolder + @"\Default.xml", NewGameName, true, TitleBarHeight);
                    Game.FileName = Utils.GetApplicationFolder() + @"\" + NewGameName + @"\Default.xml";

                    Game.GameNodeName = NewGameName;

                    XmlTextWriter Writer = new XmlTextWriter(Game.FileName, System.Text.Encoding.UTF8);
                    Writer.Formatting = Formatting.Indented;

                    Writer.WriteStartDocument();

                    Writer.WriteStartElement("AppTestStudio");  // Root.

                    Game.SaveGame(Writer, ThreadManager, tv, false);
                    Writer.WriteEndElement();
                    Writer.WriteEndDocument();
                    Writer.Close();

                    LoadGameToTree(Game);
                }

            }//end using

        }

        private string LoadGameFromString(string s, ref bool isValid)
        {
            String Result = "";
            isValid = false;


            GameNodeGame Game = null;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(s);
            frmImportProjectName frm = null;
            String GameName = "";
            if (doc.DocumentElement.SelectSingleNode("//App").IsSomething())
            {
                GameName = doc.DocumentElement.SelectSingleNode("//App").Attributes["Name"].Value;

                frm = new frmImportProjectName();
                frm.txtProjectName.Text = GameName;
                frm.ShowDialog();
            }

            if (frm.IsImporting && GameName.Length > 0)
            {
                isValid = true;
                Result = frm.txtProjectName.Text.Trim();
            }
            return Result;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Thread.Sleep(1000);
            Application.Exit();
        }

        private void fullExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export(false);
        }

        private void minimalExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export(true);
        }

        private void Export(bool Minimal)
        {
            saveFileDialog1.InitialDirectory = Utils.GetApplicationFolder() + @"\Exports\";
            GameNodeGame Game = WorkspaceNode.FirstNode as GameNodeGame;

            saveFileDialog1.FileName = Game.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            DialogResult DR = saveFileDialog1.ShowDialog();
            if (DR != DialogResult.OK)
            {
                return;
            }

            //'walk up to game node

            //'seek Game Node
            GameNode CurrentNode = tv.Nodes[0].Nodes[0] as GameNode;
            //CurrentNode = CurrentNode.GetGameNode();

            if (CurrentNode.GameNodeType == GameNodeType.Game)
            {

                GameNodeGame GameNode = CurrentNode as GameNodeGame;

                if (System.IO.File.Exists(saveFileDialog1.FileName))
                {
                    DialogResult msgboxresult = MessageBox.Show(saveFileDialog1.FileName + " already exists overwrite?", "Overwrite?", MessageBoxButtons.YesNoCancel);
                    if (msgboxresult == DialogResult.Yes)
                    {
                        //'do nothing
                    }
                    else
                    {
                        return;
                    }
                }

                XmlWriter Writer = null;
                StringBuilder Builder = new StringBuilder();

                XmlWriterSettings Settings = new XmlWriterSettings();
                Settings.Indent = true;
                Settings.Encoding = System.Text.Encoding.UTF8;
                Writer = XmlWriter.Create(Builder, Settings);
                //'Writer.Formatting = Formatting.Indented

                Writer.WriteStartDocument();

                Writer.WriteStartElement("AppTestStudio"); //' Root.

                ExportGameResults Results = GameNode.SaveGame(Writer, ThreadManager, tv, Minimal);

                Writer.WriteEndElement();
                Writer.WriteEndDocument();
                Writer.Close();

                Builder = Builder.Replace(@"encoding=""utf-16""?>", @"encoding = ""utf-8""?>");  // to-do why does it write unicode headers, when I set encoding to UTF8?

                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {
                    using (ZipArchive za = new ZipArchive(fs, ZipArchiveMode.Update, false, Encoding.UTF8))
                    {
                        ZipArchiveEntry zae = za.CreateEntry("Default.xml");
                        using (StreamWriter w = new StreamWriter(zae.Open()))
                        {
                            w.Write(Builder.ToString());
                        }

                        // Only save object pictures when in minimal mode.
                        foreach (String FullFileName in Results.ObjectListExtract)
                        {
                            String FileName = System.IO.Path.GetFileName(FullFileName);
                            zae = za.CreateEntryFromFile(FullFileName, @"Pictures\" + FileName);
                        }

                        if (Minimal)
                        {
                            //'do nothing
                        }
                        else
                        {
                            foreach (String FullFileName in Results.PictureListExtract)
                            {
                                String FileName = System.IO.Path.GetFileName(FullFileName);
                                zae = za.CreateEntryFromFile(FullFileName, @"Pictures\" + FileName);
                            }

                        }

                        //'zae = za.CreateEntry("a\Test.txt")
                        //'Using w As New StreamWriter(zae.Open())
                        //'    w.WriteLine("TEst")
                        //'End Using
                    }
                }

                Log("File Created: " + saveFileDialog1.FileName);
                ThreadManager.IncrementTestSaved();

                String Argument = "/select, \"" + saveFileDialog1.FileName + "\"";

                System.Diagnostics.Process.Start("explorer.exe", Argument);

            }
        }

        private void txtEventName_TextChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void lstThreads_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Event lstThreads_MouseDown");

            lstThreads.SelectedIndex = lstThreads.IndexFromPoint(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                //'mnuThreadName.Text = lstThreads.SelectedItem.ToString 
                //'mnuThreadName.Enabled = false
                mnuThreadList.Show(MousePosition);
                //';ContextMenuStrip1.Show(MousePosition)
            }
        }

        private void mnuThreadExit_Click(object sender, EventArgs e)
        {
            String git = lstThreads.SelectedItem.ToString();
            String[] KeysIn = { " - " };
            String[] Keys = git.Split(KeysIn, 1, StringSplitOptions.None);

            if (Keys.Length == 0)
            {
                Debug.WriteLine("Not sure this is possible");
                Debug.Assert(false);
                return;
            }

            String Token = Keys[Keys.Length - 1];
            Token = Token.Replace("ATS", "").Replace("Window", "");

            GameNodeGame GameFound = null;
            foreach (GameNodeGame Game in ThreadManager.Games)
            {
                if (Game.ThreadandWindowName == git)
                {
                    GameFound = Game;
                    Game.Thread.Abort();

                    break; // exit for
                }
            }

            if (GameFound.IsSomething())
            {
                ThreadManager.RemoveGame(GameFound);
                lstThreads.Items.Remove(git);
                Log("Stopping Thread -" + git);
            }
        }

        private void cmdPatron_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.patreon.com/AppTestStudio?fan_landing=true");
        }

        private void toolTestAll_Click(object sender, EventArgs e)
        {
            try
            {
                TestAllEvents();
            }
            catch (Exception ex)
            {
                Log("toolTestAll_Click:" + ex.Message);
            }
        }

        private void toolTest_Click(object sender, EventArgs e)
        {
            try
            {
                RunSingleTest();
            }
            catch (Exception ex)
            {
                Log("toolTest_Click:" + ex.Message);
            }
        }

        private void toolAddAction_Click(object sender, EventArgs e)
        {
            try
            {
                AddAction();
            }
            catch (Exception ex)
            {
                Log("toolAddAction_Click:" + ex.Message);
            }
        }

        private void toolAddEvent_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewEvent();
            }
            catch (Exception ex)
            {
                Log("toolAddEvent_Click:" + ex.Message);
            }
        }

        private void toolAddRNG_Click(object sender, EventArgs e)
        {
            try
            {
                AddRNGContainer();
            }
            catch (Exception ex)
            {
                Log("toolAddRNG_Click:" + ex.Message);
            }
        }

        private void toolAddRNGNode_Click(object sender, EventArgs e)
        {
            try
            {
                AddRNGNode(tv.SelectedNode as GameNodeAction);
            }
            catch (Exception ex)
            {
                Log("toolAddRNGNode_Click:" + ex.Message);
            }
        }

        private void PictureTestAllReference_Paint(object sender, PaintEventArgs e)
        {
            GameNode Node = tvTestAllEvents.SelectedNode as GameNode;

            if (Node.IsSomething() && Node.GameNodeType == GameNodeType.Action)
            {
                GameNodeAction Action = Node as GameNodeAction;
                if (Action.IsColorPoint)
                {
                    Utils.DrawColorPoints(e, dgvTestAllReference, "dgvTestAllReference", "dgvTestAllReferenceX", "dgvTestAllReferenceY");
                }
                else
                {
                    if (Action.Rectangle.IsEmpty)
                    {
                        Action.Rectangle = new Rectangle(0, 0, PictureTestAllReference.Width, PictureTestAllReference.Height);
                    }
                    Utils.DrawMask(PictureTestAllReference, Action.Rectangle, e);
                }
            }
        }

        private void PictureTestAllTest_Paint(object sender, PaintEventArgs e)
        {
            GameNode Node = tvTestAllEvents.SelectedNode as GameNode;

            if (Node.IsSomething() && Node.GameNodeType == GameNodeType.Action)
            {
                GameNodeAction Action = Node as GameNodeAction;
                if (Action.IsColorPoint)
                {
                    Utils.DrawColorPoints(e, dgvTest, "dgvColorTest", "dgvXTest", "dgvYTest");
                }
                else
                {
                    if (Action.Rectangle.IsEmpty)
                    {
                        Action.Rectangle = new Rectangle(0, 0, PictureTestAllTest.Width, PictureTestAllTest.Height);
                    }
                    Utils.DrawMask(PictureTestAllTest, Action.Rectangle, e);
                }

                try
                {
                    //Unfortunately I don't store the solution on the nodes/maybe I should so going to parse it out of the name.
                    //{Text = "Find Side Circle (x=16 ,y=246, Detected=62, Limit=79)"}
                    String Text = Node.Text;
                    String[] Keys = Text.Split(new[] { "(x=", " ,y=", ", Detected=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (Keys.Length == 4)
                    {
                        // x and y is center of detected
                        int x = Keys[1].ToInt();
                        int y = Keys[2].ToInt();

                        Rectangle Rectangle = new Rectangle();

                        // Add back 1/2 the mask to align the mask with the center detected coordinate.
                        Rectangle.X = x + Action.Rectangle.X - (Action.ObjectSearchBitmap.Width / 2);
                        Rectangle.Y = y + Action.Rectangle.Y - (Action.ObjectSearchBitmap.Height / 2);

                        // Width and height of object search image size.
                        Rectangle.Width = Action.ObjectSearchBitmap.Width;
                        Rectangle.Height = Action.ObjectSearchBitmap.Height;

                        // Draw a yellow transparent box.
                        using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 255, 201, 14)))
                        {
                            e.Graphics.FillRectangle(br, Rectangle);
                        }

                        // Draw a solid yellow line.
                        using (Pen p = new Pen(Color.FromArgb(255, 201, 14), 1))
                        {
                            e.Graphics.DrawRectangle(p, Rectangle);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Log(ex.Message);
                }
            }


        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            Timer1.Enabled = false;
            foreach (GameNodeGame Game in ThreadManager.Games)
            {
                Game.Thread.Abort();
            }
            Thread.Sleep(100);

            // threads must be turned off off during saving.
            ThreadManager.Save();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedTreeNode();
        }

        /// <summary>
        /// MOves the node up one sibling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode PLN = PanelLoadNode;
            TreeNode parent = PLN.Parent;
            TreeView view = PLN.TreeView;
            if (parent.IsSomething())
            {
                int index = parent.Nodes.IndexOf(PLN);
                if (index > 0)
                {
                    parent.Nodes.Remove(PLN);
                    parent.Nodes.Insert(index - 1, PLN);
                    PanelLoadNode.TreeView.SelectedNode = PLN;
                }
            }
            else if (PLN.TreeView.Nodes.Contains(PLN)) //root node
            {
                int index = view.Nodes.IndexOf(PLN);
                if (index > 0)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index - 1, PLN);
                }
            }
        }

        /// <summary>
        /// Moves the node down one sibling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode PLN = PanelLoadNode;
            TreeNode parent = PLN.Parent;
            TreeView view = PLN.TreeView;
            if (parent.IsSomething())
            {
                int index = parent.Nodes.IndexOf(PLN);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, PLN);
                }
            }
            else if (view.IsSomething() && view.Nodes.Contains(PLN)) //root node
            {
                int index = view.Nodes.IndexOf(PLN);
                if (index < view.Nodes.Count - 1)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index + 1, PLN);
                }
            }
        }

        private void toolStripButtonRunStartLaunch_Click(object sender, EventArgs e)
        {
            GameNodeGame Game = GetGameNode();

            StartEmmulator(Game, Game.PackageName, Game.InstanceToLaunch);

            LoadInstance(Game);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RunSingleTest();
            }
            catch (Exception ex)
            {
                Log("testToolStripMenuItem_Click:" + ex.Message);
            }
        }

        private void rdoCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCustom.Checked)
            {
                // Make room for Custom Logic
                panelRightCustomLogic.Visible = true;

                txtCustomLogic.Text = "";
                for (int i = 1; i < dgv.Rows.Count; i++)
                {
                    if (txtCustomLogic.Text.Length > 0)
                    {
                        if (PanelLoadNode.LastLogicChoice == "OR")
                        {
                            txtCustomLogic.Text = txtCustomLogic.Text + " OR ";
                        }
                        else
                        {
                            txtCustomLogic.Text = txtCustomLogic.Text + " AND ";
                        }
                    }
                    txtCustomLogic.Text = txtCustomLogic.Text + i.ToString();
                }

                PanelLoadNode.LastLogicChoice = "CUSTOM";
                Log("To Use include the Click List #, eg. 1 AND NOT (2 OR 3) ");
                Log("Custom logic supports operators &, &&, AND, !, NOT, |, ||, OR, ()'s");
            }
            else
            {
                HideCustomLogicControls();
            }

            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void HideCustomLogicControls()
        {
            panelRightCustomLogic.Visible = false;
        }

        private void rdoAnd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAnd.Checked)
            {
                PanelLoadNode.LastLogicChoice = "AND";
                HideCustomLogicControls();
            }
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }

        }

        private void rdoOR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOR.Checked)
            {
                PanelLoadNode.LastLogicChoice = "OR";
                HideCustomLogicControls();
            }
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }

        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            // this is just a basic validator, it's not perfect but it's pretty good.

            // add spaces to beginning and end.
            String Expression = " " + txtCustomLogic.Text + " ";

            // Lets add space between everything and expand mix the logic to allow for C# and VB Logic.
            Expression = Utils.ExtendCustomLogic(Expression);

            // remove the #'s since the parser doens't know what #'s are.
            for (int i = dgv.Rows.Count - 1; i >= 1; i--)
            {
                // Replace #'s with true
                Expression = Expression.Replace(" " + i.ToString() + " ", " TRUE ");
            }

            // Test the parser.
            BooleanParser.Parser parser = new BooleanParser.Parser(Expression);
            try
            {
                String NewExpress = Expression.Replace("(", "").Replace(")", "").Replace("TRUE", "").Replace("FALSE", "").Replace("AND", "").Replace("OR", "").Replace("NOT", "").Replace(" ", "");

                if (NewExpress.Length > 0)
                {
                    Log("PreCheck unexpected: " + NewExpress);
                }

                Boolean result = parser.Parse();
                Log("Parse Successful");
                cmdValidate.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                Log("Parse Check:" + ex.Message);
                cmdValidate.BackColor = Color.Red;

                Log("Note: At runtime any unparseable custom logic will skip the node.");
            }
        }

        private void txtCustom_TextChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading)
            {
                // do nothing
            }
            else
            {
                PanelLoadNode.CustomLogic = txtCustomLogic.Text.Trim();
            }
        }

        private void cmdDeleteObject_Click(object sender, EventArgs e)
        {
            GameNodeObjects Objects = GetGameNodeObjects();
            foreach (GameNodeObject gameNodeObject in Objects.Nodes)
            {
                if (gameNodeObject.Name == txtObjectName.Text)
                {
                    Objects.Nodes.Remove(gameNodeObject);
                    Log("Object: " + txtObjectName.Text + " deleted");
                    break;
                }
            }
            tv.SelectedNode = Objects;
        }

        private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
        {
            windowHandles.Add(windowHandle);
            return true;
        }

        private void SplitContainer6_Panel2_Resize(object sender, EventArgs e)
        {
            int Height = (SplitContainer6.Panel2.Height / 2) - lblTestWindow.Height - lblReference.Height;
            int Width = (SplitContainer6.Panel2.Width / 2) - 2;
            Panel1.Height = Height;
            Panel1.Top = lblTestWindow.Top + lblTestWindow.Height;
            Panel1.Width = Width;

            lblReference.Top = Panel1.Top + Panel1.Height;
            lblReference.Left = 2;
            lblTestWindow.Left = 2;

            lblTestWindowResolution.Top = lblReference.Top;
            lblTestWindowResolution.Left = Width / 2;

            dgvTestAllReference.Top = Panel1.Top;
            dgvTestAllReference.Height = Height;
            dgvTestAllReference.Width = Width;
            dgvTestAllReference.Left = Width - 2;


            Panel2.Height = Height;
            Panel2.Width = Width;

            lblReferenceWindowResolution.Left = Width / 2;

            dgvTest.Height = Height;
            Panel2.Top = Panel1.Top + Panel1.Height + lblReference.Height + 2;
            dgvTest.Top = Panel2.Top;
            dgvTest.Width = Width;
            dgvTest.Left = Width - 2;

            lblTestAllCustom.Top = lblTestWindow.Top;
            lblTestAllCustom.Left = dgvTest.Left;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {

        }

        private void cmdColorAtPointer_Click(object sender, EventArgs e)
        {
            if (panelRightColorAtPointer.Height == InitialPanelRightColorAtPointerHeight)
            {
                panelRightColorAtPointer.Height = cmdRightColorAtPointer.Height;
                cmdRightColorAtPointer.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightColorAtPointer.Height = InitialPanelRightColorAtPointerHeight;
                cmdRightColorAtPointer.ImageIndex = IconNames.DownChevron();
            }
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdRightLimit_Click(object sender, EventArgs e)
        {
            if (panelRightLimit.Height == InitialPanelRightLimitHeight)
            {
                panelRightLimit.Height = cmdRightLimit.Height;
                cmdRightLimit.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightLimit.Height = InitialPanelRightLimitHeight;
                cmdRightLimit.ImageIndex = IconNames.DownChevron();
            }
        }

        private void cmdPanelOffset_Click(object sender, EventArgs e)
        {
            if (panelRightOffset.Height == InitialPanelRightOffsetHeight)
            {
                panelRightOffset.Height = cmdRightOffset.Height;
                cmdRightOffset.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightOffset.Height = InitialPanelRightOffsetHeight;
                cmdRightOffset.ImageIndex = IconNames.DownChevron();
            }
        }

        private void cmdRightDragMode_Click(object sender, EventArgs e)
        {
            if (panelRightDragMode.Height == InitialPanelRightDragModeHeight)
            {
                panelRightDragMode.Height = cmdRightDragMode.Height;
                cmdRightDragMode.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightDragMode.Height = InitialPanelRightDragModeHeight;
                cmdRightDragMode.ImageIndex = IconNames.DownChevron();
            }
        }

        private void cmdRightAfterCompletion_Click(object sender, EventArgs e)
        {
            if (panelRightAfterCompletion.Height == InitialPanelRightAfterCompletionHeight)
            {
                panelRightAfterCompletion.Height = cmdRightAfterCompletion.Height;
                cmdRightAfterCompletion.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightAfterCompletion.Height = InitialPanelRightAfterCompletionHeight;
                cmdRightAfterCompletion.ImageIndex = IconNames.DownChevron();
            }
        }

        private void cmdRightObject_Click(object sender, EventArgs e)
        {
            if (panelRightObject.Height == InitialPanelRightObjectHeight)
            {
                panelRightObject.Height = cmdRightObject.Height;
                cmdRightObject.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightObject.Height = InitialPanelRightObjectHeight;
                cmdRightObject.ImageIndex = IconNames.DownChevron();
            }
        }

        private void cmdRightLogic_Click(object sender, EventArgs e)
        {
            if (panelRightLogic.Height == InitialPanelRightLogicHeight)
            {
                panelRightLogic.Height = cmdRightLogic.Height;
                panelRightCustomLogic.Visible = false;
                panelRightPointGrid.Visible = false;
                cmdRightLogic.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightLogic.Height = InitialPanelRightLogicHeight;
                panelRightCustomLogic.Visible = true;
                panelRightPointGrid.Visible = true;
                cmdRightLogic.ImageIndex = IconNames.DownChevron();
            }
        }

        private void numericApplicationDefaultClickSpeed_ValueChanged(object sender, EventArgs e)
        {
            GameNodeGame Game = tv.SelectedNode as GameNodeGame;
            if (Game.IsSomething())
            {
                Game.DefaultClickSpeed = Convert.ToInt32(numericApplicationDefaultClickSpeed.Value);
            }
        }

        private void cmdRightClickProperties_Click(object sender, EventArgs e)
        {
            if (panelRightClickProperties.Height == InitialPanelRightClickPropertiesHeight)
            {
                panelRightClickProperties.Height = cmdRightClickProperties.Height;

                cmdRightLogic.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightClickProperties.Height = InitialPanelRightClickPropertiesHeight;

                cmdRightLogic.ImageIndex = IconNames.DownChevron();
            }
        }

        private void NumericClickSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickSpeed = Convert.ToInt32(NumericClickSpeed.Value);
            }
        }

        private void cmdRightSwipeProperties_Click(object sender, EventArgs e)
        {


            if (panelRightSwipeProperties.Height == InitialPanelRightSwipePropertiesHeight)
            {
                panelRightSwipeProperties.Height = cmdRightSwipeProperties.Height;

                cmdRightLogic.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightSwipeProperties.Height = InitialPanelRightSwipePropertiesHeight;

                cmdRightLogic.ImageIndex = IconNames.DownChevron();
            }
        }

        private void numericSwipeStartHeight_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseStartHeight = (int)numericSwipeStartHeight.Value;
                PictureBox1.Invalidate();
            }
        }

        private void numericSwipeStartWidth_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseStartWidth = (int)numericSwipeStartWidth.Value;
                PictureBox1.Invalidate();
            }

        }

        private void numericSwipeEndHeight_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseEndHeight = (int)numericSwipeEndHeight.Value;
                PictureBox1.Invalidate();
            }

        }

        private void numericSwipeVelocity_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseVelocity = (int)numericSwipeVelocity.Value;
            }

        }

        private void rdoObjectSearchStart_CheckedChanged(object sender, EventArgs e)
        {
            ObjectSearchChanged();
        }

        private void ObjectSearchChanged()
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                if (rdoObjectSearchStart.Checked)
                {
                    ActionNode.ClickDragReleaseMode = ClickDragReleaseMode.Start;
                }
                else if (rdoObjectSearchEnd.Checked)
                {
                    ActionNode.ClickDragReleaseMode = ClickDragReleaseMode.End;
                }
                else
                {
                    ActionNode.ClickDragReleaseMode = ClickDragReleaseMode.None;
                }
            }
        }

        private void rdoObjectSearchEnd_CheckedChanged(object sender, EventArgs e)
        {
            ObjectSearchChanged();
        }

        private void rdoObjectSearchNone_CheckedChanged(object sender, EventArgs e)
        {
            ObjectSearchChanged();
        }

        private void chkPropertiesEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.Enabled = chkPropertiesEnabled.Checked;

                Utils.SetIcons(ActionNode);
            }
        }

        private void chkPropertiesRepeatsUntilFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.RepeatsUntilFalse = chkPropertiesRepeatsUntilFalse.Checked;
            }

            if (chkPropertiesRepeatsUntilFalse.Checked)
            {
                numericPropertiesRepeatsUntilFalse.Enabled = true;
                lblPropertiesRepeatsUntilFalse.Enabled = true;
            }
            else
            {
                numericPropertiesRepeatsUntilFalse.Enabled = false;
                lblPropertiesRepeatsUntilFalse.Enabled = false;
            }
        }

        private void numericPropertiesRepeatsUntilFalse_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.RepeatsUntilFalseLimit = Convert.ToInt32(numericPropertiesRepeatsUntilFalse.Value);
            }

        }

        private void numericSwipeEndWidth_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseEndWidth = (int)numericSwipeEndWidth.Value;
                PictureBox1.Invalidate();
            }
        }

        private void rdoAfterCompletionRecycle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                ArchaicSave();
            }
        }

        private void cboDPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameNodeGame Game = tv.SelectedNode as GameNodeGame;
            if (Game.IsSomething())
            {
                Game.DPI = Convert.ToInt32(cboDPI.Text);
            }
        }

        private void cmdRightAnchor_Click(object sender, EventArgs e)
        {
            if (panelRightAnchor.Height == InitialPanelRightAnchorHeight)
            {
                panelRightAnchor.Height = cmdRightAnchor.Height;
                cmdRightAnchor.ImageIndex = IconNames.LeftChevron();
            }
            else
            {
                panelRightAnchor.Height = InitialPanelRightAnchorHeight;
                cmdRightAnchor.ImageIndex = IconNames.DownChevron();
            }
        }

        private void cmdAnchorTop_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                    if ((Node.Anchor | AnchorMode.Top) > 0)
                    {
                        Node.Anchor ^= AnchorMode.Top;
                    }
                    else
                    {
                        Node.Anchor |= AnchorMode.Top;
                    }

                    AnchorChange(Node);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.Assert(false);
            }
        }

        private void cmdAnchorRight_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                    if ((Node.Anchor | AnchorMode.Right) > 0)
                    {
                        Node.Anchor ^= AnchorMode.Right;
                    }
                    else
                    {
                        Node.Anchor |= AnchorMode.Right;
                    }

                    AnchorChange(Node);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.Assert(false);
            }
        }

        private void cmdAnchorBottom_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                    if ((Node.Anchor | AnchorMode.Bottom) > 0)
                    {
                        Node.Anchor ^= AnchorMode.Bottom;
                    }
                    else
                    {
                        Node.Anchor |= AnchorMode.Bottom;
                    }

                    AnchorChange(Node);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.Assert(false);
            }
        }

        private void cmdAnchorLeft_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                    if ((Node.Anchor | AnchorMode.Left) > 0)
                    {
                        Node.Anchor ^= AnchorMode.Left;
                    }
                    else
                    {
                        Node.Anchor |= AnchorMode.Left;
                    }

                    AnchorChange(Node);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.Assert(false);
            }
        }

        private void cmdAnchorNone_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                    Node.Anchor = AnchorMode.None;
                    AnchorChange(Node);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.Assert(false);
            }
        }

        private void cmdAnchorDefault_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                    Node.Anchor = AnchorMode.Default;
                    AnchorChange(Node);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                Debug.WriteLine(ex.Message);
                Debug.Assert(false);
            }
        }

        private void AnchorChange(GameNodeAction action)
        {
            cmdAnchorTop.BackColor = AnchorModeButtonColors.DisabledColor();
            cmdAnchorRight.BackColor = AnchorModeButtonColors.DisabledColor();
            cmdAnchorBottom.BackColor = AnchorModeButtonColors.DisabledColor();
            cmdAnchorLeft.BackColor = AnchorModeButtonColors.DisabledColor();
            cmdAnchorNone.BackColor = AnchorModeButtonColors.DisabledColor();

            if (action.Anchor == AnchorMode.None)
            {
                cmdAnchorNone.BackColor = AnchorModeButtonColors.EnabledColor();
            }

            if ((action.Anchor & AnchorMode.Top) > 0)
            {
                cmdAnchorTop.BackColor = AnchorModeButtonColors.EnabledColor();
            }

            if ((action.Anchor & AnchorMode.Right) > 0)
            {
                cmdAnchorRight.BackColor = AnchorModeButtonColors.EnabledColor();
            }

            if ((action.Anchor & AnchorMode.Bottom) > 0)
            {
                cmdAnchorBottom.BackColor = AnchorModeButtonColors.EnabledColor();
            }

            if ((action.Anchor & AnchorMode.Left) > 0)
            {
                cmdAnchorLeft.BackColor = AnchorModeButtonColors.EnabledColor();
            }
        }

        private void cmdTakeParentScreenshot_Click(object sender, EventArgs e)
        {
            // Add parent screenshot if one exists.
            LoadParentScreenshotIfNecessary(true);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Bitmap bmp = PictureBoxObject.Image as Bitmap;

        //    for (int i = 0; i < 55; i++)
        //    {
        //        for (int j = 0; j < 80; j++)
        //        {
        //            if (i < bmp.Width)
        //                if (j < bmp.Height)
        //                {
        //                    bmp.SetPixel(i, j, Color.White);
        //                }
        //        }
        //    }
        //    PictureBoxObject.Invalidate();

        //}

        private void txtSteamID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboPlatform_TextChanged(object sender, EventArgs e)
        {
            grpNox.Visible = false;
            grpSteam.Visible = false;
            grpApplication.Visible = false;
            switch (cboPlatform.Text)
            {
                case "NoxPlayer":
                    grpNox.Visible = true;
                    break;
                case "Steam":
                    grpSteam.Visible = true;
                    break;
                case "Application":
                    grpApplication.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void cboPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = GetGameNode();
                switch (cboPlatform.Text)
                {
                    case "NoxPlayer":
                        GameNode.Platform = Platform.NoxPlayer;
                        cmdStartEmmulator.Text = "Start Emmulator";
                        cmdStartEmmulatorAndPackage.Text = "Start Emmulator + Run App";
                        cmdStartEmmulatorPackageAndRunScript.Text = "Start Emmulator + Run App + Run Script";
                        break;
                    case "Application":
                        GameNode.Platform = Platform.Application;
                        cmdStartEmmulator.Text = "Start Application";
                        cmdStartEmmulatorAndPackage.Text = "Start Application + Run App";
                        cmdStartEmmulatorPackageAndRunScript.Text = "Start Application + Run App + Run Script";
                        break;
                    case "Steam":
                        GameNode.Platform = Platform.Steam;
                        cmdStartEmmulator.Text = "Start Steam Application";
                        cmdStartEmmulatorAndPackage.Text = "Start Steam + Run App";
                        cmdStartEmmulatorPackageAndRunScript.Text = "Start Steam + Run App + Run Script";
                        break;
                    default:
                        GameNode.Platform = Platform.NoxPlayer;
                        Debug.Assert(false);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }

        }

        private void txtSteamID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.SteamID = txtSteamID.Text.ToInt();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void txtPathToApplicationExe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.PathToApplicationEXE = txtPathToApplicationExe.Text;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void txtApplicationWindowName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.ApplicationWindowName = txtApplicationWindowName.Text.Trim();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void txtSteamWindowName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.SteamWindowName = txtSteamWindowName.Text.Trim();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void chkApplicationIsFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.IsFullScreen = chkApplicationIsFullScreen.Checked;
                chkIsSteamFullScreen.Checked = chkApplicationIsFullScreen.Checked;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void chkIsSteamFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.IsFullScreen = chkIsSteamFullScreen.Checked;
                chkApplicationIsFullScreen.Checked = chkIsSteamFullScreen.Checked;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void wizardRecommendedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MenuLaunchWizard();
        }

        private void manualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MenuNewManual(Platform.NoxPlayer);
        }

        private void steamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuNewManual(Platform.Steam);
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuNewManual(Platform.Application);
        }

        private void cmdPathToExePicker_Click(object sender, EventArgs e)
        {
            DialogResult Result = dlgApplicationPicker.ShowDialog();
            if (Result == DialogResult.OK)
            {
                txtPathToApplicationExe.Text = dlgApplicationPicker.FileName;
            }
        }
    }
}
