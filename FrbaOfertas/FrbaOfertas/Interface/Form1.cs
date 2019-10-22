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


namespace FrbaOfertas
{
    public partial class Form1 : Form
    {        
        RolData rolData;
        FuncionalidadesData fData;
        ClienteData cData;
        Usuario me;
        Rol rol;
        Exception exError = null;

        public Form1(Usuario usuario)
        {
            InitializeComponent();
            me = usuario;
            fData = new FuncionalidadesData(Conexion.getConexion());
            rolData = new RolData(Conexion.getConexion());
            cData = new ClienteData(Conexion.getConexion());
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

            rol = roles.First();

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
            habilitarFuncionalidades( miRol.funcionalidades);
            

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

        }

        private void comprarOfertaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void canjearCuponToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GENERAR_OFERTA_Click(object sender, EventArgs e)
        {

        }

        private void CARGA_CREDITO_Click(object sender, EventArgs e)
        {
            if (rol.rol_nombre == "CLIENTE")
            {
                Dictionary<String,Object> dic =  new Dictionary<String,Object>(){{"clie_usuario",me.id_usuario}};
                Cliente meCliente = cData.FilterSelect(new Dictionary<String, String>(), dic, out exError).First();
                CargaDeCredito cc = new CargaDeCredito(meCliente);
                cc.Show();
                return;
            }

            CargaDeCredito carg = new CargaDeCredito();
            carg.Show();
        }

      
    }
}
