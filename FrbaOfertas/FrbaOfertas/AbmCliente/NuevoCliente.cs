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
        List<TextBox> noNulos= new List<TextBox>();
        List<TextBox> numericos= new List<TextBox>();
        List<TextBox> todos = new List<TextBox>();
        ClienteData dataC;
        DireccionData dataD;
        Exception exError = null;
        public NuevoCliente()
        {
            InitializeComponent();
            
        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {
            noNulos.Add(clie_nombre);
            noNulos.Add(clie_apellido);
            noNulos.Add(clie_dni);
            noNulos.Add(clie_fecha_nac);
            noNulos.Add(dom_calle);
            noNulos.Add(dom_ciudad);
            numericos.Add(clie_dni);
            numericos.Add(dom_numero);
            numericos.Add(dom_depto);
            numericos.Add(dom_piso);

            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    todos.Add((TextBox)x);
                }
            }

            dataD = new DireccionData(Conexion.getConexion());
            dataC = new ClienteData(Conexion.getConexion());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
            clie_fecha_nac.Text = monthCalendar1.SelectionStart.ToShortDateString();
            
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            Direccion direccion = new Direccion();

            if (!FormHelper.noNullList(noNulos))
                return;
            if (!FormHelper.esNumericoList(numericos))
                return;

            List<TextBox> datos = FormHelper.getNoNulos(todos);

            FormHelper.setearAtributos(datos, cliente);
            FormHelper.setearAtributos(datos, direccion);

            cliente.clie_credito = ConfigurationHelper.CreditoInicial;
            cliente.clie_activo = true;
            
            Int32 id = dataC.Create(cliente,direccion, out exError);             
            if (exError == null)
            {
                MessageBox.Show("Cliente  " + cliente.clie_nombre + " " + cliente.clie_apellido + " agregado exitosamente.", "Cliente nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro al agregar cliente, " + exError.Message,"Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);    
          

        }

        


    }
}
