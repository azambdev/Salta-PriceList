using BLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceList
{
    public partial class FormProductos : Form
    {
        private static FormProductos _instance;

        public FormProductos()
        {
            InitializeComponent();
            _instance = this;
        }

        private List<BLogic.Categoria> _listaCategorias;
        private List<BLogic.Producto> _productos;

        private void FormProductos_Load(object sender, EventArgs e)
        {
            BLogic.Categoria categoria = new BLogic.Categoria();
            List<BLogic.Categoria> listaCategorias = categoria.GetCategorias();
            _listaCategorias = listaCategorias;
            if (listaCategorias.Any())
            {
                foreach (var item in listaCategorias)
                {
                    dropDownCategorias.Items.Add(item.Descripcion());
                }
                dropDownCategorias.SelectedIndex = 0;
            }
            BLogic.Producto producto = new BLogic.Producto();
            _productos = producto.GetProductos();
        }

        public void CargarProductoPorCodigo()
        {
            try
            {
                BLogic.Producto productoConsultado = _productos.Find(x => x.Codigo() == CodigoCompleto());
                if (productoConsultado != null)
                {
                    CargarProductoEnFormulario(productoConsultado);
                    BloquearCamposDeFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void CargarProductoPorCodigo(string codigo)
        {
            try
            {
                BLogic.Producto productoConsultado = _productos.Find(x => x.Codigo() == codigo);
                if (productoConsultado != null)
                {
                    CargarProductoEnFormulario(productoConsultado);
                    BloquearCamposDeFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void BloquearCamposDeFormulario()
        {
            txtCodigoProducto.Enabled = false;
            dropDownCategorias.Enabled = false;
        }

        private byte[] Imagen()
        {
            byte[] imageData = Array.Empty<byte>();

            if (txtCodigoProducto.Enabled == true)
            {
                if (txtNombreArchivoFoto.Text.Length > 0)
                {
                    imageData = File.ReadAllBytes(txtNombreArchivoFoto.Text);
                    return imageData;
                }
            }
            else
            {
                imageData = ImageToByteArray(pictureBoxProducto.Image);
            }
            return imageData;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void CargarProductoEnFormulario(Producto productoConsultado)
        {
            txtCodigoProducto.Text = productoConsultado.Codigo().Split('-').Last();
            txtDescripcionProducto.Text = productoConsultado.Descripcion(); ;
            checkBoxActivo.Checked = productoConsultado.Activo();
            dropDownCategorias.SelectedItem = productoConsultado.Categoria().Descripcion();

            byte[] imageArray = productoConsultado.Imagen();
            if (imageArray.Length > 0)
            {
                ImageConverter converter = new ImageConverter();
                MemoryStream stmBLOBData = new MemoryStream(productoConsultado.Imagen());
                pictureBoxProducto.Image = Image.FromStream(stmBLOBData);
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

        private string CodigoCategoria()
        {
            return txtCodigoCategoria.Text.Trim();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Enabled == true)
            {
                GuardarProducto();
            }
            else
            {
                ActualizarProducto();
            }
        }

        private void GuardarProducto()
        {
            if (FaltaCompletar(CodigoProducto().Trim()))
            {
                MessageBox.Show("Debe completar el código del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (FaltaCompletar(DescripcionDelProducto().Trim()))
            {
                MessageBox.Show("Debe completar la descripción del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ExisteProducto(CodigoCompleto()))
            {
                MessageBox.Show("El código de producto ingresado ya existe en la base de datos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BLogic.Categoria categoriaSeleccionada = _listaCategorias.Find(x => x.Descripcion() == CategoriaSeleccionada());
                BLogic.Producto producto = new BLogic.Producto(0, CodigoCompleto(), categoriaSeleccionada, DescripcionDelProducto().Trim(), ProductoEsActivo(), Imagen());
                producto.Create();
                LimpiarFormulario();
                MessageBox.Show("Producto creado correctamente", "Validación de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _productos = producto.GetProductos();

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void ActualizarProducto()
        {
            if (FaltaCompletar(CodigoProducto().Trim()))
            {
                MessageBox.Show("Debe completar el código del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (FaltaCompletar(DescripcionDelProducto().Trim()))
            {
                MessageBox.Show("Debe completar la descripción del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BLogic.Categoria categoriaSeleccionada = _listaCategorias.Find(x => x.Descripcion() == CategoriaSeleccionada());
                BLogic.Producto producto = new BLogic.Producto(0, CodigoCompleto(), categoriaSeleccionada, DescripcionDelProducto().Trim(), ProductoEsActivo(), Imagen());
                producto.Update();
                LimpiarFormulario();
                MessageBox.Show("Producto actualizado correctamente", "Validación de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _productos = producto.GetProductos();

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ExisteProducto(string codigoDeProducto)
        {
            return _productos.Any(x => x.Codigo() == codigoDeProducto);
        }

        private string CodigoCompleto()
        {
            return CodigoCategoria().Trim() + "-" + CodigoProducto().Trim();
        }

        private void LimpiarFormulario()
        {
            txtCodigoProducto.Clear();
            txtDescripcionProducto.Clear();
            dropDownCategorias.SelectedIndex = 0;
            dropDownCategorias.Enabled = true;
            pictureBoxProducto.Image = null;
            checkBoxActivo.Checked = false;
            txtCodigoProducto.Enabled = true;
            txtNombreArchivoFoto.Clear();
        }

        private string CodigoProducto()
        {
            return txtCodigoProducto.Text;
        }

        private string DescripcionDelProducto()
        {
            return txtDescripcionProducto.Text;
        }

        private string CategoriaSeleccionada()
        {
            return dropDownCategorias.SelectedItem.ToString();
        }

        private bool ExisteImagen()
        {
            return pictureBoxProducto.Image != null;

        }

        private bool ProductoEsActivo()
        {
            return checkBoxActivo.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // open file dialog   
                OpenFileDialog open = new OpenFileDialog();
                // image filters  
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxProducto.Image = new Bitmap(open.FileName);
                    txtNombreArchivoFoto.Text = open.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                CargarProductoPorCodigo();
            }
        }

        private void txtCodigoProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                CargarProductoPorCodigo();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtCodigoProducto.Enabled = true;
            dropDownCategorias.Enabled = true;
        }

        private void dropDownCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoCategoria.Text = _listaCategorias.Find(x => x.Descripcion().ToString() == dropDownCategorias.SelectedItem.ToString()).Codigo();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FormBuscarProductos"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FormBuscarProductos"].Activate();
            }
            else
            {
                FormBuscarProductos frm = new FormBuscarProductos(_listaCategorias, _productos, this);
                // frm.MdiParent = this;
                // frm.Dock = DockStyle.;
                frm.ShowDialog();

            }
        }
    }
}
