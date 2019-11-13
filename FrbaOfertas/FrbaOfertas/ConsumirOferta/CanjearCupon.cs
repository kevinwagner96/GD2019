using FrbaOfertas.AbmCliente;
using FrbaOfertas.AbmProveedor;
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

namespace FrbaOfertas.ConsumirOferta
{
    public partial class CanjearCupon : Form
    {
        private static DateTime fecha = FrbaOfertas.ConfigurationHelper.FechaActual;
        DataGeneric data;
        Cliente cliente;
        Proveedor proveedor;
        Compra compra;
        Exception exError = null;


        public CanjearCupon(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            data = new DataGeneric(Conexion.getConexion());
            clie_nombre.Text = cliente.clie_nombre;
            id_compra.Enabled = true;
        }

        public CanjearCupon()
        {
            InitializeComponent();                        
            data = new DataGeneric(Conexion.getConexion());
            id_compra.Enabled = true;
            seleccionar.Enabled = true;
            seleecionar_proveedor.Visible = true;
            seleecionar_proveedor.Enabled = true;
            nombre_proveedor.Enabled = false;
        }

        public CanjearCupon(Proveedor proveedor)
        {
            InitializeComponent();
            this.proveedor = proveedor;
            nombre_proveedor.Text = proveedor.prov_razon_social;
            data = new DataGeneric(Conexion.getConexion());
            id_compra.Enabled = true;
            seleccionar.Enabled = true;
            seleecionar_proveedor.Visible = false;
            nombre_proveedor.Enabled = false;
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
            
        }

        private void id_compra_TextChanged(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (!FormHelper.esNumerico(id_compra)) {
                MessageBox.Show("El id de cupon deber ser numerico");
                return;
            }

            if (!FormHelper.noNull(clie_nombre))
            {
                MessageBox.Show("No ha seleccionado un cliente");
                return;
            }



            data.entregarCompra(proveedor.id_proveedor, Int32.Parse(id_compra.Text), cliente.id_cliente, fecha, out exError);
            if (exError == null)
            {               
                MessageBox.Show("Cupon canjeado ");
            }
            else
                MessageBox.Show("No se pudo canjear el cupon, "+exError.Message);

        }

        private void seleecionar_proveedor_Click(object sender, EventArgs e)
        {
            ProveedoresList form = new ProveedoresList(true);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.proveedor = (Proveedor)form.returnProveedor;
                nombre_proveedor.Text = this.proveedor.prov_razon_social;
            }
        }
    }
}
