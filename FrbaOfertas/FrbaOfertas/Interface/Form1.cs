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


namespace FrbaOfertas
{
    public partial class Form1 : Form
    {        
        RolData rolData;
        Usuario me;
        Rol rol;
        Exception exError = null;

        public Form1(Usuario usuario)
        {
            InitializeComponent();
            me = usuario;

            rolData = new RolData(Conexion.getConexion());
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

            if (roles.Count() > 1)
            {
                MessageBox.Show("MAS DE UN ROL");
            }
            else
            {
                rol = roles.First();
                rolTool.Text = rol.rol_nombre;
            }

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

      
    }
}
