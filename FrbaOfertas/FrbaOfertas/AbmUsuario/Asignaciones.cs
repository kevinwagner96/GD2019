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

namespace FrbaOfertas.AbmUsuario
{
    public partial class Asignaciones : Form
    {
        public Cliente returnCliente { set; get;}
        public Proveedor returnProveedor { set; get; }
        int id_usuario;
        Exception exError;

        bool clienteBool=false;
        bool proveedorBool=false;


        List<TextBox> noNulos = new List<TextBox>();

        public Asignaciones(Boolean cliente,Boolean proveedor, int id_usuario)
        {
            InitializeComponent();

            clienteBool = cliente;
            proveedorBool = proveedor;

            if (!cliente && !proveedor) {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            this.id_usuario = id_usuario;

            if (cliente)
            {                
                seleccionar.Enabled = true;
                noNulos.Add(clie_nombre);
            }
            if (proveedor)
            {
                button1.Enabled = true;
                noNulos.Add(prov_razon_social);
            }


        }


        private void seleccionar_Click(object sender, EventArgs e)
        {
            ClienteList form = new ClienteList(true);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.returnCliente = form.returnCliente;
                clie_nombre.Text = this.returnCliente.clie_nombre;
                returnCliente.clie_usuario = id_usuario;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProveedoresList form = new ProveedoresList(true);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.returnProveedor = (Proveedor)form.returnProveedor;
                prov_razon_social.Text = this.returnProveedor.prov_razon_social;
                returnProveedor.prove_usuario = id_usuario;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!FormHelper.noNullList(noNulos))
                return;

            if (clienteBool)
            {
                ClienteData cData = new ClienteData(Conexion.getConexion());
                cData.Update(returnCliente, out exError);
                if (exError != null)                                
                    MessageBox.Show("Erro al agregar Cliente al Usuario,  ERROR: " + exError.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (proveedorBool)
            {
                ProveedorData pData = new ProveedorData(Conexion.getConexion());
                pData.Update(returnProveedor, out exError);
                if (exError != null)
                    MessageBox.Show("Erro al agregar Proveedor al Usuario,  ERROR: " + exError.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            


            this.DialogResult = DialogResult.OK;
            this.Close();
            return;
        }
    }
}
