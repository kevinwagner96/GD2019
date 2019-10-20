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

namespace FrbaOfertas.AbmRol
{
    public partial class RolesList : Form
    {

        RolData data;
        List<TextBox> todos = new List<TextBox>();
        Exception exError = null;


        public RolesList()
        {
            InitializeComponent();
            data = new RolData(Conexion.getConexion());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {

            List<Rol> roles = data.Select(out exError);

            if (exError == null)
            {
                dataGridRoles.DataSource = roles;
                dataGridRoles.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("No se pudo obtener la lista de Roles, " + exError.Message);

        }
        private void nuevo_Click(object sender, EventArgs e)
        {
            NuevoRol nc = new NuevoRol();
            nc.ShowDialog();
            nc.Focus();
            cargarDataGrid();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Int32 id = (Int32)dataGridRoles.Rows[dataGridRoles.CurrentCell.RowIndex].Cells["id_rol"].Value;
            ModificarRol nc = new ModificarRol(id);
            nc.ShowDialog();
            nc.Focus();
            cargarDataGrid();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            Int32 id = (Int32)dataGridRoles.Rows[dataGridRoles.CurrentCell.RowIndex].Cells["id_rol"].Value;            

            DialogResult result = MessageBox.Show("Seguro quiere eliminar al rol", "Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                data.Delete(id, out exError);
                if (exError == null)
                {
                    cargarDataGrid();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el rol, " + exError.Message);
                    return;
                }


            }
        }
    }
}
