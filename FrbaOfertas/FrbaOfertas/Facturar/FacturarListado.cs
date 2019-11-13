using FrbaFacturas.Model.DataModel;
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

namespace FrbaOfertas.Facturar
{
    public partial class FacturarListado : Form
    {
        private Model.Factura factura;
        FacturaData data;
        DataGeneric gdata;
        Exception exError = null;

        public FacturarListado()
        {
            InitializeComponent();
            data = new FacturaData(Conexion.getConexion());
            gdata = new DataGeneric(Conexion.getConexion());
        }

        public FacturarListado(Model.Factura factura)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            data = new FacturaData(Conexion.getConexion());
            gdata = new DataGeneric(Conexion.getConexion());
            this.factura = factura;
        }

        private void FacturarListado_Load(object sender, EventArgs e)
        {

            cargarDataGrid();
        }

        private void cargarDataGrid()
        {
            List<Compra> compras = data.SelectCompras(factura, out exError);

            if (exError == null)
            {
                total_f.Text = factura.fact_importe.ToString("n2");
                cant_items.Text = "$"+factura.items.Count().ToString();
                

                dataGridClientes.DataSource = compras;
                dataGridClientes.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("No se pudo obtener la lista de comrpas, " + exError.Message);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Factura response = gdata.facturar(factura, out exError);
            if (exError != null)
            {
                MessageBox.Show("No se pudo facturar, " + exError.Message);
                return;
            }

            DialogResult result = MessageBox.Show("FACTURA N: " + response.id_fact + " \n IMPORTE: $" + response.fact_importe.ToString("n2"), "FACTURA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
