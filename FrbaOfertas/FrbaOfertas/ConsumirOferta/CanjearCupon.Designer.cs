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
            this.label14 = new System.Windows.Forms.Label();
            this.ent_fecha = new System.Windows.Forms.TextBox();
            this.guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Cliente *";
            // 
            // clie_nombre
            // 
            this.clie_nombre.Enabled = false;
            this.clie_nombre.Location = new System.Drawing.Point(110, 60);
            this.clie_nombre.Name = "clie_nombre";
            this.clie_nombre.Size = new System.Drawing.Size(123, 20);
            this.clie_nombre.TabIndex = 41;
            this.clie_nombre.Tag = "Cliente";
            // 
            // seleccionar
            // 
            this.seleccionar.Enabled = false;
            this.seleccionar.Location = new System.Drawing.Point(239, 60);
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
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Cod. Cupon *";
            // 
            // id_compra
            // 
            this.id_compra.Enabled = false;
            this.id_compra.Location = new System.Drawing.Point(110, 34);
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Fecha de Canje *";
            // 
            // ent_fecha
            // 
            this.ent_fecha.Enabled = false;
            this.ent_fecha.Location = new System.Drawing.Point(110, 87);
            this.ent_fecha.Name = "ent_fecha";
            this.ent_fecha.Size = new System.Drawing.Size(210, 20);
            this.ent_fecha.TabIndex = 47;
            this.ent_fecha.Tag = "Fecha de nacimiento";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(239, 113);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(84, 20);
            this.guardar.TabIndex = 51;
            this.guardar.Text = "Aceptar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // CanjearCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 146);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ent_fecha);
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ent_fecha;
        private System.Windows.Forms.Button guardar;
    }
}