namespace FrbaOfertas.AbmProveedor
{
    partial class ModificarUsuario
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
            this.usu_cant_intentos_fallidos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkedListRoles = new System.Windows.Forms.CheckedListBox();
            this.usu_activo = new System.Windows.Forms.CheckBox();
            this.guardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usu_contrasenia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.usu_username = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usu_cant_intentos_fallidos
            // 
            this.usu_cant_intentos_fallidos.Location = new System.Drawing.Point(112, 85);
            this.usu_cant_intentos_fallidos.Name = "usu_cant_intentos_fallidos";
            this.usu_cant_intentos_fallidos.Size = new System.Drawing.Size(213, 20);
            this.usu_cant_intentos_fallidos.TabIndex = 42;
            this.usu_cant_intentos_fallidos.Tag = "Intentos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Roles *";
            // 
            // checkedListRoles
            // 
            this.checkedListRoles.FormattingEnabled = true;
            this.checkedListRoles.Location = new System.Drawing.Point(112, 111);
            this.checkedListRoles.Name = "checkedListRoles";
            this.checkedListRoles.Size = new System.Drawing.Size(212, 94);
            this.checkedListRoles.TabIndex = 46;
            // 
            // usu_activo
            // 
            this.usu_activo.AutoSize = true;
            this.usu_activo.Location = new System.Drawing.Point(269, 220);
            this.usu_activo.Name = "usu_activo";
            this.usu_activo.Size = new System.Drawing.Size(56, 17);
            this.usu_activo.TabIndex = 45;
            this.usu_activo.Text = "Activo";
            this.usu_activo.UseVisualStyleBackColor = true;
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(240, 243);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(84, 20);
            this.guardar.TabIndex = 44;
            this.guardar.Text = "Aceptar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Cant. Intentos Fall: *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Contraseña *";
            // 
            // usu_contrasenia
            // 
            this.usu_contrasenia.Location = new System.Drawing.Point(112, 59);
            this.usu_contrasenia.Name = "usu_contrasenia";
            this.usu_contrasenia.PasswordChar = '*';
            this.usu_contrasenia.Size = new System.Drawing.Size(213, 20);
            this.usu_contrasenia.TabIndex = 40;
            this.usu_contrasenia.Tag = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Username *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Modificar Usuario";
            // 
            // usu_username
            // 
            this.usu_username.Location = new System.Drawing.Point(112, 33);
            this.usu_username.Name = "usu_username";
            this.usu_username.Size = new System.Drawing.Size(213, 20);
            this.usu_username.TabIndex = 37;
            this.usu_username.Tag = "Username";
            // 
            // ModificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 274);
            this.Controls.Add(this.usu_cant_intentos_fallidos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkedListRoles);
            this.Controls.Add(this.usu_activo);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usu_contrasenia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usu_username);
            this.Name = "ModificarUsuario";
            this.Text = "Modificar Usuario";
            this.Load += new System.EventHandler(this.ModificarProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usu_cant_intentos_fallidos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkedListRoles;
        private System.Windows.Forms.CheckBox usu_activo;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usu_contrasenia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usu_username;

    }
}