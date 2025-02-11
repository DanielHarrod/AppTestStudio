//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AppTestStudio
{
    public partial class frmTimeCapture : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Boolean IsSaved { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DelayMS { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DelayS { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DelayM { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DelayH { get; set; }

        private Boolean ReadyForEvents = false;

        public frmTimeCapture()
        {
            InitializeComponent();
            DelayH = 0;
            DelayM = 0;
            DelayMS = 0;
            DelayS = 0;
            lblDelayCalc.Text = "";
        }

        private void frmTimeCapture_Load(object sender, EventArgs e)
        {
            if (DelayH > 0)
            {
                cboDelayH.Text = DelayH.ToString();
            }
            if (DelayM > 0)
            {
                cboDelayM.Text = DelayM.ToString();
            }
            if (DelayS > 0)
            {
                cboDelayS.Text = DelayS.ToString();
            }
            if (DelayMS > 0)
            {
                cboDelayMS.Text = DelayMS.ToString();
            }
            ReadyForEvents = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            IsSaved = true;
            Hide();
        }

        private void CalculateLength()
        {
            lblDelayCalc.Text = Utils.CalculateDelay(DelayH, DelayM, DelayS, DelayMS);
        }

        private void cboDelayMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReadyForEvents)
            {
                if (cboDelayMS.Text.Trim().Length == 0)
                {
                    DelayMS = 0;
                }
                else
                {
                    DelayMS = cboDelayMS.Text.Trim().ToInt();
                }
            }

            CalculateLength();
        }

        private void cboDelayS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReadyForEvents)
            {
                if (cboDelayS.Text.Trim().Length == 0)
                {
                    DelayS = 0;
                }
                else
                {
                    DelayS = cboDelayS.Text.Trim().ToInt();
                }
            }

            CalculateLength();
        }

        private void cboDelayM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReadyForEvents)
            {
                if (cboDelayM.Text.Trim().Length == 0)
                {
                    DelayM = 0;
                }
                else
                {
                    DelayM = cboDelayM.Text.Trim().ToInt();
                }
            }

            CalculateLength();
        }

        private void cboDelayH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReadyForEvents)
            {
                if (cboDelayH.Text.Trim().Length == 0)
                {
                    DelayH = 0;
                }
                else
                {
                    DelayH = cboDelayH.Text.Trim().ToInt();
                }
            }

            CalculateLength();
        }
    }
}
