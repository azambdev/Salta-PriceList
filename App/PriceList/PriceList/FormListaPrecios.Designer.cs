
namespace PriceList
{
    partial class FormListaPrecios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaPrecios));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCantidadproductos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dropDownListaDePrecios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFiltroCodigoProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridViewProductosAsociados = new System.Windows.Forms.DataGridView();
            this.dropDownCategorias = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltroDescripcopnProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.porcentajeAplicarProductoSeleccionado = new System.Windows.Forms.NumericUpDown();
            this.txtprecioVentaFinalProductoSeleccionado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAlicuotaIvaProductoSeleccionado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCostoProductoSeleccionado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigoProductoSeleccionado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductosAsociados)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.porcentajeAplicarProductoSeleccionado)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripSeparator5,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1350, 94);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.Image = global::PriceList.Properties.Resources.nuevaListaImagenIcono;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(68, 91);
            this.toolStripButton3.Text = "Nueva";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 94);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = global::PriceList.Properties.Resources.botonGuardar;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(79, 91);
            this.toolStripButton1.Text = "Guardar";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 94);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = global::PriceList.Properties.Resources.botonBuscar;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(68, 91);
            this.toolStripButton2.Text = "Buscar";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 94);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton4.Image = global::PriceList.Properties.Resources.impresoraImagenIcono;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(86, 91);
            this.toolStripButton4.Text = "Imprimir";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton4.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCantidadproductos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dropDownListaDePrecios);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 142);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(962, 92);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listas Disponibles";
            // 
            // lblCantidadproductos
            // 
            this.lblCantidadproductos.AutoSize = true;
            this.lblCantidadproductos.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadproductos.Location = new System.Drawing.Point(687, 53);
            this.lblCantidadproductos.Name = "lblCantidadproductos";
            this.lblCantidadproductos.Size = new System.Drawing.Size(18, 18);
            this.lblCantidadproductos.TabIndex = 16;
            this.lblCantidadproductos.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(527, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Total de productos:";
            // 
            // dropDownListaDePrecios
            // 
            this.dropDownListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropDownListaDePrecios.FormattingEnabled = true;
            this.dropDownListaDePrecios.Location = new System.Drawing.Point(151, 47);
            this.dropDownListaDePrecios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropDownListaDePrecios.Name = "dropDownListaDePrecios";
            this.dropDownListaDePrecios.Size = new System.Drawing.Size(370, 26);
            this.dropDownListaDePrecios.TabIndex = 14;
            this.dropDownListaDePrecios.SelectedIndexChanged += new System.EventHandler(this.dropDownListaDePrecios_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Descripción:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFiltroCodigoProducto);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.gridViewProductosAsociados);
            this.groupBox2.Controls.Add(this.dropDownCategorias);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFiltroDescripcopnProducto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 242);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(962, 405);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productos asociados";
            // 
            // txtFiltroCodigoProducto
            // 
            this.txtFiltroCodigoProducto.Location = new System.Drawing.Point(151, 37);
            this.txtFiltroCodigoProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFiltroCodigoProducto.MaxLength = 20;
            this.txtFiltroCodigoProducto.Name = "txtFiltroCodigoProducto";
            this.txtFiltroCodigoProducto.Size = new System.Drawing.Size(210, 27);
            this.txtFiltroCodigoProducto.TabIndex = 20;
            this.txtFiltroCodigoProducto.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Código:";
            // 
            // gridViewProductosAsociados
            // 
            this.gridViewProductosAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewProductosAsociados.Location = new System.Drawing.Point(11, 134);
            this.gridViewProductosAsociados.Margin = new System.Windows.Forms.Padding(4);
            this.gridViewProductosAsociados.Name = "gridViewProductosAsociados";
            this.gridViewProductosAsociados.RowHeadersWidth = 51;
            this.gridViewProductosAsociados.Size = new System.Drawing.Size(943, 252);
            this.gridViewProductosAsociados.TabIndex = 18;
            this.gridViewProductosAsociados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewProductosAsociados_CellContentClick);
            this.gridViewProductosAsociados.SelectionChanged += new System.EventHandler(this.gridViewProductosAsociados_SelectionChanged);
            // 
            // dropDownCategorias
            // 
            this.dropDownCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropDownCategorias.FormattingEnabled = true;
            this.dropDownCategorias.Location = new System.Drawing.Point(151, 90);
            this.dropDownCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropDownCategorias.Name = "dropDownCategorias";
            this.dropDownCategorias.Size = new System.Drawing.Size(343, 26);
            this.dropDownCategorias.TabIndex = 22;
            this.dropDownCategorias.SelectedIndexChanged += new System.EventHandler(this.dropDownCategorias_SelectedIndexChanged);
            this.dropDownCategorias.SelectionChangeCommitted += new System.EventHandler(this.dropDownCategorias_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Categoría:";
            // 
            // txtFiltroDescripcopnProducto
            // 
            this.txtFiltroDescripcopnProducto.Location = new System.Drawing.Point(520, 37);
            this.txtFiltroDescripcopnProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFiltroDescripcopnProducto.MaxLength = 20;
            this.txtFiltroDescripcopnProducto.Name = "txtFiltroDescripcopnProducto";
            this.txtFiltroDescripcopnProducto.Size = new System.Drawing.Size(282, 27);
            this.txtFiltroDescripcopnProducto.TabIndex = 21;
            this.txtFiltroDescripcopnProducto.TextChanged += new System.EventHandler(this.txtFiltroDescripcopnProducto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(381, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Descripción:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.porcentajeAplicarProductoSeleccionado);
            this.groupBox3.Controls.Add(this.txtprecioVentaFinalProductoSeleccionado);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtAlicuotaIvaProductoSeleccionado);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtCostoProductoSeleccionado);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtCodigoProductoSeleccionado);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(986, 142);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(351, 505);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Precios";
            // 
            // porcentajeAplicarProductoSeleccionado
            // 
            this.porcentajeAplicarProductoSeleccionado.DecimalPlaces = 2;
            this.porcentajeAplicarProductoSeleccionado.Location = new System.Drawing.Point(94, 153);
            this.porcentajeAplicarProductoSeleccionado.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.porcentajeAplicarProductoSeleccionado.Name = "porcentajeAplicarProductoSeleccionado";
            this.porcentajeAplicarProductoSeleccionado.Size = new System.Drawing.Size(87, 27);
            this.porcentajeAplicarProductoSeleccionado.TabIndex = 24;
            this.porcentajeAplicarProductoSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.porcentajeAplicarProductoSeleccionado.ValueChanged += new System.EventHandler(this.porcentajeAplicarProductoSeleccionado_ValueChanged);
            this.porcentajeAplicarProductoSeleccionado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.porcentajeAplicarProductoSeleccionado_KeyPress);
            // 
            // txtprecioVentaFinalProductoSeleccionado
            // 
            this.txtprecioVentaFinalProductoSeleccionado.Location = new System.Drawing.Point(153, 260);
            this.txtprecioVentaFinalProductoSeleccionado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtprecioVentaFinalProductoSeleccionado.MaxLength = 10;
            this.txtprecioVentaFinalProductoSeleccionado.Name = "txtprecioVentaFinalProductoSeleccionado";
            this.txtprecioVentaFinalProductoSeleccionado.ReadOnly = true;
            this.txtprecioVentaFinalProductoSeleccionado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtprecioVentaFinalProductoSeleccionado.Size = new System.Drawing.Size(151, 27);
            this.txtprecioVentaFinalProductoSeleccionado.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Venta Final $:";
            // 
            // txtAlicuotaIvaProductoSeleccionado
            // 
            this.txtAlicuotaIvaProductoSeleccionado.Location = new System.Drawing.Point(94, 205);
            this.txtAlicuotaIvaProductoSeleccionado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAlicuotaIvaProductoSeleccionado.MaxLength = 6;
            this.txtAlicuotaIvaProductoSeleccionado.Name = "txtAlicuotaIvaProductoSeleccionado";
            this.txtAlicuotaIvaProductoSeleccionado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAlicuotaIvaProductoSeleccionado.Size = new System.Drawing.Size(87, 27);
            this.txtAlicuotaIvaProductoSeleccionado.TabIndex = 25;
            this.txtAlicuotaIvaProductoSeleccionado.Text = "0";
            this.txtAlicuotaIvaProductoSeleccionado.TextChanged += new System.EventHandler(this.txtAlicuotaIvaProductoSeleccionado_TextChanged);
            this.txtAlicuotaIvaProductoSeleccionado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlicuotaIvaProductoSeleccionado_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "Al. IVA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "% Gan:";
            // 
            // txtCostoProductoSeleccionado
            // 
            this.txtCostoProductoSeleccionado.Location = new System.Drawing.Point(93, 97);
            this.txtCostoProductoSeleccionado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCostoProductoSeleccionado.MaxLength = 10;
            this.txtCostoProductoSeleccionado.Name = "txtCostoProductoSeleccionado";
            this.txtCostoProductoSeleccionado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostoProductoSeleccionado.Size = new System.Drawing.Size(111, 27);
            this.txtCostoProductoSeleccionado.TabIndex = 23;
            this.txtCostoProductoSeleccionado.Text = "0";
            this.txtCostoProductoSeleccionado.TextChanged += new System.EventHandler(this.txtCostoProductoSeleccionado_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "$ Costo:";
            // 
            // txtCodigoProductoSeleccionado
            // 
            this.txtCodigoProductoSeleccionado.Location = new System.Drawing.Point(93, 46);
            this.txtCodigoProductoSeleccionado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoProductoSeleccionado.MaxLength = 20;
            this.txtCodigoProductoSeleccionado.Name = "txtCodigoProductoSeleccionado";
            this.txtCodigoProductoSeleccionado.ReadOnly = true;
            this.txtCodigoProductoSeleccionado.Size = new System.Drawing.Size(211, 27);
            this.txtCodigoProductoSeleccionado.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Código:";
            // 
            // FormListaPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 646);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormListaPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Precios";
            this.Load += new System.EventHandler(this.FormListaPrecios_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductosAsociados)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.porcentajeAplicarProductoSeleccionado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox dropDownListaDePrecios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltroDescripcopnProducto;
        private System.Windows.Forms.DataGridView gridViewProductosAsociados;
        private System.Windows.Forms.ComboBox dropDownCategorias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCantidadproductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TextBox txtFiltroCodigoProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoProductoSeleccionado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlicuotaIvaProductoSeleccionado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCostoProductoSeleccionado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtprecioVentaFinalProductoSeleccionado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown porcentajeAplicarProductoSeleccionado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}