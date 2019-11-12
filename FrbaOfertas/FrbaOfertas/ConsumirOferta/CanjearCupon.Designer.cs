namespace FrbaOfertas.ConsumirOferta
{
    partial class CanjearCupon
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
            this.label2 = new System.Windows.Forms.Label();
            this.clie_nombre = new System.Windows.Forms.TextBox();
            this.seleccionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.id_compra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guardar = new System.Windows.Forms.Button();
            this.seleecionar_proveedor = new System.Windows.Forms.Button();
            this.nombre_proveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Cliente *";
            // 
            // clie_nombre
            // 
            this.clie_nombre.Enabled = false;
            this.clie_nombre.Location = new System.Drawing.Point(114, 88);
            this.clie_nombre.Name = "clie_nombre";
            this.clie_nombre.Size = new System.Drawing.Size(123, 20);
            this.clie_nombre.TabIndex = 41;
            this.clie_nombre.Tag = "Cliente";
            // 
            // seleccionar
            // 
            this.seleccionar.Enabled = false;
            this.seleccionar.Location = new System.Drawing.Point(243, 88);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(81, 20);
            this.seleccionar.TabIndex = 43;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Cod. Cupon *";
            // 
            // id_compra
            // 
            this.id_compra.Enabled = false;
            this.id_compra.Location = new System.Drawing.Point(114, 62);
            this.id_compra.Name = "id_compra";
            this.id_compra.Size = new System.Drawing.Size(210, 20);
            this.id_compra.TabIndex = 44;
            this.id_compra.Tag = "Cliente";
            this.id_compra.TextChanged += new System.EventHandler(this.id_compra_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Canjear Cupon";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(239, 114);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(84, 20);
            this.guardar.TabIndex = 51;
            this.guardar.Text = "Aceptar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // seleecionar_proveedor
            // 
            this.seleecionar_proveedor.Enabled = false;
            this.seleecionar_proveedor.Location = new System.Drawing.Point(243, 36);
            this.seleecionar_proveedor.Name = "seleecionar_proveedor";
            this.seleecionar_proveedor.Size = new System.Drawing.Size(84, 20);
            this.seleecionar_proveedor.TabIndex = 84;
            this.seleecionar_proveedor.Text = "Seleccionar";
            this.seleecionar_proveedor.UseVisualStyleBackColor = true;
            this.seleecionar_proveedor.Click += new System.EventHandler(this.seleecionar_proveedor_Click);
            // 
            // nombre_proveedor
            // 
            this.nombre_proveedor.Enabled = false;
            this.nombre_proveedor.Location = new System.Drawing.Point(114, 36);
            this.nombre_proveedor.Name = "nombre_proveedor";
            this.nombre_proveedor.Size = new System.Drawing.Size(123, 20);
            this.nombre_proveedor.TabIndex = 83;
            this.nombre_proveedor.Tag = "Proveedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "Proveedor *";
            // 
            // CanjearCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 146);
            this.Controls.Add(this.seleecionar_proveedor);
            this.Controls.Add(this.nombre_proveedor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_compra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clie_nombre);
            this.Controls.Add(this.seleccionar);
            this.Name = "CanjearCupon";
            this.Text = "CanjearCupon";
            this.Load += new System.EventHandler(this.CanjearCupon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clie_nombre;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id_compra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button seleecionar_proveedor;
        private System.Windows.Forms.TextBox nombre_proveedor;
        private System.Windows.Forms.Label label4;
    }
}