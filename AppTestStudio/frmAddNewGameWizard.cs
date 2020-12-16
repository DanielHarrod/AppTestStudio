using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudio
{
    public partial class frmAddNewGameWizard : Form
    {
        //Which workspace panel are we on?
        public long CurrentPanel = 0;

        public List<string> HistoryStack { get; set; }
        public int HistoryStackIndex { get; set; }

        public Boolean fromHistory { get; set; }
        public Boolean IsReadyToCreate { get; set; }
        public frmAddNewGameWizard()
        {

            InitializeComponent();
            HistoryStack = new List<string>();
        }

        private void cmdCreateProject_Click(object sender, EventArgs e)
        {
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSearch_Click(null, null);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length > 0)
            {
                webBrowser1.Navigate("https://play.google.com/store/search?q=" + System.Web.HttpUtility.UrlEncode(txtSearch.Text.Trim()) + "&c=apps");
            }
        }

        private void tmrWaitForBrowserInitialization_Tick(object sender, EventArgs e)
        {
            if (lblAppID.Text.Length > 0)
            {
                if (webBrowser1.DocumentTitle.Length > 0)
                {
                    if (webBrowser1.DocumentTitle.Contains("-"))
                    {
                        Debug.WriteLine(webBrowser1.DocumentTitle);
                        String AppName = webBrowser1.DocumentTitle.Replace(" - Apps on Google Play", "");
                        AppName = AppName.Replace(" - Android Apps on Google Play", "");
                        lblAppName.Text = AppName;

                        foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                        {
                            AppName = AppName.Replace(c, '-');
                        }

                        AppName = AppName.Trim();

                        lblSafeName.Text = AppName;
                    }
                }
            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Debug.WriteLine("WebBrowser1_Navigated");
            if (e.Url.Query.Contains("?id="))
            {
                lblAppID.Text = e.Url.Query.Replace("?id=", "");
                Timer1.Enabled = true;
            }
            else
            {
                Timer1.Enabled = false;
                lblAppID.Text = "";
                lblAppName.Text = "";
                lblSafeName.Text = "";
            }
            Debug.WriteLine(e.Url.Query.Replace("?id=", ""));
        }

        private void cmdForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void cmdHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://play.google.com/store/apps");
        }

        private void frmAddNewGameWizard_Load(object sender, EventArgs e)
        {
            panelWorkspaceNaming.Dock = DockStyle.Fill;
            panelWorkspacePicker.Dock = DockStyle.Fill;
            panelWorkspacePlatform.Dock = DockStyle.Fill;
            panelWorkspaceStart.Dock = DockStyle.Fill;
            lblNameIsInvalid.Text = "";

            foreach (Platform platform in Enum.GetValues(typeof(Platform)))
            {
                cboPlatform.Items.Add(platform.ToString());
            }

            cboPlatform.SelectedIndex = 0;

            cboBlueStacksVersion.SelectedIndex = 1;

            ShowPanel();

            txtSearch.Focus();
            lblAppID.Text = "";
            lblAppName.Text = "";
            lblSafeName.Text = "";

            cmdHome_Click(null, null);
        }

        private void ShowPanel()
        {
            panelWorkspaceNaming.Visible = false;
            panelWorkspacePicker.Visible = false;
            panelWorkspacePlatform.Visible = false;
            panelWorkspaceStart.Visible = false;
            cmdPrevious.Enabled = true;
            cmdNext.Enabled = true;

            pictureBoxNaming.Visible = false;
            pictureBoxPicker.Visible = false;
            pictureBoxPlatform.Visible = false;
            pictureBoxStart.Visible = false;

            switch (CurrentPanel)
            {
                case 0:
                    panelWorkspaceStart.Visible = true;
                    pictureBoxStart.Visible = true;
                    cmdPrevious.Enabled = false;
                    lblTitle.Text = "Start";
                    lblSubTitle.Text = "An easy way to setup a new project.";
                    break;
                case 1:
                    panelWorkspacePlatform.Visible = true;
                    pictureBoxPlatform.Visible = true;
                    lblTitle.Text = "Choose a platform";
                    lblSubTitle.Text = "Which platform did you want to use?";
                    break;
                case 2:
                    panelWorkspacePicker.Visible = true;
                    pictureBoxPicker.Visible = true;
                    lblTitle.Text = "Browse to locate application ID";
                    lblSubTitle.Text = "Locate the ApplicationID in the store by browsing to the app, the appid and name will be automatically selected.";
                    txtSearch.Focus();
                    break;
                case 3:
                    panelWorkspaceNaming.Visible = true;
                    pictureBoxNaming.Visible = true;
                    cmdNext.Enabled = false;
                    lblTitle.Text = "Project Folder";
                    lblSubTitle.Text = "What folder should the project files be saved to?";
                    txtName_TextChanged(null, null);
                    break;
                default:
                    // shouldn't be here.
                    Debug.Assert(false);
                    break;
            }
        }

        private void cmdStartOver_Click(object sender, EventArgs e)
        {
            CurrentPanel = 0;
            cboPlatform.SelectedIndex = (int)Platform.NoxPlayer;
            cmdFinish.Enabled = false;
            txtName.Text = "";
            txtFinishAppID.Text = "";
            cboBlueStacksVersion.SelectedIndex = 1;
            cmdHome_Click(null, null);


            ShowPanel();
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            if (
                    (Platform)cboPlatform.SelectedIndex == Platform.Application
                ||
                    (Platform)cboPlatform.SelectedIndex == Platform.Steam
            )
            {
                if (CurrentPanel == 3)
                {
                    // skip picker.
                    CurrentPanel = CurrentPanel - 1;
                }
            }

            CurrentPanel = CurrentPanel - 1;
            ShowPanel();
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            // On panel 2?
            if (CurrentPanel == 2)
            {
                txtName.Text = lblSafeName.Text;
                txtFinishAppID.Text = lblAppID.Text;
            }

            if (CurrentPanel == 1)
            {
                if (
                    (Platform)cboPlatform.SelectedIndex == Platform.Application
                ||
                    (Platform)cboPlatform.SelectedIndex == Platform.Steam
                )
                { 
                    // skip picker.
                    CurrentPanel = CurrentPanel + 1;
                }
            }

            CurrentPanel = CurrentPanel + 1;

            // Now on the last panel
            if (CurrentPanel == 3)
            {                
                txtName_TextChanged(null, null);
            }
                        
            ShowPanel();
        }

        private void cmdWizardCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        
        //NoxPlayer,
        //BlueStacks,
        //Steam,
        //Application

        private void cboPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSizeControl.ForeColor = SystemColors.ControlText;
            lblDPIControl.ForeColor = SystemColors.ControlText;
            lblAppInstallation.ForeColor = SystemColors.ControlText;
            lblStatus.ForeColor = SystemColors.ControlText;
            lblSelectedPlatform.Text = cboPlatform.SelectedItem.ToString();
            lblBlueStacksVersion.Visible = false;
            cboBlueStacksVersion.Visible = false;
            switch ((Platform)cboPlatform.SelectedIndex)
            {
                // Nox
                case Platform.NoxPlayer:
                    lblSizeControl.Text = "Automated";
                    lblSizeControl.ForeColor = Color.Green;
                    lblDPIControl.Text = "Automated";
                    lblDPIControl.ForeColor = Color.Green;
                    lblAppInstallation.Text = "Manual";
                    lblStatus.Text = "Recommended";
                    lblStatus.ForeColor = Color.Green;
                    lblDetectable.Text = "Script Behaviour";

                    lblFinishAppID.Visible = true;
                    txtFinishAppID.Visible = true;

                    // Show Picker
                    tableLayoutPanelLeftNav.RowStyles[2].Height = 40;

                    break;
                case Platform.BlueStacks:
                    lblSizeControl.Text = "End User Defined";
                    lblDPIControl.Text = "End User Defined";
                    lblAppInstallation.Text = "Automated";
                    lblAppInstallation.ForeColor = Color.Green;
                    lblStatus.Text = "Caution";
                    lblDetectable.Text = "Script Behaviour";

                    lblFinishAppID.Visible = true;
                    txtFinishAppID.Visible = true;

                    // Show Picker
                    tableLayoutPanelLeftNav.RowStyles[2].Height = 40;

                    lblBlueStacksVersion.Visible = true;
                    cboBlueStacksVersion.Visible = true;

                    break;
                case Platform.Application:
                    lblSizeControl.Text = "End User Defined";
                    lblDPIControl.Text = "End User Defined";
                    lblAppInstallation.Text = "Manual";
                    lblStatus.Text = "Experimental";
                    lblDetectable.Text = "Possible";

                    lblFinishAppID.Visible = false;
                    txtFinishAppID.Visible = false;

                    // Hide Picker
                    tableLayoutPanelLeftNav.RowStyles[2].Height = 0;

                    break;
                case Platform.Steam:
                    lblSizeControl.Text = "End User Defined";
                    lblDPIControl.Text = "End User Defined";
                    lblAppInstallation.Text = "Manual";
                    lblStatus.Text = "Experimental";
                    lblDetectable.Text = "Possible";

                    lblFinishAppID.Visible = false;
                    txtFinishAppID.Visible = false;

                    // Hide Picker
                    tableLayoutPanelLeftNav.RowStyles[2].Height = 0;

                    break;
                default:
                    break;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            cmdFinish.Enabled = true;
            int IndexOfInvalidCharacter = txtName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars());
            if (IndexOfInvalidCharacter == -1)
            {
                if (txtName.Text.Trim().Length == 0)
                {
                    cmdFinish.Enabled = false;
                }
                else
                {
                    lblNameIsInvalid.Text = "";
                }
            }
            else
            {

                String BadCharacter = txtName.Text.Substring(IndexOfInvalidCharacter, 1);
                lblNameIsInvalid.Text = "Name has invalid character: " + BadCharacter;
                cmdFinish.Enabled = false;
            }
        }

        private void cmdFinish_Click(object sender, EventArgs e)
        {
            IsReadyToCreate = true;
            Close();
        }
    }
}
