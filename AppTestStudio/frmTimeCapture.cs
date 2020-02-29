using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudio
{
    public partial class frmTimeCapture : Form
    {
        public Boolean IsSaved { get; set; }
        public int DelayMS { get; set; }
        public int DelayS { get; set; }
        public int DelayM { get; set; }
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
