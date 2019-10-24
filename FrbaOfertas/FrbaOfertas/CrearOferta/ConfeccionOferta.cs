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

namespace FrbaOfertas.CrearOferta
{
    public partial class ConfeccionOferta : Form
    {
        Proveedor proveedor;
        Oferta oferta;
        OfertaData oData;

        private static DateTime fecha = FrbaOfertas.ConfigurationHelper.FechaActual;
        private static Int32 tokenSize = FrbaOfertas.ConfigurationHelper.TokenSize;
        List<TextBox> noNulos = new List<TextBox>();
        List<TextBox> numericos = new List<TextBox>();
        List<TextBox> todos = new List<TextBox>();
        List<TipoDePago> listPagos = new List<TipoDePago>();
        Exception exError = null;

        public ConfeccionOferta()
        {
            InitializeComponent();
        }

        public ConfeccionOferta(object prov)
        {
            InitializeComponent();
            this.proveedor = (Proveedor)prov;
        }

        private void ConfeccionOferta_Load(object sender, EventArgs e)
        {
            oData = new OfertaData(Conexion.getConexion());

            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    todos.Add((TextBox)x);
                }
            }

            noNulos.Add(ofer_descripcion);
            noNulos.Add(ofer_cant_disp);
            noNulos.Add(ofer_f_public);
            noNulos.Add(ofer_f_venc);
            noNulos.Add(ofer_pr_lista);
            noNulos.Add(ofer_pr_oferta);
            noNulos.Add(ofer_cant_x_cli);
            numericos.Add(ofer_cant_disp);
            numericos.Add(ofer_pr_lista);
            numericos.Add(ofer_pr_oferta);
            numericos.Add(ofer_cant_x_cli);

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            publciacionCalendar.Visible = true;
        }

        private void publciacionCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            publciacionCalendar.Visible = false;
            ofer_f_public.Text = publciacionCalendar.SelectionStart.ToShortDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vencimientoCalendar.Visible = true;
        }

        private void vencimientoCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            vencimientoCalendar.Visible = false;
            ofer_f_venc.Text = vencimientoCalendar.SelectionStart.ToShortDateString();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            oferta = new Oferta();

            if (!FormHelper.esFecha(ofer_f_venc) || !FormHelper.esFecha(ofer_f_public))
                return;

            if (!FormHelper.noNullList(noNulos) || !FormHelper.esNumericoList(numericos))
                return;

            
           
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");
            string id_oferta = token.Substring(0, tokenSize);

            FormHelper.setearAtributos(todos, oferta);

            if (DateTime.Compare(oferta.ofer_f_public, fecha) < 0) {
                MessageBox.Show(ofer_f_public.Tag +" es menor a la fecha actual. ["+fecha+"]");
                return;
            }
            if (DateTime.Compare(oferta.ofer_f_venc, oferta.ofer_f_public) < 0)
            {
                MessageBox.Show(ofer_f_public.Tag + " es menor a "+ofer_f_venc.Tag);
                return;
            }


            oferta.id_proveedor = proveedor.id_proveedor;
            oferta.id_oferta = id_oferta;
            oferta.ofer_activo = true;

            oData.Create(oferta, out exError);
            if (exError == null)
            {
                MessageBox.Show("Oferta " + oferta.ofer_descripcion + " lista.", "Nueva Oferta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro al ralizar la oferta, " + exError.Message, "Nueva Oferta", MessageBoxButtons.OK, MessageBoxIcon.Error);    

        }

        

        
    }
}
