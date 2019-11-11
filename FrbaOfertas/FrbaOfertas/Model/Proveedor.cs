using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Proveedor
    {
        public List<String> atributesModify = new List<string>();

        private Int32 _id_proveedor;
        private Int32 _id_domicilio;
        private Int32 _rubr_id;
        private Int32? _prove_usuario;
        private String _prov_CUIT;
        private String _usu_username;
        private String _prov_razon_social;
        private String _prov_email;        
        private String _prov_telefono;
        private String _prov_rubro;
        private String _prov_contacto;
        private Boolean _activo;

        public Int32 id_proveedor { get { return this._id_proveedor; } set { this._id_proveedor = value; } }
        [System.ComponentModel.Browsable(false)]
        public Int32 id_domicilio { get { return this._id_domicilio; } set { this._id_domicilio = value; atributesModify.Add("id_domicilio"); } }
        [System.ComponentModel.Browsable(false)]
        public Int32? prove_usuario { get { return this._prove_usuario; } set { this._prove_usuario = value; atributesModify.Add("prove_usuario"); } }
        [System.ComponentModel.DisplayName("CUIT")]
        public String prov_CUIT { get { return this._prov_CUIT; } set { this._prov_CUIT = value; atributesModify.Add("prov_CUIT"); } }
        [System.ComponentModel.DisplayName("Username")]
        public String usu_username { get { return this._usu_username; } set { this._usu_username = value; } }
        [System.ComponentModel.DisplayName("Razon Social")]
        public String prov_razon_social { get { return this._prov_razon_social; } set { this._prov_razon_social = value; atributesModify.Add("prov_razon_social"); } }
        [System.ComponentModel.DisplayName("Email")]
        public String prov_email { get { return this._prov_email; } set { this._prov_email = value; atributesModify.Add("prov_email"); } }
        [System.ComponentModel.DisplayName("Telefono")]
        public String prov_telefono { get { return this._prov_telefono; } set { this._prov_telefono = value; atributesModify.Add("prov_telefono"); } }
        [System.ComponentModel.Browsable(false)]
        public Int32 rubr_id { get { return this._rubr_id; } set { this._rubr_id = value; atributesModify.Add("rubr_id"); } }
        [System.ComponentModel.DisplayName("Rubro")]
        public String rubr_detalle { get { return this._prov_rubro; } set { this._prov_rubro = value; atributesModify.Add("rubr_detalle"); } }
        [System.ComponentModel.DisplayName("Contacto")]
        public String prov_contacto { get { return this._prov_contacto; } set { this._prov_contacto = value; atributesModify.Add("prov_contacto"); } }
        [System.ComponentModel.DisplayName("Activo")]
        public Boolean prov_activo { get { return this._activo; } set { this._activo = value; atributesModify.Add("prov_activo"); } }

        public Proveedor(){} 

        public Proveedor(SqlDataReader reader) 
        {
            try
            {
                id_proveedor = reader.GetInt32(0);
                id_domicilio = reader.GetInt32(1);
                if (!reader.IsDBNull(2))
                    prove_usuario = reader.GetInt32(2);
                if (!reader.IsDBNull(3))
                    usu_username = reader.GetString(3);
                prov_CUIT = reader.GetString(4);
                prov_razon_social = reader.GetString(5);
                if (!reader.IsDBNull(6))
                    prov_email = reader.GetString(6);
                if (!reader.IsDBNull(7))
                    prov_telefono = reader.GetString(7);
                if (!reader.IsDBNull(8))
                    prov_contacto = reader.GetString(8);               
                prov_activo = reader.GetBoolean(9);
                rubr_detalle = reader.GetString(10);               
            }
            catch { }
        }

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
