
namespace AppTestStudio
{
    partial class frmMouseRecorder
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
            this.components = new System.ComponentModel.Container();
            this.cmdStartStopRecording = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cmdStartStopRecording
            // 
            this.cmdStartStopRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdStartStopRecording.Location = new System.Drawing.Point(12, 508);
            this.cmdStartStopRecording.Name = "cmdStartStopRecording";
            this.cmdStartStopRecording.Size = new System.Drawing.Size(106, 23);
            this.cmdStartStopRecording.TabIndex = 0;
            this.cmdStartStopRecording.Text = "Start Recording";
            this.cmdStartStopRecording.UseVisualStyleBackColor = true;
            this.cmdStartStopRecording.Click += new System.EventHandler(this.cmdStartStopRecording_Click);
            // 
            // frmMouseRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 543);
            this.Controls.Add(this.cmdStartStopRecording);
            this.Name = "frmMouseRecorder";
            this.Text = "frmMouseRecorder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMouseRecorder_FormClosed);
            this.Load += new System.EventHandler(this.frmMouseRecorder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdStartStopRecording;
        private System.Windows.Forms.Timer timer1;
    }
}