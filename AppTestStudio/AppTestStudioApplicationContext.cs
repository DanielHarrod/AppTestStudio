//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.


using System.Diagnostics;

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
