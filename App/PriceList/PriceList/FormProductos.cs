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
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
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

        public bool FaltaCompletar(string campo)
        {
            if (campo.Length == 0)
            {
                return true;
            }
            return false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (FaltaCompletar(CodigoProducto()))
            {
                MessageBox.Show("Debe completar el código del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (FaltaCompletar(DescripcionDelProducto()))
            {
                MessageBox.Show("Debe completar la descripción del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }






        }


        private string CodigoProducto()
        {
            return txtCodigoProducto.Text;
        }

        private string DescripcionDelProducto()
        {
            return txtDescripcionProducto.Text;
        }
    }
}
