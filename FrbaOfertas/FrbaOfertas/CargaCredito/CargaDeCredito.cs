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

namespace FrbaOfertas.CargaCredito
{
    public partial class CargaDeCredito : Form
    {
        Cliente cliente;
        Credito credito;
        TipoPagoData tData;
        CreditoData cData;

        private static string fecha = FrbaOfertas.ConfigurationHelper.FechaActual.ToString();
        List<TextBox> noNulos = new List<TextBox>();
        List<TextBox> numericos = new List<TextBox>();
        List<TextBox> todos = new List<TextBox>();
        List<TipoDePago> listPagos = new List<TipoDePago>();
        Exception exError = null;

        public CargaDeCredito()
        {
            InitializeComponent();
            cred_fecha.Text = fecha;

        }

        public CargaDeCredito(Cliente cliente )
        {            
            InitializeComponent();
            cred_fecha.Text = fecha;
            this.cliente = cliente;
            clie_nombre.Enabled = false;
            seleccionar.Enabled = false;
            clie_nombre.Text = cliente.clie_nombre;

            
        }

        private void cargarCombo()
        {
            listPagos = tData.Select(out exError);

            listPagos.ForEach(delegate(TipoDePago f)
            {
                if (f.tipo_pago_nombre != "Efectivo")
                    tipo_pago.Items.Add(f.tipo_pago_nombre);
            });
        }

        private void CargaDeCredito_Load(object sender, EventArgs e)
        {
            tData = new TipoPagoData(Conexion.getConexion());
            cData = new CreditoData(Conexion.getConexion());
            cargarCombo();

            noNulos.Add(cred_fecha);
            noNulos.Add(clie_nombre);            
            noNulos.Add(cred_num_tarjeta);
            noNulos.Add(cre_empresa_tarjeta);
            noNulos.Add(cred_cod_tarjeta);
            noNulos.Add(cred_monto);
            numericos.Add(cred_num_tarjeta);
            numericos.Add(cred_cod_tarjeta);
            numericos.Add(cred_monto);

            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    todos.Add((TextBox)x);
                }
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            credito = new Credito();
            
            if (!FormHelper.noNullList(noNulos) || !FormHelper.esNumericoList(numericos))
                return;

            

            if (tipo_pago.Text.Count() < 1)
            {
                MessageBox.Show("Selecciones un tipo de pago.");
                return;
            }

            

            FormHelper.setearAtributos(todos, credito);
            if (credito.cred_monto <= 0) {
                MessageBox.Show("El monto no puede ser negativo.");
                return;
            }
            credito.id_cliente = cliente.id_cliente;
            credito.id_tipo_pago = getPagoSeleccionado().id_tipo_pago;

            cData.Create(credito,  out exError);
            if (exError == null)
            {
                MessageBox.Show("Se acreditaron $" + credito.cred_monto + " a "+ cliente.clie_nombre +" .", "Carga de credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro al ralizar la carga de credito, " + exError.Message, "Carga de credito", MessageBoxButtons.OK, MessageBoxIcon.Error);    
        }


        private TipoDePago getPagoSeleccionado() {
            TipoDePago pago = new TipoDePago();
            listPagos.ForEach(delegate(TipoDePago f)
            {
                if (f.tipo_pago_nombre == tipo_pago.Text)
                    pago = f;
            });

            return pago;
        }

        private void seleccionar_Click(object sender, EventArgs e)
        {
            ClienteList form = new ClienteList(true);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.cliente=form.returnCliente;
                clie_nombre.Text = this.cliente.clie_nombre;
            }
        }

        private void clie_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
