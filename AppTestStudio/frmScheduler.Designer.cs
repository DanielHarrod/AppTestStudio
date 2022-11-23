namespace AppTestStudio
{
    partial class frmScheduler
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.nudInstanceNumber = new System.Windows.Forms.NumericUpDown();
            this.txtWindowName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.cboPickApp = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.dtStartsAt = new System.Windows.Forms.DateTimePicker();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.txtApp = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.nudStopAfter = new System.Windows.Forms.NumericUpDown();
            this.grpRepeat = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.nudRepeatEvery = new System.Windows.Forms.NumericUpDown();
            this.chkRepeat = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudInstanceNumber)).BeginInit();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopAfter)).BeginInit();
            this.grpRepeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatEvery)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(468, 254);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 26;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(630, 254);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 27;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(156, 45);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(100, 13);
            this.Label7.TabIndex = 3;
            this.Label7.Text = "Emmulator Instance";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(7, 45);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 13);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Instance";
            // 
            // nudInstanceNumber
            // 
            this.nudInstanceNumber.Location = new System.Drawing.Point(89, 38);
            this.nudInstanceNumber.Name = "nudInstanceNumber";
            this.nudInstanceNumber.Size = new System.Drawing.Size(61, 20);
            this.nudInstanceNumber.TabIndex = 0;
            // 
            // txtWindowName
            // 
            this.txtWindowName.Location = new System.Drawing.Point(89, 12);
            this.txtWindowName.Name = "txtWindowName";
            this.txtWindowName.Size = new System.Drawing.Size(264, 20);
            this.txtWindowName.TabIndex = 1;
            this.txtWindowName.Visible = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 20);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Window Name";
            this.Label3.Visible = false;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.Label7);
            this.GroupBox5.Controls.Add(this.Label6);
            this.GroupBox5.Controls.Add(this.nudInstanceNumber);
            this.GroupBox5.Controls.Add(this.txtWindowName);
            this.GroupBox5.Controls.Add(this.Label3);
            this.GroupBox5.Location = new System.Drawing.Point(8, 72);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(365, 69);
            this.GroupBox5.TabIndex = 25;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Target";
            // 
            // cboPickApp
            // 
            this.cboPickApp.Location = new System.Drawing.Point(649, 40);
            this.cboPickApp.Name = "cboPickApp";
            this.cboPickApp.Size = new System.Drawing.Size(31, 23);
            this.cboPickApp.TabIndex = 24;
            this.cboPickApp.Text = "...";
            this.cboPickApp.UseVisualStyleBackColor = true;
            this.cboPickApp.Click += new System.EventHandler(this.cboPickApp_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(5, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(26, 13);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "App";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(5, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Name";
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.Filter = "Test App Studio files|Default.xml";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.dtStartsAt);
            this.GroupBox4.Location = new System.Drawing.Point(8, 147);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(365, 99);
            this.GroupBox4.TabIndex = 21;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Start At";
            // 
            // dtStartsAt
            // 
            this.dtStartsAt.CustomFormat = "hh:mm tt";
            this.dtStartsAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartsAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartsAt.Location = new System.Drawing.Point(6, 19);
            this.dtStartsAt.Name = "dtStartsAt";
            this.dtStartsAt.ShowUpDown = true;
            this.dtStartsAt.Size = new System.Drawing.Size(200, 48);
            this.dtStartsAt.TabIndex = 5;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(172, 20);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(62, 17);
            this.chkSunday.TabIndex = 1;
            this.chkSunday.Text = "Sunday";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(95, 67);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(68, 17);
            this.chkSaturday.TabIndex = 1;
            this.chkSaturday.Text = "Saturday";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(96, 44);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(54, 17);
            this.chkFriday.TabIndex = 1;
            this.chkFriday.Text = "Friday";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(6, 67);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(83, 17);
            this.chkWednesday.TabIndex = 1;
            this.chkWednesday.Text = "Wednesday";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // txtApp
            // 
            this.txtApp.Location = new System.Drawing.Point(46, 45);
            this.txtApp.Name = "txtApp";
            this.txtApp.Size = new System.Drawing.Size(597, 20);
            this.txtApp.TabIndex = 23;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(46, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(597, 20);
            this.txtName.TabIndex = 17;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.GroupBox2);
            this.GroupBox1.Controls.Add(this.grpRepeat);
            this.GroupBox1.Controls.Add(this.chkRepeat);
            this.GroupBox1.Location = new System.Drawing.Point(379, 72);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(335, 176);
            this.GroupBox1.TabIndex = 18;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Repeat";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.nudStopAfter);
            this.GroupBox2.Location = new System.Drawing.Point(7, 106);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(322, 55);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Stop After";
            this.GroupBox2.Visible = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(79, 22);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(73, 13);
            this.Label5.TabIndex = 1;
            this.Label5.Text = "Times per day";
            // 
            // nudStopAfter
            // 
            this.nudStopAfter.Location = new System.Drawing.Point(7, 20);
            this.nudStopAfter.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudStopAfter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStopAfter.Name = "nudStopAfter";
            this.nudStopAfter.Size = new System.Drawing.Size(61, 20);
            this.nudStopAfter.TabIndex = 0;
            this.nudStopAfter.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // grpRepeat
            // 
            this.grpRepeat.Controls.Add(this.Label4);
            this.grpRepeat.Controls.Add(this.nudRepeatEvery);
            this.grpRepeat.Location = new System.Drawing.Point(7, 44);
            this.grpRepeat.Name = "grpRepeat";
            this.grpRepeat.Size = new System.Drawing.Size(322, 55);
            this.grpRepeat.TabIndex = 1;
            this.grpRepeat.TabStop = false;
            this.grpRepeat.Text = "Repeat Every";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(74, 21);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(44, 13);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Minutes";
            // 
            // nudRepeatEvery
            // 
            this.nudRepeatEvery.Location = new System.Drawing.Point(6, 19);
            this.nudRepeatEvery.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nudRepeatEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRepeatEvery.Name = "nudRepeatEvery";
            this.nudRepeatEvery.Size = new System.Drawing.Size(62, 20);
            this.nudRepeatEvery.TabIndex = 2;
            this.nudRepeatEvery.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // chkRepeat
            // 
            this.chkRepeat.AutoSize = true;
            this.chkRepeat.Location = new System.Drawing.Point(7, 20);
            this.chkRepeat.Name = "chkRepeat";
            this.chkRepeat.Size = new System.Drawing.Size(61, 17);
            this.chkRepeat.TabIndex = 0;
            this.chkRepeat.Text = "Repeat";
            this.chkRepeat.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(549, 254);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 28;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.chkSunday);
            this.GroupBox3.Controls.Add(this.chkSaturday);
            this.GroupBox3.Controls.Add(this.chkFriday);
            this.GroupBox3.Controls.Add(this.chkWednesday);
            this.GroupBox3.Controls.Add(this.chkThursday);
            this.GroupBox3.Controls.Add(this.chkTuesday);
            this.GroupBox3.Controls.Add(this.chkMonday);
            this.GroupBox3.Location = new System.Drawing.Point(8, 252);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(365, 100);
            this.GroupBox3.TabIndex = 20;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Days";
            this.GroupBox3.Visible = false;
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(96, 20);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(70, 17);
            this.chkThursday.TabIndex = 0;
            this.chkThursday.Text = "Thursday";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(7, 44);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(67, 17);
            this.chkTuesday.TabIndex = 1;
            this.chkTuesday.Text = "Tuesday";
            this.chkTuesday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(7, 20);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(64, 17);
            this.chkMonday.TabIndex = 0;
            this.chkMonday.Text = "Monday";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(649, 11);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 19;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // frmScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 294);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.cboPickApp);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.txtApp);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.chkEnabled);
            this.Name = "frmScheduler";
            this.Text = "Add/Edit Scheduler";
            this.Load += new System.EventHandler(this.frmScheduler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudInstanceNumber)).EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopAfter)).EndInit();
            this.grpRepeat.ResumeLayout(false);
            this.grpRepeat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatEvery)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdDelete;
        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.NumericUpDown nudInstanceNumber;
        internal System.Windows.Forms.TextBox txtWindowName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button cboPickApp;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.DateTimePicker dtStartsAt;
        internal System.Windows.Forms.CheckBox chkSunday;
        internal System.Windows.Forms.CheckBox chkSaturday;
        internal System.Windows.Forms.CheckBox chkFriday;
        internal System.Windows.Forms.CheckBox chkWednesday;
        internal System.Windows.Forms.TextBox txtApp;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.NumericUpDown nudStopAfter;
        internal System.Windows.Forms.GroupBox grpRepeat;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown nudRepeatEvery;
        internal System.Windows.Forms.CheckBox chkRepeat;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.CheckBox chkThursday;
        internal System.Windows.Forms.CheckBox chkTuesday;
        internal System.Windows.Forms.CheckBox chkMonday;
        internal System.Windows.Forms.CheckBox chkEnabled;
    }
}