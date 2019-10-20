namespace FrbaOfertas.AbmRol
{
    partial class NuevoRol
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
            this.rol_nombre = new System.Windows.Forms.TextBox();
            this.checkedListFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rol_activo = new System.Windows.Forms.CheckBox();
            this.guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre *";
            // 
            // rol_nombre
            // 
            this.rol_nombre.Location = new System.Drawing.Point(114, 12);
            this.rol_nombre.Name = "rol_nombre";
            this.rol_nombre.Size = new System.Drawing.Size(173, 20);
            this.rol_nombre.TabIndex = 3;
            this.rol_nombre.Tag = "Nombre";
            // 
            // checkedListFuncionalidades
            // 
            this.checkedListFuncionalidades.FormattingEnabled = true;
            this.checkedListFuncionalidades.Location = new System.Drawing.Point(114, 47);
            this.checkedListFuncionalidades.Name = "checkedListFuncionalidades";
            this.checkedListFuncionalidades.Size = new System.Drawing.Size(173, 139);
            this.checkedListFuncionalidades.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Funcionalidades *";
            // 
            // rol_activo
            // 
            this.rol_activo.AutoSize = true;
            this.rol_activo.Location = new System.Drawing.Point(231, 192);
            this.rol_activo.Name = "rol_activo";
            this.rol_activo.Size = new System.Drawing.Size(56, 17);
            this.rol_activo.TabIndex = 35;
            this.rol_activo.Text = "Activo";
            this.rol_activo.UseVisualStyleBackColor = true;
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(203, 215);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(84, 20);
            this.guardar.TabIndex = 36;
            this.guardar.Text = "Aceptar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // NuevoRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 248);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.rol_activo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListFuncionalidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rol_nombre);
            this.Name = "NuevoRol";
            this.Text = "NuevoRol";
            this.Load += new System.EventHandler(this.NuevoRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rol_nombre;
        private System.Windows.Forms.CheckedListBox checkedListFuncionalidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox rol_activo;
        private System.Windows.Forms.Button guardar;
    }
}