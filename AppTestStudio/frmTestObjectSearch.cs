// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

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
            try
            {
                RunFullTest();
            }
            catch (Exception ex)
            {

                Debug.WriteLine("cmdUpdateScreenshot_Click:" + ex.Message);
            }
            
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
                LoadData(Parent, Parent.Rectangle);
                Search(Parent, ref CenterX, ref CenterY, ref IsPassed);

                if (IsPassed)
                {
                    switch (Node.Mode)
                    {
                        case AppTestStudio.Mode.RangeClick:
                            GameNodeAction.RangeClickResult RangeClickResult = Node.CalculateRangeClickResult((Bitmap)PictureBoxSearchArea.Image, CenterX, CenterY);
                            //int RNGW = Utils.RandomNumber(0, Node.Rectangle.Width);
                            //int RNGH = Utils.RandomNumber(0, Node.Rectangle.Height);
                            //int x = Parent.Rectangle.X + CenterX - (Node.Rectangle.Width / 2) + Node.RelativeXOffset + RNGW;
                            //int y = Parent.Rectangle.Y + CenterY - (Node.Rectangle.Height / 2) + Node.RelativeYOffset + RNGH;
                            frm.Log("Click attempt: x=" + RangeClickResult.x + ",Y = " + RangeClickResult.y);
                            Debug.WriteLine("Click attempt: x=" + RangeClickResult.x + ",Y = " + RangeClickResult.y);

                            short xMouseStart = (short)( PictureBoxSearchArea.Image.Width / 2);
                            short yMouseStart = (short)(PictureBoxSearchArea.Image.Height / 2);
                            Utils.ClickOnWindow(MainWindowHandle, xMouseStart, yMouseStart, (short)RangeClickResult.x, (short)RangeClickResult.y, Node.ClickSpeed);
                            break;
                        case AppTestStudio.Mode.ClickDragRelease:
                            GameNodeAction.ClickDragReleaseResult ClickDragReleaseResult = Node.CalculateClickDragReleaseResult(CenterX, CenterY);
                            //int xPos = Node.Rectangle.X;
                            //int yPos = Node.Rectangle.Y;

                            //int ex = xPos + Node.Rectangle.Width;
                            //int ey = yPos + Node.Rectangle.Height;

                            Boolean Failed = false;

                            //GameNode ParentGameNode = Node.Parent as GameNode;
                            //if (ParentGameNode is GameNodeAction)
                            //{
                            //    GameNodeAction ParentNode = ParentGameNode as GameNodeAction;
                            //    xPos = CenterX + ParentNode.Rectangle.X + Node.RelativeXOffset - (Node.ClickDragReleaseStartWidth / 2) + Utils.RandomNumber(0, Node.ClickDragReleaseStartWidth);
                            //    yPos = CenterY + ParentNode.Rectangle.Y + Node.RelativeYOffset - (Node.ClickDragReleaseStartHeight /2) + Utils.RandomNumber(0, Node.ClickDragReleaseStartHeight);
                            //}


                            if (ClickDragReleaseResult.StartX < 0)
                            {
                                frm.Log("Check Relative offset X, calculated to a negative position " + ClickDragReleaseResult.StartX);
                                Failed = true;
                            }

                            if (ClickDragReleaseResult.StartY < 0)
                            {
                                frm.Log("Check Relative offset Y, calculated to a negative position " + ClickDragReleaseResult.StartY);
                                Failed = true;
                            }

                            //ex = Node.Rectangle.X + Node.Rectangle.Width;
                            //ey = Node.Rectangle.Y + Node.Rectangle.Height ;


                            if (Failed)
                            {
                                // do nothing
                            }
                            else
                            {
                                frm.Log("Swipe from ( x=" + ClickDragReleaseResult.StartX + ",y = " + ClickDragReleaseResult.StartY + " to x=" + ClickDragReleaseResult.EndX + ",y=" + ClickDragReleaseResult.EndY + ")");
                                Utils.ClickDragRelease(MainWindowHandle, ClickDragReleaseResult.StartX, ClickDragReleaseResult.StartY, ClickDragReleaseResult.EndX, ClickDragReleaseResult.EndY, Node.ClickDragReleaseVelocity);
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
                LoadData(Node, Node.Rectangle);
                Search(Node, ref CenterX, ref CenterY, ref IsPassed);
            }

            Watch.Stop();
            Debug.WriteLine(Watch.ElapsedMilliseconds);
            lblHideAndSeek.Text = Watch.ElapsedMilliseconds + "ms";
        }

        private void Search(GameNodeAction node, ref int centerX, ref int centerY, ref bool passedTest)
        {
            Double Percent = (double)NumericUpDown1.Value / 100;
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


            if (j >= (float)NumericUpDown1.Value / 100)
            {
                lblResult.Text = "Test Passed";
                lblResult.BackColor = Color.Green;
                passedTest = true;
            }
            else
            {
                lblResult.Text = "Test Failed";
                lblResult.BackColor = Color.Red;
            }
            PictureBoxSearchArea.Invalidate();

        }

        private void LoadData(GameNodeAction parent, Rectangle Mask)
        {
            if (Mask.Width <= 0 || Mask.Height <= 0)
            {
                Debug.Assert(false);
                return;
            }
            Bitmap CropImage = new Bitmap(Mask.Width, Mask.Height);

            using (Graphics grp = Graphics.FromImage(CropImage))
            {
                grp.DrawImage(PictureBoxSearchArea.Image, new Rectangle(0, 0, Mask.Width, Mask.Height), Mask, GraphicsUnit.Pixel);
                //'grp.DrawEllipse(Pens.Black, 40, 40, 40, 40)

                grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            }
            try
            {
                m1 = OpenCvSharp.Extensions.BitmapConverter.ToMat(CropImage);
            }
            catch (DllNotFoundException ex)
            {
                Debug.Assert(false, "Deleting the BIN folder and rebuilding typically will fix this issue.");
                return;
            }

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

            PictureBoxObject.Image = node.ObjectSearchBitmap;

            bmp = null;

        }

        private void frmTestObjectSearch_Load(object sender, EventArgs e)
        {
            lblDetectedThreashold.Text = "";
            lblPoint.Text = "";
            if (Parent.IsSomething())
            {
                NumericUpDown1.Value = Parent.ObjectThreshold;
                switch (Parent.Channel.ToUpper())
                {
                    case "RED":
                        cboChannel.Text = "Red Channel";
                        break;
                    case "GREEN":
                        cboChannel.Text = "Green Channel";
                        break;
                    case "BLUE":
                        cboChannel.Text = "Blue Channel";
                        break;
                    default:
                        break;
                }

                cmdSetAcceptanceThreshold.Enabled = false;
                cmdChannel.Enabled = false;
            }
            else
            {
                NumericUpDown1.Value = Node.ObjectThreshold;
                switch (Node.Channel.ToUpper())
                {
                    case "RED":
                        cboChannel.Text = "Red Channel";
                        break;
                    case "GREEN":
                        cboChannel.Text = "Green Channel";
                        break;
                    case "BLUE":
                        cboChannel.Text = "Blue Channel";
                        break;
                    default:
                        break;
                }
            }
            try
            {
                RunFullTest();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("frmTestObjectSearch_Load:" + ex.Message);
            }
        }

        private void PictureBoxSearchArea_Paint(object sender, PaintEventArgs e)
        {
            //'Draw the box on the search
            Rectangle Rectangle = new Rectangle();

            if (Parent.IsSomething())
            {
                Utils.DrawMask(PictureBoxSearchArea, Parent.Rectangle, e);
                Rectangle.X = DetectedPoint.X + Parent.Rectangle.X;
                Rectangle.Y = DetectedPoint.Y + Parent.Rectangle.Y;
            }
            else
            {

                Utils.DrawMask(PictureBoxSearchArea, Node.Rectangle, e);
                Rectangle.X = DetectedPoint.X + Node.Rectangle.X;
                Rectangle.Y = DetectedPoint.Y + Node.Rectangle.Y;
            }


            Rectangle.Width = PictureBoxObject.Image.Width;
            Rectangle.Height = PictureBoxObject.Image.Height;
            using (SolidBrush br = new SolidBrush(Color.FromArgb(128, 255, 201, 14)))
            {
                e.Graphics.FillRectangle(br, Rectangle);
            }

            using (Pen p = new Pen(Color.FromArgb(255, 201, 14), 1))
            {
                e.Graphics.DrawRectangle(p, Rectangle);
            }

            return;

            //New StartRectangle Rectangle

            //        if (Parent.IsSomething)
            //            {
            //                if (Node.RelativeXOffset <> 0 Or Node.RelativeYOffset <> 0 ) {
            //                    StartRectangle = New Rectangle


            //                StartRectangle.X = DetectedPoint.X + Parent.Rectangle.X + Node.RelativeXOffset
            //                    StartRectangle.Y = DetectedPoint.Y + Parent.Rectangle.Y + Node.RelativeYOffset


            //                StartRectangle.Width = PictureBoxObject.Image.Width
            //                    StartRectangle.Height = PictureBoxObject.Image.Height
            //                    //'Using br As New SolidBrush(Color.FromArgb(128, 0, 255, 0))
            //                    //'    e.Graphics.FillRectangle(br, Rectangle)
            //                    //'End Using
            //                    Using p As New Pen(Color.FromArgb(0, 255, 0), 1)
            //                        e.Graphics.DrawRectangle(p, StartRectangle)
            //                    End Using

            //            } else
            //                {

            //                    StartRectangle.X = DetectedPoint.X + Parent.Rectangle.X
            //                StartRectangle.Y = DetectedPoint.Y + Parent.Rectangle.Y
            //                StartRectangle.Width = PictureBoxObject.Image.Width
            //                StartRectangle.Height = PictureBoxObject.Image.Height

            //            }

            //                if (Node.Mode = Mode.ClickDragRelease)
            //                {
            //                    Using p As New Pen(Color.FromArgb(255, 0, 0), 1)
            //                        e.Graphics.DrawRectangle(p, Node.Rectangle)
            //                    End Using


            //Long StartX = StartRectangle.X + (StartRectangle.Width / 2)
            //    Long StartY = StartRectangle.Y + (StartRectangle.Height / 2)
            //    Long EndX = Node.Rectangle.X + (Node.Rectangle.Width / 2)
            //    Long EndY = Node.Rectangle.Y + (Node.Rectangle.Height / 2)

            //                Using linePen As New Pen(Color.FromArgb(128, 0, 0, 255), 8)
            //                        linePen.StartCap = LineCap.RoundAnchor
            //                        linePen.EndCap = LineCap.ArrowAnchor
            //                        linePen.DashStyle = DashStyle.Dot
            //                        e.Graphics.DrawLine(linePen, StartX, StartY, EndX, EndY)
            //                    End Using

            //            }
            //            }


        }

        private void cmdSetAcceptanceThreshold_Click(object sender, EventArgs e)
        {
            frm.NumericObjectThreshold.Value = NumericUpDown1.Value;
        }

        private void cboChannel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdChannel_Click(object sender, EventArgs e)
        {
            frm.cboChannel.Text = cboChannel.Text;
        }

        private void cmdReTestFromReference_Click(object sender, EventArgs e)
        {
            try
            {
                RunFullTest();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("frmTestObjectSearch_Load:" + ex.Message);
            }
        }
    }
}
