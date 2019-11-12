using FrbaOfertas.AbmRubro;
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
        Dictionary<Int32, String> rubros;
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
            //noNulos.Add(prov_rubro);
            //noNulos.Add(prov_contacto);
            noNulos.Add(dom_calle);
            noNulos.Add(dom_ciudad);
            //numericos.Add(prov_CUIT);
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

            rubros = dataP.Rubros(out exError);
            agregarRubros(rubros);
            
           
        }

        private void setRubro(int p)
        {
            foreach (KeyValuePair<int, string> entry in rubros)
            {
                if (entry.Key == p)
                    rubrosComboBox.Text = entry.Value;
            }

        }

        private void agregarRubros(Dictionary<int, string> rubros)
        {
            foreach (KeyValuePair<int, string> entry in rubros)
            {
                rubrosComboBox.Items.Add(entry.Value);
            }
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
            proveedor.rubr_id = getRubroId(rubrosComboBox.Text);


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

        private int getRubroId(string p)
        {
            foreach (KeyValuePair<int, string> entry in rubros)
            {
                if (entry.Value == rubrosComboBox.Text)
                    return entry.Key;
            }
            return 0;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            NuevoRubro form = new NuevoRubro();
            form.Parent = this.Parent;
            var dialog = form.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                KeyValuePair<Int32, String> kv = dataP.CreateRubro(form.rubro, out exError);
                if (exError != null)
                {
                    MessageBox.Show("Error al agreagar el rubro.", "Proveedor nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    rubros.Add(kv.Key, kv.Value);
                    rubrosComboBox.Items.Add(kv.Value);
                }

            }
        }

        

       

        


    }
}
