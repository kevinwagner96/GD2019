using FrbaOfertas.Model;
using FrbaOfertas.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class ClienteList : Form
    {
        ClienteData data;
        Exception exError = null;

        public ClienteList()
        {
            InitializeComponent();
            data = new ClienteData(Conexion.getConexion());
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoCliente nc = new NuevoCliente();
            nc.ShowDialog();
            nc.Focus();            

        }

        private void ClienteList_Load(object sender, EventArgs e)
        {
            List<Cliente> clientes = data.Select(out exError);

            if (exError == null)
            {
                dataGridClientes.DataSource = clientes;
                dataGridClientes.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("No se pudo obtener la lista de Usuarios, " + exError.Message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 id = (Int32) dataGridClientes.Rows[dataGridClientes.CurrentCell.RowIndex].Cells["id_cliente"].Value;
            MessageBox.Show(id.ToString());
            ModificarCliente modificarCliente = new ModificarCliente(id);
            modificarCliente.ShowDialog();
            modificarCliente.Focus();    
        }
    }
}
