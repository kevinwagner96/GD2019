namespace FrbaOfertas.AbmProveedor
{
    partial class NuevoUsuario
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
            this.usu_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usu_contrasenia = new System.Windows.Forms.TextBox();
            this.guardar = new System.Windows.Forms.Button();
            this.prov_activo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkedListRoles = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // usu_username
            // 
            this.usu_username.Location = new System.Drawing.Point(111, 29);
            this.usu_username.Name = "usu_username";
            this.usu_username.Size = new System.Drawing.Size(213, 20);
            this.usu_username.TabIndex = 0;
            this.usu_username.Tag = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nuevo Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contraseña *";
            // 
            // usu_contrasenia
            // 
            this.usu_contrasenia.Location = new System.Drawing.Point(111, 55);
            this.usu_contrasenia.Name = "usu_contrasenia";
            this.usu_contrasenia.PasswordChar = '*';
            this.usu_contrasenia.Size = new System.Drawing.Size(213, 20);
            this.usu_contrasenia.TabIndex = 3;
            this.usu_contrasenia.Tag = "Contraseña";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(240, 215);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(84, 20);
            this.guardar.TabIndex = 29;
            this.guardar.Text = "Aceptar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // prov_activo
            // 
            this.prov_activo.AutoSize = true;
            this.prov_activo.Checked = true;
            this.prov_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.prov_activo.Location = new System.Drawing.Point(269, 192);
            this.prov_activo.Name = "prov_activo";
            this.prov_activo.Size = new System.Drawing.Size(56, 17);
            this.prov_activo.TabIndex = 34;
            this.prov_activo.Text = "Activo";
            this.prov_activo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Roles *";
            // 
            // checkedListRoles
            // 
            this.checkedListRoles.FormattingEnabled = true;
            this.checkedListRoles.Location = new System.Drawing.Point(112, 83);
            this.checkedListRoles.Name = "checkedListRoles";
            this.checkedListRoles.Size = new System.Drawing.Size(212, 94);
            this.checkedListRoles.TabIndex = 35;
            // 
            // NuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 243);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkedListRoles);
            this.Controls.Add(this.prov_activo);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usu_contrasenia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usu_username);
            this.Name = "NuevoUsuario";
            this.Text = "Nuevo Proveedor";
            this.Load += new System.EventHandler(this.NuevoCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usu_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usu_contrasenia;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.CheckBox prov_activo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkedListRoles;
    }
}