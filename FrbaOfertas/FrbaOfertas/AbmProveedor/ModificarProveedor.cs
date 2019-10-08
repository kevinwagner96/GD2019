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

namespace FrbaOfertas.AbmProveedor
{
    public partial class ModificarProveedor : Form
    {
        Int32 id_proveedor;
        Proveedor proveedor;
        Direccion direccion;
        List<TextBox> noNulos= new List<TextBox>();
        List<TextBox> numericos= new List<TextBox>();
        List<TextBox> todos = new List<TextBox>();
        ProveedorData dataP;
        DireccionData dataD;
        Exception exError = null;
        public ModificarProveedor(int id)
        {
            InitializeComponent();
            id_proveedor = id;
        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {
            noNulos.Add(prov_razon_social);
            noNulos.Add(prov_CUIT);
            noNulos.Add(prov_rubro);
            noNulos.Add(prov_contacto);
            noNulos.Add(dom_calle);
            noNulos.Add(dom_ciudad);
            numericos.Add(prov_CUIT);
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
            dataP = new ProveedorData(Conexion.getConexion());

            proveedor = dataP.Read(id_proveedor, out exError);
            prov_activo.Checked = proveedor.prov_activo;

            direccion = dataD.Read(proveedor.id_domicilio, out exError);

            FormHelper.setearTextBoxs(todos, proveedor);            
            FormHelper.setearTextBoxs(todos, direccion);
        }
   

     

        private void guardar_Click(object sender, EventArgs e)
        {           

            if (!FormHelper.noNullList(noNulos))
                return;
            if (!FormHelper.esNumericoList(numericos))
                return;

            //List<TextBox> datos = FormHelper.getNoNulos(todos);

            FormHelper.setearAtributos(todos, proveedor);
            FormHelper.setearAtributos(todos, direccion);
            proveedor.prov_activo = prov_activo.Checked;

            DialogResult result = MessageBox.Show("Seguro quiere modificar al proveedor " + proveedor.prov_razon_social + ".", "Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dataP.Update(proveedor, direccion, out exError);
                if (exError == null)
                {

                    this.Close();
                    //MessageBox.Show("Proveedor  " + proveedor.clie_nombre + " " + proveedor.clie_apellido + " modificado exitosamente.", "Proveedor nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);     
                }
                else
                    MessageBox.Show("Erro al modificar proveedor, " + exError.Message, "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

       

        


    }
}
