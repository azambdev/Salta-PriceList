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
        public FormProductos()
        {
            InitializeComponent();
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
                BLogic.Producto productoConsultado = _productos.Find(x => x.Codigo() == CodigoProducto());
                if (productoConsultado != null)
                {
                    CargarProductoEnFormulario(productoConsultado);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }

        private void CargarProductoEnFormulario(Producto productoConsultado)
        {
            txtCodigoProducto.Text = productoConsultado.Codigo();
            txtDescripcionProducto.Text = productoConsultado.Descripcion();
            checkBoxActivo.Checked = productoConsultado.Activo();
            dropDownCategorias.SelectedItem = productoConsultado.Categoria().Descripcion();


            byte[] imageArray = productoConsultado.Imagen();
            ImageConverter converter = new ImageConverter();
            pictureBoxProducto.Image = (Image)converter.ConvertFrom(imageArray);

            //pictureBoxProducto.Image = ByteToImage(productoConsultado.Imagen()); // byteArr holds byte array value
        }


        //public static Bitmap ByteToImage(byte[] blob)
        //{

        //    byte[] imageArray = blob
        //ImageConverter converter = new ImageConverter();
        //    pictureButton.Image = (Image)converter.ConvertFrom(imageArray);

        //    byte[] imageSource = blob;
        //    Bitmap image;
        //    using (MemoryStream stream = new MemoryStream(imageSource))
        //    {
        //        image = new Bitmap(stream);
        //    }
        //    return image;


        //}




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



            try
            {

                BLogic.Categoria categoriaSeleccionada = _listaCategorias.Find(x => x.Descripcion() == CategoriaSeleccionada());

                BLogic.Producto producto = new BLogic.Producto(0, CodigoProducto(), categoriaSeleccionada, DescripcionDelProducto(), ProductoEsActivo(), Imagen());
                producto.Create();
                LimpiarFormulario();
                MessageBox.Show("Producto creado correctamente", "Validación de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void LimpiarFormulario()
        {
            txtCodigoProducto.Clear();
            txtDescripcionProducto.Clear();
            dropDownCategorias.SelectedIndex = 0;
            pictureBoxProducto.Image = null;
            checkBoxActivo.Checked = false;

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

        private byte[] Imagen()
        {
            Image img = pictureBoxProducto.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            return arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                // open file dialog   
                OpenFileDialog open = new OpenFileDialog();
                // image filters  
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box  
                    pictureBoxProducto.Image = new Bitmap(open.FileName);
                    // image file path  
                    //textBox1.Text = open.FileName;
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
            // Check here tab press or not
            if (e.KeyCode == Keys.Tab)
            {
                CargarProductoPorCodigo();


                // our code here
            }


        }

        private void txtCodigoProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                CargarProductoPorCodigo();


                // our code here
            }
        }
    }
}
