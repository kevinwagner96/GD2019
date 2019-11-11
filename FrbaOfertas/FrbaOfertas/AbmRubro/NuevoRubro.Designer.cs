namespace FrbaOfertas.AbmRubro
{
    partial class NuevoRubro
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
            this.rubr_detalle = new System.Windows.Forms.TextBox();
            this.guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rubro *";
            // 
            // rubr_detalle
            // 
            this.rubr_detalle.Location = new System.Drawing.Point(56, 12);
            this.rubr_detalle.Name = "rubr_detalle";
            this.rubr_detalle.Size = new System.Drawing.Size(160, 20);
            this.rubr_detalle.TabIndex = 3;
            this.rubr_detalle.Tag = "Rubro";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(132, 40);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(84, 20);
            this.guardar.TabIndex = 30;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // NuevoRubro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 72);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rubr_detalle);
            this.Name = "NuevoRubro";
            this.Text = "NuevoRubro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rubr_detalle;
        private System.Windows.Forms.Button guardar;
    }
}