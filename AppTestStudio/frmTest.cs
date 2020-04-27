// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

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
        public frmTest(GameNodeGame game, GameNodeAction action, frmMain frm, IntPtr MainWindowHandle)
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
            txtLogic.Text = "";
            txtLogic2.Text = "";
            txtLogic3.Text = "";
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

            String Expression = "";

            Boolean UsingCustomLogic = frm.rdoCustom.Checked;

            String PreExpression = frm.txtCustomLogic.Text;
            if (UsingCustomLogic)
            {
                // add spaces to beginning and end.
                Expression = " " + frm.txtCustomLogic.Text + " ";

                // Lets add space between everything and expand mix the logic to allow for C# and VB Logic.
                Expression = Utils.ExtendCustomLogic(Expression);
            }

            String OriginalExpression = Expression;

            foreach (DataGridViewRow row in frm.dgv.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                int RowIndex = dgv.Rows.Add();
                int X = Convert.ToInt32(row.Cells["dgvX"].Value);
                int y = Convert.ToInt32(row.Cells["dgvY"].Value);

                int R = row.Cells["dgvRed"].Value.ToString().ToInt();
                int G = row.Cells["dgvGreen"].Value.ToString().ToInt();
                int B = row.Cells["dgvBlue"].Value.ToString().ToInt();

                dgv.Rows[RowIndex].Cells["dgvRed"].Value = R;
                dgv.Rows[RowIndex].Cells["dgvGreen"].Value = G;
                dgv.Rows[RowIndex].Cells["dgvBlue"].Value = B;
                dgv.Rows[RowIndex].Cells["dgvReferenceRemove"].Value = "Remove";


                Color Targetcolor = Color.FromArgb(R, G, B);
                dgv.Rows[RowIndex].Cells["dgvX"].Value = X;
                dgv.Rows[RowIndex].Cells["dgvY"].Value = y;

                DataGridViewCellStyle Style = new DataGridViewCellStyle();
                Style.BackColor = Style.BackColor = Targetcolor;
                Single brightness = Targetcolor.GetBrightness();
                if (brightness < 0.55)
                {
                    Style.ForeColor = Color.WhiteSmoke;
                }
                else
                {
                    Style.ForeColor = Color.Black;
                }

                dgv.Rows[RowIndex].Cells["dgvRed"].Style = Style;
                dgv.Rows[RowIndex].Cells["dgvGreen"].Style = Style;
                dgv.Rows[RowIndex].Cells["dgvBlue"].Style = Style;

                RowIndex = dgvTest.Rows.Add();

                DataGridViewRow dgvTestRow = dgvTest.Rows[RowIndex];

                Color TestColor;
                if (bmp.Height >= y && bmp.Width >= X)
                {
                    TestColor = bmp.GetPixel(X, y);
                }
                else
                {
                    TestColor = Color.Black;
                    Style.ForeColor = Color.White;
                }

                dgvTestRow.Cells["dgvColorTestRed"].Value = TestColor.R.ToString();
                dgvTestRow.Cells["dgvColorTestGreen"].Value = TestColor.G.ToString();
                dgvTestRow.Cells["dgvColorTestBlue"].Value = TestColor.B.ToString();

                dgvTestRow.Cells["dgvColorTestRed"].Style = Utils.GetDataGridViewCellStyleFromColor(TestColor);
                dgvTestRow.Cells["dgvColorTestGreen"].Style = Utils.GetDataGridViewCellStyleFromColor(TestColor);
                dgvTestRow.Cells["dgvColorTestBlue"].Style = Utils.GetDataGridViewCellStyleFromColor(TestColor); 

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
                else if (frm.rdoOR.Checked )
                {
                    if (Targetcolor.CompareColorWithPoints(TestColor, frm.cboPoints.Text.ToInt(), ref notused))
                    {
                        Result = true;
                    }
                }
       
                if (Targetcolor.CompareColorWithPoints(TestColor, frm.cboPoints.Text.ToInt(), ref notused))
                {
                    dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Value = "Passed";
                    dgvTestRow.Cells["dgvPassFail"].Value = "Passed";

                    Style = new DataGridViewCellStyle();
                    Style.BackColor = Color.Green;
                    dgvTestRow.Cells["dgvPassFail"].Style = Style;
                    dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Style = Style;

                }
                else
                {
                    dgvTestRow.Cells["dgvPassFail"].Value = "Failed";
                    dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Value = "Failed";
                    Style = new DataGridViewCellStyle();
                    Style.BackColor = Color.Red;
                    dgvTestRow.Cells["dgvPassFail"].Style = Style;
                    dgv.Rows[RowIndex].Cells["dgvReferencePassFail"].Style = Style;
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
                dgv.Rows[RowIndex].Cells["dvgReferenceRange"].Value = Largest;
            }

            if (frm.rdoCustom.Checked)
            {
                for (int dgvRowIndex = dgv.Rows.Count - 1; dgvRowIndex >= 0; dgvRowIndex--)
                {
                    DataGridViewRow row = dgv.Rows[dgvRowIndex];
                    if (row.IsNewRow)
                    {
                        continue;
                    }
                    if (row.Cells["dgvReferencePassFail"].Value.ToString() == "Passed")
                    {
                        Expression = Expression.Replace((dgvRowIndex + 1).ToString(), "TRUE");

                    }
                    else
                    {
                        Expression = Expression.Replace((dgvRowIndex + 1).ToString(), "FALSE");
                    }
                }
            }

            if (frm.rdoAnd.Checked)
            {
                txtLogic.Text = "Logic: AND";
            }
            else if (frm.rdoOR.Checked)
            {
                txtLogic.Text = "Logic: OR";
            }
            else
            {
                txtLogic.Text = frm.txtCustomLogic.Text;

                // Test the parser.
                BooleanParser.Parser parser = new BooleanParser.Parser(Expression);
                try
                {
                    Result = parser.Parse();
                }
                catch (Exception ex)
                {
                    String NewExpress = OriginalExpression.Replace("(", "").Replace(")", "").Replace("TRUE", "").Replace("FALSE", "").Replace("AND", "").Replace("OR", "").Replace("NOT", "").Replace(" ", "");

                    if (NewExpress.Length > 0)
                    {
                        frm.Log("Precompile says: " + NewExpress);
                    }

                    frm.Log("Parser Says:" + ex.Message);
                    Result = false;
                }
            }
            txtLogic.Text = PreExpression.ToLower();
            txtLogic2.Text = OriginalExpression.ToLower();
            txtLogic3.Text = Expression.ToLower();
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

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Utils.DrawColorPoints(e, dgv, "dgv", "dgvX", "dgvY");
        }

        private void PictureBoxTest_Paint(object sender, PaintEventArgs e)
        {
            Utils.DrawColorPoints(e, dgvTest, "dgvColorTest", "dgvXTest", "dgvYTest");
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                if (e.ColumnIndex == dgv.Columns["dgvReferenceRemove"].Index)
                {
                    // remove this reference.
                    dgv.Rows.Remove(dgv.Rows[e.RowIndex]);

                    // remove main reference.
                    frm.dgv.Rows.Remove(frm.dgv.Rows[e.RowIndex]);

                    // Renumber.
                    for (int i = e.RowIndex; i < frm.dgv.Rows.Count - 1; i++)
                    {
                        frm.dgv.Rows[i].Cells["dgvID"].Value = i + 1;
                    }

                    // Softsave
                    frm.ArchaicSave();

                    // redraw picture.
                    PictureBox1.Refresh();
                    return;
                }
            }
            catch (Exception ex)
            {
                Game.Log(ex.Message);
            }
        }
    }
}
