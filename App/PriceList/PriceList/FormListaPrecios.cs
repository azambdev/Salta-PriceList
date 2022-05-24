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
    public partial class FormListaPrecios : Form
    {
        public FormListaPrecios()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["FormNuevaListaPrecios"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FormNuevaListaPrecios"].Activate();
            }
            else
            {
                FormNuevaListaPrecios frmLista = new FormNuevaListaPrecios();
                // frm.MdiParent = this;
                // frm.Dock = DockStyle.;
                frmLista.Show();

            }


        }

        private void FormListaPrecios_Load(object sender, EventArgs e)
        {




            BLogic.Categoria categoria = new BLogic.Categoria();
            List<BLogic.Categoria> listaCategorias = categoria.GetCategorias();

            if (listaCategorias.Any())
            {
                foreach (var item in listaCategorias)
                {
                    dropDownCategorias.Items.Add(item.Codigo() + " - " + item.Descripcion());
                }
                dropDownCategorias.SelectedIndex = 0;
            }


        }
    }
}
