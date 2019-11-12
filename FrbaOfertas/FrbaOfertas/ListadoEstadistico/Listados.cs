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

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class Listados : Form
    {
        DataGeneric data;
        Exception exError = null;
        

        public Listados()
        {
            InitializeComponent();
            data = new DataGeneric(Conexion.getConexion());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<String> anios = data.getAniosFacturados(out exError);

            foreach (String a in anios)
            {
                anio.Items.Add(a);
            }

            semestre.Items.Add("Primero");
            semestre.Items.Add("Segundo");

            tipo.Items.Add("Proveedores con mayor facturacion.");
            tipo.Items.Add("Proveedores con mayor descuento.");


        }


        private void limpiar_Click(object sender, EventArgs e)
        {
            if (semestre.Text == "" || anio.Text == "" || tipo.Text=="") {
                MessageBox.Show("Semestre,Año y Tipo no pueden ser nulos.", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime start, end;


            if (semestre.Text == "Primero")
            {
                start = DateTime.Parse("01-01-" + anio.Text);
                end = DateTime.Parse("01-07-" + anio.Text);
            }
            else
            {
                start = DateTime.Parse("01-07-" + anio.Text);
                end = DateTime.Parse("31-12-" + anio.Text);
            }

            if (tipo.Text == "Proveedores con mayor facturacion.")
            {
                MessageBox.Show("Proveedores con mayor facturacion desde " + start.ToShortDateString() + " hasta " + end.ToShortDateString(), "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDataGridFacturacion(start, end);
            }
            else
            {
                MessageBox.Show("Proveedores con mayor descuento desde " + start.ToShortDateString() + " hasta " + end.ToShortDateString(), "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDataGridDescuento(start, end);
            }
            



        }

        private void cargarDataGridFacturacion(DateTime desde,DateTime hasta)
        {
            List<ListFacturacion> listado = data.mayorFacturacion(desde,hasta,out exError);

            if (exError == null)
            {
                listadosGrid.DataSource = listado;                
            }
            else
                MessageBox.Show("No se pudo obtener la lista , " + exError.Message);
        }

        private void cargarDataGridDescuento(DateTime desde, DateTime hasta)
        {
            List<ListDescuento> listado = data.mayorDescuento(desde, hasta, out exError);

            if (exError == null)
            {
                listadosGrid.DataSource = listado;
            }
            else
                MessageBox.Show("No se pudo obtener la lista , " + exError.Message);
        }

   
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listadosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
