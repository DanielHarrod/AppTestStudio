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
            lblTargetWindowName.Text = "";

            PrimaryWindowName = primaryWindowName;
            SecondaryWindowName = secondaryWindowName;
            PrimaryWindowFilter = primaryWindowFilter;
            SecondaryWindowFilter = secondaryWindowFilter;

            txtPrimaryWindowName.Text = PrimaryWindowName;
            txtSecondaryWindowName.Text = SecondaryWindowName;

            lblPrimaryWindowName.Text = PrimaryWindowName;
            lblPrimaryWindowFilter.Text = PrimaryWindowFilter;

            lblSecondaryWindowName.Text = SecondaryWindowName;            
            lblSecondaryWindowFilter.Text = SecondaryWindowFilter;

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
            lblChoosenWindow.Text = "";
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( lst.SelectedIndex > -1 )
            {
                lstSecondaryWindow.Items.Clear();

                String SelectedWindowName = lst.SelectedItem.ToString();

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
                    //if (ChildText.StartsWith(ChildWindowName))
                    //{
                    //    Handles.ChildWindowHandle = ChildHandle;
                    //    return Handles.ChildWindowHandle;
                    //}
                }


            }
            //lblChoosenWindow.Text = lst.SelectedItem.ToString();
            //ChosenWindowName = lblChoosenWindow.Text;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            String WindowName = txtPrimaryWindowName.Text.ToUpper().Trim();

            if (WindowName.Length > 0)
            {
                lst.Items.Clear();
                WindowHandles Handles = new WindowHandles();
                Process[] Processes = Process.GetProcesses();
                
                foreach (Process P in Processes)
                {
                    Boolean WindowFound = false;
                    switch (cboSteamPrimaryWindowNameFilter.Text)
                    {
                        case "Equals":
                            if (P.MainWindowTitle.ToUpper().Equals(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                        case "Starts With":
                            if (P.MainWindowTitle.ToUpper().StartsWith(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                        case "Contains":
                            if (P.MainWindowTitle.Length > 0)
                            {
                                Debug.WriteLine(P.MainWindowTitle.ToUpper());
                            }


                            if (P.MainWindowTitle.ToUpper().Contains(WindowName))
                            {
                                WindowFound = true;
                            }                                
                            break;
                        default:
                            if (P.MainWindowTitle.ToUpper().Equals(WindowName))
                            {
                                WindowFound = true;
                            }
                            break;
                    }
                    if (WindowFound)
                    {
                        lst.Items.Add(P.MainWindowTitle.ToString());
                    }
                }
            }
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

            if (lst.SelectedIndex > -1)
            {
                if (lstSecondaryWindow.SelectedIndex > -1)
                {
                    String SelectedWindowName = lst.SelectedItem.ToString();

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
    }
}
