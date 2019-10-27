namespace FrbaOfertas.CargaCredito
{
    partial class CargaDeCredito
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
            this.label14 = new System.Windows.Forms.Label();
            this.cred_fecha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cred_monto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clie_nombre = new System.Windows.Forms.TextBox();
            this.seleccionar = new System.Windows.Forms.Button();
            this.tipo_pago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cred_num_tarjeta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cre_empresa_tarjeta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cred_cod_tarjeta = new System.Windows.Forms.TextBox();
            this.guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Fecha *";
            // 
            // cred_fecha
            // 
            this.cred_fecha.Enabled = false;
            this.cred_fecha.Location = new System.Drawing.Point(108, 25);
            this.cred_fecha.Name = "cred_fecha";
            this.cred_fecha.Size = new System.Drawing.Size(213, 20);
            this.cred_fecha.TabIndex = 36;
            this.cred_fecha.Tag = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Monto *";
            // 
            // cred_monto
            // 
            this.cred_monto.Location = new System.Drawing.Point(237, 199);
            this.cred_monto.Name = "cred_monto";
            this.cred_monto.Size = new System.Drawing.Size(84, 20);
            this.cred_monto.TabIndex = 34;
            this.cred_monto.Tag = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Tipo de Pago *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Cliente *";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Cargar de credito";
            // 
            // clie_nombre
            // 
            this.clie_nombre.Enabled = false;
            this.clie_nombre.Location = new System.Drawing.Point(108, 51);
            this.clie_nombre.Name = "clie_nombre";
            this.clie_nombre.Size = new System.Drawing.Size(123, 20);
            this.clie_nombre.TabIndex = 29;
            this.clie_nombre.Tag = "Cliente";
            this.clie_nombre.TextChanged += new System.EventHandler(this.clie_nombre_TextChanged);
            // 
            // seleccionar
            // 
            this.seleccionar.Location = new System.Drawing.Point(237, 51);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(84, 20);
            this.seleccionar.TabIndex = 40;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // tipo_pago
            // 
            this.tipo_pago.FormattingEnabled = true;
            this.tipo_pago.Location = new System.Drawing.Point(108, 77);
            this.tipo_pago.Name = "tipo_pago";
            this.tipo_pago.Size = new System.Drawing.Size(213, 21);
            this.tipo_pago.TabIndex = 41;
            this.tipo_pago.Tag = "Tipo Pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "N° Tarjeta *";
            // 
            // cred_num_tarjeta
            // 
            this.cred_num_tarjeta.Location = new System.Drawing.Point(109, 104);
            this.cred_num_tarjeta.Name = "cred_num_tarjeta";
            this.cred_num_tarjeta.Size = new System.Drawing.Size(213, 20);
            this.cred_num_tarjeta.TabIndex = 42;
            this.cred_num_tarjeta.Tag = "Numero de Tarjeta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Empresa Tarjeta *";
            // 
            // cre_empresa_tarjeta
            // 
            this.cre_empresa_tarjeta.Location = new System.Drawing.Point(108, 130);
            this.cre_empresa_tarjeta.Name = "cre_empresa_tarjeta";
            this.cre_empresa_tarjeta.Size = new System.Drawing.Size(213, 20);
            this.cre_empresa_tarjeta.TabIndex = 44;
            this.cre_empresa_tarjeta.Tag = "Empresa de tarjeta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Codigo *";
            // 
            // cred_cod_tarjeta
            // 
            this.cred_cod_tarjeta.Location = new System.Drawing.Point(108, 156);
            this.cred_cod_tarjeta.Name = "cred_cod_tarjeta";
            this.cred_cod_tarjeta.Size = new System.Drawing.Size(213, 20);
            this.cred_cod_tarjeta.TabIndex = 46;
            this.cred_cod_tarjeta.Tag = "Codigo de tarjeta";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(237, 225);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(84, 24);
            this.guardar.TabIndex = 48;
            this.guardar.Text = "Pagar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // CargaDeCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 262);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cred_cod_tarjeta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cre_empresa_tarjeta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cred_num_tarjeta);
            this.Controls.Add(this.tipo_pago);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cred_fecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cred_monto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clie_nombre);
            this.Controls.Add(this.seleccionar);
            this.Name = "CargaDeCredito";
            this.Text = "CargaDeCredito";
            this.Load += new System.EventHandler(this.CargaDeCredito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox cred_fecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cred_monto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clie_nombre;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.ComboBox tipo_pago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cred_num_tarjeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cre_empresa_tarjeta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cred_cod_tarjeta;
        private System.Windows.Forms.Button guardar;
    }
}