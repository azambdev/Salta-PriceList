namespace PriceList
{
    partial class FormImpresionListaPrecios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImpresionListaPrecios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridViewProductosAsociados = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dropDownListaDePrecios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltroCodigoProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductosAsociados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFiltroCodigoProducto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dropDownListaDePrecios);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1279, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportar);
            this.groupBox2.Controls.Add(this.gridViewProductosAsociados);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1285, 449);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // gridViewProductosAsociados
            // 
            this.gridViewProductosAsociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewProductosAsociados.Location = new System.Drawing.Point(6, 31);
            this.gridViewProductosAsociados.Name = "gridViewProductosAsociados";
            this.gridViewProductosAsociados.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewProductosAsociados.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewProductosAsociados.RowTemplate.Height = 24;
            this.gridViewProductosAsociados.Size = new System.Drawing.Size(1273, 359);
            this.gridViewProductosAsociados.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(1114, 396);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(164, 43);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar>>";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dropDownListaDePrecios
            // 
            this.dropDownListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropDownListaDePrecios.FormattingEnabled = true;
            this.dropDownListaDePrecios.Location = new System.Drawing.Point(186, 34);
            this.dropDownListaDePrecios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropDownListaDePrecios.Name = "dropDownListaDePrecios";
            this.dropDownListaDePrecios.Size = new System.Drawing.Size(445, 28);
            this.dropDownListaDePrecios.TabIndex = 16;
            this.dropDownListaDePrecios.SelectedIndexChanged += new System.EventHandler(this.dropDownListaDePrecios_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Lista de Precios:";
            // 
            // txtFiltroCodigoProducto
            // 
            this.txtFiltroCodigoProducto.Location = new System.Drawing.Point(777, 37);
            this.txtFiltroCodigoProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFiltroCodigoProducto.MaxLength = 20;
            this.txtFiltroCodigoProducto.Name = "txtFiltroCodigoProducto";
            this.txtFiltroCodigoProducto.Size = new System.Drawing.Size(370, 28);
            this.txtFiltroCodigoProducto.TabIndex = 22;
            this.txtFiltroCodigoProducto.TextChanged += new System.EventHandler(this.txtFiltroCodigoProducto_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(689, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Código:";
            // 
            // FormImpresionListaPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 558);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormImpresionListaPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histórico de Lista de Precios";
            this.Load += new System.EventHandler(this.FormImpresionListaPrecios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductosAsociados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridViewProductosAsociados;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ComboBox dropDownListaDePrecios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiltroCodigoProducto;
        private System.Windows.Forms.Label label5;
    }
}