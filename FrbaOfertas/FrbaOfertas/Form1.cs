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


namespace FrbaOfertas
{
    public partial class Form1 : Form
    {
        UsuarioData usuarioData;
        Exception exError = null;

        public Form1()
        {
            InitializeComponent();
            usuarioData = new UsuarioData(Conexion.getConexion()) ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = usuarioData.Select(out exError);

            Cliente cliente = new Cliente();
            cliente.clie_nombre = "peter";
            String nombre = cliente.getMethodString("clie_nombre");
            MessageBox.Show(nombre);

            if (exError == null)
            {                
                dataGridViewUsuarios.DataSource = usuarios;                
            }
            else               
                MessageBox.Show("No se pudo obtener la lista de Usuarios, " + exError.Message);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteList nc = new ClienteList();
            nc.ShowDialog();
            nc.Focus();   
        }
    }
}
