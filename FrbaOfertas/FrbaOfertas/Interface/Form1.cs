using FrbaOfertas.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaOfertas.Model;
using FrbaOfertas.AbmCliente;
using FrbaOfertas.AbmProveedor;
using FrbaOfertas.AbmRol;
using FrbaOfertas.Model.DataModel;
using FrbaOfertas.Interface;
using FrbaOfertas.CargaCredito;
using FrbaOfertas.ComprarOferta;
using FrbaOfertas.CrearOferta;
using FrbaOfertas.ConsumirOferta;
using FrbaOfertas.Facturar;
using FrbaOfertas.ListadoEstadistico;


namespace FrbaOfertas
{
    public partial class Form1 : Form
    {        
        RolData rolData;
        FuncionalidadesData fData;
        ClienteData cData;
        ProveedorData pData;
        Usuario me;
        Rol rol;
        Cliente meCliente;
        Proveedor meProveedor;
        Exception exError = null;

        public Form1(Usuario usuario)
        {
            InitializeComponent();
            me = usuario;
            fData = new FuncionalidadesData(Conexion.getConexion());
            rolData = new RolData(Conexion.getConexion());
            cData = new ClienteData(Conexion.getConexion());
            pData = new ProveedorData(Conexion.getConexion());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usuarioTool.Text = "Usuario: " + me.usu_username;
            Dictionary<String,Object> dic =  new Dictionary<String,Object>(){{"id_usuario",me.id_usuario}};
            List<Rol> roles = rolData.FilterSelect(null,dic,out exError);
            if (exError != null)
            {
                MessageBox.Show("Error , " + exError.Message);
                return;
            }

            try
            {
                rol = roles.First();
            }
            catch (Exception ex) {
                MessageBox.Show("No, tiene un rol asignado. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            } 

            if (roles.Count() > 1)
            {
                Tus_roles formRoles = new Tus_roles(roles);
                var result = formRoles.ShowDialog();
                if (result == DialogResult.OK)
                {
                    rol = (Rol)formRoles.seleccionado;
                }
            }
                       
            rolTool.Text = rol.rol_nombre;
            Rol miRol = rolData.Read(rol.id_rol,out exError);
            if (!miRol.rol_activo)
            {
                MessageBox.Show("Su rol de usuario, no esta activo.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            habilitarFuncionalidades( miRol.funcionalidades);
            loadRol();

        }

        private void loadRol()
        {
            if (rol.rol_nombre == "CLIENTE")
            {
                Dictionary<String, Object> dic = new Dictionary<String, Object>() { { "clie_usuario", me.id_usuario } };
                try
                {
                    meCliente = cData.FilterSelect(new Dictionary<String, String>(), dic, out exError).First();
                    if (!meCliente.clie_activo)
                    {
                        MessageBox.Show("Su usuario cliente, esta inhabilitado, no podra cargar credito y comprar ofertas.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CARGA_CREDITO.Enabled = false;
                        COMPRAR_OFERTA.Enabled = false;
                    }
                }catch(Exception ex){
                    MessageBox.Show("Su usuario cliente, no tiene un cliente asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            if (rol.rol_nombre == "PROVEEDOR")
            {
                Dictionary<String, Object> dic = new Dictionary<String, Object>() { { "prove_usuario", me.id_usuario } };
                try
                {
                meProveedor = pData.FilterSelect(new Dictionary<String, String>(), dic, out exError).First();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Su usuario proveedor, no tiene un proveedor asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            if (exError != null)
            {
                MessageBox.Show("Problemas al cargar su rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void habilitarFuncionalidades(List<Funcionalidad> list)
        {
            list.ForEach(delegate(Funcionalidad f)
            {
                
                foreach (ToolStripItem item in menuStrip1.Items)
                {
                    if (f.fun_nombre == item.Name)
                    {                        
                        item.Visible = true;
                        item.Enabled = true;
                    }
                }
                foreach (ToolStripItem item in operacionesToolStripMenuItem.DropDown.Items)
                {
                    if (f.fun_nombre == item.Name)
                    {                      
                        item.Visible = true;
                        item.Enabled = true;
                    }
                }

            });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            launcher(new ClienteList());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            launcher(new ProveedoresList());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            launcher(new RolesList());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launcher(new NuevoCliente());
        }

        private void launcher(Form form){
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MdiParent = this;
            form.Show();
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            launcher(new ClienteList());
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            launcher(new NuevoProveedor());
        }

        private void listaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            launcher(new ProveedoresList()); 
        }

        private void rolesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            launcher(new RolesList());
        }

        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            launcher(new NuevoRol());
        }

        private void listaUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosList form2 = new UsuariosList();
            form2.MdiParent = this;
            form2.Show();
        }

        private void comprarOfertaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void canjearCuponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rol.rol_nombre == "CLIENTE")
            {
                CanjearCupon form = new CanjearCupon(meCliente);
                form.MdiParent = this;
                form.Show();
                return;
            }

            if (rol.rol_nombre == "PROVEEDOR")
            {
                CanjearCupon form = new CanjearCupon(meProveedor);
                form.MdiParent = this;
                form.Show();
                return;
            }

            CanjearCupon form2 = new CanjearCupon();
            form2.MdiParent = this;
            form2.Show();
        }

        private void GENERAR_OFERTA_Click(object sender, EventArgs e)
        {
            if (rol.rol_nombre == "PROVEEDOR")
            {
                ConfeccionOferta form = new ConfeccionOferta(meProveedor);
                form.MdiParent = this;
                form.Show();
                return;
            }

            ConfeccionOferta form2 = new ConfeccionOferta();
            form2.Show();
        }

        private void CARGA_CREDITO_Click(object sender, EventArgs e)
        {
            if (rol.rol_nombre == "CLIENTE")
            {
                CargaDeCredito cc = new CargaDeCredito(meCliente);
                cc.MdiParent = this;
                cc.Show();
                return;
            }

            CargaDeCredito carg = new CargaDeCredito();
            carg.MdiParent = this;
            carg.Show();
        }

        private void COMPRAR_OFERTA_Click(object sender, EventArgs e)
        {
            ListadoOfertas carg = new ListadoOfertas();
            carg.MdiParent = this;
            carg.Show();
        }

        private void nuevoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NuevoUsuario form = new NuevoUsuario();
            form.Parent = this.Parent;
            form.Show();
        }

        private void GENERAR_FACTURA_Click(object sender, EventArgs e)
        {
            NuevaFactura form = new NuevaFactura();
            form.MdiParent = this;
            form.Show();
        }

        private void LISTADO_ESTADISTICO_Click(object sender, EventArgs e)
        {
            Listados form = new Listados();
            form.MdiParent = this;
            form.Show();
        }

      
    }
}
