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
    public partial class frmScheduler : Form
    {

        public ScheduleItem Item { get; set; }
        public Boolean IsAdding { get; set; }
        public Boolean IsSaving { get; set; }
        public Boolean IsDeleting { get; set; }
        public frmScheduler(ScheduleItem Item)
        {
            InitializeComponent();
        }

        private void cboPickApp_Click(object sender, EventArgs e)
        {
            DialogResult Result = OpenFileDialog1.ShowDialog();

            if (Result == DialogResult.OK)
            {
                String filename = OpenFileDialog1.FileName;
                txtApp.Text = filename;
            }
        }

        internal ScheduleItem getItem()
        {
            ScheduleItem si;

            if (IsAdding)
            {
                si = new ScheduleItem();
            }
            else
            {
                si = Item;
            }
            si.AppPath = txtApp.Text;

            si.InstanceNumber = (int)nudInstanceNumber.Value;
            si.Monday = chkMonday.Checked;
            si.Tuesday = chkTuesday.Checked;
            si.Wednesday = chkWednesday.Checked;
            si.Thursday = chkThursday.Checked;
            si.Friday = chkFriday.Checked;
            si.Saturday = chkSaturday.Checked;
            si.Sunday = chkSunday.Checked;

            si.Name = txtName.Text;
            si.Repeats = chkRepeat.Checked;
            si.RepeatsEvery = (int)nudRepeatEvery.Value;
            si.StartsAt = dtStartsAt.Value;
            si.StopsAfter = (int)nudStopAfter.Value;
            si.WindowName = txtWindowName.Text;
            si.IsEnabled = chkEnabled.Checked;

            return si;

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            IsSaving = false;
            IsDeleting = true;
            Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            IsSaving = false;
            Hide();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            IsSaving = true;
            Hide();
        }
    }
}
