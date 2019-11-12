using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class ListDescuento
    {
        public List<String> atributesModify = new List<string>();

        private Int32 _id_proveedor;
        private String _prov_CUIT;
        private String _prov_razon_social;
        private String _prov_email;
        private String _prov_telefono;
        private String _prov_rubro;
        private String _prov_contacto;
        private String _porcent;

        [System.ComponentModel.Browsable(false)]    
        public Int32 id_proveedor { get { return this._id_proveedor; } set { this._id_proveedor = value; } }  
        [System.ComponentModel.DisplayName("CUIT")]
        public String prov_CUIT { get { return this._prov_CUIT; } set { this._prov_CUIT = value; atributesModify.Add("prov_CUIT"); } }
        [System.ComponentModel.DisplayName("Razon Social")]
        public String prov_razon_social { get { return this._prov_razon_social; } set { this._prov_razon_social = value; atributesModify.Add("prov_razon_social"); } }
        [System.ComponentModel.DisplayName("Email")]
        public String prov_email { get { return this._prov_email; } set { this._prov_email = value; atributesModify.Add("prov_email"); } }
        [System.ComponentModel.DisplayName("Telefono")]
        public String prov_telefono { get { return this._prov_telefono; } set { this._prov_telefono = value; atributesModify.Add("prov_telefono"); } }        
        [System.ComponentModel.DisplayName("Rubro")]
        public String rubr_detalle { get { return this._prov_rubro; } set { this._prov_rubro = value; atributesModify.Add("rubr_detalle"); } }
        [System.ComponentModel.DisplayName("Contacto")]
        public String prov_contacto { get { return this._prov_contacto; } set { this._prov_contacto = value; atributesModify.Add("prov_contacto"); } }
        [System.ComponentModel.DisplayName("Descuento")]
        public String porcent { get { return this._porcent; } set { this._porcent = value; atributesModify.Add("porcent"); } }

        public ListDescuento() { }

        public ListDescuento(SqlDataReader reader)
        {
            try
            {
                id_proveedor = reader.GetInt32(0);               
                rubr_detalle = reader.GetString(1);
                prov_razon_social = reader.GetString(2);
                prov_CUIT = reader.GetString(3);
                if (!reader.IsDBNull(4))
                    prov_email = reader.GetString(4);
                if (!reader.IsDBNull(5))
                    prov_telefono = reader.GetString(5);
                if (!reader.IsDBNull(6))
                    prov_contacto = reader.GetString(6);
                porcent = reader.GetValue(7).ToString();
                
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
