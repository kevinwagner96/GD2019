namespace FrbaOfertas.ComprarOferta
{
    partial class ListadoOfertas
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
            this.comprar = new System.Windows.Forms.Button();
            this.dataGridOfertas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOfertas)).BeginInit();
            this.SuspendLayout();
            // 
            // comprar
            // 
            this.comprar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comprar.Location = new System.Drawing.Point(679, 422);
            this.comprar.Name = "comprar";
            this.comprar.Size = new System.Drawing.Size(75, 23);
            this.comprar.TabIndex = 11;
            this.comprar.Text = "Comprar";
            this.comprar.UseVisualStyleBackColor = true;
            this.comprar.Click += new System.EventHandler(this.comprar_Click);
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
            this.dataGridOfertas.Location = new System.Drawing.Point(12, 12);
            this.dataGridOfertas.MultiSelect = false;
            this.dataGridOfertas.Name = "dataGridOfertas";
            this.dataGridOfertas.ReadOnly = true;
            this.dataGridOfertas.Size = new System.Drawing.Size(742, 404);
            this.dataGridOfertas.TabIndex = 7;
            // 
            // ListadoOfertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 457);
            this.Controls.Add(this.comprar);
            this.Controls.Add(this.dataGridOfertas);
            this.Name = "ListadoOfertas";
            this.Text = "ComprarOferta";
            this.Load += new System.EventHandler(this.ComprarOferta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOfertas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button comprar;
        private System.Windows.Forms.DataGridView dataGridOfertas;
    }
}