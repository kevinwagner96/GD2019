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
    public partial class NuevoProveedor : Form
    {
        
        List<TextBox> noNulos= new List<TextBox>();
        List<TextBox> numericos= new List<TextBox>();
        List<TextBox> todos = new List<TextBox>();
        ProveedorData dataP;
        DireccionData dataD;
        Exception exError = null;
        public NuevoProveedor()
        {
            InitializeComponent();
            
        }

        private void NuevoCliente_Load(object sender, EventArgs e)
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

           
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            Direccion direccion = new Direccion();

            if (!FormHelper.noNullList(noNulos) || !FormHelper.esNumericoList(numericos))
                return;

            //List<TextBox> datos = FormHelper.getNoNulos(todos);

            FormHelper.setearAtributos(todos, proveedor);
            FormHelper.setearAtributos(todos, direccion);
            proveedor.prov_activo = prov_activo.Checked;

            Int32 id = dataP.Create(proveedor, direccion, out exError);
            if (exError == null)
            {
                MessageBox.Show("Proveedor  " + proveedor.prov_razon_social + " agregado exitosamente.", "Proveedor nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro al agregar Proveedor, " + exError.Message, "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);    
          
            
        }

        

       

        


    }
}
