using FrbaOfertas.AbmProveedor;
using FrbaOfertas.Helpers;
using FrbaOfertas.Model;
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
    public partial class NuevaFactura : Form
    {
        Proveedor proveedor;
        List<TextBox> noNulos = new List<TextBox>();
        private static DateTime fecha = FrbaOfertas.ConfigurationHelper.FechaActual;
        public NuevaFactura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inicioCalenda.Visible = true;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            finalCalendar.Visible = true;
        }

        private void finalCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            finalCalendar.Visible = false;
            fin.Text = finalCalendar.SelectionStart.ToShortDateString();
        }

        private void inicioCalenda_DateSelected(object sender, DateRangeEventArgs e)
        {
            inicioCalenda.Visible = false;
            inicio.Text = inicioCalenda.SelectionStart.ToShortDateString();
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            ProveedoresList form = new ProveedoresList(true);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.proveedor = (Proveedor)form.returnProveedor;
                clie_nombre.Text = this.proveedor.prov_razon_social;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!FormHelper.noNullList(noNulos))
                return;

            

            Factura factura = new Factura();
            factura.id_proveedor = proveedor.id_proveedor;
            factura.fact_fecha = fecha;
            factura.fact_fecha_inicio = DateTime.Parse(inicio.Text);
            factura.fact_fecha_fin = DateTime.Parse(fin.Text);

           if (FormHelper.fechaMayor(factura.fact_fecha_inicio , factura.fact_fecha_fin)      )          
                return;

           if (FormHelper.fechaMayorAactual(factura.fact_fecha_fin, fecha))
               return;
            


            FacturarListado form = new FacturarListado(factura);            
            form.ShowDialog();
        }

        private void MessageBox(string p)
        {
            throw new NotImplementedException();
        }

        private void NuevaFactura_Load(object sender, EventArgs e)
        {
            noNulos.Add(inicio);
            noNulos.Add(fin);
            noNulos.Add(clie_nombre);
        }
    }
}
