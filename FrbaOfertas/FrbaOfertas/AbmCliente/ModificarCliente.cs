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
    public partial class ModificarCliente : Form
    {
        Int32 id_cliente;
        Cliente cliente;
        Direccion direccion;
        List<TextBox> noNulos= new List<TextBox>();
        List<TextBox> numericos= new List<TextBox>();
        List<TextBox> todos = new List<TextBox>();
        ClienteData dataC;
        DireccionData dataD;
        Exception exError = null;
        public ModificarCliente(int id)
        {
            InitializeComponent();
            id_cliente = id;
        }

         private void ModificarCliente_Load(object sender, EventArgs e)
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

            cliente= dataC.Read(id_cliente, out exError);
            clie_activo.Checked = cliente.clie_activo;

            direccion = dataD.Read(cliente.id_domicilio, out exError);

            FormHelper.setearTextBoxs(todos, cliente);
            clie_fecha_nac.Text = (DateTime.Parse(clie_fecha_nac.Text)).ToShortDateString();
            FormHelper.setearTextBoxs(todos, direccion);

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

            if (!FormHelper.noNullList(noNulos))
                return;
            if (!FormHelper.esNumericoList(numericos))
                return;

            //List<TextBox> datos = FormHelper.getNoNulos(todos);

            FormHelper.setearAtributos(todos, cliente);
            FormHelper.setearAtributos(todos, direccion);
            cliente.clie_activo = clie_activo.Checked;

            DialogResult result = MessageBox.Show("Seguro quiere modificar al cliente " + cliente.clie_nombre + ".", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dataC.Update(cliente, direccion, out exError);
                if (exError == null)
                {

                    this.Close();
                    //MessageBox.Show("Cliente  " + cliente.clie_nombre + " " + cliente.clie_apellido + " modificado exitosamente.", "Cliente nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);     
                }
                else
                    MessageBox.Show("Erro al modificar cliente, " + exError.Message, "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       

        


    }
}
