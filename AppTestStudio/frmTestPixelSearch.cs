using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static AppTestStudio.frmSolution;

namespace AppTestStudio
{
    public partial class frmTestPixelSearch : Form
    {
        frmMain frm;
        IntPtr MainWindowHandle;
        GameNodeAction Node;
        GameNodeGame Game;
        Point DetectedPoint;
        GameNodeAction GameNodeActionParent;

        Boolean CurrentTestPassed = false;        
        List<Point> CurrentPointList;

        public frmTestPixelSearch(GameNodeGame game, GameNodeAction node, frmMain frm, IntPtr mainWindowHandle, GameNodeAction parent)
        {
            InitializeComponent();
            this.frm = frm;
            this.MainWindowHandle = mainWindowHandle;
            this.Node = node;
            this.Game = game;
            this.GameNodeActionParent = parent;
            this.CurrentPointList = new List<Point>();
        }

        private void frmTestPixelSearch_Load(object sender, EventArgs e)
        {
            CaptureCurrentImage(Node, true);

            numPixelSearchB.Value = Node.PixelSearchB;
            numPixelSearchG.Value = Node.PixelSearchG;
            numPixelSearchR.Value = Node.PixelSearchR;
            numPixelSearchBNeg.Value = Node.PixelSearchBNeg;
            numPixelSearchGNeg.Value = Node.PixelSearchGNeg;
            numPixelSearchRNeg.Value = Node.PixelSearchRNeg;
            numPixelSearchBPos.Value = Node.PixelSearchBPos;
            numPixelSearchGPos.Value = Node.PixelSearchGPos;
            numPixelSearchRPos.Value = Node.PixelSearchRPos;
            RunTest();
            this.WindowState = FormWindowState.Maximized;
        }

        private void CaptureCurrentImage(GameNodeAction node, bool useCurrentWindow)
        {
            Bitmap bmp;

            if (useCurrentWindow)
            {
                Boolean Success = false;
                bmp = Utils.GetBitmapFromWindowHandle(ref Success, MainWindowHandle);
            }
            else
            {
                bmp = frm.PictureBox1.Image as Bitmap;
            }

            PictureBoxSearchArea.Image = bmp;

            bmp = null;

        }

        private void PictureBoxSearchArea_Paint(object sender, PaintEventArgs e)
        {
            Rectangle SourceMask;

            SourceMask = Node.Rectangle;


            if (SourceMask.IsFullScreenMask())
            {
                // do nothing
                SourceMask = SourceMask.SetFullScreenFromDefault();
            }
            else
            {
                Utils.DrawMask(PictureBoxSearchArea, SourceMask, e);
            }

            if (CurrentTestPassed)
            {
                Bitmap bitmap = PictureBoxSearchArea.Image as Bitmap;

                if (CurrentPointList.Count > 0)
                {
                    Rectangle rectanglePoint = new Rectangle(DetectedPoint.X, DetectedPoint.Y, 3, 3);
                    Utils.DrawRectangleWithGuidesOnGraphics(e.Graphics, bitmap, rectanglePoint);
                }
            }
        }

        private void cmdRetestCurrentWindow_Click(object sender, EventArgs e)
        {
            CaptureCurrentImage(Node, true);
            RunTest();
        }
        private void cmdRetestDesignImage_Click(object sender, EventArgs e)
        {
            CaptureCurrentImage(Node, false);
            RunTest();
        }

        private void RunTest()
        {
            if (PictureBoxSearchArea.Image != null)
            {
                Bitmap bmp = Utils.CropBitmap(PictureBoxSearchArea.Image as Bitmap, Node.Rectangle);

                Color SearchColor = Color.FromArgb(numPixelSearchR.Value.ToInt(), numPixelSearchG.Value.ToInt(), numPixelSearchB.Value.ToInt());

                int RMin = numPixelSearchRNeg.Value.ToInt();
                int RMax = numPixelSearchRPos.Value.ToInt();
                int GMin = numPixelSearchGNeg.Value.ToInt();
                int GMax = numPixelSearchGPos.Value.ToInt();
                int BMin = numPixelSearchBNeg.Value.ToInt();
                int BMax = numPixelSearchBPos.Value.ToInt();

                //bmp.Save("C:\\temp\\a.bmp");

                CurrentPointList = Utils.FindPixelColor(bmp, SearchColor, RMin, RMax, GMin, GMax, BMin, BMax, 999);
                dataGridView1.Rows.Clear();

                if (CurrentPointList.Count > 0)
                {
                    int xPosition = CurrentPointList[0].X + Node.Rectangle.X;
                    int yPosition = CurrentPointList[0].Y + Node.Rectangle.Y;

                    label1.Text = $"First Pixel Found at X:{xPosition} Y:{yPosition} Qty={CurrentPointList.Count()}";
                    CurrentTestPassed = true;

                    DetectedPoint = new Point(CurrentPointList[0].X + Node.Rectangle.X, CurrentPointList[0].Y + Node.Rectangle.Y);

                    int Counter = 0;
                    foreach (Point pt in CurrentPointList)
                    {
                        dataGridView1.Rows.Add(Counter++, pt.X + Node.Rectangle.X, pt.Y + Node.Rectangle.Y);
                        if (Counter >= 1000)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    label1.Text = "Not found";
                    CurrentTestPassed = false;
                }
            }
            PictureBoxSearchArea.Refresh();
        }

        private void numPixelSearchR_ValueChanged(object sender, EventArgs e)
        {
            PixelSearchValueChanged();
        }

        private void numPixelSearchG_ValueChanged(object sender, EventArgs e)
        {
            PixelSearchValueChanged();
        }

        private void numPixelSearchB_ValueChanged(object sender, EventArgs e)
        {
            PixelSearchValueChanged();
        }
        private void PixelSearchValueChanged()
        {
            lblPixelSearchPreview.BackColor = Color.FromArgb(numPixelSearchR.Value.ToInt(), numPixelSearchG.Value.ToInt(), numPixelSearchB.Value.ToInt());
        }

        private void cmdMoveSettingsToProject_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                // Header row.
                return;
            }
            
            int X = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToInt();
            int Y = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToInt();
            DetectedPoint = new Point(X, Y);
            PictureBoxSearchArea.Invalidate();
        }        
    }
}
