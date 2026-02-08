using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudioControls
{
    public class MaskChangedEventArgs : EventArgs
    {
        public Rectangle NewValue { get; }

        public MaskChangedEventArgs(Rectangle newValue)
        {
            NewValue = newValue;
        }
    }

    public partial class ATSMaskSettings : UserControl
    {
        public ATSMaskSettings()
        {
            InitializeComponent();
        }

        private Rectangle mScreenRectangle;

        public Rectangle ScreenRectangle
        {
            get
            {
                return mScreenRectangle;
            }
            set
            {
                if (mScreenRectangle != value)
                {
                    mScreenRectangle = value;
                    numMaskX.Maximum = mScreenRectangle.Width;
                    numMaskY.Maximum = mScreenRectangle.Height;
                    numMaskWidth.Maximum = mScreenRectangle.Width;
                    numMaskHeight.Maximum = mScreenRectangle.Height;
                }
            }
        }

        private Rectangle mMaskRectangle;

        public Rectangle MaskRectangle
        {
            get
            {
                return mMaskRectangle;
            }
            set
            {
                if (mMaskRectangle != value)
                {
                    mMaskRectangle = value;
                    numMaskX.Value = mMaskRectangle.X;
                    numMaskY.Value = mMaskRectangle.Y;
                    numMaskWidth.Value = mMaskRectangle.Width;
                    numMaskHeight.Value = mMaskRectangle.Height;
                }
            }
        }

        private void ATSMaskSettings_Load(object sender, EventArgs e)
        {

        }

        private void numMaskX_ValueChanged(object sender, EventArgs e)
        {
            MaskChanged?.Invoke(this, new MaskChangedEventArgs(new Rectangle((int)numMaskX.Value, (int)numMaskY.Value, (int)numMaskWidth.Value, (int)numMaskHeight.Value)));
        }

        public event EventHandler<MaskChangedEventArgs> MaskChanged;
    }
}
