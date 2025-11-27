using AppTestStudio.solution;
using System.Diagnostics;

namespace AppTestStudio
{
    public partial class frmTestAllRuntimeImages : Form
    {
        GameNodeAction actionNode = null;
        internal List<GamePassSolution> gamePassSolutions = new List<GamePassSolution>();
        internal frmTestAllRuntimeImages(GameNode gameNode, List<GamePassSolution> gamePassSolutions)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.PerformLayout();

            this.actionNode = gameNode as GameNodeAction;

            foreach (GamePassSolution item in gamePassSolutions)
            {
                this.gamePassSolutions.Add(item.CloneWithNoSolutions());
            }
        }

        int PreviewWidth = 0;
        int PreviewHeight = 0;

        private void frmTestAllRuntimeImages_Load(object sender, EventArgs e)
        {
            //lstGamePass.View = View.List;
            //ColumnHeader h = lstGamePass.Columns.Add("x");
            //h.Width = 20;

            //h = lstGamePass.Columns.Add("Time");
            //h.Width = 80;

            //h = lstGamePass.Columns.Add("Counter");
            //h.Width = 80;

            //lstGamePass.Columns.Add("Event Count");
            //h = lstGamePass.Columns.Add("Project");
            //h.Width = 80;

            //lstGamePass.Columns.Add("Result");
            //h = lstGamePass.Columns.Add("Result");
            //h.Width = 500;


            double scaler = 0.37;

            PreviewWidth = ((double)gamePassSolutions[0].Bitmap.Width * scaler).ToInt();
            PreviewHeight = ((double)gamePassSolutions[0].Bitmap.Height * scaler).ToInt();


            fp.AutoScroll = true;
            fp.WrapContents = false;
            fp.FlowDirection = FlowDirection.TopDown;


            foreach (GamePassSolution gps in gamePassSolutions)
            { 


                // Optional: add tooltip with image info

                String TT = $"Size: {Width}x{Height}";
                EventSolution eventSolution = null;
                switch (actionNode.ActionType)
                {
                    case ActionType.Action:
                        break;
                    case ActionType.Event:

                        eventSolution = actionNode.IsTrue(gps.Bitmap, actionNode.GetGameNodeGame());
                        TT = TT + $"Result={eventSolution.Result}";

                        break;
                    case ActionType.RNG:
                        break;
                    case ActionType.RNGContainer:
                        break;
                    default:
                        break;
                }

//                tip.SetToolTip(GetTLP(gps.Bitmap), TT);

                fp.Controls.Add(GetTLP(gps, scaler, eventSolution));
            }
        }
        private PictureBox GetPictureBox(Bitmap bmp, int Width, int Height)
        {
            PictureBox pb = new PictureBox();
            pb.Image = bmp;
            pb.Size = new Size(Width, Height);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Margin = new Padding(5);
            return pb;
        }

