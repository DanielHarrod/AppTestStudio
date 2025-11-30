//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using AppTestStudio.solution;
using AppTestStudioControls;
using Gma.System.MouseKeyHook;
using log4net;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static AppTestStudio.Utils;

namespace AppTestStudio
{
    public partial class frmMain : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ThreadManager ThreadManager { get; set; }
        private GameNodeWorkspace WorkspaceNode { get; set; }
        private GameNode LastNode { get; set; }
        private Boolean IsPictureObjectScreenshotMouseDown = false;
        private Rectangle PictureObjectScreenshotRectangle = new Rectangle();

        private Boolean IsPanelLoading = false;
        private Boolean IsLoadingSchedule = false;

        private GameNodeAction mPanelLoadNode;
        private GameNodeAction LastPanelLoadNode = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        private int InitialPanelRightInformationHeight;
        private int TitleBarHeight;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SteamRegistry SteamRegistry { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BlueRegistry BlueRegistry { get; set; }

        public frmMain()
        {
            Log4NetSetup.Initialize(Utils.GetApplicationFolder());
            InitializeComponent();
            ThreadManager = new ThreadManager();
            sb = new StringBuilder();
            PictureObjectScreenshotRectangle = new Rectangle();
        }

        private HistoryManager HistoryManager;

        private List<GamePassSolution> GamePassSolutions = new List<GamePassSolution>();
        private void frmMain_Load(object sender, EventArgs e)
        {

            mnuMouseRecording.Visible = false; // Hide for now.
            ShowTermsOfServiceIfNecessary();

            ThreadManager.Load();
            InitializeToolbars();
            SubscribeGlobalMouseKeyHook();
            FirstFormost();
            InitializedInstances();

            foreach (Platform platform in Enum.GetValues(typeof(Platform)))
            {
                cboPlatform.Items.Add(platform.ToString());
            }

            foreach (MouseMode mouseMode in Enum.GetValues(typeof(MouseMode)))
            {
                cboMouseMode.Items.Add(mouseMode.ToString());
            }

            foreach (WindowAction windowAction in Enum.GetValues(typeof(WindowAction)))
            {
                cboWindowAction.Items.Add(windowAction.ToString());
            }

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
            InitialPanelRightInformationHeight = panelRightInformation.Height;
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
            ReloadRuntimeScheduleView();

            tv.ExpandAll();

            LoadRanges();

            // Initialize
            appTestStudioStatusControl1.ShowPercent = 120;

            // Hide Custom Logic controls
            panelRightCustomLogic.Visible = false;

            // Instructions for minimal export 
            lblPictureMissing.Text = "This node did not include the reference picture - typically from a minimal export. \n\n If this node is true during a Run, a screenshot will automatically be linked.  \n\nYou can also manually press 'take a screenshot'.  \n\nWhen minimal exports are matched during a 'Run', a link message will be displayed in the log.  If images are linked, don't forget to save the project so the images can be loaded and managed.";

            tableLayoutPanelRunLabels.BackColor = Color.FromArgb(60, 60, 60);
            tableLayoutPanelRunValues.BackColor = Color.FromArgb(60, 60, 60);


            HistoryManager = new HistoryManager(WorkspaceNode.WorkspaceFolder);
            UpdateRecentScripts();

            InitializeRunLabels();

            InitializeActionsPerSecondGraph();

            //ResolutionCheck();
            InitializeGamePassList();

            AdministratorCheck();

            CheckMonitorScaling();

        }

        // Unfortunately this doesn't give proper DPI information - need to use GetDpiForWindow
        private void CheckMonitorScaling()
        {
            NativeMethods.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                static delegate (IntPtr hMonitor, IntPtr hdcMonitor, NativeMethods.RECT lprcMonitor, IntPtr dwData)
                {
                    int MDT_Effective_DPI = 0;
                    if (NativeMethods.GetDpiForMonitor(hMonitor, NativeMethods.DpiType.Effective, out uint dpiX, out uint dpiY) == 0)
                    {
                        double scalePercent = dpiX / 96.0 * 100;
                        Debug.WriteLine($"Monitor: {hMonitor}");
                        Debug.WriteLine($"DPI: {dpiX}x{dpiY} → Scaling: {scalePercent}%");

                        if (dpiX != 96 || dpiY != 96)
                            Debug.WriteLine("Scaling is applied.");
                        else
                            Debug.WriteLine("No scaling applied.");
                    }
                    else
                    {
                        Debug.WriteLine($"Failed to get DPI for monitor: {hMonitor}");
                    }

                    return true; // continue enumeration
                }

                , IntPtr.Zero);
        }

        private void AdministratorCheck()
        {
            try
            {
                if (Utils.IsAdministrator())
                {
                    lblIsAdministrator.Text = "Yes";
                    lblIsAdministrator.ForeColor = Color.Green;
                }
                else
                {
                    lblIsAdministrator.Text = "No";
                    lblIsAdministrator.ForeColor = Color.Red;
                    lblRunAsAdministratorWarning.Visible = true;
                }

            }
            catch (Exception ex)
            {

                log.Warn($"AdministratorCheck: {ex.Message}");
            }
        }

        List<ListViewItem> GamePassList = new List<ListViewItem>();

        private void InitializeGamePassList()
        {
            lstGamePass.View = View.Details;
            ColumnHeader h = lstGamePass.Columns.Add("x");
            h.Width = 20;

            h = lstGamePass.Columns.Add("Time");
            h.Width = 55;

            h = lstGamePass.Columns.Add("Counter");
            h.Width = 55;


            h = lstGamePass.Columns.Add("Actions");
            h.Width = 55;

            h = lstGamePass.Columns.Add("Project");
            h.Width = 90;
            lstGamePass_Resize(null, null);

        }

        /// <summary>
        /// When monitors have scaling enabled it can mess up the clicking.
        /// In the future I may add an informational startup message.
        /// </summary>
        private void ResolutionCheck()
        {
            try
            {

                if (Screen.AllScreens.Count() == 1)
                {
                    return;
                }

                List<int> DPICheck = new List<int>();
                Boolean DPIVariance = false;

                List<int> ResolutionWidthCheck = new List<int>();
                Boolean ResolutionVariance = false;

                foreach (var screen in Screen.AllScreens)
                {
                    var pnt = new System.Drawing.Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
                    var mon = NativeMethods.MonitorFromPoint(pnt, MonitorFromPointFlags.MONITOR_DEFAULTTONEAREST);
                    uint dpiX = 0;
                    uint dpiY = 0;
                    NativeMethods.GetDpiForMonitor(mon, NativeMethods.DpiType.Raw, out dpiX, out dpiY);
                    Debug.WriteLine($"DPI{dpiX},{dpiY} {screen.Bounds},{screen.WorkingArea}");
                    int CalculatedKey = (int)((float)screen.Bounds.Width / (float)dpiX) * 100;

                    if (DPICheck.Count > 0)
                    {
                        if (DPICheck.Contains(CalculatedKey))
                        {
                            // good.
                        }
                        else
                        {
                            // not good.
                            DPIVariance = true;
                        }
                    }
                    DPICheck.Add(CalculatedKey);

                    if (ResolutionWidthCheck.Count > 0)
                    {


                    }

                }

                if (DPIVariance)
                {
                    Log("This is just a basic check, and can false positive with multiple resolution monitors.");
                    Log("WARNING: A variation in dpi was found, verify all monitors have the same 'Scale and Layout' settings. Settings->Display->Scale and Layout.");
                }
            }
            catch (Exception ex)
            {
                Log($"ResolutionCheck {ex.Message}");
            }

        }

        private void InitializeActionsPerSecondGraph()
        {
            // hide the ms default.
            atsGraphActions1.Prepender = "";

            // Potentially impossible limit
            atsGraphActions1.MaxLimit = 30000;

            atsGraphActions1.SnapToScale = 10;
        }

