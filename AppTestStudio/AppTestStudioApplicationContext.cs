using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudio
{
    //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.applicationcontext?redirectedfrom=MSDN&view=net-5.0
    class AppTestStudioApplicationContext : ApplicationContext 
    {
        private frmMain frmMain;
        private frmNotify frmNotify;

        public AppTestStudioApplicationContext()
        {
            Application.ApplicationExit += Application_ApplicationExit;

            frmNotify = new frmNotify(4); 
            frmMain = new frmMain();
            

            frmMain.FormClosed += FrmMain_FormClosed;
            frmMain.FormClosing += FrmMain_FormClosing;

            frmNotify.FormClosed += FrmNotify_FormClosed;
            frmNotify.FormClosing += FrmNotify_FormClosing;

            frmMain.Show();
            
        }

        private void FrmNotify_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("FrmNotify_FormClosing");
        }

        private void FrmNotify_FormClosed(object sender, FormClosedEventArgs e)
        {
            Debug.WriteLine("FrmNotify_FormClosed");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("FrmMain_FormClosing");
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitThread();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Debug.WriteLine("Application_ApplicationExit");
        }
    }
}
