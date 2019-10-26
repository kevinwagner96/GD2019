namespace FrbaOfertas.ConsumirOferta
{
    partial class ListadoCupones
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
            this.canjear = new System.Windows.Forms.Button();
            this.dataGridOfertas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cod_compra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOfertas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canjear
            // 
            this.canjear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.canjear.Location = new System.Drawing.Point(680, 435);
            this.canjear.Name = "canjear";
            this.canjear.Size = new System.Drawing.Size(75, 23);
            this.canjear.TabIndex = 13;
            this.canjear.Text = "Entregar";
            this.canjear.UseVisualStyleBackColor = true;
            this.canjear.Click += new System.EventHandler(this.canjear_Click);
            // 
            // dataGridOfertas
            // 
            this.dataGridOfertas.AllowUserToAddRows = false;
            this.dataGridOfertas.AllowUserToDeleteRows = false;
            this.dataGridOfertas.AllowUserToOrderColumns = true;
            this.dataGridOfertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOfertas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOfertas.Location = new System.Drawing.Point(12, 61);
            this.dataGridOfertas.MultiSelect = false;
            this.dataGridOfertas.Name = "dataGridOfertas";
            this.dataGridOfertas.ReadOnly = true;
            this.dataGridOfertas.Size = new System.Drawing.Size(743, 363);
            this.dataGridOfertas.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cod_compra);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 43);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // buscar
            // 
            this.buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buscar.Location = new System.Drawing.Point(582, 14);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 8;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.limpiar.Location = new System.Drawing.Point(663, 14);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo";
            // 
            // cod_compra
            // 
            this.cod_compra.Location = new System.Drawing.Point(53, 16);
            this.cod_compra.Name = "cod_compra";
            this.cod_compra.Size = new System.Drawing.Size(100, 20);
            this.cod_compra.TabIndex = 0;
            this.cod_compra.Tag = "LIKE";
            // 
            // ListadoCupones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.canjear);
            this.Controls.Add(this.dataGridOfertas);
            this.Name = "ListadoCupones";
            this.Text = "ListadoCupones";
            this.Load += new System.EventHandler(this.ListadoCupones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOfertas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button canjear;
        private System.Windows.Forms.DataGridView dataGridOfertas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cod_compra;
    }
}