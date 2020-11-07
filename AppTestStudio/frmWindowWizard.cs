// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

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
using static AppTestStudio.Utils;

namespace AppTestStudio
{
    public partial class frmWindowWizard : Form
    {

        public String PrimaryWindowName { get; set; }
        public String SecondaryWindowName { get; set; }
        public String PrimaryWindowFilter { get; set; }
        public String SecondaryWindowFilter { get; set; }

        public frmWindowWizard(String primaryWindowName, String secondaryWindowName, string primaryWindowFilter, string secondaryWindowFilter)
        {
            InitializeComponent();

            lblSecondaryWindowsFound.Text = "";

            PrimaryWindowName = primaryWindowName;
            SecondaryWindowName = secondaryWindowName;
            PrimaryWindowFilter = primaryWindowFilter;
            SecondaryWindowFilter = secondaryWindowFilter;

            txtPrimaryWindowName.Text = PrimaryWindowName;
            txtSecondaryWindowName.Text = SecondaryWindowName;

            lblPrimaryWindowName.Text = PrimaryWindowName;
            lblChangePrimaryWindowName.Text = PrimaryWindowName;

            lblPrimaryWindowFilter.Text = PrimaryWindowFilter;
            lblChangePrimaryWindowFilter.Text = PrimaryWindowFilter;

            lblSecondaryWindowName.Text = SecondaryWindowName;
            lblChangeSecondaryWindowName.Text = SecondaryWindowName;

            lblSecondaryWindowFilter.Text = SecondaryWindowFilter;
            lblChangeSecondaryWindowFilter.Text = SecondaryWindowFilter;

            cboSteamPrimaryWindowNameFilter.Text = PrimaryWindowFilter;
            cboSteamSecondaryWindowNameFilter.Text = SecondaryWindowFilter;       
        }

        public Boolean UseValues = false;
        public String ChosenWindowName = "";

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void cmdUse_Click(object sender, EventArgs e)
        {
            UseValues = true;
            Hide();
        }

        private void frmWindowWizard_Load(object sender, EventArgs e)
        {
            lblPrimaryWindowsFound.Text = "";

            InitializeWindowList();
        }