        private void ShowTermsOfServiceIfNecessary()
        {
            //String RegistryKey = @"HKEY_CURRENT_USER\SOFTWARE\App Test Studio\";
            //String RegistryValue = "TermsDate";
            //Object TermsDate = Registry.GetValue(RegistryKey, RegistryValue, "");
            //if (TermsDate.IsSomething())
            //{
            //    DateTime Value = DateTime.MinValue;
            //    if (DateTime.TryParse(TermsDate.ToString(), out Value))                    
            //    {
            //        return;
            //    }
            //}

            //if (terms.IsAgree )
            //{
            //    Registry.SetValue(RegistryKey, RegistryValue, DateTime.Now.ToString());
            //}
            //else
            //{
            //    Application.Exit();
            //}
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

            Schedule.RuntimeSchedule = Schedule.GenerateRuntimeSchedule(DateTime.Now);
            Schedule.RemoveHistoricalScheduleItems();
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
            try
            {
                ToolStripItem Item = sender as ToolStripItem;

                if (Item.IsSomething())
                {
                    cboGameInstances.Text = Item.Text;
                    txtGamePanelLaunchInstance.Text = Item.Text;
                    toolStripInstances.Text = Item.Text;

                    GameNodeGame Game = GetGameNode();
                    if (Game.IsSomething())
                    {
                        Game.InstanceToLaunch = Item.Text;
                    }
                }

            }
            catch (Exception ex)
            {

                Log("ToolStripItem_Click:" + ex.Message);
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

            BlueRegistry = new BlueRegistry();

            if (BlueRegistry.ExceptionMessage.IsSomething())
            {
                if (BlueRegistry.ExceptionMessage.Length > 0)
                {
                    Log(BlueRegistry.ExceptionMessage);
                }
            }

            if (BlueRegistry.IsValid32)
            {
                lblBlueEmmulatorInstalled32.Text = "Yes";
                lblBlueEmmulatorInstalled32.ForeColor = Color.Green;
                lblBlueInstancesFound32.Text = BlueRegistry.InstanceNames.Count().ToString();
            }
            else
            {
                lblBlueInstancesFound32.Text = "0";
                lblBlueEmmulatorInstalled32.Text = "No";
                lblBlueEmmulatorInstalled32.ForeColor = Color.Red;

            }

            if (BlueRegistry.IsValid64)
            {
                lblBlueEmmulatorInstalled64.Text = "Yes";
                lblBlueEmmulatorInstalled64.ForeColor = Color.Green;
                lblBlueInstancesFound64.Text = BlueRegistry.InstanceName64s.Count().ToString();
            }
            else
            {
                lblBlueEmmulatorInstalled64.Text = "No";
                lblBlueEmmulatorInstalled64.ForeColor = Color.Red;
                lblBlueInstancesFound64.Text = "0";
            }

            foreach (BlueGuest Guest in BlueRegistry.GuestList)
            {
                cboBlueInstance.Items.Add(Guest.BitDashDisplayName);
            }

            if (cboBlueInstance.Items.Count > 0)
            {
                cboBlueInstance.SelectedIndex = cboBlueInstance.Items.Count - 1;
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
        const String UnPauseScript = "Resume Script";
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
                    GameNode gameNode = GetGameNode();
                    if (gameNode.IsAnythingDirty())
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
            }
            System.Windows.Forms.OpenFileDialog openDLG = new System.Windows.Forms.OpenFileDialog();
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
                    LoadExistingGameFromFile(FileName);
                }
                catch (Exception Ex)
                {
                    Log(Ex.Message);
                    Debug.WriteLine(Ex.Message);
                    Debug.Assert(false);
                }
            }
        }

        private void LoadExistingGameFromFile(string FileName)
        {
            const Boolean LoadBitmaps = false;
            GameNodeGame Game = GameNodeGame.LoadGameFromFile(FileName, LoadBitmaps, ThreadManager);
            HistoryManager.AddNew(FileName);

            if (Game.IsSomething())
            {
                LoadGameToTree(Game);
            }
            UpdateRecentScripts();
        }

        private void UpdateRecentScripts()
        {
            List<String> FileNames = HistoryManager.GetOutputFiles();
            int Lines = FileNames.Count;
            while (Lines > mnuRecentScripts.DropDownItems.Count)
            {
                ToolStripItem Item = mnuRecentScripts.DropDownItems.Add("");
                Item.Click += new System.EventHandler(this.RecentScripts_Click);

            }

            for (int i = 0; i < Lines; i++)
            {
                mnuRecentScripts.DropDownItems[i].Text = FileNames[i];
            }
        }

        private void RecentScripts_Click(object sender, EventArgs e)
        {
            ToolStripItem menu = sender as ToolStripItem;
            if (System.IO.File.Exists(menu.Text))
            {
                LoadExistingGameFromFile(menu.Text);
            }
            else
            {
                Log($"File does not exist unable to load {menu.Text}");
            }

        }


        private void LoadGameToTree(GameNodeGame game)
        {
            IsPanelLoading = true;
            ThreadManager.IncrementTestLoaded();
            tv.BeginUpdate();
            GameNode gt = WorkspaceNode;
            gt.Nodes.Clear();
            gt.Nodes.Add(game);

            game.EnsureVisible();
            game.ExpandAll();
            tv.EndUpdate();
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
                    if (cboGameInstances.Items.Count > 0)
                    {
                        cboGameInstances.SelectedIndex = 0;
                    }
                    txtGamePanelLaunchInstance.Text = "0";
                    game.InstanceToLaunch = "0";
                }
            }
            IsPanelLoading = false;
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Debug.WriteLine("tv_AfterSelect");

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
            chkFromCurrentMousePos.Visible = false;

            DisableSecondToolbarButtons();

            if (Node.IsNothing())
            {
                return;
            }
            //Console.WriteLine(Node.GameNodeType);

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
                    panelPreAction.Visible = false;
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
                            panelPreAction.Visible = true;

                            if (Action.IsParentObjectSearch())
                            {
                                panelRightOffset.Visible = true;
                                switch (Action.Mode)
                                {
                                    case Mode.RangeClick:
                                        // Do nothing
                                        break;
                                    case Mode.ClickDragRelease:
                                        panelRightDragMode.Visible = true;
                                        break;
                                    case Mode.MouseMove:
                                        panelRightDragMode.Visible = true;
                                        break;
                                    case Mode.Keyboard:
                                        // Do nothing
                                        break;
                                    default:
                                        break;
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
                                    break;
                                case Mode.MouseMove:
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
                                    break;
                                case Mode.Keyboard:
                                    panelRightSwipeProperties.Visible = false;
                                    panelRightClickProperties.Visible = false;
                                    panelKeyboard.Visible = true;
                                    PictureBox1.Visible = false;
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

        private void SetPackageNameControls(String PackageName)
        {
            txtPackageName.Text = PackageName;
            txtBluePackageName.Text = PackageName;
        }

        private void LoadGamePanel(GameNodeGame gameNode)
        {
            SetPackageNameControls(gameNode.PackageName);

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

            txtSteamPrimaryWindowName.Text = gameNode.SteamPrimaryWindowName;
            txtSteamSecondaryWindowName.Text = gameNode.SteamSecondaryWindowName;
            cboSteamPrimaryWindowNameFilter.Text = gameNode.SteamPrimaryWindowFilter.ToEnumString();
            cboSteamSecondaryWindowNameFilter.Text = gameNode.SteamSecondaryWindowFilter.ToEnumString();


            txtApplicationPrimaryWindowName.Text = gameNode.ApplicationPrimaryWindowName;
            txtApplicationSecondaryWindowName.Text = gameNode.ApplicationSecondaryWindowName;
            cboApplicationPrimaryWindowNameFilter.Text = gameNode.ApplicationPrimaryWindowFilter.ToEnumString();
            cboApplicationSecondaryWindowNameFilter.Text = gameNode.ApplicationSecondaryWindowFilter.ToEnumString();

            cboMouseMode.Text = gameNode.MouseMode.ToString();

            numericMouseSpeedPixelsPerSecond.Value = gameNode.MouseSpeedPixelsPerSecond;
            numericMouseSpeedVelocityVariantPercentMax.Value = gameNode.MouseSpeedVelocityVariantPercentMax;
            numericMouseSpeedVelocityVariantPercentMin.Value = gameNode.MouseSpeedVelocityVariantPercentMin;


            foreach (BlueGuest guest in BlueRegistry.GuestList)
            {
                if (guest.DisplayName == gameNode.BlueStacksWindowName)
                {
                    cboBlueInstance.Text = guest.BitDashDisplayName;
                    break;
                }
            }

            chkMoveMouseBeforeAction.Checked = gameNode.MoveMouseBeforeAction;
            cboWindowAction.Text = gameNode.WindowAction.ToString();

            chkGameWindowNeverQuitIfWindowNotFound.Checked = gameNode.NeverQuitIfWindowNotFound;
            chkDontTakeScreenshot.Checked = gameNode.DontTakeScreenshot;

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
                if (tv.Nodes[0].Nodes.Count > 0)
                {
                    try
                    {
                        return tv.Nodes[0].Nodes[0] as GameNodeGame;
                    }
                    catch (Exception ex)
                    {
                        Log("GetGameNode:" + ex.Message.ToString());
                    }
                }

            }
            return null;
        }

        internal GameNodeEvents GetGameNodeEvents()
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
            lblInformation.Text = "";
            pictureBoxInformationWarning.Visible = false;
            chkFromCurrentMousePos.Visible = false;
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

            chkFromCurrentMousePos.Checked = GameNode.FromCurrentMousePos;

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
                case AfterCompletionType.GoToParent:
                    rdoAfterCompletionGoTo.Checked = true;
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

            switch (GameNode.Mode)
            {
                case Mode.RangeClick:
                    rdoModeRangeClick.Checked = true;
                    break;
                case Mode.ClickDragRelease:
                    rdoModeClickDragRelease.Checked = true;
                    break;
                case Mode.MouseMove:
                    rdoModeMove.Checked = true;
                    break;
                case Mode.Keyboard:
                    rdoModeKeyboard.Checked = true;
                    break;
                default:
                    break;
            }

            chkPropertiesEnabled.Checked = GameNode.Enabled;

            txtAfterCompletionGoTo.Text = GameNode.GotoNode;

            AnchorChange(GameNode);

            switch (GameNode.ActionType)
            {
                case AppTestStudio.ActionType.Action:

                    //Properties Group
                    chkPropertiesRepeatsUntilFalse.Visible = false;
                    grpPropertiesRepeatsUntilFalse.Visible = false;
                    //End - Properties Group

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

                    txtKeyboard.Text = GameNode.KeyboardScript;

                    chkFromCurrentMousePos.Visible = true;

                    numericKeyboardTimeoutToActivateMS.Value = GameNode.KeyboardTimeoutToActivateMS;
                    chkAppActivateIfNotActive.Checked = GameNode.AppActivateIfNotActive;
                    numericKeyboardAfterSendingActivationMS.Value = GameNode.KeyboardAfterSendingActivationMS;
                    switch (GameNode.PreActionFailureAction)
                    {
                        case TimeoutAction.Abort:
                            cboPreActionFailureAction.Text = "Abort";
                            break;
                        case TimeoutAction.Continue:
                            cboPreActionFailureAction.Text = "Continue";
                            break;
                        default:
                            cboPreActionFailureAction.Text = "Abort";
                            break;
                    }

                    break;
                case AppTestStudio.ActionType.Event:

                    //Properties Group
                    chkPropertiesRepeatsUntilFalse.Visible = true;
                    grpPropertiesRepeatsUntilFalse.Visible = true;

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

                    if (GameNode.Bitmap.IsNothing())
                    {
                        GameNode.LoadBitmapFromDisk();
                    }

                    //'load existing
                    SetPictureBox1(GameNode.Bitmap);

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
            if (GameNode.Bitmap.IsNothing())
            {
                GameNode.LoadBitmapFromDisk();
            }
            SetPictureBox1(GameNode.Bitmap);
            PictureBox1.Refresh();

            ShowHidePictureMissingMessage();

            InitalizeOffsets();

            lblResolution.Text = GameNode.ResolutionWidth + "x" + GameNode.ResolutionHeight;
            IsPanelLoading = false;


            RefreshInformation(GameNode);

        }

        private void RefreshInformation(GameNodeAction Node)
        {
            const String DrawArrowMissingMessage = "No area to click has been set, please draw a line from start to finish.";
            const String DrawBoxMissingMessage = "No area to click has been set, please draw a box where the click should occur.";
            switch (Node.ActionType)
            {
                case ActionType.Action:
                    bool MissingCoordinates = false;

                    if ((Node.Rectangle.X == 0) && (Node.Rectangle.Y == 0) && (Node.Rectangle.Width == 0) && (Node.Rectangle.Height == 0))
                    {
                        MissingCoordinates = true;
                        pictureBoxInformationWarning.Visible = true;
                    }
                    switch (Node.Mode)
                    {
                        case Mode.RangeClick:
                            if (MissingCoordinates)
                            {
                                lblInformation.Text = DrawBoxMissingMessage;
                            }
                            else
                            {
                                pictureBoxInformationWarning.Visible = false;
                                lblInformation.Text = "Click starting at (" + Node.Rectangle.X + "," + Node.Rectangle.Y + ") with Height = " + Node.Rectangle.Height + ", Width =" + Node.Rectangle.Width;
                            }
                            break;
                        case Mode.ClickDragRelease:
                            if (MissingCoordinates)
                            {
                                lblInformation.Text = DrawArrowMissingMessage;
                            }
                            else
                            {
                                pictureBoxInformationWarning.Visible = false;
                                lblInformation.Text = "Swipe starting at (" + Node.Rectangle.X + "," + Node.Rectangle.Y + ") with Height = " + Node.Rectangle.Height + ", Width =" + Node.Rectangle.Width;
                            }
                            break;
                        case Mode.MouseMove:
                            if (MissingCoordinates)
                            {
                                lblInformation.Text = DrawArrowMissingMessage;
                            }
                            else
                            {
                                pictureBoxInformationWarning.Visible = false;
                                lblInformation.Text = "Mouse Move starting at (" + Node.Rectangle.X + "," + Node.Rectangle.Y + ") with Height = " + Node.Rectangle.Height + ", Width =" + Node.Rectangle.Width;
                            }
                            break;
                        case Mode.Keyboard:
                            pictureBoxInformationWarning.Visible = false;
                            break;
                        default:
                            break;
                    }
                    break;
                case ActionType.Event:
                    break;
                case ActionType.RNG:
                    break;
                case ActionType.RNGContainer:
                    break;
                default:
                    break;
            }
        }

        // Bitmap can be missing when a minimal export is loaded, minimal export does not include reference images.
        // ATS doesn't need the reference images to function, ATS will attempt to rebuild the project when the node receives a true event.
        private void ShowHidePictureMissingMessage()
        {
            Boolean IsOption = true;
            switch (PanelLoadNode.ActionType)
            {
                case ActionType.Action:
                    break;
                case ActionType.Event:
                    break;
                case ActionType.RNG:
                    IsOption = false;
                    break;
                case ActionType.RNGContainer:
                    IsOption = false;
                    break;
                default:
                    break;
            }

            if (IsOption)
            {
                if (PictureBox1.Image.IsNothing())
                {
                    lblPictureMissing.Visible = true;
                }
                else
                {
                    lblPictureMissing.Visible = false;
                }
            }
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
                            ActionNode.IsLoading = true;
                            PictureBoxEventObjectSelection.Image = gameNodeObject.Bitmap;
                            ActionNode.ObjectSearchBitmap = gameNodeObject.Bitmap;
                            ActionNode.IsLoading = false;
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
            log.Info(s);
            sb.Insert(0, s + System.Environment.NewLine);
            if (sb.Length > 10000)
            {
                sb.Remove(9700, 300);
            }
            //txtLog.Text = sb.ToString();
            txtLog.Text = sb.ToString();

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
                    Log("Creating Directory: " + Directory);
                }

                // Make a Backup file if necessary.
                if (System.IO.File.Exists(GameNode.FileName))
                {

                    String NewFileName = System.IO.Path.Combine(Directory, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss.xml"));
                    if (System.IO.File.Exists(NewFileName))
                    {
                        // do nothing
                    }
                    else
                    {
                        System.IO.File.Copy(GameNode.FileName, NewFileName);
                        Log("Saving Backup File: " + NewFileName);
                    }
                }

                String DirectoryName = Path.GetDirectoryName(GameNode.FileName);
                String TemporaryFileName = System.IO.Path.Combine(DirectoryName, Guid.NewGuid().ToString());
                XmlTextWriter Writer = null;
                try
                {
                    Writer = new XmlTextWriter(TemporaryFileName, System.Text.Encoding.UTF8);
                    Writer.Formatting = Formatting.Indented;

                    Writer.WriteStartDocument();

                    Writer.WriteStartElement("AppTestStudio");  // Root.

                    GameNode.SaveGame(Writer, ThreadManager, tv, false);
                    Writer.WriteEndElement();
                    Writer.WriteEndDocument();
                    Writer.Close();

                    System.IO.File.Delete(GameNode.FileName);
                    System.IO.File.Move(TemporaryFileName, GameNode.FileName);

                    Log("Saving New File: " + GameNode.FileName);
                }
                catch (Exception ex)
                {
                    Log("Save Failed: " + ex.Message);
                    try
                    {
                        Writer.Close();
                        System.IO.File.Delete(TemporaryFileName);
                    }
                    catch (Exception ex1)
                    {
                        Log("Attempted to clean up temp file: " + ex1.Message);
                    }
                }

                GameNode.ClearIsDirty();
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
                    RunningThreadGames.RunThread.ShutDownThread();
                    Log("Stopping existing Instance" + RunningThreadGames.GameNodeName);
                    break;
                }
            }

            GameNodeGame GameCopy = gameNode.CloneMe();

            Log4NetSetup.AddNewAppender(GameCopy.Name);
            GameCopy.InitializeLogger(GameCopy.Name);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            RunThread RT = new RunThread(GameCopy, cancellationTokenSource);
            RT.ThreadManager = ThreadManager;

            Thread t = new Thread(new ThreadStart(RT.Run));
            GameCopy.Thread = t;
            GameCopy.RunThread = RT;
            ThreadManager.Games.Add(GameCopy);

            RefreshThreadList();

            RefreshStatusList();

            toolStripButtonToggleScript.Enabled = true;

            OrdinateGameNode();

            t.Start();
            SetThreadPauseState(false);

            ThreadManager.IncrementInstanceLoaded();

            tabTree.SelectTab(1);
            cboThreads.SelectedIndex = cboThreads.Items.Count - 1;
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

        private void OrdinateGameNode()
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



        private void SetThreadPauseState(Boolean isPaused)
        {
            foreach (GameNodeGame Game in ThreadManager.Games)
            {
                Game.IsPaused = isPaused;
                if (isPaused)
                {
                    Log("Pausing Thread " + Game.ThreadandWindowName);
                }
                else
                {
                    Log("Resuming Thread " + Game.ThreadandWindowName);
                }
            }

            if (isPaused)
            {
                toolStripButtonToggleScript.Text = UnPauseScript;
                toolStripButtonToggleScript.Image = AppTestStudio.Properties.Resources.StartWithoutDebug_16x_24;
            }
            else
            {
                toolStripButtonToggleScript.Text = PauseScript;
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
                Boolean Success = false;
                Bitmap bmp = Utils.GetBitmapFromWindowHandle(ref Success, MainWindowHandle);
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
            MakeObject();
        }

        /// <summary>
        /// Make Object creates searchable images used for Object Search Events
        /// Called from buttons on Create New Object Panels.
        /// </summary>
        private void MakeObject()
        {
            GameNodeObjects ObjectsNode = GetObjectsNode();

            String OriginalName = txtObjectScreenshotName.Text.Trim();
            foreach (GameNodeObject obj in ObjectsNode.Nodes)
            {
                if (obj.GameNodeName.ToUpper() == txtObjectScreenshotName.Text.Trim().ToUpper())
                {
                    txtObjectScreenshotName.Text = FindNextObjectNameIncrement(txtObjectScreenshotName.Text);

                    Log("Create Object: Object with this name [" + OriginalName + "] already exists and must be unique, auto-increment-named to: " + txtObjectScreenshotName.Text);
                    break;
                }
            }

            if (PictureObjectScreenshotRectangle.Width <= 0 || PictureObjectScreenshotRectangle.Height <= 0)
            {
                return;
            }
            Bitmap CropImage = new Bitmap(PictureObjectScreenshotRectangle.Width, PictureObjectScreenshotRectangle.Height);
            using (Graphics grp = Graphics.FromImage(CropImage))
            {
                grp.DrawImage(PictureObjectScreenshot.Image, new Rectangle(0, 0, PictureObjectScreenshotRectangle.Width, PictureObjectScreenshotRectangle.Height), PictureObjectScreenshotRectangle, GraphicsUnit.Pixel);
                //'grp.DrawEllipse(Pens.Black, 40, 40, 40, 40)

                grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                GameNodeObject o = new GameNodeObject(txtObjectScreenshotName.Text.Trim());
                o.Bitmap = CropImage;

                GetObjectsNode().AddGameNode(o);

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
            LastNode = e.Node as GameNode;
        }

        private void tv_MouseUp(object sender, MouseEventArgs e)
        {
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

                            // No Copy/Cut Events 
                            toolStripMenuCopy.Visible = false;
                            toolStripMenuCut.Visible = false;

                            // On events tab don't show paste if there is something to paste.
                            switch (cutCopyOption)
                            {
                                case CutCopyOption.None:
                                    toolStripMenuPaste.Visible = false;
                                    toolStripSeparatorCutCopyPaste.Visible = false;
                                    break;
                                case CutCopyOption.Cut:
                                    toolStripMenuPaste.Visible = true;
                                    toolStripSeparatorCutCopyPaste.Visible = true;
                                    break;
                                case CutCopyOption.Copy:
                                    toolStripMenuPaste.Visible = true;
                                    toolStripSeparatorCutCopyPaste.Visible = true;

                                    break;
                                default:
                                    break;
                            }

                            mnuEvents.Show(tv, p);
                            break;
                        case GameNodeType.Action:
                            GameNodeAction Action = node as GameNodeAction;
                            toolStripMenuCopy.Visible = true;
                            toolStripMenuCut.Visible = true;
                            if (cutCopyOption == CutCopyOption.None)
                            {
                                toolStripMenuPaste.Visible = false;
                            }
                            else
                            {
                                toolStripMenuPaste.Visible = true;
                            }

                            toolStripSeparatorCutCopyPaste.Visible = true;
                            switch (Action.ActionType)
                            {
                                case ActionType.Action:
                                    break;
                                case ActionType.Event:
                                    break;
                                case ActionType.RNG:
                                    // Copy/Paste a RNG node has special rules, too much work for little use.
                                    toolStripMenuCopy.Visible = false;
                                    toolStripMenuCut.Visible = false;

                                    break;
                                case ActionType.RNGContainer:
                                    switch (cutCopyOption)
                                    {
                                        case CutCopyOption.None:
                                            break;
                                        case CutCopyOption.Cut:
                                        case CutCopyOption.Copy:
                                            if (cutCopyActionNode.ActionType == ActionType.RNG)
                                            {
                                                // Can copyCut Rng node into RNG Container
                                            }
                                            else
                                            {
                                                toolStripMenuPaste.Visible = false;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
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
                if (tn.IsSomething())
                {
                    if (tn.NextVisibleNode != null)
                        tn.NextVisibleNode.EnsureVisible();
                }
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

            targetAction.AddGameNode(GameNodeAction);
            tv.SelectedNode = GameNodeAction;
            ThreadManager.IncrementNewRNGContainer();
            return GameNodeAction;


        }

        private void PictureObjectScreenshot_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("PictureObjectScreenshot_MouseDown");
            IsPictureObjectScreenshotMouseDown = true;
            PictureObjectScreenshotRectangle = new Rectangle();
            PictureObjectScreenshotRectangle.X = e.X;
            PictureObjectScreenshotRectangle.Y = e.Y;
            PictureObjectScreenshot.Invalidate();

        }

        private void PictureObjectScreenshot_MouseMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("PictureObjectScreenshot_MouseMove");
            int x = 1;
            int y = 0;
            Color color = new Color();
            ShowZoom(PictureObjectScreenshot, PictureObjectScreenshotZoomBox, e, panelObjectScreenshotColor, lblObjectScreenshotColorXY, lblObjectScreenshotRHSXY, ref x, ref y, ref color, IsPictureObjectScreenshotMouseDown, ref PictureObjectScreenshotRectangle);

            Boolean ReadyToSave = IsCreateScreenshotReadyToCreate();

            cmdMakeObject.Enabled = ReadyToSave;
            cmdMakeObjectAndUse.Enabled = ReadyToSave && IsMakeObjectAndUseAbleToBeUsed();

            pictureCreateNewObjectMaskDrawnCheckBox.Visible = IsCreateScreenshotMarked();

        }


        private bool IsMakeObjectAndUseAbleToBeUsed()
        {
            return LastNodeAddObjectWasUsedFrom.IsSomething();
        }

        // Zoom and Crop/Mask
        private Boolean ShowZoom(PictureBox pb, PictureBox pb2, MouseEventArgs e, Panel PSC, Label lblColor, Label lblXY, ref int PB1x, ref int PB1Y, ref Color PB1Color, bool pb1MouseDown, ref Rectangle rect)
        {
            // this zooms and sets masks
            // need to decouple some time.
            if (pb.Image.IsSomething())
            {
                Bitmap MyBitmap = pb.Image as Bitmap;
                if (e.X >= MyBitmap.Width)
                {
                    return false;
                }
                if (e.Y >= MyBitmap.Height - 1)
                {
                    return false;
                }

                if (e.X <= -1)
                {
                    return false;
                }

                if (e.Y <= -1)
                {
                    return false;
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
                    return true;
                }
            }
            return false;
        }

        private bool IsCreateScreenshotNamed()
        {
            if (txtObjectScreenshotName.Text.Trim().Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsCreateScreenshotMarked()
        {
            if (PictureObjectScreenshotRectangle.IsEmpty)
            {
                return false;
            }

            if (PictureObjectScreenshotRectangle.Width <= 0 || PictureObjectScreenshotRectangle.Height <= 0)
            {
                return false;
            }

            return true;
        }
        private bool IsCreateScreenshotReadyToCreate()
        {
            if (IsCreateScreenshotNamed())

            {
                //' Do nothing
            }
            else
            {
                return false;
            }

            return IsCreateScreenshotMarked();
        }

        private void PictureObjectScreenshot_MouseUp(object sender, MouseEventArgs e)
        {
            IsPictureObjectScreenshotMouseDown = false;
        }

        private void PictureObjectScreenshot_Paint(object sender, PaintEventArgs e)
        {
            if (PictureObjectScreenshotRectangle.Width > 0 && PictureObjectScreenshotRectangle.Height > 0)
            {
                using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                {
                    e.Graphics.FillRectangle(br, PictureObjectScreenshotRectangle);
                }

                using (Pen p = new Pen(Color.Blue, 1))
                {
                    e.Graphics.DrawRectangle(p, PictureObjectScreenshotRectangle);
                }
            }
        }

        private void txtObjectScreenshotName_TextChanged(object sender, EventArgs e)
        {
            Boolean ReadyToSave = IsCreateScreenshotReadyToCreate();
            cmdMakeObject.Enabled = ReadyToSave;
            cmdMakeObjectAndUse.Enabled = ReadyToSave && IsMakeObjectAndUseAbleToBeUsed();
            pictureCreateNewObjectNamedCheckBox.Visible = IsCreateScreenshotNamed();
        }

        private void txtPackageName_TextChanged(object sender, EventArgs e)
        {
            GameNodeGame Game = tv.SelectedNode as GameNodeGame;
            if (Game.IsSomething())
            {
                Game.PackageName = txtPackageName.Text.Trim();

                if (Game.PackageName.Length > 0)
                {
                    toolStripButtonRunStartLaunch.Enabled = true;
                    toolStripButtonStartEmmulatorLaunchApp.Enabled = true;
                }
                else
                {
                    toolStripButtonRunStartLaunch.Enabled = false;
                    toolStripButtonStartEmmulatorLaunchApp.Enabled = false;
                }
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
            StartEmmulator(Game, "", Game.InstanceToLaunch);
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
                    case Platform.BlueStacks:

                        Result = Utils.LaunchBlueStacksInstance(PackageName, Game.BlueGuest);
                        break;
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
            GameNode.VideoFrameLimit = NumericVideoFrameLimit.Value.ToLong();
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
            String FileName = "";
            try
            {
                FileName = GetScheduleFileName();
            }
            catch (Exception ex)
            {
                Log("Save Schedule: error getting filename " + ex.Message);

            }

            try
            {
                TextWriter TR = new StreamWriter(FileName);
                XmlSerializer Serializer = new XmlSerializer(Schedule.GetType());

                Serializer.Serialize(TR, Schedule);
                TR.Close();

            }
            catch (Exception ex)
            {

                Log("Unable to save schedule:" + ex.Message);
            }

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
                    Schedule.RuntimeSchedule = Schedule.GenerateRuntimeSchedule(DateTime.Now);
                    ReloadRuntimeScheduleView();
                }
            }

        }

        private void ReloadRuntimeScheduleView()
        {
            dgRuntimeSchedule.Rows.Clear();
            foreach (ScheduleItem item in Schedule.RuntimeSchedule)
            {

                String ItemName = item.Name;
                String WindowName = item.WindowName;
                String InstanceNumber = item.InstanceNumber.ToString();
                String StartsAt = item.NextRun.ToString("hh:mm tt");


                String[] k = {
                    ItemName,
                WindowName,
                InstanceNumber,
                StartsAt};
                dgRuntimeSchedule.Rows.Add(k);
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
                String IsEnabled = item.IsEnabled.ToString();

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
                StartsAt, Repeats,IsEnabled};
                dgSchedule.Rows.Add(k);
                item.CurrentRun = DateTime.MinValue;
            }


        }

        private void chkUseParentScreenshot_CheckedChanged(object sender, EventArgs e)
        {
            LoadParentScreenshotIfNecessary();
            if (IsPanelLoading == false)
            {
                GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

                Picturable.UseParentPicture = chkUseParentScreenshot.Checked;
            }
        }

        private void LoadParentScreenshotIfNecessary(Boolean AlwaysPull = false)
        {
            if (chkUseParentScreenshot.Checked || AlwaysPull)
            {
                GameNode CurrentParent = PanelLoadNode.Parent as GameNode;

                while (CurrentParent is GameNodeAction)
                {

                    GameNodeAction Action = CurrentParent as GameNodeAction;
                    if (Action.Bitmap.IsSomething())
                    {
                        PanelLoadNode.Bitmap = Action.Bitmap.Clone() as Bitmap;
                        SetPictureBox1(PanelLoadNode.Bitmap as Bitmap);
                        ShowHidePictureMissingMessage();
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
                SaveClickList();

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
                if (PanelLoadNode.IsSomething())
                {
                    GameNode p = PanelLoadNode.Parent as GameNode;
                    PanelLoadNode.Remove();
                    tv.SelectedNode = p;
                }
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

            ActionSolution solution = null;

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
                            if (ActionNode.AppActivateIfNotActive)
                            {
                                IntPtr WindowHandle = game.GetWindowHandleByWindowName();
                                Utils.ActivateWindowIfNecessary2(WindowHandle, ActionNode.KeyboardTimeoutToActivateMS, ActionNode.KeyboardAfterSendingActivationMS);
                            }
                            Boolean Success = false;
                            Bitmap bmp = Utils.GetBitmapFromWindowHandle(ref Success, MainWindowHandle);
                            switch (ActionNode.Mode)
                            {
                                case Mode.RangeClick:
                                    GameNodeAction.RangeClickResult RangeClickResult = ActionNode.CalculateRangeClickResult(bmp, 0, 0);
                                    if (RangeClickResult.x < 0)
                                    {
                                        Log("Check Relative offset X, calculated to a negative position " + RangeClickResult.x);
                                    }

                                    if (RangeClickResult.y < 0)
                                    {
                                        Log("Check Relative offset Y, calculated to a negative position " + RangeClickResult.y);
                                    }

                                    int MousePixelSpeedPerSecond = game.CalculateNextMousePixelSpeedPerSecond();

                                    solution = Calculations.CalculateClickOnWindow(MainWindowHandle, game.MouseMode, ActionNode.FromCurrentMousePos, game.WindowAction, game.MouseX, game.MouseY, RangeClickResult.x, RangeClickResult.y, ActionNode.ClickSpeed, MousePixelSpeedPerSecond);
                                    solution.TargetX = RangeClickResult.x;
                                    solution.TargetY = RangeClickResult.y;
                                    solution.ActivateWindow = ActionNode.AppActivateIfNotActive;

                                    SolutionPlayer.Play(solution);

                                    Log("Click attempt: x=" + RangeClickResult.x + ",Y = " + RangeClickResult.y);
                                    ThreadManager.IncrementSingleTestClick();

                                    break;
                                case Mode.ClickDragRelease:
                                    GameNodeAction.ClickDragReleaseResult ClickDragResult = ActionNode.CalculateClickDragReleaseResult(0, 0);

                                    solution = Calculations.CalculateClickDragRelease(MainWindowHandle, game.MouseMode, ActionNode.FromCurrentMousePos, game.WindowAction, ClickDragResult.StartX, ClickDragResult.StartY, ClickDragResult.EndX, ClickDragResult.EndY, ActionNode.ClickDragReleaseVelocity, game.MouseSpeedPixelsPerSecond, game.DefaultClickSpeed);
                                    solution.TargetX = ClickDragResult.EndX;
                                    solution.TargetY = ClickDragResult.EndY;
                                    solution.ActivateWindow = ActionNode.AppActivateIfNotActive;

                                    SolutionPlayer.Play(solution);

                                    Log("ClickDragRelease( x=" + ClickDragResult.StartX + ",Y = " + ClickDragResult.StartY + ", ex=" + ClickDragResult.EndX + ",ey=" + ClickDragResult.EndY + ")");
                                    ThreadManager.IncrementSingleTestClickDragRelease();
                                    break;
                                case Mode.MouseMove:
                                    GameNodeAction.ClickDragReleaseResult MouseMoveResult = ActionNode.CalculateClickDragReleaseResult(0, 0);

                                    solution = Calculations.CalculateMouseMove(MainWindowHandle, game.MouseMode, ActionNode.FromCurrentMousePos, game.WindowAction, MouseMoveResult.StartX, MouseMoveResult.StartY, MouseMoveResult.EndX, MouseMoveResult.EndY, ActionNode.ClickDragReleaseVelocity, game.MouseSpeedPixelsPerSecond, game.DefaultClickSpeed);
                                    solution.TargetX = MouseMoveResult.EndX;
                                    solution.TargetY = MouseMoveResult.EndY;
                                    solution.ActivateWindow = ActionNode.AppActivateIfNotActive;

                                    SolutionPlayer.Play(solution);

                                    Log("MouseMove( x=" + MouseMoveResult.StartX + ",Y = " + MouseMoveResult.StartY + ", ex=" + MouseMoveResult.EndX + ",ey=" + MouseMoveResult.EndY + ")");
                                    ThreadManager.IncrementSingleTestMouseMove();
                                    break;
                                case Mode.Keyboard:
                                    if (ActionNode.RumtimeIsKeyboardCompiled == false)
                                    {
                                        if (ActionNode.KeyboardScript.Length > 0)
                                        {
                                            AppTestStudio.KeyboardProcessor keyboardProcessor = new AppTestStudio.KeyboardProcessor();

                                            ActionNode.RuntimeCompiledKeyboardCommands = keyboardProcessor.ParseScript(ActionNode.KeyboardScript);
                                        }
                                    }

                                    if (ActionNode.RuntimeCompiledKeyboardCommands.Count > 0)
                                    {
                                        Debug.WriteLine("TODO Add RNG Here<<");
                                        if (true)
                                        {
                                            IntPtr hWnd = Utils.GetWindowHandleByWindowName(game);
                                            if (hWnd.Equals(IntPtr.Zero))
                                            {
                                                Debug.WriteLine($"Unable to locate {game.ApplicationPrimaryWindowName}");
                                            }
                                            else
                                            {
                                                Utils.ActivateWindowIfNecessary2(hWnd, 4000, 100);
                                            }
                                        }

                                        foreach (KeyboardCommand command in ActionNode.RuntimeCompiledKeyboardCommands)
                                        {
                                            Utils.ProcessKeyboardCommand(command);
                                        }
                                    }

                                    break;

                                default:
                                    break;
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
                int CurrentThreadLogCount = ThreadManager.ThreadLog.Count();
                while (CurrentThreadLogCount-- > 0)
                {
                    if (ThreadManager.ThreadLog.Count() > 0)
                    {
                        String s = "";

                        if (ThreadManager.ThreadLog.TryDequeue(out s))
                        {
                            Log(s);
                        }
                    }
                    else
                    {
                        // shouldn't happen.
                        break;
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
            int lstthreadsSelectedIndex = cboThreads.SelectedIndex;
            if (lstthreadsSelectedIndex == -1)
            {
                if (cboThreads.Items.Count > 0)
                {
                    cboThreads.SelectedIndex = 0;
                }
            }

            toolStripButtonToggleScript.Enabled = true;

            foreach (GameNodeGame game in ThreadManager.Games.ToList())
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

                    if (game.MinimalBitmapClones.Count > 0)
                    {
                        //'walk the tree to find a bitmap

                        MinimalBitmapNode mbmc = null;
                        if (game.MinimalBitmapClones.TryDequeue(out mbmc))
                        {
                            TreeNode[] tns = tv.Nodes.Find(mbmc.NodeName, true);

                            if (tns.Length == 1)
                            {
                                GameNodeAction ActionNode = tns[0] as GameNodeAction;
                                if (ActionNode != null)
                                {

                                    if (mbmc.ResolutionHeight > 0)
                                    {
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
                                }
                                else
                                {
                                    Log("Node is not of type GameNodeAction: " + mbmc.NodeName);
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

                TimeSpan t = TimeSpan.FromSeconds(ThreadManager.WaitLength / 1000);
                lblWaiting.Text = t.ToDhmsString();

                t = TimeSpan.FromSeconds((ThreadManager.WaitLength + ThreadManager.LoadThreadManager.WaitLength) / 1000);

                lblWaitingTotal.Text = t.ToDhmsString();

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

            foreach (GameNodeGame game in ThreadManager.Games.ToList())
            {
                while (game.GamePassSolutionClones.IsEmpty == false)
                {
                    GamePassSolution gamePassSolution = null;
                    if (game.GamePassSolutionClones.TryDequeue(out gamePassSolution))
                    {
                        AddGamePassSolution(gamePassSolution);
                    }
                }
            }

            foreach (GameNodeGame game in ThreadManager.Games.ToList())
            {
                if (game.IsSomething())
                {
                    if (game.SaveVideo)
                    {
                        if (game.VideoFrameLimit > 0)
                        {
                            if (game.Video.IsNothing())
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
                                        //dont dispose re-reading it later.
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

        int GamePassListCounter = 0;

        private void AddGamePassSolution(GamePassSolution gamePassSolution)
        {
            int GamePassListCount = GamePassList.Count;

            Boolean UpdateGamePassList = true;

            if (GamePassListCount == 0)
            {
                UpdateGamePassList = false;
                GamePassListCount = 1;

            }

            int GamePassIndex = GamePassListCounter % GamePassListCount;
            int LastGamePassIndex = (GamePassListCounter - 1) % GamePassListCount;
            int Last2GamePassIndex = (GamePassListCounter - 2) % GamePassListCount;
            int Last3GamePassIndex = (GamePassListCounter - 3) % GamePassListCount;

            if (UpdateGamePassList)
            {
                // Looping Index
                GamePassList[GamePassIndex].SubItems[0].Text = "";
                GamePassList[GamePassIndex].SubItems[1].Text = DateTime.Now.ToString("HH:mm:ss");
                GamePassList[GamePassIndex].SubItems[2].Text = gamePassSolution.SolutionID.ToString();
                GamePassList[GamePassIndex].SubItems[3].Text = gamePassSolution.Solutions.Count().ToString();
                GamePassList[GamePassIndex].SubItems[4].Text = gamePassSolution.LastNodeName;

                // Clear the icon
                if (GamePassListCounter > 0)
                {
                    GamePassList[LastGamePassIndex].ImageIndex = 34;  // Blank
                }

                // Set the current arrow as indicator.
                GamePassList[GamePassIndex].ImageIndex = 5;  // Right Arrow



            }

            GamePassSolutions.Add(gamePassSolution);
            if (GamePassSolutions.Count > GamePassListCount)
            {
                GamePassSolutions.RemoveAt(0);
            }
            GamePassListCounter++;
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

            String Filename = Directory + @"\" + game.GameNodeName + DateTime.Now.ToString("ATSyyyyMMddHHmmss") + ".mp4";
            game.Video = new OpenCvSharp.VideoWriter(Filename, OpenCvSharp.FourCC.XVID, 1, new OpenCvSharp.Size(bmp.Width, bmp.Height), true);
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

                        SaveClickList();

                        GameNodeAction GameNode = tv.SelectedNode as GameNodeAction;
                    }
                    break;
                case "Action":

                    break;
                default:
                    break;
            }
        }


        public void SaveClickList()
        {
            GameNodeAction ActionNode = PanelLoadNode as GameNodeAction;
            if (ActionNode.IsNothing())
            {
                Log("Unable to identify selected node.");
                return;
            }

            if (ActionNode.ActionType == ActionType.Event)
            {

                //'      Color.
                ActionNode.ClickList.Clear();

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
                            ActionNode.AddToClickList(SingleClick);

                            if (rdoAnd.Checked)
                            {
                                ActionNode.LogicChoice = "AND";
                            }
                            else if (rdoOR.Checked)
                            {
                                ActionNode.LogicChoice = "OR";
                            }
                            else
                            {
                                ActionNode.LogicChoice = "CUSTOM";
                            }
                        }
                    }
                }
                Utils.SetIcons(ActionNode);
                //' LoadPanelSingleColorAtSingleLocation(PanelLoadNode)
                //'tv.SelectedNode = EventNode
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

            Boolean Changed = ShowZoom(PictureBox1, PictureBox2, e, PanelSelectedColor, lblRHSColor, lblRHSXY, ref PictureBox1X, ref PictureBox1Y, ref PictureBox1Color, PictureBox1MouseDown, ref Node.mRectangle);
            if (Changed)
            {
                Node.FlagAsDirty();
            }

            RefreshInformation(Node);
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

        /// <summary>
        /// Draws masks on the main image display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Node.Rectangle contains the mask when rdocolorpoint.checked == false

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
                        Utils.DrawMask(Node, PictureBox1, Node.Rectangle, e);

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
                    try
                    {
                        dgv.Rows.Remove(dgv.Rows[e.RowIndex]);

                        for (int i = e.RowIndex; i < dgv.Rows.Count - 1; i++)
                        {
                            dgv.Rows[i].Cells["dgvID"].Value = i + 1;
                        }

                        if (IsPanelLoading == false)
                        {
                            SaveClickList();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }


                    GameNodeAction GameNode = tv.SelectedNode as GameNodeAction;

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
                                SaveClickList();
                            }
                        }
                    }
                    PictureBox1.Refresh();
                }
            }
            catch (System.InvalidOperationException ex)
            {
                Log($"Can't remove on the Insert row {ex.Message}");
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
                Boolean Success = false;
                Bitmap bmp = Utils.GetBitmapFromWindowHandle(ref Success, MainWindowHandle);
                Color Color = bmp.GetPixel(x, y);
                return Color;

            }

            return Color.Empty;
        }

        private GameNodeAction LastNodeAddObjectWasUsedFrom = null;
        private void cmdAddObject2_Click(object sender, EventArgs e)
        {
            LastNodeAddObjectWasUsedFrom = tv.SelectedNode as GameNodeAction;

            //' Change the Panel to Object Screenshot
            SetPanel(PanelMode.ObjectScreenshot);

            //' Hide the Make object buttone because the name is not long enough
            cmdMakeObject.Enabled = false;

            //' Reset the Rectangle in case it//'s already being used.
            PictureObjectScreenshotRectangle = new Rectangle();

            //' Set the current image.
            PictureObjectScreenshot.Image = PictureBox1.Image;

            PanelLoadNode.BackColor = Color.White;

            pictureCreateNewObjectMaskDrawnCheckBox.Visible = false;
            pictureCreateNewObjectNamedCheckBox.Visible = false;
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
                    DisableSecondToolbarButtons();
                    SetPanel(PanelMode.Thread);

                    break;
                case 2:
                    DisableSecondToolbarButtons();
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

        internal void SetPictureBox1(Bitmap bmp)
        {
            PictureBox1.Image = bmp;
            GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

            if (PictureBox1.Image.IsSomething())
            {
                Picturable.Bitmap = PictureBox1.Image as Bitmap;
                Picturable.ResolutionWidth = PictureBox1.Image.Width;
                Picturable.ResolutionHeight = PictureBox1.Image.Height;
            }
        }

        private void cmdAddSingleColorAtSingleLocationTakeASceenshot_Click(object sender, EventArgs e)
        {
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();

            String TargetWindow = GameNode.TargetWindow;

            IntPtr MainWindowHandle = GameNode.GetWindowHandleByWindowName();

            uint Dpi = NativeMethods.GetDpiForWindow(MainWindowHandle);

            if (Dpi != 96)
            {
                Log($"*** DPI at {Dpi} Warning *** Use a monitor with the scaling set to 100%.  Go to: Windows->System->Display->Choose Monitor running->Scale&Layout->Scale set to 100%");
            }

            Debug.Print("cmdAddSingleColorAtSingleLocationTakeASceenshot_Click TW=" + TargetWindow + " MWH= " + MainWindowHandle);

            if (MainWindowHandle.ToInt32() > 0)
            {
                Boolean Success = false;
                Bitmap bmp = Utils.GetBitmapFromWindowHandle(ref Success, MainWindowHandle);
                //bmp.Save("C:\\Users\\djhar\\Desktop\\b.bmp");
                lblResolution.Text = bmp.Width + "x" + bmp.Height;

                SetPictureBox1(bmp);

                ShowHidePictureMissingMessage();

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
                    SaveClickList();

                }

            }
            else
            {
                Log("Unable to locate window: " + TargetWindow);
            }
        }

        private void RDOAfterCompletionChange()
        {
            try
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

                if (rdoAfterCompletionGoTo.Checked)
                {
                    ChosenAfterCompletionType = AfterCompletionType.GoToParent;
                }

                GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

                Picturable.AfterCompletionType = ChosenAfterCompletionType;
            }
            catch (Exception ex)
            {
                Log("RDOAfterCompletionChange");
                Log(ex.Message);
            }
        }

        private void rdoAfterCompletionContinue_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                RDOAfterCompletionChange();
            }
        }

        private void rdoAfterCompletionHome_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                RDOAfterCompletionChange();
            }
        }

        private void rdoAfterCompletionParent_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                RDOAfterCompletionChange();
            }
        }

        private void rdoAfterCompletionStop_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                RDOAfterCompletionChange();
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
                GameNodeAction ActionNode = PanelLoadNode as GameNodeAction;

                if (cboDelayMS.Text.IsNumeric())
                {
                    ActionNode.DelayMS = cboDelayMS.Text.ToInt();
                }
                else
                {
                    ActionNode.DelayMS = ActionNode.DefaultDelayMS();
                }
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
                GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

                if (cboDelayS.Text.IsNumeric())
                {
                    Picturable.DelayS = cboDelayS.Text.ToInt();
                }
                else
                {
                    Picturable.DelayS = Picturable.DefaultDelayS();
                }
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
                GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

                if (cboDelayM.Text.IsNumeric())
                {
                    Picturable.DelayM = cboDelayM.Text.ToInt();
                }
                else
                {
                    Picturable.DelayM = Picturable.DefaultDelayM();
                }
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
                GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

                if (cboDelayH.Text.IsNumeric())
                {
                    Picturable.DelayH = cboDelayH.Text.ToInt();
                }
                else
                {
                    Picturable.DelayH = Picturable.DefaultDelayH();
                }
            }
        }

        private void chkUseLimit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

                    Picturable.IsLimited = chkUseLimit.Checked;
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
            catch (Exception ex)
            {
                Log("chkUseLimit_CheckedChanged");
                Log(ex.Message);
            }
        }

        private void cboWaitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Picturable = PanelLoadNode as GameNodeAction;
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
            catch (Exception ex)
            {
                Log("cboWaitType_SelectedIndexChanged");
                Log(ex.Message);
            }
        }

        private void chkWaitFirst_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                    Node.IsWaitFirst = chkWaitFirst.Checked;
                }
            }
            catch (Exception ex)
            {
                Log("chkWaitFirst_CheckedChanged");
                Log(ex.Message);
            }
        }

        private void numIterations_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction ActionNode = PanelLoadNode as GameNodeAction;
                    ActionNode.ExecutionLimit = numIterations.Value.ToLong();
                }
            }
            catch (Exception ex)
            {
                Log("numIterations_ValueChanged");
                Log(ex.Message);
            }
        }

        private void chkLimitRepeats_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Node = tv.SelectedNode as GameNodeAction;
                    Node.LimitRepeats = chkLimitRepeats.Checked;
                }
            }
            catch (Exception ex)
            {
                Log("chkLimitRepeats_CheckedChanged");
                Log(ex.Message);
            }
        }

        private void lnkLimitTime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log("lnkLimitTime_LinkClicked");
                Log(ex.Message);
            }
        }

        private void cboPoints_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction Picturable = PanelLoadNode as GameNodeAction;

                    Picturable.Points = cboPoints.Text.ToInt();
                }
            }
            catch (Exception ex)
            {
                Log("cboPoints_TextChanged");
                Log(ex.Message);
            }
        }

        private void NumericXOffset_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                    ActionNode.RelativeXOffset = NumericXOffset.Value.ToInt();
                    PictureBox1.Invalidate();
                }
            }
            catch (Exception ex)
            {
                Log("NumericXOffset_ValueChanged");
                Log(ex.Message);
            }
        }

        private void NumericYOffset_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                    ActionNode.RelativeYOffset = NumericYOffset.Value.ToInt();
                    PictureBox1.Invalidate();
                }
            }
            catch (Exception ex)
            {
                Log("NumericYOffset_ValueChanged");
                Log(ex.Message);
            }

        }

        private void cboObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log("cboObject_SelectedIndexChanged");
                Log(ex.Message);
            }

        }

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log("cboChannel_SelectedIndexChanged");
                Log(ex.Message);
            }
        }

        private void NumericObjectThreshold_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                    ActionNode.ObjectThreshold = NumericObjectThreshold.Value.ToLong();
                }
            }
            catch (Exception ex)
            {
                Log("NumericObjectThreshold_ValueChanged");
                Log(ex.Message);
            }

        }

        private void cmdMaxMask_Click(object sender, EventArgs e)
        {
            try
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.Rectangle = new Rectangle(0, 0, PictureBox1.Image.Width, PictureBox1.Image.Height);
                PictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                Log("cmdMaxMask_Click");
                Log(ex.Message);
            }
        }

        private void dgSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                    Schedule.RuntimeSchedule = Schedule.GenerateRuntimeSchedule(DateTime.Now);
                    ReloadRuntimeScheduleView();
                }
            }
            catch (Exception ex)
            {
                Log("dgSchedule_CellContentClick");
                Log(ex.Message);
            }

        }


        private void timerScheduler_Tick(object sender, EventArgs e)
        {
            try
            {

                DateTime LowestNextRun = DateTime.MinValue;

                // not sure I need a loop anymore as the list is now sorted.
                for (int i = 0; i < Schedule.RuntimeSchedule.Count(); i++)
                {
                    if (Schedule.RuntimeSchedule[i].NextRun < DateTime.Now)
                    {
                        LaunchScheduledGame(Schedule.RuntimeSchedule[i]);
                        Schedule.RuntimeSchedule.RemoveAt(i);
                    }
                    else
                    {
                        if (Schedule.RuntimeSchedule[i].NextRun > DateTime.Now)
                        {
                            LowestNextRun = Schedule.RuntimeSchedule[i].NextRun;
                            break;
                        }
                    }
                }

                if (Schedule.ScheduleList.Count() > 0)
                {
                    if (Schedule.RuntimeSchedule.Count() == 0)
                    {
                        // We are out of schedules for the day load next day's schedule.
                        Schedule.RuntimeSchedule = Schedule.GenerateRuntimeSchedule(DateTime.Now.AddDays(1));
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
            catch (Exception ex)
            {
                Log("timerScheduler_Tick");
                Log(ex.Message);
            }
        }


        private void LaunchScheduledGame(ScheduleItem si)
        {
            si.CurrentRun = DateTime.Now;
            si.CalculateAndSetNextRun();

            if (System.IO.File.Exists(si.AppPath))
            {
                const Boolean LoadBitmaps = false;
                GameNodeGame Game = GameNodeGame.LoadGameFromFile(si.AppPath, LoadBitmaps, ThreadManager);

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
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction ActionNode = PanelLoadNode as GameNodeAction;

                    if (rdoModeRangeClick.Checked)
                    {
                        ActionNode.Mode = Mode.RangeClick;
                        Debug.WriteLine($"rdoRangeClick_CheckedChanged ActionNode.Mode={ActionNode.Mode}");

                        String EventName = txtEventName.Text;
                        if (EventName.StartsWith("Swipe "))
                        {
                            // Remove 'Swipe' add Click
                            txtEventName.Text = $"Click {txtEventName.Text.Substring(6, txtEventName.Text.Length - 6)}";
                        }
                        if (EventName.StartsWith("Move "))
                        {
                            // Remove 'Move' add Click
                            txtEventName.Text = $"Click {txtEventName.Text.Substring(5, txtEventName.Text.Length - 5)}";
                        }
                        if (EventName.StartsWith("Keyboard "))
                        {
                            // Remove 'Keyboard' add Click
                            txtEventName.Text = $"Click {txtEventName.Text.Substring(9, txtEventName.Text.Length - 9)}";
                        }
                    }
                }

                if (rdoModeRangeClick.Checked)
                {
                    panelKeyboard.Visible = false;
                    panelRightSwipeProperties.Visible = false;
                    PictureBox1.Visible = true;
                    if (PanelLoadNode.ActionType == ActionType.Action)
                    {
                        chkFromCurrentMousePos.Visible = true;
                    }
                }
                PictureBox1.Refresh();
            }
            catch (Exception ex)
            {
                Log("rdoModeRangeClick_CheckedChanged");
                Log(ex.Message);
            }
        }

        private void rdoModeClickDragRelease_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                //SaveClickList();
                //Saving not necessary
            }

            if (rdoModeClickDragRelease.Checked)
            {
                if (IsPanelLoading == false)
                {
                    panelRightSwipeProperties.Visible = true;
                    panelKeyboard.Visible = false;
                    PictureBox1.Visible = true;
                    GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;

                    ActionNode.Mode = Mode.ClickDragRelease;

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

                    String EventName = txtEventName.Text;
                    if (EventName.StartsWith("Move "))
                    {
                        // Remove 'Move' add Swipe
                        txtEventName.Text = $"Swipe {txtEventName.Text.Substring(5, txtEventName.Text.Length - 5)}";
                    }
                    if (EventName.StartsWith("Keyboard "))
                    {
                        // Remove 'Keyboard' add Swipe
                        txtEventName.Text = $"Swipe {txtEventName.Text.Substring(9, txtEventName.Text.Length - 9)}";
                    }
                    if (EventName.StartsWith("Click "))
                    {
                        // Remove 'Click' add Swipe
                        txtEventName.Text = $"Swipe {txtEventName.Text.Substring(6, txtEventName.Text.Length - 6)}";
                    }
                }
                panelRightClickProperties.Visible = false;
            }
            PictureBox1.Refresh();
        }

        private void mnuAddEvent_Click(object sender, EventArgs e)
        {
            AddNewEvent();
        }

        internal void AddNewEvent(Boolean AddToTop = false)
        {
            if (tv.SelectedNode.IsSomething())
            {
                GameNodeAction Event = new GameNodeAction("New Event", ActionType.Event);

                GameNodeEvents gameNodeEvents = GetGameNodeEvents();
                GameNode gameNode = GetGameNode();
                GameNodeObjects gameNodeObjects = GetGameNodeObjects();
                GameNodeWorkspace gameNodeWorkspace = tv.Nodes[0] as GameNodeWorkspace;

                GameNode TargetParentNode = tv.SelectedNode as GameNode;
                // TODO find other nodes that are not valid.
                if (TargetParentNode == gameNode)
                {
                    TargetParentNode = gameNodeEvents;
                }

                if (TargetParentNode == gameNodeObjects)
                {
                    TargetParentNode = gameNodeEvents;
                }

                if (TargetParentNode == gameNodeWorkspace)
                {
                    TargetParentNode = gameNodeEvents;
                }

                // Need to make sure this isn't the 
                TargetParentNode.AddGameNode(Event, AddToTop);
                tv.SelectedNode = Event;

                SetPanel(PanelMode.PanelColorEvent);
                LoadPanelSingleColorAtSingleLocation(Event);
                //LoadParentScreenshotIfNecessary();
                cmdAddSingleColorAtSingleLocationTakeASceenshot.PerformClick();
                SaveClickList();
                ThreadManager.IncrementNewEventAdded();
            }
            else
            {
                Log("Unable to Add New Event due to no-node selected");
            }
        }

        private void mnuAddAction_Click(object sender, EventArgs e)
        {
            AddAction();
        }

        internal void AddAction(Boolean AddToTop = false)
        {
            GameNode OriginalNode = tv.SelectedNode as GameNode;
            GameNodeAction GameNodeAction = new GameNodeAction("Click " + tv.SelectedNode.Text, ActionType.Action);

            GameNodeAction.FromCurrentMousePos = GetGameNode().MoveMouseBeforeAction;

            OriginalNode.AddGameNode(GameNodeAction, AddToTop);
            tv.SelectedNode = GameNodeAction;

            // Initialize Children with Parent Defaults
            GameNodeGame Game = GameNodeAction.GetGameNodeGame();
            if (Game.IsSomething())
            {
                GameNodeAction.ClickSpeed = Game.DefaultClickSpeed;
                switch (Game.WindowAction)
                {
                    case WindowAction.DoNothing:
                        GameNodeAction.AppActivateIfNotActive = false;
                        break;
                    case WindowAction.ActivateWindow:
                        GameNodeAction.AppActivateIfNotActive = true;
                        break;
                    default:
                        break;
                }
                //
            }

            SetPanel(PanelMode.PanelColorEvent);

            LoadPanelSingleColorAtSingleLocation(GameNodeAction);
            cmdAddSingleColorAtSingleLocationTakeASceenshot.PerformClick();
            //LoadParentScreenshotIfNecessary();

            InitalizeOffsets();

            ThreadManager.IncrementNewActionAdded();
            SaveClickList();
        }

        private void mnuAddRNG_Click(object sender, EventArgs e)
        {
            AddRNGContainer();
        }

        private void AddRNGContainer()
        {
            GameNodeAction RNGContainer = new GameNodeAction("New RNG", ActionType.RNGContainer);
            RNGContainer.AutoBalance = true;
            GameNode gn = tv.SelectedNode as GameNode;
            gn.AddGameNode(RNGContainer);
            tv.SelectedNode = RNGContainer;

            //'  SetPanel(PanelMode.PanelColorEvent)
            //' LoadPanelSingleColorAtSingleLocation(RNGContainer)

            GameNodeAction GameNodeAction = new GameNodeAction("", ActionType.RNG);
            GameNodeAction.Percentage = 100;
            RNGContainer.AddGameNode(GameNodeAction);
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

        private void DisableEventNodesInTree(GameNode node)
        {
            foreach (GameNode gameNode in node.Nodes)
            {
                Debug.WriteLine(gameNode.GameNodeType);
                if (gameNode.GameNodeType == GameNodeType.Action)
                {
                    GameNodeAction Action = gameNode as GameNodeAction;
                    if (Action.ActionType == ActionType.Action)
                    {
                        Action.Enabled = false;
                        Action.Text = Action.Text + " - (Disabled)";
                        Action.ForeColor = Color.LightGray;
                    }
                }
                DisableEventNodesInTree(gameNode);
            }
        }

        private void TestAllEvents()
        {
            SetPanel(PanelMode.TestAllEvents);

            //'walk to Event//'s node
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();
            tvTestAllEvents.Nodes.Clear();
            GameNodeGame TestAllEventsGameNode = GameNode.CloneMe();

            DisableEventNodesInTree(TestAllEventsGameNode);

            tvTestAllEvents.Nodes.Add(TestAllEventsGameNode);
            tvTestAllEvents.ExpandAll();

            String TargetWindow = GameNode.TargetWindow;
            IntPtr MainWindowHandle = GameNode.GetWindowHandleByWindowName();

            if (MainWindowHandle.ToInt32() > 0)
            {
                Boolean Success = false;
                PictureTestAllTest.Image = Utils.GetBitmapFromWindowHandle(ref Success, MainWindowHandle);
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

            foreach (GameNodeEvents nodeEvents in tvTestAllEvents.Nodes[0].Nodes)
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

                EventSolution solution = Node.IsTrue(Bmp, GameNode);
                if (solution.Result)
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
                        int intDetectedThreashold = (DetectedThreashold * 100).ToInt();
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
                        int intDetectedThreashold = (DetectedThreashold * 100).ToInt();
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

            //' Hide the Make object button because the name is not long enough
            cmdMakeObject.Enabled = false;

            //' Hide the Make object and Use button because the name is not long enough
            cmdMakeObjectAndUse.Enabled = false;

            //' Reset the Rectangle in case it//'s already being used.
            PictureObjectScreenshotRectangle = new Rectangle();

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

                // Final result 
                Boolean FinalResult = false;

                dgvTestAllReference.Rows.Clear();
                dgvTest.Rows.Clear();


                if (Node.LogicChoice == "CUSTOM")
                {
                    lblTestAllCustom.Text = Node.CustomLogic;
                }

                EventSolution solution = new EventSolution();

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

                    if (Node.LogicChoice == "AND")
                    {
                        if (TargetColor.CompareColorWithPoints(Item.Color, Node.Points, solution))
                        {
                            if (FinalResult == false)
                            {
                                // do nothing
                            }
                        }
                        else
                        {
                            FinalResult = true;
                        }
                    }
                    else if (Node.LogicChoice == "OR")
                    {
                        if (TargetColor.CompareColorWithPoints(Item.Color, Node.Points, solution))
                        {
                            // do nothing
                        }
                    }
                    else
                    {
                        // Do nothing fancy, just show logic.
                        // Write Custom Logic
                        //Debug.Assert(false);
                    }

                    if (TargetColor.CompareColorWithPoints(Item.Color, Node.Points, solution))
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

                if (Node.Bitmap.IsNothing())
                {
                    Node.LoadBitmapFromDisk();
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
                String ApplicationName = frm.txtName.Text;
                Platform platform = frm.lblSelectedPlatform.Text.ParseEnum<Platform>();
                String AppID = frm.txtFinishAppID.Text;
                String BlueStacksBits = frm.cboBlueStacksVersion.Text;

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

                GameNodeGame Game = AddNewGameToTree(ApplicationName, TargetFileName, platform);
                cboPlatform.Text = platform.ToString();
                switch (platform)
                {
                    case Platform.NoxPlayer:
                        SetPackageNameControls(AppID);
                        Game.PackageName = AppID;
                        break;
                    case Platform.BlueStacks:
                        SetPackageNameControls(AppID);
                        Game.PackageName = AppID;
                        break;
                    case Platform.Steam:
                        break;
                    case Platform.Application:
                        break;
                    default:
                        break;
                }

                toolStripButtonSaveScript_Click(null, null);
                ThreadManager.IncrementNewAppAdded();
            }
        }

        private GameNodeGame AddNewGameToTree(string applicationName, string targetFileName, Platform platform)
        {
            GameNodeGame NewGame = new GameNodeGame(applicationName, ThreadManager);
            WorkspaceNode.IsLoading = true;
            WorkspaceNode.AddGameNode(NewGame);
            NewGame.IsLoading = true;
            NewGame.FileName = targetFileName;

            tv.SelectedNode = NewGame;

            GameNodeEvents Events = new GameNodeEvents("Events");
            NewGame.AddGameNode(Events);

            GameNodeObjects GameNodeObjects = new GameNodeObjects("Objects");
            NewGame.AddGameNode(GameNodeObjects);

            NewGame.IsLoading = false;
            WorkspaceNode.IsLoading = false;

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
                GameNodeGame Game = AddNewGameToTree(GameName, TargetFileName, platform);
                Game.Platform = platform;
                cboPlatform.Text = platform.ToString();

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

                    const Boolean LoadBitmaps = true;
                    GameNodeGame Game = GameNodeGame.LoadGame(doc.DocumentElement.SelectSingleNode("//App"), TargetFolder + @"\Default.xml", NewGameName, LoadBitmaps, ThreadManager);
                    Game.FileName = Utils.GetApplicationFolder() + @"\" + NewGameName + @"\Default.xml";

                    Game.GameNodeName = NewGameName;

                    XmlTextWriter Writer = new XmlTextWriter(Game.FileName, System.Text.Encoding.UTF8);
                    Writer.Formatting = Formatting.Indented;

                    Writer.WriteStartDocument();

                    Writer.WriteStartElement("AppTestStudio");  // Root.

                    Boolean UseMinimalSavingMethods = false;
                    Game.SaveGame(Writer, ThreadManager, tv, UseMinimalSavingMethods);
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
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction ActionNode = PanelLoadNode as GameNodeAction;
                    ActionNode.GameNodeName = txtEventName.Text;
                }
            }
            catch (Exception ex)
            {
                Log("txtEventName_TextChanged");
                Log(ex.Message);
            }
        }

        private void mnuThreadExit_Click(object sender, EventArgs e)
        {
            //if (ThreadManager.Game.IsSomething())
            //{
            //    Log("Stopping Thread ");
            //    ThreadManager.Game.Thread.Abort();
            //    ThreadManager.RemoveGame();
            //}

            String git = cboThreads.SelectedItem.ToString();
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

                    Game.RunThread.ShutDownThread();

                    break; // exit for
                }
            }

            if (GameFound.IsSomething())
            {
                ThreadManager.RemoveGame(GameFound);
                cboThreads.Items.Remove(git);
                Log("Stopping Thread -" + git);
            }
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
            try
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
            catch (Exception ex)
            {
                Log("PictureTestAllReference_Paint");
                Log(ex.Message);
            }
        }

        private void PictureTestAllTest_Paint(object sender, PaintEventArgs e)
        {
            GameNode Node = tvTestAllEvents.SelectedNode as GameNode;

            if (Node.IsSomething() && Node.GameNodeType == GameNodeType.Action)
            {
                GameNodeAction action = Node as GameNodeAction;
                if (action.IsColorPoint)
                {
                    Utils.DrawColorPoints(e, dgvTest, "dgvColorTest", "dgvXTest", "dgvYTest");
                }
                else
                {
                    if (action.Rectangle.IsEmpty)
                    {
                        action.Rectangle = new Rectangle(0, 0, PictureTestAllTest.Width, PictureTestAllTest.Height);
                    }
                    Utils.DrawMask(PictureTestAllTest, action.Rectangle, e);
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

                        Rectangle rectangle = new Rectangle();

                        // Add back 1/2 the mask to align the mask with the center detected coordinate.
                        rectangle.X = x - (action.ObjectSearchBitmap.Width / 2) + action.Rectangle.X;
                        rectangle.Y = y - (action.ObjectSearchBitmap.Height / 2) + action.Rectangle.Y;

                        // Width and height of object search image size.
                        rectangle.Width = action.ObjectSearchBitmap.Width;
                        rectangle.Height = action.ObjectSearchBitmap.Height;


                        Utils.DrawRectangleWithGuidesOnGraphics(e.Graphics, action.Bitmap, rectangle);

                    }
                }
                catch (Exception ex)
                {

                    Log(ex.Message);
                }
            }
        }

        Boolean ShuttingDown = false;

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ShuttingDown = true;
                if (PanelLoadNode.IsSomething())
                {
                    GameNodeGame gng = GetGameNode();
                    if (gng.IsAnythingDirty())
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
                                e.Cancel = true;
                                return;
                            case frmLoadCheck.LoadCheckResult.DefaultValue:
                                return;
                            default:
                                Debug.Assert(false);  //should not be here.
                                break;
                        }
                    }
                }

                UnsubscribeGlobalMouseKeyHook();
                Visible = false;
                Timer1.Enabled = false;
                foreach (GameNodeGame Game in ThreadManager.Games)
                {
                    Game.RunThread.ShutDownThread();
                }
                HistoryManager.Save();

                Thread.Sleep(100);

                // threads must be turned off off during saving.
                ThreadManager.Save();
            }
            catch (Exception ex)
            {
                // it is a known that this will exception if Terms of Use, cancel is clicked.  May not be worth adding wrappers to prevent.
                Debug.WriteLine(ex.Message);
            }
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
                SaveClickList();
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
                SaveClickList();
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
                SaveClickList();
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
                    GetGameNode().FlagAsDirty();
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


        private void cmdColorAtPointer_Click(object sender, EventArgs e)
        {
            if (panelRightColorAtPointer.Height == InitialPanelRightColorAtPointerHeight)
            {
                panelRightColorAtPointer.Height = cmdRightColorAtPointer.Height;
                cmdRightColorAtPointer.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightColorAtPointer.Height = InitialPanelRightColorAtPointerHeight;
                cmdRightColorAtPointer.ImageIndex = IconNames.DownChevron;
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
                cmdRightLimit.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightLimit.Height = InitialPanelRightLimitHeight;
                cmdRightLimit.ImageIndex = IconNames.DownChevron;
            }
        }

        private void cmdPanelOffset_Click(object sender, EventArgs e)
        {
            if (panelRightOffset.Height == InitialPanelRightOffsetHeight)
            {
                panelRightOffset.Height = cmdRightOffset.Height;
                cmdRightOffset.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightOffset.Height = InitialPanelRightOffsetHeight;
                cmdRightOffset.ImageIndex = IconNames.DownChevron;
            }
        }

        private void cmdRightDragMode_Click(object sender, EventArgs e)
        {
            if (panelRightDragMode.Height == InitialPanelRightDragModeHeight)
            {
                panelRightDragMode.Height = cmdRightDragMode.Height;
                cmdRightDragMode.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightDragMode.Height = InitialPanelRightDragModeHeight;
                cmdRightDragMode.ImageIndex = IconNames.DownChevron;
            }
        }

        private void cmdRightAfterCompletion_Click(object sender, EventArgs e)
        {
            if (panelRightAfterCompletion.Height == InitialPanelRightAfterCompletionHeight)
            {
                panelRightAfterCompletion.Height = cmdRightAfterCompletion.Height;
                cmdRightAfterCompletion.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightAfterCompletion.Height = InitialPanelRightAfterCompletionHeight;
                cmdRightAfterCompletion.ImageIndex = IconNames.DownChevron;
            }
        }

        private void cmdRightObject_Click(object sender, EventArgs e)
        {
            if (panelRightObject.Height == InitialPanelRightObjectHeight)
            {
                panelRightObject.Height = cmdRightObject.Height;
                cmdRightObject.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightObject.Height = InitialPanelRightObjectHeight;
                cmdRightObject.ImageIndex = IconNames.DownChevron;
            }
        }

        private void cmdRightLogic_Click(object sender, EventArgs e)
        {
            if (panelRightLogic.Height == InitialPanelRightLogicHeight)
            {
                panelRightLogic.Height = cmdRightLogic.Height;
                panelRightCustomLogic.Visible = false;
                panelRightPointGrid.Visible = false;
                cmdRightLogic.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightLogic.Height = InitialPanelRightLogicHeight;
                panelRightCustomLogic.Visible = true;
                panelRightPointGrid.Visible = true;
                cmdRightLogic.ImageIndex = IconNames.DownChevron;
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

                cmdRightLogic.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightClickProperties.Height = InitialPanelRightClickPropertiesHeight;

                cmdRightLogic.ImageIndex = IconNames.DownChevron;
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

                cmdRightLogic.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightSwipeProperties.Height = InitialPanelRightSwipePropertiesHeight;

                cmdRightLogic.ImageIndex = IconNames.DownChevron;
            }
        }

        private void numericSwipeStartHeight_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseStartHeight = numericSwipeStartHeight.Value.ToInt();
                PictureBox1.Invalidate();
            }
        }

        private void numericSwipeStartWidth_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseStartWidth = numericSwipeStartWidth.Value.ToInt();
                PictureBox1.Invalidate();
            }

        }

        private void numericSwipeEndHeight_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseEndHeight = numericSwipeEndHeight.Value.ToInt();
                PictureBox1.Invalidate();
            }

        }

        private void numericSwipeVelocity_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.ClickDragReleaseVelocity = numericSwipeVelocity.Value.ToInt();
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
                ActionNode.ClickDragReleaseEndWidth = numericSwipeEndWidth.Value.ToInt();
                PictureBox1.Invalidate();
            }
        }

        private void rdoAfterCompletionRecycle_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                RDOAfterCompletionChange();
            }
        }

        private void cboDPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeGame Game = tv.SelectedNode as GameNodeGame;
                if (Game.IsSomething())
                {
                    Game.DPI = Convert.ToInt32(cboDPI.Text);
                }
            }
        }

        private void cmdRightAnchor_Click(object sender, EventArgs e)
        {
            if (panelRightAnchor.Height == InitialPanelRightAnchorHeight)
            {
                panelRightAnchor.Height = cmdRightAnchor.Height;
                cmdRightAnchor.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightAnchor.Height = InitialPanelRightAnchorHeight;
                cmdRightAnchor.ImageIndex = IconNames.DownChevron;
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
            grpBlue.Visible = false;
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
                case "BlueStacks":
                    grpBlue.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void cboPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                toolStripInstances.Visible = false;
                toolStripCurrentDesignInstance.Visible = false;

                GameNodeGame GameNode = GetGameNode();
                if (GameNode.IsSomething())
                {
                    switch (cboPlatform.Text)
                    {
                        case "BlueStacks":
                            GameNode.Platform = Platform.BlueStacks;
                            cmdStartEmmulator.Text = "Start Emmulator";
                            cmdStartEmmulatorAndPackage.Text = "Start Emmulator + Run App";
                            cmdStartEmmulatorPackageAndRunScript.Text = "Start Emmulator + Run App + Run Script";
                            break;
                        case "NoxPlayer":
                            GameNode.Platform = Platform.NoxPlayer;
                            cmdStartEmmulator.Text = "Start Emmulator";
                            cmdStartEmmulatorAndPackage.Text = "Start Emmulator + Run App";
                            cmdStartEmmulatorPackageAndRunScript.Text = "Start Emmulator + Run App + Run Script";

                            // Show toolbar fast switch instances.
                            toolStripInstances.Visible = true;
                            toolStripCurrentDesignInstance.Visible = true;
                            break;
                        case "Application":
                            GameNode.Platform = Platform.Application;
                            cmdStartEmmulator.Text = "Start Application";
                            cmdStartEmmulatorAndPackage.Text = "Start Application + Run App";
                            cmdStartEmmulatorPackageAndRunScript.Text = "Start Application + Run App + Run Script";
                            toolStripButtonRunStartLaunch.Enabled = false;
                            toolStripButtonStartEmmulatorLaunchApp.Enabled = false;
                            break;
                        case "Steam":
                            GameNode.Platform = Platform.Steam;
                            cmdStartEmmulator.Text = "Start Steam Application";
                            cmdStartEmmulatorAndPackage.Text = "Start Steam + Run App";
                            cmdStartEmmulatorPackageAndRunScript.Text = "Start Steam + Run App + Run Script";
                            toolStripButtonRunStartLaunch.Enabled = false;
                            toolStripButtonStartEmmulatorLaunchApp.Enabled = false;
                            break;
                        default:
                            GameNode.Platform = Platform.NoxPlayer;
                            Debug.Assert(false);
                            break;
                    }
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
                GameNode.ApplicationPrimaryWindowName = txtApplicationPrimaryWindowName.Text.Trim();
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
                GameNode.SteamPrimaryWindowName = txtSteamPrimaryWindowName.Text.Trim();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void cmdPathToExePicker_Click(object sender, EventArgs e)
        {
            DialogResult Result = dlgApplicationPicker.ShowDialog();
            if (Result == DialogResult.OK)
            {
                txtPathToApplicationExe.Text = dlgApplicationPicker.FileName;
            }
        }

        private void txtGamePanelLoopDelay_TextChanged_1(object sender, EventArgs e)
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



        Boolean panelRightPropertiesOriginalVisible;
        Boolean panelRightAfterCompletionOriginalVisible;
        Boolean panelRightObjectOriginalVisible;
        Boolean panelRightSwipePropertiesOriginalVisible;
        Boolean panelRightClickPropertiesOriginalVisible;
        Boolean panelRightLogicOriginalVisible;
        Boolean panelRightCustomLogicOriginalVisible;
        Boolean panelRightPointGridOriginalVisible;

        int FlowLayoutPanelColorEvent1OriginWidth = 0;
        private void cmdFlowLayoutPanelColorEvent1_Click(object sender, EventArgs e)
        {
            if (FlowLayoutPanelColorEvent1OriginWidth == 0)
            {
                FlowLayoutPanelColorEvent1OriginWidth = cmdFlowLayoutPanelColorEvent1.Width;
            }
            //this.tableColorEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            //this.tableColorEvent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            if (cmdFlowLayoutPanelColorEvent1.Text == "<<  ")
            {
                panelRightPropertiesOriginalVisible = panelRightProperties.Visible;
                panelRightAfterCompletionOriginalVisible = panelRightAfterCompletion.Visible;
                panelRightObjectOriginalVisible = panelRightObject.Visible;
                panelRightSwipePropertiesOriginalVisible = panelRightSwipeProperties.Visible;
                panelRightClickPropertiesOriginalVisible = panelRightClickProperties.Visible;
                panelRightLogicOriginalVisible = panelRightLogic.Visible;
                panelRightCustomLogicOriginalVisible = panelRightCustomLogic.Visible;
                panelRightPointGridOriginalVisible = panelRightPointGrid.Visible;

                // Hide section
                cmdFlowLayoutPanelColorEvent1.Text = ">>  ";
                cmdFlowLayoutPanelColorEvent1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                tableColorEvent.ColumnStyles[1].Width = 30;

                panelRightProperties.Visible = false;
                panelRightAfterCompletion.Visible = false;
                panelRightObject.Visible = false;
                panelRightSwipeProperties.Visible = false;
                panelRightClickProperties.Visible = false;
                panelRightLogic.Visible = false;
                panelRightCustomLogic.Visible = false;
                panelRightPointGrid.Visible = false;

            }
            else
            {
                // Show section
                cmdFlowLayoutPanelColorEvent1.Text = "<<  ";
                cmdFlowLayoutPanelColorEvent1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                tableColorEvent.ColumnStyles[1].Width = FlowLayoutPanelColorEvent1OriginWidth;

                panelRightProperties.Visible = panelRightPropertiesOriginalVisible;
                panelRightAfterCompletion.Visible = panelRightAfterCompletionOriginalVisible;
                panelRightObject.Visible = panelRightObjectOriginalVisible;
                panelRightSwipeProperties.Visible = panelRightSwipePropertiesOriginalVisible;
                panelRightClickProperties.Visible = panelRightClickPropertiesOriginalVisible;
                panelRightLogic.Visible = panelRightLogicOriginalVisible;
                panelRightCustomLogic.Visible = panelRightCustomLogicOriginalVisible;
                panelRightPointGrid.Visible = panelRightPointGridOriginalVisible;
            }
        }


        Boolean panelRightColorAtPointerOriginalVisible;
        Boolean panelRightLimitOriginalVisible;
        Boolean panelRightAnchorOriginalVisible;
        Boolean panelRightOffsetOriginalVisible;
        Boolean panelRightDragModeOriginalVisible;
        int FlowLayoutPanelColorEvent2OriginWidth = 0;
        private void cmdFlowLayoutPanelColorEvent2_Click(object sender, EventArgs e)
        {
            try
            {



                if (FlowLayoutPanelColorEvent2OriginWidth == 0)
                {
                    FlowLayoutPanelColorEvent2OriginWidth = cmdFlowLayoutPanelColorEvent2.Width;
                }
                // Original Size is 300 first, 290 second.
                if (cmdFlowLayoutPanelColorEvent2.Text == "<<  ")
                {
                    // Hide section
                    panelRightColorAtPointerOriginalVisible = panelRightColorAtPointer.Visible;
                    panelRightLimitOriginalVisible = panelRightLimit.Visible;
                    panelRightAnchorOriginalVisible = panelRightAnchor.Visible;
                    panelRightOffsetOriginalVisible = panelRightOffset.Visible;
                    panelRightDragModeOriginalVisible = panelRightDragMode.Visible;

                    cmdFlowLayoutPanelColorEvent2.Text = ">>  ";
                    cmdFlowLayoutPanelColorEvent2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    // Third column
                    tableColorEvent.ColumnStyles[2].Width = 30;

                    panelRightColorAtPointer.Visible = false;
                    panelRightLimit.Visible = false;
                    panelRightAnchor.Visible = false;
                    panelRightOffset.Visible = false;
                    panelRightDragMode.Visible = false;
                }
                else
                {
                    cmdFlowLayoutPanelColorEvent2.Text = "<<  ";
                    cmdFlowLayoutPanelColorEvent2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                    tableColorEvent.ColumnStyles[2].Width = FlowLayoutPanelColorEvent2OriginWidth;

                    panelRightColorAtPointer.Visible = panelRightColorAtPointerOriginalVisible;
                    panelRightLimit.Visible = panelRightLimitOriginalVisible;
                    panelRightAnchor.Visible = panelRightAnchorOriginalVisible;
                    panelRightOffset.Visible = panelRightOffsetOriginalVisible;
                    panelRightDragMode.Visible = panelRightDragModeOriginalVisible;
                }
            }
            catch (Exception ex)
            {
                Log("cmdFlowLayoutPanelColorEvent2_Click:" + ex.Message);
            }
        }

        private void txtSteamSecondaryWindowName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.SteamSecondaryWindowName = txtSteamSecondaryWindowName.Text.Trim();
            }
            catch (Exception ex)
            {
                Log("txtSteamSecondaryWindowName_TextChanged:" + ex.Message);
            }
        }

        private void txtApplicationSecondaryWindowName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.ApplicationSecondaryWindowName = txtApplicationSecondaryWindowName.Text.Trim();
            }
            catch (Exception ex)
            {
                Log("txtApplicationSecondaryWindowName_TextChanged:" + ex.Message);
            }
        }

        private void cboApplicationPrimaryWindowNameFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;

                WindowNameFilterType FilterType = Utils.GetEnumTypeFromFilterName(cboApplicationPrimaryWindowNameFilter.Text);

                GameNode.ApplicationPrimaryWindowFilter = FilterType;
            }
            catch (Exception ex)
            {
                Log("cboApplicationPrimaryWindowNameFilter_SelectedIndexChanged:" + ex.Message);
            }
        }

        private void cboApplicationSecondaryWindowNameFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;

                WindowNameFilterType FilterType = Utils.GetEnumTypeFromFilterName(cboApplicationSecondaryWindowNameFilter.Text);

                GameNode.ApplicationSecondaryWindowFilter = FilterType;
            }
            catch (Exception ex)
            {
                Log("cboApplicationSecondaryWindowNameFilter_SelectedIndexChanged:" + ex.Message);
            }
        }

        private void cboSteamPrimaryWindowNameFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;

                WindowNameFilterType FilterType = Utils.GetEnumTypeFromFilterName(cboSteamPrimaryWindowNameFilter.Text);

                GameNode.SteamPrimaryWindowFilter = FilterType;
            }
            catch (Exception ex)
            {
                Log("cboSteamPrimaryWindowNameFilter_SelectedIndexChanged:" + ex.Message);
            }
        }

        private void cboSteamSecondaryWindowNameFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;

                WindowNameFilterType FilterType = Utils.GetEnumTypeFromFilterName(cboSteamSecondaryWindowNameFilter.Text);

                GameNode.SteamSecondaryWindowFilter = FilterType;
            }
            catch (Exception ex)
            {
                Log("cboSteamSecondaryWindowNameFilter_SelectedIndexChanged:" + ex.Message);
            }
        }

        private void cmdSteamWindowWizard_Click(object sender, EventArgs e)
        {
            try
            {
                frmWindowWizard WindowWizard = new frmWindowWizard(txtSteamPrimaryWindowName.Text, txtSteamSecondaryWindowName.Text, cboSteamPrimaryWindowNameFilter.Text, cboSteamSecondaryWindowNameFilter.Text);
                WindowWizard.StartPosition = FormStartPosition.CenterParent;
                WindowWizard.ShowDialog();

                if (WindowWizard.UseValues)
                {
                    txtSteamPrimaryWindowName.Text = WindowWizard.lblChangePrimaryWindowName.Text;
                    txtSteamSecondaryWindowName.Text = WindowWizard.lblChangeSecondaryWindowName.Text;
                    cboSteamPrimaryWindowNameFilter.Text = WindowWizard.lblChangePrimaryWindowFilter.Text;
                    cboSteamSecondaryWindowNameFilter.Text = WindowWizard.lblChangeSecondaryWindowFilter.Text;
                }
            }
            catch (Exception ex)
            {
                Log("cmdSteamWindowWizard_Click:" + ex.Message);
            }
        }

        private void cmdApplicationWindowWizard_Click(object sender, EventArgs e)
        {
            try
            {
                frmWindowWizard WindowWizard = new frmWindowWizard(txtApplicationPrimaryWindowName.Text, txtApplicationSecondaryWindowName.Text, cboApplicationPrimaryWindowNameFilter.Text, cboApplicationSecondaryWindowNameFilter.Text);
                WindowWizard.StartPosition = FormStartPosition.CenterParent;
                WindowWizard.ShowDialog();

                if (WindowWizard.UseValues)
                {
                    txtApplicationPrimaryWindowName.Text = WindowWizard.lblChangePrimaryWindowName.Text;
                    txtApplicationSecondaryWindowName.Text = WindowWizard.lblChangeSecondaryWindowName.Text;
                    cboApplicationPrimaryWindowNameFilter.Text = WindowWizard.lblChangePrimaryWindowFilter.Text;
                    cboApplicationSecondaryWindowNameFilter.Text = WindowWizard.lblChangeSecondaryWindowFilter.Text;
                }
            }
            catch (Exception ex)
            {
                Log("cmdApplicationWindowWizard_Click:" + ex.Message);
            }
        }

        private void cmdMakeObjectAndUse_Click(object sender, EventArgs e)
        {
            try
            {
                MakeObject();

                // if this was called from create object button on event form.
                if (LastNodeAddObjectWasUsedFrom.IsSomething())
                {
                    // set the Node
                    tv.SelectedNode = LastNodeAddObjectWasUsedFrom;

                    // Set Object Search if it's not already est.
                    if (rdoObjectSearch.Checked == false)
                    {
                        rdoObjectSearch.Checked = true;
                    }

                    // Set Node in Ojbect Search 
                    cboObject.Text = txtObjectScreenshotName.Text;

                    LastNodeAddObjectWasUsedFrom.Text = "Find " + txtObjectScreenshotName.Text;
                    txtEventName.Text = LastNodeAddObjectWasUsedFrom.Text;

                    // Add Child Click Event the size of the origin picture.
                    GameNodeAction ClickEvent = new GameNodeAction("Click " + txtObjectScreenshotName.Text, ActionType.Action);
                    ClickEvent.Bitmap = LastNodeAddObjectWasUsedFrom.Bitmap.CloneMe();
                    ClickEvent.ResolutionHeight = LastNodeAddObjectWasUsedFrom.ResolutionHeight;
                    ClickEvent.ResolutionWidth = LastNodeAddObjectWasUsedFrom.ResolutionWidth;
                    ClickEvent.Rectangle = PictureObjectScreenshotRectangle;
                    GameNode gn = tv.SelectedNode as GameNode;
                    gn.AddGameNode(ClickEvent);

                    // Clear out so that going back to make object will not be available.
                    LastNodeAddObjectWasUsedFrom = null;
                }
            }
            catch (Exception ex)
            {
                Log("cmdMakeObjectAndUse_Click:" + ex.Message);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuLaunchWizard();
            }
            catch (Exception ex)
            {
                Log("newToolStripMenuItem_Click:" + ex.Message);
            }
        }

        private void txtBluePackageName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame Game = tv.SelectedNode as GameNodeGame;
                if (Game.IsSomething())
                {
                    Game.PackageName = txtBluePackageName.Text.Trim();
                    if (Game.PackageName.Length > 0)
                    {
                        toolStripButtonRunStartLaunch.Enabled = true;
                        toolStripButtonStartEmmulatorLaunchApp.Enabled = true;
                    }
                    else
                    {
                        toolStripButtonRunStartLaunch.Enabled = false;
                        toolStripButtonStartEmmulatorLaunchApp.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log("txtBluePackageName_TextChanged:" + ex.Message);
            }
        }

        private void cboBlueInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame Game = tv.SelectedNode as GameNodeGame;
                if (Game.IsSomething())
                {
                    foreach (BlueGuest Guest in BlueRegistry.GuestList)
                    {
                        if (cboBlueInstance.Text == Guest.BitDashDisplayName)
                        {
                            Game.BlueGuest = Guest.CloneMe();
                            Game.BlueStacksWindowName = Guest.DisplayName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("cboBlueInstance_SelectedIndexChanged:" + ex.Message);
            }
        }

        private IKeyboardMouseEvents GlobalMouseKeyHook;

        public void SubscribeGlobalMouseKeyHook()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            GlobalMouseKeyHook = Hook.GlobalEvents();

            // GlobalMouseKeyHook.MouseDownExt += GlobalHookMouseDownExt;
            GlobalMouseKeyHook.KeyDown += GlobalMouseKeyHook_KeyDown;
        }



        Boolean IsNotifying = false;

        frmNotify frmNotify;
        private void GlobalMouseKeyHook_KeyDown(object sender, KeyEventArgs e)
        {
            //Debug.WriteLine($"GlobalMouseKeyHook_KeyDown: {e.KeyCode},{e.SuppressKeyPress},{e.KeyData}");
            try
            {
                // Not sure why this fires true for F5 sometimes.
                if (e.KeyData.HasFlag(Keys.Control | Keys.Shift | Keys.Alt | Keys.F1))
                {
                    try
                    {
                        String KeyDatavalue = e.KeyData.ToString();
                        if (KeyDatavalue.Contains("F1"))
                        {
                            AddNewEvent();
                            tabDesign.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        Log("GlobalMouseKeyHook_KeyDown F1:" + ex.Message);
                    }
                    e.Handled = true;
                }
                if (e.KeyData.HasFlag(Keys.Control | Keys.Shift | Keys.Alt | Keys.Escape))
                {
                    Log("The Claw[Ctrl+Alt+Shift] + Escape - Pressed");
                    e.Handled = true;

                    Boolean RunningThreadDetected = false;

                    foreach (GameNodeGame game in ThreadManager.Games)
                    {
                        if (game.IsPaused == false)
                        {
                            RunningThreadDetected = true;

                            // if any thread is running then pause them all
                            SetThreadPauseState(true);

                            // since we paused all threads we can stop checking.
                        }
                    }


                    if (RunningThreadDetected)
                    {
                        // We aren't already notifying.
                        if (IsNotifying == false)
                        {
                            // prevent reentry until completed
                            IsNotifying = true;

                            // show a center screen popup to notify that we shutdown.
                            frmNotify = new frmNotify(3000);
                            frmNotify.LetsQuit += FrmNotify_LetsQuit;

                            Utils.ShowInactiveTopmostFormCenterScreen(frmNotify);
                        }
                    }
                    else
                    {
                        Log("There was not any threads that were running.");
                    }
                }

                if (e.KeyData.HasFlag(Keys.Control | Keys.Shift | Keys.Alt | Keys.F5))
                {
                    Log("The Claw[Ctrl+Alt+Shift] + F5 - Pressed");
                    e.Handled = true;

                    Boolean IsThereAnyThreadsRunning = false;
                    foreach (GameNodeGame game in ThreadManager.Games)
                    {
                        if (game.IsSomething())
                        {
                            if (game.IsPaused == false)
                            {
                                IsThereAnyThreadsRunning = true;
                            }

                            if (IsThereAnyThreadsRunning)
                            {
                                // Pause all threads
                                SetThreadPauseState(true);
                            }
                            else
                            {
                                // Resume all threads
                                SetThreadPauseState(false);
                            }
                        }
                        else
                        {
                            Log("There were not any running scripts.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("GlobalMouseKeyHook_KeyDown:" + ex.Message);
            }
        }

        private void FrmNotify_LetsQuit(object sender, EventArgs e)
        {
            try
            {
                frmNotify.Dispose();
                frmNotify = null;
                IsNotifying = false;
            }
            catch (Exception ex)
            {
                Log("FrmNotify_LetsQuit:" + ex.Message);
            }
        }
        private void Notify_threadDone(object sender, EventArgs e)
        {
            IsNotifying = false;
            Debug.WriteLine("Notify_threadDone");
        }

        //private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        //{
        //    Debug.WriteLine("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);

        //    // uncommenting the following line will suppress the middle mouse button click
        //    // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
        //}

        public void UnsubscribeGlobalMouseKeyHook()
        {
            //GlobalMouseKeyHook.MouseDownExt -= GlobalHookMouseDownExt;
            //GlobalMouseKeyHook.KeyPress -= GlobalMouseKeyHook_KeyPress;
            GlobalMouseKeyHook.KeyDown -= GlobalMouseKeyHook_KeyDown;
            //GlobalMouseKeyHook.KeyUp += GlobalMouseKeyHook_KeyUp;

            //It is recommened to dispose it
            GlobalMouseKeyHook.Dispose();
        }

        private void cboClickMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                switch (cboMouseMode.Text)
                {
                    case "Active":
                        GameNode.MouseMode = MouseMode.Active;
                        break;
                    case "Passive":
                        GameNode.MouseMode = MouseMode.Passive;
                        break;
                    default:
                        GameNode.MouseMode = MouseMode.Passive;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }

            switch (cboMouseMode.Text)
            {
                case "Active":
                    lblWindowNotVisibleAction.Visible = true;
                    break;
                case "Passive":
                    lblWindowNotVisibleAction.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void numericMouseSpeedPixelsPerSecond_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeGame Node = tv.SelectedNode as GameNodeGame;
                Node.MouseSpeedPixelsPerSecond = numericMouseSpeedPixelsPerSecond.Value.ToInt();
            }
        }

        private void numericMouseSpeedVelocityVariantPercentMax_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeGame Node = tv.SelectedNode as GameNodeGame;
                Node.MouseSpeedVelocityVariantPercentMax = numericMouseSpeedVelocityVariantPercentMax.Value.ToInt();
            }
        }

        private void numericMouseSpeedVelocityVariantPercentMin_ValueChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeGame Node = tv.SelectedNode as GameNodeGame;
                Node.MouseSpeedVelocityVariantPercentMin = numericMouseSpeedVelocityVariantPercentMin.Value.ToInt();
            }
        }

        private void cboWindowAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeGame Node = tv.SelectedNode as GameNodeGame;
                switch (cboWindowAction.Text)
                {
                    case "DoNothing":
                        Node.WindowAction = WindowAction.DoNothing;
                        break;
                    case "ActivateWindow":
                        Node.WindowAction = WindowAction.ActivateWindow;
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
        }

        private void chkMoveMouseBeforeAction_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeGame Node = tv.SelectedNode as GameNodeGame;
                Node.MoveMouseBeforeAction = chkMoveMouseBeforeAction.Checked;
            }
        }

        /// <summary>
        /// Minimizes/shows the right information panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRightInformation_Click(object sender, EventArgs e)
        {
            if (panelRightInformation.Height == InitialPanelRightInformationHeight)
            {
                panelRightInformation.Height = cmdRightInformation.Height;

                cmdRightInformation.ImageIndex = IconNames.LeftChevron;
            }
            else
            {
                panelRightInformation.Height = InitialPanelRightInformationHeight;

                cmdRightInformation.ImageIndex = IconNames.DownChevron;
            }
        }

        private void tv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Down)
                {
                    GameNode Node = tv.SelectedNode as GameNode;
                    if (Node.IsSomething())
                    {
                        switch (Node.GameNodeType)
                        {
                            case GameNodeType.Workspace:
                                break;
                            case GameNodeType.Games:
                                break;
                            case GameNodeType.Game:
                                break;
                            case GameNodeType.Events:
                                break;
                            case GameNodeType.Action:
                                if (Node.NextNode.IsSomething())
                                {
                                    Node.MoveDown();
                                    tv.SelectedNode = Node;
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
                    }

                }

                if (e.KeyCode == Keys.Up)
                {
                    GameNode Node = tv.SelectedNode as GameNode;
                    if (Node.IsSomething())
                    {
                        switch (Node.GameNodeType)
                        {
                            case GameNodeType.Workspace:
                                break;
                            case GameNodeType.Games:
                                break;
                            case GameNodeType.Game:
                                break;
                            case GameNodeType.Events:
                                break;
                            case GameNodeType.Action:
                                if (Node.PrevNode.IsSomething())
                                {
                                    Node.MoveUp();
                                    tv.SelectedNode = Node;
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
                    }
                }
            }
        }

        private void chkFromCurrentMousePos_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                GameNodeAction GameNode = tv.SelectedNode as GameNodeAction;
                GameNode.FromCurrentMousePos = chkFromCurrentMousePos.Checked;
            }
        }

        private void tvRun_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                GameNode Node = e.Node as GameNode;
                if (Node.IsNothing())
                {
                    return;
                }

                if (lblRunLabel1.Text == lblRunLabel1.Name)
                {
                    InitializeRunLabels();
                }
                // Done to reduce flickering.
                String RT1 = Node.Name;
                String RT2 = Node.GameNodeType.ToString();
                String RT3 = "";
                String RT4 = "True";
                String RT5 = "";
                String RT6 = "";
                String RT7 = "";
                String RT8 = "";
                String RT9 = "";
                String RT10 = "";
                String RT11 = "";


                switch (Node.GameNodeType)
                {
                    case GameNodeType.Workspace:
                        break;
                    case GameNodeType.Games:
                        break;
                    case GameNodeType.Game:
                        break;
                    case GameNodeType.Events:
                        break;
                    case GameNodeType.Action:
                        GameNodeAction Action = e.Node as GameNodeAction;

                        RT4 = Action.Enabled.ToString();

                        RT3 = Action.ActionType.ToString();

                        RT5 = Action.RuntimeActionCount.ToString();

                        RT6 = Action.IsLimited.ToString();

                        RT8 = Action.ResolutionWidth + "x" + Action.ResolutionHeight;

                        RT11 = Action.CalculateDelayInMS() + "ms";

                        if (Action.IsLimited)
                        {
                            RT7 = Action.WaitType.ToString();

                            if (Action.LimitRepeats)
                            {
                                RT7 = lblRunValue7.Text + " (Repeats)";
                            }

                            switch (Action.WaitType)
                            {
                                case WaitType.Iteration:
                                    RT9 = Action.RuntimeIterationsLeft.ToString();
                                    break;
                                case WaitType.Time:
                                    RT9 = Action.RuntimeNextAllowedTime.ToString();
                                    break;
                                case WaitType.Session:
                                    RT9 = Action.RuntimeOncePerSession.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }

                        switch (Action.ActionType)
                        {
                            case AppTestStudio.ActionType.RNGContainer:
                                break;
                            case ActionType.RNG:
                                break;
                            case ActionType.Event:
                                RT2 = "Event";
                                if (Action.IsColorPoint)
                                {
                                    if (Action.ClickList.Count == 0)
                                    {
                                        RT3 = "Group";
                                    }
                                    else
                                    {
                                        RT3 = "Color Point";
                                    }

                                }
                                else
                                {
                                    RT3 = "Object Search";
                                }
                                break;
                            case ActionType.Action:

                                if (Action.IsParentObjectSearch())
                                {
                                    if (Action.Mode == Mode.ClickDragRelease)
                                    {

                                    }
                                }

                                switch (Action.Mode)
                                {
                                    case Mode.RangeClick:
                                        RT3 = RT3 + " " + Mode.RangeClick.ToString();
                                        break;
                                    case Mode.ClickDragRelease:
                                        RT3 = RT3 + " " + Mode.ClickDragRelease.ToString();
                                        if (Action.IsParentObjectSearch())
                                        {

                                        }
                                        else
                                        {

                                        }
                                        break;
                                    case Mode.MouseMove:
                                        RT3 = RT3 + " " + Mode.MouseMove.ToString();
                                        break;
                                    case Mode.Keyboard:
                                        RT3 = RT3 + " " + Mode.Keyboard.ToString();
                                        break;
                                    default:
                                        // do nothing
                                        break;
                                }

                                break;
                            default:
                                break;
                        }

                        switch (Action.AfterCompletionType)
                        {
                            case AfterCompletionType.Continue:
                                RT10 = "Continue";
                                break;
                            case AfterCompletionType.Home:
                                RT10 = "Home";
                                break;
                            case AfterCompletionType.Parent:
                                RT10 = "Parent";
                                break;
                            case AfterCompletionType.Stop:
                                RT10 = "Stop";
                                break;
                            case AfterCompletionType.ContinueProcess:
                                RT10 = "ContinueProcess";
                                break;
                            case AfterCompletionType.Recycle:
                                RT10 = "Recycle";
                                break;
                            default:
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
                        Debug.Assert(false);
                        break;
                }
                //https://stackoverflow.com/questions/3816362/winforms-label-flickering
                lblRunValue1.Text = RT1;
                lblRunValue2.Text = RT2;
                lblRunValue3.Text = RT3;
                lblRunValue4.Text = RT4;
                lblRunValue5.Text = RT5;
                lblRunValue6.Text = RT6;
                lblRunValue7.Text = RT7;
                lblRunValue8.Text = RT8;
                lblRunValue9.Text = RT9;
                lblRunValue10.Text = RT10;
                lblRunValue11.Text = RT11;

                //lblRunValue12.Text = RT12;
                //lblRunValue13.Text = RT13;
                //lblRunValue14.text = RT14;
            }
            catch (Exception ex)
            {
                Log("tvRun_AfterSelect");
                Log(ex.Message);
            }
        }

        private void InitializeRunLabels()
        {
            lblRunLabel1.Text = "Name";
            lblRunLabel2.Text = "Node Type";
            lblRunLabel3.Text = "Node Sub Type";
            lblRunLabel4.Text = "Enabled";
            lblRunLabel5.Text = "Activity Count";
            lblRunLabel6.Text = "Is Limited";
            lblRunLabel7.Text = "Wait Type";
            lblRunLabel8.Text = "Resolution";
            lblRunLabel9.Text = "Limit Control";
            lblRunLabel10.Text = "After Completion";
            lblRunLabel11.Text = "After Delay";
            lblRunLabel12.Text = "";
            lblRunLabel13.Text = "";
            lblRunLabel14.Text = "";

            lblRunValue1.Text = "";
            lblRunValue2.Text = "";
            lblRunValue3.Text = "";
            lblRunValue4.Text = "";
            lblRunValue5.Text = "";
            lblRunValue6.Text = "";
            lblRunValue7.Text = "";
            lblRunValue8.Text = "";
            lblRunValue9.Text = "";
            lblRunValue10.Text = "";
            lblRunValue11.Text = "";
            lblRunValue12.Text = "";
            lblRunValue13.Text = "";
            lblRunValue14.Text = "";

        }

        private void toolStripMenuItemResetResolution_Click(object sender, EventArgs e)
        {
            try
            {

                GameNode gameNode = tvRun.SelectedNode as GameNode;
                if (gameNode.IsSomething())
                {
                    GameNodeAction gameNodeAction = gameNode as GameNodeAction;

                    GameNodeGame game = gameNode.GetGameNodeGame();

                    IntPtr MainWindowHandle = game.GetWindowHandleByWindowName();

                    if (MainWindowHandle.ToInt32() == 0)
                    {
                        Log("Reset Resolution: Unable to find Window");
                        return;
                    }

                    if (gameNodeAction.ResolutionHeight <= 0 || gameNodeAction.ResolutionWidth <= 0)
                    {
                        Log("Reset Resolution: Height or width is invalid: " + gameNodeAction.ResolutionWidth + "x" + gameNodeAction.ResolutionHeight);
                    }

                    Log("Attempting to resize window to " + gameNodeAction.ResolutionWidth + "x" + gameNodeAction.ResolutionHeight);
                    NativeMethods.MoveWindow(MainWindowHandle, 0, 0, gameNodeAction.ResolutionWidth, gameNodeAction.ResolutionHeight, true);
                }
            }
            catch (Exception ex)
            {
                Log("toolStripMenuItemResetResolution_Click");
                Log(ex.Message.ToString());
            }
        }

        private void cmdUpdateResolution_Click(object sender, EventArgs e)
        {
            try
            {
                // if there is some resolution in the box.
                if (lblRunValue8.Text.Contains("x"))
                {
                    Point point = cmdUpdateResolution.PointToClient(Cursor.Position);
                    contextMenuStripResetResolution.Show(cmdUpdateResolution, point.X, point.Y);
                }
            }
            catch (Exception ex)
            {
                Log("cmdUpdateResolution_Click");
                Log(ex.Message);
            }
        }

        private void cmdRuntimeEnableToggle_Click(object sender, EventArgs e)
        {
            try
            {
                Point point = cmdRuntimeEnableToggle.PointToClient(Cursor.Position);
                GameNodeAction Action = GetCurrentSelectedRunTreeActionNode();
                if (Action.IsSomething())
                {
                    toolStripMenuItemRuntimeEnableDisableToggle.Text = "Change to " + !Action.Enabled + "?";
                    contextMenuStripRuntimeEnableDisable.Show(cmdRuntimeEnableToggle, point.X, point.Y);
                }
                else
                {
                    Log("Unable to locate runtime Action Node");
                }
            }
            catch (Exception ex)
            {
                Log("cmdRuntimeEnableToggle_Click");
                Log(ex.Message);
            }
        }

        private GameNodeAction GetCurrentSelectedRunTreeActionNode()
        {
            GameNode Node = tvRun.SelectedNode as GameNode;
            if (Node.IsNothing())
            {
                return null;
            }

            switch (Node.GameNodeType)
            {
                case GameNodeType.Workspace:
                    break;
                case GameNodeType.Games:
                    break;
                case GameNodeType.Game:
                    break;
                case GameNodeType.Events:
                    break;
                case GameNodeType.Action:
                    GameNodeAction Action = Node as GameNodeAction;
                    if (Action.IsNothing())
                    {
                        return null;
                    }

                    return Action;
                default:
                    break;
            }
            return null;
        }

        private void toolStripMenuItemRuntimeEnableDisableToggle_Click(object sender, EventArgs e)
        {
            try
            {
                GameNodeAction Action = GetCurrentSelectedRunTreeActionNode();
                if (Action.IsSomething())
                {
                    // Toggle Event.
                    Action.Enabled = !Action.Enabled;

                    // Reset the menu
                    TreeViewEventArgs tvea = new TreeViewEventArgs(Action as TreeNode);
                    tvRun_AfterSelect(this, tvea);
                }
            }
            catch (Exception ex)
            {
                Log("toolStripMenuItemRuntimeEnableDisableToggle_Click");
                Log(ex.Message);
            }
        }

        static long LastClickCount = 0;

        private void TimerProperties_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tvRun.SelectedNode.IsSomething())
                {
                    TreeViewEventArgs tvea = new TreeViewEventArgs(tvRun.SelectedNode);
                    tvRun_AfterSelect(null, tvea);
                }

                // Force redraw
                atsGraph1.Queue.Add(this.ThreadManager.DequeueProcessingTime());
                atsGraph1.Invalidate();

                long TickCoundDifference = this.ThreadManager.ClickCount - LastClickCount;
                LastClickCount = this.ThreadManager.ClickCount;
                atsGraphActions1.Queue.Add(TickCoundDifference);
                atsGraphActions1.Invalidate();
            }
            catch (Exception ex)
            {
                Log("TimerProperties_Tick");
                Log(ex.Message);
            }
        }

        private void aboutAppTestStudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAbout f = new frmAbout();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Log("aboutAppTestStudioToolStripMenuItem_Click");
                Log(ex.Message);
            }
        }

        private void RefreshThreadList()
        {
            cboThreads.Items.Clear();
            foreach (GameNodeGame Game in ThreadManager.Games)
            {
                cboThreads.Items.Add(Game.ThreadandWindowName);
                toolStripButtonToggleScript.Enabled = true;
            }
            cboThreads_SelectedIndexChanged(null, null);
        }

        private void cboThreads_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("cboThreads_SelectedIndexChanged");

            try
            {
                if (ThreadManager.Games.Count == 0)
                {
                    tvRun.Nodes.Clear();
                    InitializeRunLabels();
                }
                foreach (GameNodeGame Game in ThreadManager.Games)
                {
                    if (cboThreads.Text == Game.ThreadandWindowName)
                    {
                        tvRun.Nodes.Clear();

                        // Copy the Runtime tree to the tvRun tab.
                        tvRun.Nodes.Add(Game as TreeNode);
                        tvRun.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Clearing Run Nodes Tree View.");
                tvRun.Nodes.Clear();
                Log("cboThreads_SelectedIndexChanged");
                Log(ex.Message);
            }
        }

        private void txtApplicationParameters_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
                GameNode.ApplicationParameters = txtApplicationParameters.Text.Trim();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void rdoModeMove_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction ActionNode = PanelLoadNode as GameNodeAction;

                    if (rdoModeMove.Checked)
                    {
                        ActionNode.Mode = Mode.MouseMove;

                        panelRightSwipeProperties.Visible = true;
                        panelRightClickProperties.Visible = false;
                        panelKeyboard.Visible = false;
                        PictureBox1.Visible = true;

                        if (PanelLoadNode.ActionType == ActionType.Action)
                        {
                            chkFromCurrentMousePos.Visible = true;
                        }

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

                        String EventName = txtEventName.Text;
                        if (EventName.StartsWith("Swipe "))
                        {
                            // Remove 'Swipe' add Move
                            txtEventName.Text = $"Move {txtEventName.Text.Substring(6, txtEventName.Text.Length - 6)}";
                        }
                        if (EventName.StartsWith("Keyboard "))
                        {
                            // Remove 'Keyboard' add Move
                            txtEventName.Text = $"Move {txtEventName.Text.Substring(9, txtEventName.Text.Length - 9)}";
                        }
                        if (EventName.StartsWith("Click "))
                        {
                            // Remove 'Keyboard' add Move
                            txtEventName.Text = $"Move {txtEventName.Text.Substring(6, txtEventName.Text.Length - 6)}";
                        }
                    }
                    PictureBox1.Refresh();
                }
            }
            catch (Exception ex)
            {
                Log("rdoModeMove_CheckedChanged");
                Log(ex.Message);
            }
        }
        private void chkGameWindowNeverQuitIfWindowNotFound_CheckedChanged(object sender, EventArgs e)
        {
            GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
            GameNode.NeverQuitIfWindowNotFound = chkGameWindowNeverQuitIfWindowNotFound.Checked;
        }

        // Stores the checkboxes that are selected.
        List<CheckBox> chkKeyboardKeys = new List<CheckBox>();
        private void chkGeneralKeyboardUI_CheckChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            String Tag = chk.Tag.ToString();
            if (chk.Checked)
            {
                switch (Tag)
                {
                    case "{LSHIFT}":
                        Tag = "{LSHIFTDOWN}";
                        break;
                    case "{LCTRL}":
                        Tag = "{LCTRLDOWN}";
                        break;
                    case "{LWIN}":
                        Tag = "{LWINDOWN}";
                        break;
                    case "{LALT}":
                        Tag = "{LALTDOWN}";
                        break;
                    case "q":
                        Tag = "{QDOWN}";
                        break;
                    default:
                        Tag = $"{{{Tag.ToUpper()}DOWN}}";
                        break;
                }
                if (Tag.Length > 0)
                {
                    txtKeyboard.Text = txtKeyboard.Text + Tag;
                }
            }
            else
            {
                switch (Tag)
                {
                    case "{LSHIFT}":
                        txtKeyboard.Text = txtKeyboard.Text + "{LSHIFTUP}";
                        break;
                    case "{LCTRL}":
                        txtKeyboard.Text = txtKeyboard.Text + "{LCTRLUP}";
                        Tag = "{LCTRLDOWN}";
                        break;
                    case "{LWIN}":
                        txtKeyboard.Text = txtKeyboard.Text + "{LWINUP}";
                        break;
                    case "{LALT}":
                        txtKeyboard.Text = txtKeyboard.Text + "{LALTUP}";
                        break;


                    default:
                        txtKeyboard.Text = txtKeyboard.Text + $"{{{Tag.ToUpper()}UP}}";
                        break;
                }
            }

        }

        private void rdoModeKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsPanelLoading == false)
                {
                    GameNodeAction ActionNode = PanelLoadNode as GameNodeAction;

                    if (rdoModeKeyboard.Checked)
                    {
                        ActionNode.Mode = Mode.Keyboard;

                        panelRightSwipeProperties.Visible = false;
                        panelRightClickProperties.Visible = false;
                        panelKeyboard.Visible = true;
                        PictureBox1.Visible = false;

                        String EventName = txtEventName.Text;
                        if (EventName.StartsWith("Swipe "))
                        {
                            // Remove 'Swipe' add Keyboard
                            txtEventName.Text = $"Keyboard {txtEventName.Text.Substring(6, txtEventName.Text.Length - 6)}";
                        }
                        if (EventName.StartsWith("Move "))
                        {
                            // Remove 'Move' add Keyboard
                            txtEventName.Text = $"Keyboard {txtEventName.Text.Substring(5, txtEventName.Text.Length - 5)}";
                        }
                        if (EventName.StartsWith("Click "))
                        {
                            // Remove 'Click' add Keyboard
                            txtEventName.Text = $"Keyboard {txtEventName.Text.Substring(6, txtEventName.Text.Length - 6)}";
                        }

                        //if (PanelLoadNode.ActionType == ActionType.Action)
                        //{
                        //    chkFromCurrentMousePos.Visible = true;
                        //}

                        //if (ActionNode.IsParentObjectSearch())
                        //{
                        //    groupBoxClickDragReleaseObjectSearch.Enabled = true;
                        //    ActionNode.ClickDragReleaseMode = ClickDragReleaseMode.Start;
                        //    rdoObjectSearchStart.Checked = true;
                        //}
                        //else
                        //{
                        //    groupBoxClickDragReleaseObjectSearch.Enabled = false;
                        //    ActionNode.ClickDragReleaseMode = ClickDragReleaseMode.None;
                        //}
                    }
                    PictureBox1.Refresh();
                }
            }
            catch (Exception ex)
            {
                Log("rdoModeKeyboard_CheckedChanged");
                Log(ex.Message);
            }
        }

        private void txtKeyboard_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.KeyboardScript = txtKeyboard.Text;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void cmdKeyboardValidate_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Validating Script");
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;

                AppTestStudio.KeyboardProcessor KeyboardProcessor = new AppTestStudio.KeyboardProcessor();
                List<KeyboardCommand> CompleteList = KeyboardProcessor.ParseScript(txtKeyboard.Text);
                long Errors = 0;
                long ms = 0;
                foreach (KeyboardCommand command in CompleteList)
                {
                    if (command.ButtonState == KeyboardButtonStates.Error)
                    {
                        Log("Error Found");
                        Errors = Errors + 1;
                    }
                    Log(command.ToString());
                    ms = ms + command.Delayms;
                }
                if (Errors > 0)
                {
                    Log($"{Errors} Errors found.  Please fix, Errors will be skipped and may cause unexpected behaviours.");
                    cmdKeyboardValidate.BackColor = Color.Red;
                }
                else
                {
                    Log($"{CompleteList.Count} Steps found over {ms}ms.");
                    cmdKeyboardValidate.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void test()
        {
            //chkAppActivateIfNotActive
            //numericKeyboardTimeoutToActivateMS
            //numericKeyboardAfterSendingActivationMS
            //cboPreActionFailureAction
        }

        private void chkAppActivateIfNotActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.AppActivateIfNotActive = chkAppActivateIfNotActive.Checked;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void numericKeyboardTimeoutToActivateMS_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.KeyboardTimeoutToActivateMS = numericKeyboardTimeoutToActivateMS.Value.ToInt();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void numericKeyboardAfterSendingActivationMS_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.KeyboardAfterSendingActivationMS = numericKeyboardAfterSendingActivationMS.Value.ToInt();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void cboPreActionFailureAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                switch (cboPreActionFailureAction.SelectedValue)
                {
                    case "Abort":
                        ActionNode.PreActionFailureAction = TimeoutAction.Abort;
                        break;
                    case "Continue":
                        ActionNode.PreActionFailureAction = TimeoutAction.Continue;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void cmdWait1_Click(object sender, EventArgs e)
        {
            txtKeyboard.Text = txtKeyboard.Text + $"{{WAIT.{numericWait1.Value}}}";
        }

        private void cmdWait2_Click(object sender, EventArgs e)
        {
            txtKeyboard.Text = txtKeyboard.Text + $"{{WAIT.{numericWait2.Value}}}";
        }

        private void cmdWait3_Click(object sender, EventArgs e)
        {
            txtKeyboard.Text = txtKeyboard.Text + $"{{WAIT.{numericWait3.Value}}}";
        }

        private void chkDontTakeScreenshot_CheckedChanged(object sender, EventArgs e)
        {
            GameNodeGame GameNode = tv.SelectedNode as GameNodeGame;
            GameNode.DontTakeScreenshot = chkDontTakeScreenshot.Checked;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CutCopyOption cutCopyOption { get; set; } = CutCopyOption.None;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GameNodeAction cutCopyActionNode { get; set; }

        private void toolStripMenuCut_Click(object sender, EventArgs e)
        {
            cutCopyOption = CutCopyOption.Cut;
            cutCopyActionNode = tv.SelectedNode as GameNodeAction;

            // Cut so remove from tree.
            GameNode Parent = cutCopyActionNode.Parent as GameNode;
            Parent.Nodes.Remove(cutCopyActionNode);
        }

        private void toolStripMenuCopy_Click(object sender, EventArgs e)
        {
            cutCopyOption = CutCopyOption.Copy;
            cutCopyActionNode = tv.SelectedNode as GameNodeAction;
        }

        private void toolStripMenuPasteChild_Click(object sender, EventArgs e)
        {
            GameNode DestinationNode = tv.SelectedNode as GameNode;

            switch (cutCopyOption)
            {
                case CutCopyOption.Cut:
                    DestinationNode.Nodes.Add(cutCopyActionNode);
                    break;
                case CutCopyOption.Copy:
                    GameNodeAction NewNode = cutCopyActionNode.CloneMe();
                    DestinationNode.Nodes.Add(NewNode);
                    break;
                default:
                    break;
            }
            PasteCleanup();
        }

        private void toolStripMenuPasteSibling_Click(object sender, EventArgs e)
        {
            GameNode DestinationNode = tv.SelectedNode as GameNode;
            GameNode ParentNode = DestinationNode.Parent as GameNode;

            // Find location of the child relative to the parent.
            int NodeIndex = 0;
            foreach (GameNode node in ParentNode.Nodes)
            {
                if (DestinationNode == node)
                {
                    break;
                }
                NodeIndex++;
            }

            if (DestinationNode.GameNodeType == GameNodeType.Events)
            {
                // user used the wrong paste but we will fix it for them.
                toolStripMenuPasteChild_Click(sender, e);
            }
            else
            {
                PasteSibling(ParentNode, NodeIndex);
                PasteCleanup();
            }
        }
        void PasteSibling(GameNode ParentNode, int NodeIndex)
        {
            switch (cutCopyOption)
            {
                case CutCopyOption.Cut:
                    ParentNode.Nodes.Insert(NodeIndex, cutCopyActionNode);
                    break;
                case CutCopyOption.Copy:
                    GameNodeAction NewNode = cutCopyActionNode.CloneMe();

                    ParentNode.Nodes.Insert(NodeIndex, NewNode);
                    break;
                default:
                    break;
            }
        }

        private void PasteCleanup()
        {
            switch (cutCopyOption)
            {
                case CutCopyOption.None:
                    break;
                case CutCopyOption.Cut:
                    cutCopyOption = CutCopyOption.None;
                    break;
                case CutCopyOption.Copy:
                    break;
                default:
                    break;
            }
        }

        private void toolStripMenuPasteSiblingBelow_Click(object sender, EventArgs e)
        {
            GameNode DestinationNode = tv.SelectedNode as GameNode;
            GameNode ParentNode = DestinationNode.Parent as GameNode;

            // Find location of the child relative to the parent.
            int NodeIndex = 0;
            foreach (GameNode node in ParentNode.Nodes)
            {
                if (DestinationNode == node)
                {
                    break;
                }
                NodeIndex++;
            }

            if (DestinationNode.GameNodeType == GameNodeType.Events)
            {
                // user used the wrong paste but we will fix it for them.
                toolStripMenuPasteChild_Click(sender, e);
            }
            else
            {
                PasteSibling(ParentNode, NodeIndex + 1);
                PasteCleanup();
            }

        }

        private void cmdAfterCompletionHelp_Click(object sender, EventArgs e)
        {
            frmTreePicker picker = new frmTreePicker();
            GameNode Node = tv.SelectedNode as GameNode;
            GameNodeGame GameNode = Node.GetGameNodeGame();

            picker.treeView1.Nodes.Clear();
            TreeNode TestAllEventsGameNode = GameNode.CloneMe().Nodes[0];

            picker.treeView1.Nodes.Add(TestAllEventsGameNode);
            picker.treeView1.ExpandAll();
            picker.ShowDialog();
            if (picker.AcceptedText.Length > 0)
            {
                txtAfterCompletionGoTo.Text = picker.AcceptedText;
                rdoAfterCompletionGoTo.Checked = true;
            }
            picker = null;
        }

        private void rdoAfterCompletionGoTo_CheckedChanged(object sender, EventArgs e)
        {
            if (IsPanelLoading == false)
            {
                RDOAfterCompletionChange();
            }
        }

        private void txtAfterCompletionGoTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GameNodeAction ActionNode = tv.SelectedNode as GameNodeAction;
                ActionNode.GotoNode = txtAfterCompletionGoTo.Text;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        static int MouseRecordingCount = 0;
        private void mnuMouseRecording_Click(object sender, EventArgs e)
        {
            if (MouseRecordingCount == 0)
            {
                MouseRecordingCount++;
                frmMouseRecorder MouseRecorder = new frmMouseRecorder();

                // Non blocking window.
                MouseRecorder.Show();
                MouseRecordingCount--;
            }
        }

        private void toolStripButtonTest1_Click(object sender, EventArgs e)
        {


        }

        private void frmMain_Resize(object sender, EventArgs e)
        {

        }

        private void lstGamePass_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("lstGamePass_MouseClick");
            ListViewItem item = lstGamePass.GetItemAt(e.X, e.Y);
            if (item.IsSomething())
            {
                var k = GamePassList[item.Index];

                int index = k.SubItems[2].Text.ToInt();

                foreach (GamePassSolution solution in GamePassSolutions)
                {
                    if (solution.SolutionID == index)
                    {
                        ShowSolution(solution);
                    }
                }
            }
            Debug.WriteLine(item.Index);
        }

        private void ShowSolution(GamePassSolution solution)
        {
            frmSolution frm = new frmSolution(solution, this);


            frm.Show();
        }

        private void lstGamePass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("lstGamePass_SelectedIndexChanged");
        }

        private void lstGamePass_Resize(object sender, EventArgs e)
        {
            try
            {
                if (ShuttingDown == false)
                {
                    int headerHeigth = 29;
                    int rowHeight = 19;  // Picture is 16, measured between top of text to line above next text is 18.  19 did I count wrong?

                    int visibleRows = (lstGamePass.ClientSize.Height - headerHeigth) / rowHeight;
                    GamePassList = new List<ListViewItem>();


                    // Optional: store all items elsewhere and repopulate

                    lstGamePass.BeginUpdate();
                    lstGamePass.Items.Clear();
                    for (int i = 0; i < visibleRows; i++)
                    {
                        ListViewItem item = lstGamePass.Items.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        item.SubItems.Add("");
                        GamePassList.Add(item);
                    }
                    if (lstGamePass.Columns.Count > 0)
                    {
                        lstGamePass.Columns[0].DisplayIndex = 0;
                    }
                    else
                    {
                        Debug.WriteLine("lstGamePassColumns ?");
                    }

                    if (GamePassList.Count == 0)
                    {
                        // Abort
                        return;
                    }

                    int CurrentGamePassListCounter = GamePassListCounter;
                    int CurrentvisibleRows = visibleRows;

                    for (int i = GamePassSolutions.Count - 1; i >= 0; i--)
                    //foreach (GamePassSolution solution in GamePassSolutions)
                    {
                        GamePassSolution solution = GamePassSolutions[i];
                        int LastGamePassIndex = (CurrentGamePassListCounter - 1) % GamePassList.Count;

                        if (CurrentGamePassListCounter == 0 || CurrentvisibleRows == 0 || LastGamePassIndex < 0)
                        {
                            break;
                        }

                        GamePassList[LastGamePassIndex].SubItems[0].Text = "";
                        GamePassList[LastGamePassIndex].SubItems[1].Text = DateTime.Now.ToString("HH:mm:ss");
                        GamePassList[LastGamePassIndex].SubItems[2].Text = solution.SolutionID.ToString();
                        GamePassList[LastGamePassIndex].SubItems[3].Text = solution.Solutions.Count().ToString();
                        GamePassList[LastGamePassIndex].SubItems[4].Text = solution.LastNodeName;
                        CurrentGamePassListCounter--;
                        CurrentvisibleRows--;
                    }

                    lstGamePass.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                // This gets called duing unload, which throws an exception with the listview.
                log.Error(ex);
            }
            finally
            {
                lstGamePass.EndUpdate();
            }
        }

        private void lstGamePass_MouseMove(object sender, MouseEventArgs e)
        {
            //Debug.WriteLine("lstGamePass_MouseMove");
            ListViewItem item = lstGamePass.GetItemAt(e.X, e.Y);
            if (item.IsSomething())
            {
                var k = GamePassList[item.Index];

                int index = k.SubItems[2].Text.ToInt();

                foreach (GamePassSolution solution in GamePassSolutions)
                {
                    if (solution.SolutionID == index)
                    {
                        pbPreview.Width = (int)(pbPreview.Height * ((double)solution.Bitmap.Width / solution.Bitmap.Height));
                        pbPreview.Image = solution.Bitmap;
                        pbPreview.Left = -20 - pbPreview.Width + splitContainerThread.Width;
                        pbPreview.Top = e.Y + 20;

                        break;
                    }
                }
            }
        }

        private void lstGamePass_MouseLeave(object sender, EventArgs e)
        {
            pbPreview.Visible = false;
        }

        private void lstGamePass_MouseEnter(object sender, EventArgs e)
        {
            pbPreview.Visible = true;
        }

        internal void AddNewNode(String Name, bool IsAction, bool UseSelectedNode, bool AddToTopChild, Bitmap bmp)
        {
            tabTree.SelectedIndex = 0;

            Boolean AddToTop = AddToTopChild;

            // Use Selected Node
            if (UseSelectedNode)
            {
                GameNode node = tv.SelectedNode as GameNode;
                if (node != null)
                {
                    switch (node.GameNodeType)
                    {
                        case GameNodeType.Events:
                            break;
                        case GameNodeType.Action:
                            break;
                        default:
                            tv.SelectedNode = GetGameNodeEvents();
                            break;
                    }
                }
            }
            else
            {
                tv.SelectedNode = GetGameNodeEvents();
            }

            if (IsAction)
            {
                AddAction(AddToTopChild);
            }
            else
            {
                AddNewEvent(AddToTopChild);
            }
            txtEventName.Text = Name;
            SetPictureBox1(bmp);
        }

        private void mnuCompareAllToRuntimeImagesTolstGamePassolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAllRuntimeImages frm = new frmTestAllRuntimeImages(this, lastGameNodeForRunTesting, GamePassSolutions);
            frm.Show();
        }

        GameNode lastGameNodeForRunTesting = null;

        private void tvRun_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                //' Point where mouse is clicked
                Point p = new Point(e.X, e.Y);

                //' Go to the node that the user clicked
                GameNode node = tvRun.GetNodeAt(p) as GameNode;
                lastGameNodeForRunTesting = node;

                Boolean showMenu = false;
                switch (node.GameNodeType)
                {
                    case GameNodeType.Workspace:
                        break;
                    case GameNodeType.Games:
                        break;
                    case GameNodeType.Game:
                        break;
                    case GameNodeType.Events:
                        break;
                    case GameNodeType.Action:

                        GameNodeAction ActionNode = node as GameNodeAction;
                        switch (ActionNode.ActionType)
                        {
                            case ActionType.Action:
                                break;
                            case ActionType.Event:
                                lblRunTreeNodeNameToolStripMenuItem.Text = ActionNode.Name;
                                showMenu = true;
                                break;
                            case ActionType.RNG:
                                break;
                            case ActionType.RNGContainer:
                                break;
                            default:
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

                if (showMenu)
                {
                    mnuRunTree.Show(tvRun, p);
                }
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }
    }
}

