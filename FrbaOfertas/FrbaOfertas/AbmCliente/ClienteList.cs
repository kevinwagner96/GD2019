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
        public Cliente returnCliente { get; set; }
        List<TextBox> todos = new List<TextBox>();
        Exception exError = null;

        public ClienteList()
        {
            InitializeComponent();
            data = new ClienteData(Conexion.getConexion());
            
        }

        public ClienteList(bool seleccionar)
        {
            InitializeComponent();
            data = new ClienteData(Conexion.getConexion());
            if (seleccionar)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                select.Visible = true;
            }

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
            Dictionary<String, String> like = new Dictionary<string, string>();
            Dictionary<String, Object> exac = new Dictionary<string, Object>();
             List < TextBox > noNulos = FormHelper.getNoNulos(todos);
            foreach (TextBox tb in noNulos)
            {
                if(tb.Tag!=null && tb.Tag.ToString()=="LIKE")
                    like.Add(tb.Name, tb.Text);
                else
                    exac.Add(tb.Name,tb.Text);
            }

            if (like.Count() == 0 && exac.Count() == 0)
            {
                cargarDataGrid();
                return;
            }

            List<Cliente> clientes = data.FilterSelect(like,exac,out exError);

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

        private void seleccionar_Click(object sender, EventArgs e)
        {
            String nombre = dataGridClientes.Rows[dataGridClientes.CurrentCell.RowIndex].Cells["clie_nombre"].Value.ToString();
            Int32 id = (Int32)dataGridClientes.Rows[dataGridClientes.CurrentCell.RowIndex].Cells["id_cliente"].Value;
            returnCliente = new Cliente();
            returnCliente.clie_nombre = nombre;
            returnCliente.id_cliente = id;
            this.DialogResult = DialogResult.OK;
                this.Close();
                return;
        }
    }
}
