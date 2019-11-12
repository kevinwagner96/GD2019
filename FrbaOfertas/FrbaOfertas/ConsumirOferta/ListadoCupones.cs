
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

namespace FrbaOfertas.ConsumirOferta
{
    public partial class ListadoCupones : Form
    {
        CompraData cData;
        private static DateTime fecha = FrbaOfertas.ConfigurationHelper.FechaActual;
        Exception exError = null;
        public ListadoCupones()
        {
            InitializeComponent();
        }

        private void ListadoCupones_Load(object sender, EventArgs e)
        {
            cData = new CompraData(Conexion.getConexion());
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
            
            Dictionary<String, Object> dic = new Dictionary<String, Object>() { { "compra_fecha_vencimiento", fecha } };
            List<Compra> compras = cData.FilterSelect(new Dictionary<String, String>(), dic, out exError);

            if (exError == null)
            {
                dataGridOfertas.DataSource = compras;
                //dataGridOfertas.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("No se pudo obtener la lista de cupones, " + exError.Message);

        }

        private void cargarDataGrid(string busqueda)
        {
            Dictionary<String, String> like = new Dictionary<String, String>() { { "id_compra", busqueda } };
            Dictionary<String, Object> dic = new Dictionary<String, Object>() { { "compra_fecha_vencimiento", fecha } };
            List<Compra> compras = cData.FilterSelect(like, dic, out exError);

            if (exError == null)
            {
                dataGridOfertas.DataSource = compras;
                //dataGridOfertas.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("No se pudo obtener la lista de cupones, " + exError.Message);

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (cod_compra.Text.Count() > 0)
                cargarDataGrid(cod_compra.Text);
            else
                cargarDataGrid();
        
        
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            cod_compra.Text = "";
            cargarDataGrid();
        }

        private void canjear_Click(object sender, EventArgs e)
        {            
            Int32 id = (Int32)dataGridOfertas.Rows[dataGridOfertas.CurrentCell.RowIndex].Cells["id_compra"].Value;
            Compra compra = new Compra();
            compra.id_compra = id;
            CanjearCupon canjeo = new CanjearCupon();
            canjeo.MdiParent = this.ParentForm;
            canjeo.Show();

            return;
        }
    }
}
