namespace FrbaOfertas.CrearOferta
{
    partial class ConfeccionOferta
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
            this.label7 = new System.Windows.Forms.Label();
            this.ofer_cant_disp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ofer_descripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ofer_pr_oferta = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.publciacionCalendar = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.ofer_f_public = new System.Windows.Forms.TextBox();
            this.vencimientoCalendar = new System.Windows.Forms.MonthCalendar();
            this.button2 = new System.Windows.Forms.Button();
            this.ofer_f_venc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ofer_pr_lista = new System.Windows.Forms.TextBox();
            this.ofer_cant_x_cli = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Cantidad disponible *";
            // 
            // ofer_cant_disp
            // 
            this.ofer_cant_disp.Location = new System.Drawing.Point(108, 160);
            this.ofer_cant_disp.Name = "ofer_cant_disp";
            this.ofer_cant_disp.Size = new System.Drawing.Size(213, 20);
            this.ofer_cant_disp.TabIndex = 63;
            this.ofer_cant_disp.Tag = "Cant. Disponible";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Descripcion *";
            // 
            // ofer_descripcion
            // 
            this.ofer_descripcion.Location = new System.Drawing.Point(108, 134);
            this.ofer_descripcion.Name = "ofer_descripcion";
            this.ofer_descripcion.Size = new System.Drawing.Size(213, 20);
            this.ofer_descripcion.TabIndex = 61;
            this.ofer_descripcion.Tag = "Descripcion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Precio *";
            // 
            // ofer_pr_oferta
            // 
            this.ofer_pr_oferta.Location = new System.Drawing.Point(108, 82);
            this.ofer_pr_oferta.Name = "ofer_pr_oferta";
            this.ofer_pr_oferta.Size = new System.Drawing.Size(213, 20);
            this.ofer_pr_oferta.TabIndex = 59;
            this.ofer_pr_oferta.Tag = "Precio";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "Fecha Publicacion*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Nueva Oferta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Fecha Vencimiento*";
            // 
            // publciacionCalendar
            // 
            this.publciacionCalendar.Location = new System.Drawing.Point(130, 55);
            this.publciacionCalendar.Name = "publciacionCalendar";
            this.publciacionCalendar.TabIndex = 69;
            this.publciacionCalendar.Visible = false;
            this.publciacionCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.publciacionCalendar_DateSelected);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 20);
            this.button1.TabIndex = 70;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ofer_f_public
            // 
            this.ofer_f_public.Location = new System.Drawing.Point(109, 30);
            this.ofer_f_public.Name = "ofer_f_public";
            this.ofer_f_public.Size = new System.Drawing.Size(123, 20);
            this.ofer_f_public.TabIndex = 68;
            this.ofer_f_public.Tag = "Fecha de publicacion";
            // 
            // vencimientoCalendar
            // 
            this.vencimientoCalendar.Location = new System.Drawing.Point(129, 81);
            this.vencimientoCalendar.Name = "vencimientoCalendar";
            this.vencimientoCalendar.TabIndex = 72;
            this.vencimientoCalendar.Visible = false;
            this.vencimientoCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.vencimientoCalendar_DateSelected);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 20);
            this.button2.TabIndex = 73;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ofer_f_venc
            // 
            this.ofer_f_venc.Location = new System.Drawing.Point(108, 56);
            this.ofer_f_venc.Name = "ofer_f_venc";
            this.ofer_f_venc.Size = new System.Drawing.Size(123, 20);
            this.ofer_f_venc.TabIndex = 71;
            this.ofer_f_venc.Tag = "Fecha de vencimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Precio Lista *";
            // 
            // ofer_pr_lista
            // 
            this.ofer_pr_lista.Location = new System.Drawing.Point(108, 108);
            this.ofer_pr_lista.Name = "ofer_pr_lista";
            this.ofer_pr_lista.Size = new System.Drawing.Size(213, 20);
            this.ofer_pr_lista.TabIndex = 74;
            this.ofer_pr_lista.Tag = "Precio de lista";
            // 
            // ofer_cant_x_cli
            // 
            this.ofer_cant_x_cli.Location = new System.Drawing.Point(109, 186);
            this.ofer_cant_x_cli.Name = "ofer_cant_x_cli";
            this.ofer_cant_x_cli.Size = new System.Drawing.Size(213, 20);
            this.ofer_cant_x_cli.TabIndex = 76;
            this.ofer_cant_x_cli.Tag = "Cant. x Cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 77;
            this.label9.Text = "Cant. x Cliente *";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(265, 212);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "Activo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(239, 235);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(84, 20);
            this.guardar.TabIndex = 78;
            this.guardar.Text = "Aceptar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // ConfeccionOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 272);
            this.Controls.Add(this.publciacionCalendar);
            this.Controls.Add(this.vencimientoCalendar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ofer_cant_x_cli);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ofer_pr_lista);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ofer_f_venc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ofer_f_public);
            this.Controls.Add(this.ofer_cant_disp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ofer_descripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ofer_pr_oferta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "ConfeccionOferta";
            this.Text = "ConfeccionOferta";
            this.Load += new System.EventHandler(this.ConfeccionOferta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ofer_cant_disp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ofer_descripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ofer_pr_oferta;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MonthCalendar publciacionCalendar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ofer_f_public;
        private System.Windows.Forms.MonthCalendar vencimientoCalendar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ofer_f_venc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ofer_pr_lista;
        private System.Windows.Forms.TextBox ofer_cant_x_cli;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button guardar;
    }
}