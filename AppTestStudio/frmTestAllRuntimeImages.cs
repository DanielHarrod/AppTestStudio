using AppTestStudio.solution;
using System.Windows.Forms;
using static OpenCvSharp.ML.DTrees;

namespace AppTestStudio
{
    public partial class frmTestAllRuntimeImages : Form
    {
        GameNodeAction actionNode = null;
        internal List<GamePassSolution> gamePassSolutions = new List<GamePassSolution>();
        internal frmTestAllRuntimeImages(GameNode gameNode, List<GamePassSolution> gamePassSolutions)
        {
            InitializeComponent();
            this.actionNode = gameNode as GameNodeAction;

            foreach (GamePassSolution item in gamePassSolutions)
            {
                this.gamePassSolutions.Add(item.CloneWithNoSolutions());
            }
        }

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

            int Width = ((double)gamePassSolutions[0].Bitmap.Width * scaler).ToInt();
            int Height = ((double)gamePassSolutions[0].Bitmap.Height * scaler).ToInt();


            fp.AutoScroll = true;
            fp.WrapContents = false;
            fp.FlowDirection = FlowDirection.TopDown;


            foreach (GamePassSolution gps in gamePassSolutions)
            { 


                // Optional: add tooltip with image info

                String TT = $"Size: {Width}x{Height}";

                switch (actionNode.ActionType)
                {
                    case ActionType.Action:
                        break;
                    case ActionType.Event:

                        EventSolution eventSolution = actionNode.IsTrue(gps.Bitmap, actionNode.GetGameNodeGame());
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

                fp.Controls.Add(GetTLP(gps.Bitmap, scaler));
            }
        }
        private PictureBox GetPictureBox(Bitmap bmp)
        {
            PictureBox pb = new PictureBox();
            pb.Image = bmp;
            pb.Size = new Size(Width, Height);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Margin = new Padding(5);
            return pb;
        }

        const int TableWidth = 472;

        private TableLayoutPanel GetTLP(Bitmap bmp, double scaler)
        {
            int Width = ((double)bmp.Width * scaler).ToInt();
            int Height = ((double)bmp.Height * scaler).ToInt();

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(GetPictureBox(bmp), 0, 0);
            
            if (actionNode.IsColorPoint)
            {
                tableLayoutPanel.Controls.Add(GetDVG(), 1, 0);
            }
            else
            {
                tableLayoutPanel.Controls.Add(new Panel(), 1, 0);
            }
                
            tableLayoutPanel.Name = "tableLayoutPanel1";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(Width+ TableWidth, Height);
            tableLayoutPanel.TabIndex = 0;
            return tableLayoutPanel;
        }

        private DataGridView GetDVG()
        {
            DataGridView dgv = new DataGridView();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgv.AllowUserToAddRows = false;
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgv.Size = new Size(TableWidth, 261);
            dgv.TabIndex = 10;

            //int RowIndex = dgv.Rows.Add();
            //RowIndex = dgv.Rows.Add();

            //dgv.Rows[RowIndex.a].Cells["dgvRed"].Value = "Red";
            //dgv.Rows[RowIndex].Cells["dgvGreen"].Value = "Green";
            //dgv.Rows[RowIndex].Cells["dgvBlue"].Value = "Blue";

            //dgv.Rows[RowIndex].Cells["dgvX"].Value = "X";
            //dgv.Rows[RowIndex].Cells["dgvY"].Value = "Y";
            //dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Value = "Pass/Fail";
            //dgv.Rows[RowIndex].Cells["dvgReferenceRange"].Value = "Points";

            foreach (SingleClick click in actionNode.ClickList)
            {
                int RowIndex = dgv.Rows.Add();
                dgv.Rows[RowIndex].Cells["dgvRRed"].Value = click.Color.R.ToInt().ToString();
                dgv.Rows[RowIndex].Cells["dgvRGreen"].Value = click.Color.G.ToInt().ToString();
                dgv.Rows[RowIndex].Cells["dgvRBlue"].Value = click.Color.B.ToInt().ToString();
                dgv.Rows[RowIndex].Cells["dgvX"].Value = click.X;
                dgv.Rows[RowIndex].Cells["dgvY"].Value = click.Y;

            }


            return dgv;
        }

        private void myDataGridView_SelectionChanged(Object sender, EventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }
    }
}
