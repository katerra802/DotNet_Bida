using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Windows.Forms;

namespace bida_test
{
    public partial class inHoaDon : Form
    {
        public inHoaDon()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

