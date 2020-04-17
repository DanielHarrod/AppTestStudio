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
            IsReadyToCreate = true;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
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
                        String AppName = webBrowser1.DocumentTitle.Replace(" - Apps on Google Play", "");
                        lblAppName.Text = AppName;
                        cmdCreateProject.Enabled = true;

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
            cmdCreateProject.Enabled = false;
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
            txtSearch.Focus();
            lblAppID.Text = "";
            lblAppName.Text = "";
            lblSafeName.Text = "";
        }
    }
}
