using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainUI
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void scanModel1_Load(object sender, EventArgs e)
        {

        }
    }
}
static class ControlExtensions
{
    static public void UIThread(this Control control, System.Action code)
    {
        if (control.InvokeRequired)
        {
            control.BeginInvoke(code);
            return;
        }
        code.Invoke();
    }

    static public void UIThreadInvoke(this Control control, System.Action code)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(code);
            return;
        }
        code.Invoke();
    }
}