        private void InitializeWindowList()
        {
            // Loop through the processes
            Process[] Processes = Process.GetProcesses();
            foreach (Process P in Processes)
            {
                // if the processes have a window title
                if (P.MainWindowTitle.Length > 0)
                {
                    lstWindowsFound.Items.Add(P.MainWindowTitle);
                }
            }
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( lstPrimary.SelectedIndex > -1 )
            {
                cmdUseSecondaryWindowFound.Enabled = false;

                lstSecondaryWindow.Items.Clear();

                String SelectedWindowName = lstPrimary.SelectedItem.ToString();

                IntPtr PrimaryWindowHandle = WindowWizardGetWindowHandleFromWindowName(SelectedWindowName);

                WindowHandleInfo hi = new WindowHandleInfo(PrimaryWindowHandle);
                List<IntPtr> ChildWindowHandles = hi.GetAllChildHandles();

                foreach (IntPtr ChildHandle in ChildWindowHandles)
                {
                    String ChildText = GetText(ChildHandle);
                    if (ChildText.Length > 0)
                    {
                        lstSecondaryWindow.Items.Add(ChildText);
                    }
                }

                // highlight the first item in the list.
                if (lstSecondaryWindow.Items.Count > 0)
                {
                    lstSecondaryWindow.SelectedIndex = 0;
                    cmdUseSecondaryWindowFound.Enabled = true;
                }
                else
                {
                    // no child windows
                    // Take a screenshot from main window.
                    if (PrimaryWindowHandle != IntPtr.Zero)
                    {
                        Bitmap bmp = Utils.GetBitmapFromWindowHandle(PrimaryWindowHandle);
                        PictureBox1.Image = bmp;
                    }
                }
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            String WindowName = txtPrimaryWindowName.Text.ToUpper().Trim();

            if (WindowName.Length > 0)
            {
                lstPrimary.Items.Clear();
                
                foreach (String ListItem in lstWindowsFound.Items)
                {
                    Boolean WindowFound = false;
                    switch (cboSteamPrimaryWindowNameFilter.Text)
                    {
                        case "Equals":
                            if (ListItem.ToUpper().Equals(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                        case "Starts With":
                            if (ListItem.ToUpper().StartsWith(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                        case "Contains":

                            if (ListItem.ToUpper().Contains(WindowName))
                            {
                                WindowFound = true;
                            }                                
                            break;
                        default:
                            if (ListItem.ToUpper().Equals(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                    }
                    if (WindowFound)
                    {
                        lstPrimary.Items.Add(ListItem.ToString());
                    }
                }
                
                // if we found items set the first item.
                if (lstPrimary.Items.Count > 0)
                {
                    lstPrimary.SelectedIndex = 0;
                }
            }

            lblPrimaryWindowsFound.Text = lstPrimary.Items.Count.ToString();
        }

        private IntPtr WindowWizardGetWindowHandleFromWindowName(String WindowName)
        {
            Process[] Processes = Process.GetProcesses();
            foreach (Process P in Processes)
            {
                if (P.MainWindowTitle.Length > 0)
                {
                    if (P.MainWindowTitle == WindowName)
                    {
                        return P.MainWindowHandle;
                    }
                }
            }
            return IntPtr.Zero;
        }

        private void lstSecondaryWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            IntPtr ChildWindowHandle = IntPtr.Zero;

            if (lstPrimary.SelectedIndex > -1)
            {
                if (lstSecondaryWindow.SelectedIndex > -1)
                {
                    String SelectedWindowName = lstPrimary.SelectedItem.ToString();

                    IntPtr PrimaryWindowHandle = WindowWizardGetWindowHandleFromWindowName(SelectedWindowName);

                    WindowHandleInfo hi = new WindowHandleInfo(PrimaryWindowHandle);
                    List<IntPtr> ChildWindowHandles = hi.GetAllChildHandles();

                    foreach (IntPtr ChildHandle in ChildWindowHandles)
                    {
                        String ChildText = GetText(ChildHandle);
                        if (ChildText.Length > 0)
                        {
                            if (ChildText == lstSecondaryWindow.SelectedItem.ToString())
                            {
                                ChildWindowHandle = ChildHandle;
                                break;
                            }
                        }
                        //if (ChildText.StartsWith(ChildWindowName))
                        //{
                        //    Handles.ChildWindowHandle = ChildHandle;
                        //    return Handles.ChildWindowHandle;
                        //}
                    }
                }
            }

            // Did we find something?
            if (ChildWindowHandle != IntPtr.Zero)
            {
                Bitmap bmp = Utils.GetBitmapFromWindowHandle(ChildWindowHandle);
                PictureBox1.Image = bmp;
            }            
        }

        private void cmdRefreshList_Click(object sender, EventArgs e)
        {
            lstWindowsFound.Items.Clear();

            InitializeWindowList();
        }

        private void cmdUseWindowFound_Click(object sender, EventArgs e)
        {
            if (lstWindowsFound.SelectedIndex > 0)
            {
                txtPrimaryWindowName.Text = lstWindowsFound.Text;
                cboSteamPrimaryWindowNameFilter.Text = "Equals";
                cmdSearch_Click(null, null);

            }
        }

        private void lstWindowsFound_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdUseWindowFound.Enabled = true;
        }

        private void cmdSecondarySearch_Click(object sender, EventArgs e)
        {
            String WindowName = txtSecondaryWindowName.Text.ToUpper().Trim();

            if (WindowName.Length > 0)
            {
                lstSecondary.Items.Clear();

                foreach (String ListItem in lstSecondaryWindow.Items)
                {
                    Boolean WindowFound = false;
                    switch (cboSteamSecondaryWindowNameFilter.Text)
                    {
                        case "Equals":
                            if (ListItem.ToUpper().Equals(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                        case "Starts With":
                            if (ListItem.ToUpper().StartsWith(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                        case "Contains":

                            if (ListItem.ToUpper().Contains(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                        default:
                            if (ListItem.ToUpper().Equals(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                    }
                    if (WindowFound)
                    {
                        lstSecondary.Items.Add(ListItem.ToString());
                    }
                }
            }

            lblSecondaryWindowsFound.Text = lstSecondary.Items.Count.ToString();
        }

        private void cmdUseSecondaryWindowFound_Click(object sender, EventArgs e)
        {
            if (lstWindowsFound.SelectedIndex > 0)
            {
                txtSecondaryWindowName.Text = lstSecondaryWindow.Text;
                cboSteamSecondaryWindowNameFilter.Text = "Equals";
                cmdSecondarySearch_Click(null, null);
            }
        }

        private void cboSteamPrimaryWindowNameFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChangePrimaryWindowFilter.Text = cboSteamPrimaryWindowNameFilter.Text;
        }

        private void txtPrimaryWindowName_TextChanged(object sender, EventArgs e)
        {
            lblChangePrimaryWindowName.Text = txtPrimaryWindowName.Text;
        }

        private void cboSteamSecondaryWindowNameFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChangeSecondaryWindowFilter.Text = cboSteamSecondaryWindowNameFilter.Text;
        }

        private void txtSecondaryWindowName_TextChanged(object sender, EventArgs e)
        {
            lblChangeSecondaryWindowName.Text = txtSecondaryWindowName.Text;
        }
    }
}
