namespace FrbaOfertas.ListadoEstadistico
{
    partial class Listados
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.ComboBox();
            this.semestre = new System.Windows.Forms.ComboBox();
            this.anio = new System.Windows.Forms.ComboBox();
            this.limpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listadosGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tipo);
            this.groupBox1.Controls.Add(this.semestre);
            this.groupBox1.Controls.Add(this.anio);
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 43);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Tipo de Listado:";
            // 
            // tipo
            // 
            this.tipo.FormattingEnabled = true;
            this.tipo.Location = new System.Drawing.Point(480, 14);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(213, 21);
            this.tipo.TabIndex = 44;
            this.tipo.Tag = "Tipo Pago";
            // 
            // semestre
            // 
            this.semestre.FormattingEnabled = true;
            this.semestre.Location = new System.Drawing.Point(226, 16);
            this.semestre.Name = "semestre";
            this.semestre.Size = new System.Drawing.Size(112, 21);
            this.semestre.TabIndex = 43;
            this.semestre.Tag = "Tipo Pago";
            // 
            // anio
            // 
            this.anio.FormattingEnabled = true;
            this.anio.Location = new System.Drawing.Point(42, 16);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(103, 21);
            this.anio.TabIndex = 42;
            this.anio.Tag = "Tipo Pago";
            // 
            // limpiar
            // 
            this.limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.limpiar.Location = new System.Drawing.Point(699, 14);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Listar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Semestre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año:";
            // 
            // listadosGrid
            // 
            this.listadosGrid.AllowUserToAddRows = false;
            this.listadosGrid.AllowUserToDeleteRows = false;
            this.listadosGrid.AllowUserToOrderColumns = true;
            this.listadosGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listadosGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadosGrid.Location = new System.Drawing.Point(12, 60);
            this.listadosGrid.MultiSelect = false;
            this.listadosGrid.Name = "listadosGrid";
            this.listadosGrid.ReadOnly = true;
            this.listadosGrid.Size = new System.Drawing.Size(780, 403);
            this.listadosGrid.TabIndex = 5;
            this.listadosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listadosGrid_CellContentClick);
            // 
            // Listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 475);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listadosGrid);
            this.Name = "Listados";
            this.Text = "Listados Estadisticos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadosGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listadosGrid;
        private System.Windows.Forms.ComboBox anio;
        private System.Windows.Forms.ComboBox semestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tipo;
    }
}