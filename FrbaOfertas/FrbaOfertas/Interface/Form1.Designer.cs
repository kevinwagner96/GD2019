namespace FrbaOfertas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ABM_CLIENTE = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ABM_PROVEEDOR = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ABM_ROL = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GENERAR_OFERTA = new System.Windows.Forms.ToolStripMenuItem();
            this.CARGA_CREDITO = new System.Windows.Forms.ToolStripMenuItem();
            this.LISTADO_ESTADISTICO = new System.Windows.Forms.ToolStripMenuItem();
            this.GENERAR_FACTURA = new System.Windows.Forms.ToolStripMenuItem();
            this.INHABILITAR_CUPON = new System.Windows.Forms.ToolStripMenuItem();
            this.CANJEAR_CUPON = new System.Windows.Forms.ToolStripMenuItem();
            this.COMPRAR_OFERTA = new System.Windows.Forms.ToolStripMenuItem();
            this.ABM_USUARIO = new System.Windows.Forms.ToolStripMenuItem();
            this.listaUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.usuarioTool = new System.Windows.Forms.ToolStripStatusLabel();
            this.rolTool = new System.Windows.Forms.ToolStripStatusLabel();
            this.close = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ABM_CLIENTE,
            this.ABM_PROVEEDOR,
            this.ABM_ROL,
            this.operacionesToolStripMenuItem,
            this.ABM_USUARIO});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(986, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ABM_CLIENTE
            // 
            this.ABM_CLIENTE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.listaToolStripMenuItem});
            this.ABM_CLIENTE.Enabled = false;
            this.ABM_CLIENTE.Name = "ABM_CLIENTE";
            this.ABM_CLIENTE.Size = new System.Drawing.Size(61, 20);
            this.ABM_CLIENTE.Text = "Clientes";
            this.ABM_CLIENTE.Visible = false;
            this.ABM_CLIENTE.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // listaToolStripMenuItem
            // 
            this.listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            this.listaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listaToolStripMenuItem.Text = "Lista";
            this.listaToolStripMenuItem.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
            // 
            // ABM_PROVEEDOR
            // 
            this.ABM_PROVEEDOR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.listaToolStripMenuItem1});
            this.ABM_PROVEEDOR.Enabled = false;
            this.ABM_PROVEEDOR.Name = "ABM_PROVEEDOR";
            this.ABM_PROVEEDOR.Size = new System.Drawing.Size(84, 20);
            this.ABM_PROVEEDOR.Text = "Proveedores";
            this.ABM_PROVEEDOR.Visible = false;
            this.ABM_PROVEEDOR.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // listaToolStripMenuItem1
            // 
            this.listaToolStripMenuItem1.Name = "listaToolStripMenuItem1";
            this.listaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.listaToolStripMenuItem1.Text = "Lista";
            this.listaToolStripMenuItem1.Click += new System.EventHandler(this.listaToolStripMenuItem1_Click);
            // 
            // ABM_ROL
            // 
            this.ABM_ROL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rolesToolStripMenuItem1,
            this.nuevoToolStripMenuItem2});
            this.ABM_ROL.Enabled = false;
            this.ABM_ROL.Name = "ABM_ROL";
            this.ABM_ROL.Size = new System.Drawing.Size(47, 20);
            this.ABM_ROL.Text = "Roles";
            this.ABM_ROL.Visible = false;
            // 
            // rolesToolStripMenuItem1
            // 
            this.rolesToolStripMenuItem1.Name = "rolesToolStripMenuItem1";
            this.rolesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.rolesToolStripMenuItem1.Text = "Roles";
            this.rolesToolStripMenuItem1.Click += new System.EventHandler(this.rolesToolStripMenuItem1_Click);
            // 
            // nuevoToolStripMenuItem2
            // 
            this.nuevoToolStripMenuItem2.Name = "nuevoToolStripMenuItem2";
            this.nuevoToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem2.Text = "Nuevo";
            this.nuevoToolStripMenuItem2.Click += new System.EventHandler(this.nuevoToolStripMenuItem2_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GENERAR_OFERTA,
            this.CARGA_CREDITO,
            this.LISTADO_ESTADISTICO,
            this.GENERAR_FACTURA,
            this.INHABILITAR_CUPON,
            this.CANJEAR_CUPON,
            this.COMPRAR_OFERTA});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // GENERAR_OFERTA
            // 
            this.GENERAR_OFERTA.Enabled = false;
            this.GENERAR_OFERTA.Name = "GENERAR_OFERTA";
            this.GENERAR_OFERTA.Size = new System.Drawing.Size(171, 22);
            this.GENERAR_OFERTA.Text = "Generar Oferta";
            this.GENERAR_OFERTA.Visible = false;
            this.GENERAR_OFERTA.Click += new System.EventHandler(this.GENERAR_OFERTA_Click);
            // 
            // CARGA_CREDITO
            // 
            this.CARGA_CREDITO.Enabled = false;
            this.CARGA_CREDITO.Name = "CARGA_CREDITO";
            this.CARGA_CREDITO.Size = new System.Drawing.Size(171, 22);
            this.CARGA_CREDITO.Text = "Carga Credito";
            this.CARGA_CREDITO.Visible = false;
            this.CARGA_CREDITO.Click += new System.EventHandler(this.CARGA_CREDITO_Click);
            // 
            // LISTADO_ESTADISTICO
            // 
            this.LISTADO_ESTADISTICO.Enabled = false;
            this.LISTADO_ESTADISTICO.Name = "LISTADO_ESTADISTICO";
            this.LISTADO_ESTADISTICO.Size = new System.Drawing.Size(171, 22);
            this.LISTADO_ESTADISTICO.Text = "Listado Estadistico";
            this.LISTADO_ESTADISTICO.Visible = false;
            // 
            // GENERAR_FACTURA
            // 
            this.GENERAR_FACTURA.Enabled = false;
            this.GENERAR_FACTURA.Name = "GENERAR_FACTURA";
            this.GENERAR_FACTURA.Size = new System.Drawing.Size(171, 22);
            this.GENERAR_FACTURA.Text = "Generar Factura";
            this.GENERAR_FACTURA.Visible = false;
            this.GENERAR_FACTURA.Click += new System.EventHandler(this.GENERAR_FACTURA_Click);
            // 
            // INHABILITAR_CUPON
            // 
            this.INHABILITAR_CUPON.Enabled = false;
            this.INHABILITAR_CUPON.Name = "INHABILITAR_CUPON";
            this.INHABILITAR_CUPON.Size = new System.Drawing.Size(171, 22);
            this.INHABILITAR_CUPON.Text = "Inhabilitar Cupon";
            this.INHABILITAR_CUPON.Visible = false;
            // 
            // CANJEAR_CUPON
            // 
            this.CANJEAR_CUPON.Enabled = false;
            this.CANJEAR_CUPON.Name = "CANJEAR_CUPON";
            this.CANJEAR_CUPON.Size = new System.Drawing.Size(171, 22);
            this.CANJEAR_CUPON.Text = "Canjear Cupon";
            this.CANJEAR_CUPON.Visible = false;
            this.CANJEAR_CUPON.Click += new System.EventHandler(this.canjearCuponToolStripMenuItem_Click);
            // 
            // COMPRAR_OFERTA
            // 
            this.COMPRAR_OFERTA.Name = "COMPRAR_OFERTA";
            this.COMPRAR_OFERTA.Size = new System.Drawing.Size(171, 22);
            this.COMPRAR_OFERTA.Text = "Comprar Oferta";
            this.COMPRAR_OFERTA.Visible = false;
            this.COMPRAR_OFERTA.Click += new System.EventHandler(this.COMPRAR_OFERTA_Click);
            // 
            // ABM_USUARIO
            // 
            this.ABM_USUARIO.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaUsuariosToolStripMenuItem,
            this.nuevoToolStripMenuItem3});
            this.ABM_USUARIO.Enabled = false;
            this.ABM_USUARIO.Name = "ABM_USUARIO";
            this.ABM_USUARIO.Size = new System.Drawing.Size(64, 20);
            this.ABM_USUARIO.Text = "Usuarios";
            this.ABM_USUARIO.Visible = false;
            // 
            // listaUsuariosToolStripMenuItem
            // 
            this.listaUsuariosToolStripMenuItem.Name = "listaUsuariosToolStripMenuItem";
            this.listaUsuariosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listaUsuariosToolStripMenuItem.Text = "Lista";
            this.listaUsuariosToolStripMenuItem.Click += new System.EventHandler(this.listaUsuariosToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem3
            // 
            this.nuevoToolStripMenuItem3.Name = "nuevoToolStripMenuItem3";
            this.nuevoToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem3.Text = "Nuevo";
            this.nuevoToolStripMenuItem3.Click += new System.EventHandler(this.nuevoToolStripMenuItem3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioTool,
            this.rolTool});
            this.statusStrip1.Location = new System.Drawing.Point(0, 597);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(986, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // usuarioTool
            // 
            this.usuarioTool.Name = "usuarioTool";
            this.usuarioTool.Size = new System.Drawing.Size(118, 17);
            this.usuarioTool.Text = "toolStripStatusLabel1";
            // 
            // rolTool
            // 
            this.rolTool.Name = "rolTool";
            this.rolTool.Size = new System.Drawing.Size(118, 17);
            this.rolTool.Text = "toolStripStatusLabel1";
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(883, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(103, 23);
            this.close.TabIndex = 6;
            this.close.Text = "Cerrar Sesión";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 619);
            this.Controls.Add(this.close);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FRBA Ofertas - GDDS2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ABM_CLIENTE;
        private System.Windows.Forms.ToolStripMenuItem ABM_PROVEEDOR;
        private System.Windows.Forms.ToolStripMenuItem ABM_ROL;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel usuarioTool;
        private System.Windows.Forms.ToolStripStatusLabel rolTool;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem GENERAR_OFERTA;
        private System.Windows.Forms.ToolStripMenuItem CARGA_CREDITO;
        private System.Windows.Forms.ToolStripMenuItem LISTADO_ESTADISTICO;
        private System.Windows.Forms.ToolStripMenuItem GENERAR_FACTURA;
        private System.Windows.Forms.ToolStripMenuItem INHABILITAR_CUPON;
        private System.Windows.Forms.ToolStripMenuItem CANJEAR_CUPON;
        private System.Windows.Forms.ToolStripMenuItem ABM_USUARIO;
        private System.Windows.Forms.ToolStripMenuItem listaUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem COMPRAR_OFERTA;
    }
}

