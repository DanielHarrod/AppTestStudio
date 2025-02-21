﻿using System.Diagnostics;

namespace AppTestStudio
{

    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                try
                {
                    GlobalMouseKeyHook.Dispose();
                    if (frmNotify != null)
                    {
                        frmNotify.Dispose();
                    }                    
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            ListViewItem listViewItem1 = new ListViewItem("");
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            importExportToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            fullExportToolStripMenuItem = new ToolStripMenuItem();
            minimalExportToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mnuRecentScripts = new ToolStripMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            aboutAppTestStudioToolStripMenuItem = new ToolStripMenuItem();
            splitContainerMain = new SplitContainer();
            splitContainerWorkspace = new SplitContainer();
            tabTree = new TabControl();
            tabDesign = new TabPage();
            tableLayoutPanelDesign = new TableLayoutPanel();
            tv = new TreeView();
            ImageList1 = new ImageList(components);
            panel3 = new Panel();
            txtFilter = new TextBox();
            label93 = new Label();
            tabRun = new TabPage();
            splitContainerRunTab = new SplitContainer();
            splitContainerRunTabThread = new SplitContainer();
            cboThreads = new ComboBox();
            tvRun = new TreeView();
            splitContainerRunProperties = new SplitContainer();
            tableLayoutPanelRunLabels = new TableLayoutPanel();
            lblRunLabel11 = new Label();
            lblRunLabel12 = new Label();
            lblRunLabel13 = new Label();
            lblRunLabel10 = new Label();
            lblRunLabel9 = new Label();
            lblRunLabel7 = new Label();
            lblRunLabel14 = new Label();
            lblRunLabel2 = new Label();
            lblRunLabel8 = new Label();
            lblRunLabel1 = new Label();
            lblRunLabel3 = new Label();
            lblRunLabel4 = new Label();
            lblRunLabel5 = new Label();
            lblRunLabel6 = new Label();
            tableLayoutPanelRunValues = new TableLayoutPanel();
            lblRunValue14 = new Label();
            lblRunValue7 = new Label();
            lblRunValue1 = new Label();
            lblRunValue2 = new Label();
            lblRunValue8 = new Label();
            lblRunValue3 = new Label();
            lblRunValue12 = new Label();
            lblRunValue9 = new Label();
            lblRunValue13 = new Label();
            lblRunValue4 = new Label();
            lblRunValue5 = new Label();
            lblRunValue11 = new Label();
            lblRunValue10 = new Label();
            lblRunValue6 = new Label();
            cmdUpdateResolution = new Button();
            cmdRuntimeEnableToggle = new Button();
            tabSchedule = new TabPage();
            PanelThread = new Panel();
            splitContainerThreadMain = new SplitContainer();
            splitContainerThread = new SplitContainer();
            splitContainerStatsNScrollie = new SplitContainer();
            tableLayoutStats = new TableLayoutPanel();
            groupTotal = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label13 = new Label();
            lblHomeTotal = new Label();
            label15 = new Label();
            lblChildTotal = new Label();
            lblContinueTotal = new Label();
            label21 = new Label();
            label20 = new Label();
            lblWaitingTotal = new Label();
            lblScreenshotsTotal = new Label();
            label19 = new Label();
            lblClickCountTotal = new Label();
            label14 = new Label();
            groupSession = new GroupBox();
            tableLayoutPanelSession = new TableLayoutPanel();
            label1 = new Label();
            label3 = new Label();
            lblWaiting = new Label();
            label9 = new Label();
            lblHome = new Label();
            lblScreenshots = new Label();
            label7 = new Label();
            lblContinue = new Label();
            label2 = new Label();
            lblChild = new Label();
            lblClickCount = new Label();
            label8 = new Label();
            grpCPU = new GroupBox();
            atsGraph1 = new AppTestStudioControls.ATSGraph();
            grpAPS = new GroupBox();
            atsGraphActions1 = new AppTestStudioControls.ATSGraph();
            splitContainerSeconds = new SplitContainer();
            appTestStudioStatusControl1 = new AppTestStudioControls.AppTestStudioStatusControl();
            lstGamePass = new ListView();
            PanelColorEvent = new Panel();
            tableColorEvent = new TableLayoutPanel();
            panelColorEventChild1 = new Panel();
            cmdTakeParentScreenshot = new Button();
            grpEventMode = new GroupBox();
            rdoObjectSearch = new RadioButton();
            rdoColorPoint = new RadioButton();
            lblMode = new Label();
            grpMode = new GroupBox();
            rdoModeKeyboard = new RadioButton();
            rdoModeMove = new RadioButton();
            rdoModeClickDragRelease = new RadioButton();
            rdoModeRangeClick = new RadioButton();
            cmdTest = new Button();
            cmdAddObject2 = new Button();
            PanelScreenshot = new Panel();
            panelKeyboard = new Panel();
            label97 = new Label();
            grpInsertWeights = new GroupBox();
            label96 = new Label();
            cmdWait3 = new Button();
            cmdWait2 = new Button();
            cmdWait1 = new Button();
            numericWait3 = new NumericUpDown();
            numericWait2 = new NumericUpDown();
            numericWait1 = new NumericUpDown();
            groupBox21 = new GroupBox();
            chkKeyboardSpace = new CheckBox();
            chkKeyboardA = new CheckBox();
            chkKeyboardTilde = new CheckBox();
            chkKeyboardTab = new CheckBox();
            chkKeyboardCapsLock = new CheckBox();
            chkKeyboardLeft = new CheckBox();
            chkKeyboardF12 = new CheckBox();
            chkKeyboardRight = new CheckBox();
            chkKeyboardDown = new CheckBox();
            chkKeyboardLeftShift = new CheckBox();
            chkKeyboardPageDown = new CheckBox();
            chkKeyboardEnd = new CheckBox();
            chkKeyboardDelete = new CheckBox();
            chkKeyboardPageUp = new CheckBox();
            chkKeyboardHome = new CheckBox();
            chkKeyboardIns = new CheckBox();
            chkKeyboardUp = new CheckBox();
            chkKeyboardF11 = new CheckBox();
            chkKeyboardRightShift = new CheckBox();
            chkKeyboardF8 = new CheckBox();
            chkKeyboardLeftCtrl = new CheckBox();
            chkKeyboardF10 = new CheckBox();
            chkKeyboardMnu = new CheckBox();
            chkKeyboardRightCtrl = new CheckBox();
            chkKeyboardF7 = new CheckBox();
            chkKeyboardLeftAlt = new CheckBox();
            chkKeyboardF9 = new CheckBox();
            chkKeyboardRightAlt = new CheckBox();
            chkKeyboardF6 = new CheckBox();
            chkKeyboardLeftWin = new CheckBox();
            chkKeyboardF5 = new CheckBox();
            chkKeyboardRightWin = new CheckBox();
            chkKeyboardF4 = new CheckBox();
            chkKeyboardF3 = new CheckBox();
            chkKeyboardB = new CheckBox();
            chkKeyboardF2 = new CheckBox();
            chkKeyboardC = new CheckBox();
            chkKeyboardF1 = new CheckBox();
            chkKeyboardD = new CheckBox();
            chkKeyboardESC = new CheckBox();
            chkKeyboardE = new CheckBox();
            chkKeyboardBackspace = new CheckBox();
            chkKeyboardF = new CheckBox();
            chkKeyboardPlus = new CheckBox();
            chkKeyboardG = new CheckBox();
            chkKeyboardDash = new CheckBox();
            chkKeyboardH = new CheckBox();
            chkKeyboard0 = new CheckBox();
            chkKeyboardI = new CheckBox();
            chkKeyboard9 = new CheckBox();
            chkKeyboardJ = new CheckBox();
            chkKeyboard8 = new CheckBox();
            chkKeyboardK = new CheckBox();
            chkKeyboard7 = new CheckBox();
            chkKeyboardL = new CheckBox();
            chkKeyboard6 = new CheckBox();
            chkKeyboardM = new CheckBox();
            chkKeyboard5 = new CheckBox();
            chkKeyboardComma = new CheckBox();
            chkKeyboard4 = new CheckBox();
            chkKeyboardPeriod = new CheckBox();
            chkKeyboard3 = new CheckBox();
            chkKeyboardSlash = new CheckBox();
            chkKeyboard2 = new CheckBox();
            chkKeyboardSemicolon = new CheckBox();
            chkKeyboard1 = new CheckBox();
            chkKeyboardQuote = new CheckBox();
            chkKeyboardZ = new CheckBox();
            chkKeyboardEnter = new CheckBox();
            chkKeyboardY = new CheckBox();
            chkKeyboardN = new CheckBox();
            chkKeyboardX = new CheckBox();
            chkKeyboardO = new CheckBox();
            chkKeyboardW = new CheckBox();
            chkKeyboardP = new CheckBox();
            chkKeyboardV = new CheckBox();
            chkKeyboardLeftBracket = new CheckBox();
            chkKeyboardU = new CheckBox();
            chkKeyboardRightBracket = new CheckBox();
            chkKeyboardT = new CheckBox();
            chkKeyboardBackslash = new CheckBox();
            chkKeyboardS = new CheckBox();
            chkKeyboardQ = new CheckBox();
            chkKeyboardR = new CheckBox();
            cmdKeyboardValidate = new Button();
            txtKeyboard = new TextBox();
            lblPictureMissing = new Label();
            PictureBox1 = new PictureBox();
            label29 = new Label();
            txtEventName = new TextBox();
            chkUseParentScreenshot = new CheckBox();
            cmdAddSingleColorAtSingleLocationTakeASceenshot = new Button();
            FlowLayoutPanelColorEvent1 = new FlowLayoutPanel();
            cmdFlowLayoutPanelColorEvent1 = new Button();
            panelRightProperties = new Panel();
            chkPropertiesRepeatsUntilFalse = new CheckBox();
            grpPropertiesRepeatsUntilFalse = new GroupBox();
            lblPropertiesRepeatsUntilFalse = new Label();
            numericPropertiesRepeatsUntilFalse = new NumericUpDown();
            chkPropertiesEnabled = new CheckBox();
            lblResolution = new Label();
            cmdPanelRightResolution = new Button();
            panelPreAction = new Panel();
            groupBox22 = new GroupBox();
            label99 = new Label();
            cboPreActionFailureAction = new ComboBox();
            label98 = new Label();
            numericKeyboardAfterSendingActivationMS = new NumericUpDown();
            label95 = new Label();
            numericKeyboardTimeoutToActivateMS = new NumericUpDown();
            chkAppActivateIfNotActive = new CheckBox();
            chkFromCurrentMousePos = new CheckBox();
            button2 = new Button();
            panelRightAfterCompletion = new Panel();
            cmdAfterCompletionHelp = new Button();
            txtAfterCompletionGoTo = new TextBox();
            rdoAfterCompletionGoTo = new RadioButton();
            groupBox4 = new GroupBox();
            groupBox6 = new GroupBox();
            lblDelayCalc = new Label();
            label23 = new Label();
            label24 = new Label();
            label27 = new Label();
            cboDelayH = new ComboBox();
            cboDelayM = new ComboBox();
            cboDelayS = new ComboBox();
            label28 = new Label();
            cboDelayMS = new ComboBox();
            cmdRightAfterCompletion = new Button();
            rdoAfterCompletionRecycle = new RadioButton();
            rdoAfterCompletionStop = new RadioButton();
            rdoAfterCompletionContinue = new RadioButton();
            rdoAfterCompletionHome = new RadioButton();
            rdoAfterCompletionParent = new RadioButton();
            panelRightObject = new Panel();
            NumericObjectThreshold = new NumericUpDown();
            cmdRightObject = new Button();
            Label52 = new Label();
            cboObject = new ComboBox();
            cmdMaxMask = new Button();
            lblSearchObject = new Label();
            lblMaskSize = new Label();
            lblColorChannel = new Label();
            Label51 = new Label();
            PictureBoxEventObjectSelection = new PictureBox();
            Label50 = new Label();
            cboChannel = new ComboBox();
            panelRightSwipeProperties = new Panel();
            label60 = new Label();
            groupBox8 = new GroupBox();
            label59 = new Label();
            label57 = new Label();
            numericSwipeEndWidth = new NumericUpDown();
            numericSwipeEndHeight = new NumericUpDown();
            groupBox5 = new GroupBox();
            label58 = new Label();
            label56 = new Label();
            numericSwipeStartWidth = new NumericUpDown();
            numericSwipeStartHeight = new NumericUpDown();
            groupBoxClickDragReleaseObjectSearch = new GroupBox();
            rdoObjectSearchNone = new RadioButton();
            rdoObjectSearchEnd = new RadioButton();
            rdoObjectSearchStart = new RadioButton();
            numericSwipeVelocity = new NumericUpDown();
            cmdRightSwipeProperties = new Button();
            panelRightClickProperties = new Panel();
            label55 = new Label();
            NumericClickSpeed = new NumericUpDown();
            label54 = new Label();
            cmdRightClickProperties = new Button();
            panelRightLogic = new Panel();
            cmdRightLogic = new Button();
            cboPoints = new ComboBox();
            rdoCustom = new RadioButton();
            label31 = new Label();
            rdoOR = new RadioButton();
            rdoAnd = new RadioButton();
            panelRightCustomLogic = new Panel();
            cmdValidate = new Button();
            label37 = new Label();
            txtCustomLogic = new TextBox();
            panelRightPointGrid = new Panel();
            dgv = new DataGridView();
            dgvID = new DataGridViewTextBoxColumn();
            dgvRed = new DataGridViewTextBoxColumn();
            dgvBlue = new DataGridViewTextBoxColumn();
            dgvGreen = new DataGridViewTextBoxColumn();
            dgvX = new DataGridViewTextBoxColumn();
            dgvY = new DataGridViewTextBoxColumn();
            dgvScan = new DataGridViewButtonColumn();
            dgvRemove = new DataGridViewButtonColumn();
            panelRightInformation = new Panel();
            pictureBoxInformationWarning = new PictureBox();
            lblInformation = new Label();
            cmdRightInformation = new Button();
            FlowLayoutPanelColorEvent2 = new FlowLayoutPanel();
            cmdFlowLayoutPanelColorEvent2 = new Button();
            panelRightColorAtPointer = new Panel();
            cmdRightColorAtPointer = new Button();
            PictureBox2 = new PictureBox();
            PanelSelectedColor = new Panel();
            lblRHSColor = new Label();
            lblRHSXY = new Label();
            panelRightLimit = new Panel();
            GroupBox7 = new GroupBox();
            chkLimitRepeats = new CheckBox();
            lnkLimitTime = new LinkLabel();
            numIterations = new NumericUpDown();
            lblLimitTimeLabel = new Label();
            lblLimitIterationsLabel = new Label();
            chkWaitFirst = new CheckBox();
            cmdRightLimit = new Button();
            lblLimitWaitType = new Label();
            chkUseLimit = new CheckBox();
            cboWaitType = new ComboBox();
            panelRightAnchor = new Panel();
            cmdAnchorDefault = new Button();
            cmdRightAnchor = new Button();
            cmdAnchorLeft = new Button();
            cmdAnchorRight = new Button();
            cmdAnchorBottom = new Button();
            cmdAnchorTop = new Button();
            cmdAnchorNone = new Button();
            panelRightOffset = new Panel();
            lblYOffsetRange = new Label();
            lblXOffsetRange = new Label();
            NumericYOffset = new NumericUpDown();
            NumericXOffset = new NumericUpDown();
            Label49 = new Label();
            Label48 = new Label();
            cmdRightOffset = new Button();
            panelRightDragMode = new Panel();
            cmdRightDragMode = new Button();
            PanelGame = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox18 = new GroupBox();
            groupBox2 = new GroupBox();
            label42 = new Label();
            numericApplicationDefaultClickSpeed = new NumericUpDown();
            groupBox16 = new GroupBox();
            label92 = new Label();
            numericMouseSpeedPixelsPerSecond = new NumericUpDown();
            groupBox17 = new GroupBox();
            label91 = new Label();
            label90 = new Label();
            numericMouseSpeedVelocityVariantPercentMin = new NumericUpDown();
            numericMouseSpeedVelocityVariantPercentMax = new NumericUpDown();
            label88 = new Label();
            label89 = new Label();
            label87 = new Label();
            grpActiveMouseSettings = new GroupBox();
            cboWindowAction = new ComboBox();
            chkMoveMouseBeforeAction = new CheckBox();
            lblWindowNotVisibleAction = new Label();
            label70 = new Label();
            cboMouseMode = new ComboBox();
            grpApplication = new GroupBox();
            groupBox13 = new GroupBox();
            label71 = new Label();
            label69 = new Label();
            txtPathToApplicationExe = new TextBox();
            txtApplicationParameters = new TextBox();
            cmdPathToExePicker = new Button();
            label72 = new Label();
            groupBox10 = new GroupBox();
            cmdApplicationWindowWizard = new Button();
            cboApplicationSecondaryWindowNameFilter = new ComboBox();
            txtApplicationSecondaryWindowName = new TextBox();
            label76 = new Label();
            label77 = new Label();
            cboApplicationPrimaryWindowNameFilter = new ComboBox();
            txtApplicationPrimaryWindowName = new TextBox();
            label78 = new Label();
            label79 = new Label();
            grpNox = new GroupBox();
            label61 = new Label();
            cboDPI = new ComboBox();
            Label26 = new Label();
            cboGameInstances = new ComboBox();
            cboResolution = new ComboBox();
            txtGamePanelLaunchInstance = new TextBox();
            label12 = new Label();
            Label16 = new Label();
            txtPackageName = new TextBox();
            label63 = new Label();
            Label25 = new Label();
            grpSteam = new GroupBox();
            groupBox14 = new GroupBox();
            label84 = new Label();
            label64 = new Label();
            label66 = new Label();
            txtSteamID = new TextBox();
            groupBox9 = new GroupBox();
            cmdSteamWindowWizard = new Button();
            cboSteamSecondaryWindowNameFilter = new ComboBox();
            txtSteamSecondaryWindowName = new TextBox();
            label74 = new Label();
            label75 = new Label();
            cboSteamPrimaryWindowNameFilter = new ComboBox();
            txtSteamPrimaryWindowName = new TextBox();
            label73 = new Label();
            label67 = new Label();
            grpBlue = new GroupBox();
            cboBlueInstance = new ComboBox();
            label83 = new Label();
            label82 = new Label();
            txtBluePackageName = new TextBox();
            groupBox11 = new GroupBox();
            chkDontTakeScreenshot = new CheckBox();
            chkGameWindowNeverQuitIfWindowNotFound = new CheckBox();
            grpVideo = new GroupBox();
            lblFrameLimit = new Label();
            NumericVideoFrameLimit = new NumericUpDown();
            chkSaveVideo = new CheckBox();
            Label33 = new Label();
            cmdStartEmmulatorAndPackage = new Button();
            cmdStartEmmulatorPackageAndRunScript = new Button();
            cmdStartEmmulator = new Button();
            txtGamePanelLoopDelay = new TextBox();
            Label30 = new Label();
            cmdRunScript = new Button();
            cboPlatform = new ComboBox();
            lblGamePanelGameName = new Label();
            label62 = new Label();
            label18 = new Label();
            label22 = new Label();
            PanelObject = new Panel();
            cmdDeleteObject = new Button();
            label36 = new Label();
            txtObjectReferencedBy = new TextBox();
            Panel5 = new Panel();
            PictureBoxObject = new PictureBox();
            txtObjectName = new TextBox();
            Label47 = new Label();
            Label46 = new Label();
            PanelTestAllEvents = new Panel();
            SplitContainer6 = new SplitContainer();
            SplitContainer7 = new SplitContainer();
            label35 = new Label();
            tvTestAllEvents = new TreeView();
            lblTestAllCustom = new Label();
            dgvTest = new DataGridView();
            dgvColorTestID = new DataGridViewTextBoxColumn();
            dgvColorTestRed = new DataGridViewTextBoxColumn();
            dgvColorTestGreen = new DataGridViewTextBoxColumn();
            dgvColorTestBlue = new DataGridViewTextBoxColumn();
            dgvXTest = new DataGridViewTextBoxColumn();
            dgvYTest = new DataGridViewTextBoxColumn();
            dgvPassFail = new DataGridViewTextBoxColumn();
            dvgRange = new DataGridViewTextBoxColumn();
            dgvTestAllReference = new DataGridView();
            dgvTestAllReferenceID = new DataGridViewTextBoxColumn();
            dgvTestAllReferenceRed = new DataGridViewTextBoxColumn();
            dgvTestAllReferenceGreen = new DataGridViewTextBoxColumn();
            dgvTestAllReferenceBlue = new DataGridViewTextBoxColumn();
            dgvTestAllReferenceX = new DataGridViewTextBoxColumn();
            dgvTestAllReferenceY = new DataGridViewTextBoxColumn();
            lblReferenceWindowResolution = new Label();
            lblTestWindowResolution = new Label();
            Panel2 = new Panel();
            PictureTestAllTest = new PictureBox();
            lblTestWindow = new Label();
            lblReference = new Label();
            Panel1 = new Panel();
            PictureTestAllReference = new PictureBox();
            PanelGames = new Panel();
            label43 = new Label();
            PanelActions = new Panel();
            label41 = new Label();
            PanelObjectScreenshot = new Panel();
            pictureCreateNewObjectNamedCheckBox = new PictureBox();
            pictureCreateNewObjectMaskDrawnCheckBox = new PictureBox();
            cmdMakeObjectAndUse = new Button();
            cmdMakeObject = new Button();
            panelObjectScreenshotColor = new Panel();
            lblObjectScreenshotColorXY = new Label();
            lblObjectScreenshotRHSXY = new Label();
            PictureObjectScreenshotZoomBox = new PictureBox();
            txtObjectScreenshotName = new TextBox();
            Label45 = new Label();
            cmdObjectScreenshotsTakeAScreenshot = new Button();
            Panel4 = new Panel();
            PictureObjectScreenshot = new PictureBox();
            Label44 = new Label();
            Label53 = new Label();
            PanelAddNewGames = new Panel();
            label39 = new Label();
            txtAddNewGame = new TextBox();
            label38 = new Label();
            PanelObjects = new Panel();
            label34 = new Label();
            label32 = new Label();
            PanelEvents = new Panel();
            lblEventsPanelTargetWindow = new Label();
            label11 = new Label();
            label10 = new Label();
            PanelSchedule = new Panel();
            splitContainerSchedule = new SplitContainer();
            dgSchedule = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colWindowName = new DataGridViewTextBoxColumn();
            colInstance = new DataGridViewTextBoxColumn();
            colStartTime = new DataGridViewTextBoxColumn();
            colRepeat = new DataGridViewTextBoxColumn();
            colScheduleEnabled = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            splitContainerRuntimeSchedule = new SplitContainer();
            lblRuntimeScheduleLabel = new Label();
            dgRuntimeSchedule = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            Button5 = new Button();
            chkEnableSchedule = new CheckBox();
            Button4 = new Button();
            cmdAddSchedule = new Button();
            label40 = new Label();
            PanelWorkspace = new Panel();
            groupBox15 = new GroupBox();
            label94 = new Label();
            label86 = new Label();
            label85 = new Label();
            groupBox12 = new GroupBox();
            lblBlueInstancesFound64 = new Label();
            lblBlueEmmulatorInstalled64 = new Label();
            lblBlueInstancesFound32 = new Label();
            label81 = new Label();
            lblBlueEmmulatorInstalled32 = new Label();
            label80 = new Label();
            label68 = new Label();
            label65 = new Label();
            groupBox3 = new GroupBox();
            lblEmmulatorInstancesFound = new Label();
            lblEmmulatorInstalled = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtLog = new RichTextBox();
            mnuPopupGames = new ContextMenuStrip(components);
            mnuGamesAddNewGame = new ToolStripMenuItem();
            mnuGamesLoadApp = new ToolStripMenuItem();
            mnuEvents = new ContextMenuStrip(components);
            mnuAddEvent = new ToolStripMenuItem();
            mnuAddAction = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripMenuCut = new ToolStripMenuItem();
            toolStripMenuCopy = new ToolStripMenuItem();
            toolStripMenuPaste = new ToolStripMenuItem();
            toolStripMenuPasteChild = new ToolStripMenuItem();
            toolStripMenuPasteSibling = new ToolStripMenuItem();
            toolStripMenuPasteSiblingBelow = new ToolStripMenuItem();
            toolStripSeparatorCutCopyPaste = new ToolStripSeparator();
            testToolStripMenuItem = new ToolStripMenuItem();
            mnuTestAllEvents = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            mnuAddRNG = new ToolStripMenuItem();
            mnuAddRNGNode = new ToolStripMenuItem();
            toolStripSeparator12 = new ToolStripSeparator();
            advancedToolStripMenuItem = new ToolStripMenuItem();
            moveToolStripMenuItem = new ToolStripMenuItem();
            upToolStripMenuItem = new ToolStripMenuItem();
            downToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            mnuThreadList = new ContextMenuStrip(components);
            mnuThreadExit = new ToolStripMenuItem();
            mnuPopupGame = new ContextMenuStrip(components);
            mnuLoadInstance = new ToolStripMenuItem();
            mnuLaunchAndLoad = new ToolStripMenuItem();
            mnuObjects = new ContextMenuStrip(components);
            mnuAddObject = new ToolStripMenuItem();
            timerScheduler = new System.Windows.Forms.Timer(components);
            Timer1 = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            dlgApplicationPicker = new OpenFileDialog();
            button1 = new Button();
            contextMenuStripResetResolution = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator13 = new ToolStripSeparator();
            toolStripMenuItemResetResolution = new ToolStripMenuItem();
            contextMenuStripRuntimeEnableDisable = new ContextMenuStrip(components);
            toolStripMenuItemEnableDisableToggleLabel = new ToolStripMenuItem();
            toolStripSeparatorEnableDisableToggle = new ToolStripSeparator();
            toolStripMenuItemRuntimeEnableDisableToggle = new ToolStripMenuItem();
            TimerProperties = new System.Windows.Forms.Timer(components);
            appTestStudioToolStrip1 = new AppTestStudioControls.AppTestStudioToolStrip();
            toolAddEvent = new ToolStripButton();
            toolStripSeparator9 = new ToolStripSeparator();
            toolAddAction = new ToolStripButton();
            toolStripSeparator10 = new ToolStripSeparator();
            toolTest = new ToolStripButton();
            toolTestAll = new ToolStripButton();
            toolStripSeparator11 = new ToolStripSeparator();
            toolAddRNG = new ToolStripButton();
            toolAddRNGNode = new ToolStripButton();
            toolStripMain = new AppTestStudioControls.AppTestStudioToolStrip();
            toolStripLoadScript = new ToolStripButton();
            toolStripButtonSaveScript = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButtonRunScript = new ToolStripButton();
            toolStripButtonRunStartLaunch = new ToolStripButton();
            toolStripButtonStartEmmulatorLaunchApp = new ToolStripButton();
            toolStripButtonStartEmmulator = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButtonToggleScript = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolSchedulerRunning = new ToolStripLabel();
            toolStripSeparator8 = new ToolStripSeparator();
            toolStripCurrentDesignInstance = new ToolStripLabel();
            toolStripInstances = new ToolStripDropDownButton();
            mnuMouseRecording = new ToolStripButton();
            toolStripButtonTest1 = new ToolStripButton();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerWorkspace).BeginInit();
            splitContainerWorkspace.Panel1.SuspendLayout();
            splitContainerWorkspace.Panel2.SuspendLayout();
            splitContainerWorkspace.SuspendLayout();
            tabTree.SuspendLayout();
            tabDesign.SuspendLayout();
            tableLayoutPanelDesign.SuspendLayout();
            panel3.SuspendLayout();
            tabRun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerRunTab).BeginInit();
            splitContainerRunTab.Panel1.SuspendLayout();
            splitContainerRunTab.Panel2.SuspendLayout();
            splitContainerRunTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerRunTabThread).BeginInit();
            splitContainerRunTabThread.Panel1.SuspendLayout();
            splitContainerRunTabThread.Panel2.SuspendLayout();
            splitContainerRunTabThread.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerRunProperties).BeginInit();
            splitContainerRunProperties.Panel1.SuspendLayout();
            splitContainerRunProperties.Panel2.SuspendLayout();
            splitContainerRunProperties.SuspendLayout();
            tableLayoutPanelRunLabels.SuspendLayout();
            tableLayoutPanelRunValues.SuspendLayout();
            PanelThread.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerThreadMain).BeginInit();
            splitContainerThreadMain.Panel1.SuspendLayout();
            splitContainerThreadMain.Panel2.SuspendLayout();
            splitContainerThreadMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerThread).BeginInit();
            splitContainerThread.Panel1.SuspendLayout();
            splitContainerThread.Panel2.SuspendLayout();
            splitContainerThread.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerStatsNScrollie).BeginInit();
            splitContainerStatsNScrollie.Panel1.SuspendLayout();
            splitContainerStatsNScrollie.Panel2.SuspendLayout();
            splitContainerStatsNScrollie.SuspendLayout();
            tableLayoutStats.SuspendLayout();
            groupTotal.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupSession.SuspendLayout();
            tableLayoutPanelSession.SuspendLayout();
            grpCPU.SuspendLayout();
            grpAPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerSeconds).BeginInit();
            splitContainerSeconds.SuspendLayout();
            PanelColorEvent.SuspendLayout();
            tableColorEvent.SuspendLayout();
            panelColorEventChild1.SuspendLayout();
            grpEventMode.SuspendLayout();
            grpMode.SuspendLayout();
            PanelScreenshot.SuspendLayout();
            panelKeyboard.SuspendLayout();
            grpInsertWeights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericWait3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericWait2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericWait1).BeginInit();
            groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            FlowLayoutPanelColorEvent1.SuspendLayout();
            panelRightProperties.SuspendLayout();
            grpPropertiesRepeatsUntilFalse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPropertiesRepeatsUntilFalse).BeginInit();
            panelPreAction.SuspendLayout();
            groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericKeyboardAfterSendingActivationMS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericKeyboardTimeoutToActivateMS).BeginInit();
            panelRightAfterCompletion.SuspendLayout();
            groupBox6.SuspendLayout();
            panelRightObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericObjectThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEventObjectSelection).BeginInit();
            panelRightSwipeProperties.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericSwipeEndWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSwipeEndHeight).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericSwipeStartWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSwipeStartHeight).BeginInit();
            groupBoxClickDragReleaseObjectSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericSwipeVelocity).BeginInit();
            panelRightClickProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericClickSpeed).BeginInit();
            panelRightLogic.SuspendLayout();
            panelRightCustomLogic.SuspendLayout();
            panelRightPointGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panelRightInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxInformationWarning).BeginInit();
            FlowLayoutPanelColorEvent2.SuspendLayout();
            panelRightColorAtPointer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            PanelSelectedColor.SuspendLayout();
            panelRightLimit.SuspendLayout();
            GroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIterations).BeginInit();
            panelRightAnchor.SuspendLayout();
            panelRightOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericYOffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericXOffset).BeginInit();
            panelRightDragMode.SuspendLayout();
            PanelGame.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox18.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericApplicationDefaultClickSpeed).BeginInit();
            groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericMouseSpeedPixelsPerSecond).BeginInit();
            groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericMouseSpeedVelocityVariantPercentMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMouseSpeedVelocityVariantPercentMax).BeginInit();
            grpActiveMouseSettings.SuspendLayout();
            grpApplication.SuspendLayout();
            groupBox13.SuspendLayout();
            groupBox10.SuspendLayout();
            grpNox.SuspendLayout();
            grpSteam.SuspendLayout();
            groupBox14.SuspendLayout();
            groupBox9.SuspendLayout();
            grpBlue.SuspendLayout();
            groupBox11.SuspendLayout();
            grpVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericVideoFrameLimit).BeginInit();
            PanelObject.SuspendLayout();
            Panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxObject).BeginInit();
            PanelTestAllEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer6).BeginInit();
            SplitContainer6.Panel1.SuspendLayout();
            SplitContainer6.Panel2.SuspendLayout();
            SplitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer7).BeginInit();
            SplitContainer7.Panel1.SuspendLayout();
            SplitContainer7.Panel2.SuspendLayout();
            SplitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTestAllReference).BeginInit();
            Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureTestAllTest).BeginInit();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureTestAllReference).BeginInit();
            PanelGames.SuspendLayout();
            PanelActions.SuspendLayout();
            PanelObjectScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureCreateNewObjectNamedCheckBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureCreateNewObjectMaskDrawnCheckBox).BeginInit();
            panelObjectScreenshotColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureObjectScreenshotZoomBox).BeginInit();
            Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureObjectScreenshot).BeginInit();
            PanelAddNewGames.SuspendLayout();
            PanelObjects.SuspendLayout();
            PanelEvents.SuspendLayout();
            PanelSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerSchedule).BeginInit();
            splitContainerSchedule.Panel1.SuspendLayout();
            splitContainerSchedule.Panel2.SuspendLayout();
            splitContainerSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSchedule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerRuntimeSchedule).BeginInit();
            splitContainerRuntimeSchedule.Panel1.SuspendLayout();
            splitContainerRuntimeSchedule.Panel2.SuspendLayout();
            splitContainerRuntimeSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgRuntimeSchedule).BeginInit();
            PanelWorkspace.SuspendLayout();
            groupBox15.SuspendLayout();
            groupBox12.SuspendLayout();
            groupBox3.SuspendLayout();
            mnuPopupGames.SuspendLayout();
            mnuEvents.SuspendLayout();
            mnuThreadList.SuspendLayout();
            mnuPopupGame.SuspendLayout();
            mnuObjects.SuspendLayout();
            contextMenuStripResetResolution.SuspendLayout();
            contextMenuStripRuntimeEnableDisable.SuspendLayout();
            appTestStudioToolStrip1.SuspendLayout();
            toolStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(2670, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, toolStripSeparator1, importExportToolStripMenuItem, toolStripSeparator2, mnuRecentScripts, toolStripSeparator14, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(227, 34);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(224, 6);
            // 
            // importExportToolStripMenuItem
            // 
            importExportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem, exportToolStripMenuItem });
            importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            importExportToolStripMenuItem.Size = new Size(227, 34);
            importExportToolStripMenuItem.Text = "Import/Export";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(169, 34);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fullExportToolStripMenuItem, minimalExportToolStripMenuItem });
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(169, 34);
            exportToolStripMenuItem.Text = "Export";
            // 
            // fullExportToolStripMenuItem
            // 
            fullExportToolStripMenuItem.Name = "fullExportToolStripMenuItem";
            fullExportToolStripMenuItem.Size = new Size(233, 34);
            fullExportToolStripMenuItem.Text = "Full Export";
            fullExportToolStripMenuItem.Click += fullExportToolStripMenuItem_Click;
            // 
            // minimalExportToolStripMenuItem
            // 
            minimalExportToolStripMenuItem.Name = "minimalExportToolStripMenuItem";
            minimalExportToolStripMenuItem.Size = new Size(233, 34);
            minimalExportToolStripMenuItem.Text = "Minimal Export";
            minimalExportToolStripMenuItem.Click += minimalExportToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(224, 6);
            // 
            // mnuRecentScripts
            // 
            mnuRecentScripts.Name = "mnuRecentScripts";
            mnuRecentScripts.Size = new Size(227, 34);
            mnuRecentScripts.Text = "Recent Scripts";
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(224, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(227, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutAppTestStudioToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(65, 29);
            aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutAppTestStudioToolStripMenuItem
            // 
            aboutAppTestStudioToolStripMenuItem.Name = "aboutAppTestStudioToolStripMenuItem";
            aboutAppTestStudioToolStripMenuItem.Size = new Size(294, 34);
            aboutAppTestStudioToolStripMenuItem.Text = "About App Test Studio";
            aboutAppTestStudioToolStripMenuItem.Click += aboutAppTestStudioToolStripMenuItem_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 101);
            splitContainerMain.Margin = new Padding(6, 5, 6, 5);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(splitContainerWorkspace);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(txtLog);
            splitContainerMain.Size = new Size(2670, 1637);
            splitContainerMain.SplitterDistance = 1482;
            splitContainerMain.SplitterWidth = 8;
            splitContainerMain.TabIndex = 2;
            // 
            // splitContainerWorkspace
            // 
            splitContainerWorkspace.Dock = DockStyle.Fill;
            splitContainerWorkspace.Location = new Point(0, 0);
            splitContainerWorkspace.Margin = new Padding(6, 5, 6, 5);
            splitContainerWorkspace.Name = "splitContainerWorkspace";
            // 
            // splitContainerWorkspace.Panel1
            // 
            splitContainerWorkspace.Panel1.Controls.Add(tabTree);
            // 
            // splitContainerWorkspace.Panel2
            // 
            splitContainerWorkspace.Panel2.Controls.Add(PanelThread);
            splitContainerWorkspace.Panel2.Controls.Add(PanelColorEvent);
            splitContainerWorkspace.Panel2.Controls.Add(PanelGame);
            splitContainerWorkspace.Panel2.Controls.Add(PanelObject);
            splitContainerWorkspace.Panel2.Controls.Add(PanelTestAllEvents);
            splitContainerWorkspace.Panel2.Controls.Add(PanelGames);
            splitContainerWorkspace.Panel2.Controls.Add(PanelActions);
            splitContainerWorkspace.Panel2.Controls.Add(PanelObjectScreenshot);
            splitContainerWorkspace.Panel2.Controls.Add(PanelAddNewGames);
            splitContainerWorkspace.Panel2.Controls.Add(PanelObjects);
            splitContainerWorkspace.Panel2.Controls.Add(PanelEvents);
            splitContainerWorkspace.Panel2.Controls.Add(PanelSchedule);
            splitContainerWorkspace.Panel2.Controls.Add(PanelWorkspace);
            splitContainerWorkspace.Size = new Size(2670, 1482);
            splitContainerWorkspace.SplitterDistance = 424;
            splitContainerWorkspace.SplitterWidth = 7;
            splitContainerWorkspace.TabIndex = 0;
            // 
            // tabTree
            // 
            tabTree.Controls.Add(tabDesign);
            tabTree.Controls.Add(tabRun);
            tabTree.Controls.Add(tabSchedule);
            tabTree.Dock = DockStyle.Fill;
            tabTree.Location = new Point(0, 0);
            tabTree.Margin = new Padding(6, 5, 6, 5);
            tabTree.Name = "tabTree";
            tabTree.SelectedIndex = 0;
            tabTree.Size = new Size(424, 1482);
            tabTree.TabIndex = 0;
            tabTree.SelectedIndexChanged += tabTree_SelectedIndexChanged;
            // 
            // tabDesign
            // 
            tabDesign.Controls.Add(tableLayoutPanelDesign);
            tabDesign.Location = new Point(4, 34);
            tabDesign.Margin = new Padding(6, 5, 6, 5);
            tabDesign.Name = "tabDesign";
            tabDesign.Padding = new Padding(6, 5, 6, 5);
            tabDesign.Size = new Size(416, 1444);
            tabDesign.TabIndex = 0;
            tabDesign.Text = "Design";
            tabDesign.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDesign
            // 
            tableLayoutPanelDesign.ColumnCount = 1;
            tableLayoutPanelDesign.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelDesign.Controls.Add(tv, 0, 1);
            tableLayoutPanelDesign.Controls.Add(panel3, 0, 0);
            tableLayoutPanelDesign.Dock = DockStyle.Fill;
            tableLayoutPanelDesign.Location = new Point(6, 5);
            tableLayoutPanelDesign.Margin = new Padding(1, 2, 1, 2);
            tableLayoutPanelDesign.Name = "tableLayoutPanelDesign";
            tableLayoutPanelDesign.RowCount = 2;
            tableLayoutPanelDesign.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tableLayoutPanelDesign.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelDesign.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelDesign.Size = new Size(404, 1434);
            tableLayoutPanelDesign.TabIndex = 1;
            // 
            // tv
            // 
            tv.AllowDrop = true;
            tv.Cursor = Cursors.Hand;
            tv.Dock = DockStyle.Fill;
            tv.ImageIndex = 0;
            tv.ImageList = ImageList1;
            tv.Location = new Point(0, 62);
            tv.Margin = new Padding(0);
            tv.Name = "tv";
            tv.SelectedImageIndex = 0;
            tv.Size = new Size(404, 1372);
            tv.TabIndex = 0;
            tv.ItemDrag += tv_ItemDrag;
            tv.AfterSelect += tv_AfterSelect;
            tv.NodeMouseClick += tv_NodeMouseClick;
            tv.DragDrop += tv_DragDrop;
            tv.DragOver += tv_DragOver;
            tv.KeyUp += tv_KeyUp;
            tv.MouseUp += tv_MouseUp;
            // 
            // ImageList1
            // 
            ImageList1.ColorDepth = ColorDepth.Depth8Bit;
            ImageList1.ImageStream = (ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
            ImageList1.TransparentColor = Color.Transparent;
            ImageList1.Images.SetKeyName(0, "Video_game_controller_icon_designed_by_Maico_Amorim.png");
            ImageList1.Images.SetKeyName(1, "AWS_Simple_Icons_Non-Service_Specific_AWS_Management_Console.png");
            ImageList1.Images.SetKeyName(2, "Angular_lightningbolt.png");
            ImageList1.Images.SetKeyName(3, "Pixel_51_icon_cursor_click_bottom_right.png");
            ImageList1.Images.SetKeyName(4, "RMG Container.png");
            ImageList1.Images.SetKeyName(5, "RNG.png");
            ImageList1.Images.SetKeyName(6, "Angular_lightningboltNo.png");
            ImageList1.Images.SetKeyName(7, "Angular_lightningboltYes.png");
            ImageList1.Images.SetKeyName(8, "HelpApplication_16x_24.bmp");
            ImageList1.Images.SetKeyName(9, "mobile.png");
            ImageList1.Images.SetKeyName(10, "mobiles.png");
            ImageList1.Images.SetKeyName(11, "EncapsulateField_16x.png");
            ImageList1.Images.SetKeyName(12, "EditMultipleObjects_16x.png");
            ImageList1.Images.SetKeyName(13, "RectangularScreenshot_16x.png");
            ImageList1.Images.SetKeyName(14, "RectangularSelection_16x.png");
            ImageList1.Images.SetKeyName(15, "Event_16x.png");
            ImageList1.Images.SetKeyName(16, "ButtonClick_16x.png");
            ImageList1.Images.SetKeyName(17, "Home_16x.png");
            ImageList1.Images.SetKeyName(18, "Application_16x.png");
            ImageList1.Images.SetKeyName(19, "AppRoot_16x.png");
            ImageList1.Images.SetKeyName(20, "SearchAndApps_16x.png");
            ImageList1.Images.SetKeyName(21, "DependencyArrow_16x.png");
            ImageList1.Images.SetKeyName(22, "ASX_CollapseChevronDown_grey_16x.png");
            ImageList1.Images.SetKeyName(23, "CollapseChevronLeft_16x.png");
            ImageList1.Images.SetKeyName(24, "RNGGR.png");
            ImageList1.Images.SetKeyName(25, "Angular_lightningboltGR.png");
            ImageList1.Images.SetKeyName(26, "ButtonClick_16xGR.png");
            ImageList1.Images.SetKeyName(27, "DependencyArrow_16xGR.png");
            ImageList1.Images.SetKeyName(28, "RMG ContainerGR.png");
            ImageList1.Images.SetKeyName(29, "SearchAndApps_16xGR.png");
            ImageList1.Images.SetKeyName(30, "ATSGroup.png");
            ImageList1.Images.SetKeyName(31, "ATSGroupGR.png");
            ImageList1.Images.SetKeyName(32, "MoveGlyph_16x.png");
            ImageList1.Images.SetKeyName(33, "ToggleOfficeKeyboardScheme_16x.png");
            // 
            // panel3
            // 
            panel3.Controls.Add(txtFilter);
            panel3.Controls.Add(label93);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(404, 62);
            panel3.TabIndex = 0;
            // 
            // txtFilter
            // 
            txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFilter.Location = new Point(59, 5);
            txtFilter.Margin = new Padding(6, 5, 6, 5);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(338, 31);
            txtFilter.TabIndex = 0;
            txtFilter.KeyUp += txtSearch_KeyUp;
            // 
            // label93
            // 
            label93.AutoSize = true;
            label93.Location = new Point(6, 10);
            label93.Margin = new Padding(6, 0, 6, 0);
            label93.Name = "label93";
            label93.Size = new Size(50, 25);
            label93.TabIndex = 0;
            label93.Text = "Filter";
            // 
            // tabRun
            // 
            tabRun.Controls.Add(splitContainerRunTab);
            tabRun.Location = new Point(4, 34);
            tabRun.Margin = new Padding(6, 5, 6, 5);
            tabRun.Name = "tabRun";
            tabRun.Padding = new Padding(6, 5, 6, 5);
            tabRun.Size = new Size(416, 1444);
            tabRun.TabIndex = 1;
            tabRun.Text = "Run";
            tabRun.UseVisualStyleBackColor = true;
            // 
            // splitContainerRunTab
            // 
            splitContainerRunTab.Dock = DockStyle.Fill;
            splitContainerRunTab.Location = new Point(6, 5);
            splitContainerRunTab.Margin = new Padding(6, 5, 6, 5);
            splitContainerRunTab.Name = "splitContainerRunTab";
            splitContainerRunTab.Orientation = Orientation.Horizontal;
            // 
            // splitContainerRunTab.Panel1
            // 
            splitContainerRunTab.Panel1.AutoScroll = true;
            splitContainerRunTab.Panel1.Controls.Add(splitContainerRunTabThread);
            // 
            // splitContainerRunTab.Panel2
            // 
            splitContainerRunTab.Panel2.AutoScroll = true;
            splitContainerRunTab.Panel2.Controls.Add(splitContainerRunProperties);
            splitContainerRunTab.Size = new Size(404, 1434);
            splitContainerRunTab.SplitterDistance = 707;
            splitContainerRunTab.SplitterWidth = 8;
            splitContainerRunTab.TabIndex = 1;
            // 
            // splitContainerRunTabThread
            // 
            splitContainerRunTabThread.BackColor = Color.Transparent;
            splitContainerRunTabThread.Dock = DockStyle.Fill;
            splitContainerRunTabThread.FixedPanel = FixedPanel.Panel1;
            splitContainerRunTabThread.IsSplitterFixed = true;
            splitContainerRunTabThread.Location = new Point(0, 0);
            splitContainerRunTabThread.Margin = new Padding(6, 5, 6, 5);
            splitContainerRunTabThread.Name = "splitContainerRunTabThread";
            splitContainerRunTabThread.Orientation = Orientation.Horizontal;
            // 
            // splitContainerRunTabThread.Panel1
            // 
            splitContainerRunTabThread.Panel1.BackColor = Color.Transparent;
            splitContainerRunTabThread.Panel1.Controls.Add(cboThreads);
            splitContainerRunTabThread.Panel1MinSize = 21;
            // 
            // splitContainerRunTabThread.Panel2
            // 
            splitContainerRunTabThread.Panel2.Controls.Add(tvRun);
            splitContainerRunTabThread.Size = new Size(404, 707);
            splitContainerRunTabThread.SplitterDistance = 25;
            splitContainerRunTabThread.SplitterWidth = 2;
            splitContainerRunTabThread.TabIndex = 2;
            // 
            // cboThreads
            // 
            cboThreads.Dock = DockStyle.Top;
            cboThreads.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThreads.FormattingEnabled = true;
            cboThreads.Location = new Point(0, 0);
            cboThreads.Margin = new Padding(6, 5, 6, 5);
            cboThreads.Name = "cboThreads";
            cboThreads.Size = new Size(404, 33);
            cboThreads.TabIndex = 1;
            cboThreads.SelectedIndexChanged += cboThreads_SelectedIndexChanged;
            // 
            // tvRun
            // 
            tvRun.BackColor = SystemColors.Control;
            tvRun.Dock = DockStyle.Fill;
            tvRun.ImageIndex = 0;
            tvRun.ImageList = ImageList1;
            tvRun.Location = new Point(0, 0);
            tvRun.Name = "tvRun";
            tvRun.SelectedImageIndex = 0;
            tvRun.Size = new Size(404, 680);
            tvRun.TabIndex = 0;
            tvRun.AfterSelect += tvRun_AfterSelect;
            // 
            // splitContainerRunProperties
            // 
            splitContainerRunProperties.Dock = DockStyle.Top;
            splitContainerRunProperties.Location = new Point(0, 0);
            splitContainerRunProperties.Margin = new Padding(6, 5, 6, 5);
            splitContainerRunProperties.Name = "splitContainerRunProperties";
            // 
            // splitContainerRunProperties.Panel1
            // 
            splitContainerRunProperties.Panel1.Controls.Add(tableLayoutPanelRunLabels);
            // 
            // splitContainerRunProperties.Panel2
            // 
            splitContainerRunProperties.Panel2.Controls.Add(tableLayoutPanelRunValues);
            splitContainerRunProperties.Size = new Size(404, 677);
            splitContainerRunProperties.SplitterDistance = 162;
            splitContainerRunProperties.SplitterWidth = 1;
            splitContainerRunProperties.TabIndex = 1;
            // 
            // tableLayoutPanelRunLabels
            // 
            tableLayoutPanelRunLabels.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelRunLabels.BackColor = SystemColors.ControlDarkDark;
            tableLayoutPanelRunLabels.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelRunLabels.ColumnCount = 1;
            tableLayoutPanelRunLabels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel11, 0, 10);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel12, 0, 11);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel13, 0, 12);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel10, 0, 9);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel9, 0, 8);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel7, 0, 6);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel14, 0, 13);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel2, 0, 1);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel8, 0, 7);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel1, 0, 0);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel3, 0, 2);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel4, 0, 3);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel5, 0, 4);
            tableLayoutPanelRunLabels.Controls.Add(lblRunLabel6, 0, 5);
            tableLayoutPanelRunLabels.Location = new Point(0, 0);
            tableLayoutPanelRunLabels.Margin = new Padding(6, 5, 6, 5);
            tableLayoutPanelRunLabels.Name = "tableLayoutPanelRunLabels";
            tableLayoutPanelRunLabels.RowCount = 15;
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunLabels.Size = new Size(162, 677);
            tableLayoutPanelRunLabels.TabIndex = 1;
            // 
            // lblRunLabel11
            // 
            lblRunLabel11.AutoSize = true;
            lblRunLabel11.ForeColor = SystemColors.ButtonFace;
            lblRunLabel11.Location = new Point(7, 396);
            lblRunLabel11.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel11.Name = "lblRunLabel11";
            lblRunLabel11.Size = new Size(123, 25);
            lblRunLabel11.TabIndex = 13;
            lblRunLabel11.Text = "lblRunLabel11";
            // 
            // lblRunLabel12
            // 
            lblRunLabel12.AutoSize = true;
            lblRunLabel12.ForeColor = SystemColors.ButtonFace;
            lblRunLabel12.Location = new Point(7, 435);
            lblRunLabel12.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel12.Name = "lblRunLabel12";
            lblRunLabel12.Size = new Size(123, 25);
            lblRunLabel12.TabIndex = 2;
            lblRunLabel12.Text = "lblRunLabel12";
            // 
            // lblRunLabel13
            // 
            lblRunLabel13.AutoSize = true;
            lblRunLabel13.ForeColor = SystemColors.ButtonFace;
            lblRunLabel13.Location = new Point(7, 474);
            lblRunLabel13.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel13.Name = "lblRunLabel13";
            lblRunLabel13.Size = new Size(123, 25);
            lblRunLabel13.TabIndex = 3;
            lblRunLabel13.Text = "lblRunLabel13";
            // 
            // lblRunLabel10
            // 
            lblRunLabel10.AutoSize = true;
            lblRunLabel10.ForeColor = SystemColors.ButtonFace;
            lblRunLabel10.Location = new Point(7, 357);
            lblRunLabel10.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel10.Name = "lblRunLabel10";
            lblRunLabel10.Size = new Size(123, 25);
            lblRunLabel10.TabIndex = 12;
            lblRunLabel10.Text = "lblRunLabel10";
            // 
            // lblRunLabel9
            // 
            lblRunLabel9.AutoSize = true;
            lblRunLabel9.ForeColor = SystemColors.ButtonFace;
            lblRunLabel9.Location = new Point(7, 318);
            lblRunLabel9.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel9.Name = "lblRunLabel9";
            lblRunLabel9.Size = new Size(113, 25);
            lblRunLabel9.TabIndex = 11;
            lblRunLabel9.Text = "lblRunLabel9";
            // 
            // lblRunLabel7
            // 
            lblRunLabel7.AutoSize = true;
            lblRunLabel7.ForeColor = SystemColors.ButtonFace;
            lblRunLabel7.Location = new Point(7, 240);
            lblRunLabel7.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel7.Name = "lblRunLabel7";
            lblRunLabel7.Size = new Size(113, 25);
            lblRunLabel7.TabIndex = 1;
            lblRunLabel7.Text = "lblRunLabel7";
            // 
            // lblRunLabel14
            // 
            lblRunLabel14.AutoSize = true;
            lblRunLabel14.ForeColor = SystemColors.ButtonFace;
            lblRunLabel14.Location = new Point(7, 513);
            lblRunLabel14.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel14.Name = "lblRunLabel14";
            lblRunLabel14.Size = new Size(123, 25);
            lblRunLabel14.TabIndex = 5;
            lblRunLabel14.Text = "lblRunLabel14";
            // 
            // lblRunLabel2
            // 
            lblRunLabel2.AutoSize = true;
            lblRunLabel2.ForeColor = SystemColors.ButtonFace;
            lblRunLabel2.Location = new Point(7, 45);
            lblRunLabel2.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel2.Name = "lblRunLabel2";
            lblRunLabel2.Size = new Size(113, 25);
            lblRunLabel2.TabIndex = 1;
            lblRunLabel2.Text = "lblRunLabel2";
            // 
            // lblRunLabel8
            // 
            lblRunLabel8.AutoSize = true;
            lblRunLabel8.ForeColor = SystemColors.ButtonFace;
            lblRunLabel8.Location = new Point(7, 279);
            lblRunLabel8.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel8.Name = "lblRunLabel8";
            lblRunLabel8.Size = new Size(113, 25);
            lblRunLabel8.TabIndex = 6;
            lblRunLabel8.Text = "lblRunLabel8";
            // 
            // lblRunLabel1
            // 
            lblRunLabel1.AutoSize = true;
            lblRunLabel1.ForeColor = SystemColors.ButtonFace;
            lblRunLabel1.Location = new Point(7, 6);
            lblRunLabel1.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel1.Name = "lblRunLabel1";
            lblRunLabel1.Size = new Size(113, 25);
            lblRunLabel1.TabIndex = 0;
            lblRunLabel1.Text = "lblRunLabel1";
            // 
            // lblRunLabel3
            // 
            lblRunLabel3.AutoSize = true;
            lblRunLabel3.ForeColor = SystemColors.ButtonFace;
            lblRunLabel3.Location = new Point(7, 84);
            lblRunLabel3.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel3.Name = "lblRunLabel3";
            lblRunLabel3.Size = new Size(113, 25);
            lblRunLabel3.TabIndex = 4;
            lblRunLabel3.Text = "lblRunLabel3";
            // 
            // lblRunLabel4
            // 
            lblRunLabel4.AutoSize = true;
            lblRunLabel4.ForeColor = SystemColors.ButtonFace;
            lblRunLabel4.Location = new Point(7, 123);
            lblRunLabel4.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel4.Name = "lblRunLabel4";
            lblRunLabel4.Size = new Size(113, 25);
            lblRunLabel4.TabIndex = 6;
            lblRunLabel4.Text = "lblRunLabel4";
            // 
            // lblRunLabel5
            // 
            lblRunLabel5.AutoSize = true;
            lblRunLabel5.ForeColor = SystemColors.ButtonFace;
            lblRunLabel5.Location = new Point(7, 162);
            lblRunLabel5.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel5.Name = "lblRunLabel5";
            lblRunLabel5.Size = new Size(113, 25);
            lblRunLabel5.TabIndex = 8;
            lblRunLabel5.Text = "lblRunLabel5";
            // 
            // lblRunLabel6
            // 
            lblRunLabel6.AutoSize = true;
            lblRunLabel6.ForeColor = SystemColors.ButtonFace;
            lblRunLabel6.Location = new Point(7, 201);
            lblRunLabel6.Margin = new Padding(6, 5, 6, 0);
            lblRunLabel6.Name = "lblRunLabel6";
            lblRunLabel6.Size = new Size(113, 25);
            lblRunLabel6.TabIndex = 10;
            lblRunLabel6.Text = "lblRunLabel6";
            // 
            // tableLayoutPanelRunValues
            // 
            tableLayoutPanelRunValues.BackColor = SystemColors.ControlDarkDark;
            tableLayoutPanelRunValues.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelRunValues.ColumnCount = 2;
            tableLayoutPanelRunValues.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelRunValues.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 123F));
            tableLayoutPanelRunValues.Controls.Add(lblRunValue14, 0, 13);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue7, 0, 6);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue1, 0, 0);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue2, 0, 1);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue8, 0, 7);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue3, 0, 2);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue12, 0, 11);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue9, 0, 8);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue13, 0, 12);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue4, 0, 3);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue5, 0, 4);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue11, 0, 10);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue10, 0, 9);
            tableLayoutPanelRunValues.Controls.Add(lblRunValue6, 0, 5);
            tableLayoutPanelRunValues.Controls.Add(cmdUpdateResolution, 1, 7);
            tableLayoutPanelRunValues.Controls.Add(cmdRuntimeEnableToggle, 1, 3);
            tableLayoutPanelRunValues.Dock = DockStyle.Fill;
            tableLayoutPanelRunValues.Location = new Point(0, 0);
            tableLayoutPanelRunValues.Margin = new Padding(6, 5, 6, 5);
            tableLayoutPanelRunValues.Name = "tableLayoutPanelRunValues";
            tableLayoutPanelRunValues.RowCount = 17;
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelRunValues.Size = new Size(241, 677);
            tableLayoutPanelRunValues.TabIndex = 0;
            // 
            // lblRunValue14
            // 
            lblRunValue14.AutoSize = true;
            lblRunValue14.ForeColor = SystemColors.ButtonFace;
            lblRunValue14.Location = new Point(7, 513);
            lblRunValue14.Margin = new Padding(6, 5, 6, 0);
            lblRunValue14.Name = "lblRunValue14";
            lblRunValue14.Size = new Size(95, 33);
            lblRunValue14.TabIndex = 12;
            lblRunValue14.Text = "lblRunValue14";
            // 
            // lblRunValue7
            // 
            lblRunValue7.AutoSize = true;
            lblRunValue7.ForeColor = SystemColors.ButtonFace;
            lblRunValue7.Location = new Point(7, 240);
            lblRunValue7.Margin = new Padding(6, 5, 6, 0);
            lblRunValue7.Name = "lblRunValue7";
            lblRunValue7.Size = new Size(95, 33);
            lblRunValue7.TabIndex = 0;
            lblRunValue7.Text = "lblRunValue7";
            // 
            // lblRunValue1
            // 
            lblRunValue1.AutoSize = true;
            lblRunValue1.ForeColor = SystemColors.ButtonFace;
            lblRunValue1.Location = new Point(7, 6);
            lblRunValue1.Margin = new Padding(6, 5, 6, 0);
            lblRunValue1.Name = "lblRunValue1";
            lblRunValue1.Size = new Size(95, 33);
            lblRunValue1.TabIndex = 2;
            lblRunValue1.Text = "lblRunValue1";
            // 
            // lblRunValue2
            // 
            lblRunValue2.AutoSize = true;
            lblRunValue2.ForeColor = SystemColors.ButtonFace;
            lblRunValue2.Location = new Point(7, 45);
            lblRunValue2.Margin = new Padding(6, 5, 6, 0);
            lblRunValue2.Name = "lblRunValue2";
            lblRunValue2.Size = new Size(95, 33);
            lblRunValue2.TabIndex = 3;
            lblRunValue2.Text = "lblRunValue2";
            // 
            // lblRunValue8
            // 
            lblRunValue8.AutoSize = true;
            lblRunValue8.ForeColor = SystemColors.ButtonFace;
            lblRunValue8.Location = new Point(7, 279);
            lblRunValue8.Margin = new Padding(6, 5, 6, 0);
            lblRunValue8.Name = "lblRunValue8";
            lblRunValue8.Size = new Size(95, 33);
            lblRunValue8.TabIndex = 4;
            lblRunValue8.Text = "lblRunValue8";
            // 
            // lblRunValue3
            // 
            lblRunValue3.AutoSize = true;
            lblRunValue3.ForeColor = SystemColors.ButtonFace;
            lblRunValue3.Location = new Point(7, 84);
            lblRunValue3.Margin = new Padding(6, 5, 6, 0);
            lblRunValue3.Name = "lblRunValue3";
            lblRunValue3.Size = new Size(95, 33);
            lblRunValue3.TabIndex = 5;
            lblRunValue3.Text = "lblRunValue3";
            // 
            // lblRunValue12
            // 
            lblRunValue12.AutoSize = true;
            lblRunValue12.ForeColor = SystemColors.ButtonFace;
            lblRunValue12.Location = new Point(7, 435);
            lblRunValue12.Margin = new Padding(6, 5, 6, 0);
            lblRunValue12.Name = "lblRunValue12";
            lblRunValue12.Size = new Size(95, 33);
            lblRunValue12.TabIndex = 9;
            lblRunValue12.Text = "lblRunValue12";
            // 
            // lblRunValue9
            // 
            lblRunValue9.AutoSize = true;
            lblRunValue9.ForeColor = SystemColors.ButtonFace;
            lblRunValue9.Location = new Point(7, 318);
            lblRunValue9.Margin = new Padding(6, 5, 6, 0);
            lblRunValue9.Name = "lblRunValue9";
            lblRunValue9.Size = new Size(95, 33);
            lblRunValue9.TabIndex = 8;
            lblRunValue9.Text = "lblRunValue9";
            // 
            // lblRunValue13
            // 
            lblRunValue13.AutoSize = true;
            lblRunValue13.ForeColor = SystemColors.ButtonFace;
            lblRunValue13.Location = new Point(7, 474);
            lblRunValue13.Margin = new Padding(6, 5, 6, 0);
            lblRunValue13.Name = "lblRunValue13";
            lblRunValue13.Size = new Size(95, 33);
            lblRunValue13.TabIndex = 7;
            lblRunValue13.Text = "lblRunValue13";
            // 
            // lblRunValue4
            // 
            lblRunValue4.AutoSize = true;
            lblRunValue4.ForeColor = SystemColors.ButtonFace;
            lblRunValue4.Location = new Point(7, 123);
            lblRunValue4.Margin = new Padding(6, 5, 6, 0);
            lblRunValue4.Name = "lblRunValue4";
            lblRunValue4.Size = new Size(95, 33);
            lblRunValue4.TabIndex = 7;
            lblRunValue4.Text = "lblRunValue4";
            // 
            // lblRunValue5
            // 
            lblRunValue5.AutoSize = true;
            lblRunValue5.ForeColor = SystemColors.ButtonFace;
            lblRunValue5.Location = new Point(7, 162);
            lblRunValue5.Margin = new Padding(6, 5, 6, 0);
            lblRunValue5.Name = "lblRunValue5";
            lblRunValue5.Size = new Size(95, 33);
            lblRunValue5.TabIndex = 9;
            lblRunValue5.Text = "lblRunValue5";
            // 
            // lblRunValue11
            // 
            lblRunValue11.AutoSize = true;
            lblRunValue11.ForeColor = SystemColors.ButtonFace;
            lblRunValue11.Location = new Point(7, 396);
            lblRunValue11.Margin = new Padding(6, 5, 6, 0);
            lblRunValue11.Name = "lblRunValue11";
            lblRunValue11.Size = new Size(95, 33);
            lblRunValue11.TabIndex = 11;
            lblRunValue11.Text = "lblRunValue11";
            // 
            // lblRunValue10
            // 
            lblRunValue10.AutoSize = true;
            lblRunValue10.ForeColor = SystemColors.ButtonFace;
            lblRunValue10.Location = new Point(7, 357);
            lblRunValue10.Margin = new Padding(6, 5, 6, 0);
            lblRunValue10.Name = "lblRunValue10";
            lblRunValue10.Size = new Size(95, 33);
            lblRunValue10.TabIndex = 10;
            lblRunValue10.Text = "lblRunValue10";
            // 
            // lblRunValue6
            // 
            lblRunValue6.AutoSize = true;
            lblRunValue6.ForeColor = SystemColors.ButtonFace;
            lblRunValue6.Location = new Point(7, 201);
            lblRunValue6.Margin = new Padding(6, 5, 6, 0);
            lblRunValue6.Name = "lblRunValue6";
            lblRunValue6.Size = new Size(95, 33);
            lblRunValue6.TabIndex = 11;
            lblRunValue6.Text = "lblRunValue6";
            // 
            // cmdUpdateResolution
            // 
            cmdUpdateResolution.Dock = DockStyle.Fill;
            cmdUpdateResolution.Location = new Point(117, 274);
            cmdUpdateResolution.Margin = new Padding(0);
            cmdUpdateResolution.Name = "cmdUpdateResolution";
            cmdUpdateResolution.Size = new Size(123, 38);
            cmdUpdateResolution.TabIndex = 13;
            cmdUpdateResolution.Text = "...";
            cmdUpdateResolution.UseVisualStyleBackColor = true;
            cmdUpdateResolution.Click += cmdUpdateResolution_Click;
            // 
            // cmdRuntimeEnableToggle
            // 
            cmdRuntimeEnableToggle.Dock = DockStyle.Fill;
            cmdRuntimeEnableToggle.Location = new Point(117, 118);
            cmdRuntimeEnableToggle.Margin = new Padding(0);
            cmdRuntimeEnableToggle.Name = "cmdRuntimeEnableToggle";
            cmdRuntimeEnableToggle.Size = new Size(123, 38);
            cmdRuntimeEnableToggle.TabIndex = 14;
            cmdRuntimeEnableToggle.Text = "...";
            cmdRuntimeEnableToggle.UseVisualStyleBackColor = true;
            cmdRuntimeEnableToggle.Click += cmdRuntimeEnableToggle_Click;
            // 
            // tabSchedule
            // 
            tabSchedule.Location = new Point(4, 34);
            tabSchedule.Margin = new Padding(6, 5, 6, 5);
            tabSchedule.Name = "tabSchedule";
            tabSchedule.Size = new Size(416, 1444);
            tabSchedule.TabIndex = 2;
            tabSchedule.Text = "Schedule";
            tabSchedule.UseVisualStyleBackColor = true;
            // 
            // PanelThread
            // 
            PanelThread.Controls.Add(splitContainerThreadMain);
            PanelThread.Location = new Point(9, 297);
            PanelThread.Margin = new Padding(6, 5, 6, 5);
            PanelThread.Name = "PanelThread";
            PanelThread.Size = new Size(2377, 1265);
            PanelThread.TabIndex = 0;
            // 
            // splitContainerThreadMain
            // 
            splitContainerThreadMain.Dock = DockStyle.Fill;
            splitContainerThreadMain.FixedPanel = FixedPanel.Panel2;
            splitContainerThreadMain.Location = new Point(0, 0);
            splitContainerThreadMain.Name = "splitContainerThreadMain";
            // 
            // splitContainerThreadMain.Panel1
            // 
            splitContainerThreadMain.Panel1.Controls.Add(splitContainerThread);
            // 
            // splitContainerThreadMain.Panel2
            // 
            splitContainerThreadMain.Panel2.Controls.Add(lstGamePass);
            splitContainerThreadMain.Panel2MinSize = 120;
            splitContainerThreadMain.Size = new Size(2377, 1265);
            splitContainerThreadMain.SplitterDistance = 1963;
            splitContainerThreadMain.TabIndex = 1;
            // 
            // splitContainerThread
            // 
            splitContainerThread.Dock = DockStyle.Fill;
            splitContainerThread.FixedPanel = FixedPanel.Panel1;
            splitContainerThread.Location = new Point(0, 0);
            splitContainerThread.Margin = new Padding(6, 5, 6, 5);
            splitContainerThread.Name = "splitContainerThread";
            splitContainerThread.Orientation = Orientation.Horizontal;
            // 
            // splitContainerThread.Panel1
            // 
            splitContainerThread.Panel1.Controls.Add(splitContainerStatsNScrollie);
            // 
            // splitContainerThread.Panel2
            // 
            splitContainerThread.Panel2.Controls.Add(appTestStudioStatusControl1);
            splitContainerThread.Size = new Size(1963, 1265);
            splitContainerThread.SplitterDistance = 330;
            splitContainerThread.SplitterWidth = 8;
            splitContainerThread.TabIndex = 1;
            // 
            // splitContainerStatsNScrollie
            // 
            splitContainerStatsNScrollie.Dock = DockStyle.Fill;
            splitContainerStatsNScrollie.FixedPanel = FixedPanel.Panel2;
            splitContainerStatsNScrollie.Location = new Point(0, 0);
            splitContainerStatsNScrollie.Margin = new Padding(6, 5, 6, 5);
            splitContainerStatsNScrollie.Name = "splitContainerStatsNScrollie";
            splitContainerStatsNScrollie.Orientation = Orientation.Horizontal;
            // 
            // splitContainerStatsNScrollie.Panel1
            // 
            splitContainerStatsNScrollie.Panel1.Controls.Add(tableLayoutStats);
            // 
            // splitContainerStatsNScrollie.Panel2
            // 
            splitContainerStatsNScrollie.Panel2.Controls.Add(splitContainerSeconds);
            splitContainerStatsNScrollie.Size = new Size(1963, 330);
            splitContainerStatsNScrollie.SplitterDistance = 264;
            splitContainerStatsNScrollie.SplitterWidth = 8;
            splitContainerStatsNScrollie.TabIndex = 2;
            // 
            // tableLayoutStats
            // 
            tableLayoutStats.AutoSize = true;
            tableLayoutStats.ColumnCount = 4;
            tableLayoutStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutStats.Controls.Add(groupTotal, 0, 0);
            tableLayoutStats.Controls.Add(groupSession, 0, 0);
            tableLayoutStats.Controls.Add(grpCPU, 2, 0);
            tableLayoutStats.Controls.Add(grpAPS, 3, 0);
            tableLayoutStats.Dock = DockStyle.Fill;
            tableLayoutStats.Location = new Point(0, 0);
            tableLayoutStats.Margin = new Padding(6, 5, 6, 5);
            tableLayoutStats.Name = "tableLayoutStats";
            tableLayoutStats.RowCount = 1;
            tableLayoutStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutStats.Size = new Size(1963, 264);
            tableLayoutStats.TabIndex = 3;
            // 
            // groupTotal
            // 
            groupTotal.Controls.Add(tableLayoutPanel1);
            groupTotal.Dock = DockStyle.Fill;
            groupTotal.Location = new Point(496, 5);
            groupTotal.Margin = new Padding(6, 5, 6, 5);
            groupTotal.Name = "groupTotal";
            groupTotal.Padding = new Padding(6, 5, 6, 5);
            groupTotal.Size = new Size(478, 254);
            groupTotal.TabIndex = 2;
            groupTotal.TabStop = false;
            groupTotal.Text = "Total";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 126F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label13, 0, 0);
            tableLayoutPanel1.Controls.Add(lblHomeTotal, 1, 2);
            tableLayoutPanel1.Controls.Add(label15, 0, 1);
            tableLayoutPanel1.Controls.Add(lblChildTotal, 1, 4);
            tableLayoutPanel1.Controls.Add(lblContinueTotal, 1, 3);
            tableLayoutPanel1.Controls.Add(label21, 0, 2);
            tableLayoutPanel1.Controls.Add(label20, 0, 5);
            tableLayoutPanel1.Controls.Add(lblWaitingTotal, 1, 5);
            tableLayoutPanel1.Controls.Add(lblScreenshotsTotal, 1, 0);
            tableLayoutPanel1.Controls.Add(label19, 0, 4);
            tableLayoutPanel1.Controls.Add(lblClickCountTotal, 1, 1);
            tableLayoutPanel1.Controls.Add(label14, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(6, 29);
            tableLayoutPanel1.Margin = new Padding(6, 5, 6, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.Size = new Size(466, 220);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 0);
            label13.Margin = new Padding(6, 0, 6, 0);
            label13.Name = "label13";
            label13.Size = new Size(111, 25);
            label13.TabIndex = 0;
            label13.Text = "Screenshots:";
            // 
            // lblHomeTotal
            // 
            lblHomeTotal.AutoSize = true;
            lblHomeTotal.Location = new Point(132, 74);
            lblHomeTotal.Margin = new Padding(6, 0, 6, 0);
            lblHomeTotal.Name = "lblHomeTotal";
            lblHomeTotal.Size = new Size(117, 25);
            lblHomeTotal.TabIndex = 2;
            lblHomeTotal.Text = "lblHomeTotal";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 37);
            label15.Margin = new Padding(6, 0, 6, 0);
            label15.Name = "label15";
            label15.Size = new Size(60, 25);
            label15.TabIndex = 1;
            label15.Text = "Clicks:";
            // 
            // lblChildTotal
            // 
            lblChildTotal.AutoSize = true;
            lblChildTotal.Location = new Point(132, 148);
            lblChildTotal.Margin = new Padding(6, 0, 6, 0);
            lblChildTotal.Name = "lblChildTotal";
            lblChildTotal.Size = new Size(108, 25);
            lblChildTotal.TabIndex = 1;
            lblChildTotal.Text = "lblChildTotal";
            // 
            // lblContinueTotal
            // 
            lblContinueTotal.AutoSize = true;
            lblContinueTotal.Location = new Point(132, 111);
            lblContinueTotal.Margin = new Padding(6, 0, 6, 0);
            lblContinueTotal.Name = "lblContinueTotal";
            lblContinueTotal.Size = new Size(139, 25);
            lblContinueTotal.TabIndex = 0;
            lblContinueTotal.Text = "lblContinueTotal";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(6, 74);
            label21.Margin = new Padding(6, 0, 6, 0);
            label21.Name = "label21";
            label21.Size = new Size(65, 25);
            label21.TabIndex = 2;
            label21.Text = "Home:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 185);
            label20.Margin = new Padding(6, 0, 6, 0);
            label20.Name = "label20";
            label20.Size = new Size(76, 25);
            label20.TabIndex = 2;
            label20.Text = "Waiting:";
            // 
            // lblWaitingTotal
            // 
            lblWaitingTotal.AutoSize = true;
            lblWaitingTotal.Location = new Point(132, 185);
            lblWaitingTotal.Margin = new Padding(6, 0, 6, 0);
            lblWaitingTotal.Name = "lblWaitingTotal";
            lblWaitingTotal.Size = new Size(128, 25);
            lblWaitingTotal.TabIndex = 2;
            lblWaitingTotal.Text = "lblWaitingTotal";
            // 
            // lblScreenshotsTotal
            // 
            lblScreenshotsTotal.AutoSize = true;
            lblScreenshotsTotal.Location = new Point(132, 0);
            lblScreenshotsTotal.Margin = new Padding(6, 0, 6, 0);
            lblScreenshotsTotal.Name = "lblScreenshotsTotal";
            lblScreenshotsTotal.Size = new Size(163, 25);
            lblScreenshotsTotal.TabIndex = 0;
            lblScreenshotsTotal.Text = "lblScreenshotsTotal";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 148);
            label19.Margin = new Padding(6, 0, 6, 0);
            label19.Name = "label19";
            label19.Size = new Size(56, 25);
            label19.TabIndex = 1;
            label19.Text = "Child:";
            // 
            // lblClickCountTotal
            // 
            lblClickCountTotal.AutoSize = true;
            lblClickCountTotal.Location = new Point(132, 37);
            lblClickCountTotal.Margin = new Padding(6, 0, 6, 0);
            lblClickCountTotal.Name = "lblClickCountTotal";
            lblClickCountTotal.Size = new Size(152, 25);
            lblClickCountTotal.TabIndex = 1;
            lblClickCountTotal.Text = "lblClickCountTotal";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 111);
            label14.Margin = new Padding(6, 0, 6, 0);
            label14.Name = "label14";
            label14.Size = new Size(87, 25);
            label14.TabIndex = 0;
            label14.Text = "Continue:";
            // 
            // groupSession
            // 
            groupSession.Controls.Add(tableLayoutPanelSession);
            groupSession.Dock = DockStyle.Fill;
            groupSession.Location = new Point(6, 5);
            groupSession.Margin = new Padding(6, 5, 6, 5);
            groupSession.Name = "groupSession";
            groupSession.Padding = new Padding(6, 5, 6, 5);
            groupSession.Size = new Size(478, 254);
            groupSession.TabIndex = 1;
            groupSession.TabStop = false;
            groupSession.Text = "Session";
            // 
            // tableLayoutPanelSession
            // 
            tableLayoutPanelSession.AutoSize = true;
            tableLayoutPanelSession.ColumnCount = 2;
            tableLayoutPanelSession.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 126F));
            tableLayoutPanelSession.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelSession.Controls.Add(label1, 0, 0);
            tableLayoutPanelSession.Controls.Add(label3, 0, 5);
            tableLayoutPanelSession.Controls.Add(lblWaiting, 1, 5);
            tableLayoutPanelSession.Controls.Add(label9, 0, 2);
            tableLayoutPanelSession.Controls.Add(lblHome, 1, 2);
            tableLayoutPanelSession.Controls.Add(lblScreenshots, 1, 0);
            tableLayoutPanelSession.Controls.Add(label7, 0, 3);
            tableLayoutPanelSession.Controls.Add(lblContinue, 1, 3);
            tableLayoutPanelSession.Controls.Add(label2, 0, 1);
            tableLayoutPanelSession.Controls.Add(lblChild, 1, 4);
            tableLayoutPanelSession.Controls.Add(lblClickCount, 1, 1);
            tableLayoutPanelSession.Controls.Add(label8, 0, 4);
            tableLayoutPanelSession.Dock = DockStyle.Fill;
            tableLayoutPanelSession.Location = new Point(6, 29);
            tableLayoutPanelSession.Margin = new Padding(6, 5, 6, 5);
            tableLayoutPanelSession.Name = "tableLayoutPanelSession";
            tableLayoutPanelSession.RowCount = 6;
            tableLayoutPanelSession.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanelSession.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanelSession.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanelSession.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanelSession.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanelSession.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanelSession.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanelSession.Size = new Size(466, 220);
            tableLayoutPanelSession.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 0);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 0;
            label1.Text = "Screenshots:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 185);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(76, 25);
            label3.TabIndex = 2;
            label3.Text = "Waiting:";
            // 
            // lblWaiting
            // 
            lblWaiting.AutoSize = true;
            lblWaiting.Location = new Point(132, 185);
            lblWaiting.Margin = new Padding(6, 0, 6, 0);
            lblWaiting.Name = "lblWaiting";
            lblWaiting.Size = new Size(91, 25);
            lblWaiting.TabIndex = 2;
            lblWaiting.Text = "lblWaiting";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 74);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(65, 25);
            label9.TabIndex = 2;
            label9.Text = "Home:";
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.Location = new Point(132, 74);
            lblHome.Margin = new Padding(6, 0, 6, 0);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(80, 25);
            lblHome.TabIndex = 2;
            lblHome.Text = "lblHome";
            // 
            // lblScreenshots
            // 
            lblScreenshots.AutoSize = true;
            lblScreenshots.Location = new Point(132, 0);
            lblScreenshots.Margin = new Padding(6, 0, 6, 0);
            lblScreenshots.Name = "lblScreenshots";
            lblScreenshots.Size = new Size(126, 25);
            lblScreenshots.TabIndex = 0;
            lblScreenshots.Text = "lblScreenshots";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 111);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(87, 25);
            label7.TabIndex = 0;
            label7.Text = "Continue:";
            // 
            // lblContinue
            // 
            lblContinue.AutoSize = true;
            lblContinue.Location = new Point(132, 111);
            lblContinue.Margin = new Padding(6, 0, 6, 0);
            lblContinue.Name = "lblContinue";
            lblContinue.Size = new Size(102, 25);
            lblContinue.TabIndex = 0;
            lblContinue.Text = "lblContinue";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 37);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 1;
            label2.Text = "Clicks:";
            // 
            // lblChild
            // 
            lblChild.AutoSize = true;
            lblChild.Location = new Point(132, 148);
            lblChild.Margin = new Padding(6, 0, 6, 0);
            lblChild.Name = "lblChild";
            lblChild.Size = new Size(71, 25);
            lblChild.TabIndex = 1;
            lblChild.Text = "lblChild";
            // 
            // lblClickCount
            // 
            lblClickCount.AutoSize = true;
            lblClickCount.Location = new Point(132, 37);
            lblClickCount.Margin = new Padding(6, 0, 6, 0);
            lblClickCount.Name = "lblClickCount";
            lblClickCount.Size = new Size(115, 25);
            lblClickCount.TabIndex = 1;
            lblClickCount.Text = "lblClickCount";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 148);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(56, 25);
            label8.TabIndex = 1;
            label8.Text = "Child:";
            // 
            // grpCPU
            // 
            grpCPU.Controls.Add(atsGraph1);
            grpCPU.Dock = DockStyle.Fill;
            grpCPU.Location = new Point(986, 5);
            grpCPU.Margin = new Padding(6, 5, 6, 5);
            grpCPU.Name = "grpCPU";
            grpCPU.Padding = new Padding(6, 5, 6, 5);
            grpCPU.Size = new Size(478, 254);
            grpCPU.TabIndex = 3;
            grpCPU.TabStop = false;
            grpCPU.Text = "CPU";
            // 
            // atsGraph1
            // 
            atsGraph1.Dock = DockStyle.Fill;
            atsGraph1.Location = new Point(6, 29);
            atsGraph1.Margin = new Padding(6, 5, 6, 5);
            atsGraph1.Name = "atsGraph1";
            atsGraph1.Size = new Size(466, 220);
            atsGraph1.TabIndex = 0;
            // 
            // grpAPS
            // 
            grpAPS.Controls.Add(atsGraphActions1);
            grpAPS.Dock = DockStyle.Fill;
            grpAPS.Location = new Point(1476, 5);
            grpAPS.Margin = new Padding(6, 5, 6, 5);
            grpAPS.Name = "grpAPS";
            grpAPS.Padding = new Padding(6, 5, 6, 5);
            grpAPS.Size = new Size(481, 254);
            grpAPS.TabIndex = 4;
            grpAPS.TabStop = false;
            grpAPS.Text = "Clicks Per Second";
            // 
            // atsGraphActions1
            // 
            atsGraphActions1.Dock = DockStyle.Fill;
            atsGraphActions1.Location = new Point(6, 29);
            atsGraphActions1.Margin = new Padding(6, 5, 6, 5);
            atsGraphActions1.Name = "atsGraphActions1";
            atsGraphActions1.Size = new Size(469, 220);
            atsGraphActions1.TabIndex = 0;
            // 
            // splitContainerSeconds
            // 
            splitContainerSeconds.Dock = DockStyle.Bottom;
            splitContainerSeconds.Location = new Point(0, 21);
            splitContainerSeconds.Margin = new Padding(6, 5, 6, 5);
            splitContainerSeconds.Name = "splitContainerSeconds";
            // 
            // splitContainerSeconds.Panel1
            // 
            splitContainerSeconds.Panel1.BackColor = SystemColors.ControlLight;
            // 
            // splitContainerSeconds.Panel2
            // 
            splitContainerSeconds.Panel2.BackColor = SystemColors.ControlDark;
            splitContainerSeconds.Size = new Size(1963, 37);
            splitContainerSeconds.SplitterDistance = 303;
            splitContainerSeconds.SplitterWidth = 7;
            splitContainerSeconds.TabIndex = 0;
            // 
            // appTestStudioStatusControl1
            // 
            appTestStudioStatusControl1.Dock = DockStyle.Fill;
            appTestStudioStatusControl1.Items = (List<string>)resources.GetObject("appTestStudioStatusControl1.Items");
            appTestStudioStatusControl1.Location = new Point(0, 0);
            appTestStudioStatusControl1.Margin = new Padding(7, 10, 7, 10);
            appTestStudioStatusControl1.Name = "appTestStudioStatusControl1";
            appTestStudioStatusControl1.ShowPercent = 10L;
            appTestStudioStatusControl1.Size = new Size(1963, 927);
            appTestStudioStatusControl1.TabIndex = 0;
            // 
            // lstGamePass
            // 
            lstGamePass.Dock = DockStyle.Fill;
            lstGamePass.Items.AddRange(new ListViewItem[] { listViewItem1 });
            lstGamePass.Location = new Point(0, 0);
            lstGamePass.Name = "lstGamePass";
            lstGamePass.Size = new Size(410, 1265);
            lstGamePass.TabIndex = 0;
            lstGamePass.UseCompatibleStateImageBehavior = false;
            // 
            // PanelColorEvent
            // 
            PanelColorEvent.Controls.Add(tableColorEvent);
            PanelColorEvent.Location = new Point(26, 140);
            PanelColorEvent.Margin = new Padding(6, 5, 6, 5);
            PanelColorEvent.Name = "PanelColorEvent";
            PanelColorEvent.Size = new Size(2133, 1337);
            PanelColorEvent.TabIndex = 14;
            // 
            // tableColorEvent
            // 
            tableColorEvent.ColumnCount = 3;
            tableColorEvent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableColorEvent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableColorEvent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 483F));
            tableColorEvent.Controls.Add(panelColorEventChild1, 0, 0);
            tableColorEvent.Controls.Add(FlowLayoutPanelColorEvent1, 1, 0);
            tableColorEvent.Controls.Add(FlowLayoutPanelColorEvent2, 2, 0);
            tableColorEvent.Dock = DockStyle.Fill;
            tableColorEvent.Location = new Point(0, 0);
            tableColorEvent.Name = "tableColorEvent";
            tableColorEvent.RowCount = 1;
            tableColorEvent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableColorEvent.Size = new Size(2133, 1337);
            tableColorEvent.TabIndex = 33;
            tableColorEvent.Paint += tableLayoutPanel2_Paint;
            // 
            // panelColorEventChild1
            // 
            panelColorEventChild1.Controls.Add(cmdTakeParentScreenshot);
            panelColorEventChild1.Controls.Add(grpEventMode);
            panelColorEventChild1.Controls.Add(grpMode);
            panelColorEventChild1.Controls.Add(cmdTest);
            panelColorEventChild1.Controls.Add(cmdAddObject2);
            panelColorEventChild1.Controls.Add(PanelScreenshot);
            panelColorEventChild1.Controls.Add(label29);
            panelColorEventChild1.Controls.Add(txtEventName);
            panelColorEventChild1.Controls.Add(chkUseParentScreenshot);
            panelColorEventChild1.Controls.Add(cmdAddSingleColorAtSingleLocationTakeASceenshot);
            panelColorEventChild1.Dock = DockStyle.Fill;
            panelColorEventChild1.Location = new Point(3, 3);
            panelColorEventChild1.Name = "panelColorEventChild1";
            panelColorEventChild1.Size = new Size(1144, 1331);
            panelColorEventChild1.TabIndex = 0;
            // 
            // cmdTakeParentScreenshot
            // 
            cmdTakeParentScreenshot.Location = new Point(7, 87);
            cmdTakeParentScreenshot.Margin = new Padding(6, 5, 6, 5);
            cmdTakeParentScreenshot.Name = "cmdTakeParentScreenshot";
            cmdTakeParentScreenshot.Size = new Size(220, 45);
            cmdTakeParentScreenshot.TabIndex = 32;
            cmdTakeParentScreenshot.Text = "Take Parent Screenshot";
            cmdTakeParentScreenshot.UseVisualStyleBackColor = true;
            cmdTakeParentScreenshot.Click += cmdTakeParentScreenshot_Click;
            // 
            // grpEventMode
            // 
            grpEventMode.Controls.Add(rdoObjectSearch);
            grpEventMode.Controls.Add(rdoColorPoint);
            grpEventMode.Controls.Add(lblMode);
            grpEventMode.Location = new Point(231, 12);
            grpEventMode.Margin = new Padding(6, 5, 6, 5);
            grpEventMode.Name = "grpEventMode";
            grpEventMode.Padding = new Padding(6, 5, 6, 5);
            grpEventMode.Size = new Size(187, 115);
            grpEventMode.TabIndex = 28;
            grpEventMode.TabStop = false;
            grpEventMode.Text = "Event Mode";
            // 
            // rdoObjectSearch
            // 
            rdoObjectSearch.AutoSize = true;
            rdoObjectSearch.Location = new Point(17, 73);
            rdoObjectSearch.Margin = new Padding(6, 5, 6, 5);
            rdoObjectSearch.Name = "rdoObjectSearch";
            rdoObjectSearch.Size = new Size(146, 29);
            rdoObjectSearch.TabIndex = 1;
            rdoObjectSearch.TabStop = true;
            rdoObjectSearch.Text = "Object Search";
            rdoObjectSearch.UseVisualStyleBackColor = true;
            rdoObjectSearch.CheckedChanged += rdoObjectSearch_CheckedChanged;
            // 
            // rdoColorPoint
            // 
            rdoColorPoint.AutoSize = true;
            rdoColorPoint.Location = new Point(17, 28);
            rdoColorPoint.Margin = new Padding(6, 5, 6, 5);
            rdoColorPoint.Name = "rdoColorPoint";
            rdoColorPoint.Size = new Size(127, 29);
            rdoColorPoint.TabIndex = 0;
            rdoColorPoint.TabStop = true;
            rdoColorPoint.Text = "Color/Point";
            rdoColorPoint.UseVisualStyleBackColor = true;
            rdoColorPoint.CheckedChanged += rdoColorPoint_CheckedChanged;
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(209, -3);
            lblMode.Margin = new Padding(6, 0, 6, 0);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(78, 25);
            lblMode.TabIndex = 12;
            lblMode.Text = "lblMode";
            lblMode.Visible = false;
            // 
            // grpMode
            // 
            grpMode.Controls.Add(rdoModeKeyboard);
            grpMode.Controls.Add(rdoModeMove);
            grpMode.Controls.Add(rdoModeClickDragRelease);
            grpMode.Controls.Add(rdoModeRangeClick);
            grpMode.Location = new Point(429, 12);
            grpMode.Margin = new Padding(6, 5, 6, 5);
            grpMode.Name = "grpMode";
            grpMode.Padding = new Padding(6, 5, 6, 5);
            grpMode.Size = new Size(230, 115);
            grpMode.TabIndex = 21;
            grpMode.TabStop = false;
            grpMode.Text = "Mode";
            // 
            // rdoModeKeyboard
            // 
            rdoModeKeyboard.AutoSize = true;
            rdoModeKeyboard.Location = new Point(111, 67);
            rdoModeKeyboard.Margin = new Padding(6, 5, 6, 5);
            rdoModeKeyboard.Name = "rdoModeKeyboard";
            rdoModeKeyboard.Size = new Size(113, 29);
            rdoModeKeyboard.TabIndex = 3;
            rdoModeKeyboard.TabStop = true;
            rdoModeKeyboard.Text = "Keyboard";
            rdoModeKeyboard.UseVisualStyleBackColor = true;
            rdoModeKeyboard.CheckedChanged += rdoModeKeyboard_CheckedChanged;
            // 
            // rdoModeMove
            // 
            rdoModeMove.AutoSize = true;
            rdoModeMove.Location = new Point(111, 28);
            rdoModeMove.Margin = new Padding(6, 5, 6, 5);
            rdoModeMove.Name = "rdoModeMove";
            rdoModeMove.Size = new Size(82, 29);
            rdoModeMove.TabIndex = 2;
            rdoModeMove.TabStop = true;
            rdoModeMove.Text = "Move";
            rdoModeMove.UseVisualStyleBackColor = true;
            rdoModeMove.CheckedChanged += rdoModeMove_CheckedChanged;
            // 
            // rdoModeClickDragRelease
            // 
            rdoModeClickDragRelease.AutoSize = true;
            rdoModeClickDragRelease.Location = new Point(10, 67);
            rdoModeClickDragRelease.Margin = new Padding(6, 5, 6, 5);
            rdoModeClickDragRelease.Name = "rdoModeClickDragRelease";
            rdoModeClickDragRelease.Size = new Size(84, 29);
            rdoModeClickDragRelease.TabIndex = 1;
            rdoModeClickDragRelease.Text = "Swipe";
            rdoModeClickDragRelease.UseVisualStyleBackColor = true;
            rdoModeClickDragRelease.CheckedChanged += rdoModeClickDragRelease_CheckedChanged;
            // 
            // rdoModeRangeClick
            // 
            rdoModeRangeClick.AutoSize = true;
            rdoModeRangeClick.Checked = true;
            rdoModeRangeClick.Location = new Point(10, 28);
            rdoModeRangeClick.Margin = new Padding(6, 5, 6, 5);
            rdoModeRangeClick.Name = "rdoModeRangeClick";
            rdoModeRangeClick.Size = new Size(73, 29);
            rdoModeRangeClick.TabIndex = 0;
            rdoModeRangeClick.TabStop = true;
            rdoModeRangeClick.Text = "Click";
            rdoModeRangeClick.UseVisualStyleBackColor = true;
            rdoModeRangeClick.CheckedChanged += rdoModeRangeClick_CheckedChanged;
            // 
            // cmdTest
            // 
            cmdTest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdTest.Font = new Font("Microsoft Sans Serif", 15.75F);
            cmdTest.Location = new Point(813, 60);
            cmdTest.Margin = new Padding(6, 5, 6, 5);
            cmdTest.Name = "cmdTest";
            cmdTest.Size = new Size(327, 63);
            cmdTest.TabIndex = 16;
            cmdTest.Text = "Test";
            cmdTest.UseVisualStyleBackColor = true;
            cmdTest.Click += cmdTest_Click;
            // 
            // cmdAddObject2
            // 
            cmdAddObject2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdAddObject2.Location = new Point(813, 10);
            cmdAddObject2.Margin = new Padding(6, 5, 6, 5);
            cmdAddObject2.Name = "cmdAddObject2";
            cmdAddObject2.Size = new Size(327, 45);
            cmdAddObject2.TabIndex = 31;
            cmdAddObject2.Text = "Create New Object With This Image";
            cmdAddObject2.UseVisualStyleBackColor = true;
            cmdAddObject2.Click += cmdAddObject2_Click;
            // 
            // PanelScreenshot
            // 
            PanelScreenshot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PanelScreenshot.AutoScroll = true;
            PanelScreenshot.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelScreenshot.Controls.Add(panelKeyboard);
            PanelScreenshot.Controls.Add(lblPictureMissing);
            PanelScreenshot.Controls.Add(PictureBox1);
            PanelScreenshot.Location = new Point(7, 185);
            PanelScreenshot.Margin = new Padding(6, 5, 6, 5);
            PanelScreenshot.Name = "PanelScreenshot";
            PanelScreenshot.Size = new Size(1133, 1141);
            PanelScreenshot.TabIndex = 7;
            // 
            // panelKeyboard
            // 
            panelKeyboard.BackColor = SystemColors.Control;
            panelKeyboard.Controls.Add(label97);
            panelKeyboard.Controls.Add(grpInsertWeights);
            panelKeyboard.Controls.Add(groupBox21);
            panelKeyboard.Controls.Add(cmdKeyboardValidate);
            panelKeyboard.Controls.Add(txtKeyboard);
            panelKeyboard.Location = new Point(0, 0);
            panelKeyboard.Margin = new Padding(6, 5, 6, 5);
            panelKeyboard.Name = "panelKeyboard";
            panelKeyboard.Size = new Size(1281, 997);
            panelKeyboard.TabIndex = 2;
            panelKeyboard.Visible = false;
            // 
            // label97
            // 
            label97.Location = new Point(11, 652);
            label97.Margin = new Padding(6, 0, 6, 0);
            label97.Name = "label97";
            label97.Size = new Size(893, 188);
            label97.TabIndex = 21;
            label97.Text = resources.GetString("label97.Text");
            // 
            // grpInsertWeights
            // 
            grpInsertWeights.Controls.Add(label96);
            grpInsertWeights.Controls.Add(cmdWait3);
            grpInsertWeights.Controls.Add(cmdWait2);
            grpInsertWeights.Controls.Add(cmdWait1);
            grpInsertWeights.Controls.Add(numericWait3);
            grpInsertWeights.Controls.Add(numericWait2);
            grpInsertWeights.Controls.Add(numericWait1);
            grpInsertWeights.Location = new Point(841, 27);
            grpInsertWeights.Margin = new Padding(6, 5, 6, 5);
            grpInsertWeights.Name = "grpInsertWeights";
            grpInsertWeights.Padding = new Padding(6, 5, 6, 5);
            grpInsertWeights.Size = new Size(337, 563);
            grpInsertWeights.TabIndex = 20;
            grpInsertWeights.TabStop = false;
            grpInsertWeights.Text = "Insert Wait Times (ms)";
            // 
            // label96
            // 
            label96.Location = new Point(13, 195);
            label96.Margin = new Padding(6, 0, 6, 0);
            label96.Name = "label96";
            label96.Size = new Size(323, 375);
            label96.TabIndex = 3;
            label96.Text = resources.GetString("label96.Text");
            // 
            // cmdWait3
            // 
            cmdWait3.Location = new Point(153, 130);
            cmdWait3.Margin = new Padding(6, 5, 6, 5);
            cmdWait3.Name = "cmdWait3";
            cmdWait3.Size = new Size(157, 45);
            cmdWait3.TabIndex = 2;
            cmdWait3.Text = "Custom";
            cmdWait3.UseVisualStyleBackColor = true;
            cmdWait3.Click += cmdWait3_Click;
            // 
            // cmdWait2
            // 
            cmdWait2.Location = new Point(153, 78);
            cmdWait2.Margin = new Padding(6, 5, 6, 5);
            cmdWait2.Name = "cmdWait2";
            cmdWait2.Size = new Size(157, 45);
            cmdWait2.TabIndex = 2;
            cmdWait2.Text = "Normal Press";
            cmdWait2.UseVisualStyleBackColor = true;
            cmdWait2.Click += cmdWait2_Click;
            // 
            // cmdWait1
            // 
            cmdWait1.Location = new Point(153, 30);
            cmdWait1.Margin = new Padding(6, 5, 6, 5);
            cmdWait1.Name = "cmdWait1";
            cmdWait1.Size = new Size(159, 45);
            cmdWait1.TabIndex = 1;
            cmdWait1.Text = "Quick Tap";
            cmdWait1.UseVisualStyleBackColor = true;
            cmdWait1.Click += cmdWait1_Click;
            // 
            // numericWait3
            // 
            numericWait3.Location = new Point(13, 128);
            numericWait3.Margin = new Padding(6, 5, 6, 5);
            numericWait3.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericWait3.Name = "numericWait3";
            numericWait3.Size = new Size(130, 31);
            numericWait3.TabIndex = 0;
            numericWait3.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // numericWait2
            // 
            numericWait2.Location = new Point(13, 78);
            numericWait2.Margin = new Padding(6, 5, 6, 5);
            numericWait2.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericWait2.Name = "numericWait2";
            numericWait2.Size = new Size(130, 31);
            numericWait2.TabIndex = 0;
            numericWait2.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // numericWait1
            // 
            numericWait1.Location = new Point(13, 30);
            numericWait1.Margin = new Padding(6, 5, 6, 5);
            numericWait1.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericWait1.Name = "numericWait1";
            numericWait1.Size = new Size(130, 31);
            numericWait1.TabIndex = 0;
            numericWait1.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // groupBox21
            // 
            groupBox21.Controls.Add(chkKeyboardSpace);
            groupBox21.Controls.Add(chkKeyboardA);
            groupBox21.Controls.Add(chkKeyboardTilde);
            groupBox21.Controls.Add(chkKeyboardTab);
            groupBox21.Controls.Add(chkKeyboardCapsLock);
            groupBox21.Controls.Add(chkKeyboardLeft);
            groupBox21.Controls.Add(chkKeyboardF12);
            groupBox21.Controls.Add(chkKeyboardRight);
            groupBox21.Controls.Add(chkKeyboardDown);
            groupBox21.Controls.Add(chkKeyboardLeftShift);
            groupBox21.Controls.Add(chkKeyboardPageDown);
            groupBox21.Controls.Add(chkKeyboardEnd);
            groupBox21.Controls.Add(chkKeyboardDelete);
            groupBox21.Controls.Add(chkKeyboardPageUp);
            groupBox21.Controls.Add(chkKeyboardHome);
            groupBox21.Controls.Add(chkKeyboardIns);
            groupBox21.Controls.Add(chkKeyboardUp);
            groupBox21.Controls.Add(chkKeyboardF11);
            groupBox21.Controls.Add(chkKeyboardRightShift);
            groupBox21.Controls.Add(chkKeyboardF8);
            groupBox21.Controls.Add(chkKeyboardLeftCtrl);
            groupBox21.Controls.Add(chkKeyboardF10);
            groupBox21.Controls.Add(chkKeyboardMnu);
            groupBox21.Controls.Add(chkKeyboardRightCtrl);
            groupBox21.Controls.Add(chkKeyboardF7);
            groupBox21.Controls.Add(chkKeyboardLeftAlt);
            groupBox21.Controls.Add(chkKeyboardF9);
            groupBox21.Controls.Add(chkKeyboardRightAlt);
            groupBox21.Controls.Add(chkKeyboardF6);
            groupBox21.Controls.Add(chkKeyboardLeftWin);
            groupBox21.Controls.Add(chkKeyboardF5);
            groupBox21.Controls.Add(chkKeyboardRightWin);
            groupBox21.Controls.Add(chkKeyboardF4);
            groupBox21.Controls.Add(chkKeyboardF3);
            groupBox21.Controls.Add(chkKeyboardB);
            groupBox21.Controls.Add(chkKeyboardF2);
            groupBox21.Controls.Add(chkKeyboardC);
            groupBox21.Controls.Add(chkKeyboardF1);
            groupBox21.Controls.Add(chkKeyboardD);
            groupBox21.Controls.Add(chkKeyboardESC);
            groupBox21.Controls.Add(chkKeyboardE);
            groupBox21.Controls.Add(chkKeyboardBackspace);
            groupBox21.Controls.Add(chkKeyboardF);
            groupBox21.Controls.Add(chkKeyboardPlus);
            groupBox21.Controls.Add(chkKeyboardG);
            groupBox21.Controls.Add(chkKeyboardDash);
            groupBox21.Controls.Add(chkKeyboardH);
            groupBox21.Controls.Add(chkKeyboard0);
            groupBox21.Controls.Add(chkKeyboardI);
            groupBox21.Controls.Add(chkKeyboard9);
            groupBox21.Controls.Add(chkKeyboardJ);
            groupBox21.Controls.Add(chkKeyboard8);
            groupBox21.Controls.Add(chkKeyboardK);
            groupBox21.Controls.Add(chkKeyboard7);
            groupBox21.Controls.Add(chkKeyboardL);
            groupBox21.Controls.Add(chkKeyboard6);
            groupBox21.Controls.Add(chkKeyboardM);
            groupBox21.Controls.Add(chkKeyboard5);
            groupBox21.Controls.Add(chkKeyboardComma);
            groupBox21.Controls.Add(chkKeyboard4);
            groupBox21.Controls.Add(chkKeyboardPeriod);
            groupBox21.Controls.Add(chkKeyboard3);
            groupBox21.Controls.Add(chkKeyboardSlash);
            groupBox21.Controls.Add(chkKeyboard2);
            groupBox21.Controls.Add(chkKeyboardSemicolon);
            groupBox21.Controls.Add(chkKeyboard1);
            groupBox21.Controls.Add(chkKeyboardQuote);
            groupBox21.Controls.Add(chkKeyboardZ);
            groupBox21.Controls.Add(chkKeyboardEnter);
            groupBox21.Controls.Add(chkKeyboardY);
            groupBox21.Controls.Add(chkKeyboardN);
            groupBox21.Controls.Add(chkKeyboardX);
            groupBox21.Controls.Add(chkKeyboardO);
            groupBox21.Controls.Add(chkKeyboardW);
            groupBox21.Controls.Add(chkKeyboardP);
            groupBox21.Controls.Add(chkKeyboardV);
            groupBox21.Controls.Add(chkKeyboardLeftBracket);
            groupBox21.Controls.Add(chkKeyboardU);
            groupBox21.Controls.Add(chkKeyboardRightBracket);
            groupBox21.Controls.Add(chkKeyboardT);
            groupBox21.Controls.Add(chkKeyboardBackslash);
            groupBox21.Controls.Add(chkKeyboardS);
            groupBox21.Controls.Add(chkKeyboardQ);
            groupBox21.Controls.Add(chkKeyboardR);
            groupBox21.Location = new Point(10, 12);
            groupBox21.Margin = new Padding(6, 5, 6, 5);
            groupBox21.Name = "groupBox21";
            groupBox21.Padding = new Padding(6, 5, 6, 5);
            groupBox21.Size = new Size(820, 367);
            groupBox21.TabIndex = 19;
            groupBox21.TabStop = false;
            groupBox21.Text = "Press";
            // 
            // chkKeyboardSpace
            // 
            chkKeyboardSpace.Appearance = Appearance.Button;
            chkKeyboardSpace.Location = new Point(197, 305);
            chkKeyboardSpace.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardSpace.Name = "chkKeyboardSpace";
            chkKeyboardSpace.Size = new Size(231, 47);
            chkKeyboardSpace.TabIndex = 9;
            chkKeyboardSpace.Tag = "SPACE";
            chkKeyboardSpace.Text = "Space";
            chkKeyboardSpace.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardSpace.UseVisualStyleBackColor = true;
            chkKeyboardSpace.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardA
            // 
            chkKeyboardA.Appearance = Appearance.Button;
            chkKeyboardA.Location = new Point(103, 198);
            chkKeyboardA.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardA.Name = "chkKeyboardA";
            chkKeyboardA.Size = new Size(40, 47);
            chkKeyboardA.TabIndex = 9;
            chkKeyboardA.Tag = "a";
            chkKeyboardA.Text = "A";
            chkKeyboardA.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardA.UseVisualStyleBackColor = true;
            chkKeyboardA.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardTilde
            // 
            chkKeyboardTilde.Appearance = Appearance.Button;
            chkKeyboardTilde.Location = new Point(29, 90);
            chkKeyboardTilde.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardTilde.Name = "chkKeyboardTilde";
            chkKeyboardTilde.Size = new Size(40, 47);
            chkKeyboardTilde.TabIndex = 9;
            chkKeyboardTilde.Tag = "~";
            chkKeyboardTilde.Text = "~";
            chkKeyboardTilde.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardTilde.UseVisualStyleBackColor = true;
            chkKeyboardTilde.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardTab
            // 
            chkKeyboardTab.Appearance = Appearance.Button;
            chkKeyboardTab.Location = new Point(27, 145);
            chkKeyboardTab.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardTab.Name = "chkKeyboardTab";
            chkKeyboardTab.Size = new Size(71, 47);
            chkKeyboardTab.TabIndex = 9;
            chkKeyboardTab.Tag = "TAB";
            chkKeyboardTab.Text = "Tab";
            chkKeyboardTab.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardTab.UseVisualStyleBackColor = true;
            chkKeyboardTab.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardCapsLock
            // 
            chkKeyboardCapsLock.Appearance = Appearance.Button;
            chkKeyboardCapsLock.Location = new Point(29, 198);
            chkKeyboardCapsLock.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardCapsLock.Name = "chkKeyboardCapsLock";
            chkKeyboardCapsLock.Size = new Size(71, 47);
            chkKeyboardCapsLock.TabIndex = 9;
            chkKeyboardCapsLock.Tag = "CAPS";
            chkKeyboardCapsLock.Text = "Caps";
            chkKeyboardCapsLock.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardCapsLock.UseVisualStyleBackColor = true;
            chkKeyboardCapsLock.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardLeft
            // 
            chkKeyboardLeft.Appearance = Appearance.Button;
            chkKeyboardLeft.Location = new Point(677, 305);
            chkKeyboardLeft.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardLeft.Name = "chkKeyboardLeft";
            chkKeyboardLeft.Size = new Size(40, 47);
            chkKeyboardLeft.TabIndex = 13;
            chkKeyboardLeft.Tag = "LEFT";
            chkKeyboardLeft.Text = "L";
            chkKeyboardLeft.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardLeft.UseVisualStyleBackColor = true;
            chkKeyboardLeft.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF12
            // 
            chkKeyboardF12.Appearance = Appearance.Button;
            chkKeyboardF12.Font = new Font("Microsoft Sans Serif", 5F);
            chkKeyboardF12.Location = new Point(611, 37);
            chkKeyboardF12.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF12.Name = "chkKeyboardF12";
            chkKeyboardF12.Size = new Size(40, 47);
            chkKeyboardF12.TabIndex = 14;
            chkKeyboardF12.Tag = "F12";
            chkKeyboardF12.Text = "F12";
            chkKeyboardF12.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF12.UseVisualStyleBackColor = true;
            chkKeyboardF12.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardRight
            // 
            chkKeyboardRight.Appearance = Appearance.Button;
            chkKeyboardRight.Location = new Point(767, 305);
            chkKeyboardRight.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardRight.Name = "chkKeyboardRight";
            chkKeyboardRight.Size = new Size(40, 47);
            chkKeyboardRight.TabIndex = 13;
            chkKeyboardRight.Tag = "RIGHT";
            chkKeyboardRight.Text = "R";
            chkKeyboardRight.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardRight.UseVisualStyleBackColor = true;
            chkKeyboardRight.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardDown
            // 
            chkKeyboardDown.Appearance = Appearance.Button;
            chkKeyboardDown.Location = new Point(721, 305);
            chkKeyboardDown.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardDown.Name = "chkKeyboardDown";
            chkKeyboardDown.Size = new Size(40, 47);
            chkKeyboardDown.TabIndex = 13;
            chkKeyboardDown.Tag = "DOWN";
            chkKeyboardDown.Text = "Down";
            chkKeyboardDown.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardDown.UseVisualStyleBackColor = true;
            chkKeyboardDown.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardLeftShift
            // 
            chkKeyboardLeftShift.Appearance = Appearance.Button;
            chkKeyboardLeftShift.Location = new Point(29, 252);
            chkKeyboardLeftShift.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardLeftShift.Name = "chkKeyboardLeftShift";
            chkKeyboardLeftShift.Size = new Size(84, 47);
            chkKeyboardLeftShift.TabIndex = 9;
            chkKeyboardLeftShift.Tag = "LSHIFT";
            chkKeyboardLeftShift.Text = "L Shift";
            chkKeyboardLeftShift.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardLeftShift.UseVisualStyleBackColor = true;
            chkKeyboardLeftShift.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardPageDown
            // 
            chkKeyboardPageDown.Appearance = Appearance.Button;
            chkKeyboardPageDown.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardPageDown.Location = new Point(766, 198);
            chkKeyboardPageDown.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardPageDown.Name = "chkKeyboardPageDown";
            chkKeyboardPageDown.Size = new Size(40, 47);
            chkKeyboardPageDown.TabIndex = 13;
            chkKeyboardPageDown.Tag = "PGDOWN";
            chkKeyboardPageDown.Text = "Do";
            chkKeyboardPageDown.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardPageDown.UseVisualStyleBackColor = true;
            chkKeyboardPageDown.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardEnd
            // 
            chkKeyboardEnd.Appearance = Appearance.Button;
            chkKeyboardEnd.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardEnd.Location = new Point(721, 198);
            chkKeyboardEnd.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardEnd.Name = "chkKeyboardEnd";
            chkKeyboardEnd.Size = new Size(40, 47);
            chkKeyboardEnd.TabIndex = 13;
            chkKeyboardEnd.Tag = "{END}";
            chkKeyboardEnd.Text = "En";
            chkKeyboardEnd.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardEnd.UseVisualStyleBackColor = true;
            chkKeyboardEnd.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardDelete
            // 
            chkKeyboardDelete.Appearance = Appearance.Button;
            chkKeyboardDelete.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardDelete.Location = new Point(679, 198);
            chkKeyboardDelete.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardDelete.Name = "chkKeyboardDelete";
            chkKeyboardDelete.Size = new Size(40, 47);
            chkKeyboardDelete.TabIndex = 13;
            chkKeyboardDelete.Tag = "DELETE";
            chkKeyboardDelete.Text = "De";
            chkKeyboardDelete.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardDelete.UseVisualStyleBackColor = true;
            chkKeyboardDelete.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardPageUp
            // 
            chkKeyboardPageUp.Appearance = Appearance.Button;
            chkKeyboardPageUp.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardPageUp.Location = new Point(766, 145);
            chkKeyboardPageUp.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardPageUp.Name = "chkKeyboardPageUp";
            chkKeyboardPageUp.Size = new Size(40, 47);
            chkKeyboardPageUp.TabIndex = 13;
            chkKeyboardPageUp.Tag = "PGUP";
            chkKeyboardPageUp.Text = "Up";
            chkKeyboardPageUp.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardPageUp.UseVisualStyleBackColor = true;
            chkKeyboardPageUp.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardHome
            // 
            chkKeyboardHome.Appearance = Appearance.Button;
            chkKeyboardHome.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardHome.Location = new Point(721, 145);
            chkKeyboardHome.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardHome.Name = "chkKeyboardHome";
            chkKeyboardHome.Size = new Size(40, 47);
            chkKeyboardHome.TabIndex = 13;
            chkKeyboardHome.Tag = "HOME";
            chkKeyboardHome.Text = "Ho";
            chkKeyboardHome.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardHome.UseVisualStyleBackColor = true;
            chkKeyboardHome.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardIns
            // 
            chkKeyboardIns.Appearance = Appearance.Button;
            chkKeyboardIns.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardIns.Location = new Point(679, 145);
            chkKeyboardIns.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardIns.Name = "chkKeyboardIns";
            chkKeyboardIns.Size = new Size(40, 47);
            chkKeyboardIns.TabIndex = 13;
            chkKeyboardIns.Tag = "INSERT";
            chkKeyboardIns.Text = "Ins";
            chkKeyboardIns.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardIns.UseVisualStyleBackColor = true;
            chkKeyboardIns.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardUp
            // 
            chkKeyboardUp.Appearance = Appearance.Button;
            chkKeyboardUp.Location = new Point(721, 253);
            chkKeyboardUp.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardUp.Name = "chkKeyboardUp";
            chkKeyboardUp.Size = new Size(40, 47);
            chkKeyboardUp.TabIndex = 13;
            chkKeyboardUp.Tag = "UP";
            chkKeyboardUp.Text = "U";
            chkKeyboardUp.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardUp.UseVisualStyleBackColor = true;
            chkKeyboardUp.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF11
            // 
            chkKeyboardF11.Appearance = Appearance.Button;
            chkKeyboardF11.Font = new Font("Microsoft Sans Serif", 5F);
            chkKeyboardF11.Location = new Point(570, 37);
            chkKeyboardF11.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF11.Name = "chkKeyboardF11";
            chkKeyboardF11.Size = new Size(40, 47);
            chkKeyboardF11.TabIndex = 14;
            chkKeyboardF11.Tag = "F11";
            chkKeyboardF11.Text = "F11";
            chkKeyboardF11.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF11.UseVisualStyleBackColor = true;
            chkKeyboardF11.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardRightShift
            // 
            chkKeyboardRightShift.Appearance = Appearance.Button;
            chkKeyboardRightShift.Location = new Point(569, 252);
            chkKeyboardRightShift.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardRightShift.Name = "chkKeyboardRightShift";
            chkKeyboardRightShift.Size = new Size(84, 47);
            chkKeyboardRightShift.TabIndex = 9;
            chkKeyboardRightShift.Tag = "RSHIFT";
            chkKeyboardRightShift.Text = "R Shift";
            chkKeyboardRightShift.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardRightShift.UseVisualStyleBackColor = true;
            chkKeyboardRightShift.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF8
            // 
            chkKeyboardF8.Appearance = Appearance.Button;
            chkKeyboardF8.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF8.Location = new Point(433, 37);
            chkKeyboardF8.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF8.Name = "chkKeyboardF8";
            chkKeyboardF8.Size = new Size(40, 47);
            chkKeyboardF8.TabIndex = 14;
            chkKeyboardF8.Tag = "F8";
            chkKeyboardF8.Text = "F8";
            chkKeyboardF8.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF8.UseVisualStyleBackColor = true;
            chkKeyboardF8.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardLeftCtrl
            // 
            chkKeyboardLeftCtrl.Appearance = Appearance.Button;
            chkKeyboardLeftCtrl.Location = new Point(29, 305);
            chkKeyboardLeftCtrl.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardLeftCtrl.Name = "chkKeyboardLeftCtrl";
            chkKeyboardLeftCtrl.Size = new Size(50, 47);
            chkKeyboardLeftCtrl.TabIndex = 9;
            chkKeyboardLeftCtrl.Tag = "LCTRL";
            chkKeyboardLeftCtrl.Text = "Ctrl";
            chkKeyboardLeftCtrl.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardLeftCtrl.UseVisualStyleBackColor = true;
            chkKeyboardLeftCtrl.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF10
            // 
            chkKeyboardF10.Appearance = Appearance.Button;
            chkKeyboardF10.Font = new Font("Microsoft Sans Serif", 5F);
            chkKeyboardF10.Location = new Point(529, 37);
            chkKeyboardF10.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF10.Name = "chkKeyboardF10";
            chkKeyboardF10.Size = new Size(40, 47);
            chkKeyboardF10.TabIndex = 14;
            chkKeyboardF10.Tag = "F10";
            chkKeyboardF10.Text = "F10";
            chkKeyboardF10.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF10.UseVisualStyleBackColor = true;
            chkKeyboardF10.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardMnu
            // 
            chkKeyboardMnu.Appearance = Appearance.Button;
            chkKeyboardMnu.Enabled = false;
            chkKeyboardMnu.Location = new Point(550, 305);
            chkKeyboardMnu.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardMnu.Name = "chkKeyboardMnu";
            chkKeyboardMnu.Size = new Size(50, 47);
            chkKeyboardMnu.TabIndex = 9;
            chkKeyboardMnu.Tag = "MNU";
            chkKeyboardMnu.Text = "Mnu";
            chkKeyboardMnu.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardMnu.UseVisualStyleBackColor = true;
            chkKeyboardMnu.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardRightCtrl
            // 
            chkKeyboardRightCtrl.Appearance = Appearance.Button;
            chkKeyboardRightCtrl.Location = new Point(603, 305);
            chkKeyboardRightCtrl.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardRightCtrl.Name = "chkKeyboardRightCtrl";
            chkKeyboardRightCtrl.Size = new Size(50, 47);
            chkKeyboardRightCtrl.TabIndex = 9;
            chkKeyboardRightCtrl.Tag = "RCTRL";
            chkKeyboardRightCtrl.Text = "Ctrl";
            chkKeyboardRightCtrl.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardRightCtrl.UseVisualStyleBackColor = true;
            chkKeyboardRightCtrl.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF7
            // 
            chkKeyboardF7.Appearance = Appearance.Button;
            chkKeyboardF7.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF7.Location = new Point(391, 37);
            chkKeyboardF7.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF7.Name = "chkKeyboardF7";
            chkKeyboardF7.Size = new Size(40, 47);
            chkKeyboardF7.TabIndex = 14;
            chkKeyboardF7.Tag = "F7";
            chkKeyboardF7.Text = "F7";
            chkKeyboardF7.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF7.UseVisualStyleBackColor = true;
            chkKeyboardF7.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardLeftAlt
            // 
            chkKeyboardLeftAlt.Appearance = Appearance.Button;
            chkKeyboardLeftAlt.Location = new Point(143, 305);
            chkKeyboardLeftAlt.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardLeftAlt.Name = "chkKeyboardLeftAlt";
            chkKeyboardLeftAlt.Size = new Size(50, 47);
            chkKeyboardLeftAlt.TabIndex = 9;
            chkKeyboardLeftAlt.Tag = "LALT";
            chkKeyboardLeftAlt.Text = "Alt";
            chkKeyboardLeftAlt.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardLeftAlt.UseVisualStyleBackColor = true;
            chkKeyboardLeftAlt.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF9
            // 
            chkKeyboardF9.Appearance = Appearance.Button;
            chkKeyboardF9.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF9.Location = new Point(487, 37);
            chkKeyboardF9.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF9.Name = "chkKeyboardF9";
            chkKeyboardF9.Size = new Size(40, 47);
            chkKeyboardF9.TabIndex = 14;
            chkKeyboardF9.Tag = "F9";
            chkKeyboardF9.Text = "F9";
            chkKeyboardF9.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF9.UseVisualStyleBackColor = true;
            chkKeyboardF9.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardRightAlt
            // 
            chkKeyboardRightAlt.Appearance = Appearance.Button;
            chkKeyboardRightAlt.Location = new Point(433, 305);
            chkKeyboardRightAlt.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardRightAlt.Name = "chkKeyboardRightAlt";
            chkKeyboardRightAlt.Size = new Size(50, 47);
            chkKeyboardRightAlt.TabIndex = 9;
            chkKeyboardRightAlt.Tag = "RALT";
            chkKeyboardRightAlt.Text = "Alt";
            chkKeyboardRightAlt.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardRightAlt.UseVisualStyleBackColor = true;
            chkKeyboardRightAlt.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF6
            // 
            chkKeyboardF6.Appearance = Appearance.Button;
            chkKeyboardF6.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF6.Location = new Point(350, 37);
            chkKeyboardF6.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF6.Name = "chkKeyboardF6";
            chkKeyboardF6.Size = new Size(40, 47);
            chkKeyboardF6.TabIndex = 14;
            chkKeyboardF6.Tag = "F6";
            chkKeyboardF6.Text = "F6";
            chkKeyboardF6.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF6.UseVisualStyleBackColor = true;
            chkKeyboardF6.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardLeftWin
            // 
            chkKeyboardLeftWin.Appearance = Appearance.Button;
            chkKeyboardLeftWin.Location = new Point(83, 305);
            chkKeyboardLeftWin.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardLeftWin.Name = "chkKeyboardLeftWin";
            chkKeyboardLeftWin.Size = new Size(57, 47);
            chkKeyboardLeftWin.TabIndex = 9;
            chkKeyboardLeftWin.Tag = "LWIN";
            chkKeyboardLeftWin.Text = "Win";
            chkKeyboardLeftWin.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardLeftWin.UseVisualStyleBackColor = true;
            chkKeyboardLeftWin.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF5
            // 
            chkKeyboardF5.Appearance = Appearance.Button;
            chkKeyboardF5.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF5.Location = new Point(309, 37);
            chkKeyboardF5.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF5.Name = "chkKeyboardF5";
            chkKeyboardF5.Size = new Size(40, 47);
            chkKeyboardF5.TabIndex = 14;
            chkKeyboardF5.Tag = "F5";
            chkKeyboardF5.Text = "F5";
            chkKeyboardF5.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF5.UseVisualStyleBackColor = true;
            chkKeyboardF5.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardRightWin
            // 
            chkKeyboardRightWin.Appearance = Appearance.Button;
            chkKeyboardRightWin.Location = new Point(489, 305);
            chkKeyboardRightWin.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardRightWin.Name = "chkKeyboardRightWin";
            chkKeyboardRightWin.Size = new Size(57, 47);
            chkKeyboardRightWin.TabIndex = 9;
            chkKeyboardRightWin.Tag = "RWIN";
            chkKeyboardRightWin.Text = "Win";
            chkKeyboardRightWin.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardRightWin.UseVisualStyleBackColor = true;
            chkKeyboardRightWin.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF4
            // 
            chkKeyboardF4.Appearance = Appearance.Button;
            chkKeyboardF4.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF4.Location = new Point(251, 37);
            chkKeyboardF4.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF4.Name = "chkKeyboardF4";
            chkKeyboardF4.Size = new Size(40, 47);
            chkKeyboardF4.TabIndex = 14;
            chkKeyboardF4.Tag = "F4";
            chkKeyboardF4.Text = "F4";
            chkKeyboardF4.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF4.UseVisualStyleBackColor = true;
            chkKeyboardF4.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF3
            // 
            chkKeyboardF3.Appearance = Appearance.Button;
            chkKeyboardF3.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF3.Location = new Point(209, 37);
            chkKeyboardF3.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF3.Name = "chkKeyboardF3";
            chkKeyboardF3.Size = new Size(40, 47);
            chkKeyboardF3.TabIndex = 14;
            chkKeyboardF3.Tag = "F3";
            chkKeyboardF3.Text = "F3";
            chkKeyboardF3.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF3.UseVisualStyleBackColor = true;
            chkKeyboardF3.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardB
            // 
            chkKeyboardB.Appearance = Appearance.Button;
            chkKeyboardB.Location = new Point(299, 252);
            chkKeyboardB.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardB.Name = "chkKeyboardB";
            chkKeyboardB.Size = new Size(40, 47);
            chkKeyboardB.TabIndex = 10;
            chkKeyboardB.Tag = "b";
            chkKeyboardB.Text = "B";
            chkKeyboardB.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardB.UseVisualStyleBackColor = true;
            chkKeyboardB.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF2
            // 
            chkKeyboardF2.Appearance = Appearance.Button;
            chkKeyboardF2.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF2.Location = new Point(164, 37);
            chkKeyboardF2.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF2.Name = "chkKeyboardF2";
            chkKeyboardF2.Size = new Size(40, 47);
            chkKeyboardF2.TabIndex = 14;
            chkKeyboardF2.Tag = "F2";
            chkKeyboardF2.Text = "F2";
            chkKeyboardF2.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF2.UseVisualStyleBackColor = true;
            chkKeyboardF2.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardC
            // 
            chkKeyboardC.Appearance = Appearance.Button;
            chkKeyboardC.Location = new Point(209, 252);
            chkKeyboardC.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardC.Name = "chkKeyboardC";
            chkKeyboardC.Size = new Size(40, 47);
            chkKeyboardC.TabIndex = 11;
            chkKeyboardC.Tag = "c";
            chkKeyboardC.Text = "C";
            chkKeyboardC.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardC.UseVisualStyleBackColor = true;
            chkKeyboardC.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF1
            // 
            chkKeyboardF1.Appearance = Appearance.Button;
            chkKeyboardF1.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardF1.Location = new Point(121, 37);
            chkKeyboardF1.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF1.Name = "chkKeyboardF1";
            chkKeyboardF1.Size = new Size(40, 47);
            chkKeyboardF1.TabIndex = 14;
            chkKeyboardF1.Tag = "F1";
            chkKeyboardF1.Text = "F1";
            chkKeyboardF1.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF1.UseVisualStyleBackColor = true;
            chkKeyboardF1.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardD
            // 
            chkKeyboardD.Appearance = Appearance.Button;
            chkKeyboardD.Location = new Point(190, 198);
            chkKeyboardD.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardD.Name = "chkKeyboardD";
            chkKeyboardD.Size = new Size(40, 47);
            chkKeyboardD.TabIndex = 12;
            chkKeyboardD.Tag = "d";
            chkKeyboardD.Text = "D";
            chkKeyboardD.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardD.UseVisualStyleBackColor = true;
            chkKeyboardD.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardESC
            // 
            chkKeyboardESC.Appearance = Appearance.Button;
            chkKeyboardESC.Font = new Font("Microsoft Sans Serif", 4.5F);
            chkKeyboardESC.Location = new Point(47, 37);
            chkKeyboardESC.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardESC.Name = "chkKeyboardESC";
            chkKeyboardESC.Size = new Size(40, 47);
            chkKeyboardESC.TabIndex = 14;
            chkKeyboardESC.Tag = "ESC";
            chkKeyboardESC.Text = "Esc";
            chkKeyboardESC.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardESC.UseVisualStyleBackColor = true;
            chkKeyboardESC.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardE
            // 
            chkKeyboardE.Appearance = Appearance.Button;
            chkKeyboardE.Location = new Point(183, 145);
            chkKeyboardE.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardE.Name = "chkKeyboardE";
            chkKeyboardE.Size = new Size(41, 47);
            chkKeyboardE.TabIndex = 13;
            chkKeyboardE.Tag = "e";
            chkKeyboardE.Text = "E";
            chkKeyboardE.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardE.UseVisualStyleBackColor = true;
            chkKeyboardE.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardBackspace
            // 
            chkKeyboardBackspace.Appearance = Appearance.Button;
            chkKeyboardBackspace.Font = new Font("Microsoft Sans Serif", 6F);
            chkKeyboardBackspace.Location = new Point(570, 90);
            chkKeyboardBackspace.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardBackspace.Name = "chkKeyboardBackspace";
            chkKeyboardBackspace.Size = new Size(84, 47);
            chkKeyboardBackspace.TabIndex = 13;
            chkKeyboardBackspace.Tag = "BACKSPACE";
            chkKeyboardBackspace.Text = "Backspace";
            chkKeyboardBackspace.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardBackspace.UseVisualStyleBackColor = true;
            chkKeyboardBackspace.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardF
            // 
            chkKeyboardF.Appearance = Appearance.Button;
            chkKeyboardF.Location = new Point(233, 198);
            chkKeyboardF.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardF.Name = "chkKeyboardF";
            chkKeyboardF.Size = new Size(40, 47);
            chkKeyboardF.TabIndex = 13;
            chkKeyboardF.Tag = "f";
            chkKeyboardF.Text = "F";
            chkKeyboardF.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardF.UseVisualStyleBackColor = true;
            chkKeyboardF.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardPlus
            // 
            chkKeyboardPlus.Appearance = Appearance.Button;
            chkKeyboardPlus.Location = new Point(529, 90);
            chkKeyboardPlus.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardPlus.Name = "chkKeyboardPlus";
            chkKeyboardPlus.Size = new Size(40, 47);
            chkKeyboardPlus.TabIndex = 13;
            chkKeyboardPlus.Tag = "=";
            chkKeyboardPlus.Text = "=";
            chkKeyboardPlus.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardPlus.UseVisualStyleBackColor = true;
            chkKeyboardPlus.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardG
            // 
            chkKeyboardG.Appearance = Appearance.Button;
            chkKeyboardG.Location = new Point(277, 198);
            chkKeyboardG.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardG.Name = "chkKeyboardG";
            chkKeyboardG.Size = new Size(40, 47);
            chkKeyboardG.TabIndex = 13;
            chkKeyboardG.Tag = "g";
            chkKeyboardG.Text = "G";
            chkKeyboardG.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardG.UseVisualStyleBackColor = true;
            chkKeyboardG.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardDash
            // 
            chkKeyboardDash.Appearance = Appearance.Button;
            chkKeyboardDash.Location = new Point(487, 90);
            chkKeyboardDash.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardDash.Name = "chkKeyboardDash";
            chkKeyboardDash.Size = new Size(40, 47);
            chkKeyboardDash.TabIndex = 13;
            chkKeyboardDash.Tag = "-";
            chkKeyboardDash.Text = "-";
            chkKeyboardDash.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardDash.UseVisualStyleBackColor = true;
            chkKeyboardDash.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardH
            // 
            chkKeyboardH.Appearance = Appearance.Button;
            chkKeyboardH.Location = new Point(320, 198);
            chkKeyboardH.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardH.Name = "chkKeyboardH";
            chkKeyboardH.Size = new Size(40, 47);
            chkKeyboardH.TabIndex = 13;
            chkKeyboardH.Tag = "h";
            chkKeyboardH.Text = "H";
            chkKeyboardH.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardH.UseVisualStyleBackColor = true;
            chkKeyboardH.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard0
            // 
            chkKeyboard0.Appearance = Appearance.Button;
            chkKeyboard0.Location = new Point(446, 90);
            chkKeyboard0.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard0.Name = "chkKeyboard0";
            chkKeyboard0.Size = new Size(40, 47);
            chkKeyboard0.TabIndex = 13;
            chkKeyboard0.Tag = "0";
            chkKeyboard0.Text = "0";
            chkKeyboard0.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard0.UseVisualStyleBackColor = true;
            chkKeyboard0.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardI
            // 
            chkKeyboardI.Appearance = Appearance.Button;
            chkKeyboardI.Location = new Point(393, 145);
            chkKeyboardI.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardI.Name = "chkKeyboardI";
            chkKeyboardI.Size = new Size(40, 47);
            chkKeyboardI.TabIndex = 13;
            chkKeyboardI.Tag = "i";
            chkKeyboardI.Text = "I";
            chkKeyboardI.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardI.UseVisualStyleBackColor = true;
            chkKeyboardI.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard9
            // 
            chkKeyboard9.Appearance = Appearance.Button;
            chkKeyboard9.Location = new Point(403, 90);
            chkKeyboard9.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard9.Name = "chkKeyboard9";
            chkKeyboard9.Size = new Size(40, 47);
            chkKeyboard9.TabIndex = 13;
            chkKeyboard9.Tag = "9";
            chkKeyboard9.Text = "9";
            chkKeyboard9.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard9.UseVisualStyleBackColor = true;
            chkKeyboard9.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardJ
            // 
            chkKeyboardJ.Appearance = Appearance.Button;
            chkKeyboardJ.Location = new Point(363, 198);
            chkKeyboardJ.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardJ.Name = "chkKeyboardJ";
            chkKeyboardJ.Size = new Size(40, 47);
            chkKeyboardJ.TabIndex = 13;
            chkKeyboardJ.Tag = "j";
            chkKeyboardJ.Text = "J";
            chkKeyboardJ.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardJ.UseVisualStyleBackColor = true;
            chkKeyboardJ.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard8
            // 
            chkKeyboard8.Appearance = Appearance.Button;
            chkKeyboard8.Location = new Point(361, 90);
            chkKeyboard8.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard8.Name = "chkKeyboard8";
            chkKeyboard8.Size = new Size(40, 47);
            chkKeyboard8.TabIndex = 13;
            chkKeyboard8.Tag = "8";
            chkKeyboard8.Text = "8";
            chkKeyboard8.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard8.UseVisualStyleBackColor = true;
            chkKeyboard8.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardK
            // 
            chkKeyboardK.Appearance = Appearance.Button;
            chkKeyboardK.Location = new Point(407, 198);
            chkKeyboardK.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardK.Name = "chkKeyboardK";
            chkKeyboardK.Size = new Size(40, 47);
            chkKeyboardK.TabIndex = 13;
            chkKeyboardK.Tag = "k";
            chkKeyboardK.Text = "K";
            chkKeyboardK.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardK.UseVisualStyleBackColor = true;
            chkKeyboardK.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard7
            // 
            chkKeyboard7.Appearance = Appearance.Button;
            chkKeyboard7.Location = new Point(320, 90);
            chkKeyboard7.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard7.Name = "chkKeyboard7";
            chkKeyboard7.Size = new Size(40, 47);
            chkKeyboard7.TabIndex = 13;
            chkKeyboard7.Tag = "7";
            chkKeyboard7.Text = "7";
            chkKeyboard7.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard7.UseVisualStyleBackColor = true;
            chkKeyboard7.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardL
            // 
            chkKeyboardL.Appearance = Appearance.Button;
            chkKeyboardL.Location = new Point(450, 198);
            chkKeyboardL.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardL.Name = "chkKeyboardL";
            chkKeyboardL.Size = new Size(40, 47);
            chkKeyboardL.TabIndex = 13;
            chkKeyboardL.Tag = "l";
            chkKeyboardL.Text = "L";
            chkKeyboardL.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardL.UseVisualStyleBackColor = true;
            chkKeyboardL.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard6
            // 
            chkKeyboard6.Appearance = Appearance.Button;
            chkKeyboard6.Location = new Point(279, 90);
            chkKeyboard6.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard6.Name = "chkKeyboard6";
            chkKeyboard6.Size = new Size(40, 47);
            chkKeyboard6.TabIndex = 13;
            chkKeyboard6.Tag = "6";
            chkKeyboard6.Text = "6";
            chkKeyboard6.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard6.UseVisualStyleBackColor = true;
            chkKeyboard6.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardM
            // 
            chkKeyboardM.Appearance = Appearance.Button;
            chkKeyboardM.Location = new Point(389, 252);
            chkKeyboardM.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardM.Name = "chkKeyboardM";
            chkKeyboardM.Size = new Size(40, 47);
            chkKeyboardM.TabIndex = 13;
            chkKeyboardM.Tag = "m";
            chkKeyboardM.Text = "M";
            chkKeyboardM.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardM.UseVisualStyleBackColor = true;
            chkKeyboardM.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard5
            // 
            chkKeyboard5.Appearance = Appearance.Button;
            chkKeyboard5.Location = new Point(237, 90);
            chkKeyboard5.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard5.Name = "chkKeyboard5";
            chkKeyboard5.Size = new Size(40, 47);
            chkKeyboard5.TabIndex = 13;
            chkKeyboard5.Tag = "5";
            chkKeyboard5.Text = "5";
            chkKeyboard5.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard5.UseVisualStyleBackColor = true;
            chkKeyboard5.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardComma
            // 
            chkKeyboardComma.Appearance = Appearance.Button;
            chkKeyboardComma.Location = new Point(433, 252);
            chkKeyboardComma.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardComma.Name = "chkKeyboardComma";
            chkKeyboardComma.Size = new Size(40, 47);
            chkKeyboardComma.TabIndex = 13;
            chkKeyboardComma.Tag = ",";
            chkKeyboardComma.Text = ",";
            chkKeyboardComma.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardComma.UseVisualStyleBackColor = true;
            chkKeyboardComma.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard4
            // 
            chkKeyboard4.Appearance = Appearance.Button;
            chkKeyboard4.Location = new Point(194, 90);
            chkKeyboard4.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard4.Name = "chkKeyboard4";
            chkKeyboard4.Size = new Size(40, 47);
            chkKeyboard4.TabIndex = 13;
            chkKeyboard4.Tag = "4";
            chkKeyboard4.Text = "4";
            chkKeyboard4.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard4.UseVisualStyleBackColor = true;
            chkKeyboard4.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardPeriod
            // 
            chkKeyboardPeriod.Appearance = Appearance.Button;
            chkKeyboardPeriod.Location = new Point(479, 252);
            chkKeyboardPeriod.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardPeriod.Name = "chkKeyboardPeriod";
            chkKeyboardPeriod.Size = new Size(40, 47);
            chkKeyboardPeriod.TabIndex = 13;
            chkKeyboardPeriod.Tag = ".";
            chkKeyboardPeriod.Text = ".";
            chkKeyboardPeriod.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardPeriod.UseVisualStyleBackColor = true;
            chkKeyboardPeriod.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard3
            // 
            chkKeyboard3.Appearance = Appearance.Button;
            chkKeyboard3.Location = new Point(153, 90);
            chkKeyboard3.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard3.Name = "chkKeyboard3";
            chkKeyboard3.Size = new Size(40, 47);
            chkKeyboard3.TabIndex = 13;
            chkKeyboard3.Tag = "3";
            chkKeyboard3.Text = "3";
            chkKeyboard3.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard3.UseVisualStyleBackColor = true;
            chkKeyboard3.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardSlash
            // 
            chkKeyboardSlash.Appearance = Appearance.Button;
            chkKeyboardSlash.Location = new Point(523, 252);
            chkKeyboardSlash.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardSlash.Name = "chkKeyboardSlash";
            chkKeyboardSlash.Size = new Size(40, 47);
            chkKeyboardSlash.TabIndex = 13;
            chkKeyboardSlash.Tag = "/";
            chkKeyboardSlash.Text = "/";
            chkKeyboardSlash.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardSlash.UseVisualStyleBackColor = true;
            chkKeyboardSlash.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard2
            // 
            chkKeyboard2.Appearance = Appearance.Button;
            chkKeyboard2.Location = new Point(111, 90);
            chkKeyboard2.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard2.Name = "chkKeyboard2";
            chkKeyboard2.Size = new Size(40, 47);
            chkKeyboard2.TabIndex = 13;
            chkKeyboard2.Tag = "2";
            chkKeyboard2.Text = "2";
            chkKeyboard2.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard2.UseVisualStyleBackColor = true;
            chkKeyboard2.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardSemicolon
            // 
            chkKeyboardSemicolon.Appearance = Appearance.Button;
            chkKeyboardSemicolon.Location = new Point(493, 198);
            chkKeyboardSemicolon.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardSemicolon.Name = "chkKeyboardSemicolon";
            chkKeyboardSemicolon.Size = new Size(40, 47);
            chkKeyboardSemicolon.TabIndex = 13;
            chkKeyboardSemicolon.Tag = ";";
            chkKeyboardSemicolon.Text = ";";
            chkKeyboardSemicolon.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardSemicolon.UseVisualStyleBackColor = true;
            chkKeyboardSemicolon.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboard1
            // 
            chkKeyboard1.Appearance = Appearance.Button;
            chkKeyboard1.Location = new Point(70, 90);
            chkKeyboard1.Margin = new Padding(6, 5, 6, 5);
            chkKeyboard1.Name = "chkKeyboard1";
            chkKeyboard1.Size = new Size(40, 47);
            chkKeyboard1.TabIndex = 13;
            chkKeyboard1.Tag = "1";
            chkKeyboard1.Text = "1";
            chkKeyboard1.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboard1.UseVisualStyleBackColor = true;
            chkKeyboard1.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardQuote
            // 
            chkKeyboardQuote.Appearance = Appearance.Button;
            chkKeyboardQuote.Location = new Point(537, 198);
            chkKeyboardQuote.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardQuote.Name = "chkKeyboardQuote";
            chkKeyboardQuote.Size = new Size(40, 47);
            chkKeyboardQuote.TabIndex = 13;
            chkKeyboardQuote.Tag = "'";
            chkKeyboardQuote.Text = "'";
            chkKeyboardQuote.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardQuote.UseVisualStyleBackColor = true;
            chkKeyboardQuote.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardZ
            // 
            chkKeyboardZ.Appearance = Appearance.Button;
            chkKeyboardZ.Location = new Point(119, 252);
            chkKeyboardZ.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardZ.Name = "chkKeyboardZ";
            chkKeyboardZ.Size = new Size(40, 47);
            chkKeyboardZ.TabIndex = 13;
            chkKeyboardZ.Tag = "z";
            chkKeyboardZ.Text = "Z";
            chkKeyboardZ.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardZ.UseVisualStyleBackColor = true;
            chkKeyboardZ.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardEnter
            // 
            chkKeyboardEnter.Appearance = Appearance.Button;
            chkKeyboardEnter.Location = new Point(580, 198);
            chkKeyboardEnter.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardEnter.Name = "chkKeyboardEnter";
            chkKeyboardEnter.Size = new Size(70, 47);
            chkKeyboardEnter.TabIndex = 13;
            chkKeyboardEnter.Tag = "ENTER";
            chkKeyboardEnter.Text = "Enter";
            chkKeyboardEnter.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardEnter.UseVisualStyleBackColor = true;
            chkKeyboardEnter.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardY
            // 
            chkKeyboardY.Appearance = Appearance.Button;
            chkKeyboardY.Location = new Point(310, 145);
            chkKeyboardY.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardY.Name = "chkKeyboardY";
            chkKeyboardY.Size = new Size(40, 47);
            chkKeyboardY.TabIndex = 13;
            chkKeyboardY.Tag = "y";
            chkKeyboardY.Text = "Y";
            chkKeyboardY.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardY.UseVisualStyleBackColor = true;
            chkKeyboardY.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardN
            // 
            chkKeyboardN.Appearance = Appearance.Button;
            chkKeyboardN.Location = new Point(343, 252);
            chkKeyboardN.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardN.Name = "chkKeyboardN";
            chkKeyboardN.Size = new Size(40, 47);
            chkKeyboardN.TabIndex = 13;
            chkKeyboardN.Tag = "n";
            chkKeyboardN.Text = "N";
            chkKeyboardN.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardN.UseVisualStyleBackColor = true;
            chkKeyboardN.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardX
            // 
            chkKeyboardX.Appearance = Appearance.Button;
            chkKeyboardX.Location = new Point(163, 252);
            chkKeyboardX.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardX.Name = "chkKeyboardX";
            chkKeyboardX.Size = new Size(40, 47);
            chkKeyboardX.TabIndex = 13;
            chkKeyboardX.Tag = "x";
            chkKeyboardX.Text = "X";
            chkKeyboardX.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardX.UseVisualStyleBackColor = true;
            chkKeyboardX.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardO
            // 
            chkKeyboardO.Appearance = Appearance.Button;
            chkKeyboardO.Location = new Point(434, 145);
            chkKeyboardO.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardO.Name = "chkKeyboardO";
            chkKeyboardO.Size = new Size(40, 47);
            chkKeyboardO.TabIndex = 13;
            chkKeyboardO.Tag = "o";
            chkKeyboardO.Text = "O";
            chkKeyboardO.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardO.UseVisualStyleBackColor = true;
            chkKeyboardO.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardW
            // 
            chkKeyboardW.Appearance = Appearance.Button;
            chkKeyboardW.Location = new Point(141, 145);
            chkKeyboardW.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardW.Name = "chkKeyboardW";
            chkKeyboardW.Size = new Size(40, 47);
            chkKeyboardW.TabIndex = 13;
            chkKeyboardW.Tag = "w";
            chkKeyboardW.Text = "W";
            chkKeyboardW.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardW.UseVisualStyleBackColor = true;
            chkKeyboardW.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardP
            // 
            chkKeyboardP.Appearance = Appearance.Button;
            chkKeyboardP.Location = new Point(477, 145);
            chkKeyboardP.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardP.Name = "chkKeyboardP";
            chkKeyboardP.Size = new Size(40, 47);
            chkKeyboardP.TabIndex = 13;
            chkKeyboardP.Tag = "p";
            chkKeyboardP.Text = "P";
            chkKeyboardP.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardP.UseVisualStyleBackColor = true;
            chkKeyboardP.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardV
            // 
            chkKeyboardV.Appearance = Appearance.Button;
            chkKeyboardV.Location = new Point(253, 252);
            chkKeyboardV.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardV.Name = "chkKeyboardV";
            chkKeyboardV.Size = new Size(40, 47);
            chkKeyboardV.TabIndex = 13;
            chkKeyboardV.Tag = "v";
            chkKeyboardV.Text = "V";
            chkKeyboardV.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardV.UseVisualStyleBackColor = true;
            chkKeyboardV.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardLeftBracket
            // 
            chkKeyboardLeftBracket.Appearance = Appearance.Button;
            chkKeyboardLeftBracket.Location = new Point(519, 145);
            chkKeyboardLeftBracket.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardLeftBracket.Name = "chkKeyboardLeftBracket";
            chkKeyboardLeftBracket.Size = new Size(40, 47);
            chkKeyboardLeftBracket.TabIndex = 13;
            chkKeyboardLeftBracket.Tag = "[";
            chkKeyboardLeftBracket.Text = "[";
            chkKeyboardLeftBracket.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardLeftBracket.UseVisualStyleBackColor = true;
            chkKeyboardLeftBracket.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardU
            // 
            chkKeyboardU.Appearance = Appearance.Button;
            chkKeyboardU.Location = new Point(351, 145);
            chkKeyboardU.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardU.Name = "chkKeyboardU";
            chkKeyboardU.Size = new Size(40, 47);
            chkKeyboardU.TabIndex = 13;
            chkKeyboardU.Tag = "u";
            chkKeyboardU.Text = "U";
            chkKeyboardU.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardU.UseVisualStyleBackColor = true;
            chkKeyboardU.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardRightBracket
            // 
            chkKeyboardRightBracket.Appearance = Appearance.Button;
            chkKeyboardRightBracket.Location = new Point(560, 145);
            chkKeyboardRightBracket.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardRightBracket.Name = "chkKeyboardRightBracket";
            chkKeyboardRightBracket.Size = new Size(40, 47);
            chkKeyboardRightBracket.TabIndex = 13;
            chkKeyboardRightBracket.Tag = "]";
            chkKeyboardRightBracket.Text = "]";
            chkKeyboardRightBracket.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardRightBracket.UseVisualStyleBackColor = true;
            chkKeyboardRightBracket.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardT
            // 
            chkKeyboardT.Appearance = Appearance.Button;
            chkKeyboardT.Location = new Point(269, 145);
            chkKeyboardT.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardT.Name = "chkKeyboardT";
            chkKeyboardT.Size = new Size(40, 47);
            chkKeyboardT.TabIndex = 13;
            chkKeyboardT.Tag = "t";
            chkKeyboardT.Text = "T";
            chkKeyboardT.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardT.UseVisualStyleBackColor = true;
            chkKeyboardT.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardBackslash
            // 
            chkKeyboardBackslash.Appearance = Appearance.Button;
            chkKeyboardBackslash.Location = new Point(601, 145);
            chkKeyboardBackslash.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardBackslash.Name = "chkKeyboardBackslash";
            chkKeyboardBackslash.Size = new Size(40, 47);
            chkKeyboardBackslash.TabIndex = 13;
            chkKeyboardBackslash.Tag = "\\";
            chkKeyboardBackslash.Text = "\\";
            chkKeyboardBackslash.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardBackslash.UseVisualStyleBackColor = true;
            chkKeyboardBackslash.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardS
            // 
            chkKeyboardS.Appearance = Appearance.Button;
            chkKeyboardS.Location = new Point(147, 198);
            chkKeyboardS.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardS.Name = "chkKeyboardS";
            chkKeyboardS.Size = new Size(40, 47);
            chkKeyboardS.TabIndex = 13;
            chkKeyboardS.Tag = "s";
            chkKeyboardS.Text = "S";
            chkKeyboardS.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardS.UseVisualStyleBackColor = true;
            chkKeyboardS.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardQ
            // 
            chkKeyboardQ.Appearance = Appearance.Button;
            chkKeyboardQ.Location = new Point(100, 145);
            chkKeyboardQ.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardQ.Name = "chkKeyboardQ";
            chkKeyboardQ.Size = new Size(40, 47);
            chkKeyboardQ.TabIndex = 13;
            chkKeyboardQ.Tag = "q";
            chkKeyboardQ.Text = "Q";
            chkKeyboardQ.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardQ.UseVisualStyleBackColor = true;
            chkKeyboardQ.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // chkKeyboardR
            // 
            chkKeyboardR.Appearance = Appearance.Button;
            chkKeyboardR.Location = new Point(227, 145);
            chkKeyboardR.Margin = new Padding(6, 5, 6, 5);
            chkKeyboardR.Name = "chkKeyboardR";
            chkKeyboardR.Size = new Size(40, 47);
            chkKeyboardR.TabIndex = 13;
            chkKeyboardR.Tag = "r";
            chkKeyboardR.Text = "R";
            chkKeyboardR.TextAlign = ContentAlignment.MiddleCenter;
            chkKeyboardR.UseVisualStyleBackColor = true;
            chkKeyboardR.CheckedChanged += chkGeneralKeyboardUI_CheckChanged;
            // 
            // cmdKeyboardValidate
            // 
            cmdKeyboardValidate.Location = new Point(840, 602);
            cmdKeyboardValidate.Margin = new Padding(6, 5, 6, 5);
            cmdKeyboardValidate.Name = "cmdKeyboardValidate";
            cmdKeyboardValidate.Size = new Size(126, 45);
            cmdKeyboardValidate.TabIndex = 15;
            cmdKeyboardValidate.Text = "Validate";
            cmdKeyboardValidate.UseVisualStyleBackColor = true;
            cmdKeyboardValidate.Click += cmdKeyboardValidate_Click;
            // 
            // txtKeyboard
            // 
            txtKeyboard.Location = new Point(10, 385);
            txtKeyboard.Margin = new Padding(6, 5, 6, 5);
            txtKeyboard.Multiline = true;
            txtKeyboard.Name = "txtKeyboard";
            txtKeyboard.Size = new Size(815, 257);
            txtKeyboard.TabIndex = 0;
            txtKeyboard.TextChanged += txtKeyboard_TextChanged;
            // 
            // lblPictureMissing
            // 
            lblPictureMissing.Font = new Font("Microsoft Sans Serif", 12F);
            lblPictureMissing.Location = new Point(0, 97);
            lblPictureMissing.Margin = new Padding(6, 0, 6, 0);
            lblPictureMissing.Name = "lblPictureMissing";
            lblPictureMissing.Size = new Size(1053, 480);
            lblPictureMissing.TabIndex = 1;
            lblPictureMissing.Text = "lblPictureMissing";
            // 
            // PictureBox1
            // 
            PictureBox1.Cursor = Cursors.Cross;
            PictureBox1.Location = new Point(0, 0);
            PictureBox1.Margin = new Padding(6, 5, 6, 5);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(100, 50);
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            PictureBox1.Click += PictureBox1_Click;
            PictureBox1.Paint += PictureBox1_Paint;
            PictureBox1.MouseDown += PictureBox1_MouseDown;
            PictureBox1.MouseMove += PictureBox1_MouseMove;
            PictureBox1.MouseUp += PictureBox1_MouseUp;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(7, 145);
            label29.Margin = new Padding(6, 0, 6, 0);
            label29.Name = "label29";
            label29.Size = new Size(107, 25);
            label29.TabIndex = 9;
            label29.Text = "Event Name";
            // 
            // txtEventName
            // 
            txtEventName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEventName.BackColor = SystemColors.Window;
            txtEventName.Location = new Point(126, 138);
            txtEventName.Margin = new Padding(6, 5, 6, 5);
            txtEventName.Name = "txtEventName";
            txtEventName.Size = new Size(1013, 31);
            txtEventName.TabIndex = 10;
            txtEventName.TextChanged += txtEventName_TextChanged;
            // 
            // chkUseParentScreenshot
            // 
            chkUseParentScreenshot.AutoSize = true;
            chkUseParentScreenshot.Location = new Point(7, 10);
            chkUseParentScreenshot.Margin = new Padding(6, 5, 6, 5);
            chkUseParentScreenshot.Name = "chkUseParentScreenshot";
            chkUseParentScreenshot.Size = new Size(213, 29);
            chkUseParentScreenshot.TabIndex = 15;
            chkUseParentScreenshot.Text = "Use Parent Screenshot";
            chkUseParentScreenshot.UseVisualStyleBackColor = true;
            chkUseParentScreenshot.CheckedChanged += chkUseParentScreenshot_CheckedChanged;
            // 
            // cmdAddSingleColorAtSingleLocationTakeASceenshot
            // 
            cmdAddSingleColorAtSingleLocationTakeASceenshot.Location = new Point(7, 40);
            cmdAddSingleColorAtSingleLocationTakeASceenshot.Margin = new Padding(6, 2, 6, 2);
            cmdAddSingleColorAtSingleLocationTakeASceenshot.Name = "cmdAddSingleColorAtSingleLocationTakeASceenshot";
            cmdAddSingleColorAtSingleLocationTakeASceenshot.Size = new Size(220, 45);
            cmdAddSingleColorAtSingleLocationTakeASceenshot.TabIndex = 6;
            cmdAddSingleColorAtSingleLocationTakeASceenshot.Text = "Take a Screenshot";
            cmdAddSingleColorAtSingleLocationTakeASceenshot.UseVisualStyleBackColor = true;
            cmdAddSingleColorAtSingleLocationTakeASceenshot.Click += cmdAddSingleColorAtSingleLocationTakeASceenshot_Click;
            // 
            // FlowLayoutPanelColorEvent1
            // 
            FlowLayoutPanelColorEvent1.AutoScroll = true;
            FlowLayoutPanelColorEvent1.Controls.Add(cmdFlowLayoutPanelColorEvent1);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightProperties);
            FlowLayoutPanelColorEvent1.Controls.Add(panelPreAction);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightAfterCompletion);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightObject);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightSwipeProperties);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightClickProperties);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightLogic);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightCustomLogic);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightPointGrid);
            FlowLayoutPanelColorEvent1.Controls.Add(panelRightInformation);
            FlowLayoutPanelColorEvent1.Dock = DockStyle.Fill;
            FlowLayoutPanelColorEvent1.FlowDirection = FlowDirection.TopDown;
            FlowLayoutPanelColorEvent1.Location = new Point(1156, 5);
            FlowLayoutPanelColorEvent1.Margin = new Padding(6, 5, 6, 5);
            FlowLayoutPanelColorEvent1.Name = "FlowLayoutPanelColorEvent1";
            FlowLayoutPanelColorEvent1.Size = new Size(488, 1327);
            FlowLayoutPanelColorEvent1.TabIndex = 32;
            FlowLayoutPanelColorEvent1.WrapContents = false;
            // 
            // cmdFlowLayoutPanelColorEvent1
            // 
            cmdFlowLayoutPanelColorEvent1.BackColor = SystemColors.Control;
            cmdFlowLayoutPanelColorEvent1.Cursor = Cursors.Hand;
            cmdFlowLayoutPanelColorEvent1.FlatAppearance.BorderSize = 0;
            cmdFlowLayoutPanelColorEvent1.FlatStyle = FlatStyle.Flat;
            cmdFlowLayoutPanelColorEvent1.Font = new Font("Microsoft Sans Serif", 7F);
            cmdFlowLayoutPanelColorEvent1.Location = new Point(6, 0);
            cmdFlowLayoutPanelColorEvent1.Margin = new Padding(6, 0, 6, 0);
            cmdFlowLayoutPanelColorEvent1.Name = "cmdFlowLayoutPanelColorEvent1";
            cmdFlowLayoutPanelColorEvent1.Size = new Size(467, 35);
            cmdFlowLayoutPanelColorEvent1.TabIndex = 13;
            cmdFlowLayoutPanelColorEvent1.Text = "<<  ";
            cmdFlowLayoutPanelColorEvent1.TextAlign = ContentAlignment.MiddleRight;
            cmdFlowLayoutPanelColorEvent1.UseVisualStyleBackColor = false;
            cmdFlowLayoutPanelColorEvent1.Click += cmdFlowLayoutPanelColorEvent1_Click;
            // 
            // panelRightProperties
            // 
            panelRightProperties.BorderStyle = BorderStyle.FixedSingle;
            panelRightProperties.Controls.Add(chkPropertiesRepeatsUntilFalse);
            panelRightProperties.Controls.Add(grpPropertiesRepeatsUntilFalse);
            panelRightProperties.Controls.Add(chkPropertiesEnabled);
            panelRightProperties.Controls.Add(lblResolution);
            panelRightProperties.Controls.Add(cmdPanelRightResolution);
            panelRightProperties.Location = new Point(3, 38);
            panelRightProperties.Name = "panelRightProperties";
            panelRightProperties.Size = new Size(465, 165);
            panelRightProperties.TabIndex = 38;
            // 
            // chkPropertiesRepeatsUntilFalse
            // 
            chkPropertiesRepeatsUntilFalse.AutoSize = true;
            chkPropertiesRepeatsUntilFalse.Location = new Point(251, 55);
            chkPropertiesRepeatsUntilFalse.Name = "chkPropertiesRepeatsUntilFalse";
            chkPropertiesRepeatsUntilFalse.Size = new Size(184, 29);
            chkPropertiesRepeatsUntilFalse.TabIndex = 11;
            chkPropertiesRepeatsUntilFalse.Text = "Repeats Until False";
            chkPropertiesRepeatsUntilFalse.UseVisualStyleBackColor = true;
            chkPropertiesRepeatsUntilFalse.CheckedChanged += chkPropertiesRepeatsUntilFalse_CheckedChanged;
            // 
            // grpPropertiesRepeatsUntilFalse
            // 
            grpPropertiesRepeatsUntilFalse.Controls.Add(lblPropertiesRepeatsUntilFalse);
            grpPropertiesRepeatsUntilFalse.Controls.Add(numericPropertiesRepeatsUntilFalse);
            grpPropertiesRepeatsUntilFalse.Location = new Point(241, 62);
            grpPropertiesRepeatsUntilFalse.Name = "grpPropertiesRepeatsUntilFalse";
            grpPropertiesRepeatsUntilFalse.Size = new Size(207, 92);
            grpPropertiesRepeatsUntilFalse.TabIndex = 12;
            grpPropertiesRepeatsUntilFalse.TabStop = false;
            // 
            // lblPropertiesRepeatsUntilFalse
            // 
            lblPropertiesRepeatsUntilFalse.AutoSize = true;
            lblPropertiesRepeatsUntilFalse.Location = new Point(127, 38);
            lblPropertiesRepeatsUntilFalse.Name = "lblPropertiesRepeatsUntilFalse";
            lblPropertiesRepeatsUntilFalse.Size = new Size(50, 25);
            lblPropertiesRepeatsUntilFalse.TabIndex = 12;
            lblPropertiesRepeatsUntilFalse.Text = "Limit";
            // 
            // numericPropertiesRepeatsUntilFalse
            // 
            numericPropertiesRepeatsUntilFalse.Font = new Font("Microsoft Sans Serif", 12F);
            numericPropertiesRepeatsUntilFalse.Location = new Point(14, 30);
            numericPropertiesRepeatsUntilFalse.Margin = new Padding(6, 5, 6, 5);
            numericPropertiesRepeatsUntilFalse.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericPropertiesRepeatsUntilFalse.Name = "numericPropertiesRepeatsUntilFalse";
            numericPropertiesRepeatsUntilFalse.Size = new Size(106, 35);
            numericPropertiesRepeatsUntilFalse.TabIndex = 11;
            numericPropertiesRepeatsUntilFalse.ValueChanged += numericPropertiesRepeatsUntilFalse_ValueChanged;
            // 
            // chkPropertiesEnabled
            // 
            chkPropertiesEnabled.AutoSize = true;
            chkPropertiesEnabled.Location = new Point(9, 52);
            chkPropertiesEnabled.Name = "chkPropertiesEnabled";
            chkPropertiesEnabled.Size = new Size(101, 29);
            chkPropertiesEnabled.TabIndex = 9;
            chkPropertiesEnabled.Text = "Enabled";
            chkPropertiesEnabled.UseVisualStyleBackColor = true;
            chkPropertiesEnabled.CheckedChanged += chkPropertiesEnabled_CheckedChanged;
            // 
            // lblResolution
            // 
            lblResolution.AutoSize = true;
            lblResolution.BackColor = SystemColors.AppWorkspace;
            lblResolution.Location = new Point(321, 10);
            lblResolution.Margin = new Padding(6, 0, 6, 0);
            lblResolution.Name = "lblResolution";
            lblResolution.Size = new Size(114, 25);
            lblResolution.TabIndex = 1;
            lblResolution.Text = "lblResolution";
            lblResolution.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmdPanelRightResolution
            // 
            cmdPanelRightResolution.BackColor = SystemColors.AppWorkspace;
            cmdPanelRightResolution.Dock = DockStyle.Top;
            cmdPanelRightResolution.FlatAppearance.BorderSize = 0;
            cmdPanelRightResolution.FlatStyle = FlatStyle.Flat;
            cmdPanelRightResolution.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdPanelRightResolution.ForeColor = SystemColors.ButtonFace;
            cmdPanelRightResolution.Location = new Point(0, 0);
            cmdPanelRightResolution.Margin = new Padding(6, 5, 6, 5);
            cmdPanelRightResolution.Name = "cmdPanelRightResolution";
            cmdPanelRightResolution.Size = new Size(463, 45);
            cmdPanelRightResolution.TabIndex = 8;
            cmdPanelRightResolution.Text = "Properties";
            cmdPanelRightResolution.TextAlign = ContentAlignment.MiddleLeft;
            cmdPanelRightResolution.UseVisualStyleBackColor = false;
            // 
            // panelPreAction
            // 
            panelPreAction.BorderStyle = BorderStyle.FixedSingle;
            panelPreAction.Controls.Add(groupBox22);
            panelPreAction.Controls.Add(chkFromCurrentMousePos);
            panelPreAction.Controls.Add(button2);
            panelPreAction.Location = new Point(3, 209);
            panelPreAction.Name = "panelPreAction";
            panelPreAction.Size = new Size(465, 305);
            panelPreAction.TabIndex = 39;
            panelPreAction.Visible = false;
            // 
            // groupBox22
            // 
            groupBox22.Controls.Add(label99);
            groupBox22.Controls.Add(cboPreActionFailureAction);
            groupBox22.Controls.Add(label98);
            groupBox22.Controls.Add(numericKeyboardAfterSendingActivationMS);
            groupBox22.Controls.Add(label95);
            groupBox22.Controls.Add(numericKeyboardTimeoutToActivateMS);
            groupBox22.Controls.Add(chkAppActivateIfNotActive);
            groupBox22.Location = new Point(11, 108);
            groupBox22.Margin = new Padding(6, 5, 6, 5);
            groupBox22.Name = "groupBox22";
            groupBox22.Padding = new Padding(6, 5, 6, 5);
            groupBox22.Size = new Size(441, 187);
            groupBox22.TabIndex = 15;
            groupBox22.TabStop = false;
            // 
            // label99
            // 
            label99.AutoSize = true;
            label99.Location = new Point(130, 90);
            label99.Margin = new Padding(6, 0, 6, 0);
            label99.Name = "label99";
            label99.Size = new Size(133, 25);
            label99.TabIndex = 26;
            label99.Text = "Timeout Action";
            // 
            // cboPreActionFailureAction
            // 
            cboPreActionFailureAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPreActionFailureAction.FormattingEnabled = true;
            cboPreActionFailureAction.Items.AddRange(new object[] { "Abort", "Continue" });
            cboPreActionFailureAction.Location = new Point(13, 80);
            cboPreActionFailureAction.Margin = new Padding(6, 5, 6, 5);
            cboPreActionFailureAction.Name = "cboPreActionFailureAction";
            cboPreActionFailureAction.Size = new Size(110, 33);
            cboPreActionFailureAction.TabIndex = 25;
            cboPreActionFailureAction.SelectedIndexChanged += cboPreActionFailureAction_SelectedIndexChanged;
            // 
            // label98
            // 
            label98.AutoSize = true;
            label98.Location = new Point(100, 137);
            label98.Margin = new Padding(6, 0, 6, 0);
            label98.Name = "label98";
            label98.Size = new Size(263, 25);
            label98.TabIndex = 24;
            label98.Text = "Wait after sending Activate (ms)";
            // 
            // numericKeyboardAfterSendingActivationMS
            // 
            numericKeyboardAfterSendingActivationMS.Location = new Point(10, 133);
            numericKeyboardAfterSendingActivationMS.Margin = new Padding(6, 5, 6, 5);
            numericKeyboardAfterSendingActivationMS.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericKeyboardAfterSendingActivationMS.Name = "numericKeyboardAfterSendingActivationMS";
            numericKeyboardAfterSendingActivationMS.Size = new Size(84, 31);
            numericKeyboardAfterSendingActivationMS.TabIndex = 23;
            numericKeyboardAfterSendingActivationMS.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericKeyboardAfterSendingActivationMS.ValueChanged += numericKeyboardAfterSendingActivationMS_ValueChanged;
            // 
            // label95
            // 
            label95.AutoSize = true;
            label95.Location = new Point(100, 45);
            label95.Margin = new Padding(6, 0, 6, 0);
            label95.Name = "label95";
            label95.Size = new Size(116, 25);
            label95.TabIndex = 22;
            label95.Text = "Timeout (ms)";
            // 
            // numericKeyboardTimeoutToActivateMS
            // 
            numericKeyboardTimeoutToActivateMS.Location = new Point(11, 35);
            numericKeyboardTimeoutToActivateMS.Margin = new Padding(6, 5, 6, 5);
            numericKeyboardTimeoutToActivateMS.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericKeyboardTimeoutToActivateMS.Name = "numericKeyboardTimeoutToActivateMS";
            numericKeyboardTimeoutToActivateMS.Size = new Size(83, 31);
            numericKeyboardTimeoutToActivateMS.TabIndex = 21;
            numericKeyboardTimeoutToActivateMS.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            numericKeyboardTimeoutToActivateMS.ValueChanged += numericKeyboardTimeoutToActivateMS_ValueChanged;
            // 
            // chkAppActivateIfNotActive
            // 
            chkAppActivateIfNotActive.AutoSize = true;
            chkAppActivateIfNotActive.Location = new Point(11, -2);
            chkAppActivateIfNotActive.Margin = new Padding(6, 5, 6, 5);
            chkAppActivateIfNotActive.Name = "chkAppActivateIfNotActive";
            chkAppActivateIfNotActive.Size = new Size(365, 29);
            chkAppActivateIfNotActive.TabIndex = 20;
            chkAppActivateIfNotActive.Text = "Activate Application (if not already active)";
            chkAppActivateIfNotActive.UseVisualStyleBackColor = true;
            chkAppActivateIfNotActive.CheckedChanged += chkAppActivateIfNotActive_CheckedChanged;
            // 
            // chkFromCurrentMousePos
            // 
            chkFromCurrentMousePos.Location = new Point(9, 50);
            chkFromCurrentMousePos.Name = "chkFromCurrentMousePos";
            chkFromCurrentMousePos.Size = new Size(426, 62);
            chkFromCurrentMousePos.TabIndex = 14;
            chkFromCurrentMousePos.Text = "Move mouse from sys pos (Active Mouse Only)";
            chkFromCurrentMousePos.UseVisualStyleBackColor = true;
            chkFromCurrentMousePos.CheckedChanged += chkFromCurrentMousePos_CheckedChanged;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.AppWorkspace;
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(0, 0);
            button2.Margin = new Padding(6, 5, 6, 5);
            button2.Name = "button2";
            button2.Size = new Size(463, 45);
            button2.TabIndex = 8;
            button2.Text = "Pre Action Events";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            // 
            // panelRightAfterCompletion
            // 
            panelRightAfterCompletion.BorderStyle = BorderStyle.FixedSingle;
            panelRightAfterCompletion.Controls.Add(cmdAfterCompletionHelp);
            panelRightAfterCompletion.Controls.Add(txtAfterCompletionGoTo);
            panelRightAfterCompletion.Controls.Add(rdoAfterCompletionGoTo);
            panelRightAfterCompletion.Controls.Add(groupBox4);
            panelRightAfterCompletion.Controls.Add(groupBox6);
            panelRightAfterCompletion.Controls.Add(cmdRightAfterCompletion);
            panelRightAfterCompletion.Controls.Add(rdoAfterCompletionRecycle);
            panelRightAfterCompletion.Controls.Add(rdoAfterCompletionStop);
            panelRightAfterCompletion.Controls.Add(rdoAfterCompletionContinue);
            panelRightAfterCompletion.Controls.Add(rdoAfterCompletionHome);
            panelRightAfterCompletion.Controls.Add(rdoAfterCompletionParent);
            panelRightAfterCompletion.Location = new Point(6, 522);
            panelRightAfterCompletion.Margin = new Padding(6, 5, 6, 5);
            panelRightAfterCompletion.Name = "panelRightAfterCompletion";
            panelRightAfterCompletion.Size = new Size(465, 380);
            panelRightAfterCompletion.TabIndex = 30;
            // 
            // cmdAfterCompletionHelp
            // 
            cmdAfterCompletionHelp.Location = new Point(421, 320);
            cmdAfterCompletionHelp.Margin = new Padding(6, 5, 6, 5);
            cmdAfterCompletionHelp.Name = "cmdAfterCompletionHelp";
            cmdAfterCompletionHelp.Size = new Size(41, 45);
            cmdAfterCompletionHelp.TabIndex = 11;
            cmdAfterCompletionHelp.Text = "...";
            cmdAfterCompletionHelp.UseVisualStyleBackColor = true;
            cmdAfterCompletionHelp.Click += cmdAfterCompletionHelp_Click;
            // 
            // txtAfterCompletionGoTo
            // 
            txtAfterCompletionGoTo.Location = new Point(97, 323);
            txtAfterCompletionGoTo.Margin = new Padding(6, 5, 6, 5);
            txtAfterCompletionGoTo.Name = "txtAfterCompletionGoTo";
            txtAfterCompletionGoTo.Size = new Size(321, 31);
            txtAfterCompletionGoTo.TabIndex = 10;
            txtAfterCompletionGoTo.TextChanged += txtAfterCompletionGoTo_TextChanged;
            // 
            // rdoAfterCompletionGoTo
            // 
            rdoAfterCompletionGoTo.AutoSize = true;
            rdoAfterCompletionGoTo.Location = new Point(13, 325);
            rdoAfterCompletionGoTo.Margin = new Padding(6, 5, 6, 5);
            rdoAfterCompletionGoTo.Name = "rdoAfterCompletionGoTo";
            rdoAfterCompletionGoTo.Size = new Size(78, 29);
            rdoAfterCompletionGoTo.TabIndex = 9;
            rdoAfterCompletionGoTo.TabStop = true;
            rdoAfterCompletionGoTo.Text = "GoTo";
            rdoAfterCompletionGoTo.UseVisualStyleBackColor = true;
            rdoAfterCompletionGoTo.CheckedChanged += rdoAfterCompletionGoTo_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Location = new Point(21, 190);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(131, 2);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lblDelayCalc);
            groupBox6.Controls.Add(label23);
            groupBox6.Controls.Add(label24);
            groupBox6.Controls.Add(label27);
            groupBox6.Controls.Add(cboDelayH);
            groupBox6.Controls.Add(cboDelayM);
            groupBox6.Controls.Add(cboDelayS);
            groupBox6.Controls.Add(label28);
            groupBox6.Controls.Add(cboDelayMS);
            groupBox6.Location = new Point(191, 47);
            groupBox6.Margin = new Padding(6, 5, 6, 5);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(6, 5, 6, 5);
            groupBox6.Size = new Size(220, 270);
            groupBox6.TabIndex = 5;
            groupBox6.TabStop = false;
            groupBox6.Text = "Delay (Additive)";
            // 
            // lblDelayCalc
            // 
            lblDelayCalc.AutoSize = true;
            lblDelayCalc.Location = new Point(17, 235);
            lblDelayCalc.Margin = new Padding(6, 0, 6, 0);
            lblDelayCalc.Name = "lblDelayCalc";
            lblDelayCalc.Size = new Size(117, 25);
            lblDelayCalc.TabIndex = 10;
            lblDelayCalc.Text = "[lblDelayCalc]";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(13, 190);
            label23.Margin = new Padding(6, 0, 6, 0);
            label23.Name = "label23";
            label23.Size = new Size(60, 25);
            label23.TabIndex = 9;
            label23.Text = "Hours";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(13, 138);
            label24.Margin = new Padding(6, 0, 6, 0);
            label24.Name = "label24";
            label24.Size = new Size(75, 25);
            label24.TabIndex = 8;
            label24.Text = "Minutes";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(13, 87);
            label27.Margin = new Padding(6, 0, 6, 0);
            label27.Name = "label27";
            label27.Size = new Size(79, 25);
            label27.TabIndex = 7;
            label27.Text = "Seconds";
            // 
            // cboDelayH
            // 
            cboDelayH.BackColor = SystemColors.Window;
            cboDelayH.FormattingEnabled = true;
            cboDelayH.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cboDelayH.Location = new Point(126, 185);
            cboDelayH.Margin = new Padding(6, 5, 6, 5);
            cboDelayH.MaxLength = 3;
            cboDelayH.Name = "cboDelayH";
            cboDelayH.Size = new Size(78, 33);
            cboDelayH.TabIndex = 6;
            cboDelayH.TextChanged += cboDelayH_TextChanged;
            // 
            // cboDelayM
            // 
            cboDelayM.BackColor = SystemColors.Window;
            cboDelayM.FormattingEnabled = true;
            cboDelayM.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cboDelayM.Location = new Point(126, 133);
            cboDelayM.Margin = new Padding(6, 5, 6, 5);
            cboDelayM.MaxLength = 2;
            cboDelayM.Name = "cboDelayM";
            cboDelayM.Size = new Size(78, 33);
            cboDelayM.TabIndex = 6;
            cboDelayM.TextChanged += cboDelayM_TextChanged;
            // 
            // cboDelayS
            // 
            cboDelayS.BackColor = SystemColors.Window;
            cboDelayS.FormattingEnabled = true;
            cboDelayS.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" });
            cboDelayS.Location = new Point(126, 80);
            cboDelayS.Margin = new Padding(6, 5, 6, 5);
            cboDelayS.MaxLength = 2;
            cboDelayS.Name = "cboDelayS";
            cboDelayS.Size = new Size(78, 33);
            cboDelayS.TabIndex = 6;
            cboDelayS.TextChanged += cboDelayS_TextChanged;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(13, 38);
            label28.Margin = new Padding(6, 0, 6, 0);
            label28.Name = "label28";
            label28.Size = new Size(99, 25);
            label28.TabIndex = 5;
            label28.Text = "1/1000 sec";
            // 
            // cboDelayMS
            // 
            cboDelayMS.BackColor = SystemColors.Window;
            cboDelayMS.FormattingEnabled = true;
            cboDelayMS.Items.AddRange(new object[] { "0", "50", "100", "200", "300", "400", "500", "600", "700", "800", "900", "950" });
            cboDelayMS.Location = new Point(126, 33);
            cboDelayMS.Margin = new Padding(6, 5, 6, 5);
            cboDelayMS.MaxLength = 3;
            cboDelayMS.Name = "cboDelayMS";
            cboDelayMS.Size = new Size(78, 33);
            cboDelayMS.TabIndex = 4;
            cboDelayMS.TextChanged += cboDelayMS_TextChanged;
            // 
            // cmdRightAfterCompletion
            // 
            cmdRightAfterCompletion.BackColor = SystemColors.AppWorkspace;
            cmdRightAfterCompletion.Cursor = Cursors.Hand;
            cmdRightAfterCompletion.Dock = DockStyle.Top;
            cmdRightAfterCompletion.FlatAppearance.BorderSize = 0;
            cmdRightAfterCompletion.FlatStyle = FlatStyle.Flat;
            cmdRightAfterCompletion.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightAfterCompletion.ForeColor = SystemColors.ButtonFace;
            cmdRightAfterCompletion.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightAfterCompletion.ImageIndex = 22;
            cmdRightAfterCompletion.ImageList = ImageList1;
            cmdRightAfterCompletion.Location = new Point(0, 0);
            cmdRightAfterCompletion.Margin = new Padding(6, 5, 6, 5);
            cmdRightAfterCompletion.Name = "cmdRightAfterCompletion";
            cmdRightAfterCompletion.Size = new Size(463, 45);
            cmdRightAfterCompletion.TabIndex = 7;
            cmdRightAfterCompletion.Text = "After Completion";
            cmdRightAfterCompletion.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightAfterCompletion.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightAfterCompletion.UseVisualStyleBackColor = false;
            cmdRightAfterCompletion.Click += cmdRightAfterCompletion_Click;
            // 
            // rdoAfterCompletionRecycle
            // 
            rdoAfterCompletionRecycle.AutoSize = true;
            rdoAfterCompletionRecycle.Location = new Point(11, 245);
            rdoAfterCompletionRecycle.Margin = new Padding(6, 5, 6, 5);
            rdoAfterCompletionRecycle.Name = "rdoAfterCompletionRecycle";
            rdoAfterCompletionRecycle.Size = new Size(94, 29);
            rdoAfterCompletionRecycle.TabIndex = 6;
            rdoAfterCompletionRecycle.TabStop = true;
            rdoAfterCompletionRecycle.Text = "Recycle";
            rdoAfterCompletionRecycle.UseVisualStyleBackColor = true;
            rdoAfterCompletionRecycle.CheckedChanged += rdoAfterCompletionRecycle_CheckedChanged;
            // 
            // rdoAfterCompletionStop
            // 
            rdoAfterCompletionStop.AutoSize = true;
            rdoAfterCompletionStop.Location = new Point(11, 202);
            rdoAfterCompletionStop.Margin = new Padding(6, 5, 6, 5);
            rdoAfterCompletionStop.Name = "rdoAfterCompletionStop";
            rdoAfterCompletionStop.Size = new Size(133, 29);
            rdoAfterCompletionStop.TabIndex = 6;
            rdoAfterCompletionStop.TabStop = true;
            rdoAfterCompletionStop.Text = "Stop Thread";
            rdoAfterCompletionStop.UseVisualStyleBackColor = true;
            rdoAfterCompletionStop.CheckedChanged += rdoAfterCompletionStop_CheckedChanged;
            // 
            // rdoAfterCompletionContinue
            // 
            rdoAfterCompletionContinue.AutoSize = true;
            rdoAfterCompletionContinue.Location = new Point(11, 63);
            rdoAfterCompletionContinue.Margin = new Padding(6, 5, 6, 5);
            rdoAfterCompletionContinue.Name = "rdoAfterCompletionContinue";
            rdoAfterCompletionContinue.Size = new Size(108, 29);
            rdoAfterCompletionContinue.TabIndex = 0;
            rdoAfterCompletionContinue.TabStop = true;
            rdoAfterCompletionContinue.Text = "Continue";
            rdoAfterCompletionContinue.UseVisualStyleBackColor = true;
            rdoAfterCompletionContinue.CheckedChanged += rdoAfterCompletionContinue_CheckedChanged;
            // 
            // rdoAfterCompletionHome
            // 
            rdoAfterCompletionHome.AutoSize = true;
            rdoAfterCompletionHome.Location = new Point(11, 110);
            rdoAfterCompletionHome.Margin = new Padding(6, 5, 6, 5);
            rdoAfterCompletionHome.Name = "rdoAfterCompletionHome";
            rdoAfterCompletionHome.Size = new Size(149, 29);
            rdoAfterCompletionHome.TabIndex = 1;
            rdoAfterCompletionHome.TabStop = true;
            rdoAfterCompletionHome.Text = "Back to Home";
            rdoAfterCompletionHome.UseVisualStyleBackColor = true;
            rdoAfterCompletionHome.CheckedChanged += rdoAfterCompletionHome_CheckedChanged;
            // 
            // rdoAfterCompletionParent
            // 
            rdoAfterCompletionParent.AutoSize = true;
            rdoAfterCompletionParent.Location = new Point(11, 155);
            rdoAfterCompletionParent.Margin = new Padding(6, 5, 6, 5);
            rdoAfterCompletionParent.Name = "rdoAfterCompletionParent";
            rdoAfterCompletionParent.Size = new Size(149, 29);
            rdoAfterCompletionParent.TabIndex = 2;
            rdoAfterCompletionParent.TabStop = true;
            rdoAfterCompletionParent.Text = "Back to Parent";
            rdoAfterCompletionParent.UseVisualStyleBackColor = true;
            rdoAfterCompletionParent.CheckedChanged += rdoAfterCompletionParent_CheckedChanged;
            // 
            // panelRightObject
            // 
            panelRightObject.BorderStyle = BorderStyle.FixedSingle;
            panelRightObject.Controls.Add(NumericObjectThreshold);
            panelRightObject.Controls.Add(cmdRightObject);
            panelRightObject.Controls.Add(Label52);
            panelRightObject.Controls.Add(cboObject);
            panelRightObject.Controls.Add(cmdMaxMask);
            panelRightObject.Controls.Add(lblSearchObject);
            panelRightObject.Controls.Add(lblMaskSize);
            panelRightObject.Controls.Add(lblColorChannel);
            panelRightObject.Controls.Add(Label51);
            panelRightObject.Controls.Add(PictureBoxEventObjectSelection);
            panelRightObject.Controls.Add(Label50);
            panelRightObject.Controls.Add(cboChannel);
            panelRightObject.Location = new Point(3, 910);
            panelRightObject.Name = "panelRightObject";
            panelRightObject.Size = new Size(465, 379);
            panelRightObject.TabIndex = 34;
            // 
            // NumericObjectThreshold
            // 
            NumericObjectThreshold.Font = new Font("Microsoft Sans Serif", 12F);
            NumericObjectThreshold.Location = new Point(171, 153);
            NumericObjectThreshold.Margin = new Padding(6, 5, 6, 5);
            NumericObjectThreshold.Name = "NumericObjectThreshold";
            NumericObjectThreshold.Size = new Size(229, 35);
            NumericObjectThreshold.TabIndex = 10;
            NumericObjectThreshold.ValueChanged += NumericObjectThreshold_ValueChanged;
            // 
            // cmdRightObject
            // 
            cmdRightObject.BackColor = SystemColors.ButtonShadow;
            cmdRightObject.Cursor = Cursors.Hand;
            cmdRightObject.Dock = DockStyle.Top;
            cmdRightObject.FlatAppearance.BorderSize = 0;
            cmdRightObject.FlatStyle = FlatStyle.Flat;
            cmdRightObject.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightObject.ForeColor = SystemColors.ButtonFace;
            cmdRightObject.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightObject.ImageIndex = 22;
            cmdRightObject.ImageList = ImageList1;
            cmdRightObject.Location = new Point(0, 0);
            cmdRightObject.Margin = new Padding(6, 5, 6, 5);
            cmdRightObject.Name = "cmdRightObject";
            cmdRightObject.Size = new Size(463, 42);
            cmdRightObject.TabIndex = 11;
            cmdRightObject.Text = "Object";
            cmdRightObject.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightObject.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightObject.UseVisualStyleBackColor = false;
            cmdRightObject.Click += cmdRightObject_Click;
            // 
            // Label52
            // 
            Label52.AutoSize = true;
            Label52.Location = new Point(37, 170);
            Label52.Margin = new Padding(6, 0, 6, 0);
            Label52.Name = "Label52";
            Label52.Size = new Size(90, 25);
            Label52.TabIndex = 9;
            Label52.Text = "Threshold";
            // 
            // cboObject
            // 
            cboObject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboObject.FormattingEnabled = true;
            cboObject.Location = new Point(171, 58);
            cboObject.Margin = new Padding(6, 5, 6, 5);
            cboObject.Name = "cboObject";
            cboObject.Size = new Size(230, 33);
            cboObject.TabIndex = 0;
            cboObject.SelectedIndexChanged += cboObject_SelectedIndexChanged;
            // 
            // cmdMaxMask
            // 
            cmdMaxMask.Location = new Point(171, 235);
            cmdMaxMask.Margin = new Padding(6, 5, 6, 5);
            cmdMaxMask.Name = "cmdMaxMask";
            cmdMaxMask.Size = new Size(226, 45);
            cmdMaxMask.TabIndex = 8;
            cmdMaxMask.Text = "Set Mask to Max";
            cmdMaxMask.UseVisualStyleBackColor = true;
            cmdMaxMask.Click += cmdMaxMask_Click;
            // 
            // lblSearchObject
            // 
            lblSearchObject.Location = new Point(37, 58);
            lblSearchObject.Margin = new Padding(6, 0, 6, 0);
            lblSearchObject.Name = "lblSearchObject";
            lblSearchObject.Size = new Size(209, 40);
            lblSearchObject.TabIndex = 2;
            lblSearchObject.Text = "Search Object";
            // 
            // lblMaskSize
            // 
            lblMaskSize.AutoSize = true;
            lblMaskSize.Location = new Point(169, 205);
            lblMaskSize.Margin = new Padding(6, 0, 6, 0);
            lblMaskSize.Name = "lblMaskSize";
            lblMaskSize.Size = new Size(104, 25);
            lblMaskSize.TabIndex = 7;
            lblMaskSize.Text = "lblMaskSize";
            // 
            // lblColorChannel
            // 
            lblColorChannel.Location = new Point(37, 112);
            lblColorChannel.Margin = new Padding(6, 0, 6, 0);
            lblColorChannel.Name = "lblColorChannel";
            lblColorChannel.Size = new Size(131, 40);
            lblColorChannel.TabIndex = 4;
            lblColorChannel.Text = "Color Channel";
            // 
            // Label51
            // 
            Label51.AutoSize = true;
            Label51.Location = new Point(37, 205);
            Label51.Margin = new Padding(6, 0, 6, 0);
            Label51.Name = "Label51";
            Label51.Size = new Size(90, 25);
            Label51.TabIndex = 6;
            Label51.Text = "Mask Size";
            // 
            // PictureBoxEventObjectSelection
            // 
            PictureBoxEventObjectSelection.Location = new Point(171, 290);
            PictureBoxEventObjectSelection.Margin = new Padding(6, 5, 6, 5);
            PictureBoxEventObjectSelection.Name = "PictureBoxEventObjectSelection";
            PictureBoxEventObjectSelection.Size = new Size(100, 50);
            PictureBoxEventObjectSelection.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBoxEventObjectSelection.TabIndex = 1;
            PictureBoxEventObjectSelection.TabStop = false;
            // 
            // Label50
            // 
            Label50.AutoSize = true;
            Label50.Location = new Point(41, 290);
            Label50.Margin = new Padding(6, 0, 6, 0);
            Label50.Name = "Label50";
            Label50.Size = new Size(64, 25);
            Label50.TabIndex = 5;
            Label50.Text = "Object";
            // 
            // cboChannel
            // 
            cboChannel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChannel.FormattingEnabled = true;
            cboChannel.Items.AddRange(new object[] { "Choose a Channel", "Red Channel", "Green Channel", "Blue Channel" });
            cboChannel.Location = new Point(171, 112);
            cboChannel.Margin = new Padding(6, 5, 6, 5);
            cboChannel.Name = "cboChannel";
            cboChannel.Size = new Size(230, 33);
            cboChannel.TabIndex = 3;
            cboChannel.SelectedIndexChanged += cboChannel_SelectedIndexChanged;
            // 
            // panelRightSwipeProperties
            // 
            panelRightSwipeProperties.BorderStyle = BorderStyle.FixedSingle;
            panelRightSwipeProperties.Controls.Add(label60);
            panelRightSwipeProperties.Controls.Add(groupBox8);
            panelRightSwipeProperties.Controls.Add(groupBox5);
            panelRightSwipeProperties.Controls.Add(groupBoxClickDragReleaseObjectSearch);
            panelRightSwipeProperties.Controls.Add(numericSwipeVelocity);
            panelRightSwipeProperties.Controls.Add(cmdRightSwipeProperties);
            panelRightSwipeProperties.Location = new Point(3, 1295);
            panelRightSwipeProperties.Name = "panelRightSwipeProperties";
            panelRightSwipeProperties.Size = new Size(465, 389);
            panelRightSwipeProperties.TabIndex = 40;
            // 
            // label60
            // 
            label60.AutoSize = true;
            label60.Location = new Point(209, 63);
            label60.Name = "label60";
            label60.Size = new Size(219, 25);
            label60.TabIndex = 16;
            label60.Text = "Velocity (ms)  1000 = 1sec";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(label59);
            groupBox8.Controls.Add(label57);
            groupBox8.Controls.Add(numericSwipeEndWidth);
            groupBox8.Controls.Add(numericSwipeEndHeight);
            groupBox8.Location = new Point(20, 230);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(179, 138);
            groupBox8.TabIndex = 15;
            groupBox8.TabStop = false;
            groupBox8.Text = "End Size";
            // 
            // label59
            // 
            label59.AutoSize = true;
            label59.Location = new Point(114, 95);
            label59.Name = "label59";
            label59.Size = new Size(60, 25);
            label59.TabIndex = 11;
            label59.Text = "Width";
            // 
            // label57
            // 
            label57.AutoSize = true;
            label57.Location = new Point(114, 40);
            label57.Name = "label57";
            label57.Size = new Size(65, 25);
            label57.TabIndex = 11;
            label57.Text = "Height";
            // 
            // numericSwipeEndWidth
            // 
            numericSwipeEndWidth.Font = new Font("Microsoft Sans Serif", 12F);
            numericSwipeEndWidth.Location = new Point(13, 88);
            numericSwipeEndWidth.Margin = new Padding(6, 5, 6, 5);
            numericSwipeEndWidth.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericSwipeEndWidth.Name = "numericSwipeEndWidth";
            numericSwipeEndWidth.Size = new Size(94, 35);
            numericSwipeEndWidth.TabIndex = 10;
            numericSwipeEndWidth.ValueChanged += numericSwipeEndWidth_ValueChanged;
            // 
            // numericSwipeEndHeight
            // 
            numericSwipeEndHeight.Font = new Font("Microsoft Sans Serif", 12F);
            numericSwipeEndHeight.Location = new Point(13, 35);
            numericSwipeEndHeight.Margin = new Padding(6, 5, 6, 5);
            numericSwipeEndHeight.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericSwipeEndHeight.Name = "numericSwipeEndHeight";
            numericSwipeEndHeight.Size = new Size(94, 35);
            numericSwipeEndHeight.TabIndex = 10;
            numericSwipeEndHeight.ValueChanged += numericSwipeEndHeight_ValueChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label58);
            groupBox5.Controls.Add(label56);
            groupBox5.Controls.Add(numericSwipeStartWidth);
            groupBox5.Controls.Add(numericSwipeStartHeight);
            groupBox5.Location = new Point(20, 60);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(179, 150);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "Start Size";
            // 
            // label58
            // 
            label58.AutoSize = true;
            label58.Location = new Point(114, 100);
            label58.Name = "label58";
            label58.Size = new Size(60, 25);
            label58.TabIndex = 11;
            label58.Text = "Width";
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Location = new Point(114, 40);
            label56.Name = "label56";
            label56.Size = new Size(65, 25);
            label56.TabIndex = 11;
            label56.Text = "Height";
            // 
            // numericSwipeStartWidth
            // 
            numericSwipeStartWidth.Font = new Font("Microsoft Sans Serif", 12F);
            numericSwipeStartWidth.Location = new Point(13, 92);
            numericSwipeStartWidth.Margin = new Padding(6, 5, 6, 5);
            numericSwipeStartWidth.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericSwipeStartWidth.Name = "numericSwipeStartWidth";
            numericSwipeStartWidth.Size = new Size(94, 35);
            numericSwipeStartWidth.TabIndex = 10;
            numericSwipeStartWidth.ValueChanged += numericSwipeStartWidth_ValueChanged;
            // 
            // numericSwipeStartHeight
            // 
            numericSwipeStartHeight.Font = new Font("Microsoft Sans Serif", 12F);
            numericSwipeStartHeight.Location = new Point(13, 35);
            numericSwipeStartHeight.Margin = new Padding(6, 5, 6, 5);
            numericSwipeStartHeight.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericSwipeStartHeight.Name = "numericSwipeStartHeight";
            numericSwipeStartHeight.Size = new Size(94, 35);
            numericSwipeStartHeight.TabIndex = 10;
            numericSwipeStartHeight.ValueChanged += numericSwipeStartHeight_ValueChanged;
            // 
            // groupBoxClickDragReleaseObjectSearch
            // 
            groupBoxClickDragReleaseObjectSearch.Controls.Add(rdoObjectSearchNone);
            groupBoxClickDragReleaseObjectSearch.Controls.Add(rdoObjectSearchEnd);
            groupBoxClickDragReleaseObjectSearch.Controls.Add(rdoObjectSearchStart);
            groupBoxClickDragReleaseObjectSearch.Location = new Point(226, 160);
            groupBoxClickDragReleaseObjectSearch.Name = "groupBoxClickDragReleaseObjectSearch";
            groupBoxClickDragReleaseObjectSearch.Size = new Size(189, 210);
            groupBoxClickDragReleaseObjectSearch.TabIndex = 14;
            groupBoxClickDragReleaseObjectSearch.TabStop = false;
            groupBoxClickDragReleaseObjectSearch.Text = "Object Search";
            // 
            // rdoObjectSearchNone
            // 
            rdoObjectSearchNone.AutoSize = true;
            rdoObjectSearchNone.Location = new Point(17, 117);
            rdoObjectSearchNone.Name = "rdoObjectSearchNone";
            rdoObjectSearchNone.Size = new Size(80, 29);
            rdoObjectSearchNone.TabIndex = 1;
            rdoObjectSearchNone.TabStop = true;
            rdoObjectSearchNone.Text = "None";
            rdoObjectSearchNone.UseVisualStyleBackColor = true;
            rdoObjectSearchNone.CheckedChanged += rdoObjectSearchNone_CheckedChanged;
            // 
            // rdoObjectSearchEnd
            // 
            rdoObjectSearchEnd.AutoSize = true;
            rdoObjectSearchEnd.Location = new Point(17, 80);
            rdoObjectSearchEnd.Name = "rdoObjectSearchEnd";
            rdoObjectSearchEnd.Size = new Size(101, 29);
            rdoObjectSearchEnd.TabIndex = 1;
            rdoObjectSearchEnd.TabStop = true;
            rdoObjectSearchEnd.Text = "Use End";
            rdoObjectSearchEnd.UseVisualStyleBackColor = true;
            rdoObjectSearchEnd.CheckedChanged += rdoObjectSearchEnd_CheckedChanged;
            // 
            // rdoObjectSearchStart
            // 
            rdoObjectSearchStart.AutoSize = true;
            rdoObjectSearchStart.Location = new Point(17, 40);
            rdoObjectSearchStart.Name = "rdoObjectSearchStart";
            rdoObjectSearchStart.Size = new Size(107, 29);
            rdoObjectSearchStart.TabIndex = 0;
            rdoObjectSearchStart.TabStop = true;
            rdoObjectSearchStart.Text = "Use Start";
            rdoObjectSearchStart.UseVisualStyleBackColor = true;
            rdoObjectSearchStart.CheckedChanged += rdoObjectSearchStart_CheckedChanged;
            // 
            // numericSwipeVelocity
            // 
            numericSwipeVelocity.Font = new Font("Microsoft Sans Serif", 12F);
            numericSwipeVelocity.Location = new Point(207, 100);
            numericSwipeVelocity.Margin = new Padding(6, 5, 6, 5);
            numericSwipeVelocity.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericSwipeVelocity.Name = "numericSwipeVelocity";
            numericSwipeVelocity.Size = new Size(119, 35);
            numericSwipeVelocity.TabIndex = 10;
            numericSwipeVelocity.ValueChanged += numericSwipeVelocity_ValueChanged;
            // 
            // cmdRightSwipeProperties
            // 
            cmdRightSwipeProperties.BackColor = SystemColors.ButtonShadow;
            cmdRightSwipeProperties.Cursor = Cursors.Hand;
            cmdRightSwipeProperties.Dock = DockStyle.Top;
            cmdRightSwipeProperties.FlatAppearance.BorderSize = 0;
            cmdRightSwipeProperties.FlatStyle = FlatStyle.Flat;
            cmdRightSwipeProperties.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightSwipeProperties.ForeColor = SystemColors.ButtonFace;
            cmdRightSwipeProperties.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightSwipeProperties.ImageIndex = 22;
            cmdRightSwipeProperties.ImageList = ImageList1;
            cmdRightSwipeProperties.Location = new Point(0, 0);
            cmdRightSwipeProperties.Margin = new Padding(6, 5, 6, 5);
            cmdRightSwipeProperties.Name = "cmdRightSwipeProperties";
            cmdRightSwipeProperties.Size = new Size(463, 42);
            cmdRightSwipeProperties.TabIndex = 13;
            cmdRightSwipeProperties.Text = "Mouse Positioning";
            cmdRightSwipeProperties.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightSwipeProperties.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightSwipeProperties.UseVisualStyleBackColor = false;
            cmdRightSwipeProperties.Click += cmdRightSwipeProperties_Click;
            // 
            // panelRightClickProperties
            // 
            panelRightClickProperties.BorderStyle = BorderStyle.FixedSingle;
            panelRightClickProperties.Controls.Add(label55);
            panelRightClickProperties.Controls.Add(NumericClickSpeed);
            panelRightClickProperties.Controls.Add(label54);
            panelRightClickProperties.Controls.Add(cmdRightClickProperties);
            panelRightClickProperties.Location = new Point(3, 1690);
            panelRightClickProperties.Name = "panelRightClickProperties";
            panelRightClickProperties.Size = new Size(465, 165);
            panelRightClickProperties.TabIndex = 39;
            // 
            // label55
            // 
            label55.Location = new Point(14, 105);
            label55.Name = "label55";
            label55.Size = new Size(406, 63);
            label55.TabIndex = 15;
            label55.Text = "How long to hold the mouse down during a click event, some applications won't respond to 0.";
            // 
            // NumericClickSpeed
            // 
            NumericClickSpeed.Font = new Font("Microsoft Sans Serif", 15F);
            NumericClickSpeed.Location = new Point(181, 47);
            NumericClickSpeed.Margin = new Padding(6, 5, 6, 5);
            NumericClickSpeed.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            NumericClickSpeed.Name = "NumericClickSpeed";
            NumericClickSpeed.Size = new Size(106, 41);
            NumericClickSpeed.TabIndex = 14;
            NumericClickSpeed.ValueChanged += NumericClickSpeed_ValueChanged;
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new Point(14, 60);
            label54.Name = "label54";
            label54.Size = new Size(161, 25);
            label54.TabIndex = 13;
            label54.Text = "Click Duration (ms)";
            // 
            // cmdRightClickProperties
            // 
            cmdRightClickProperties.BackColor = SystemColors.ButtonShadow;
            cmdRightClickProperties.Cursor = Cursors.Hand;
            cmdRightClickProperties.Dock = DockStyle.Top;
            cmdRightClickProperties.FlatAppearance.BorderSize = 0;
            cmdRightClickProperties.FlatStyle = FlatStyle.Flat;
            cmdRightClickProperties.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightClickProperties.ForeColor = SystemColors.ButtonFace;
            cmdRightClickProperties.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightClickProperties.ImageIndex = 22;
            cmdRightClickProperties.ImageList = ImageList1;
            cmdRightClickProperties.Location = new Point(0, 0);
            cmdRightClickProperties.Margin = new Padding(6, 5, 6, 5);
            cmdRightClickProperties.Name = "cmdRightClickProperties";
            cmdRightClickProperties.Size = new Size(463, 42);
            cmdRightClickProperties.TabIndex = 12;
            cmdRightClickProperties.Text = "Click Properties";
            cmdRightClickProperties.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightClickProperties.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightClickProperties.UseVisualStyleBackColor = false;
            cmdRightClickProperties.Click += cmdRightClickProperties_Click;
            // 
            // panelRightLogic
            // 
            panelRightLogic.BorderStyle = BorderStyle.FixedSingle;
            panelRightLogic.Controls.Add(cmdRightLogic);
            panelRightLogic.Controls.Add(cboPoints);
            panelRightLogic.Controls.Add(rdoCustom);
            panelRightLogic.Controls.Add(label31);
            panelRightLogic.Controls.Add(rdoOR);
            panelRightLogic.Controls.Add(rdoAnd);
            panelRightLogic.Location = new Point(3, 1861);
            panelRightLogic.Name = "panelRightLogic";
            panelRightLogic.Size = new Size(465, 135);
            panelRightLogic.TabIndex = 35;
            // 
            // cmdRightLogic
            // 
            cmdRightLogic.BackColor = SystemColors.ButtonShadow;
            cmdRightLogic.Cursor = Cursors.Hand;
            cmdRightLogic.Dock = DockStyle.Top;
            cmdRightLogic.FlatAppearance.BorderSize = 0;
            cmdRightLogic.FlatStyle = FlatStyle.Flat;
            cmdRightLogic.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightLogic.ForeColor = SystemColors.ButtonFace;
            cmdRightLogic.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightLogic.ImageIndex = 22;
            cmdRightLogic.ImageList = ImageList1;
            cmdRightLogic.Location = new Point(0, 0);
            cmdRightLogic.Margin = new Padding(6, 5, 6, 5);
            cmdRightLogic.Name = "cmdRightLogic";
            cmdRightLogic.Size = new Size(463, 42);
            cmdRightLogic.TabIndex = 12;
            cmdRightLogic.Text = "Logic";
            cmdRightLogic.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightLogic.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightLogic.UseVisualStyleBackColor = false;
            cmdRightLogic.Click += cmdRightLogic_Click;
            // 
            // cboPoints
            // 
            cboPoints.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPoints.FormattingEnabled = true;
            cboPoints.Location = new Point(329, 90);
            cboPoints.Margin = new Padding(6, 5, 6, 5);
            cboPoints.Name = "cboPoints";
            cboPoints.Size = new Size(101, 33);
            cboPoints.TabIndex = 2;
            cboPoints.TextChanged += cboPoints_TextChanged;
            // 
            // rdoCustom
            // 
            rdoCustom.AutoSize = true;
            rdoCustom.Location = new Point(151, 55);
            rdoCustom.Margin = new Padding(6, 5, 6, 5);
            rdoCustom.Name = "rdoCustom";
            rdoCustom.Size = new Size(99, 29);
            rdoCustom.TabIndex = 5;
            rdoCustom.TabStop = true;
            rdoCustom.Text = "Custom";
            rdoCustom.UseVisualStyleBackColor = true;
            rdoCustom.CheckedChanged += rdoCustom_CheckedChanged;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(329, 55);
            label31.Margin = new Padding(6, 0, 6, 0);
            label31.Name = "label31";
            label31.Size = new Size(95, 25);
            label31.TabIndex = 3;
            label31.Text = "Points +/-.";
            // 
            // rdoOR
            // 
            rdoOR.AutoSize = true;
            rdoOR.Location = new Point(84, 55);
            rdoOR.Margin = new Padding(6, 5, 6, 5);
            rdoOR.Name = "rdoOR";
            rdoOR.Size = new Size(62, 29);
            rdoOR.TabIndex = 1;
            rdoOR.TabStop = true;
            rdoOR.Text = "OR";
            rdoOR.UseVisualStyleBackColor = true;
            rdoOR.CheckedChanged += rdoOR_CheckedChanged;
            // 
            // rdoAnd
            // 
            rdoAnd.AutoSize = true;
            rdoAnd.Location = new Point(10, 55);
            rdoAnd.Margin = new Padding(6, 5, 6, 5);
            rdoAnd.Name = "rdoAnd";
            rdoAnd.Size = new Size(75, 29);
            rdoAnd.TabIndex = 0;
            rdoAnd.TabStop = true;
            rdoAnd.Text = "AND";
            rdoAnd.UseVisualStyleBackColor = true;
            rdoAnd.CheckedChanged += rdoAnd_CheckedChanged;
            // 
            // panelRightCustomLogic
            // 
            panelRightCustomLogic.BorderStyle = BorderStyle.FixedSingle;
            panelRightCustomLogic.Controls.Add(cmdValidate);
            panelRightCustomLogic.Controls.Add(label37);
            panelRightCustomLogic.Controls.Add(txtCustomLogic);
            panelRightCustomLogic.Location = new Point(3, 2002);
            panelRightCustomLogic.Name = "panelRightCustomLogic";
            panelRightCustomLogic.Size = new Size(463, 177);
            panelRightCustomLogic.TabIndex = 36;
            // 
            // cmdValidate
            // 
            cmdValidate.Location = new Point(334, 2);
            cmdValidate.Margin = new Padding(6, 5, 6, 5);
            cmdValidate.Name = "cmdValidate";
            cmdValidate.Size = new Size(97, 35);
            cmdValidate.TabIndex = 7;
            cmdValidate.Text = "Validate";
            cmdValidate.UseVisualStyleBackColor = true;
            cmdValidate.Click += cmdValidate_Click;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(10, 12);
            label37.Name = "label37";
            label37.Size = new Size(308, 25);
            label37.TabIndex = 7;
            label37.Text = "Custom Logic:  NOT 1 AND ( 2 OR 3 )";
            label37.Click += label37_Click;
            // 
            // txtCustomLogic
            // 
            txtCustomLogic.Dock = DockStyle.Bottom;
            txtCustomLogic.Location = new Point(0, 41);
            txtCustomLogic.Margin = new Padding(6, 5, 6, 5);
            txtCustomLogic.Multiline = true;
            txtCustomLogic.Name = "txtCustomLogic";
            txtCustomLogic.Size = new Size(461, 134);
            txtCustomLogic.TabIndex = 6;
            txtCustomLogic.TextChanged += txtCustom_TextChanged;
            // 
            // panelRightPointGrid
            // 
            panelRightPointGrid.Controls.Add(dgv);
            panelRightPointGrid.Location = new Point(3, 2185);
            panelRightPointGrid.Name = "panelRightPointGrid";
            panelRightPointGrid.Size = new Size(467, 297);
            panelRightPointGrid.TabIndex = 37;
            // 
            // dgv
            // 
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new DataGridViewColumn[] { dgvID, dgvRed, dgvBlue, dgvGreen, dgvX, dgvY, dgvScan, dgvRemove });
            dgv.Cursor = Cursors.Hand;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 0);
            dgv.Margin = new Padding(6, 5, 6, 5);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 62;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(467, 297);
            dgv.TabIndex = 4;
            dgv.CellClick += dgv_CellClick;
            // 
            // dgvID
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvID.DefaultCellStyle = dataGridViewCellStyle11;
            dgvID.HeaderText = "ID";
            dgvID.MinimumWidth = 10;
            dgvID.Name = "dgvID";
            // 
            // dgvRed
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvRed.DefaultCellStyle = dataGridViewCellStyle12;
            dgvRed.HeaderText = "R";
            dgvRed.MinimumWidth = 10;
            dgvRed.Name = "dgvRed";
            // 
            // dgvBlue
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvBlue.DefaultCellStyle = dataGridViewCellStyle13;
            dgvBlue.HeaderText = "B";
            dgvBlue.MinimumWidth = 10;
            dgvBlue.Name = "dgvBlue";
            // 
            // dgvGreen
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvGreen.DefaultCellStyle = dataGridViewCellStyle14;
            dgvGreen.HeaderText = "G";
            dgvGreen.MinimumWidth = 10;
            dgvGreen.Name = "dgvGreen";
            // 
            // dgvX
            // 
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvX.DefaultCellStyle = dataGridViewCellStyle15;
            dgvX.HeaderText = "X";
            dgvX.MinimumWidth = 10;
            dgvX.Name = "dgvX";
            // 
            // dgvY
            // 
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvY.DefaultCellStyle = dataGridViewCellStyle16;
            dgvY.HeaderText = "Y";
            dgvY.MinimumWidth = 10;
            dgvY.Name = "dgvY";
            // 
            // dgvScan
            // 
            dgvScan.HeaderText = "Scan";
            dgvScan.MinimumWidth = 20;
            dgvScan.Name = "dgvScan";
            dgvScan.Resizable = DataGridViewTriState.True;
            dgvScan.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvScan.ToolTipText = "Scan and Add Additional Colors from location, from Current Target Window";
            // 
            // dgvRemove
            // 
            dgvRemove.HeaderText = "Rem";
            dgvRemove.MinimumWidth = 20;
            dgvRemove.Name = "dgvRemove";
            dgvRemove.Text = "Rem";
            // 
            // panelRightInformation
            // 
            panelRightInformation.BorderStyle = BorderStyle.FixedSingle;
            panelRightInformation.Controls.Add(pictureBoxInformationWarning);
            panelRightInformation.Controls.Add(lblInformation);
            panelRightInformation.Controls.Add(cmdRightInformation);
            panelRightInformation.Location = new Point(3, 2488);
            panelRightInformation.Name = "panelRightInformation";
            panelRightInformation.Size = new Size(465, 165);
            panelRightInformation.TabIndex = 41;
            // 
            // pictureBoxInformationWarning
            // 
            pictureBoxInformationWarning.BackgroundImageLayout = ImageLayout.None;
            pictureBoxInformationWarning.Image = Properties.Resources.StatusWarning_71x71;
            pictureBoxInformationWarning.Location = new Point(10, 60);
            pictureBoxInformationWarning.Margin = new Padding(6, 5, 6, 5);
            pictureBoxInformationWarning.Name = "pictureBoxInformationWarning";
            pictureBoxInformationWarning.Size = new Size(67, 65);
            pictureBoxInformationWarning.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxInformationWarning.TabIndex = 14;
            pictureBoxInformationWarning.TabStop = false;
            pictureBoxInformationWarning.Visible = false;
            // 
            // lblInformation
            // 
            lblInformation.Location = new Point(80, 60);
            lblInformation.Margin = new Padding(6, 0, 6, 0);
            lblInformation.Name = "lblInformation";
            lblInformation.Size = new Size(373, 90);
            lblInformation.TabIndex = 13;
            lblInformation.Text = "lblInformation";
            // 
            // cmdRightInformation
            // 
            cmdRightInformation.BackColor = SystemColors.ButtonShadow;
            cmdRightInformation.Cursor = Cursors.Hand;
            cmdRightInformation.Dock = DockStyle.Top;
            cmdRightInformation.FlatAppearance.BorderSize = 0;
            cmdRightInformation.FlatStyle = FlatStyle.Flat;
            cmdRightInformation.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightInformation.ForeColor = SystemColors.ButtonFace;
            cmdRightInformation.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightInformation.ImageIndex = 22;
            cmdRightInformation.ImageList = ImageList1;
            cmdRightInformation.Location = new Point(0, 0);
            cmdRightInformation.Margin = new Padding(6, 5, 6, 5);
            cmdRightInformation.Name = "cmdRightInformation";
            cmdRightInformation.Size = new Size(463, 42);
            cmdRightInformation.TabIndex = 12;
            cmdRightInformation.Text = "Information";
            cmdRightInformation.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightInformation.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightInformation.UseVisualStyleBackColor = false;
            cmdRightInformation.Click += cmdRightInformation_Click;
            // 
            // FlowLayoutPanelColorEvent2
            // 
            FlowLayoutPanelColorEvent2.AutoScroll = true;
            FlowLayoutPanelColorEvent2.Controls.Add(cmdFlowLayoutPanelColorEvent2);
            FlowLayoutPanelColorEvent2.Controls.Add(panelRightColorAtPointer);
            FlowLayoutPanelColorEvent2.Controls.Add(panelRightLimit);
            FlowLayoutPanelColorEvent2.Controls.Add(panelRightAnchor);
            FlowLayoutPanelColorEvent2.Controls.Add(panelRightOffset);
            FlowLayoutPanelColorEvent2.Controls.Add(panelRightDragMode);
            FlowLayoutPanelColorEvent2.Dock = DockStyle.Fill;
            FlowLayoutPanelColorEvent2.FlowDirection = FlowDirection.TopDown;
            FlowLayoutPanelColorEvent2.Location = new Point(1653, 3);
            FlowLayoutPanelColorEvent2.Name = "FlowLayoutPanelColorEvent2";
            FlowLayoutPanelColorEvent2.Size = new Size(477, 1331);
            FlowLayoutPanelColorEvent2.TabIndex = 33;
            FlowLayoutPanelColorEvent2.WrapContents = false;
            // 
            // cmdFlowLayoutPanelColorEvent2
            // 
            cmdFlowLayoutPanelColorEvent2.BackColor = SystemColors.Control;
            cmdFlowLayoutPanelColorEvent2.Cursor = Cursors.Hand;
            cmdFlowLayoutPanelColorEvent2.FlatAppearance.BorderSize = 0;
            cmdFlowLayoutPanelColorEvent2.FlatStyle = FlatStyle.Flat;
            cmdFlowLayoutPanelColorEvent2.Font = new Font("Microsoft Sans Serif", 7F);
            cmdFlowLayoutPanelColorEvent2.Location = new Point(6, 0);
            cmdFlowLayoutPanelColorEvent2.Margin = new Padding(6, 0, 6, 0);
            cmdFlowLayoutPanelColorEvent2.Name = "cmdFlowLayoutPanelColorEvent2";
            cmdFlowLayoutPanelColorEvent2.Size = new Size(467, 35);
            cmdFlowLayoutPanelColorEvent2.TabIndex = 2;
            cmdFlowLayoutPanelColorEvent2.Text = "<<  ";
            cmdFlowLayoutPanelColorEvent2.TextAlign = ContentAlignment.MiddleRight;
            cmdFlowLayoutPanelColorEvent2.UseVisualStyleBackColor = false;
            cmdFlowLayoutPanelColorEvent2.Click += cmdFlowLayoutPanelColorEvent2_Click;
            // 
            // panelRightColorAtPointer
            // 
            panelRightColorAtPointer.BorderStyle = BorderStyle.FixedSingle;
            panelRightColorAtPointer.Controls.Add(cmdRightColorAtPointer);
            panelRightColorAtPointer.Controls.Add(PictureBox2);
            panelRightColorAtPointer.Controls.Add(PanelSelectedColor);
            panelRightColorAtPointer.Location = new Point(6, 40);
            panelRightColorAtPointer.Margin = new Padding(6, 5, 6, 5);
            panelRightColorAtPointer.Name = "panelRightColorAtPointer";
            panelRightColorAtPointer.Size = new Size(465, 417);
            panelRightColorAtPointer.TabIndex = 0;
            // 
            // cmdRightColorAtPointer
            // 
            cmdRightColorAtPointer.BackColor = SystemColors.ButtonShadow;
            cmdRightColorAtPointer.Cursor = Cursors.Hand;
            cmdRightColorAtPointer.Dock = DockStyle.Top;
            cmdRightColorAtPointer.FlatAppearance.BorderSize = 0;
            cmdRightColorAtPointer.FlatStyle = FlatStyle.Flat;
            cmdRightColorAtPointer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightColorAtPointer.ForeColor = SystemColors.ButtonFace;
            cmdRightColorAtPointer.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightColorAtPointer.ImageIndex = 22;
            cmdRightColorAtPointer.ImageList = ImageList1;
            cmdRightColorAtPointer.Location = new Point(0, 0);
            cmdRightColorAtPointer.Margin = new Padding(6, 5, 6, 5);
            cmdRightColorAtPointer.Name = "cmdRightColorAtPointer";
            cmdRightColorAtPointer.Size = new Size(463, 45);
            cmdRightColorAtPointer.TabIndex = 0;
            cmdRightColorAtPointer.Text = "Color At Pointer";
            cmdRightColorAtPointer.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightColorAtPointer.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightColorAtPointer.UseVisualStyleBackColor = false;
            cmdRightColorAtPointer.Click += cmdColorAtPointer_Click;
            // 
            // PictureBox2
            // 
            PictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureBox2.Image = (Image)resources.GetObject("PictureBox2.Image");
            PictureBox2.Location = new Point(103, 45);
            PictureBox2.Margin = new Padding(6, 5, 6, 5);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new Size(267, 308);
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.TabIndex = 0;
            PictureBox2.TabStop = false;
            // 
            // PanelSelectedColor
            // 
            PanelSelectedColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PanelSelectedColor.Controls.Add(lblRHSColor);
            PanelSelectedColor.Controls.Add(lblRHSXY);
            PanelSelectedColor.Location = new Point(103, 350);
            PanelSelectedColor.Margin = new Padding(6, 5, 6, 5);
            PanelSelectedColor.Name = "PanelSelectedColor";
            PanelSelectedColor.Size = new Size(267, 70);
            PanelSelectedColor.TabIndex = 1;
            // 
            // lblRHSColor
            // 
            lblRHSColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRHSColor.AutoSize = true;
            lblRHSColor.Location = new Point(7, 38);
            lblRHSColor.Margin = new Padding(6, 0, 6, 0);
            lblRHSColor.Name = "lblRHSColor";
            lblRHSColor.Size = new Size(105, 25);
            lblRHSColor.TabIndex = 2;
            lblRHSColor.Text = "[lblColorXY]";
            // 
            // lblRHSXY
            // 
            lblRHSXY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRHSXY.AutoSize = true;
            lblRHSXY.Location = new Point(9, 13);
            lblRHSXY.Margin = new Padding(6, 0, 6, 0);
            lblRHSXY.Name = "lblRHSXY";
            lblRHSXY.Size = new Size(96, 25);
            lblRHSXY.TabIndex = 3;
            lblRHSXY.Text = "[lblRHSXY]";
            // 
            // panelRightLimit
            // 
            panelRightLimit.BorderStyle = BorderStyle.FixedSingle;
            panelRightLimit.Controls.Add(GroupBox7);
            panelRightLimit.Controls.Add(cmdRightLimit);
            panelRightLimit.Controls.Add(lblLimitWaitType);
            panelRightLimit.Controls.Add(chkUseLimit);
            panelRightLimit.Controls.Add(cboWaitType);
            panelRightLimit.Location = new Point(6, 467);
            panelRightLimit.Margin = new Padding(6, 5, 6, 5);
            panelRightLimit.Name = "panelRightLimit";
            panelRightLimit.Size = new Size(465, 227);
            panelRightLimit.TabIndex = 31;
            // 
            // GroupBox7
            // 
            GroupBox7.Controls.Add(chkLimitRepeats);
            GroupBox7.Controls.Add(lnkLimitTime);
            GroupBox7.Controls.Add(numIterations);
            GroupBox7.Controls.Add(lblLimitTimeLabel);
            GroupBox7.Controls.Add(lblLimitIterationsLabel);
            GroupBox7.Controls.Add(chkWaitFirst);
            GroupBox7.Location = new Point(190, 55);
            GroupBox7.Margin = new Padding(6, 5, 6, 5);
            GroupBox7.Name = "GroupBox7";
            GroupBox7.Padding = new Padding(6, 5, 6, 5);
            GroupBox7.Size = new Size(226, 162);
            GroupBox7.TabIndex = 30;
            GroupBox7.TabStop = false;
            // 
            // chkLimitRepeats
            // 
            chkLimitRepeats.AutoSize = true;
            chkLimitRepeats.Location = new Point(14, 122);
            chkLimitRepeats.Margin = new Padding(6, 5, 6, 5);
            chkLimitRepeats.Name = "chkLimitRepeats";
            chkLimitRepeats.Size = new Size(100, 29);
            chkLimitRepeats.TabIndex = 31;
            chkLimitRepeats.Text = "Repeats";
            chkLimitRepeats.UseVisualStyleBackColor = true;
            chkLimitRepeats.CheckedChanged += chkLimitRepeats_CheckedChanged;
            // 
            // lnkLimitTime
            // 
            lnkLimitTime.AutoSize = true;
            lnkLimitTime.Location = new Point(99, 83);
            lnkLimitTime.Margin = new Padding(6, 0, 6, 0);
            lnkLimitTime.Name = "lnkLimitTime";
            lnkLimitTime.Size = new Size(94, 25);
            lnkLimitTime.TabIndex = 30;
            lnkLimitTime.TabStop = true;
            lnkLimitTime.Text = "LinkLabel1";
            lnkLimitTime.LinkClicked += lnkLimitTime_LinkClicked;
            // 
            // numIterations
            // 
            numIterations.Location = new Point(94, 33);
            numIterations.Margin = new Padding(6, 5, 6, 5);
            numIterations.Name = "numIterations";
            numIterations.Size = new Size(114, 31);
            numIterations.TabIndex = 29;
            numIterations.ValueChanged += numIterations_ValueChanged;
            // 
            // lblLimitTimeLabel
            // 
            lblLimitTimeLabel.AutoSize = true;
            lblLimitTimeLabel.Location = new Point(9, 80);
            lblLimitTimeLabel.Margin = new Padding(6, 0, 6, 0);
            lblLimitTimeLabel.Name = "lblLimitTimeLabel";
            lblLimitTimeLabel.Size = new Size(54, 25);
            lblLimitTimeLabel.TabIndex = 28;
            lblLimitTimeLabel.Text = "Time:";
            // 
            // lblLimitIterationsLabel
            // 
            lblLimitIterationsLabel.AutoSize = true;
            lblLimitIterationsLabel.Location = new Point(9, 40);
            lblLimitIterationsLabel.Margin = new Padding(6, 0, 6, 0);
            lblLimitIterationsLabel.Name = "lblLimitIterationsLabel";
            lblLimitIterationsLabel.Size = new Size(90, 25);
            lblLimitIterationsLabel.TabIndex = 28;
            lblLimitIterationsLabel.Text = "Iterations:";
            // 
            // chkWaitFirst
            // 
            chkWaitFirst.AutoSize = true;
            chkWaitFirst.Location = new Point(9, 0);
            chkWaitFirst.Margin = new Padding(6, 5, 6, 5);
            chkWaitFirst.Name = "chkWaitFirst";
            chkWaitFirst.Size = new Size(111, 29);
            chkWaitFirst.TabIndex = 4;
            chkWaitFirst.Text = "Wait First";
            chkWaitFirst.UseVisualStyleBackColor = true;
            chkWaitFirst.CheckedChanged += chkWaitFirst_CheckedChanged;
            // 
            // cmdRightLimit
            // 
            cmdRightLimit.BackColor = SystemColors.ButtonShadow;
            cmdRightLimit.Cursor = Cursors.Hand;
            cmdRightLimit.Dock = DockStyle.Top;
            cmdRightLimit.FlatAppearance.BorderSize = 0;
            cmdRightLimit.FlatStyle = FlatStyle.Flat;
            cmdRightLimit.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightLimit.ForeColor = SystemColors.ButtonFace;
            cmdRightLimit.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightLimit.ImageIndex = 22;
            cmdRightLimit.ImageList = ImageList1;
            cmdRightLimit.Location = new Point(0, 0);
            cmdRightLimit.Margin = new Padding(6, 5, 6, 5);
            cmdRightLimit.Name = "cmdRightLimit";
            cmdRightLimit.Size = new Size(463, 42);
            cmdRightLimit.TabIndex = 8;
            cmdRightLimit.Text = "Limit";
            cmdRightLimit.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightLimit.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightLimit.UseVisualStyleBackColor = false;
            cmdRightLimit.Click += cmdRightLimit_Click;
            // 
            // lblLimitWaitType
            // 
            lblLimitWaitType.AutoSize = true;
            lblLimitWaitType.Location = new Point(17, 100);
            lblLimitWaitType.Margin = new Padding(6, 0, 6, 0);
            lblLimitWaitType.Name = "lblLimitWaitType";
            lblLimitWaitType.Size = new Size(92, 25);
            lblLimitWaitType.TabIndex = 29;
            lblLimitWaitType.Text = "Limit Type";
            // 
            // chkUseLimit
            // 
            chkUseLimit.AutoSize = true;
            chkUseLimit.Location = new Point(19, 60);
            chkUseLimit.Margin = new Padding(6, 5, 6, 5);
            chkUseLimit.Name = "chkUseLimit";
            chkUseLimit.Size = new Size(141, 29);
            chkUseLimit.TabIndex = 3;
            chkUseLimit.Text = "Enable Limits";
            chkUseLimit.UseVisualStyleBackColor = true;
            chkUseLimit.CheckedChanged += chkUseLimit_CheckedChanged;
            // 
            // cboWaitType
            // 
            cboWaitType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWaitType.FormattingEnabled = true;
            cboWaitType.Items.AddRange(new object[] { "Iteration", "Time", "Once Per Session" });
            cboWaitType.Location = new Point(19, 130);
            cboWaitType.Margin = new Padding(6, 5, 6, 5);
            cboWaitType.Name = "cboWaitType";
            cboWaitType.Size = new Size(147, 33);
            cboWaitType.TabIndex = 28;
            cboWaitType.SelectedIndexChanged += cboWaitType_SelectedIndexChanged;
            // 
            // panelRightAnchor
            // 
            panelRightAnchor.BorderStyle = BorderStyle.FixedSingle;
            panelRightAnchor.Controls.Add(cmdAnchorDefault);
            panelRightAnchor.Controls.Add(cmdRightAnchor);
            panelRightAnchor.Controls.Add(cmdAnchorLeft);
            panelRightAnchor.Controls.Add(cmdAnchorRight);
            panelRightAnchor.Controls.Add(cmdAnchorBottom);
            panelRightAnchor.Controls.Add(cmdAnchorTop);
            panelRightAnchor.Controls.Add(cmdAnchorNone);
            panelRightAnchor.Location = new Point(6, 704);
            panelRightAnchor.Margin = new Padding(6, 5, 6, 5);
            panelRightAnchor.Name = "panelRightAnchor";
            panelRightAnchor.Size = new Size(465, 247);
            panelRightAnchor.TabIndex = 34;
            // 
            // cmdAnchorDefault
            // 
            cmdAnchorDefault.Cursor = Cursors.Hand;
            cmdAnchorDefault.Location = new Point(9, 52);
            cmdAnchorDefault.Margin = new Padding(6, 5, 6, 5);
            cmdAnchorDefault.Name = "cmdAnchorDefault";
            cmdAnchorDefault.Size = new Size(100, 45);
            cmdAnchorDefault.TabIndex = 13;
            cmdAnchorDefault.Text = "Default";
            cmdAnchorDefault.UseVisualStyleBackColor = true;
            cmdAnchorDefault.Click += cmdAnchorDefault_Click;
            // 
            // cmdRightAnchor
            // 
            cmdRightAnchor.BackColor = SystemColors.ButtonShadow;
            cmdRightAnchor.Cursor = Cursors.Hand;
            cmdRightAnchor.Dock = DockStyle.Top;
            cmdRightAnchor.FlatAppearance.BorderSize = 0;
            cmdRightAnchor.FlatStyle = FlatStyle.Flat;
            cmdRightAnchor.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightAnchor.ForeColor = SystemColors.ButtonFace;
            cmdRightAnchor.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightAnchor.ImageIndex = 22;
            cmdRightAnchor.ImageList = ImageList1;
            cmdRightAnchor.Location = new Point(0, 0);
            cmdRightAnchor.Margin = new Padding(6, 5, 6, 5);
            cmdRightAnchor.Name = "cmdRightAnchor";
            cmdRightAnchor.Size = new Size(463, 42);
            cmdRightAnchor.TabIndex = 9;
            cmdRightAnchor.Text = "Anchor";
            cmdRightAnchor.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightAnchor.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightAnchor.UseVisualStyleBackColor = false;
            cmdRightAnchor.Click += cmdRightAnchor_Click;
            // 
            // cmdAnchorLeft
            // 
            cmdAnchorLeft.Cursor = Cursors.Hand;
            cmdAnchorLeft.Location = new Point(0, 135);
            cmdAnchorLeft.Margin = new Padding(6, 5, 6, 5);
            cmdAnchorLeft.Name = "cmdAnchorLeft";
            cmdAnchorLeft.Size = new Size(159, 20);
            cmdAnchorLeft.TabIndex = 12;
            cmdAnchorLeft.UseVisualStyleBackColor = true;
            cmdAnchorLeft.Click += cmdAnchorLeft_Click;
            // 
            // cmdAnchorRight
            // 
            cmdAnchorRight.Cursor = Cursors.Hand;
            cmdAnchorRight.Location = new Point(274, 135);
            cmdAnchorRight.Margin = new Padding(6, 5, 6, 5);
            cmdAnchorRight.Name = "cmdAnchorRight";
            cmdAnchorRight.Size = new Size(161, 20);
            cmdAnchorRight.TabIndex = 12;
            cmdAnchorRight.UseVisualStyleBackColor = true;
            cmdAnchorRight.Click += cmdAnchorRight_Click;
            // 
            // cmdAnchorBottom
            // 
            cmdAnchorBottom.Cursor = Cursors.Hand;
            cmdAnchorBottom.Location = new Point(210, 170);
            cmdAnchorBottom.Margin = new Padding(6, 5, 6, 5);
            cmdAnchorBottom.Name = "cmdAnchorBottom";
            cmdAnchorBottom.Size = new Size(17, 78);
            cmdAnchorBottom.TabIndex = 11;
            cmdAnchorBottom.UseVisualStyleBackColor = true;
            cmdAnchorBottom.Click += cmdAnchorBottom_Click;
            // 
            // cmdAnchorTop
            // 
            cmdAnchorTop.Cursor = Cursors.Hand;
            cmdAnchorTop.Location = new Point(210, 38);
            cmdAnchorTop.Margin = new Padding(6, 5, 6, 5);
            cmdAnchorTop.Name = "cmdAnchorTop";
            cmdAnchorTop.Size = new Size(17, 78);
            cmdAnchorTop.TabIndex = 11;
            cmdAnchorTop.UseVisualStyleBackColor = true;
            cmdAnchorTop.Click += cmdAnchorTop_Click;
            // 
            // cmdAnchorNone
            // 
            cmdAnchorNone.Cursor = Cursors.Hand;
            cmdAnchorNone.Location = new Point(153, 113);
            cmdAnchorNone.Margin = new Padding(6, 5, 6, 5);
            cmdAnchorNone.Name = "cmdAnchorNone";
            cmdAnchorNone.Size = new Size(126, 62);
            cmdAnchorNone.TabIndex = 10;
            cmdAnchorNone.Text = "None";
            cmdAnchorNone.UseVisualStyleBackColor = true;
            cmdAnchorNone.Click += cmdAnchorNone_Click;
            // 
            // panelRightOffset
            // 
            panelRightOffset.BorderStyle = BorderStyle.FixedSingle;
            panelRightOffset.Controls.Add(lblYOffsetRange);
            panelRightOffset.Controls.Add(lblXOffsetRange);
            panelRightOffset.Controls.Add(NumericYOffset);
            panelRightOffset.Controls.Add(NumericXOffset);
            panelRightOffset.Controls.Add(Label49);
            panelRightOffset.Controls.Add(Label48);
            panelRightOffset.Controls.Add(cmdRightOffset);
            panelRightOffset.Location = new Point(3, 959);
            panelRightOffset.Name = "panelRightOffset";
            panelRightOffset.Size = new Size(465, 160);
            panelRightOffset.TabIndex = 32;
            // 
            // lblYOffsetRange
            // 
            lblYOffsetRange.Location = new Point(254, 115);
            lblYOffsetRange.Margin = new Padding(6, 0, 6, 0);
            lblYOffsetRange.Name = "lblYOffsetRange";
            lblYOffsetRange.Size = new Size(130, 37);
            lblYOffsetRange.TabIndex = 9;
            lblYOffsetRange.Text = "lblYOffsetRange";
            lblYOffsetRange.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblXOffsetRange
            // 
            lblXOffsetRange.Location = new Point(31, 115);
            lblXOffsetRange.Margin = new Padding(6, 0, 6, 0);
            lblXOffsetRange.Name = "lblXOffsetRange";
            lblXOffsetRange.Size = new Size(141, 30);
            lblXOffsetRange.TabIndex = 9;
            lblXOffsetRange.Text = "lblXOffsetRange";
            lblXOffsetRange.TextAlign = ContentAlignment.TopCenter;
            // 
            // NumericYOffset
            // 
            NumericYOffset.Font = new Font("Microsoft Sans Serif", 15F);
            NumericYOffset.Location = new Point(299, 55);
            NumericYOffset.Margin = new Padding(6, 5, 6, 5);
            NumericYOffset.Name = "NumericYOffset";
            NumericYOffset.Size = new Size(109, 41);
            NumericYOffset.TabIndex = 8;
            NumericYOffset.ValueChanged += NumericYOffset_ValueChanged;
            // 
            // NumericXOffset
            // 
            NumericXOffset.Font = new Font("Microsoft Sans Serif", 15F);
            NumericXOffset.Location = new Point(80, 55);
            NumericXOffset.Margin = new Padding(6, 5, 6, 5);
            NumericXOffset.Name = "NumericXOffset";
            NumericXOffset.Size = new Size(106, 41);
            NumericXOffset.TabIndex = 8;
            NumericXOffset.ValueChanged += NumericXOffset_ValueChanged;
            // 
            // Label49
            // 
            Label49.AutoSize = true;
            Label49.Location = new Point(226, 67);
            Label49.Margin = new Padding(6, 0, 6, 0);
            Label49.Name = "Label49";
            Label49.Size = new Size(76, 25);
            Label49.TabIndex = 7;
            Label49.Text = "Y Offset";
            // 
            // Label48
            // 
            Label48.AutoSize = true;
            Label48.Location = new Point(6, 67);
            Label48.Margin = new Padding(6, 0, 6, 0);
            Label48.Name = "Label48";
            Label48.Size = new Size(77, 25);
            Label48.TabIndex = 7;
            Label48.Text = "X Offset";
            // 
            // cmdRightOffset
            // 
            cmdRightOffset.BackColor = SystemColors.ButtonShadow;
            cmdRightOffset.Cursor = Cursors.Hand;
            cmdRightOffset.Dock = DockStyle.Top;
            cmdRightOffset.FlatAppearance.BorderSize = 0;
            cmdRightOffset.FlatStyle = FlatStyle.Flat;
            cmdRightOffset.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightOffset.ForeColor = SystemColors.ButtonFace;
            cmdRightOffset.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightOffset.ImageIndex = 22;
            cmdRightOffset.ImageList = ImageList1;
            cmdRightOffset.Location = new Point(0, 0);
            cmdRightOffset.Margin = new Padding(6, 5, 6, 5);
            cmdRightOffset.Name = "cmdRightOffset";
            cmdRightOffset.Size = new Size(463, 42);
            cmdRightOffset.TabIndex = 9;
            cmdRightOffset.Text = "Offset";
            cmdRightOffset.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightOffset.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightOffset.UseVisualStyleBackColor = false;
            cmdRightOffset.Click += cmdPanelOffset_Click;
            // 
            // panelRightDragMode
            // 
            panelRightDragMode.BorderStyle = BorderStyle.FixedSingle;
            panelRightDragMode.Controls.Add(cmdRightDragMode);
            panelRightDragMode.Location = new Point(3, 1125);
            panelRightDragMode.Name = "panelRightDragMode";
            panelRightDragMode.Size = new Size(436, 314);
            panelRightDragMode.TabIndex = 33;
            panelRightDragMode.Visible = false;
            // 
            // cmdRightDragMode
            // 
            cmdRightDragMode.BackColor = SystemColors.ButtonShadow;
            cmdRightDragMode.Cursor = Cursors.Hand;
            cmdRightDragMode.Dock = DockStyle.Top;
            cmdRightDragMode.FlatAppearance.BorderSize = 0;
            cmdRightDragMode.FlatStyle = FlatStyle.Flat;
            cmdRightDragMode.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightDragMode.ForeColor = SystemColors.ButtonFace;
            cmdRightDragMode.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightDragMode.ImageIndex = 22;
            cmdRightDragMode.ImageList = ImageList1;
            cmdRightDragMode.Location = new Point(0, 0);
            cmdRightDragMode.Margin = new Padding(6, 5, 6, 5);
            cmdRightDragMode.Name = "cmdRightDragMode";
            cmdRightDragMode.Size = new Size(434, 42);
            cmdRightDragMode.TabIndex = 10;
            cmdRightDragMode.Text = "Drag Mode";
            cmdRightDragMode.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightDragMode.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightDragMode.UseVisualStyleBackColor = false;
            cmdRightDragMode.Click += cmdRightDragMode_Click;
            // 
            // PanelGame
            // 
            PanelGame.Controls.Add(flowLayoutPanel1);
            PanelGame.Controls.Add(cboPlatform);
            PanelGame.Controls.Add(lblGamePanelGameName);
            PanelGame.Controls.Add(label62);
            PanelGame.Controls.Add(label18);
            PanelGame.Controls.Add(label22);
            PanelGame.Location = new Point(53, 112);
            PanelGame.Margin = new Padding(6, 5, 6, 5);
            PanelGame.Name = "PanelGame";
            PanelGame.Size = new Size(1431, 1153);
            PanelGame.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(groupBox18);
            flowLayoutPanel1.Controls.Add(grpApplication);
            flowLayoutPanel1.Controls.Add(grpNox);
            flowLayoutPanel1.Controls.Add(grpSteam);
            flowLayoutPanel1.Controls.Add(grpBlue);
            flowLayoutPanel1.Controls.Add(groupBox11);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(14, 138);
            flowLayoutPanel1.Margin = new Padding(6, 5, 6, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1411, 1003);
            flowLayoutPanel1.TabIndex = 45;
            flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox18
            // 
            groupBox18.Controls.Add(groupBox2);
            groupBox18.Controls.Add(groupBox16);
            groupBox18.Controls.Add(grpActiveMouseSettings);
            groupBox18.Controls.Add(label70);
            groupBox18.Controls.Add(cboMouseMode);
            groupBox18.Location = new Point(6, 5);
            groupBox18.Margin = new Padding(6, 5, 6, 5);
            groupBox18.Name = "groupBox18";
            groupBox18.Padding = new Padding(6, 5, 6, 5);
            groupBox18.Size = new Size(1354, 435);
            groupBox18.TabIndex = 50;
            groupBox18.TabStop = false;
            groupBox18.Text = "Mouse";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label42);
            groupBox2.Controls.Add(numericApplicationDefaultClickSpeed);
            groupBox2.Location = new Point(21, 87);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(614, 110);
            groupBox2.TabIndex = 34;
            groupBox2.TabStop = false;
            groupBox2.Text = "Default Click Speed (ms)";
            // 
            // label42
            // 
            label42.Location = new Point(199, 27);
            label42.Name = "label42";
            label42.Size = new Size(349, 75);
            label42.TabIndex = 34;
            label42.Text = "How long to hold the mouse down during a click event.  Some applications do not respond to 0ms.";
            // 
            // numericApplicationDefaultClickSpeed
            // 
            numericApplicationDefaultClickSpeed.Font = new Font("Microsoft Sans Serif", 15F);
            numericApplicationDefaultClickSpeed.Location = new Point(20, 35);
            numericApplicationDefaultClickSpeed.Margin = new Padding(6, 5, 6, 5);
            numericApplicationDefaultClickSpeed.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericApplicationDefaultClickSpeed.Name = "numericApplicationDefaultClickSpeed";
            numericApplicationDefaultClickSpeed.Size = new Size(157, 41);
            numericApplicationDefaultClickSpeed.TabIndex = 33;
            numericApplicationDefaultClickSpeed.ValueChanged += numericApplicationDefaultClickSpeed_ValueChanged;
            // 
            // groupBox16
            // 
            groupBox16.Controls.Add(label92);
            groupBox16.Controls.Add(numericMouseSpeedPixelsPerSecond);
            groupBox16.Controls.Add(groupBox17);
            groupBox16.Controls.Add(label87);
            groupBox16.Location = new Point(651, 192);
            groupBox16.Margin = new Padding(6, 5, 6, 5);
            groupBox16.Name = "groupBox16";
            groupBox16.Padding = new Padding(6, 5, 6, 5);
            groupBox16.Size = new Size(691, 235);
            groupBox16.TabIndex = 45;
            groupBox16.TabStop = false;
            groupBox16.Text = "Mouse Movement Speed";
            // 
            // label92
            // 
            label92.AutoSize = true;
            label92.Location = new Point(357, 53);
            label92.Margin = new Padding(6, 0, 6, 0);
            label92.Name = "label92";
            label92.Size = new Size(109, 25);
            label92.TabIndex = 3;
            label92.Text = "(1 to 50000)";
            // 
            // numericMouseSpeedPixelsPerSecond
            // 
            numericMouseSpeedPixelsPerSecond.Location = new Point(181, 42);
            numericMouseSpeedPixelsPerSecond.Margin = new Padding(6, 5, 6, 5);
            numericMouseSpeedPixelsPerSecond.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numericMouseSpeedPixelsPerSecond.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericMouseSpeedPixelsPerSecond.Name = "numericMouseSpeedPixelsPerSecond";
            numericMouseSpeedPixelsPerSecond.Size = new Size(163, 31);
            numericMouseSpeedPixelsPerSecond.TabIndex = 2;
            numericMouseSpeedPixelsPerSecond.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericMouseSpeedPixelsPerSecond.ValueChanged += numericMouseSpeedPixelsPerSecond_ValueChanged;
            // 
            // groupBox17
            // 
            groupBox17.Controls.Add(label91);
            groupBox17.Controls.Add(label90);
            groupBox17.Controls.Add(numericMouseSpeedVelocityVariantPercentMin);
            groupBox17.Controls.Add(numericMouseSpeedVelocityVariantPercentMax);
            groupBox17.Controls.Add(label88);
            groupBox17.Controls.Add(label89);
            groupBox17.Location = new Point(21, 95);
            groupBox17.Margin = new Padding(6, 5, 6, 5);
            groupBox17.Name = "groupBox17";
            groupBox17.Padding = new Padding(6, 5, 6, 5);
            groupBox17.Size = new Size(401, 128);
            groupBox17.TabIndex = 1;
            groupBox17.TabStop = false;
            groupBox17.Text = "Random Speed Modification Per Action";
            // 
            // label91
            // 
            label91.AutoSize = true;
            label91.Location = new Point(209, 87);
            label91.Margin = new Padding(6, 0, 6, 0);
            label91.Name = "label91";
            label91.Size = new Size(96, 25);
            label91.TabIndex = 2;
            label91.Text = "(-500 to 0)";
            // 
            // label90
            // 
            label90.AutoSize = true;
            label90.Location = new Point(209, 42);
            label90.Margin = new Padding(6, 0, 6, 0);
            label90.Name = "label90";
            label90.Size = new Size(89, 25);
            label90.TabIndex = 2;
            label90.Text = "(0 to 500)";
            // 
            // numericMouseSpeedVelocityVariantPercentMin
            // 
            numericMouseSpeedVelocityVariantPercentMin.Location = new Point(80, 87);
            numericMouseSpeedVelocityVariantPercentMin.Margin = new Padding(6, 5, 6, 5);
            numericMouseSpeedVelocityVariantPercentMin.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numericMouseSpeedVelocityVariantPercentMin.Minimum = new decimal(new int[] { 500, 0, 0, int.MinValue });
            numericMouseSpeedVelocityVariantPercentMin.Name = "numericMouseSpeedVelocityVariantPercentMin";
            numericMouseSpeedVelocityVariantPercentMin.Size = new Size(114, 31);
            numericMouseSpeedVelocityVariantPercentMin.TabIndex = 1;
            numericMouseSpeedVelocityVariantPercentMin.ValueChanged += numericMouseSpeedVelocityVariantPercentMin_ValueChanged;
            // 
            // numericMouseSpeedVelocityVariantPercentMax
            // 
            numericMouseSpeedVelocityVariantPercentMax.Location = new Point(79, 38);
            numericMouseSpeedVelocityVariantPercentMax.Margin = new Padding(6, 5, 6, 5);
            numericMouseSpeedVelocityVariantPercentMax.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericMouseSpeedVelocityVariantPercentMax.Name = "numericMouseSpeedVelocityVariantPercentMax";
            numericMouseSpeedVelocityVariantPercentMax.Size = new Size(117, 31);
            numericMouseSpeedVelocityVariantPercentMax.TabIndex = 1;
            numericMouseSpeedVelocityVariantPercentMax.ValueChanged += numericMouseSpeedVelocityVariantPercentMax_ValueChanged;
            // 
            // label88
            // 
            label88.AutoSize = true;
            label88.Location = new Point(10, 42);
            label88.Margin = new Padding(6, 0, 6, 0);
            label88.Name = "label88";
            label88.Size = new Size(65, 25);
            label88.TabIndex = 0;
            label88.Text = "Max %";
            // 
            // label89
            // 
            label89.AutoSize = true;
            label89.Location = new Point(10, 95);
            label89.Margin = new Padding(6, 0, 6, 0);
            label89.Name = "label89";
            label89.Size = new Size(62, 25);
            label89.TabIndex = 0;
            label89.Text = "Min %";
            // 
            // label87
            // 
            label87.AutoSize = true;
            label87.Location = new Point(17, 52);
            label87.Margin = new Padding(6, 0, 6, 0);
            label87.Name = "label87";
            label87.Size = new Size(148, 25);
            label87.TabIndex = 0;
            label87.Text = "Pixels Per Second";
            // 
            // grpActiveMouseSettings
            // 
            grpActiveMouseSettings.Controls.Add(cboWindowAction);
            grpActiveMouseSettings.Controls.Add(chkMoveMouseBeforeAction);
            grpActiveMouseSettings.Controls.Add(lblWindowNotVisibleAction);
            grpActiveMouseSettings.Location = new Point(651, 35);
            grpActiveMouseSettings.Margin = new Padding(6, 5, 6, 5);
            grpActiveMouseSettings.Name = "grpActiveMouseSettings";
            grpActiveMouseSettings.Padding = new Padding(6, 5, 6, 5);
            grpActiveMouseSettings.Size = new Size(693, 147);
            grpActiveMouseSettings.TabIndex = 50;
            grpActiveMouseSettings.TabStop = false;
            grpActiveMouseSettings.Text = "Mouse Mode Mouse Settings";
            // 
            // cboWindowAction
            // 
            cboWindowAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWindowAction.FormattingEnabled = true;
            cboWindowAction.Location = new Point(239, 37);
            cboWindowAction.Margin = new Padding(6, 5, 6, 5);
            cboWindowAction.Name = "cboWindowAction";
            cboWindowAction.Size = new Size(383, 33);
            cboWindowAction.TabIndex = 47;
            cboWindowAction.SelectedIndexChanged += cboWindowAction_SelectedIndexChanged;
            // 
            // chkMoveMouseBeforeAction
            // 
            chkMoveMouseBeforeAction.AutoSize = true;
            chkMoveMouseBeforeAction.Location = new Point(21, 97);
            chkMoveMouseBeforeAction.Margin = new Padding(6, 5, 6, 5);
            chkMoveMouseBeforeAction.Name = "chkMoveMouseBeforeAction";
            chkMoveMouseBeforeAction.Size = new Size(631, 29);
            chkMoveMouseBeforeAction.TabIndex = 49;
            chkMoveMouseBeforeAction.Text = "Default - Move System Mouse To Start Location Before Action (Active Only)";
            chkMoveMouseBeforeAction.UseVisualStyleBackColor = true;
            chkMoveMouseBeforeAction.CheckedChanged += chkMoveMouseBeforeAction_CheckedChanged;
            // 
            // lblWindowNotVisibleAction
            // 
            lblWindowNotVisibleAction.AutoSize = true;
            lblWindowNotVisibleAction.Location = new Point(13, 42);
            lblWindowNotVisibleAction.Margin = new Padding(6, 0, 6, 0);
            lblWindowNotVisibleAction.Name = "lblWindowNotVisibleAction";
            lblWindowNotVisibleAction.Size = new Size(225, 25);
            lblWindowNotVisibleAction.TabIndex = 48;
            lblWindowNotVisibleAction.Text = "Window Not Visible Action";
            // 
            // label70
            // 
            label70.AutoSize = true;
            label70.Location = new Point(23, 40);
            label70.Name = "label70";
            label70.Size = new Size(118, 25);
            label70.TabIndex = 46;
            label70.Text = "Mouse Mode";
            // 
            // cboMouseMode
            // 
            cboMouseMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMouseMode.FormattingEnabled = true;
            cboMouseMode.Location = new Point(249, 35);
            cboMouseMode.Name = "cboMouseMode";
            cboMouseMode.Size = new Size(383, 33);
            cboMouseMode.TabIndex = 37;
            cboMouseMode.SelectedIndexChanged += cboClickMode_SelectedIndexChanged;
            cboMouseMode.TextChanged += cboPlatform_TextChanged;
            // 
            // grpApplication
            // 
            grpApplication.Controls.Add(groupBox13);
            grpApplication.Controls.Add(groupBox10);
            grpApplication.Location = new Point(3, 448);
            grpApplication.Name = "grpApplication";
            grpApplication.Size = new Size(1167, 565);
            grpApplication.TabIndex = 40;
            grpApplication.TabStop = false;
            grpApplication.Text = "Application";
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(label71);
            groupBox13.Controls.Add(label69);
            groupBox13.Controls.Add(txtPathToApplicationExe);
            groupBox13.Controls.Add(txtApplicationParameters);
            groupBox13.Controls.Add(cmdPathToExePicker);
            groupBox13.Controls.Add(label72);
            groupBox13.Location = new Point(9, 277);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new Size(1150, 270);
            groupBox13.TabIndex = 11;
            groupBox13.TabStop = false;
            groupBox13.Text = "Start Configuration - Not Required";
            // 
            // label71
            // 
            label71.Location = new Point(654, 170);
            label71.Name = "label71";
            label71.Size = new Size(447, 85);
            label71.TabIndex = 8;
            label71.Text = "Used to automatically launch application when scheduler is used, or Toolbar \"Start\" buttons.";
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Location = new Point(11, 30);
            label69.Name = "label69";
            label69.Size = new Size(102, 25);
            label69.TabIndex = 0;
            label69.Text = "Path to EXE";
            // 
            // txtPathToApplicationExe
            // 
            txtPathToApplicationExe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPathToApplicationExe.Location = new Point(20, 62);
            txtPathToApplicationExe.Name = "txtPathToApplicationExe";
            txtPathToApplicationExe.Size = new Size(1057, 31);
            txtPathToApplicationExe.TabIndex = 4;
            txtPathToApplicationExe.TextChanged += txtPathToApplicationExe_TextChanged;
            // 
            // txtApplicationParameters
            // 
            txtApplicationParameters.Location = new Point(20, 152);
            txtApplicationParameters.Name = "txtApplicationParameters";
            txtApplicationParameters.Size = new Size(453, 31);
            txtApplicationParameters.TabIndex = 7;
            txtApplicationParameters.TextChanged += txtApplicationParameters_TextChanged;
            // 
            // cmdPathToExePicker
            // 
            cmdPathToExePicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdPathToExePicker.Font = new Font("Microsoft Sans Serif", 14F);
            cmdPathToExePicker.Location = new Point(1081, 55);
            cmdPathToExePicker.Name = "cmdPathToExePicker";
            cmdPathToExePicker.Size = new Size(59, 50);
            cmdPathToExePicker.TabIndex = 5;
            cmdPathToExePicker.Text = "...";
            cmdPathToExePicker.TextAlign = ContentAlignment.TopCenter;
            cmdPathToExePicker.UseVisualStyleBackColor = false;
            cmdPathToExePicker.Click += cmdPathToExePicker_Click;
            // 
            // label72
            // 
            label72.AutoSize = true;
            label72.Location = new Point(11, 112);
            label72.Name = "label72";
            label72.Size = new Size(99, 25);
            label72.TabIndex = 6;
            label72.Text = "Parameters";
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(cmdApplicationWindowWizard);
            groupBox10.Controls.Add(cboApplicationSecondaryWindowNameFilter);
            groupBox10.Controls.Add(txtApplicationSecondaryWindowName);
            groupBox10.Controls.Add(label76);
            groupBox10.Controls.Add(label77);
            groupBox10.Controls.Add(cboApplicationPrimaryWindowNameFilter);
            groupBox10.Controls.Add(txtApplicationPrimaryWindowName);
            groupBox10.Controls.Add(label78);
            groupBox10.Controls.Add(label79);
            groupBox10.Location = new Point(9, 35);
            groupBox10.Margin = new Padding(6, 5, 6, 5);
            groupBox10.Name = "groupBox10";
            groupBox10.Padding = new Padding(6, 5, 6, 5);
            groupBox10.Size = new Size(793, 228);
            groupBox10.TabIndex = 10;
            groupBox10.TabStop = false;
            groupBox10.Text = "Window";
            // 
            // cmdApplicationWindowWizard
            // 
            cmdApplicationWindowWizard.Location = new Point(653, 20);
            cmdApplicationWindowWizard.Margin = new Padding(6, 5, 6, 5);
            cmdApplicationWindowWizard.Name = "cmdApplicationWindowWizard";
            cmdApplicationWindowWizard.Size = new Size(126, 45);
            cmdApplicationWindowWizard.TabIndex = 12;
            cmdApplicationWindowWizard.Text = "Wizard";
            cmdApplicationWindowWizard.UseVisualStyleBackColor = true;
            cmdApplicationWindowWizard.Click += cmdApplicationWindowWizard_Click;
            // 
            // cboApplicationSecondaryWindowNameFilter
            // 
            cboApplicationSecondaryWindowNameFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboApplicationSecondaryWindowNameFilter.FormattingEnabled = true;
            cboApplicationSecondaryWindowNameFilter.Items.AddRange(new object[] { "Equals", "Starts With", "Contains" });
            cboApplicationSecondaryWindowNameFilter.Location = new Point(231, 128);
            cboApplicationSecondaryWindowNameFilter.Margin = new Padding(6, 5, 6, 5);
            cboApplicationSecondaryWindowNameFilter.Name = "cboApplicationSecondaryWindowNameFilter";
            cboApplicationSecondaryWindowNameFilter.Size = new Size(123, 33);
            cboApplicationSecondaryWindowNameFilter.TabIndex = 11;
            cboApplicationSecondaryWindowNameFilter.SelectedIndexChanged += cboApplicationSecondaryWindowNameFilter_SelectedIndexChanged;
            // 
            // txtApplicationSecondaryWindowName
            // 
            txtApplicationSecondaryWindowName.Location = new Point(231, 178);
            txtApplicationSecondaryWindowName.Name = "txtApplicationSecondaryWindowName";
            txtApplicationSecondaryWindowName.Size = new Size(545, 31);
            txtApplicationSecondaryWindowName.TabIndex = 10;
            txtApplicationSecondaryWindowName.TextChanged += txtApplicationSecondaryWindowName_TextChanged;
            // 
            // label76
            // 
            label76.AutoSize = true;
            label76.Location = new Point(9, 188);
            label76.Name = "label76";
            label76.Size = new Size(218, 25);
            label76.TabIndex = 8;
            label76.Text = "Secondary Window Name";
            // 
            // label77
            // 
            label77.AutoSize = true;
            label77.Location = new Point(9, 138);
            label77.Name = "label77";
            label77.Size = new Size(209, 25);
            label77.TabIndex = 9;
            label77.Text = "Secondary Window Filter";
            // 
            // cboApplicationPrimaryWindowNameFilter
            // 
            cboApplicationPrimaryWindowNameFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboApplicationPrimaryWindowNameFilter.FormattingEnabled = true;
            cboApplicationPrimaryWindowNameFilter.Items.AddRange(new object[] { "Equals", "Starts With", "Contains" });
            cboApplicationPrimaryWindowNameFilter.Location = new Point(231, 28);
            cboApplicationPrimaryWindowNameFilter.Margin = new Padding(6, 5, 6, 5);
            cboApplicationPrimaryWindowNameFilter.Name = "cboApplicationPrimaryWindowNameFilter";
            cboApplicationPrimaryWindowNameFilter.Size = new Size(123, 33);
            cboApplicationPrimaryWindowNameFilter.TabIndex = 7;
            cboApplicationPrimaryWindowNameFilter.SelectedIndexChanged += cboApplicationPrimaryWindowNameFilter_SelectedIndexChanged;
            // 
            // txtApplicationPrimaryWindowName
            // 
            txtApplicationPrimaryWindowName.Location = new Point(231, 80);
            txtApplicationPrimaryWindowName.Name = "txtApplicationPrimaryWindowName";
            txtApplicationPrimaryWindowName.Size = new Size(545, 31);
            txtApplicationPrimaryWindowName.TabIndex = 7;
            txtApplicationPrimaryWindowName.TextChanged += txtApplicationWindowName_TextChanged;
            // 
            // label78
            // 
            label78.AutoSize = true;
            label78.Location = new Point(9, 88);
            label78.Name = "label78";
            label78.Size = new Size(195, 25);
            label78.TabIndex = 0;
            label78.Text = "Primary Window Name";
            // 
            // label79
            // 
            label79.AutoSize = true;
            label79.Location = new Point(9, 38);
            label79.Name = "label79";
            label79.Size = new Size(186, 25);
            label79.TabIndex = 0;
            label79.Text = "Primary Window Filter";
            // 
            // grpNox
            // 
            grpNox.Controls.Add(label61);
            grpNox.Controls.Add(cboDPI);
            grpNox.Controls.Add(Label26);
            grpNox.Controls.Add(cboGameInstances);
            grpNox.Controls.Add(cboResolution);
            grpNox.Controls.Add(txtGamePanelLaunchInstance);
            grpNox.Controls.Add(label12);
            grpNox.Controls.Add(Label16);
            grpNox.Controls.Add(txtPackageName);
            grpNox.Controls.Add(label63);
            grpNox.Controls.Add(Label25);
            grpNox.Location = new Point(3, 1019);
            grpNox.Name = "grpNox";
            grpNox.Size = new Size(1167, 258);
            grpNox.TabIndex = 38;
            grpNox.TabStop = false;
            grpNox.Text = "Nox Player";
            // 
            // label61
            // 
            label61.Location = new Point(429, 200);
            label61.Name = "label61";
            label61.Size = new Size(559, 62);
            label61.TabIndex = 36;
            label61.Text = "DPI: some apps are DPI aware and adjust.  Those apps need consistent dpi for transportability.  Most apps do not use this setting.";
            // 
            // cboDPI
            // 
            cboDPI.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDPI.FormattingEnabled = true;
            cboDPI.Items.AddRange(new object[] { "96", "120", "144", "192", "240", "288", "384", "480" });
            cboDPI.Location = new Point(249, 200);
            cboDPI.Margin = new Padding(6, 5, 6, 5);
            cboDPI.Name = "cboDPI";
            cboDPI.Size = new Size(161, 33);
            cboDPI.TabIndex = 35;
            cboDPI.SelectedIndexChanged += cboDPI_SelectedIndexChanged;
            // 
            // Label26
            // 
            Label26.AutoSize = true;
            Label26.Location = new Point(367, 98);
            Label26.Margin = new Padding(6, 0, 6, 0);
            Label26.Name = "Label26";
            Label26.Size = new Size(156, 25);
            Label26.TabIndex = 47;
            Label26.Text = "Installed Instances";
            // 
            // cboGameInstances
            // 
            cboGameInstances.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGameInstances.FormattingEnabled = true;
            cboGameInstances.Location = new Point(527, 88);
            cboGameInstances.Margin = new Padding(6, 5, 6, 5);
            cboGameInstances.Name = "cboGameInstances";
            cboGameInstances.Size = new Size(161, 33);
            cboGameInstances.TabIndex = 46;
            cboGameInstances.SelectedIndexChanged += cboGameInstances_SelectedIndexChanged;
            // 
            // cboResolution
            // 
            cboResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            cboResolution.FormattingEnabled = true;
            cboResolution.Items.AddRange(new object[] { "640x360", "667x375", "1024x768", "1280x800" });
            cboResolution.Location = new Point(249, 142);
            cboResolution.Margin = new Padding(6, 5, 6, 5);
            cboResolution.Name = "cboResolution";
            cboResolution.Size = new Size(437, 33);
            cboResolution.TabIndex = 45;
            cboResolution.SelectedIndexChanged += cboResolution_SelectedIndexChanged;
            // 
            // txtGamePanelLaunchInstance
            // 
            txtGamePanelLaunchInstance.BackColor = SystemColors.Window;
            txtGamePanelLaunchInstance.Location = new Point(249, 92);
            txtGamePanelLaunchInstance.Margin = new Padding(6, 5, 6, 5);
            txtGamePanelLaunchInstance.Name = "txtGamePanelLaunchInstance";
            txtGamePanelLaunchInstance.Size = new Size(104, 31);
            txtGamePanelLaunchInstance.TabIndex = 41;
            txtGamePanelLaunchInstance.TextChanged += txtGamePanelLaunchInstance_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(14, 92);
            label12.Margin = new Padding(6, 0, 6, 0);
            label12.Name = "label12";
            label12.Size = new Size(155, 25);
            label12.TabIndex = 39;
            label12.Text = "Instance to launch";
            // 
            // Label16
            // 
            Label16.AutoSize = true;
            Label16.Location = new Point(14, 40);
            Label16.Margin = new Padding(6, 0, 6, 0);
            Label16.Name = "Label16";
            Label16.Size = new Size(128, 25);
            Label16.TabIndex = 40;
            Label16.Text = "Package Name";
            // 
            // txtPackageName
            // 
            txtPackageName.BackColor = SystemColors.Window;
            txtPackageName.Location = new Point(249, 40);
            txtPackageName.Margin = new Padding(6, 5, 6, 5);
            txtPackageName.Name = "txtPackageName";
            txtPackageName.Size = new Size(791, 31);
            txtPackageName.TabIndex = 38;
            txtPackageName.TextChanged += txtPackageName_TextChanged;
            // 
            // label63
            // 
            label63.AutoSize = true;
            label63.Location = new Point(19, 200);
            label63.Margin = new Padding(6, 0, 6, 0);
            label63.Name = "label63";
            label63.Size = new Size(160, 25);
            label63.TabIndex = 37;
            label63.Text = "DPI (Dots Per Inch)";
            // 
            // Label25
            // 
            Label25.AutoSize = true;
            Label25.Location = new Point(14, 148);
            Label25.Margin = new Padding(6, 0, 6, 0);
            Label25.Name = "Label25";
            Label25.Size = new Size(142, 25);
            Label25.TabIndex = 37;
            Label25.Text = "Initial Resolution";
            // 
            // grpSteam
            // 
            grpSteam.Controls.Add(groupBox14);
            grpSteam.Controls.Add(groupBox9);
            grpSteam.Location = new Point(3, 1283);
            grpSteam.Name = "grpSteam";
            grpSteam.Size = new Size(1167, 495);
            grpSteam.TabIndex = 39;
            grpSteam.TabStop = false;
            grpSteam.Text = "Steam - Experimental/In Development/Incomplete";
            // 
            // groupBox14
            // 
            groupBox14.Controls.Add(label84);
            groupBox14.Controls.Add(label64);
            groupBox14.Controls.Add(label66);
            groupBox14.Controls.Add(txtSteamID);
            groupBox14.Location = new Point(9, 277);
            groupBox14.Margin = new Padding(6, 5, 6, 5);
            groupBox14.Name = "groupBox14";
            groupBox14.Padding = new Padding(6, 5, 6, 5);
            groupBox14.Size = new Size(1140, 195);
            groupBox14.TabIndex = 9;
            groupBox14.TabStop = false;
            groupBox14.Text = "Start Configuration - Not Required";
            // 
            // label84
            // 
            label84.Location = new Point(14, 92);
            label84.Name = "label84";
            label84.Size = new Size(447, 85);
            label84.TabIndex = 9;
            label84.Text = "Used to automatically launch application when scheduler is used, or Toolbar \"Start\" buttons.";
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Location = new Point(11, 38);
            label64.Name = "label64";
            label64.Size = new Size(179, 25);
            label64.TabIndex = 0;
            label64.Text = "Steam Application ID";
            // 
            // label66
            // 
            label66.Location = new Point(587, 35);
            label66.Name = "label66";
            label66.Size = new Size(546, 122);
            label66.TabIndex = 3;
            label66.Text = "Enter the Steam Game Number Ex.  285920  Right Click a steam app Icon, then go to properties.  Steam ID's Look like this: steam://rungameid/285920";
            // 
            // txtSteamID
            // 
            txtSteamID.Location = new Point(211, 37);
            txtSteamID.Name = "txtSteamID";
            txtSteamID.Size = new Size(368, 31);
            txtSteamID.TabIndex = 4;
            txtSteamID.TextChanged += txtSteamID_TextChanged;
            txtSteamID.KeyPress += txtSteamID_KeyPress;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(cmdSteamWindowWizard);
            groupBox9.Controls.Add(cboSteamSecondaryWindowNameFilter);
            groupBox9.Controls.Add(txtSteamSecondaryWindowName);
            groupBox9.Controls.Add(label74);
            groupBox9.Controls.Add(label75);
            groupBox9.Controls.Add(cboSteamPrimaryWindowNameFilter);
            groupBox9.Controls.Add(txtSteamPrimaryWindowName);
            groupBox9.Controls.Add(label73);
            groupBox9.Controls.Add(label67);
            groupBox9.Location = new Point(9, 35);
            groupBox9.Margin = new Padding(6, 5, 6, 5);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(6, 5, 6, 5);
            groupBox9.Size = new Size(834, 228);
            groupBox9.TabIndex = 8;
            groupBox9.TabStop = false;
            groupBox9.Text = "Window";
            // 
            // cmdSteamWindowWizard
            // 
            cmdSteamWindowWizard.Location = new Point(630, 28);
            cmdSteamWindowWizard.Margin = new Padding(6, 5, 6, 5);
            cmdSteamWindowWizard.Name = "cmdSteamWindowWizard";
            cmdSteamWindowWizard.Size = new Size(187, 45);
            cmdSteamWindowWizard.TabIndex = 9;
            cmdSteamWindowWizard.Text = "Window Wizard";
            cmdSteamWindowWizard.UseVisualStyleBackColor = true;
            cmdSteamWindowWizard.Click += cmdSteamWindowWizard_Click;
            // 
            // cboSteamSecondaryWindowNameFilter
            // 
            cboSteamSecondaryWindowNameFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSteamSecondaryWindowNameFilter.FormattingEnabled = true;
            cboSteamSecondaryWindowNameFilter.Items.AddRange(new object[] { "Equals", "Starts With", "Contains" });
            cboSteamSecondaryWindowNameFilter.Location = new Point(231, 128);
            cboSteamSecondaryWindowNameFilter.Margin = new Padding(6, 5, 6, 5);
            cboSteamSecondaryWindowNameFilter.Name = "cboSteamSecondaryWindowNameFilter";
            cboSteamSecondaryWindowNameFilter.Size = new Size(123, 33);
            cboSteamSecondaryWindowNameFilter.TabIndex = 11;
            cboSteamSecondaryWindowNameFilter.SelectedIndexChanged += cboSteamSecondaryWindowNameFilter_SelectedIndexChanged;
            // 
            // txtSteamSecondaryWindowName
            // 
            txtSteamSecondaryWindowName.Location = new Point(231, 178);
            txtSteamSecondaryWindowName.Name = "txtSteamSecondaryWindowName";
            txtSteamSecondaryWindowName.Size = new Size(583, 31);
            txtSteamSecondaryWindowName.TabIndex = 10;
            txtSteamSecondaryWindowName.TextChanged += txtSteamSecondaryWindowName_TextChanged;
            // 
            // label74
            // 
            label74.AutoSize = true;
            label74.Location = new Point(9, 188);
            label74.Name = "label74";
            label74.Size = new Size(218, 25);
            label74.TabIndex = 8;
            label74.Text = "Secondary Window Name";
            // 
            // label75
            // 
            label75.AutoSize = true;
            label75.Location = new Point(9, 138);
            label75.Name = "label75";
            label75.Size = new Size(209, 25);
            label75.TabIndex = 9;
            label75.Text = "Secondary Window Filter";
            // 
            // cboSteamPrimaryWindowNameFilter
            // 
            cboSteamPrimaryWindowNameFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSteamPrimaryWindowNameFilter.FormattingEnabled = true;
            cboSteamPrimaryWindowNameFilter.Items.AddRange(new object[] { "Equals", "Starts With", "Contains" });
            cboSteamPrimaryWindowNameFilter.Location = new Point(231, 28);
            cboSteamPrimaryWindowNameFilter.Margin = new Padding(6, 5, 6, 5);
            cboSteamPrimaryWindowNameFilter.Name = "cboSteamPrimaryWindowNameFilter";
            cboSteamPrimaryWindowNameFilter.Size = new Size(123, 33);
            cboSteamPrimaryWindowNameFilter.TabIndex = 7;
            cboSteamPrimaryWindowNameFilter.SelectedIndexChanged += cboSteamPrimaryWindowNameFilter_SelectedIndexChanged;
            // 
            // txtSteamPrimaryWindowName
            // 
            txtSteamPrimaryWindowName.Location = new Point(231, 78);
            txtSteamPrimaryWindowName.Name = "txtSteamPrimaryWindowName";
            txtSteamPrimaryWindowName.Size = new Size(583, 31);
            txtSteamPrimaryWindowName.TabIndex = 5;
            txtSteamPrimaryWindowName.TextChanged += txtSteamWindowName_TextChanged;
            // 
            // label73
            // 
            label73.AutoSize = true;
            label73.Location = new Point(9, 88);
            label73.Name = "label73";
            label73.Size = new Size(195, 25);
            label73.TabIndex = 0;
            label73.Text = "Primary Window Name";
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Location = new Point(9, 38);
            label67.Name = "label67";
            label67.Size = new Size(186, 25);
            label67.TabIndex = 0;
            label67.Text = "Primary Window Filter";
            // 
            // grpBlue
            // 
            grpBlue.Controls.Add(cboBlueInstance);
            grpBlue.Controls.Add(label83);
            grpBlue.Controls.Add(label82);
            grpBlue.Controls.Add(txtBluePackageName);
            grpBlue.Location = new Point(3, 1784);
            grpBlue.Name = "grpBlue";
            grpBlue.Size = new Size(1169, 125);
            grpBlue.TabIndex = 48;
            grpBlue.TabStop = false;
            grpBlue.Text = "BlueStacks";
            // 
            // cboBlueInstance
            // 
            cboBlueInstance.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBlueInstance.FormattingEnabled = true;
            cboBlueInstance.Location = new Point(306, 87);
            cboBlueInstance.Name = "cboBlueInstance";
            cboBlueInstance.Size = new Size(485, 33);
            cboBlueInstance.TabIndex = 43;
            cboBlueInstance.SelectedIndexChanged += cboBlueInstance_SelectedIndexChanged;
            // 
            // label83
            // 
            label83.AutoSize = true;
            label83.Location = new Point(77, 85);
            label83.Margin = new Padding(6, 0, 6, 0);
            label83.Name = "label83";
            label83.Size = new Size(77, 25);
            label83.TabIndex = 42;
            label83.Text = "Instance";
            // 
            // label82
            // 
            label82.AutoSize = true;
            label82.Location = new Point(71, 47);
            label82.Margin = new Padding(6, 0, 6, 0);
            label82.Name = "label82";
            label82.Size = new Size(128, 25);
            label82.TabIndex = 42;
            label82.Text = "Package Name";
            // 
            // txtBluePackageName
            // 
            txtBluePackageName.BackColor = SystemColors.Window;
            txtBluePackageName.Location = new Point(306, 47);
            txtBluePackageName.Margin = new Padding(6, 5, 6, 5);
            txtBluePackageName.Name = "txtBluePackageName";
            txtBluePackageName.Size = new Size(791, 31);
            txtBluePackageName.TabIndex = 41;
            txtBluePackageName.TextChanged += txtBluePackageName_TextChanged;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(chkDontTakeScreenshot);
            groupBox11.Controls.Add(chkGameWindowNeverQuitIfWindowNotFound);
            groupBox11.Controls.Add(grpVideo);
            groupBox11.Controls.Add(Label33);
            groupBox11.Controls.Add(cmdStartEmmulatorAndPackage);
            groupBox11.Controls.Add(cmdStartEmmulatorPackageAndRunScript);
            groupBox11.Controls.Add(cmdStartEmmulator);
            groupBox11.Controls.Add(txtGamePanelLoopDelay);
            groupBox11.Controls.Add(Label30);
            groupBox11.Controls.Add(cmdRunScript);
            groupBox11.Location = new Point(6, 1917);
            groupBox11.Margin = new Padding(6, 5, 6, 5);
            groupBox11.Name = "groupBox11";
            groupBox11.Padding = new Padding(6, 5, 6, 5);
            groupBox11.Size = new Size(1167, 542);
            groupBox11.TabIndex = 47;
            groupBox11.TabStop = false;
            groupBox11.Text = "General";
            // 
            // chkDontTakeScreenshot
            // 
            chkDontTakeScreenshot.AutoSize = true;
            chkDontTakeScreenshot.Location = new Point(29, 85);
            chkDontTakeScreenshot.Margin = new Padding(6, 5, 6, 5);
            chkDontTakeScreenshot.Name = "chkDontTakeScreenshot";
            chkDontTakeScreenshot.Size = new Size(460, 29);
            chkDontTakeScreenshot.TabIndex = 46;
            chkDontTakeScreenshot.Text = "Don't Take Screenshot at Runtime (Use Empty Events)";
            chkDontTakeScreenshot.UseVisualStyleBackColor = true;
            chkDontTakeScreenshot.CheckedChanged += chkDontTakeScreenshot_CheckedChanged;
            // 
            // chkGameWindowNeverQuitIfWindowNotFound
            // 
            chkGameWindowNeverQuitIfWindowNotFound.AutoSize = true;
            chkGameWindowNeverQuitIfWindowNotFound.Location = new Point(27, 135);
            chkGameWindowNeverQuitIfWindowNotFound.Margin = new Padding(6, 5, 6, 5);
            chkGameWindowNeverQuitIfWindowNotFound.Name = "chkGameWindowNeverQuitIfWindowNotFound";
            chkGameWindowNeverQuitIfWindowNotFound.Size = new Size(300, 29);
            chkGameWindowNeverQuitIfWindowNotFound.TabIndex = 45;
            chkGameWindowNeverQuitIfWindowNotFound.Text = "Never Quit if Window Not Found";
            chkGameWindowNeverQuitIfWindowNotFound.UseVisualStyleBackColor = true;
            chkGameWindowNeverQuitIfWindowNotFound.CheckedChanged += chkGameWindowNeverQuitIfWindowNotFound_CheckedChanged;
            // 
            // grpVideo
            // 
            grpVideo.Controls.Add(lblFrameLimit);
            grpVideo.Controls.Add(NumericVideoFrameLimit);
            grpVideo.Controls.Add(chkSaveVideo);
            grpVideo.Location = new Point(39, 317);
            grpVideo.Margin = new Padding(6, 5, 6, 5);
            grpVideo.Name = "grpVideo";
            grpVideo.Padding = new Padding(6, 5, 6, 5);
            grpVideo.Size = new Size(333, 147);
            grpVideo.TabIndex = 32;
            grpVideo.TabStop = false;
            grpVideo.Text = "Video";
            // 
            // lblFrameLimit
            // 
            lblFrameLimit.AutoSize = true;
            lblFrameLimit.Location = new Point(14, 83);
            lblFrameLimit.Margin = new Padding(6, 0, 6, 0);
            lblFrameLimit.Name = "lblFrameLimit";
            lblFrameLimit.Size = new Size(104, 25);
            lblFrameLimit.TabIndex = 33;
            lblFrameLimit.Text = "Frame Limit";
            // 
            // NumericVideoFrameLimit
            // 
            NumericVideoFrameLimit.Font = new Font("Microsoft Sans Serif", 15F);
            NumericVideoFrameLimit.Location = new Point(127, 67);
            NumericVideoFrameLimit.Margin = new Padding(6, 5, 6, 5);
            NumericVideoFrameLimit.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            NumericVideoFrameLimit.Name = "NumericVideoFrameLimit";
            NumericVideoFrameLimit.Size = new Size(157, 41);
            NumericVideoFrameLimit.TabIndex = 32;
            NumericVideoFrameLimit.ValueChanged += NumericVideoFrameLimit_ValueChanged;
            // 
            // chkSaveVideo
            // 
            chkSaveVideo.AutoSize = true;
            chkSaveVideo.Location = new Point(14, 28);
            chkSaveVideo.Margin = new Padding(6, 5, 6, 5);
            chkSaveVideo.Name = "chkSaveVideo";
            chkSaveVideo.Size = new Size(126, 29);
            chkSaveVideo.TabIndex = 31;
            chkSaveVideo.Text = "Save Video";
            chkSaveVideo.UseVisualStyleBackColor = true;
            chkSaveVideo.CheckedChanged += chkSaveVideo_CheckedChanged;
            // 
            // Label33
            // 
            Label33.AutoSize = true;
            Label33.Location = new Point(434, 37);
            Label33.Margin = new Padding(6, 0, 6, 0);
            Label33.Name = "Label33";
            Label33.Size = new Size(147, 25);
            Label33.TabIndex = 44;
            Label33.Text = "1,000 ms = 1 sec";
            // 
            // cmdStartEmmulatorAndPackage
            // 
            cmdStartEmmulatorAndPackage.Location = new Point(641, 145);
            cmdStartEmmulatorAndPackage.Margin = new Padding(6, 5, 6, 5);
            cmdStartEmmulatorAndPackage.Name = "cmdStartEmmulatorAndPackage";
            cmdStartEmmulatorAndPackage.Size = new Size(440, 45);
            cmdStartEmmulatorAndPackage.TabIndex = 21;
            cmdStartEmmulatorAndPackage.Text = "Start Emmulator + Run App";
            cmdStartEmmulatorAndPackage.UseVisualStyleBackColor = true;
            cmdStartEmmulatorAndPackage.Click += cmdStartEmmulatorAndPackage_Click;
            // 
            // cmdStartEmmulatorPackageAndRunScript
            // 
            cmdStartEmmulatorPackageAndRunScript.Location = new Point(641, 200);
            cmdStartEmmulatorPackageAndRunScript.Margin = new Padding(6, 5, 6, 5);
            cmdStartEmmulatorPackageAndRunScript.Name = "cmdStartEmmulatorPackageAndRunScript";
            cmdStartEmmulatorPackageAndRunScript.Size = new Size(440, 45);
            cmdStartEmmulatorPackageAndRunScript.TabIndex = 21;
            cmdStartEmmulatorPackageAndRunScript.Text = "Start Emmulator + Run App + Run Script";
            cmdStartEmmulatorPackageAndRunScript.UseVisualStyleBackColor = true;
            cmdStartEmmulatorPackageAndRunScript.Click += cmdStartEmmulatorPackageAndRunScript_Click;
            // 
            // cmdStartEmmulator
            // 
            cmdStartEmmulator.Location = new Point(641, 33);
            cmdStartEmmulator.Margin = new Padding(6, 5, 6, 5);
            cmdStartEmmulator.Name = "cmdStartEmmulator";
            cmdStartEmmulator.Size = new Size(440, 45);
            cmdStartEmmulator.TabIndex = 21;
            cmdStartEmmulator.Text = "Start Emmulator";
            cmdStartEmmulator.UseVisualStyleBackColor = true;
            cmdStartEmmulator.Click += cmdStartEmmulator_Click;
            // 
            // txtGamePanelLoopDelay
            // 
            txtGamePanelLoopDelay.BackColor = SystemColors.Window;
            txtGamePanelLoopDelay.Location = new Point(254, 33);
            txtGamePanelLoopDelay.Margin = new Padding(6, 5, 6, 5);
            txtGamePanelLoopDelay.Name = "txtGamePanelLoopDelay";
            txtGamePanelLoopDelay.Size = new Size(164, 31);
            txtGamePanelLoopDelay.TabIndex = 43;
            txtGamePanelLoopDelay.TextChanged += txtGamePanelLoopDelay_TextChanged_1;
            // 
            // Label30
            // 
            Label30.AutoSize = true;
            Label30.Location = new Point(21, 33);
            Label30.Margin = new Padding(6, 0, 6, 0);
            Label30.Name = "Label30";
            Label30.Size = new Size(141, 25);
            Label30.TabIndex = 42;
            Label30.Text = "Loop Delay (ms)";
            // 
            // cmdRunScript
            // 
            cmdRunScript.Location = new Point(641, 88);
            cmdRunScript.Margin = new Padding(6, 5, 6, 5);
            cmdRunScript.Name = "cmdRunScript";
            cmdRunScript.Size = new Size(440, 45);
            cmdRunScript.TabIndex = 22;
            cmdRunScript.Text = "Run Script";
            cmdRunScript.UseVisualStyleBackColor = true;
            cmdRunScript.Click += cmdRunScript_Click;
            // 
            // cboPlatform
            // 
            cboPlatform.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPlatform.FormattingEnabled = true;
            cboPlatform.Location = new Point(173, 87);
            cboPlatform.Name = "cboPlatform";
            cboPlatform.Size = new Size(383, 33);
            cboPlatform.TabIndex = 37;
            cboPlatform.SelectedIndexChanged += cboPlatform_SelectedIndexChanged;
            cboPlatform.TextChanged += cboPlatform_TextChanged;
            // 
            // lblGamePanelGameName
            // 
            lblGamePanelGameName.AutoSize = true;
            lblGamePanelGameName.Location = new Point(169, 53);
            lblGamePanelGameName.Margin = new Padding(6, 0, 6, 0);
            lblGamePanelGameName.Name = "lblGamePanelGameName";
            lblGamePanelGameName.Size = new Size(221, 25);
            lblGamePanelGameName.TabIndex = 2;
            lblGamePanelGameName.Text = "[lblGamePanelGameName]";
            // 
            // label62
            // 
            label62.AutoSize = true;
            label62.Location = new Point(19, 92);
            label62.Margin = new Padding(6, 0, 6, 0);
            label62.Name = "label62";
            label62.Size = new Size(80, 25);
            label62.TabIndex = 1;
            label62.Text = "Platform";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(19, 52);
            label18.Margin = new Padding(6, 0, 6, 0);
            label18.Name = "label18";
            label18.Size = new Size(98, 25);
            label18.TabIndex = 1;
            label18.Text = "App Name";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Microsoft Sans Serif", 11F);
            label22.Location = new Point(6, 0);
            label22.Margin = new Padding(6, 0, 6, 0);
            label22.Name = "label22";
            label22.Size = new Size(113, 26);
            label22.TabIndex = 0;
            label22.Text = "App Panel";
            // 
            // PanelObject
            // 
            PanelObject.Controls.Add(cmdDeleteObject);
            PanelObject.Controls.Add(label36);
            PanelObject.Controls.Add(txtObjectReferencedBy);
            PanelObject.Controls.Add(Panel5);
            PanelObject.Controls.Add(txtObjectName);
            PanelObject.Controls.Add(Label47);
            PanelObject.Controls.Add(Label46);
            PanelObject.Location = new Point(1463, 72);
            PanelObject.Margin = new Padding(6, 5, 6, 5);
            PanelObject.Name = "PanelObject";
            PanelObject.Size = new Size(1563, 948);
            PanelObject.TabIndex = 18;
            // 
            // cmdDeleteObject
            // 
            cmdDeleteObject.Location = new Point(967, 23);
            cmdDeleteObject.Margin = new Padding(6, 5, 6, 5);
            cmdDeleteObject.Name = "cmdDeleteObject";
            cmdDeleteObject.Size = new Size(126, 45);
            cmdDeleteObject.TabIndex = 12;
            cmdDeleteObject.Text = "Delete";
            cmdDeleteObject.UseVisualStyleBackColor = true;
            cmdDeleteObject.Click += cmdDeleteObject_Click;
            // 
            // label36
            // 
            label36.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label36.AutoSize = true;
            label36.Location = new Point(1113, 15);
            label36.Margin = new Padding(6, 0, 6, 0);
            label36.Name = "label36";
            label36.Size = new Size(124, 25);
            label36.TabIndex = 11;
            label36.Text = "Referenced by";
            // 
            // txtObjectReferencedBy
            // 
            txtObjectReferencedBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtObjectReferencedBy.BackColor = SystemColors.ButtonFace;
            txtObjectReferencedBy.Location = new Point(1110, 48);
            txtObjectReferencedBy.Margin = new Padding(6, 5, 6, 5);
            txtObjectReferencedBy.Multiline = true;
            txtObjectReferencedBy.Name = "txtObjectReferencedBy";
            txtObjectReferencedBy.ScrollBars = ScrollBars.Vertical;
            txtObjectReferencedBy.Size = new Size(445, 269);
            txtObjectReferencedBy.TabIndex = 10;
            // 
            // Panel5
            // 
            Panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel5.AutoScroll = true;
            Panel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Panel5.Controls.Add(PictureBoxObject);
            Panel5.Location = new Point(23, 117);
            Panel5.Margin = new Padding(6, 5, 6, 5);
            Panel5.Name = "Panel5";
            Panel5.Size = new Size(760, 747);
            Panel5.TabIndex = 9;
            // 
            // PictureBoxObject
            // 
            PictureBoxObject.Location = new Point(0, 0);
            PictureBoxObject.Margin = new Padding(6, 5, 6, 5);
            PictureBoxObject.Name = "PictureBoxObject";
            PictureBoxObject.Size = new Size(100, 50);
            PictureBoxObject.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBoxObject.TabIndex = 0;
            PictureBoxObject.TabStop = false;
            // 
            // txtObjectName
            // 
            txtObjectName.Enabled = false;
            txtObjectName.Location = new Point(87, 55);
            txtObjectName.Margin = new Padding(6, 5, 6, 5);
            txtObjectName.Name = "txtObjectName";
            txtObjectName.Size = new Size(454, 31);
            txtObjectName.TabIndex = 2;
            // 
            // Label47
            // 
            Label47.AutoSize = true;
            Label47.Location = new Point(19, 65);
            Label47.Margin = new Padding(6, 0, 6, 0);
            Label47.Name = "Label47";
            Label47.Size = new Size(59, 25);
            Label47.TabIndex = 1;
            Label47.Text = "Name";
            // 
            // Label46
            // 
            Label46.AutoSize = true;
            Label46.Location = new Point(19, 22);
            Label46.Margin = new Padding(6, 0, 6, 0);
            Label46.Name = "Label46";
            Label46.Size = new Size(64, 25);
            Label46.TabIndex = 0;
            Label46.Text = "Object";
            // 
            // PanelTestAllEvents
            // 
            PanelTestAllEvents.Controls.Add(SplitContainer6);
            PanelTestAllEvents.Location = new Point(1081, 285);
            PanelTestAllEvents.Margin = new Padding(6, 5, 6, 5);
            PanelTestAllEvents.Name = "PanelTestAllEvents";
            PanelTestAllEvents.Size = new Size(1747, 985);
            PanelTestAllEvents.TabIndex = 16;
            // 
            // SplitContainer6
            // 
            SplitContainer6.Dock = DockStyle.Fill;
            SplitContainer6.Location = new Point(0, 0);
            SplitContainer6.Margin = new Padding(6, 5, 6, 5);
            SplitContainer6.Name = "SplitContainer6";
            // 
            // SplitContainer6.Panel1
            // 
            SplitContainer6.Panel1.Controls.Add(SplitContainer7);
            // 
            // SplitContainer6.Panel2
            // 
            SplitContainer6.Panel2.Controls.Add(lblTestAllCustom);
            SplitContainer6.Panel2.Controls.Add(dgvTest);
            SplitContainer6.Panel2.Controls.Add(dgvTestAllReference);
            SplitContainer6.Panel2.Controls.Add(lblReferenceWindowResolution);
            SplitContainer6.Panel2.Controls.Add(lblTestWindowResolution);
            SplitContainer6.Panel2.Controls.Add(Panel2);
            SplitContainer6.Panel2.Controls.Add(lblTestWindow);
            SplitContainer6.Panel2.Controls.Add(lblReference);
            SplitContainer6.Panel2.Controls.Add(Panel1);
            SplitContainer6.Panel2.Resize += SplitContainer6_Panel2_Resize;
            SplitContainer6.Size = new Size(1747, 985);
            SplitContainer6.SplitterDistance = 301;
            SplitContainer6.SplitterWidth = 7;
            SplitContainer6.TabIndex = 2;
            // 
            // SplitContainer7
            // 
            SplitContainer7.Dock = DockStyle.Fill;
            SplitContainer7.Location = new Point(0, 0);
            SplitContainer7.Margin = new Padding(6, 5, 6, 5);
            SplitContainer7.Name = "SplitContainer7";
            SplitContainer7.Orientation = Orientation.Horizontal;
            // 
            // SplitContainer7.Panel1
            // 
            SplitContainer7.Panel1.Controls.Add(label35);
            // 
            // SplitContainer7.Panel2
            // 
            SplitContainer7.Panel2.Controls.Add(tvTestAllEvents);
            SplitContainer7.Size = new Size(301, 985);
            SplitContainer7.SplitterDistance = 45;
            SplitContainer7.SplitterWidth = 8;
            SplitContainer7.TabIndex = 0;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Microsoft Sans Serif", 11F);
            label35.Location = new Point(1, 2);
            label35.Margin = new Padding(6, 0, 6, 0);
            label35.Name = "label35";
            label35.Size = new Size(157, 26);
            label35.TabIndex = 0;
            label35.Text = "Test All Events";
            // 
            // tvTestAllEvents
            // 
            tvTestAllEvents.Dock = DockStyle.Fill;
            tvTestAllEvents.ImageIndex = 0;
            tvTestAllEvents.ImageList = ImageList1;
            tvTestAllEvents.Location = new Point(0, 0);
            tvTestAllEvents.Margin = new Padding(6, 5, 6, 5);
            tvTestAllEvents.Name = "tvTestAllEvents";
            tvTestAllEvents.SelectedImageIndex = 0;
            tvTestAllEvents.Size = new Size(301, 932);
            tvTestAllEvents.TabIndex = 1;
            tvTestAllEvents.AfterSelect += tvTestAllEvents_AfterSelect;
            tvTestAllEvents.MouseUp += tvTestAllEvents_MouseUp;
            // 
            // lblTestAllCustom
            // 
            lblTestAllCustom.AutoSize = true;
            lblTestAllCustom.Location = new Point(1067, 27);
            lblTestAllCustom.Margin = new Padding(6, 0, 6, 0);
            lblTestAllCustom.Name = "lblTestAllCustom";
            lblTestAllCustom.Size = new Size(143, 25);
            lblTestAllCustom.TabIndex = 14;
            lblTestAllCustom.Text = "lblTestAllCustom";
            // 
            // dgvTest
            // 
            dgvTest.Anchor = AnchorStyles.None;
            dgvTest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = SystemColors.Control;
            dataGridViewCellStyle17.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle17.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = DataGridViewTriState.True;
            dgvTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            dgvTest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTest.Columns.AddRange(new DataGridViewColumn[] { dgvColorTestID, dgvColorTestRed, dgvColorTestGreen, dgvColorTestBlue, dgvXTest, dgvYTest, dgvPassFail, dvgRange });
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = SystemColors.Window;
            dataGridViewCellStyle18.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle18.ForeColor = SystemColors.Control;
            dataGridViewCellStyle18.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = DataGridViewTriState.False;
            dgvTest.DefaultCellStyle = dataGridViewCellStyle18;
            dgvTest.Location = new Point(830, 435);
            dgvTest.Margin = new Padding(6, 5, 6, 5);
            dgvTest.Name = "dgvTest";
            dgvTest.RowHeadersWidth = 62;
            dgvTest.ScrollBars = ScrollBars.Vertical;
            dgvTest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTest.Size = new Size(753, 527);
            dgvTest.TabIndex = 13;
            // 
            // dgvColorTestID
            // 
            dgvColorTestID.HeaderText = "ID";
            dgvColorTestID.MinimumWidth = 8;
            dgvColorTestID.Name = "dgvColorTestID";
            dgvColorTestID.Width = 62;
            // 
            // dgvColorTestRed
            // 
            dgvColorTestRed.HeaderText = "Red";
            dgvColorTestRed.MinimumWidth = 8;
            dgvColorTestRed.Name = "dgvColorTestRed";
            dgvColorTestRed.Width = 75;
            // 
            // dgvColorTestGreen
            // 
            dgvColorTestGreen.HeaderText = "Green";
            dgvColorTestGreen.MinimumWidth = 8;
            dgvColorTestGreen.Name = "dgvColorTestGreen";
            dgvColorTestGreen.Width = 91;
            // 
            // dgvColorTestBlue
            // 
            dgvColorTestBlue.HeaderText = "Blue";
            dgvColorTestBlue.MinimumWidth = 8;
            dgvColorTestBlue.Name = "dgvColorTestBlue";
            dgvColorTestBlue.Width = 79;
            // 
            // dgvXTest
            // 
            dgvXTest.DataPropertyName = "dgvXTest";
            dgvXTest.HeaderText = "X";
            dgvXTest.MinimumWidth = 8;
            dgvXTest.Name = "dgvXTest";
            dgvXTest.Width = 56;
            // 
            // dgvYTest
            // 
            dgvYTest.DataPropertyName = "dgvYTest";
            dgvYTest.HeaderText = "Y";
            dgvYTest.MinimumWidth = 8;
            dgvYTest.Name = "dgvYTest";
            dgvYTest.Width = 55;
            // 
            // dgvPassFail
            // 
            dgvPassFail.HeaderText = "Pass/Fail";
            dgvPassFail.MinimumWidth = 8;
            dgvPassFail.Name = "dgvPassFail";
            dgvPassFail.Width = 115;
            // 
            // dvgRange
            // 
            dvgRange.HeaderText = "+-Points";
            dvgRange.MinimumWidth = 8;
            dvgRange.Name = "dvgRange";
            dvgRange.Width = 108;
            // 
            // dgvTestAllReference
            // 
            dgvTestAllReference.Anchor = AnchorStyles.None;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = SystemColors.Control;
            dataGridViewCellStyle19.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle19.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvTestAllReference.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvTestAllReference.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTestAllReference.Columns.AddRange(new DataGridViewColumn[] { dgvTestAllReferenceID, dgvTestAllReferenceRed, dgvTestAllReferenceGreen, dgvTestAllReferenceBlue, dgvTestAllReferenceX, dgvTestAllReferenceY });
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = SystemColors.Window;
            dataGridViewCellStyle20.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle20.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.False;
            dgvTestAllReference.DefaultCellStyle = dataGridViewCellStyle20;
            dgvTestAllReference.Location = new Point(830, 92);
            dgvTestAllReference.Margin = new Padding(6, 5, 6, 5);
            dgvTestAllReference.Name = "dgvTestAllReference";
            dgvTestAllReference.RowHeadersWidth = 62;
            dgvTestAllReference.ScrollBars = ScrollBars.Vertical;
            dgvTestAllReference.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTestAllReference.Size = new Size(753, 308);
            dgvTestAllReference.TabIndex = 11;
            // 
            // dgvTestAllReferenceID
            // 
            dgvTestAllReferenceID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTestAllReferenceID.HeaderText = "ID";
            dgvTestAllReferenceID.MinimumWidth = 8;
            dgvTestAllReferenceID.Name = "dgvTestAllReferenceID";
            dgvTestAllReferenceID.Width = 62;
            // 
            // dgvTestAllReferenceRed
            // 
            dgvTestAllReferenceRed.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTestAllReferenceRed.HeaderText = "Red";
            dgvTestAllReferenceRed.MinimumWidth = 8;
            dgvTestAllReferenceRed.Name = "dgvTestAllReferenceRed";
            dgvTestAllReferenceRed.Width = 75;
            // 
            // dgvTestAllReferenceGreen
            // 
            dgvTestAllReferenceGreen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTestAllReferenceGreen.HeaderText = "Green";
            dgvTestAllReferenceGreen.MinimumWidth = 8;
            dgvTestAllReferenceGreen.Name = "dgvTestAllReferenceGreen";
            dgvTestAllReferenceGreen.Width = 91;
            // 
            // dgvTestAllReferenceBlue
            // 
            dgvTestAllReferenceBlue.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTestAllReferenceBlue.HeaderText = "Blue";
            dgvTestAllReferenceBlue.MinimumWidth = 8;
            dgvTestAllReferenceBlue.Name = "dgvTestAllReferenceBlue";
            dgvTestAllReferenceBlue.Width = 79;
            // 
            // dgvTestAllReferenceX
            // 
            dgvTestAllReferenceX.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTestAllReferenceX.DataPropertyName = "dgvTestAllReferenceX";
            dgvTestAllReferenceX.HeaderText = "X";
            dgvTestAllReferenceX.MinimumWidth = 8;
            dgvTestAllReferenceX.Name = "dgvTestAllReferenceX";
            dgvTestAllReferenceX.Width = 56;
            // 
            // dgvTestAllReferenceY
            // 
            dgvTestAllReferenceY.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTestAllReferenceY.DataPropertyName = "dgvTestAllReferenceY";
            dgvTestAllReferenceY.HeaderText = "Y";
            dgvTestAllReferenceY.MinimumWidth = 8;
            dgvTestAllReferenceY.Name = "dgvTestAllReferenceY";
            dgvTestAllReferenceY.Width = 55;
            // 
            // lblReferenceWindowResolution
            // 
            lblReferenceWindowResolution.AutoSize = true;
            lblReferenceWindowResolution.Location = new Point(571, 492);
            lblReferenceWindowResolution.Margin = new Padding(6, 0, 6, 0);
            lblReferenceWindowResolution.Name = "lblReferenceWindowResolution";
            lblReferenceWindowResolution.Size = new Size(256, 25);
            lblReferenceWindowResolution.TabIndex = 8;
            lblReferenceWindowResolution.Text = "lblReferenceWindowResolution";
            // 
            // lblTestWindowResolution
            // 
            lblTestWindowResolution.AutoSize = true;
            lblTestWindowResolution.Location = new Point(620, 47);
            lblTestWindowResolution.Margin = new Padding(6, 0, 6, 0);
            lblTestWindowResolution.Name = "lblTestWindowResolution";
            lblTestWindowResolution.Size = new Size(210, 25);
            lblTestWindowResolution.TabIndex = 12;
            lblTestWindowResolution.Text = "lblTestWindowResolution";
            // 
            // Panel2
            // 
            Panel2.Anchor = AnchorStyles.None;
            Panel2.AutoScroll = true;
            Panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Panel2.Controls.Add(PictureTestAllTest);
            Panel2.Location = new Point(-219, 527);
            Panel2.Margin = new Padding(6, 5, 6, 5);
            Panel2.Name = "Panel2";
            Panel2.Size = new Size(814, 453);
            Panel2.TabIndex = 11;
            // 
            // PictureTestAllTest
            // 
            PictureTestAllTest.Location = new Point(6, 5);
            PictureTestAllTest.Margin = new Padding(6, 5, 6, 5);
            PictureTestAllTest.Name = "PictureTestAllTest";
            PictureTestAllTest.Size = new Size(100, 50);
            PictureTestAllTest.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureTestAllTest.TabIndex = 1;
            PictureTestAllTest.TabStop = false;
            PictureTestAllTest.Paint += PictureTestAllTest_Paint;
            // 
            // lblTestWindow
            // 
            lblTestWindow.AutoSize = true;
            lblTestWindow.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblTestWindow.Location = new Point(19, 15);
            lblTestWindow.Margin = new Padding(6, 0, 6, 0);
            lblTestWindow.Name = "lblTestWindow";
            lblTestWindow.Size = new Size(260, 33);
            lblTestWindow.TabIndex = 10;
            lblTestWindow.Text = "Reference Window";
            // 
            // lblReference
            // 
            lblReference.AutoSize = true;
            lblReference.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblReference.Location = new Point(13, 452);
            lblReference.Margin = new Padding(6, 0, 6, 0);
            lblReference.Name = "lblReference";
            lblReference.Size = new Size(183, 33);
            lblReference.TabIndex = 9;
            lblReference.Text = "Test Window";
            // 
            // Panel1
            // 
            Panel1.Anchor = AnchorStyles.None;
            Panel1.AutoScroll = true;
            Panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Panel1.BackColor = SystemColors.ActiveCaptionText;
            Panel1.Controls.Add(PictureTestAllReference);
            Panel1.Location = new Point(-210, 80);
            Panel1.Margin = new Padding(6, 5, 6, 5);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(809, 365);
            Panel1.TabIndex = 8;
            // 
            // PictureTestAllReference
            // 
            PictureTestAllReference.BackColor = SystemColors.Control;
            PictureTestAllReference.Location = new Point(6, 5);
            PictureTestAllReference.Margin = new Padding(6, 5, 6, 5);
            PictureTestAllReference.Name = "PictureTestAllReference";
            PictureTestAllReference.Size = new Size(100, 50);
            PictureTestAllReference.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureTestAllReference.TabIndex = 1;
            PictureTestAllReference.TabStop = false;
            PictureTestAllReference.Paint += PictureTestAllReference_Paint;
            // 
            // PanelGames
            // 
            PanelGames.Controls.Add(label43);
            PanelGames.Location = new Point(1344, 115);
            PanelGames.Margin = new Padding(6, 5, 6, 5);
            PanelGames.Name = "PanelGames";
            PanelGames.Size = new Size(333, 192);
            PanelGames.TabIndex = 21;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new Font("Microsoft Sans Serif", 11F);
            label43.Location = new Point(6, 5);
            label43.Margin = new Padding(6, 0, 6, 0);
            label43.Name = "label43";
            label43.Size = new Size(145, 26);
            label43.TabIndex = 1;
            label43.Text = "Panel Games";
            // 
            // PanelActions
            // 
            PanelActions.Controls.Add(label41);
            PanelActions.Location = new Point(1249, 163);
            PanelActions.Margin = new Padding(6, 5, 6, 5);
            PanelActions.Name = "PanelActions";
            PanelActions.Size = new Size(617, 415);
            PanelActions.TabIndex = 20;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Microsoft Sans Serif", 11F);
            label41.Location = new Point(6, 0);
            label41.Margin = new Padding(6, 0, 6, 0);
            label41.Name = "label41";
            label41.Size = new Size(146, 26);
            label41.TabIndex = 2;
            label41.Text = "Actions Panel";
            // 
            // PanelObjectScreenshot
            // 
            PanelObjectScreenshot.Controls.Add(pictureCreateNewObjectNamedCheckBox);
            PanelObjectScreenshot.Controls.Add(pictureCreateNewObjectMaskDrawnCheckBox);
            PanelObjectScreenshot.Controls.Add(cmdMakeObjectAndUse);
            PanelObjectScreenshot.Controls.Add(cmdMakeObject);
            PanelObjectScreenshot.Controls.Add(panelObjectScreenshotColor);
            PanelObjectScreenshot.Controls.Add(PictureObjectScreenshotZoomBox);
            PanelObjectScreenshot.Controls.Add(txtObjectScreenshotName);
            PanelObjectScreenshot.Controls.Add(Label45);
            PanelObjectScreenshot.Controls.Add(cmdObjectScreenshotsTakeAScreenshot);
            PanelObjectScreenshot.Controls.Add(Panel4);
            PanelObjectScreenshot.Controls.Add(Label44);
            PanelObjectScreenshot.Controls.Add(Label53);
            PanelObjectScreenshot.Location = new Point(599, 613);
            PanelObjectScreenshot.Margin = new Padding(6, 5, 6, 5);
            PanelObjectScreenshot.Name = "PanelObjectScreenshot";
            PanelObjectScreenshot.Size = new Size(1327, 733);
            PanelObjectScreenshot.TabIndex = 12;
            // 
            // pictureCreateNewObjectNamedCheckBox
            // 
            pictureCreateNewObjectNamedCheckBox.Image = Properties.Resources.PSGreenCheck;
            pictureCreateNewObjectNamedCheckBox.Location = new Point(634, 83);
            pictureCreateNewObjectNamedCheckBox.Margin = new Padding(6, 5, 6, 5);
            pictureCreateNewObjectNamedCheckBox.Name = "pictureCreateNewObjectNamedCheckBox";
            pictureCreateNewObjectNamedCheckBox.Size = new Size(26, 28);
            pictureCreateNewObjectNamedCheckBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureCreateNewObjectNamedCheckBox.TabIndex = 17;
            pictureCreateNewObjectNamedCheckBox.TabStop = false;
            // 
            // pictureCreateNewObjectMaskDrawnCheckBox
            // 
            pictureCreateNewObjectMaskDrawnCheckBox.Image = Properties.Resources.PSGreenCheck;
            pictureCreateNewObjectMaskDrawnCheckBox.Location = new Point(634, 53);
            pictureCreateNewObjectMaskDrawnCheckBox.Margin = new Padding(6, 5, 6, 5);
            pictureCreateNewObjectMaskDrawnCheckBox.Name = "pictureCreateNewObjectMaskDrawnCheckBox";
            pictureCreateNewObjectMaskDrawnCheckBox.Size = new Size(26, 28);
            pictureCreateNewObjectMaskDrawnCheckBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureCreateNewObjectMaskDrawnCheckBox.TabIndex = 16;
            pictureCreateNewObjectMaskDrawnCheckBox.TabStop = false;
            // 
            // cmdMakeObjectAndUse
            // 
            cmdMakeObjectAndUse.Location = new Point(380, 22);
            cmdMakeObjectAndUse.Margin = new Padding(6, 5, 6, 5);
            cmdMakeObjectAndUse.Name = "cmdMakeObjectAndUse";
            cmdMakeObjectAndUse.Size = new Size(234, 45);
            cmdMakeObjectAndUse.TabIndex = 14;
            cmdMakeObjectAndUse.Text = "Make Object + Use";
            cmdMakeObjectAndUse.UseVisualStyleBackColor = true;
            cmdMakeObjectAndUse.Click += cmdMakeObjectAndUse_Click;
            // 
            // cmdMakeObject
            // 
            cmdMakeObject.Location = new Point(380, 77);
            cmdMakeObject.Margin = new Padding(6, 5, 6, 5);
            cmdMakeObject.Name = "cmdMakeObject";
            cmdMakeObject.Size = new Size(234, 45);
            cmdMakeObject.TabIndex = 14;
            cmdMakeObject.Text = "Make Object";
            cmdMakeObject.UseVisualStyleBackColor = true;
            cmdMakeObject.Click += cmdMakeObject_Click;
            // 
            // panelObjectScreenshotColor
            // 
            panelObjectScreenshotColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelObjectScreenshotColor.Controls.Add(lblObjectScreenshotColorXY);
            panelObjectScreenshotColor.Controls.Add(lblObjectScreenshotRHSXY);
            panelObjectScreenshotColor.Location = new Point(1053, 327);
            panelObjectScreenshotColor.Margin = new Padding(6, 5, 6, 5);
            panelObjectScreenshotColor.Name = "panelObjectScreenshotColor";
            panelObjectScreenshotColor.Size = new Size(263, 80);
            panelObjectScreenshotColor.TabIndex = 13;
            // 
            // lblObjectScreenshotColorXY
            // 
            lblObjectScreenshotColorXY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblObjectScreenshotColorXY.AutoSize = true;
            lblObjectScreenshotColorXY.Location = new Point(3, 38);
            lblObjectScreenshotColorXY.Margin = new Padding(6, 0, 6, 0);
            lblObjectScreenshotColorXY.Name = "lblObjectScreenshotColorXY";
            lblObjectScreenshotColorXY.Size = new Size(105, 25);
            lblObjectScreenshotColorXY.TabIndex = 2;
            lblObjectScreenshotColorXY.Text = "[lblColorXY]";
            // 
            // lblObjectScreenshotRHSXY
            // 
            lblObjectScreenshotRHSXY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblObjectScreenshotRHSXY.AutoSize = true;
            lblObjectScreenshotRHSXY.Location = new Point(6, 13);
            lblObjectScreenshotRHSXY.Margin = new Padding(6, 0, 6, 0);
            lblObjectScreenshotRHSXY.Name = "lblObjectScreenshotRHSXY";
            lblObjectScreenshotRHSXY.Size = new Size(96, 25);
            lblObjectScreenshotRHSXY.TabIndex = 3;
            lblObjectScreenshotRHSXY.Text = "[lblRHSXY]";
            // 
            // PictureObjectScreenshotZoomBox
            // 
            PictureObjectScreenshotZoomBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureObjectScreenshotZoomBox.Image = (Image)resources.GetObject("PictureObjectScreenshotZoomBox.Image");
            PictureObjectScreenshotZoomBox.Location = new Point(1050, 8);
            PictureObjectScreenshotZoomBox.Margin = new Padding(6, 5, 6, 5);
            PictureObjectScreenshotZoomBox.Name = "PictureObjectScreenshotZoomBox";
            PictureObjectScreenshotZoomBox.Size = new Size(267, 308);
            PictureObjectScreenshotZoomBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureObjectScreenshotZoomBox.TabIndex = 12;
            PictureObjectScreenshotZoomBox.TabStop = false;
            // 
            // txtObjectScreenshotName
            // 
            txtObjectScreenshotName.Location = new Point(94, 138);
            txtObjectScreenshotName.Margin = new Padding(6, 5, 6, 5);
            txtObjectScreenshotName.Name = "txtObjectScreenshotName";
            txtObjectScreenshotName.Size = new Size(521, 31);
            txtObjectScreenshotName.TabIndex = 11;
            txtObjectScreenshotName.TextChanged += txtObjectScreenshotName_TextChanged;
            // 
            // Label45
            // 
            Label45.AutoSize = true;
            Label45.Location = new Point(21, 138);
            Label45.Margin = new Padding(6, 0, 6, 0);
            Label45.Name = "Label45";
            Label45.Size = new Size(63, 25);
            Label45.TabIndex = 10;
            Label45.Text = "Name:";
            // 
            // cmdObjectScreenshotsTakeAScreenshot
            // 
            cmdObjectScreenshotsTakeAScreenshot.Location = new Point(26, 48);
            cmdObjectScreenshotsTakeAScreenshot.Margin = new Padding(6, 5, 6, 5);
            cmdObjectScreenshotsTakeAScreenshot.Name = "cmdObjectScreenshotsTakeAScreenshot";
            cmdObjectScreenshotsTakeAScreenshot.Size = new Size(213, 45);
            cmdObjectScreenshotsTakeAScreenshot.TabIndex = 9;
            cmdObjectScreenshotsTakeAScreenshot.Text = "Take a Screenshot";
            cmdObjectScreenshotsTakeAScreenshot.UseVisualStyleBackColor = true;
            cmdObjectScreenshotsTakeAScreenshot.Click += cmdObjectScreenshotsTakeAScreenshot_Click;
            // 
            // Panel4
            // 
            Panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel4.AutoScroll = true;
            Panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Panel4.Controls.Add(PictureObjectScreenshot);
            Panel4.Location = new Point(26, 195);
            Panel4.Margin = new Padding(6, 5, 6, 5);
            Panel4.Name = "Panel4";
            Panel4.Size = new Size(861, 513);
            Panel4.TabIndex = 8;
            // 
            // PictureObjectScreenshot
            // 
            PictureObjectScreenshot.Cursor = Cursors.Cross;
            PictureObjectScreenshot.Location = new Point(13, 15);
            PictureObjectScreenshot.Margin = new Padding(6, 5, 6, 5);
            PictureObjectScreenshot.Name = "PictureObjectScreenshot";
            PictureObjectScreenshot.Size = new Size(286, 263);
            PictureObjectScreenshot.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureObjectScreenshot.TabIndex = 16;
            PictureObjectScreenshot.TabStop = false;
            PictureObjectScreenshot.Paint += PictureObjectScreenshot_Paint;
            PictureObjectScreenshot.MouseDown += PictureObjectScreenshot_MouseDown;
            PictureObjectScreenshot.MouseMove += PictureObjectScreenshot_MouseMove;
            PictureObjectScreenshot.MouseUp += PictureObjectScreenshot_MouseUp;
            // 
            // Label44
            // 
            Label44.AutoSize = true;
            Label44.Font = new Font("Microsoft Sans Serif", 11F);
            Label44.Location = new Point(26, 8);
            Label44.Margin = new Padding(6, 0, 6, 0);
            Label44.Name = "Label44";
            Label44.Size = new Size(196, 26);
            Label44.TabIndex = 0;
            Label44.Text = "Create New Object";
            // 
            // Label53
            // 
            Label53.Location = new Point(657, 33);
            Label53.Margin = new Padding(6, 0, 6, 0);
            Label53.Name = "Label53";
            Label53.Size = new Size(774, 260);
            Label53.TabIndex = 15;
            Label53.Text = resources.GetString("Label53.Text");
            // 
            // PanelAddNewGames
            // 
            PanelAddNewGames.Controls.Add(label39);
            PanelAddNewGames.Controls.Add(txtAddNewGame);
            PanelAddNewGames.Controls.Add(label38);
            PanelAddNewGames.Location = new Point(874, 362);
            PanelAddNewGames.Margin = new Padding(6, 5, 6, 5);
            PanelAddNewGames.Name = "PanelAddNewGames";
            PanelAddNewGames.Size = new Size(643, 222);
            PanelAddNewGames.TabIndex = 17;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(10, 52);
            label39.Margin = new Padding(6, 0, 6, 0);
            label39.Name = "label39";
            label39.Size = new Size(110, 25);
            label39.TabIndex = 2;
            label39.Text = "Game Name";
            // 
            // txtAddNewGame
            // 
            txtAddNewGame.BackColor = SystemColors.Window;
            txtAddNewGame.Location = new Point(127, 47);
            txtAddNewGame.Margin = new Padding(6, 5, 6, 5);
            txtAddNewGame.Name = "txtAddNewGame";
            txtAddNewGame.Size = new Size(510, 31);
            txtAddNewGame.TabIndex = 1;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Font = new Font("Microsoft Sans Serif", 11.25F);
            label38.Location = new Point(6, 0);
            label38.Margin = new Padding(6, 0, 6, 0);
            label38.Name = "label38";
            label38.Size = new Size(183, 29);
            label38.TabIndex = 0;
            label38.Text = "Add New Game";
            // 
            // PanelObjects
            // 
            PanelObjects.Controls.Add(label34);
            PanelObjects.Controls.Add(label32);
            PanelObjects.Location = new Point(710, 548);
            PanelObjects.Margin = new Padding(6, 5, 6, 5);
            PanelObjects.Name = "PanelObjects";
            PanelObjects.Size = new Size(333, 192);
            PanelObjects.TabIndex = 15;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(120, 97);
            label34.Margin = new Padding(6, 0, 6, 0);
            label34.Name = "label34";
            label34.Size = new Size(139, 25);
            label34.TabIndex = 3;
            label34.Text = "Currently Empty";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Microsoft Sans Serif", 11.25F);
            label32.Location = new Point(6, 0);
            label32.Margin = new Padding(6, 0, 6, 0);
            label32.Name = "label32";
            label32.Size = new Size(96, 29);
            label32.TabIndex = 2;
            label32.Text = "Objects";
            // 
            // PanelEvents
            // 
            PanelEvents.Controls.Add(lblEventsPanelTargetWindow);
            PanelEvents.Controls.Add(label11);
            PanelEvents.Controls.Add(label10);
            PanelEvents.Location = new Point(439, 772);
            PanelEvents.Margin = new Padding(6, 5, 6, 5);
            PanelEvents.Name = "PanelEvents";
            PanelEvents.Size = new Size(851, 390);
            PanelEvents.TabIndex = 2;
            // 
            // lblEventsPanelTargetWindow
            // 
            lblEventsPanelTargetWindow.AutoSize = true;
            lblEventsPanelTargetWindow.Location = new Point(154, 50);
            lblEventsPanelTargetWindow.Margin = new Padding(6, 0, 6, 0);
            lblEventsPanelTargetWindow.Name = "lblEventsPanelTargetWindow";
            lblEventsPanelTargetWindow.Size = new Size(237, 25);
            lblEventsPanelTargetWindow.TabIndex = 3;
            lblEventsPanelTargetWindow.Text = "lblEventsPanelTargetWindow";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(10, 52);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(131, 25);
            label11.TabIndex = 2;
            label11.Text = "Target Window";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 11.25F);
            label10.Location = new Point(6, 10);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(85, 29);
            label10.TabIndex = 1;
            label10.Text = "Events";
            // 
            // PanelSchedule
            // 
            PanelSchedule.Controls.Add(splitContainerSchedule);
            PanelSchedule.Controls.Add(Button5);
            PanelSchedule.Controls.Add(chkEnableSchedule);
            PanelSchedule.Controls.Add(Button4);
            PanelSchedule.Controls.Add(cmdAddSchedule);
            PanelSchedule.Controls.Add(label40);
            PanelSchedule.Location = new Point(141, 80);
            PanelSchedule.Margin = new Padding(6, 5, 6, 5);
            PanelSchedule.Name = "PanelSchedule";
            PanelSchedule.Size = new Size(1034, 753);
            PanelSchedule.TabIndex = 19;
            // 
            // splitContainerSchedule
            // 
            splitContainerSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerSchedule.Location = new Point(6, 102);
            splitContainerSchedule.Margin = new Padding(6, 5, 6, 5);
            splitContainerSchedule.Name = "splitContainerSchedule";
            splitContainerSchedule.Orientation = Orientation.Horizontal;
            // 
            // splitContainerSchedule.Panel1
            // 
            splitContainerSchedule.Panel1.Controls.Add(dgSchedule);
            // 
            // splitContainerSchedule.Panel2
            // 
            splitContainerSchedule.Panel2.Controls.Add(splitContainerRuntimeSchedule);
            splitContainerSchedule.Size = new Size(1023, 647);
            splitContainerSchedule.SplitterDistance = 321;
            splitContainerSchedule.SplitterWidth = 8;
            splitContainerSchedule.TabIndex = 8;
            // 
            // dgSchedule
            // 
            dgSchedule.AllowUserToAddRows = false;
            dgSchedule.AllowUserToDeleteRows = false;
            dgSchedule.AllowUserToOrderColumns = true;
            dgSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSchedule.Columns.AddRange(new DataGridViewColumn[] { colName, colWindowName, colInstance, colStartTime, colRepeat, colScheduleEnabled, colEdit });
            dgSchedule.Dock = DockStyle.Fill;
            dgSchedule.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgSchedule.Location = new Point(0, 0);
            dgSchedule.Margin = new Padding(6, 5, 6, 5);
            dgSchedule.Name = "dgSchedule";
            dgSchedule.ReadOnly = true;
            dgSchedule.RowHeadersWidth = 62;
            dgSchedule.Size = new Size(1023, 321);
            dgSchedule.TabIndex = 3;
            dgSchedule.CellContentClick += dgSchedule_CellContentClick;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // colWindowName
            // 
            colWindowName.HeaderText = "Window";
            colWindowName.MinimumWidth = 8;
            colWindowName.Name = "colWindowName";
            colWindowName.ReadOnly = true;
            colWindowName.Width = 150;
            // 
            // colInstance
            // 
            colInstance.HeaderText = "Instance";
            colInstance.MinimumWidth = 60;
            colInstance.Name = "colInstance";
            colInstance.ReadOnly = true;
            colInstance.Width = 60;
            // 
            // colStartTime
            // 
            colStartTime.HeaderText = "Start Time";
            colStartTime.MinimumWidth = 8;
            colStartTime.Name = "colStartTime";
            colStartTime.ReadOnly = true;
            colStartTime.Width = 150;
            // 
            // colRepeat
            // 
            colRepeat.HeaderText = "Repeats";
            colRepeat.MinimumWidth = 8;
            colRepeat.Name = "colRepeat";
            colRepeat.ReadOnly = true;
            colRepeat.Width = 150;
            // 
            // colScheduleEnabled
            // 
            colScheduleEnabled.HeaderText = "Enabled";
            colScheduleEnabled.MinimumWidth = 8;
            colScheduleEnabled.Name = "colScheduleEnabled";
            colScheduleEnabled.ReadOnly = true;
            colScheduleEnabled.Width = 150;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Modify";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 35;
            // 
            // splitContainerRuntimeSchedule
            // 
            splitContainerRuntimeSchedule.Dock = DockStyle.Fill;
            splitContainerRuntimeSchedule.FixedPanel = FixedPanel.Panel1;
            splitContainerRuntimeSchedule.IsSplitterFixed = true;
            splitContainerRuntimeSchedule.Location = new Point(0, 0);
            splitContainerRuntimeSchedule.Margin = new Padding(6, 5, 6, 5);
            splitContainerRuntimeSchedule.Name = "splitContainerRuntimeSchedule";
            splitContainerRuntimeSchedule.Orientation = Orientation.Horizontal;
            // 
            // splitContainerRuntimeSchedule.Panel1
            // 
            splitContainerRuntimeSchedule.Panel1.Controls.Add(lblRuntimeScheduleLabel);
            splitContainerRuntimeSchedule.Panel1MinSize = 21;
            // 
            // splitContainerRuntimeSchedule.Panel2
            // 
            splitContainerRuntimeSchedule.Panel2.Controls.Add(dgRuntimeSchedule);
            splitContainerRuntimeSchedule.Size = new Size(1023, 318);
            splitContainerRuntimeSchedule.SplitterDistance = 25;
            splitContainerRuntimeSchedule.SplitterWidth = 8;
            splitContainerRuntimeSchedule.TabIndex = 0;
            // 
            // lblRuntimeScheduleLabel
            // 
            lblRuntimeScheduleLabel.AutoSize = true;
            lblRuntimeScheduleLabel.Dock = DockStyle.Top;
            lblRuntimeScheduleLabel.Location = new Point(0, 0);
            lblRuntimeScheduleLabel.Margin = new Padding(6, 0, 6, 0);
            lblRuntimeScheduleLabel.Name = "lblRuntimeScheduleLabel";
            lblRuntimeScheduleLabel.Size = new Size(201, 25);
            lblRuntimeScheduleLabel.TabIndex = 0;
            lblRuntimeScheduleLabel.Text = "Schedule plan for today";
            // 
            // dgRuntimeSchedule
            // 
            dgRuntimeSchedule.AllowUserToAddRows = false;
            dgRuntimeSchedule.AllowUserToDeleteRows = false;
            dgRuntimeSchedule.AllowUserToOrderColumns = true;
            dgRuntimeSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgRuntimeSchedule.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgRuntimeSchedule.Dock = DockStyle.Fill;
            dgRuntimeSchedule.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgRuntimeSchedule.Location = new Point(0, 0);
            dgRuntimeSchedule.Margin = new Padding(6, 5, 6, 5);
            dgRuntimeSchedule.Name = "dgRuntimeSchedule";
            dgRuntimeSchedule.ReadOnly = true;
            dgRuntimeSchedule.RowHeadersWidth = 62;
            dgRuntimeSchedule.Size = new Size(1023, 285);
            dgRuntimeSchedule.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Window";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Instance";
            dataGridViewTextBoxColumn3.MinimumWidth = 60;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Start Time";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 150;
            // 
            // Button5
            // 
            Button5.Location = new Point(324, 55);
            Button5.Margin = new Padding(6, 5, 6, 5);
            Button5.Name = "Button5";
            Button5.Size = new Size(126, 45);
            Button5.TabIndex = 7;
            Button5.Text = "Button5";
            Button5.UseVisualStyleBackColor = true;
            Button5.Visible = false;
            // 
            // chkEnableSchedule
            // 
            chkEnableSchedule.AutoSize = true;
            chkEnableSchedule.Location = new Point(14, 47);
            chkEnableSchedule.Margin = new Padding(6, 5, 6, 5);
            chkEnableSchedule.Name = "chkEnableSchedule";
            chkEnableSchedule.Size = new Size(172, 29);
            chkEnableSchedule.TabIndex = 6;
            chkEnableSchedule.Text = "Enable Scheduler";
            chkEnableSchedule.UseVisualStyleBackColor = true;
            chkEnableSchedule.CheckedChanged += chkEnableSchedule_CheckedChanged;
            // 
            // Button4
            // 
            Button4.Location = new Point(431, 0);
            Button4.Margin = new Padding(6, 5, 6, 5);
            Button4.Name = "Button4";
            Button4.Size = new Size(367, 45);
            Button4.TabIndex = 5;
            Button4.Text = "add 1 schedule entry";
            Button4.UseVisualStyleBackColor = true;
            Button4.Visible = false;
            // 
            // cmdAddSchedule
            // 
            cmdAddSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdAddSchedule.Location = new Point(826, 8);
            cmdAddSchedule.Margin = new Padding(6, 5, 6, 5);
            cmdAddSchedule.Name = "cmdAddSchedule";
            cmdAddSchedule.Size = new Size(206, 45);
            cmdAddSchedule.TabIndex = 4;
            cmdAddSchedule.Text = "Add New Schedule";
            cmdAddSchedule.UseVisualStyleBackColor = true;
            cmdAddSchedule.Click += cmdAddSchedule_Click;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Microsoft Sans Serif", 11F);
            label40.Location = new Point(6, 3);
            label40.Margin = new Padding(6, 0, 6, 0);
            label40.Name = "label40";
            label40.Size = new Size(103, 26);
            label40.TabIndex = 2;
            label40.Text = "Schedule";
            // 
            // PanelWorkspace
            // 
            PanelWorkspace.Controls.Add(groupBox15);
            PanelWorkspace.Controls.Add(groupBox12);
            PanelWorkspace.Controls.Add(groupBox3);
            PanelWorkspace.Controls.Add(label4);
            PanelWorkspace.Location = new Point(813, 460);
            PanelWorkspace.Margin = new Padding(6, 5, 6, 5);
            PanelWorkspace.Name = "PanelWorkspace";
            PanelWorkspace.Size = new Size(1589, 1097);
            PanelWorkspace.TabIndex = 1;
            // 
            // groupBox15
            // 
            groupBox15.Controls.Add(label94);
            groupBox15.Controls.Add(label86);
            groupBox15.Controls.Add(label85);
            groupBox15.Location = new Point(669, 60);
            groupBox15.Margin = new Padding(6, 5, 6, 5);
            groupBox15.Name = "groupBox15";
            groupBox15.Padding = new Padding(6, 5, 6, 5);
            groupBox15.Size = new Size(674, 267);
            groupBox15.TabIndex = 4;
            groupBox15.TabStop = false;
            groupBox15.Text = "Keyboard Shortcuts";
            // 
            // label94
            // 
            label94.AutoSize = true;
            label94.Location = new Point(10, 142);
            label94.Margin = new Padding(6, 0, 6, 0);
            label94.Name = "label94";
            label94.Size = new Size(330, 25);
            label94.TabIndex = 3;
            label94.Text = "Ctrl + Alt + Shift + F1 = Take Screenshot";
            // 
            // label86
            // 
            label86.AutoSize = true;
            label86.Location = new Point(10, 97);
            label86.Margin = new Padding(6, 0, 6, 0);
            label86.Name = "label86";
            label86.Size = new Size(377, 25);
            label86.TabIndex = 3;
            label86.Text = "Ctrl + Alt + Shift + F5 = Toggle Scripts On/Off";
            // 
            // label85
            // 
            label85.AutoSize = true;
            label85.Location = new Point(10, 45);
            label85.Margin = new Padding(6, 0, 6, 0);
            label85.Name = "label85";
            label85.Size = new Size(389, 25);
            label85.TabIndex = 3;
            label85.Text = "Ctrl + Alt + Shift + ESC = Pause Running Scripts";
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(lblBlueInstancesFound64);
            groupBox12.Controls.Add(lblBlueEmmulatorInstalled64);
            groupBox12.Controls.Add(lblBlueInstancesFound32);
            groupBox12.Controls.Add(label81);
            groupBox12.Controls.Add(lblBlueEmmulatorInstalled32);
            groupBox12.Controls.Add(label80);
            groupBox12.Controls.Add(label68);
            groupBox12.Controls.Add(label65);
            groupBox12.Location = new Point(11, 202);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new Size(644, 245);
            groupBox12.TabIndex = 2;
            groupBox12.TabStop = false;
            groupBox12.Text = "Blue Check List - Not Required";
            // 
            // lblBlueInstancesFound64
            // 
            lblBlueInstancesFound64.AutoSize = true;
            lblBlueInstancesFound64.Location = new Point(294, 170);
            lblBlueInstancesFound64.Name = "lblBlueInstancesFound64";
            lblBlueInstancesFound64.Size = new Size(208, 25);
            lblBlueInstancesFound64.TabIndex = 2;
            lblBlueInstancesFound64.Text = "lblBlueInstancesFound64";
            // 
            // lblBlueEmmulatorInstalled64
            // 
            lblBlueEmmulatorInstalled64.AutoSize = true;
            lblBlueEmmulatorInstalled64.Location = new Point(294, 123);
            lblBlueEmmulatorInstalled64.Name = "lblBlueEmmulatorInstalled64";
            lblBlueEmmulatorInstalled64.Size = new Size(237, 25);
            lblBlueEmmulatorInstalled64.TabIndex = 2;
            lblBlueEmmulatorInstalled64.Text = "lblBlueEmmulatorInstalled64";
            // 
            // lblBlueInstancesFound32
            // 
            lblBlueInstancesFound32.AutoSize = true;
            lblBlueInstancesFound32.Location = new Point(294, 85);
            lblBlueInstancesFound32.Name = "lblBlueInstancesFound32";
            lblBlueInstancesFound32.Size = new Size(208, 25);
            lblBlueInstancesFound32.TabIndex = 2;
            lblBlueInstancesFound32.Text = "lblBlueInstancesFound32";
            // 
            // label81
            // 
            label81.AutoSize = true;
            label81.Location = new Point(14, 170);
            label81.Margin = new Padding(6, 0, 6, 0);
            label81.Name = "label81";
            label81.Size = new Size(279, 25);
            label81.TabIndex = 1;
            label81.Text = "Emmulator Instances Found 64bit";
            // 
            // lblBlueEmmulatorInstalled32
            // 
            lblBlueEmmulatorInstalled32.AutoSize = true;
            lblBlueEmmulatorInstalled32.Location = new Point(294, 37);
            lblBlueEmmulatorInstalled32.Name = "lblBlueEmmulatorInstalled32";
            lblBlueEmmulatorInstalled32.Size = new Size(237, 25);
            lblBlueEmmulatorInstalled32.TabIndex = 2;
            lblBlueEmmulatorInstalled32.Text = "lblBlueEmmulatorInstalled32";
            // 
            // label80
            // 
            label80.AutoSize = true;
            label80.Location = new Point(14, 127);
            label80.Margin = new Padding(6, 0, 6, 0);
            label80.Name = "label80";
            label80.Size = new Size(216, 25);
            label80.TabIndex = 0;
            label80.Text = "Emmulator Installed 64bit";
            // 
            // label68
            // 
            label68.AutoSize = true;
            label68.Location = new Point(14, 85);
            label68.Margin = new Padding(6, 0, 6, 0);
            label68.Name = "label68";
            label68.Size = new Size(279, 25);
            label68.TabIndex = 1;
            label68.Text = "Emmulator Instances Found 32bit";
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Location = new Point(14, 40);
            label65.Margin = new Padding(6, 0, 6, 0);
            label65.Name = "label65";
            label65.Size = new Size(216, 25);
            label65.TabIndex = 0;
            label65.Text = "Emmulator Installed 32bit";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblEmmulatorInstancesFound);
            groupBox3.Controls.Add(lblEmmulatorInstalled);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Location = new Point(11, 48);
            groupBox3.Margin = new Padding(6, 5, 6, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(6, 5, 6, 5);
            groupBox3.Size = new Size(647, 133);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Nox Check List - Not Required";
            // 
            // lblEmmulatorInstancesFound
            // 
            lblEmmulatorInstancesFound.AutoSize = true;
            lblEmmulatorInstancesFound.Location = new Point(254, 83);
            lblEmmulatorInstancesFound.Margin = new Padding(6, 0, 6, 0);
            lblEmmulatorInstancesFound.Name = "lblEmmulatorInstancesFound";
            lblEmmulatorInstancesFound.Size = new Size(242, 25);
            lblEmmulatorInstancesFound.TabIndex = 3;
            lblEmmulatorInstancesFound.Text = "lblEmmulatorInstancesFound";
            // 
            // lblEmmulatorInstalled
            // 
            lblEmmulatorInstalled.AutoSize = true;
            lblEmmulatorInstalled.Location = new Point(254, 38);
            lblEmmulatorInstalled.Margin = new Padding(6, 0, 6, 0);
            lblEmmulatorInstalled.Name = "lblEmmulatorInstalled";
            lblEmmulatorInstalled.Size = new Size(184, 25);
            lblEmmulatorInstalled.TabIndex = 2;
            lblEmmulatorInstalled.Text = "lblEmmulatorInstalled";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 83);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(233, 25);
            label6.TabIndex = 1;
            label6.Text = "Emmulator Instances Found";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 38);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(170, 25);
            label5.TabIndex = 0;
            label5.Text = "Emmulator Installed";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F);
            label4.Location = new Point(7, 8);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(134, 29);
            label4.TabIndex = 0;
            label4.Text = "Workspace";
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Fill;
            txtLog.Location = new Point(0, 0);
            txtLog.Margin = new Padding(6, 5, 6, 5);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(2670, 147);
            txtLog.TabIndex = 1;
            txtLog.Text = "";
            // 
            // mnuPopupGames
            // 
            mnuPopupGames.ImageScalingSize = new Size(24, 24);
            mnuPopupGames.Items.AddRange(new ToolStripItem[] { mnuGamesAddNewGame, mnuGamesLoadApp });
            mnuPopupGames.Name = "mnuPopupGames";
            mnuPopupGames.Size = new Size(210, 68);
            // 
            // mnuGamesAddNewGame
            // 
            mnuGamesAddNewGame.Name = "mnuGamesAddNewGame";
            mnuGamesAddNewGame.Size = new Size(209, 32);
            mnuGamesAddNewGame.Text = "Add New Game";
            // 
            // mnuGamesLoadApp
            // 
            mnuGamesLoadApp.Name = "mnuGamesLoadApp";
            mnuGamesLoadApp.Size = new Size(209, 32);
            mnuGamesLoadApp.Text = "Load App";
            // 
            // mnuEvents
            // 
            mnuEvents.ImageScalingSize = new Size(24, 24);
            mnuEvents.Items.AddRange(new ToolStripItem[] { mnuAddEvent, mnuAddAction, toolStripSeparator6, toolStripMenuCut, toolStripMenuCopy, toolStripMenuPaste, toolStripSeparatorCutCopyPaste, testToolStripMenuItem, mnuTestAllEvents, toolStripSeparator7, mnuAddRNG, mnuAddRNGNode, toolStripSeparator12, advancedToolStripMenuItem });
            mnuEvents.Name = "mnuEvents";
            mnuEvents.Size = new Size(321, 348);
            // 
            // mnuAddEvent
            // 
            mnuAddEvent.Image = Properties.Resources.AddEvent;
            mnuAddEvent.Name = "mnuAddEvent";
            mnuAddEvent.Size = new Size(320, 32);
            mnuAddEvent.Text = "Add Event";
            mnuAddEvent.Click += mnuAddEvent_Click;
            // 
            // mnuAddAction
            // 
            mnuAddAction.Image = Properties.Resources.AddActionP;
            mnuAddAction.Name = "mnuAddAction";
            mnuAddAction.Size = new Size(320, 32);
            mnuAddAction.Text = "Add Action";
            mnuAddAction.Click += mnuAddAction_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(317, 6);
            // 
            // toolStripMenuCut
            // 
            toolStripMenuCut.Image = Properties.Resources.Cut_16x;
            toolStripMenuCut.Name = "toolStripMenuCut";
            toolStripMenuCut.Size = new Size(320, 32);
            toolStripMenuCut.Text = "Cut";
            toolStripMenuCut.Click += toolStripMenuCut_Click;
            // 
            // toolStripMenuCopy
            // 
            toolStripMenuCopy.Image = Properties.Resources.ASX_Copy_blue_16x;
            toolStripMenuCopy.Name = "toolStripMenuCopy";
            toolStripMenuCopy.Size = new Size(320, 32);
            toolStripMenuCopy.Text = "Copy";
            toolStripMenuCopy.Click += toolStripMenuCopy_Click;
            // 
            // toolStripMenuPaste
            // 
            toolStripMenuPaste.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuPasteChild, toolStripMenuPasteSibling, toolStripMenuPasteSiblingBelow });
            toolStripMenuPaste.Image = Properties.Resources.ASX_Paste_blue_16x;
            toolStripMenuPaste.Name = "toolStripMenuPaste";
            toolStripMenuPaste.Size = new Size(320, 32);
            toolStripMenuPaste.Text = "Paste";
            // 
            // toolStripMenuPasteChild
            // 
            toolStripMenuPasteChild.Image = Properties.Resources.BranchRelationshipChild_16x;
            toolStripMenuPasteChild.Name = "toolStripMenuPasteChild";
            toolStripMenuPasteChild.Size = new Size(235, 34);
            toolStripMenuPasteChild.Text = "Child (Under)";
            toolStripMenuPasteChild.Click += toolStripMenuPasteChild_Click;
            // 
            // toolStripMenuPasteSibling
            // 
            toolStripMenuPasteSibling.Image = Properties.Resources.BranchRelationshipSibling_16x_reverse;
            toolStripMenuPasteSibling.Name = "toolStripMenuPasteSibling";
            toolStripMenuPasteSibling.Size = new Size(235, 34);
            toolStripMenuPasteSibling.Text = "Sibling (Above)";
            toolStripMenuPasteSibling.Click += toolStripMenuPasteSibling_Click;
            // 
            // toolStripMenuPasteSiblingBelow
            // 
            toolStripMenuPasteSiblingBelow.Image = Properties.Resources.BranchRelationshipSibling_16x;
            toolStripMenuPasteSiblingBelow.Name = "toolStripMenuPasteSiblingBelow";
            toolStripMenuPasteSiblingBelow.Size = new Size(235, 34);
            toolStripMenuPasteSiblingBelow.Text = "Sibling (Below)";
            toolStripMenuPasteSiblingBelow.Click += toolStripMenuPasteSiblingBelow_Click;
            // 
            // toolStripSeparatorCutCopyPaste
            // 
            toolStripSeparatorCutCopyPaste.Name = "toolStripSeparatorCutCopyPaste";
            toolStripSeparatorCutCopyPaste.Size = new Size(317, 6);
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Image = Properties.Resources.Test;
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(320, 32);
            testToolStripMenuItem.Text = "Test";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // mnuTestAllEvents
            // 
            mnuTestAllEvents.Image = Properties.Resources.TestALLP;
            mnuTestAllEvents.Name = "mnuTestAllEvents";
            mnuTestAllEvents.Size = new Size(320, 32);
            mnuTestAllEvents.Text = "Test All";
            mnuTestAllEvents.Click += mnuTestAllEvents_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(317, 6);
            // 
            // mnuAddRNG
            // 
            mnuAddRNG.Image = Properties.Resources.AddRNGContainerP;
            mnuAddRNG.Name = "mnuAddRNG";
            mnuAddRNG.Size = new Size(320, 32);
            mnuAddRNG.Text = "Add Random Number (RNG)";
            mnuAddRNG.Click += mnuAddRNG_Click;
            // 
            // mnuAddRNGNode
            // 
            mnuAddRNGNode.Image = Properties.Resources.AddRNGP;
            mnuAddRNGNode.Name = "mnuAddRNGNode";
            mnuAddRNGNode.Size = new Size(320, 32);
            mnuAddRNGNode.Text = "Add RNG Node";
            mnuAddRNGNode.Click += mnuAddRNGNode_Click;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new Size(317, 6);
            // 
            // advancedToolStripMenuItem
            // 
            advancedToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { moveToolStripMenuItem, deleteToolStripMenuItem });
            advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            advancedToolStripMenuItem.Size = new Size(320, 32);
            advancedToolStripMenuItem.Text = "Advanced";
            // 
            // moveToolStripMenuItem
            // 
            moveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { upToolStripMenuItem, downToolStripMenuItem });
            moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            moveToolStripMenuItem.Size = new Size(164, 34);
            moveToolStripMenuItem.Text = "Move";
            // 
            // upToolStripMenuItem
            // 
            upToolStripMenuItem.Name = "upToolStripMenuItem";
            upToolStripMenuItem.Size = new Size(161, 34);
            upToolStripMenuItem.Text = "Up";
            upToolStripMenuItem.Click += upToolStripMenuItem_Click;
            // 
            // downToolStripMenuItem
            // 
            downToolStripMenuItem.Name = "downToolStripMenuItem";
            downToolStripMenuItem.Size = new Size(161, 34);
            downToolStripMenuItem.Text = "Down";
            downToolStripMenuItem.Click += downToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(164, 34);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // mnuThreadList
            // 
            mnuThreadList.ImageScalingSize = new Size(24, 24);
            mnuThreadList.Items.AddRange(new ToolStripItem[] { mnuThreadExit });
            mnuThreadList.Name = "mnuThreadList";
            mnuThreadList.Size = new Size(181, 36);
            // 
            // mnuThreadExit
            // 
            mnuThreadExit.Name = "mnuThreadExit";
            mnuThreadExit.Size = new Size(180, 32);
            mnuThreadExit.Text = "Stop Thread";
            mnuThreadExit.Click += mnuThreadExit_Click;
            // 
            // mnuPopupGame
            // 
            mnuPopupGame.ImageScalingSize = new Size(24, 24);
            mnuPopupGame.Items.AddRange(new ToolStripItem[] { mnuLoadInstance, mnuLaunchAndLoad });
            mnuPopupGame.Name = "mnuPopupGame";
            mnuPopupGame.Size = new Size(408, 68);
            // 
            // mnuLoadInstance
            // 
            mnuLoadInstance.Name = "mnuLoadInstance";
            mnuLoadInstance.Size = new Size(407, 32);
            mnuLoadInstance.Text = "Run Script";
            // 
            // mnuLaunchAndLoad
            // 
            mnuLaunchAndLoad.Name = "mnuLaunchAndLoad";
            mnuLaunchAndLoad.Size = new Size(407, 32);
            mnuLaunchAndLoad.Text = "Start Emmulator + Run App + Run Script";
            // 
            // mnuObjects
            // 
            mnuObjects.AccessibleName = "NOT USING";
            mnuObjects.ImageScalingSize = new Size(24, 24);
            mnuObjects.Items.AddRange(new ToolStripItem[] { mnuAddObject });
            mnuObjects.Name = "mnuObjects";
            mnuObjects.Size = new Size(211, 36);
            // 
            // mnuAddObject
            // 
            mnuAddObject.Name = "mnuAddObject";
            mnuAddObject.Size = new Size(210, 32);
            mnuAddObject.Text = "Add Screenshot";
            mnuAddObject.Click += mnuAddObject_Click;
            // 
            // timerScheduler
            // 
            timerScheduler.Interval = 1000;
            timerScheduler.Tick += timerScheduler_Tick;
            // 
            // Timer1
            // 
            Timer1.Interval = 50;
            Timer1.Tick += Timer1_Tick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Zip Files|*.zip";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "zip";
            // 
            // dlgApplicationPicker
            // 
            dlgApplicationPicker.FileName = "*.exe";
            // 
            // button1
            // 
            button1.Location = new Point(228, 11);
            button1.Name = "button1";
            button1.Size = new Size(141, 23);
            button1.TabIndex = 14;
            button1.Text = "Make Object + Choose";
            button1.UseVisualStyleBackColor = true;
            button1.Click += cmdMakeObject_Click;
            // 
            // contextMenuStripResetResolution
            // 
            contextMenuStripResetResolution.ImageScalingSize = new Size(24, 24);
            contextMenuStripResetResolution.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripSeparator13, toolStripMenuItemResetResolution });
            contextMenuStripResetResolution.Name = "contextMenuStripResetResolution";
            contextMenuStripResetResolution.Size = new Size(301, 74);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(300, 32);
            toolStripMenuItem1.Text = "Modify window resolution?";
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new Size(297, 6);
            // 
            // toolStripMenuItemResetResolution
            // 
            toolStripMenuItemResetResolution.Name = "toolStripMenuItemResetResolution";
            toolStripMenuItemResetResolution.Size = new Size(300, 32);
            toolStripMenuItemResetResolution.Text = "Reset Resolution";
            toolStripMenuItemResetResolution.Click += toolStripMenuItemResetResolution_Click;
            // 
            // contextMenuStripRuntimeEnableDisable
            // 
            contextMenuStripRuntimeEnableDisable.ImageScalingSize = new Size(24, 24);
            contextMenuStripRuntimeEnableDisable.Items.AddRange(new ToolStripItem[] { toolStripMenuItemEnableDisableToggleLabel, toolStripSeparatorEnableDisableToggle, toolStripMenuItemRuntimeEnableDisableToggle });
            contextMenuStripRuntimeEnableDisable.Name = "contextMenuStripRuntimeEnableDisable";
            contextMenuStripRuntimeEnableDisable.Size = new Size(268, 74);
            // 
            // toolStripMenuItemEnableDisableToggleLabel
            // 
            toolStripMenuItemEnableDisableToggleLabel.Enabled = false;
            toolStripMenuItemEnableDisableToggleLabel.Name = "toolStripMenuItemEnableDisableToggleLabel";
            toolStripMenuItemEnableDisableToggleLabel.Size = new Size(267, 32);
            toolStripMenuItemEnableDisableToggleLabel.Text = "Enable/Disable Toggle?";
            // 
            // toolStripSeparatorEnableDisableToggle
            // 
            toolStripSeparatorEnableDisableToggle.Name = "toolStripSeparatorEnableDisableToggle";
            toolStripSeparatorEnableDisableToggle.Size = new Size(264, 6);
            // 
            // toolStripMenuItemRuntimeEnableDisableToggle
            // 
            toolStripMenuItemRuntimeEnableDisableToggle.Name = "toolStripMenuItemRuntimeEnableDisableToggle";
            toolStripMenuItemRuntimeEnableDisableToggle.Size = new Size(267, 32);
            toolStripMenuItemRuntimeEnableDisableToggle.Text = "Toggle";
            toolStripMenuItemRuntimeEnableDisableToggle.Click += toolStripMenuItemRuntimeEnableDisableToggle_Click;
            // 
            // TimerProperties
            // 
            TimerProperties.Enabled = true;
            TimerProperties.Interval = 1000;
            TimerProperties.Tick += TimerProperties_Tick;
            // 
            // appTestStudioToolStrip1
            // 
            appTestStudioToolStrip1.ImageScalingSize = new Size(24, 24);
            appTestStudioToolStrip1.Items.AddRange(new ToolStripItem[] { toolAddEvent, toolStripSeparator9, toolAddAction, toolStripSeparator10, toolTest, toolTestAll, toolStripSeparator11, toolAddRNG, toolAddRNGNode });
            appTestStudioToolStrip1.Location = new Point(0, 67);
            appTestStudioToolStrip1.Name = "appTestStudioToolStrip1";
            appTestStudioToolStrip1.Padding = new Padding(0, 0, 3, 0);
            appTestStudioToolStrip1.Size = new Size(2670, 34);
            appTestStudioToolStrip1.TabIndex = 5;
            appTestStudioToolStrip1.Text = "appTestStudioToolStrip1";
            // 
            // toolAddEvent
            // 
            toolAddEvent.Image = Properties.Resources.AddEvent;
            toolAddEvent.ImageTransparentColor = Color.Magenta;
            toolAddEvent.Name = "toolAddEvent";
            toolAddEvent.Size = new Size(122, 29);
            toolAddEvent.Text = "Add Event";
            toolAddEvent.Click += toolAddEvent_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(6, 34);
            // 
            // toolAddAction
            // 
            toolAddAction.Image = Properties.Resources.AddActionP;
            toolAddAction.ImageTransparentColor = Color.Magenta;
            toolAddAction.Name = "toolAddAction";
            toolAddAction.Size = new Size(130, 29);
            toolAddAction.Text = "Add Action";
            toolAddAction.Click += toolAddAction_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(6, 34);
            // 
            // toolTest
            // 
            toolTest.Image = Properties.Resources.Test;
            toolTest.ImageTransparentColor = Color.Magenta;
            toolTest.Name = "toolTest";
            toolTest.Size = new Size(70, 29);
            toolTest.Text = "Test";
            toolTest.Click += toolTest_Click;
            // 
            // toolTestAll
            // 
            toolTestAll.Image = Properties.Resources.TestALLP;
            toolTestAll.ImageTransparentColor = Color.Magenta;
            toolTestAll.Name = "toolTestAll";
            toolTestAll.Size = new Size(95, 29);
            toolTestAll.Text = "Test All";
            toolTestAll.Click += toolTestAll_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(6, 34);
            // 
            // toolAddRNG
            // 
            toolAddRNG.Image = Properties.Resources.AddRNGContainerP;
            toolAddRNG.ImageTransparentColor = Color.Magenta;
            toolAddRNG.Name = "toolAddRNG";
            toolAddRNG.Size = new Size(115, 29);
            toolAddRNG.Text = "Add RNG";
            toolAddRNG.Click += toolAddRNG_Click;
            // 
            // toolAddRNGNode
            // 
            toolAddRNGNode.Image = Properties.Resources.AddRNGP;
            toolAddRNGNode.ImageTransparentColor = Color.Magenta;
            toolAddRNGNode.Name = "toolAddRNGNode";
            toolAddRNGNode.Size = new Size(164, 29);
            toolAddRNGNode.Text = "Add RNG Node";
            toolAddRNGNode.Click += toolAddRNGNode_Click;
            // 
            // toolStripMain
            // 
            toolStripMain.ImageScalingSize = new Size(24, 24);
            toolStripMain.Items.AddRange(new ToolStripItem[] { toolStripLoadScript, toolStripButtonSaveScript, toolStripSeparator3, toolStripButtonRunScript, toolStripButtonRunStartLaunch, toolStripButtonStartEmmulatorLaunchApp, toolStripButtonStartEmmulator, toolStripSeparator4, toolStripButtonToggleScript, toolStripSeparator5, toolSchedulerRunning, toolStripSeparator8, toolStripCurrentDesignInstance, toolStripInstances, mnuMouseRecording, toolStripButtonTest1 });
            toolStripMain.Location = new Point(0, 33);
            toolStripMain.Name = "toolStripMain";
            toolStripMain.Padding = new Padding(0, 0, 3, 0);
            toolStripMain.Size = new Size(2670, 34);
            toolStripMain.TabIndex = 1;
            toolStripMain.Text = "toolStripMain";
            // 
            // toolStripLoadScript
            // 
            toolStripLoadScript.Image = Properties.Resources.UploadFile_16x_24;
            toolStripLoadScript.ImageTransparentColor = Color.Magenta;
            toolStripLoadScript.Name = "toolStripLoadScript";
            toolStripLoadScript.Size = new Size(129, 29);
            toolStripLoadScript.Text = "Load Script";
            toolStripLoadScript.Click += toolStripLoadScript_Click;
            // 
            // toolStripButtonSaveScript
            // 
            toolStripButtonSaveScript.Image = Properties.Resources.Save_16x_24;
            toolStripButtonSaveScript.ImageTransparentColor = Color.Magenta;
            toolStripButtonSaveScript.Name = "toolStripButtonSaveScript";
            toolStripButtonSaveScript.Size = new Size(127, 29);
            toolStripButtonSaveScript.Text = "Save Script";
            toolStripButtonSaveScript.Click += toolStripButtonSaveScript_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 34);
            // 
            // toolStripButtonRunScript
            // 
            toolStripButtonRunScript.Image = Properties.Resources.UploadFile_16x_24;
            toolStripButtonRunScript.ImageTransparentColor = Color.Magenta;
            toolStripButtonRunScript.Name = "toolStripButtonRunScript";
            toolStripButtonRunScript.Size = new Size(71, 29);
            toolStripButtonRunScript.Text = "Run";
            toolStripButtonRunScript.ToolTipText = "Run Script";
            toolStripButtonRunScript.Click += toolStripButtonRunScript_Click;
            // 
            // toolStripButtonRunStartLaunch
            // 
            toolStripButtonRunStartLaunch.Image = Properties.Resources.ImportCatalogPart_16x_24;
            toolStripButtonRunStartLaunch.ImageTransparentColor = Color.Magenta;
            toolStripButtonRunStartLaunch.Name = "toolStripButtonRunStartLaunch";
            toolStripButtonRunStartLaunch.Size = new Size(206, 29);
            toolStripButtonRunStartLaunch.Text = "Run + Start + Launch";
            toolStripButtonRunStartLaunch.ToolTipText = "Run Script + Start Emmulator + Launch App - Requires Nox/BlueStacks and a Package Name to be entered.";
            toolStripButtonRunStartLaunch.Click += toolStripButtonRunStartLaunch_Click;
            // 
            // toolStripButtonStartEmmulatorLaunchApp
            // 
            toolStripButtonStartEmmulatorLaunchApp.Image = Properties.Resources.ImportCatalogPart_16x_24;
            toolStripButtonStartEmmulatorLaunchApp.ImageTransparentColor = Color.Magenta;
            toolStripButtonStartEmmulatorLaunchApp.Name = "toolStripButtonStartEmmulatorLaunchApp";
            toolStripButtonStartEmmulatorLaunchApp.Size = new Size(153, 29);
            toolStripButtonStartEmmulatorLaunchApp.Text = "Start + Launch";
            toolStripButtonStartEmmulatorLaunchApp.ToolTipText = "Start Emmulator + Launch App - Requires Nox/BlueStacks and a Package Name to be entered.";
            toolStripButtonStartEmmulatorLaunchApp.Click += toolStripButtonStartEmmulatorLaunchApp_Click;
            // 
            // toolStripButtonStartEmmulator
            // 
            toolStripButtonStartEmmulator.Image = Properties.Resources.StartEmmulator;
            toolStripButtonStartEmmulator.ImageTransparentColor = Color.Magenta;
            toolStripButtonStartEmmulator.Name = "toolStripButtonStartEmmulator";
            toolStripButtonStartEmmulator.Size = new Size(76, 29);
            toolStripButtonStartEmmulator.Text = "Start";
            toolStripButtonStartEmmulator.ToolTipText = "Start Emmulator";
            toolStripButtonStartEmmulator.Click += toolStripButtonStartEmmulator_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 34);
            // 
            // toolStripButtonToggleScript
            // 
            toolStripButtonToggleScript.Enabled = false;
            toolStripButtonToggleScript.Image = Properties.Resources.Pause_64x_64;
            toolStripButtonToggleScript.ImageTransparentColor = Color.Magenta;
            toolStripButtonToggleScript.Name = "toolStripButtonToggleScript";
            toolStripButtonToggleScript.Size = new Size(135, 29);
            toolStripButtonToggleScript.Text = "Pause Script";
            toolStripButtonToggleScript.Click += toolStripButtonToggleScript_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 34);
            // 
            // toolSchedulerRunning
            // 
            toolSchedulerRunning.Name = "toolSchedulerRunning";
            toolSchedulerRunning.Size = new Size(150, 29);
            toolSchedulerRunning.Text = "Scheduler Paused";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 34);
            // 
            // toolStripCurrentDesignInstance
            // 
            toolStripCurrentDesignInstance.Name = "toolStripCurrentDesignInstance";
            toolStripCurrentDesignInstance.Size = new Size(200, 29);
            toolStripCurrentDesignInstance.Text = "Current Design Instance";
            toolStripCurrentDesignInstance.Visible = false;
            // 
            // toolStripInstances
            // 
            toolStripInstances.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripInstances.Image = (Image)resources.GetObject("toolStripInstances.Image");
            toolStripInstances.ImageTransparentColor = Color.Magenta;
            toolStripInstances.Name = "toolStripInstances";
            toolStripInstances.Size = new Size(111, 29);
            toolStripInstances.Text = "Instance #";
            toolStripInstances.Visible = false;
            // 
            // mnuMouseRecording
            // 
            mnuMouseRecording.DisplayStyle = ToolStripItemDisplayStyle.Text;
            mnuMouseRecording.Image = (Image)resources.GetObject("mnuMouseRecording.Image");
            mnuMouseRecording.ImageTransparentColor = Color.Magenta;
            mnuMouseRecording.Name = "mnuMouseRecording";
            mnuMouseRecording.Size = new Size(150, 29);
            mnuMouseRecording.Text = "MouseRecording";
            mnuMouseRecording.Click += mnuMouseRecording_Click;
            // 
            // toolStripButtonTest1
            // 
            toolStripButtonTest1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonTest1.Image = (Image)resources.GetObject("toolStripButtonTest1.Image");
            toolStripButtonTest1.ImageTransparentColor = Color.Magenta;
            toolStripButtonTest1.Name = "toolStripButtonTest1";
            toolStripButtonTest1.Size = new Size(61, 29);
            toolStripButtonTest1.Text = "Test 1";
            toolStripButtonTest1.Click += toolStripButtonTest1_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2670, 1738);
            Controls.Add(splitContainerMain);
            Controls.Add(appTestStudioToolStrip1);
            Controls.Add(toolStripMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6, 5, 6, 5);
            Name = "frmMain";
            Text = "App Test Studio";
            FormClosing += frmMain_FormClosing;
            FormClosed += frmMain_FormClosed;
            Load += frmMain_Load;
            Resize += frmMain_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainerWorkspace.Panel1.ResumeLayout(false);
            splitContainerWorkspace.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerWorkspace).EndInit();
            splitContainerWorkspace.ResumeLayout(false);
            tabTree.ResumeLayout(false);
            tabDesign.ResumeLayout(false);
            tableLayoutPanelDesign.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabRun.ResumeLayout(false);
            splitContainerRunTab.Panel1.ResumeLayout(false);
            splitContainerRunTab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerRunTab).EndInit();
            splitContainerRunTab.ResumeLayout(false);
            splitContainerRunTabThread.Panel1.ResumeLayout(false);
            splitContainerRunTabThread.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerRunTabThread).EndInit();
            splitContainerRunTabThread.ResumeLayout(false);
            splitContainerRunProperties.Panel1.ResumeLayout(false);
            splitContainerRunProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerRunProperties).EndInit();
            splitContainerRunProperties.ResumeLayout(false);
            tableLayoutPanelRunLabels.ResumeLayout(false);
            tableLayoutPanelRunLabels.PerformLayout();
            tableLayoutPanelRunValues.ResumeLayout(false);
            tableLayoutPanelRunValues.PerformLayout();
            PanelThread.ResumeLayout(false);
            splitContainerThreadMain.Panel1.ResumeLayout(false);
            splitContainerThreadMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerThreadMain).EndInit();
            splitContainerThreadMain.ResumeLayout(false);
            splitContainerThread.Panel1.ResumeLayout(false);
            splitContainerThread.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerThread).EndInit();
            splitContainerThread.ResumeLayout(false);
            splitContainerStatsNScrollie.Panel1.ResumeLayout(false);
            splitContainerStatsNScrollie.Panel1.PerformLayout();
            splitContainerStatsNScrollie.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerStatsNScrollie).EndInit();
            splitContainerStatsNScrollie.ResumeLayout(false);
            tableLayoutStats.ResumeLayout(false);
            groupTotal.ResumeLayout(false);
            groupTotal.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupSession.ResumeLayout(false);
            groupSession.PerformLayout();
            tableLayoutPanelSession.ResumeLayout(false);
            tableLayoutPanelSession.PerformLayout();
            grpCPU.ResumeLayout(false);
            grpAPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerSeconds).EndInit();
            splitContainerSeconds.ResumeLayout(false);
            PanelColorEvent.ResumeLayout(false);
            tableColorEvent.ResumeLayout(false);
            panelColorEventChild1.ResumeLayout(false);
            panelColorEventChild1.PerformLayout();
            grpEventMode.ResumeLayout(false);
            grpEventMode.PerformLayout();
            grpMode.ResumeLayout(false);
            grpMode.PerformLayout();
            PanelScreenshot.ResumeLayout(false);
            PanelScreenshot.PerformLayout();
            panelKeyboard.ResumeLayout(false);
            panelKeyboard.PerformLayout();
            grpInsertWeights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericWait3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericWait2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericWait1).EndInit();
            groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            FlowLayoutPanelColorEvent1.ResumeLayout(false);
            panelRightProperties.ResumeLayout(false);
            panelRightProperties.PerformLayout();
            grpPropertiesRepeatsUntilFalse.ResumeLayout(false);
            grpPropertiesRepeatsUntilFalse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericPropertiesRepeatsUntilFalse).EndInit();
            panelPreAction.ResumeLayout(false);
            groupBox22.ResumeLayout(false);
            groupBox22.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericKeyboardAfterSendingActivationMS).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericKeyboardTimeoutToActivateMS).EndInit();
            panelRightAfterCompletion.ResumeLayout(false);
            panelRightAfterCompletion.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            panelRightObject.ResumeLayout(false);
            panelRightObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericObjectThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxEventObjectSelection).EndInit();
            panelRightSwipeProperties.ResumeLayout(false);
            panelRightSwipeProperties.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericSwipeEndWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSwipeEndHeight).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericSwipeStartWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSwipeStartHeight).EndInit();
            groupBoxClickDragReleaseObjectSearch.ResumeLayout(false);
            groupBoxClickDragReleaseObjectSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericSwipeVelocity).EndInit();
            panelRightClickProperties.ResumeLayout(false);
            panelRightClickProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericClickSpeed).EndInit();
            panelRightLogic.ResumeLayout(false);
            panelRightLogic.PerformLayout();
            panelRightCustomLogic.ResumeLayout(false);
            panelRightCustomLogic.PerformLayout();
            panelRightPointGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panelRightInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxInformationWarning).EndInit();
            FlowLayoutPanelColorEvent2.ResumeLayout(false);
            panelRightColorAtPointer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            PanelSelectedColor.ResumeLayout(false);
            PanelSelectedColor.PerformLayout();
            panelRightLimit.ResumeLayout(false);
            panelRightLimit.PerformLayout();
            GroupBox7.ResumeLayout(false);
            GroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIterations).EndInit();
            panelRightAnchor.ResumeLayout(false);
            panelRightOffset.ResumeLayout(false);
            panelRightOffset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericYOffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericXOffset).EndInit();
            panelRightDragMode.ResumeLayout(false);
            PanelGame.ResumeLayout(false);
            PanelGame.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            groupBox18.ResumeLayout(false);
            groupBox18.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericApplicationDefaultClickSpeed).EndInit();
            groupBox16.ResumeLayout(false);
            groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericMouseSpeedPixelsPerSecond).EndInit();
            groupBox17.ResumeLayout(false);
            groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericMouseSpeedVelocityVariantPercentMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMouseSpeedVelocityVariantPercentMax).EndInit();
            grpActiveMouseSettings.ResumeLayout(false);
            grpActiveMouseSettings.PerformLayout();
            grpApplication.ResumeLayout(false);
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            grpNox.ResumeLayout(false);
            grpNox.PerformLayout();
            grpSteam.ResumeLayout(false);
            groupBox14.ResumeLayout(false);
            groupBox14.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            grpBlue.ResumeLayout(false);
            grpBlue.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            grpVideo.ResumeLayout(false);
            grpVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericVideoFrameLimit).EndInit();
            PanelObject.ResumeLayout(false);
            PanelObject.PerformLayout();
            Panel5.ResumeLayout(false);
            Panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxObject).EndInit();
            PanelTestAllEvents.ResumeLayout(false);
            SplitContainer6.Panel1.ResumeLayout(false);
            SplitContainer6.Panel2.ResumeLayout(false);
            SplitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer6).EndInit();
            SplitContainer6.ResumeLayout(false);
            SplitContainer7.Panel1.ResumeLayout(false);
            SplitContainer7.Panel1.PerformLayout();
            SplitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer7).EndInit();
            SplitContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTest).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTestAllReference).EndInit();
            Panel2.ResumeLayout(false);
            Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureTestAllTest).EndInit();
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureTestAllReference).EndInit();
            PanelGames.ResumeLayout(false);
            PanelGames.PerformLayout();
            PanelActions.ResumeLayout(false);
            PanelActions.PerformLayout();
            PanelObjectScreenshot.ResumeLayout(false);
            PanelObjectScreenshot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureCreateNewObjectNamedCheckBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureCreateNewObjectMaskDrawnCheckBox).EndInit();
            panelObjectScreenshotColor.ResumeLayout(false);
            panelObjectScreenshotColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureObjectScreenshotZoomBox).EndInit();
            Panel4.ResumeLayout(false);
            Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureObjectScreenshot).EndInit();
            PanelAddNewGames.ResumeLayout(false);
            PanelAddNewGames.PerformLayout();
            PanelObjects.ResumeLayout(false);
            PanelObjects.PerformLayout();
            PanelEvents.ResumeLayout(false);
            PanelEvents.PerformLayout();
            PanelSchedule.ResumeLayout(false);
            PanelSchedule.PerformLayout();
            splitContainerSchedule.Panel1.ResumeLayout(false);
            splitContainerSchedule.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerSchedule).EndInit();
            splitContainerSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgSchedule).EndInit();
            splitContainerRuntimeSchedule.Panel1.ResumeLayout(false);
            splitContainerRuntimeSchedule.Panel1.PerformLayout();
            splitContainerRuntimeSchedule.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerRuntimeSchedule).EndInit();
            splitContainerRuntimeSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgRuntimeSchedule).EndInit();
            PanelWorkspace.ResumeLayout(false);
            PanelWorkspace.PerformLayout();
            groupBox15.ResumeLayout(false);
            groupBox15.PerformLayout();
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            mnuPopupGames.ResumeLayout(false);
            mnuEvents.ResumeLayout(false);
            mnuThreadList.ResumeLayout(false);
            mnuPopupGame.ResumeLayout(false);
            mnuObjects.ResumeLayout(false);
            contextMenuStripResetResolution.ResumeLayout(false);
            contextMenuStripRuntimeEnableDisable.ResumeLayout(false);
            appTestStudioToolStrip1.ResumeLayout(false);
            appTestStudioToolStrip1.PerformLayout();
            toolStripMain.ResumeLayout(false);
            toolStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private AppTestStudioControls.AppTestStudioToolStrip toolStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerWorkspace;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimalExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripLoadScript;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRunScript;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartEmmulatorLaunchApp;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartEmmulator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonToggleScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolSchedulerRunning;
        private System.Windows.Forms.TabControl tabTree;
        private System.Windows.Forms.TabPage tabDesign;
        private System.Windows.Forms.TabPage tabRun;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Panel PanelThread;
        private System.Windows.Forms.Panel PanelWorkspace;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblEmmulatorInstancesFound;
        private System.Windows.Forms.Label lblEmmulatorInstalled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PanelEvents;
        private System.Windows.Forms.Label lblEventsPanelTargetWindow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Panel PanelObjectScreenshot;
        internal System.Windows.Forms.Label Label53;
        internal System.Windows.Forms.Button cmdMakeObject;
        internal System.Windows.Forms.Panel panelObjectScreenshotColor;
        internal System.Windows.Forms.Label lblObjectScreenshotColorXY;
        internal System.Windows.Forms.Label lblObjectScreenshotRHSXY;
        internal System.Windows.Forms.PictureBox PictureObjectScreenshotZoomBox;
        internal System.Windows.Forms.TextBox txtObjectScreenshotName;
        internal System.Windows.Forms.Label Label45;
        internal System.Windows.Forms.Button cmdObjectScreenshotsTakeAScreenshot;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.PictureBox PictureObjectScreenshot;
        internal System.Windows.Forms.Label Label44;
        internal System.Windows.Forms.Panel PanelColorEvent;
        internal System.Windows.Forms.Button cmdAddObject2;
        internal System.Windows.Forms.NumericUpDown NumericXOffset;
        internal System.Windows.Forms.Label Label48;
        internal System.Windows.Forms.NumericUpDown NumericYOffset;
        internal System.Windows.Forms.Label lblXOffsetRange;
        internal System.Windows.Forms.Label Label49;
        internal System.Windows.Forms.Label lblYOffsetRange;
        internal System.Windows.Forms.NumericUpDown NumericObjectThreshold;
        internal System.Windows.Forms.Label Label52;
        internal System.Windows.Forms.Button cmdMaxMask;
        internal System.Windows.Forms.Label lblMaskSize;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.Label Label50;
        internal System.Windows.Forms.ComboBox cboChannel;
        internal System.Windows.Forms.PictureBox PictureBoxEventObjectSelection;
        internal System.Windows.Forms.ComboBox cboObject;
        internal System.Windows.Forms.Label lblColorChannel;
        internal System.Windows.Forms.Label lblSearchObject;
        internal System.Windows.Forms.GroupBox grpEventMode;
        internal System.Windows.Forms.RadioButton rdoObjectSearch;
        internal System.Windows.Forms.RadioButton rdoColorPoint;
        internal System.Windows.Forms.Panel PanelScreenshot;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Button cmdTest;
        internal System.Windows.Forms.GroupBox grpMode;
        internal System.Windows.Forms.RadioButton rdoModeClickDragRelease;
        internal System.Windows.Forms.RadioButton rdoModeRangeClick;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.CheckBox chkLimitRepeats;
        internal System.Windows.Forms.LinkLabel lnkLimitTime;
        internal System.Windows.Forms.NumericUpDown numIterations;
        internal System.Windows.Forms.Label lblLimitTimeLabel;
        internal System.Windows.Forms.Label lblLimitIterationsLabel;
        internal System.Windows.Forms.CheckBox chkWaitFirst;
        internal System.Windows.Forms.Label lblLimitWaitType;
        internal System.Windows.Forms.ComboBox cboWaitType;
        internal System.Windows.Forms.CheckBox chkUseLimit;
        internal System.Windows.Forms.RadioButton rdoAfterCompletionStop;
        internal System.Windows.Forms.GroupBox groupBox6;
        internal System.Windows.Forms.Label lblDelayCalc;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.ComboBox cboDelayH;
        internal System.Windows.Forms.ComboBox cboDelayM;
        internal System.Windows.Forms.ComboBox cboDelayS;
        internal System.Windows.Forms.Label label28;
        internal System.Windows.Forms.ComboBox cboDelayMS;
        internal System.Windows.Forms.RadioButton rdoAfterCompletionParent;
        internal System.Windows.Forms.RadioButton rdoAfterCompletionHome;
        internal System.Windows.Forms.RadioButton rdoAfterCompletionContinue;
        internal System.Windows.Forms.CheckBox chkUseParentScreenshot;
        internal System.Windows.Forms.Label lblMode;
        internal System.Windows.Forms.TextBox txtEventName;
        internal System.Windows.Forms.Label label29;
        internal System.Windows.Forms.Button cmdAddSingleColorAtSingleLocationTakeASceenshot;
        internal System.Windows.Forms.Panel PanelSelectedColor;
        internal System.Windows.Forms.Label lblRHSColor;
        internal System.Windows.Forms.Label lblRHSXY;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.ComboBox cboPoints;
        internal System.Windows.Forms.RadioButton rdoOR;
        internal System.Windows.Forms.RadioButton rdoAnd;
        internal System.Windows.Forms.DataGridView dgv;
        internal System.Windows.Forms.Panel PanelGame;
        internal System.Windows.Forms.Label lblGamePanelGameName;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Panel PanelSchedule;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.CheckBox chkEnableSchedule;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button cmdAddSchedule;
        internal System.Windows.Forms.DataGridView dgSchedule;
        internal System.Windows.Forms.Label label40;
        internal System.Windows.Forms.Panel PanelObject;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.PictureBox PictureBoxObject;
        internal System.Windows.Forms.TextBox txtObjectName;
        internal System.Windows.Forms.Label Label47;
        internal System.Windows.Forms.Label Label46;
        internal System.Windows.Forms.Panel PanelAddNewGames;
        private System.Windows.Forms.Label label39;
        internal System.Windows.Forms.TextBox txtAddNewGame;
        internal System.Windows.Forms.Label label38;
        internal System.Windows.Forms.Panel PanelTestAllEvents;
        internal System.Windows.Forms.SplitContainer SplitContainer6;
        internal System.Windows.Forms.SplitContainer SplitContainer7;
        internal System.Windows.Forms.Label label35;
        internal System.Windows.Forms.TreeView tvTestAllEvents;
        internal System.Windows.Forms.DataGridView dgvTestAllReference;
        private System.Windows.Forms.Panel PanelObjects;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label32;
        internal System.Windows.Forms.Panel PanelGames;
        internal System.Windows.Forms.Label label43;
        internal System.Windows.Forms.Panel PanelActions;
        internal System.Windows.Forms.Label label41;
        internal System.Windows.Forms.ContextMenuStrip mnuPopupGames;
        internal System.Windows.Forms.ToolStripMenuItem mnuGamesAddNewGame;
        internal System.Windows.Forms.ToolStripMenuItem mnuGamesLoadApp;
        internal System.Windows.Forms.ContextMenuStrip mnuEvents;
        internal System.Windows.Forms.ToolStripMenuItem mnuAddEvent;
        internal System.Windows.Forms.ToolStripMenuItem mnuAddAction;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal System.Windows.Forms.ToolStripMenuItem mnuAddRNG;
        internal System.Windows.Forms.ToolStripMenuItem mnuAddRNGNode;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        internal System.Windows.Forms.ToolStripMenuItem mnuTestAllEvents;
        internal System.Windows.Forms.ContextMenuStrip mnuThreadList;
        internal System.Windows.Forms.ToolStripMenuItem mnuThreadExit;
        internal System.Windows.Forms.ContextMenuStrip mnuPopupGame;
        internal System.Windows.Forms.ToolStripMenuItem mnuLoadInstance;
        internal System.Windows.Forms.ToolStripMenuItem mnuLaunchAndLoad;
        internal System.Windows.Forms.ContextMenuStrip mnuObjects;
        internal System.Windows.Forms.ToolStripMenuItem mnuAddObject;
        internal System.Windows.Forms.Timer timerScheduler;
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.ImageList ImageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel toolStripCurrentDesignInstance;
        private AppTestStudioControls.AppTestStudioToolStrip appTestStudioToolStrip1;
        private System.Windows.Forms.ToolStripButton toolAddEvent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolAddAction;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton toolTest;
        private System.Windows.Forms.ToolStripButton toolTestAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton toolAddRNG;
        private System.Windows.Forms.ToolStripButton toolAddRNGNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonRunStartLaunch;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        internal System.Windows.Forms.TextBox txtCustomLogic;
        private System.Windows.Forms.Button cmdValidate;
        internal System.Windows.Forms.RadioButton rdoCustom;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtObjectReferencedBy;
        private System.Windows.Forms.Button cmdDeleteObject;
        private System.Windows.Forms.Label lblReferenceWindowResolution;
        internal System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestGreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestBlue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvXTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvYTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPassFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgRange;
        private System.Windows.Forms.Label lblTestWindowResolution;
        internal System.Windows.Forms.PictureBox PictureTestAllTest;
        internal System.Windows.Forms.Label lblTestWindow;
        internal System.Windows.Forms.Label lblReference;
        internal System.Windows.Forms.PictureBox PictureTestAllReference;
        private System.Windows.Forms.Label lblTestAllCustom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTestAllReferenceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTestAllReferenceRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTestAllReferenceGreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTestAllReferenceBlue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTestAllReferenceX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTestAllReferenceY;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelColorEvent1;
        private System.Windows.Forms.Panel panelRightColorAtPointer;
        private System.Windows.Forms.Button cmdRightColorAtPointer;
        private System.Windows.Forms.Panel panelRightAfterCompletion;
        private System.Windows.Forms.Button cmdRightAfterCompletion;
        private System.Windows.Forms.Panel panelRightLimit;
        private System.Windows.Forms.Button cmdRightLimit;
        private System.Windows.Forms.Panel panelRightOffset;
        private System.Windows.Forms.Button cmdRightOffset;
        private System.Windows.Forms.Panel panelRightDragMode;
        private System.Windows.Forms.Button cmdRightDragMode;
        private System.Windows.Forms.Panel panelRightObject;
        private System.Windows.Forms.Button cmdRightObject;
        private System.Windows.Forms.Panel panelRightLogic;
        private System.Windows.Forms.Button cmdRightLogic;
        private System.Windows.Forms.Panel panelRightCustomLogic;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TableLayoutPanel tableColorEvent;
        private System.Windows.Forms.Panel panelColorEventChild1;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelColorEvent2;
        private System.Windows.Forms.Panel panelRightPointGrid;
        private System.Windows.Forms.Panel panelRightProperties;
        internal System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Button cmdPanelRightResolution;
        private System.Windows.Forms.Panel panelRightClickProperties;
        private System.Windows.Forms.Label label55;
        internal System.Windows.Forms.NumericUpDown NumericClickSpeed;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button cmdRightClickProperties;
        private System.Windows.Forms.Panel panelRightSwipeProperties;
        private System.Windows.Forms.Button cmdRightSwipeProperties;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label57;
        internal System.Windows.Forms.NumericUpDown numericSwipeEndWidth;
        internal System.Windows.Forms.NumericUpDown numericSwipeEndHeight;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label56;
        internal System.Windows.Forms.NumericUpDown numericSwipeStartWidth;
        internal System.Windows.Forms.NumericUpDown numericSwipeStartHeight;
        private System.Windows.Forms.GroupBox groupBoxClickDragReleaseObjectSearch;
        private System.Windows.Forms.RadioButton rdoObjectSearchNone;
        private System.Windows.Forms.RadioButton rdoObjectSearchEnd;
        private System.Windows.Forms.RadioButton rdoObjectSearchStart;
        internal System.Windows.Forms.NumericUpDown numericSwipeVelocity;
        private System.Windows.Forms.CheckBox chkPropertiesRepeatsUntilFalse;
        private System.Windows.Forms.Label lblPropertiesRepeatsUntilFalse;
        internal System.Windows.Forms.NumericUpDown numericPropertiesRepeatsUntilFalse;
        private System.Windows.Forms.CheckBox chkPropertiesEnabled;
        private System.Windows.Forms.GroupBox grpPropertiesRepeatsUntilFalse;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.RadioButton rdoAfterCompletionRecycle;
        private System.Windows.Forms.Panel panelRightAnchor;
        private System.Windows.Forms.Button cmdAnchorLeft;
        private System.Windows.Forms.Button cmdAnchorRight;
        private System.Windows.Forms.Button cmdAnchorBottom;
        private System.Windows.Forms.Button cmdAnchorTop;
        private System.Windows.Forms.Button cmdAnchorNone;
        private System.Windows.Forms.Button cmdRightAnchor;
        private System.Windows.Forms.Button cmdAnchorDefault;
        private System.Windows.Forms.ToolStripDropDownButton toolStripInstances;
        internal System.Windows.Forms.Button cmdTakeParentScreenshot;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBlue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvY;
        private System.Windows.Forms.DataGridViewButtonColumn dgvScan;
        private System.Windows.Forms.DataGridViewButtonColumn dgvRemove;
        private System.Windows.Forms.ComboBox cboPlatform;
        private System.Windows.Forms.GroupBox grpNox;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.ComboBox cboDPI;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.ComboBox cboGameInstances;
        internal System.Windows.Forms.ComboBox cboResolution;
        internal System.Windows.Forms.TextBox txtGamePanelLaunchInstance;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox txtPackageName;
        internal System.Windows.Forms.Label label63;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Label label62;
        private System.Windows.Forms.GroupBox grpSteam;
        private System.Windows.Forms.TextBox txtSteamID;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.GroupBox grpApplication;
        private System.Windows.Forms.Button cmdPathToExePicker;
        private System.Windows.Forms.TextBox txtPathToApplicationExe;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox txtSteamPrimaryWindowName;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtApplicationPrimaryWindowName;
        private System.Windows.Forms.OpenFileDialog dlgApplicationPicker;
        private System.Windows.Forms.TextBox txtApplicationParameters;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button cmdFlowLayoutPanelColorEvent1;
        private System.Windows.Forms.Button cmdFlowLayoutPanelColorEvent2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox cboSteamSecondaryWindowNameFilter;
        private System.Windows.Forms.TextBox txtSteamSecondaryWindowName;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.ComboBox cboSteamPrimaryWindowNameFilter;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox cboApplicationSecondaryWindowNameFilter;
        private System.Windows.Forms.TextBox txtApplicationSecondaryWindowName;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.ComboBox cboApplicationPrimaryWindowNameFilter;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Button cmdSteamWindowWizard;
        private System.Windows.Forms.Button cmdApplicationWindowWizard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox11;
        internal System.Windows.Forms.GroupBox grpVideo;
        internal System.Windows.Forms.Label lblFrameLimit;
        internal System.Windows.Forms.NumericUpDown NumericVideoFrameLimit;
        internal System.Windows.Forms.CheckBox chkSaveVideo;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.Button cmdStartEmmulatorAndPackage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label42;
        internal System.Windows.Forms.NumericUpDown numericApplicationDefaultClickSpeed;
        internal System.Windows.Forms.Button cmdStartEmmulatorPackageAndRunScript;
        internal System.Windows.Forms.Button cmdStartEmmulator;
        internal System.Windows.Forms.TextBox txtGamePanelLoopDelay;
        internal System.Windows.Forms.Label Label30;
        internal System.Windows.Forms.Button cmdRunScript;
        private System.Windows.Forms.Label lblPictureMissing;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button cmdMakeObjectAndUse;
        private System.Windows.Forms.PictureBox pictureCreateNewObjectMaskDrawnCheckBox;
        private System.Windows.Forms.PictureBox pictureCreateNewObjectNamedCheckBox;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label lblBlueInstancesFound32;
        private System.Windows.Forms.Label lblBlueEmmulatorInstalled32;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label lblBlueInstancesFound64;
        private System.Windows.Forms.Label lblBlueEmmulatorInstalled64;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.GroupBox grpBlue;
        internal System.Windows.Forms.Label label82;
        internal System.Windows.Forms.TextBox txtBluePackageName;
        private System.Windows.Forms.ComboBox cboBlueInstance;
        internal System.Windows.Forms.Label label83;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.ComboBox cboMouseMode;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.NumericUpDown numericMouseSpeedPixelsPerSecond;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.NumericUpDown numericMouseSpeedVelocityVariantPercentMin;
        private System.Windows.Forms.NumericUpDown numericMouseSpeedVelocityVariantPercentMax;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Label lblWindowNotVisibleAction;
        private System.Windows.Forms.ComboBox cboWindowAction;
        private System.Windows.Forms.CheckBox chkMoveMouseBeforeAction;
        private System.Windows.Forms.GroupBox grpActiveMouseSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDesign;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Panel panelRightInformation;
        private System.Windows.Forms.Button cmdRightInformation;
        private System.Windows.Forms.PictureBox pictureBoxInformationWarning;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.TreeView tvRun;
        private System.Windows.Forms.SplitContainer splitContainerRunTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRunValues;
        private System.Windows.Forms.Label lblRunLabel1;
        private System.Windows.Forms.Label lblRunLabel2;
        private System.Windows.Forms.Label lblRunValue1;
        private System.Windows.Forms.Label lblRunValue2;
        private System.Windows.Forms.Label lblRunLabel3;
        private System.Windows.Forms.Label lblRunValue3;
        private System.Windows.Forms.Label lblRunLabel4;
        private System.Windows.Forms.Label lblRunValue4;
        private System.Windows.Forms.Label lblRunLabel5;
        private System.Windows.Forms.Label lblRunValue5;
        private System.Windows.Forms.Label lblRunLabel6;
        private System.Windows.Forms.Label lblRunValue6;
        private System.Windows.Forms.SplitContainer splitContainerRunProperties;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRunLabels;
        private System.Windows.Forms.Label lblRunLabel12;
        private System.Windows.Forms.Label lblRunLabel13;
        private System.Windows.Forms.Label lblRunLabel14;
        private System.Windows.Forms.Label lblRunValue13;
        private System.Windows.Forms.Label lblRunValue12;
        private System.Windows.Forms.Label lblRunValue11;
        private System.Windows.Forms.Label lblRunLabel7;
        private System.Windows.Forms.Label lblRunValue7;
        private System.Windows.Forms.Label lblRunValue8;
        private System.Windows.Forms.Label lblRunLabel8;
        private System.Windows.Forms.Label lblRunValue9;
        private System.Windows.Forms.Label lblRunValue10;
        private System.Windows.Forms.Label lblRunLabel11;
        private System.Windows.Forms.Label lblRunLabel10;
        private System.Windows.Forms.Label lblRunLabel9;
        private System.Windows.Forms.Label lblRunValue14;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripResetResolution;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResetResolution;
        private System.Windows.Forms.Button cmdUpdateResolution;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.Button cmdRuntimeEnableToggle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRuntimeEnableDisable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableDisableToggleLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorEnableDisableToggle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRuntimeEnableDisableToggle;
        private System.Windows.Forms.Timer TimerProperties;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAppTestStudioToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboThreads;
        private System.Windows.Forms.SplitContainer splitContainerRunTabThread;
        private System.Windows.Forms.SplitContainer splitContainerSchedule;
        private System.Windows.Forms.SplitContainer splitContainerRuntimeSchedule;
        private System.Windows.Forms.Label lblRuntimeScheduleLabel;
        internal System.Windows.Forms.DataGridView dgRuntimeSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWindowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleEnabled;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.RadioButton rdoModeMove;
        private System.Windows.Forms.CheckBox chkGameWindowNeverQuitIfWindowNotFound;
        private System.Windows.Forms.Panel panelKeyboard;
        private System.Windows.Forms.TextBox txtKeyboard;
        private System.Windows.Forms.CheckBox chkKeyboardF4;
        private System.Windows.Forms.CheckBox chkKeyboardF3;
        private System.Windows.Forms.CheckBox chkKeyboardF2;
        private System.Windows.Forms.CheckBox chkKeyboardF1;
        private System.Windows.Forms.CheckBox chkKeyboardESC;
        private System.Windows.Forms.CheckBox chkKeyboard0;
        private System.Windows.Forms.CheckBox chkKeyboard9;
        private System.Windows.Forms.CheckBox chkKeyboard8;
        private System.Windows.Forms.CheckBox chkKeyboard7;
        private System.Windows.Forms.CheckBox chkKeyboard6;
        private System.Windows.Forms.CheckBox chkKeyboard5;
        private System.Windows.Forms.CheckBox chkKeyboard4;
        private System.Windows.Forms.CheckBox chkKeyboard3;
        private System.Windows.Forms.CheckBox chkKeyboard2;
        private System.Windows.Forms.CheckBox chkKeyboard1;
        private System.Windows.Forms.CheckBox chkKeyboardZ;
        private System.Windows.Forms.CheckBox chkKeyboardY;
        private System.Windows.Forms.CheckBox chkKeyboardX;
        private System.Windows.Forms.CheckBox chkKeyboardW;
        private System.Windows.Forms.CheckBox chkKeyboardV;
        private System.Windows.Forms.CheckBox chkKeyboardU;
        private System.Windows.Forms.CheckBox chkKeyboardT;
        private System.Windows.Forms.CheckBox chkKeyboardS;
        private System.Windows.Forms.CheckBox chkKeyboardR;
        private System.Windows.Forms.CheckBox chkKeyboardQ;
        private System.Windows.Forms.CheckBox chkKeyboardP;
        private System.Windows.Forms.CheckBox chkKeyboardO;
        private System.Windows.Forms.CheckBox chkKeyboardN;
        private System.Windows.Forms.CheckBox chkKeyboardM;
        private System.Windows.Forms.CheckBox chkKeyboardL;
        private System.Windows.Forms.CheckBox chkKeyboardK;
        private System.Windows.Forms.CheckBox chkKeyboardJ;
        private System.Windows.Forms.CheckBox chkKeyboardI;
        private System.Windows.Forms.CheckBox chkKeyboardH;
        private System.Windows.Forms.CheckBox chkKeyboardG;
        private System.Windows.Forms.CheckBox chkKeyboardF;
        private System.Windows.Forms.CheckBox chkKeyboardE;
        private System.Windows.Forms.CheckBox chkKeyboardD;
        private System.Windows.Forms.CheckBox chkKeyboardC;
        private System.Windows.Forms.CheckBox chkKeyboardB;
        private System.Windows.Forms.CheckBox chkKeyboardCapsLock;
        private System.Windows.Forms.CheckBox chkKeyboardTab;
        private System.Windows.Forms.CheckBox chkKeyboardTilde;
        private System.Windows.Forms.CheckBox chkKeyboardA;
        private System.Windows.Forms.CheckBox chkKeyboardF12;
        private System.Windows.Forms.CheckBox chkKeyboardF11;
        private System.Windows.Forms.CheckBox chkKeyboardF8;
        private System.Windows.Forms.CheckBox chkKeyboardF10;
        private System.Windows.Forms.CheckBox chkKeyboardF7;
        private System.Windows.Forms.CheckBox chkKeyboardF9;
        private System.Windows.Forms.CheckBox chkKeyboardF6;
        private System.Windows.Forms.CheckBox chkKeyboardF5;
        private System.Windows.Forms.CheckBox chkKeyboardBackspace;
        private System.Windows.Forms.CheckBox chkKeyboardPlus;
        private System.Windows.Forms.CheckBox chkKeyboardDash;
        private System.Windows.Forms.CheckBox chkKeyboardBackslash;
        private System.Windows.Forms.CheckBox chkKeyboardRightBracket;
        private System.Windows.Forms.CheckBox chkKeyboardLeftBracket;
        private System.Windows.Forms.CheckBox chkKeyboardEnter;
        private System.Windows.Forms.CheckBox chkKeyboardQuote;
        private System.Windows.Forms.CheckBox chkKeyboardSemicolon;
        private System.Windows.Forms.CheckBox chkKeyboardSlash;
        private System.Windows.Forms.CheckBox chkKeyboardPeriod;
        private System.Windows.Forms.CheckBox chkKeyboardComma;
        private System.Windows.Forms.CheckBox chkKeyboardRightWin;
        private System.Windows.Forms.CheckBox chkKeyboardLeftWin;
        private System.Windows.Forms.CheckBox chkKeyboardSpace;
        private System.Windows.Forms.CheckBox chkKeyboardRightAlt;
        private System.Windows.Forms.CheckBox chkKeyboardLeftAlt;
        private System.Windows.Forms.CheckBox chkKeyboardRightCtrl;
        private System.Windows.Forms.CheckBox chkKeyboardLeftCtrl;
        private System.Windows.Forms.CheckBox chkKeyboardRightShift;
        private System.Windows.Forms.CheckBox chkKeyboardLeftShift;
        private System.Windows.Forms.Button cmdKeyboardValidate;
        private System.Windows.Forms.CheckBox chkKeyboardLeft;
        private System.Windows.Forms.CheckBox chkKeyboardRight;
        private System.Windows.Forms.CheckBox chkKeyboardDown;
        private System.Windows.Forms.CheckBox chkKeyboardUp;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.CheckBox chkKeyboardPageDown;
        private System.Windows.Forms.CheckBox chkKeyboardEnd;
        private System.Windows.Forms.CheckBox chkKeyboardDelete;
        private System.Windows.Forms.CheckBox chkKeyboardPageUp;
        private System.Windows.Forms.CheckBox chkKeyboardHome;
        private System.Windows.Forms.CheckBox chkKeyboardIns;
        private System.Windows.Forms.CheckBox chkKeyboardMnu;
        private System.Windows.Forms.RadioButton rdoModeKeyboard;
        private System.Windows.Forms.CheckBox chkFromCurrentMousePos;
        private System.Windows.Forms.Panel panelPreAction;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericKeyboardAfterSendingActivationMS;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.NumericUpDown numericKeyboardTimeoutToActivateMS;
        private System.Windows.Forms.CheckBox chkAppActivateIfNotActive;
        private System.Windows.Forms.ComboBox cboPreActionFailureAction;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.GroupBox grpInsertWeights;
        private System.Windows.Forms.Button cmdWait2;
        private System.Windows.Forms.Button cmdWait1;
        private System.Windows.Forms.NumericUpDown numericWait3;
        private System.Windows.Forms.NumericUpDown numericWait2;
        private System.Windows.Forms.NumericUpDown numericWait1;
        private System.Windows.Forms.Button cmdWait3;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.CheckBox chkDontTakeScreenshot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorCutCopyPaste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPaste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPasteChild;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPasteSibling;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPasteSiblingBelow;
        internal System.Windows.Forms.RadioButton rdoAfterCompletionGoTo;
        private System.Windows.Forms.Button cmdAfterCompletionHelp;
        private System.Windows.Forms.TextBox txtAfterCompletionGoTo;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentScripts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton mnuMouseRecording;
        private ToolStripButton toolStripButtonTest1;
        private TreeView tv;
        private SplitContainer splitContainerThreadMain;
        private SplitContainer splitContainerThread;
        private SplitContainer splitContainerStatsNScrollie;
        private TableLayoutPanel tableLayoutStats;
        private GroupBox groupTotal;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label13;
        private Label lblHomeTotal;
        private Label label15;
        private Label lblChildTotal;
        private Label lblContinueTotal;
        private Label label21;
        private Label label20;
        private Label lblWaitingTotal;
        private Label lblScreenshotsTotal;
        private Label label19;
        private Label lblClickCountTotal;
        private Label label14;
        private GroupBox groupSession;
        private TableLayoutPanel tableLayoutPanelSession;
        private Label label1;
        private Label label3;
        private Label lblWaiting;
        private Label label9;
        private Label lblHome;
        private Label lblScreenshots;
        private Label label7;
        private Label lblContinue;
        private Label label2;
        private Label lblChild;
        private Label lblClickCount;
        private Label label8;
        private GroupBox grpCPU;
        private AppTestStudioControls.ATSGraph atsGraph1;
        private GroupBox grpAPS;
        private AppTestStudioControls.ATSGraph atsGraphActions1;
        private SplitContainer splitContainerSeconds;
        private AppTestStudioControls.AppTestStudioStatusControl appTestStudioStatusControl1;
        internal Panel Panel2;
        internal Panel Panel1;
        private ListView lstGamePass;
    }
}