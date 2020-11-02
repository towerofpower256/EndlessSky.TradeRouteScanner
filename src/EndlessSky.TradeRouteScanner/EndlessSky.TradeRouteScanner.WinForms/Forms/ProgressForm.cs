using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndlessSky.TradeRouteScanner.WinForms.Forms
{
    public partial class ProgressForm : Form
    {
        public event EventHandler<EventArgs> OnCancel;

        private bool _canClose = false;

        public ProgressForm()
        {
            InitializeComponent();
        }

        public delegate void CloseSafeDelegate();
        public void CloseSafe()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CloseSafeDelegate(CloseSafe));
                return;
            }

            this.Close();
        }

        public delegate void SetProgressDelegate(int value, int max);
        public void SetProgress(int value, int max)
        {
            if (progMain.InvokeRequired)
            {
                progMain.Invoke(new SetProgressDelegate(SetProgress), new object[] { value, max });
                return;
            }

            if (max <= 0)
            {
                progMain.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                if (progMain.Style != ProgressBarStyle.Continuous) progMain.Style = ProgressBarStyle.Continuous;
                if (value > max) value = max;
                if (value < 0) value = 0;

                var valueNorm = (int)(((float)value / (float)max) * 100);
                progMain.Value = valueNorm;
            }
        }

        public delegate void SetMessageDelegate(string msg);
        public void SetMessage(string msg)
        {
            if (lblMain.InvokeRequired)
            {
                lblMain.Invoke(new SetMessageDelegate(SetMessage), new object[] { msg });
                return;
            }

            lblMain.Text = msg;
        }

        private void DoCancel()
        {
            OnCancel?.Invoke(this, new EventArgs());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DoCancel();
        }
    }
}
