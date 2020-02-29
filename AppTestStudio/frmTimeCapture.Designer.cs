namespace AppTestStudio
{
    partial class frmTimeCapture
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
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblDelayCalc = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.cboDelayH = new System.Windows.Forms.ComboBox();
            this.cboDelayM = new System.Windows.Forms.ComboBox();
            this.cboDelayS = new System.Windows.Forms.ComboBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.cboDelayMS = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(131, 166);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 32;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(50, 166);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 31;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblDelayCalc
            // 
            this.lblDelayCalc.AutoSize = true;
            this.lblDelayCalc.Location = new System.Drawing.Point(35, 133);
            this.lblDelayCalc.Name = "lblDelayCalc";
            this.lblDelayCalc.Size = new System.Drawing.Size(71, 13);
            this.lblDelayCalc.TabIndex = 30;
            this.lblDelayCalc.Text = "[lblDelayCalc]";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(33, 109);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(35, 13);
            this.Label20.TabIndex = 29;
            this.Label20.Text = "Hours";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(33, 82);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(44, 13);
            this.Label19.TabIndex = 28;
            this.Label19.Text = "Minutes";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(33, 55);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(49, 13);
            this.Label18.TabIndex = 27;
            this.Label18.Text = "Seconds";
            // 
            // cboDelayH
            // 
            this.cboDelayH.BackColor = System.Drawing.SystemColors.Window;
            this.cboDelayH.FormattingEnabled = true;
            this.cboDelayH.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cboDelayH.Location = new System.Drawing.Point(100, 106);
            this.cboDelayH.MaxLength = 3;
            this.cboDelayH.Name = "cboDelayH";
            this.cboDelayH.Size = new System.Drawing.Size(49, 21);
            this.cboDelayH.TabIndex = 24;
            this.cboDelayH.SelectedIndexChanged += new System.EventHandler(this.cboDelayH_SelectedIndexChanged);
            // 
            // cboDelayM
            // 
            this.cboDelayM.BackColor = System.Drawing.SystemColors.Window;
            this.cboDelayM.FormattingEnabled = true;
            this.cboDelayM.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cboDelayM.Location = new System.Drawing.Point(100, 79);
            this.cboDelayM.MaxLength = 2;
            this.cboDelayM.Name = "cboDelayM";
            this.cboDelayM.Size = new System.Drawing.Size(49, 21);
            this.cboDelayM.TabIndex = 25;
            this.cboDelayM.SelectedIndexChanged += new System.EventHandler(this.cboDelayM_SelectedIndexChanged);
            // 
            // cboDelayS
            // 
            this.cboDelayS.BackColor = System.Drawing.SystemColors.Window;
            this.cboDelayS.FormattingEnabled = true;
            this.cboDelayS.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cboDelayS.Location = new System.Drawing.Point(100, 52);
            this.cboDelayS.MaxLength = 2;
            this.cboDelayS.Name = "cboDelayS";
            this.cboDelayS.Size = new System.Drawing.Size(49, 21);
            this.cboDelayS.TabIndex = 26;
            this.cboDelayS.SelectedIndexChanged += new System.EventHandler(this.cboDelayS_SelectedIndexChanged);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(33, 30);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(62, 13);
            this.Label17.TabIndex = 23;
            this.Label17.Text = "1/1000 sec";
            // 
            // cboDelayMS
            // 
            this.cboDelayMS.BackColor = System.Drawing.SystemColors.Window;
            this.cboDelayMS.FormattingEnabled = true;
            this.cboDelayMS.Items.AddRange(new object[] {
            "0",
            "50",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "950"});
            this.cboDelayMS.Location = new System.Drawing.Point(100, 27);
            this.cboDelayMS.MaxLength = 3;
            this.cboDelayMS.Name = "cboDelayMS";
            this.cboDelayMS.Size = new System.Drawing.Size(49, 21);
            this.cboDelayMS.TabIndex = 22;
            this.cboDelayMS.SelectedIndexChanged += new System.EventHandler(this.cboDelayMS_SelectedIndexChanged);
            // 
            // frmTimeCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 216);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblDelayCalc);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.cboDelayH);
            this.Controls.Add(this.cboDelayM);
            this.Controls.Add(this.cboDelayS);
            this.Controls.Add(this.Label17);
            this.Controls.Add(this.cboDelayMS);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimeCapture";
            this.Text = "frmTimeCapture";
            this.Load += new System.EventHandler(this.frmTimeCapture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Label lblDelayCalc;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.ComboBox cboDelayH;
        internal System.Windows.Forms.ComboBox cboDelayM;
        internal System.Windows.Forms.ComboBox cboDelayS;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.ComboBox cboDelayMS;
    }
}