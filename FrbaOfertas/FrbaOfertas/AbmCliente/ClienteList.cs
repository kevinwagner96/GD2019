using FrbaOfertas.Helpers;
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
        List<TextBox> todos = new List<TextBox>();
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
            cargarDataGrid();
        }

        private void ClienteList_Load(object sender, EventArgs e)
        {
            todos.Add(clie_nombre);
            todos.Add(clie_email);
            todos.Add(clie_dni);
            todos.Add(clie_apellido);

            cargarDataGrid();
        }

        private void cargarDataGrid()
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
            ModificarCliente modificarCliente = new ModificarCliente(id);
            modificarCliente.ShowDialog();
            modificarCliente.Focus();
            cargarDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String nombre = dataGridClientes.Rows[dataGridClientes.CurrentCell.RowIndex].Cells["clie_nombre"].Value.ToString();
            Int32 id = (Int32)dataGridClientes.Rows[dataGridClientes.CurrentCell.RowIndex].Cells["id_cliente"].Value;

            DialogResult result = MessageBox.Show("Seguro quiere eliminar al cliente " + nombre + ".", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                data.Delete(id, out exError);
                if (exError == null)
                {
                    cargarDataGrid();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar cliente, " + exError.Message);
                    return;
                }
                
                
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> filtros = new Dictionary<string, string>();
             List < TextBox > noNulos = FormHelper.getNoNulos(todos);
            foreach (TextBox tb in noNulos)
            {
                filtros.Add(tb.Name, tb.Text);
            }

            if (filtros.Count() == 0)
            {
                cargarDataGrid();
                return;
            }

            List<Cliente> clientes = data.FilterSelect(filtros,out exError);

            if (exError == null)
            {
                dataGridClientes.DataSource = clientes;
                dataGridClientes.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("No se pudo obtener la lista de Usuarios, " + exError.Message);
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            List<TextBox> noNulos = FormHelper.getNoNulos(todos);
            foreach (TextBox tb in noNulos)
            {
                tb.Text = "";
            }

            cargarDataGrid();
        }
    }
}
