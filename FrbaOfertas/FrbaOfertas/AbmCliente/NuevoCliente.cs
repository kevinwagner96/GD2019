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

namespace FrbaOfertas.AbmCliente
{
    public partial class NuevoCliente : Form
    {
        ClienteData dataC;
        DireccionData dataD;
        Exception exError = null;
        public NuevoCliente()
        {
            InitializeComponent();
            dataD = new DireccionData(Conexion.getConexion());
            dataC = new ClienteData(Conexion.getConexion()); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
            textFNacimiento.Text = monthCalendar1.SelectionStart.ToShortDateString();
            
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            
            Cliente cliente = new Cliente();
            cliente.clie_nombre =  textBoxNombre.Text;
            cliente.clie_apellido = textBoxApellido.Text;
            try{
                cliente.clie_dni = Int32.Parse(textBoxDNI.Text);                
            }
            catch{
               MessageBox.Show("El campo DNI no es un numero");
               return;
            }

            try{
                cliente.clie_fecha_nac = DateTime.Parse(textFNacimiento.Text);
            }
            catch
            {
                MessageBox.Show("El campo Fecha es invalido");
                return;
            }

            cliente.clie_email =  textBoxEmail.Text;
            cliente.clie_telefono =  textBoxTelefono.Text;
            cliente.clie_credito = 0;
            cliente.clie_activo = true;
            
            Direccion direccion = new Direccion();
            direccion.dom_calle = textBoxCalle.Text;
            direccion.dom_numero = textBoxNumero.Text;
            try
            {
                if (textBoxDepartamento.Text != "")
                    direccion.dom_depto = Int32.Parse(textBoxDepartamento.Text);
            }
            catch
            {
                MessageBox.Show("El campo Departamento no es un numero");
                return;
            }
            
            try
            {
                if(textBoxPiso.Text!="")
                    direccion.dom_piso = Int32.Parse(textBoxPiso.Text);
            }
            catch
            {
                MessageBox.Show("El campo Piso no es un numero");
                return;
            }
            
            direccion.dom_ciudad = textBoxCiudad.Text;
            direccion.dom_localidad = textBoxLocalidad.Text;
            direccion.dom_codigo_postal = textBoxCodPostal.Text;

            Int32 id = dataD.Create(direccion, out exError);
            if (exError == null)
            {
                cliente.id_domicilio = id;
                 MessageBox.Show( id.ToString());
                 Int32  cliid =  dataC.Create(cliente, out exError);
                if (exError == null)
                {
                    MessageBox.Show("Cliente  " + cliente.clie_nombre + " " + cliente.clie_apellido + " agregado exitosamente.", "Cliente nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);     
                }
                else
                    MessageBox.Show("Erro al agregar cliente, " + exError.Message,"Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            else
                MessageBox.Show("Erro al  agregar direccion, " + exError.Message,"Direccion", MessageBoxButtons.OK, MessageBoxIcon.Error);    




        }
    }
}
