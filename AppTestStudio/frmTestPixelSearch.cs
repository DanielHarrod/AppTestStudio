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
            Rectangle rectangle = new Rectangle();

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

            Utils.FindFirstColor
            Node.PixelSearchB = (int)numPixelSearchB.Value;
            Node.PixelSearchG = (int)numPixelSearchG.Value;
            Node.PixelSearchR = (int)numPixelSearchR.Value;
            Node.PixelSearchBNeg = (int)numPixelSearchBNeg.Value;
            Node.PixelSearchGNeg = (int)numPixelSearchGNeg.Value;
            Node.PixelSearchRNeg = (int)numPixelSearchRNeg.Value;
            Node.PixelSearchBPos = (int)numPixelSearchBPos.Value;
            Node.PixelSearchGPos = (int)numPixelSearchGPos.Value;
            Node.PixelSearchRPos = (int)numPixelSearchRPos.Value;
            Boolean Found = Node.PerformPixelSearch(Game, PictureBoxSearchArea.Image as Bitmap, out DetectedPoint, GameNodeActionParent);
            if (Found)
            {
                lblResult.Text = "Pixel Found at X:" + DetectedPoint.X.ToString() + " Y:" + DetectedPoint.Y.ToString();
            }
            else
            {
                lblResult.Text = "Pixel Not Found";
            }
            PictureBoxSearchArea.Refresh();
        }
}
