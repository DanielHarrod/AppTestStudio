using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudio
{
    public partial class frmTestObjectSearch : Form
    {
        public frmTestObjectSearch(GameNodeGame game, GameNodeAction node, frmMain frm, IntPtr mainWindowHandle, GameNodeAction parent)
        {
            InitializeComponent();

            this.frm = frm;
            this.MainWindowHandle = mainWindowHandle;
            this.Node = node;
            this.Game = game;
            this.Parent = parent;


        }

        Mat m1;
        Mat Blue;
        Mat Green;
        Mat Red;

        Mat m2;

        Mat BlueTarget;
        Mat GreenTarget;
        Mat RedTarget;

        frmMain frm;
        IntPtr MainWindowHandle;
        GameNodeAction Node;
        GameNodeGame Game;
        Bitmap CropImage;
        OpenCvSharp.Point DetectedPoint;
        GameNodeAction Parent;

        private void cmdUpdateScreenshot_Click(object sender, EventArgs e)
        {
            RunFullTest();
        }

        private void RunFullTest(Boolean UseCurrentWindow = true)
        {
            Stopwatch Watch = System.Diagnostics.Stopwatch.StartNew();

            int CenterX = 0;
            int CenterY = 0;
            Boolean IsPassed = false; ;

            if (Parent.IsSomething())
            {
                RunTest(Parent, UseCurrentWindow);
                LoadData(Parent);
                Search(Parent, ref CenterX,ref CenterY,ref IsPassed);

                if (IsPassed)
                {

                    switch (Node.Mode)
                    {
                        case AppTestStudio.Mode.RangeClick:
                            int RNGW = Utils.RandomNumber(0, Node.Rectangle.Width);
                            int RNGH = Utils.RandomNumber(0, Node.Rectangle.Height);
                            int x = Parent.Rectangle.X + CenterX - (Node.Rectangle.Width / 2) + Node.RelativeXOffset + RNGW;
                            int y = Parent.Rectangle.Y + CenterY - (Node.Rectangle.Height / 2) + Node.RelativeYOffset + RNGH;
                            Utils.ClickOnWindow(MainWindowHandle, (short)x, (short)y);
                            frm.Log("Click attempt: x=" + x + ",Y = " + y);
                            Debug.WriteLine("Click attempt: x=" + x + ",Y = " + y);
                            break;
                        case AppTestStudio.Mode.ClickDragRelease:
                            int xPos = Node.Rectangle.X;
                            int yPos = Node.Rectangle.Y;

                            int ex = xPos + Node.Rectangle.Width;
                            int ey = yPos + Node.Rectangle.Height;

                            Boolean Failed = false;

                            if (Node.IsRelativeStart)
                            {


                                GameNode Parent = Node.Parent as GameNode;
                                if (Parent is GameNodeAction)
                                {
                                    GameNodeAction ParentNode = Parent as GameNodeAction;
                                    xPos = CenterX + ParentNode.Rectangle.X + Node.RelativeXOffset - (Node.Rectangle.Width / 2) + Utils.RandomNumber(0, Node.Rectangle.Width);
                                    yPos = CenterY + ParentNode.Rectangle.Y + Node.RelativeYOffset - (Node.Rectangle.Height / 2) + Utils.RandomNumber(0, Node.Rectangle.Height);
                                }

                                if (xPos < 0)
                                {
                                    frm.Log("Check Relative offset X, calculated to a negative position " + xPos);
                                    Failed = true;
                                }

                                if (yPos < 0)
                                {
                                    frm.Log("Check Relative offset Y, calculated to a negative position " + yPos);
                                    Failed = true;
                                }

                                if (yPos <= 34)
                                {
                                    frm.Log("Check Relative offset Y, calculated to a position on the Window Title  " + yPos + " use > 35");
                                    Failed = true;
                                }

                                ex = Node.Rectangle.X + Node.Rectangle.Width / 2;
                                ey = Node.Rectangle.Y + Node.Rectangle.Height / 2;

                            }

                            if (Failed)
                            {

                            }
                            else
                            {
                                frm.Log("Swipe from ( x=" + xPos + ",y = " + yPos + " to x=" + ex + ",y=" + ey + ")");
                                Utils.ClickDragRelease(MainWindowHandle, xPos, yPos, ex, ey);
                            }
                            break;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                }
            }
            else
            {
                RunTest(Node, UseCurrentWindow);
                LoadData(Node);
                Search(Node,ref CenterX,ref CenterY,ref IsPassed);
            }


            Watch.Stop();
            Debug.WriteLine(Watch.ElapsedMilliseconds);
            lblHideAndSeek.Text = Watch.ElapsedMilliseconds + "ms";


        }

        private void Search(GameNodeAction node,ref int centerX,ref int centerY,ref bool passedTest)
        {
            Double Percent = (double) NumericUpDown1.Value / 100;
            int Rows = Red.Rows - RedTarget.Rows + 1;
            int Cols = Red.Cols - RedTarget.Cols + 1;

        if (Rows < 1)
            {
                frm.Log(Node.Name + " search item height " + RedTarget.Rows + "px is larger than the height of the mask of " + Red.Rows + "px, Please increase the mask size so the search image can be searched.");
                return;
        }

            if (Cols < 1)
            {
                frm.Log(Node.Name + " search item width is " + RedTarget.Cols + "px is larger than the width of the mask of " + Red.Cols + "px, Please increase the mask size so the search image can be searched.");
                return;
            }

            Mat res = new Mat(Rows, Cols, MatType.CV_8U);
            //'Cv2.CvtColor(m1, m2, ColorConversionCodes.)

            Mat SearchTarget = null;
            Mat ObjectTarget = null; 

            switch (cboChannel.Text)
            {
                case "Red Channel":
                    SearchTarget = Red;
                    ObjectTarget = RedTarget;
                    break;
                case "Green Channel":
                    SearchTarget = Green;
                    ObjectTarget = GreenTarget;
                    break;
                case "Blue Channel":
                    SearchTarget = Blue;
                ObjectTarget = BlueTarget;
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }


            Cv2.MatchTemplate(SearchTarget, ObjectTarget, res, TemplateMatchModes.CCoeffNormed);

            OpenCvSharp.Point p = new OpenCvSharp.Point();
        DetectedPoint = new OpenCvSharp.Point();
            Cv2.MinMaxLoc(res, out p, out DetectedPoint);

            //'Dim mv As Double
            //'Dim xval As Double
            //'Dim mloc As Point
            //'Dim xloc As Point

            //'Cv2.MinMaxLoc(res, mv, xval, mloc, xloc)

            Mat.Indexer<Single> indexer = res.GetGenericIndexer<Single>();
            Single j = indexer[DetectedPoint.Y, DetectedPoint.X];

            lblDetectedThreashold.Text = (j * 100).ToString("F1");
            centerX = DetectedPoint.X + (PictureBoxObject.Image.Width / 2);
            centerY = DetectedPoint.Y + (PictureBoxObject.Image.Height / 2);

            lblPoint.Text = "x = " + centerX + "  y =" + centerY;
            Debug.WriteLine(DetectedPoint);
            Debug.WriteLine(j);

        //'Dim Min As Double
        //'Dim Max As Double
        //'res.MinMaxIdx(Min, Max)

        //'//'~220
        //'For r As Integer = Node.Rectangle.Y To Node.Rectangle.Y + Node.Rectangle.Height
        //'    For c As Integer = Node.Rectangle.X To Node.Rectangle.X + Node.Rectangle.Width 
        //'        Dim j = indexer(r, c)
        //'        if (j > Percent ) {
        //'            Debug.WriteLine("Row=" & r & " col=" & c & " value = " & j)
        //'        }
        //'    Next
        //'Next


        if (j >= (float) NumericUpDown1.Value / 100 ) {
                lblResult.Text = "Test Passed";
                lblResult.BackColor = Color.Green;
                passedTest = true;
        } else {
                lblResult.Text = "Test Failed";
                lblResult.BackColor = Color.Red;
}
            PictureBoxSearchArea.Invalidate();

        }

        private void LoadData(GameNodeAction parent)
        {
            if (Node.Rectangle.Width <= 0 || Node.Rectangle.Height <= 0)
            {
                Debug.Assert(false);
                return;
            }
            Bitmap CropImage = new Bitmap(Node.Rectangle.Width, Node.Rectangle.Height);

            using (Graphics grp = Graphics.FromImage(CropImage))
            {
                grp.DrawImage(PictureBoxSearchArea.Image, new Rectangle(0, 0, Node.Rectangle.Width, Node.Rectangle.Height), Node.Rectangle, GraphicsUnit.Pixel);
                //'grp.DrawEllipse(Pens.Black, 40, 40, 40, 40)

                grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            }
            m1 = OpenCvSharp.Extensions.BitmapConverter.ToMat(CropImage);

            //'213 ms
            //'Dim Red As Mat = m1.ExtractChannel(2)
            Mat[] BGR = m1.Split();

            Blue = BGR[0];
            Green = BGR[1];
            Red = BGR[2];

            //'Red.CvtColor(ColorConversionCodes.GRAY2BGR, 1)

            //'6ms
            PictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(Red);
            PictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(Green);
            PictureBox3.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(Blue);

            m2 = OpenCvSharp.Extensions.BitmapConverter.ToMat(PictureBoxObject.Image as Bitmap);
            BGR = m2.Split();
            BlueTarget = BGR[0];
            GreenTarget = BGR[1];
            RedTarget = BGR[2];
        }

        private void RunTest(GameNodeAction node, bool useCurrentWindow)
        {
            Bitmap bmp;

            if (useCurrentWindow)
            {
                bmp = Utils.GetBitmapFromWindowHandle(MainWindowHandle);
            }
            else
            {
                bmp = frm.PictureBox1.Image as Bitmap;
            }

            PictureBoxSearchArea.Image = bmp;

            PictureBoxObject.Image = Node.ObjectSearchBitmap;

            bmp = null;

        }
    }
}
