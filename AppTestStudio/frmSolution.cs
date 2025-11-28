//AppTestStudio 
//Copyright(C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using AppTestStudio.solution;
using OpenCvSharp.Internal.Vectors;
using OpenCvSharp.XImgProc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace AppTestStudio
{
    internal partial class frmSolution : Form
    {
        private frmMain frmMain = null;
        public enum ColumnType : int
        {
            Aarow = 0,
            Index = 1,
            NodeName = 2,
            MessageName = 3,
            Position = 4,
            X = 5,
            Y = 6,
            ExecutionTime = 7,
            AfterDelay = 8,
            CumulativeTime = 9

        }
        GamePassSolution GamePassSolution;
        internal frmSolution(GamePassSolution gamePassSolution, frmMain frmMain)
        {
            GamePassSolution = gamePassSolution;
            InitializeComponent();
            this.frmMain = frmMain;
        }

        private void frmSolution_Load(object sender, EventArgs e)
        {

            lblRunTime.Text = "";

            pictureBox1.Image = GamePassSolution.Bitmap;

            AddString($"GameName={GamePassSolution.GameName}");
            AddString($"Solution Count={GamePassSolution.Solutions.Count}");
            lblProject.Text = GamePassSolution.GameName;

            int GridCount = 0;

            int RuntimeMS = 0;

            int CurrentRunTime = 0;
            foreach (ISolution solution in GamePassSolution.Solutions)
            {
                if (solution is ActionSolution)
                {
                    ActionSolution? actionSolution = solution as ActionSolution;
                    AddString($"EventType={actionSolution.EventType.ToString()}");
                    AddString($"ActionSolution: Messages={actionSolution.Messages.Count}, Inputs={actionSolution.ATSInputs.Count}");
                    if (actionSolution.Messages.Count > 0)
                    {
                        MouseSolutionMessage Firstsd = actionSolution.Messages[0];
                        MouseSolutionMessage Last = actionSolution.Messages[actionSolution.Messages.Count - 1];
                        //AddString($"MouseMove: ({First.CalcX},{First.CalcY}) -> ({Last.CalcX},{Last.CalcY}) Events:{actionSolution.Messages.Count} ms:{actionSolution.RuntimeMS} "); 
                    }
                    RuntimeMS += actionSolution.RuntimeMS;

                    foreach (KeyboardCommand cmd in actionSolution.KeyboardCommands)
                    {
                        CurrentRunTime += cmd.Delayms;

                        int index = grd.Rows.Add();
                        grd.Rows[index].Cells[(int)ColumnType.Aarow].Value = "";
                        grd.Rows[index].Cells[(int)ColumnType.Index].Value = GridCount;
                        grd.Rows[index].Cells[(int)ColumnType.NodeName].Value = solution.NodeName;
                        grd.Rows[index].Cells[(int)ColumnType.MessageName].Value = "Keyboard";
                        grd.Rows[index].Cells[(int)ColumnType.X].Value = cmd.PrintScanCode();
                        grd.Rows[index].Cells[(int)ColumnType.Y].Value = cmd.ButtonState.ToString();
                        grd.Rows[index].Cells[(int)ColumnType.ExecutionTime].Value = cmd.ExecutionTime.ToString("HH:mm:ss.fff");
                        grd.Rows[index].Cells[(int)ColumnType.AfterDelay].Value = cmd.Delayms.ToString();
                        grd.Rows[index].Cells[(int)ColumnType.CumulativeTime].Value = CurrentRunTime;

                        GridCount++;

                    }

                    foreach (MouseSolutionMessage item in actionSolution.Messages)
                    {
                        CurrentRunTime += item.AfterDelay;

                        int index = grd.Rows.Add();
                        grd.Rows[index].Cells[(int)ColumnType.Aarow].Value = "";
                        grd.Rows[index].Cells[(int)ColumnType.Index].Value = GridCount;
                        grd.Rows[index].Cells[(int)ColumnType.NodeName].Value = solution.NodeName;
                        grd.Rows[index].Cells[(int)ColumnType.MessageName].Value = item.MessageName();
                        grd.Rows[index].Cells[(int)ColumnType.X].Value = item.CalcX.ToString();
                        grd.Rows[index].Cells[(int)ColumnType.Y].Value = item.CalcY.ToString();
                        grd.Rows[index].Cells[(int)ColumnType.ExecutionTime].Value = item.ExecutionTime.ToString("HH:mm:ss.fff");
                        grd.Rows[index].Cells[(int)ColumnType.AfterDelay].Value = item.AfterDelay.ToString();
                        grd.Rows[index].Cells[(int)ColumnType.CumulativeTime].Value = CurrentRunTime;

                        GridCount++;
                    }

                    foreach (ATSInput item in actionSolution.ATSInputs)
                    {
                        CurrentRunTime += item.AfterDelay;

                        int index = grd.Rows.Add();
                        grd.Rows[index].Cells[(int)ColumnType.Aarow].Value = "";
                        grd.Rows[index].Cells[(int)ColumnType.Index].Value = GridCount;
                        grd.Rows[index].Cells[(int)ColumnType.NodeName].Value = solution.NodeName;
                        grd.Rows[index].Cells[(int)ColumnType.MessageName].Value = item.MessageName();
                        grd.Rows[index].Cells[(int)ColumnType.Position].Value = item.MessageName();
                        int XPos = item.CalcX;
                        int YPos = item.CalcY;
                        String Position = "";
                        if (XPos > GamePassSolution.Bitmap.Width)
                        {
                            Position = "Desk";
                        }
                        else
                        {
                            Position = "App";
                        }
                        grd.Rows[index].Cells[(int)ColumnType.Position].Value = Position;
                        grd.Rows[index].Cells[(int)ColumnType.X].Value = XPos.ToString();
                        grd.Rows[index].Cells[(int)ColumnType.Y].Value = YPos.ToString();
                        grd.Rows[index].Cells[(int)ColumnType.ExecutionTime].Value = item.ExecutionTime.ToString("HH:mm:ss.fff");
                        grd.Rows[index].Cells[(int)ColumnType.AfterDelay].Value = item.AfterDelay.ToString();
                        grd.Rows[index].Cells[(int)ColumnType.CumulativeTime].Value = CurrentRunTime;
                    }

                    continue;
                }

                if (solution is EventSolution)
                {
                    EventSolution eventSolution = (EventSolution)solution;

                    AddString($"EventSolution: ClickList={eventSolution.ClickList.Count}");

                    continue;
                }
            }

            lblRunTime.Text = $"{RuntimeMS}ms";

            hScrollBar1.Maximum = RuntimeMS;

        }

        private void AddString(string s)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = s;
            }
            else
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + s;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void cmdAnimate_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int velocity = 500;

            //int positions = hScrollBar1.Maximum; 
            //hScrollBar1.Value = hScrollBar1.Value + 1
        }

        private void grd_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void grd_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                // Header row.
                return;
            }

            String Action = grd.Rows[e.RowIndex].Cells[3].Value.ToString();
            X = grd.Rows[e.RowIndex].Cells[(int)ColumnType.X].Value.ToInt();
            Y = grd.Rows[e.RowIndex].Cells[(int)ColumnType.Y].Value.ToInt();

            Debug.Print($"grd_CellMouseEnterRI = {e.RowIndex} {Action} {X},{Y}");

            switch (Action)
            {
                case "MouseMove":
                case "Mouse Move":
                    DrawMode = "MouseMove";
                    pictureBox1.Invalidate();
                    break;
                default:
                    break;
            }

        }

        String DrawMode = "";
        int X = 0;
        int Y = 0;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);
            String Action = "DrawCrossHair";

            switch (DrawMode)
            {
                case "MouseMove":
                    Action = "DrawCrossHair";
                    break;
                case "LeftButtonUp":
                    Action = "DrawCrossHair";
                    break;
                case "LeftButtonDown":
                    Action = "DrawCrossHair";
                    break;
                default:
                    break;
            }


            switch (Action)
            {
                case "DrawCrossHair":
                    g.DrawLine(p, X, 0, X, Y - 1);
                    g.DrawLine(p, X, pictureBox1.Image.Height, X, Y - 1);
                    g.DrawLine(p, 0, Y - 1, X + 1, Y - 1);
                    g.DrawLine(p, pictureBox1.Image.Width, Y - 1, X + 1, Y - 1);
                    break;

                default:
                    break;
            }
        }

        private void cmdAddImageToProject_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddNewNode frmAddNewNode = new frmAddNewNode(GamePassSolution, frmMain.tv.SelectedNode.FullPath);
                frmAddNewNode.ShowDialog();

                if (frmAddNewNode.ExitAndTargetNewNode)
                {
                    frmMain.AddNewNode(frmAddNewNode.NodeName, frmAddNewNode.IsAction, !frmAddNewNode.UseRootNode, frmAddNewNode.ChildNodeTop, pictureBox1.Image as Bitmap);
                    Hide();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("cmdAddImageToProject_Click failed. ex=" + ex.Message);
            }
        }
    }
}

