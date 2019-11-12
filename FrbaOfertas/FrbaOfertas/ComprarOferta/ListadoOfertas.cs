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

namespace FrbaOfertas.ComprarOferta
{
    public partial class ListadoOfertas : Form
    {
        Cliente cliente=null;
        OfertaData oData;
        private static DateTime fecha = FrbaOfertas.ConfigurationHelper.FechaActual;
        Exception exError = null;

        public ListadoOfertas()
        {
            InitializeComponent();
        }

        public ListadoOfertas(Cliente cliente)
        {

            InitializeComponent();
            this.cliente = cliente;
        }

        private void ComprarOferta_Load(object sender, EventArgs e)
        {
            oData = new OfertaData(Conexion.getConexion());
            cargarDataGrid();
        }

        private void cargarDataGrid()
        {

            Dictionary<String, Object> dic = new Dictionary<String, Object>() { { "ofer_f_public", fecha } };            
            List<Oferta> proveedores = oData.FilterSelect(new Dictionary<String, String>(),dic,out exError);

            if (exError == null)
            {
                dataGridOfertas.DataSource = proveedores;
                dataGridOfertas.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("No se pudo obtener la lista de ofertas, " + exError.Message);

        }

        private void comprar_Click(object sender, EventArgs e)
        {
            String oferta = dataGridOfertas.Rows[dataGridOfertas.CurrentCell.RowIndex].Cells["id_oferta"].Value.ToString();

            if (cliente == null) {                

                CompraOferta form2 = new CompraOferta( oferta);
                form2.ShowDialog();
                form2.Focus();
                return;
            }

            CompraOferta form = new CompraOferta(cliente , oferta);
            form.ShowDialog();
            form.Focus();
            
        }
    }
}
