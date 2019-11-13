using FrbaOfertas.AbmCliente;
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

namespace FrbaOfertas.ComprarOferta
{
    public partial class CompraOferta : Form
    {
        private static DateTime fecha = FrbaOfertas.ConfigurationHelper.FechaActual;
        DataGeneric data;
        Exception exError = null;
        Cliente cliente;
        Oferta oferta;
        public CompraOferta()
        {
            InitializeComponent();
            data = new DataGeneric(Conexion.getConexion());
        }

        public CompraOferta(Cliente cliente, String oferta)
        {
            InitializeComponent();
            data = new DataGeneric(Conexion.getConexion());
            this.cliente = cliente;
            //this.oferta = oferta;
            clie_nombre.Text = cliente.clie_nombre;
            id_oferta.Text = oferta;

        }

        public CompraOferta( String oferta)
        {
            InitializeComponent();
            data = new DataGeneric(Conexion.getConexion());            
            //this.oferta = oferta;
            //clie_nombre.Text = cliente.clie_nombre;
            id_oferta.Text = oferta;
            seleccionar.Enabled = true;
        }

        private void CompraOferta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!FormHelper.esNumerico(cantidad)) {
                MessageBox.Show("Cantidad no es numerico");
                return;
            }

            if (!FormHelper.noNull(clie_nombre))
            {
                MessageBox.Show("Cliente no seleccionado");
                return;
            }

            if (Int32.Parse(cantidad.Text) <= 0)
            {
                MessageBox.Show("La cantidad no puede ser negativa.");
                return;
            }

            String codigo =  data.realizarCompra(cliente.id_cliente, id_oferta.Text, Int32.Parse(cantidad.Text), fecha,out exError);
            if (exError == null)
            {
                MessageBox.Show("Compra realizada el codigo de cupon es : "+codigo);
            }
            else
                MessageBox.Show("No se pudo comprar la oferta "+exError);

            this.Close();

        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            ClienteList form = new ClienteList(true);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.cliente = form.returnCliente;
                clie_nombre.Text = this.cliente.clie_nombre;
            }
        }
    }
}
