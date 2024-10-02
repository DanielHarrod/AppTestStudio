//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Windows.Forms;

namespace AppTestStudio
{
    public partial class frmScheduler : Form
    {

        public ScheduleItem Item { get; set; }
        public Boolean IsAdding { get; set; }
        public Boolean IsSaving { get; set; }
        public Boolean IsDeleting { get; set; }
        public frmScheduler(ScheduleItem item)
        {
            InitializeComponent();
            Item = item;
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

            si.InstanceNumber = nudInstanceNumber.Value.ToInt();
            si.Monday = chkMonday.Checked;
            si.Tuesday = chkTuesday.Checked;
            si.Wednesday = chkWednesday.Checked;
            si.Thursday = chkThursday.Checked;
            si.Friday = chkFriday.Checked;
            si.Saturday = chkSaturday.Checked;
            si.Sunday = chkSunday.Checked;

            si.Name = txtName.Text;
            si.Repeats = chkRepeat.Checked;
            si.RepeatsEvery = nudRepeatEvery.Value.ToInt();
            si.StartsAt = dtStartsAt.Value;
            si.StopsAfter = nudStopAfter.Value.ToInt();
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

        private void frmScheduler_Load(object sender, EventArgs e)
        {
            if (Item.IsSomething())
            {
                txtApp.Text = Item.AppPath;


            nudInstanceNumber.Value = Item.InstanceNumber;
                chkMonday.Checked = Item.Monday;
                chkTuesday.Checked = Item.Tuesday;
                chkWednesday.Checked = Item.Wednesday;
                chkThursday.Checked = Item.Thursday;
                chkFriday.Checked = Item.Friday;
                chkSaturday.Checked = Item.Saturday;
                chkSunday.Checked = Item.Sunday;

                txtName.Text = Item.Name;
                chkRepeat.Checked = Item.Repeats;
                nudRepeatEvery.Value = Item.RepeatsEvery;
                dtStartsAt.Value = Item.StartsAt;
                nudStopAfter.Value = Item.StopsAfter;
                txtWindowName.Text = Item.WindowName;
                chkEnabled.Checked = Item.IsEnabled;
            }
            else
            {
                cmdDelete.Enabled = false;
              dtStartsAt.Value = DateTime.Now.AddMinutes(30);
          }

        }
    }
}
