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
    public partial class frmTestPixelSearch : Form
    {
        frmMain frm;
        IntPtr MainWindowHandle;
        GameNodeAction Node;
        GameNodeGame Game;
        OpenCvSharp.Point DetectedPoint;
        GameNodeAction GameNodeActionParent;

        Boolean CurrentTestPassed = false;
        Point? CurrentPoint = Point.Empty;

        public frmTestPixelSearch(GameNodeGame game, GameNodeAction node, frmMain frm, IntPtr mainWindowHandle, GameNodeAction parent)
        {
            InitializeComponent();
            this.frm = frm;
            this.MainWindowHandle = mainWindowHandle;
            this.Node = node;
            this.Game = game;
            this.GameNodeActionParent = parent;
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

                if (CurrentPoint.HasValue)
                {
                    Rectangle rectanglePoint = new Rectangle(CurrentPoint.Value.X + Node.Rectangle.X, CurrentPoint.Value.Y + Node.Rectangle.Y, 3,3);
                    Utils.DrawRectangleWithGuidesOnGraphics(e.Graphics, bitmap, rectanglePoint);
                }
            }
        }

        private void cmdRetestCurrentWindow_Click(object sender, EventArgs e)
        {
            CaptureCurrentImage(Node, true);
        }
        private void cmdRetestDesignImage_Click(object sender, EventArgs e)
        {
            CaptureCurrentImage(Node, false);
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

                CurrentPoint = Utils.FindFirstColor(bmp, SearchColor, RMin, RMax, GMin, GMax, BMin, BMax);

                if (CurrentPoint.HasValue)
                {
                    label1.Text = "Pixel Found at X:" + (CurrentPoint.Value.X + Node.Rectangle.X).ToString() + " Y:" + (CurrentPoint.Value.Y + Node.Rectangle.Y).ToString();
                    CurrentTestPassed = true;
                }
                else
                {
                    label1.Text = "Not found";
                    CurrentTestPassed = false;
                }
            }
            PictureBoxSearchArea.Refresh();
        }
    }
}
