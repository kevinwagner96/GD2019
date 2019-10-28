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
        public object returnDireccion { get; set; }
        public object returnProveedor { get; set; }  
        ProveedorData dataP;
        DireccionData dataD;
        Exception exError = null;
        bool noDB=false;
        public NuevoProveedor(bool db)
        {
            InitializeComponent();
            noDB = db;
            
        }
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

            Dictionary<String, Object> exac = new Dictionary<string, Object>() { { "prov_razon_social", proveedor.prov_razon_social } };
            if (dataP.FilterSelect(new Dictionary<String, String>(), exac, out exError).Count() > 0)
            {
                MessageBox.Show("Erro al agregar proveedor, ya existe la razon social", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Dictionary<String, Object> exac2 = new Dictionary<string, Object>() { { "prov_CUIT", proveedor.prov_CUIT } };
            if (dataP.FilterSelect(new Dictionary<String, String>(), exac2, out exError).Count() > 0)
            {
                MessageBox.Show("Erro al agregar proveedor, ya existe el CUIT", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (noDB)
            {
                returnProveedor= proveedor;
                returnDireccion = direccion;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

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
