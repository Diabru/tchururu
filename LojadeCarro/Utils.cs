using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    internal class Utils
    {
        public static void LimparCampos(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is MaskedTextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)(c)).SelectedIndex = -1;
                }
                if (c.HasChildren)
                {
                    LimparCampos(c);
                }
            }
        }

    }
}
