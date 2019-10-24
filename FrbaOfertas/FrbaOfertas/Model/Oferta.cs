using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    class Oferta
    {
        public List<String> atributesModify = new List<string>();

        String _id_oferta;
        Int32 _id_proveedor;
        String _ofer_descripcion;
        Int32 _ofer_cant_disp;
        Boolean _ofer_activo;
        DateTime _ofer_f_public;
        DateTime _ofer_f_venc;
        Double _ofer_pr_oferta;
        Double _ofer_pr_lista;
        Int32 _ofer_cant_x_cli;


        [System.ComponentModel.Browsable(false)]
        public String id_oferta { get { return this._id_oferta; } set { this._id_oferta = value; atributesModify.Add("id_oferta"); } }
        [System.ComponentModel.Browsable(false)]
        public Int32 id_proveedor { get { return this._id_proveedor; } set { this._id_proveedor = value; atributesModify.Add("id_proveedor"); } }
        [System.ComponentModel.DisplayName("Descripcion")]
        public String ofer_descripcion { get { return this._ofer_descripcion; } set { this._ofer_descripcion = value; atributesModify.Add("ofer_descripcion"); } }
        [System.ComponentModel.DisplayName("Cant. Disponible")]
        public Int32 ofer_cant_disp { get { return this._ofer_cant_disp; } set { this._ofer_cant_disp = value; atributesModify.Add("ofer_cant_disp"); } }
        [System.ComponentModel.DisplayName("Activo")]
        public Boolean ofer_activo { get { return this._ofer_activo; } set { this._ofer_activo = value; atributesModify.Add("ofer_activo"); } }
        [System.ComponentModel.DisplayName("Fecha Publicacion")]
        public DateTime ofer_f_public { get { return this._ofer_f_public; } set { this._ofer_f_public = value; atributesModify.Add("ofer_f_public"); } }
        [System.ComponentModel.DisplayName("Fecha Vencimiento")]
        public DateTime ofer_f_venc { get { return this._ofer_f_venc; } set { this._ofer_f_venc = value; atributesModify.Add("ofer_f_venc"); } }
        [System.ComponentModel.DisplayName("Precio Oferta")]
        public Double ofer_pr_oferta { get { return this._ofer_pr_oferta; } set { this._ofer_pr_oferta = value; atributesModify.Add("ofer_pr_oferta"); } }
        [System.ComponentModel.DisplayName("Precio Oferta")]
        public Double ofer_pr_lista { get { return this._ofer_pr_lista; } set { this._ofer_pr_lista = value; atributesModify.Add("ofer_pr_lista"); } }
        [System.ComponentModel.DisplayName("Cant. Disponible")]
        public Int32 ofer_cant_x_cli { get { return this._ofer_cant_x_cli; } set { this._ofer_cant_x_cli = value; atributesModify.Add("ofer_cant_x_cli"); } }

        public List<String> getAtributeMList()
        {
            return atributesModify.Distinct().ToList();
        }

        public dynamic getMethodString(String methodName)
        {
            return this.GetType().GetProperty(methodName).GetValue(this, null); ;
        }

        public void restartMList()
        {
            this.atributesModify.Clear();
        }

        public void setMethodString(String methodName, object value)
        {
            this.GetType().GetProperty(methodName).SetValue(this, value);
        }

    }
}
