using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna;
using Guna.UI2.WinForms;

namespace bida_test
{
    public class vailidexInput
    {
        public bool checkAlltxtNull(Form x)
        {
            foreach (Control c in x.Controls)
            {
                if(c is TextBox || c is Guna2TextBox)
                {
                    if (c.Text.Length == 0)
                        return false;
                }
            }
            return true;
        }

        public bool checkOnetxtNull(TextBox txt)
        {
            if (txt.Text.Length == 0)
                return false;
            return true;
        }

        public bool checkOnetxtNull(Guna2TextBox txt)
        {
            if (txt.Text.Length == 0)
                return false;
            return true;
        }

        public void checkSpace(KeyPressEventArgs e, Control ctr, TextBox txt)
        {
            if (txt.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }
            else if (txt.Text[txt.Text.Length - 1] == ' ')
            {
                e.Handled = true;
                return;
            }
        }

        public void checktxt(object sender,KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            TextBox txt = (TextBox)sender;

            if (!Char.IsLetter(e.KeyChar) && !Char.IsDigit(e.KeyChar)
                && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                return;
            }
            else if (e.KeyChar == ' ')
            {
                checkSpace(e, ctr, txt);
            }
            else return;
        }

        public void checktxtOnlyText(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            TextBox txt = (TextBox)sender;

            if (!Char.IsLetter(e.KeyChar)
                && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                return;
            }
            else if (e.KeyChar == ' ')
            {
                checkSpace(e, ctr, txt);
            }
            else return;
        }

        public void checktxtOnlyNumber(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            TextBox txt = (TextBox)sender;

            if (!Char.IsDigit(e.KeyChar)
                && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            else return;
        }

        public void clearTxt(Form f)
        {
            foreach (Control c in f.Controls)
            {
                if(c is TextBox txt)
                {
                    txt.Clear();
                }
            }
        }
    }
}
