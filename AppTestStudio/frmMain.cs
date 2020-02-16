using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudio
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripButtonToggleScript_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("TEst");
        }

        private void toolStripLoadScript_Click(object sender, EventArgs e)
        {
            if ( tv.Nodes[0].Nodes.Count > 0)
            {
                frmLoadCheck LoadCheck = new frmLoadCheck();
                LoadCheck.StartPosition = FormStartPosition.CenterParent;
                LoadCheck.ShowDialog();

                switch (LoadCheck.Result)
                {
                    case frmLoadCheck.LoadCheckResult.Save:
                        SaveCurrentProject();
                        break;
                    case frmLoadCheck.LoadCheckResult.DontSave:
                        break;
                    case frmLoadCheck.LoadCheckResult.Cancel:
                        return;
                    case frmLoadCheck.LoadCheckResult.DefaultValue:
                        return;
                    default:
                        Debug.Assert(false);  //should not be here.
                        break;
                }
            }

            OpenFileDialog openDLG = new OpenFileDialog();
            openDLG.InitialDirectory = Utils.GetApplicationFolder();
            openDLG.Filter = "App Test Studio files|Default.xml";
            openDLG.RestoreDirectory = true;
            openDLG.Multiselect = false;

            DialogResult Result = openDLG.ShowDialog();
            if ( Result == DialogResult.OK)
            {
                String FileName = openDLG.FileName;
                GameNodeGame Game = GameNodeGame.LoadGameFromFile(FileName, true);

                if ( Game.IsSomething())
                {
                    LoadGameToTree(Game);
                }
            }
        }

        private void LoadGameToTree(GameNodeGame game)
        {
            //Interlocked.Increment()
        }

        private void SaveCurrentProject()
        {
            throw new NotImplementedException();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          // Color Bob = ColorTranslator.FromHtml("#002255ff");
        }
    }
}
