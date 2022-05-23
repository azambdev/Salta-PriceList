using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["FormProductos"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FormProductos"].Activate();
            }
            else
            {
                FormProductos frm = new FormProductos();
                // frm.MdiParent = this;
                // frm.Dock = DockStyle.;
                frm.Show();

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["FormListaPrecios"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FormListaPrecios"].Activate();
            }
            else
            {
                FormListaPrecios frmLista = new FormListaPrecios();
                // frm.MdiParent = this;
                // frm.Dock = DockStyle.;
                frmLista.Show();

            }


        }
    }
}
