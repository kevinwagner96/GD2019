namespace FrbaOfertas.ComprarOferta
{
    partial class CompraOferta
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
            this.id_oferta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cantidad = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Cliente *";
            // 
            // clie_nombre
            // 
            this.clie_nombre.Enabled = false;
            this.clie_nombre.Location = new System.Drawing.Point(107, 12);
            this.clie_nombre.Name = "clie_nombre";
            this.clie_nombre.Size = new System.Drawing.Size(123, 20);
            this.clie_nombre.TabIndex = 44;
            this.clie_nombre.Tag = "Cliente";
            // 
            // seleccionar
            // 
            this.seleccionar.Enabled = false;
            this.seleccionar.Location = new System.Drawing.Point(236, 12);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(81, 20);
            this.seleccionar.TabIndex = 46;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Cod. Oferta*";
            // 
            // id_oferta
            // 
            this.id_oferta.Enabled = false;
            this.id_oferta.Location = new System.Drawing.Point(107, 38);
            this.id_oferta.Name = "id_oferta";
            this.id_oferta.Size = new System.Drawing.Size(210, 20);
            this.id_oferta.TabIndex = 47;
            this.id_oferta.Tag = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Cantidad*";
            // 
            // cantidad
            // 
            this.cantidad.Location = new System.Drawing.Point(107, 64);
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(210, 20);
            this.cantidad.TabIndex = 49;
            this.cantidad.Tag = "Cantidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 20);
            this.button1.TabIndex = 51;
            this.button1.Text = "Comprar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CompraOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 121);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_oferta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clie_nombre);
            this.Controls.Add(this.seleccionar);
            this.Name = "CompraOferta";
            this.Text = "CompraOferta";
            this.Load += new System.EventHandler(this.CompraOferta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clie_nombre;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id_oferta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cantidad;
        private System.Windows.Forms.Button button1;
    }
}