using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    class Proveedor
    {
        public List<String> atributesModify = new List<string>();

        private Int32 _id_proveedor;
        private Int32 _id_domicilio;
        private Int32? _prove_usuario;
        private String _prov_CUIT;
        private String _prov_razon_social;
        private String _prov_email;        
        private String _prov_telefono;
        private String _prov_rubro;
        private String _prov_contacto;
        private Boolean _activo;

        public Int32 id_proveedor { get { return this._id_proveedor; } set { this._id_proveedor = value; atributesModify.Add("id_proveedor"); } }
        [System.ComponentModel.Browsable(false)]
        public Int32 id_domicilio { get { return this._id_domicilio; } set { this._id_domicilio = value; atributesModify.Add("id_domicilio"); } }
        [System.ComponentModel.Browsable(false)]
        public Int32? prove_usuario { get { return this._prove_usuario; } set { this._prove_usuario = value; atributesModify.Add("prove_usuario"); } }
        [System.ComponentModel.DisplayName("CUIT")]
        public String prov_CUIT { get { return this._prov_CUIT; } set { this._prov_CUIT = value; atributesModify.Add("prov_CUIT"); } }
        [System.ComponentModel.DisplayName("Razon Social")]
        public String prov_razon_social { get { return this._prov_razon_social; } set { this._prov_razon_social = value; atributesModify.Add("prov_razon_social"); } }
        [System.ComponentModel.DisplayName("Email")]
        public String prov_email { get { return this._prov_email; } set { this._prov_email = value; atributesModify.Add("prov_email"); } }
        [System.ComponentModel.DisplayName("Telefono")]
        public String prov_telefono { get { return this._prov_telefono; } set { this._prov_telefono = value; atributesModify.Add("prov_telefono"); } }
        [System.ComponentModel.DisplayName("Rubro")]
        public String prov_rubro { get { return this._prov_rubro; } set { this._prov_rubro = value; atributesModify.Add("prov_rubro"); } }
        [System.ComponentModel.DisplayName("Contacto")]
        public String prov_contacto { get { return this._prov_contacto; } set { this._prov_contacto = value; atributesModify.Add("prov_contacto"); } }
        [System.ComponentModel.DisplayName("Activo")]
        public Boolean prov_activo { get { return this._activo; } set { this._activo = value; atributesModify.Add("prov_activo"); } }


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
