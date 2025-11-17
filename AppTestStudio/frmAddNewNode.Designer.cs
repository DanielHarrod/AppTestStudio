namespace AppTestStudio
{
    partial class frmAddNewNode
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtNodeName = new TextBox();
            groupBox1 = new GroupBox();
            rdoAction = new RadioButton();
            rdoEvent = new RadioButton();
            cmdCreate = new Button();
            cmdCancel = new Button();
            groupBox2 = new GroupBox();
            rdoRootNode = new RadioButton();
            rdoSelectedNode = new RadioButton();
            lblSelectedNode = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(373, 287);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(400, 12);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // txtNodeName
            // 
            txtNodeName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNodeName.Location = new Point(444, 9);
            txtNodeName.Name = "txtNodeName";
            txtNodeName.Size = new Size(344, 23);
            txtNodeName.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(rdoAction);
            groupBox1.Controls.Add(rdoEvent);
            groupBox1.Location = new Point(400, 38);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(373, 74);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Type";
            // 
            // rdoAction
            // 
            rdoAction.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdoAction.AutoSize = true;
            rdoAction.Location = new Point(274, 47);
            rdoAction.Name = "rdoAction";
            rdoAction.Size = new Size(60, 19);
            rdoAction.TabIndex = 0;
            rdoAction.Text = "Action";
            rdoAction.UseVisualStyleBackColor = true;
            // 
            // rdoEvent
            // 
            rdoEvent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            rdoEvent.AutoSize = true;
            rdoEvent.Checked = true;
            rdoEvent.Location = new Point(274, 22);
            rdoEvent.Name = "rdoEvent";
            rdoEvent.Size = new Size(54, 19);
            rdoEvent.TabIndex = 0;
            rdoEvent.TabStop = true;
            rdoEvent.Text = "Event";
            rdoEvent.UseVisualStyleBackColor = true;
            // 
            // cmdCreate
            // 
            cmdCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdCreate.Location = new Point(400, 276);
            cmdCreate.Name = "cmdCreate";
            cmdCreate.Size = new Size(283, 23);
            cmdCreate.TabIndex = 4;
            cmdCreate.Text = "Create";
            cmdCreate.UseVisualStyleBackColor = true;
            cmdCreate.Click += cmdCreate_Click;
            // 
            // cmdCancel
            // 
            cmdCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdCancel.Location = new Point(689, 276);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.Size = new Size(84, 23);
            cmdCancel.TabIndex = 5;
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = true;
            cmdCancel.Click += cmdCancel_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(rdoRootNode);
            groupBox2.Controls.Add(rdoSelectedNode);
            groupBox2.Location = new Point(400, 118);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(373, 128);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Node to add as child";
            // 
            // rdoRootNode
            // 
            rdoRootNode.AutoSize = true;
            rdoRootNode.Location = new Point(6, 22);
            rdoRootNode.Name = "rdoRootNode";
            rdoRootNode.Size = new Size(82, 19);
            rdoRootNode.TabIndex = 0;
            rdoRootNode.Text = "Root Node";
            rdoRootNode.UseVisualStyleBackColor = true;
            // 
            // rdoSelectedNode
            // 
            rdoSelectedNode.AutoSize = true;
            rdoSelectedNode.Checked = true;
            rdoSelectedNode.Location = new Point(6, 42);
            rdoSelectedNode.Name = "rdoSelectedNode";
            rdoSelectedNode.Size = new Size(101, 19);
            rdoSelectedNode.TabIndex = 0;
            rdoSelectedNode.TabStop = true;
            rdoSelectedNode.Text = "Selected Node";
            rdoSelectedNode.UseVisualStyleBackColor = true;
            // 
            // lblSelectedNode
            // 
            lblSelectedNode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSelectedNode.Location = new Point(406, 187);
            lblSelectedNode.Name = "lblSelectedNode";
            lblSelectedNode.Size = new Size(367, 86);
            lblSelectedNode.TabIndex = 1;
            lblSelectedNode.Text = "lblSelectedNode";
            // 
            // frmAddNewNode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 319);
            Controls.Add(lblSelectedNode);
            Controls.Add(groupBox2);
            Controls.Add(cmdCancel);
            Controls.Add(cmdCreate);
            Controls.Add(groupBox1);
            Controls.Add(txtNodeName);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            MinimizeBox = false;
            Name = "frmAddNewNode";
            Text = "Add Image to Project";
            Load += frmAddNewNode_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtNodeName;
        private GroupBox groupBox1;
        private RadioButton rdoAction;
        private RadioButton rdoEvent;
        private Button cmdCreate;
        private Button cmdCancel;
        private GroupBox groupBox2;
        private Label lblSelectedNode;
        private RadioButton rdoRootNode;
        private RadioButton rdoSelectedNode;
    }
}