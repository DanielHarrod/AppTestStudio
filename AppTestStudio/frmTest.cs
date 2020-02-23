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
    public partial class frmTest : Form
    {
        frmMain frm;
        IntPtr MainWindowHandle;
        GameNodeAction Action;
        GameNodeGame Game;
        public frmTest( GameNodeGame game, GameNodeAction action, frmMain frm, IntPtr MainWindowHandle)
        {
            InitializeComponent();
            Game = game;
            Action = action;
            this.frm = frm;
            this.MainWindowHandle = MainWindowHandle;

            RunTest();

        }

        private void cmdRetest_Click(object sender, EventArgs e)
        {
            RunTest();
        }

        private void RunTest()
        {
            dgv.Rows.Clear();
            dgvTest.Rows.Clear();
            PictureBox1.Image = frm.PictureBox1.Image;

            Bitmap bmp = Utils.GetBitmapFromWindowHandle(MainWindowHandle);

            PictureBoxTest.Image = bmp;

            String bmpResolution = bmp.Width + "x" + bmp.Height;
            String GameResolution = Action.ResolutionWidth + "x" + Action.ResolutionHeight;

            if (GameResolution != bmpResolution)
            {
                txtResolution.Text = "Warning Resolution Variation - Expected: " + GameResolution + "x" + " vs Actual:" + bmpResolution;
                txtResolution.BackColor = Color.Yellow;
            }
            else
            {
                txtResolution.Text = "Resolution " + bmp.Width + "x" + bmp.Height;
                txtResolution.BackColor = Color.Green;
            }

            Boolean Result = false;
            Boolean FinalResult = false;


            lblPoints.Text = Action.Points + " Points";

            foreach (DataGridViewRow row in frm.dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }


            int RowIndex = dgv.Rows.Add();
            int X = Convert.ToInt32( row.Cells["dgvX"].Value);
            int y = Convert.ToInt32(row.Cells["dgvY"].Value);
                Color Targetcolor = Color.Red;
                Targetcolor = Targetcolor.FromRGBString(row.Cells["dgvColor"].Value.ToString());
                dgv.Rows[RowIndex].Cells["dgvColor"].Value = Targetcolor.ToRGBString();
            dgv.Rows[RowIndex].Cells["dgvX"].Value = X;
                dgv.Rows[RowIndex].Cells["dgvY"].Value = y;

                DataGridViewCellStyle Style = new DataGridViewCellStyle();
                Style.BackColor = Style.BackColor.FromRGBString(row.Cells["dgvColor"].Value.ToString());
Single brightness = Targetcolor.GetBrightness();
            if (brightness < 0.55)
            {
                    Style.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                    Style.ForeColor = Color.Black;
            }

                dgv.Rows[RowIndex].Cells["dgvColor"].Style = Style;

                RowIndex = dgvTest.Rows.Add();

            DataGridViewRow dgvTestRow = dgvTest.Rows[RowIndex];

                Color TestColor;
                if (bmp.Height >= y && bmp.Width >= X ) {
                    TestColor = bmp.GetPixel(X, y);
                } else
            {
                    TestColor = Color.Black;
                    Style.ForeColor = Color.White;
                }

                dgvTestRow.Cells["dgvColorTest"].Value = TestColor.ToRGBString();

                dgvTestRow.Cells["dgvColorTest"].Style = Utils.GetDataGridViewCellStyleFromColor(TestColor);

                dgvTestRow.Cells["dgvXTest"].Value = X;
                dgvTestRow.Cells["dgvYTest"].Value = y;

                int notused = 0;

                if (frm.rdoAnd.Checked)
            {
                if (Targetcolor.CompareColorWithPoints(TestColor, frm.cboPoints.Text.ToInt(), ref notused))
                {
                    if (FinalResult == false)
                    {
                            Result = true; ;
                        }
                }
                else
                {
                        Result = false;
                        FinalResult = true;
                    }
            }
            else
            {
                if (Targetcolor.CompareColorWithPoints(TestColor, frm.cboPoints.Text.ToInt(),ref notused))
                {
                        Result = true;
                    }
            }

            if (Targetcolor.CompareColorWithPoints(TestColor, frm.cboPoints.Text.ToInt(), ref notused))
            {
                    dgvTestRow.Cells["dgvPassFail"].Value = "Test Passed";
                    Style = new DataGridViewCellStyle();
                    Style.BackColor = Color.Green;
                    dgvTestRow.Cells["dgvPassFail"].Style = Style;

                }
            else
            {
                    dgvTestRow.Cells["dgvPassFail"].Value = "Test Failed";
                    Style = new DataGridViewCellStyle();
                    Style.BackColor = Color.Red;
                    dgvTestRow.Cells["dgvPassFail"].Style = Style;
                }

                long r = Math.Abs(Convert.ToInt32(Targetcolor.R) - Convert.ToInt32(TestColor.R));
long g = Math.Abs(Convert.ToInt32(Targetcolor.G) - Convert.ToInt32(TestColor.G));
long b = Math.Abs(Convert.ToInt32(Targetcolor.B) - Convert.ToInt32(TestColor.B));

long Largest = 0;
                if (r > Largest)
            {
                    Largest = r;
                }
            if (g > Largest)
            {
                    Largest = g;
                }
            if (b > Largest)
            {
                    Largest = b;
                }

                dgvTestRow.Cells["dvgRange"].Value = Largest;
        }

        if (frm.rdoAnd.Checked)
            {
                lblLogic.Text = "Logic: AND";
        }
            else
            {
                lblLogic.Text = "Logic: OR";
          }

            if (dgvTest.Rows.Count == 1)
            {
                Result = true;
            }


            if (Result)
            {
                txtResult.Text = "Passed";
                txtResult.BackColor = Color.Green;
            }
            else
            {
                txtResult.Text = "Failed";
                txtResult.BackColor = Color.Red;
          }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
