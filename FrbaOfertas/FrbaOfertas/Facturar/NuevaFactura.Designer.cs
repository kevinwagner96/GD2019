namespace FrbaOfertas.Facturar
{
    partial class NuevaFactura
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
            this.finalCalendar = new System.Windows.Forms.MonthCalendar();
            this.inicioCalenda = new System.Windows.Forms.MonthCalendar();
            this.button2 = new System.Windows.Forms.Button();
            this.fin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.inicio = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clie_nombre = new System.Windows.Forms.TextBox();
            this.seleccionar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // finalCalendar
            // 
            this.finalCalendar.Location = new System.Drawing.Point(37, 1);
            this.finalCalendar.Name = "finalCalendar";
            this.finalCalendar.TabIndex = 77;
            this.finalCalendar.Visible = false;
            this.finalCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.finalCalendar_DateSelected);
            // 
            // inicioCalenda
            // 
            this.inicioCalenda.Location = new System.Drawing.Point(31, 12);
            this.inicioCalenda.Name = "inicioCalenda";
            this.inicioCalenda.TabIndex = 80;
            this.inicioCalenda.Visible = false;
            this.inicioCalenda.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.inicioCalenda_DateSelected);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(234, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 20);
            this.button2.TabIndex = 81;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fin
            // 
            this.fin.Enabled = false;
            this.fin.Location = new System.Drawing.Point(105, 38);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(123, 20);
            this.fin.TabIndex = 79;
            this.fin.Tag = "Fecha de fin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 20);
            this.button1.TabIndex = 78;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inicio
            // 
            this.inicio.Enabled = false;
            this.inicio.Location = new System.Drawing.Point(106, 12);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(123, 20);
            this.inicio.TabIndex = 76;
            this.inicio.Tag = "Fecha de inicio";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 74;
            this.label14.Text = "Fecha Inicio*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "Fecha Fin*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Proveedor *";
            // 
            // clie_nombre
            // 
            this.clie_nombre.Enabled = false;
            this.clie_nombre.Location = new System.Drawing.Point(106, 64);
            this.clie_nombre.Name = "clie_nombre";
            this.clie_nombre.Size = new System.Drawing.Size(123, 20);
            this.clie_nombre.TabIndex = 82;
            this.clie_nombre.Tag = "Cliente";
            // 
            // seleccionar
            // 
            this.seleccionar.Location = new System.Drawing.Point(235, 64);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(84, 20);
            this.seleccionar.TabIndex = 84;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(235, 149);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 20);
            this.button3.TabIndex = 85;
            this.button3.Text = "Listado";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NuevaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 181);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.finalCalendar);
            this.Controls.Add(this.inicioCalenda);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inicio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clie_nombre);
            this.Controls.Add(this.seleccionar);
            this.Name = "NuevaFactura";
            this.Text = "NuevaFactura";
            this.Load += new System.EventHandler(this.NuevaFactura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar finalCalendar;
        private System.Windows.Forms.MonthCalendar inicioCalenda;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox fin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox inicio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clie_nombre;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Button button3;
    }
}