        private TableLayoutPanel GetTLP(GamePassSolution gps, double scaler, EventSolution eventSolution)
        {
            int Width = ((double)gps.Bitmap.Width * scaler).ToInt();
            int Height = ((double)gps.Bitmap.Height * scaler).ToInt();

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, PreviewWidth));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            Bitmap pBMP = gps.Bitmap.CloneMe();
            Rectangle locatedRectangle = Rectangle.Empty;
            if (actionNode.IsColorPoint)
            {
                // do nothing
            }
            else { 
                using (Graphics g = Graphics.FromImage(pBMP))
                {
                    // Draw Mask Area
                    Utils.DrawRectangleWithGuidesOnGraphics(g, gps.Bitmap, actionNode.Rectangle, 0, 0, 255, 125);

                    int LocatedX = eventSolution.CenterX - (actionNode.ObjectSearchBitmap.Width / 2);
                    int locatedY = eventSolution.CenterY - (actionNode.ObjectSearchBitmap.Height / 2);
                   
                    locatedRectangle.X = LocatedX + actionNode.Rectangle.X;
                    locatedRectangle.Y = locatedY + actionNode.Rectangle.Y;
                    locatedRectangle.Width = actionNode.ObjectSearchBitmap.Width;
                    locatedRectangle.Height = actionNode.ObjectSearchBitmap.Height;

                    Utils.DrawRectangleWithGuidesOnGraphics(g, gps.Bitmap, locatedRectangle, 255, 0, 0, 125);
                }
            }

            PictureBox pb = GetPictureBox(pBMP, Width, Height);

            tableLayoutPanel.Controls.Add(pb, 0, 0);

            tableLayoutPanel.Name = "tableLayoutPanel1";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(Width + this.ClientSize.Width, Height);
            tableLayoutPanel.TabIndex = 0;

            if (actionNode.IsColorPoint)
            {
                tableLayoutPanel.Controls.Add(GetDVG(gps), 1, 0);
            }
            else
            {
                ActionSolution solution = new ActionSolution();

                Debug.WriteLine($"Mask = {actionNode.Rectangle}");

                FlowLayoutPanel fp = new FlowLayoutPanel();
                fp.FlowDirection = FlowDirection.TopDown;
                fp.WrapContents = false;
                fp.AutoScroll = true;
                fp.Width = gps.Bitmap.Width;
                fp.Height = Height;

                Label l = new Label();
                l.Width = 300;
                l.Text = $"Solution ID = {gps.SolutionID}";
                fp.Controls.Add(l);

                l = new Label();
                l.Width = 300;
                l.Text = $"ObjectThreashold = {actionNode.ObjectThreshold}";
                fp.Controls.Add(l);

                int detectedThreashold = (int)(eventSolution.DetectedThreashold * 100);
                l = new Label();
                l.Width = 300;
                l.Text = $"DetectedThreshold = {detectedThreashold}";
                fp.Controls.Add(l);

                l = new Label();
                l.Width = 500;
                l.Text = $"Mask = {actionNode.Rectangle}";
                fp.Controls.Add(l);

                l = new Label();
                l.Width = 500;
                l.Text = $"Best XY at Threashold = {detectedThreashold} at ({eventSolution.CenterX},{eventSolution.CenterY})";
                fp.Controls.Add(l);

                l = new Label();
                l.Width = 500;
                l.Text = "Result: Fail";
                l.BackColor = Color.PaleVioletRed;
                if (detectedThreashold >= actionNode.ObjectThreshold)
                {
                    l.Text = "Result: Pass";
                    l.BackColor = Color.LightGreen;
                }
                fp.Controls.Add(l);

                l = new Label();
                l.Width = 500;
                l.Text = $"Seek time {eventSolution.ImageSearchTime}";
                fp.Controls.Add(l);

                l = new Label();
                l.Width = 500;
                l.Text = $"Search Area";
                fp.Controls.Add(l);


                Bitmap searchObject = actionNode.ObjectSearchBitmap;
                int searchObjectWidth = searchObject.Width;
                int searchObjectHeight = searchObject.Height;

                // Search Image
                GroupBox groupBox = new GroupBox();
                groupBox.Text = "Search Image";
                groupBox.Name = "groupBox1";
                groupBox.Width = searchObjectWidth + 6;
                groupBox.Height = searchObjectHeight + 23;

                PictureBox pictureBox = GetPictureBox(searchObject, searchObjectWidth, searchObjectHeight);
                pictureBox.Dock = DockStyle.Left | DockStyle.Top;
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;

                groupBox.Controls.Add(pictureBox);
                fp.Controls.Add(groupBox);

                // Mask Area
                Bitmap bmpMask = eventSolution.bitmapBeingSearchedForObject;
                int ObjectSearchWidth = bmpMask.Width;
                int ObjectSearchHeight = bmpMask.Height;

                groupBox = new GroupBox();
                groupBox.Text = "Search Area";
                groupBox.Name = "groupBox2";
                groupBox.Width = ObjectSearchWidth + 6;
                groupBox.Height = ObjectSearchHeight + 23;

                pictureBox = GetPictureBox(bmpMask, ObjectSearchWidth, ObjectSearchHeight);
                pictureBox.Dock = DockStyle.Left | DockStyle.Top;
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;

                groupBox.Controls.Add(pictureBox);
                fp.Controls.Add(groupBox);

                // Found Area
                Bitmap CropImage = new Bitmap(searchObjectWidth, searchObjectHeight);
                using (Graphics grp = Graphics.FromImage(CropImage))
                {
                    grp.DrawImage(gps.Bitmap, new Rectangle(0, 0, searchObjectWidth, searchObjectHeight), locatedRectangle, GraphicsUnit.Pixel);
                    grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                }

                pictureBox = GetPictureBox(CropImage, CropImage.Width, CropImage.Height);
                pictureBox.Dock = DockStyle.Left | DockStyle.Top;
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;

                groupBox = new GroupBox();
                groupBox.Text = "Found Image";
                groupBox.Name = "groupBox3";
                groupBox.Width = CropImage.Width + 6;
                groupBox.Height = CropImage.Height + 23;

                groupBox.Controls.Add(pictureBox);
                fp.Controls.Add(groupBox);

                tableLayoutPanel.Controls.Add(fp, 1, 0);
            }
            return tableLayoutPanel;            
        }

        private DataGridView GetDVG(GamePassSolution gps)
        {
            DataGridView dgv = new DataGridView();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgv.AllowUserToAddRows = false;
            dgv.Anchor = AnchorStyles.Top |  AnchorStyles.Left | AnchorStyles.Bottom;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            DataGridViewTextBoxColumn dgvRed = new DataGridViewTextBoxColumn();
            dgvRed.HeaderText = "Red";
            dgvRed.Name = "dgvRed";
            DataGridViewTextBoxColumn dgvGreen = new DataGridViewTextBoxColumn();
            dgvGreen.HeaderText = "Green";
            dgvGreen.Name = "dgvGreen";
            DataGridViewTextBoxColumn dgvBlue = new DataGridViewTextBoxColumn();
            dgvBlue.HeaderText = "Blue";
            dgvBlue.Name = "dgvBlue";
            DataGridViewTextBoxColumn dgvRRed = new DataGridViewTextBoxColumn();
            dgvRRed.HeaderText = "Ref Red";
            dgvRRed.Name = "dgvRRed";
            DataGridViewTextBoxColumn dgvRGreen = new DataGridViewTextBoxColumn();
            dgvRGreen.HeaderText = "Ref Green";
            dgvRGreen.Name = "dgvRGreen";
            DataGridViewTextBoxColumn dgvRBlue = new DataGridViewTextBoxColumn();
            dgvRBlue.HeaderText = "Ref Blue";
            dgvRBlue.Name = "dgvRBlue";
            DataGridViewTextBoxColumn dgvX = new DataGridViewTextBoxColumn();
            dgvX.HeaderText = "X";
            dgvX.Name = "dgvX";
            DataGridViewTextBoxColumn dgvY = new DataGridViewTextBoxColumn();
            dgvY.HeaderText = "Y";
            dgvY.Name = "dgvY";
            DataGridViewTextBoxColumn dgvReferencePassFail = new DataGridViewTextBoxColumn();
            dgvReferencePassFail.HeaderText = "Pass/Fail";
            dgvReferencePassFail.Name = "dgvReferencePassFail";
            DataGridViewTextBoxColumn dvgReferenceRange = new DataGridViewTextBoxColumn();
            dvgReferenceRange.HeaderText = "Range";
            dvgReferenceRange.Name = "dvgReferenceRange";

            dgv.Columns.AddRange(new DataGridViewColumn[] { dgvX, dgvY, dgvRed, dgvGreen, dgvBlue, dgvRRed, dgvRGreen, dgvRBlue, dgvReferencePassFail, dvgReferenceRange });
            dgv.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv.SelectionChanged += myDataGridView_SelectionChanged;
            dgv.DefaultCellStyle = dataGridViewCellStyle2;
            dgv.Location = new Point(6, 32);
            dgv.Margin = new Padding(4, 3, 4, 3);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 62;
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.TabIndex = 10;
            dgv.Width = 600;

            foreach (SingleClick click in actionNode.ClickList)
            {
                int RowIndex = dgv.Rows.Add();
                dgv.Rows[RowIndex].Cells["dgvRRed"].Value = click.Color.R.ToInt().ToString();
                dgv.Rows[RowIndex].Cells["dgvRGreen"].Value = click.Color.G.ToInt().ToString();
                dgv.Rows[RowIndex].Cells["dgvRBlue"].Value = click.Color.B.ToInt().ToString();
                dgv.Rows[RowIndex].Cells["dgvX"].Value = click.X;
                dgv.Rows[RowIndex].Cells["dgvY"].Value = click.Y;
                dgv.Rows[RowIndex].Cells["dvgReferenceRange"].Value = $"+/- {actionNode.Points}";
                dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Value = "";

                Color TestColor = Color.Black;

                if (gps.Bitmap.Height >= click.Y && gps.Bitmap.Width >= click.X)
                {
                    TestColor = gps.Bitmap.GetPixel(click.X, click.Y);
                }

                dgv.Rows[RowIndex].Cells["dgvRed"].Value = TestColor.R.ToInt().ToString();
                dgv.Rows[RowIndex].Cells["dgvGreen"].Value = TestColor.G.ToInt().ToString();
                dgv.Rows[RowIndex].Cells["dgvBlue"].Value = TestColor.B.ToInt().ToString();


                DataGridViewCellStyle CellStyle = Utils.GetDataGridViewCellStyleFromColor(TestColor);

                dgv.Rows[RowIndex].Cells["dgvRed"].Style = CellStyle;
                dgv.Rows[RowIndex].Cells["dgvGreen"].Style = CellStyle;
                dgv.Rows[RowIndex].Cells["dgvBlue"].Style = CellStyle;

                Color TargetColor = click.Color;
                DataGridViewCellStyle TargetCellStyle = Utils.GetDataGridViewCellStyleFromColor(TargetColor);

                dgv.Rows[RowIndex].Cells["dgvRRed"].Style = TargetCellStyle;
                dgv.Rows[RowIndex].Cells["dgvRGreen"].Style = TargetCellStyle;
                dgv.Rows[RowIndex].Cells["dgvRBlue"].Style = TargetCellStyle;

                if (TargetColor.CompareColorWithPoints(TestColor, actionNode.Points, new EventSolution()))
                {
                    dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Value = "Passed";

                    CellStyle = new DataGridViewCellStyle();
                    CellStyle.BackColor = Color.Green;
                    dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Style = CellStyle;

                }
                else
                {
                    dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Value = "Failed";

                    CellStyle = new DataGridViewCellStyle();
                    CellStyle.BackColor = Color.Red;
                    dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Style = CellStyle;
                }
            }

            return dgv;
        }

        private void myDataGridView_SelectionChanged(Object sender, EventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }
    }
}
