using FrbaOfertas.AbmProveedor;
using FrbaOfertas.DataModel;
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

namespace FrbaOfertas.AbmProveedor
{
    public partial class UsuariosList : Form
    {
        UsuarioData data;
        List<TextBox> todos = new List<TextBox>();
        public object returnProveedor { get; set; }
        Exception exError = null;

        public UsuariosList()
        {
            InitializeComponent();
            data = new UsuarioData(Conexion.getConexion());
            
        }

        public UsuariosList(bool seleccionar)
        {
            InitializeComponent();
            data = new UsuarioData(Conexion.getConexion());
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
            NuevoUsuario nc = new NuevoUsuario();
            nc.ShowDialog();
            nc.Focus();
            cargarDataGrid();
        }

        private void ClienteList_Load(object sender, EventArgs e)
        {
            
            todos.Add(prov_CUIT);
            todos.Add(prov_email);
            todos.Add(prov_razon_social);
            
                
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {

            List<Usuario> usuarios = data.Select(out exError);

            if (exError == null)
            {
                dataGridProveedores.DataSource = usuarios;
                dataGridProveedores.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("No se pudo obtener la lista de usuarios, " + exError.Message);
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Int32 id = (Int32) dataGridProveedores.Rows[dataGridProveedores.CurrentCell.RowIndex].Cells["id_proveedor"].Value;
            ModificarProveedor modificarProveedor = new ModificarProveedor(id);
            modificarProveedor.ShowDialog();
            modificarProveedor.Focus();
            cargarDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String nombre = dataGridProveedores.Rows[dataGridProveedores.CurrentCell.RowIndex].Cells["prov_razon_social"].Value.ToString();
            Int32 id = (Int32)dataGridProveedores.Rows[dataGridProveedores.CurrentCell.RowIndex].Cells["id_proveedor"].Value;

            DialogResult result = MessageBox.Show("Seguro quiere eliminar al proveedor " + nombre + ".", "Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

            List<Usuario> proveedores = data.FilterSelect(like,exac,out exError);

            if (exError == null)
            {
                dataGridProveedores.DataSource = proveedores;
                dataGridProveedores.Columns[0].Visible = false;
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

        private void select_Click(object sender, EventArgs e)
        {
            String razonSocial = dataGridProveedores.Rows[dataGridProveedores.CurrentCell.RowIndex].Cells["prov_razon_social"].Value.ToString();
            Int32 id = (Int32)dataGridProveedores.Rows[dataGridProveedores.CurrentCell.RowIndex].Cells["id_proveedor"].Value;
            returnProveedor = new Proveedor();
            ((Proveedor)returnProveedor).prov_razon_social = razonSocial;
            ((Proveedor)returnProveedor).id_proveedor = id;
            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }
    }
}
