using FrbaOfertas.AbmCliente;
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

namespace FrbaOfertas.ConsumirOferta
{
    public partial class CanjearCupon : Form
    {
        private static DateTime fecha = FrbaOfertas.ConfigurationHelper.FechaActual;
        Cliente cliente;
        Compra compra;


        public CanjearCupon(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            clie_nombre.Text = cliente.clie_nombre;
            id_compra.Enabled = true;
        }

        public CanjearCupon(object compra)
        {
            InitializeComponent();
            this.compra =(Compra) compra;
            id_compra.Text = this.compra.id_compra.ToString();
            seleccionar.Enabled = true;
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

        private void CanjearCupon_Load(object sender, EventArgs e)
        {
            ent_fecha.Text = fecha.ToShortDateString();
        }

        private void id_compra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
