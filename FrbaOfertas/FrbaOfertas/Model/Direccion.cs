using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    class Direccion
    {
        public List<String> atributesModify = new List<string>();


        private Int32 _id_domicilio;
        private String _dom_calle;
        private String _dom_numero ;
        private Int32 _dom_depto;
        private Int32 _dom_piso;
        private String _dom_ciudad;
        private String _dom_localidad;
        private String _dom_codigo_postal;

        public Int32 id_domicilio { get { return this._id_domicilio; } set { this._id_domicilio = value; atributesModify.Add("id_domicilio"); } }
        [System.ComponentModel.DisplayName("Calle")]
        public String dom_calle { get { return this._dom_calle; } set { this._dom_calle = value; atributesModify.Add("dom_calle"); } }
        [System.ComponentModel.DisplayName("Numero")]
        public String dom_numero { get { return this._dom_numero; } set { this._dom_numero = value; atributesModify.Add("dom_numero"); } }
        [System.ComponentModel.DisplayName("Depto")]
        public Int32 dom_depto { get { return this._dom_depto; } set { this._dom_depto = value; atributesModify.Add("dom_depto"); } }
        [System.ComponentModel.DisplayName("Piso")]
        public Int32 dom_piso { get { return this._dom_piso; } set { this._dom_piso = value; atributesModify.Add("dom_piso"); } }
        [System.ComponentModel.DisplayName("Ciudad")]
        public String dom_ciudad { get { return this._dom_ciudad; } set { this._dom_ciudad = value; atributesModify.Add("dom_ciudad"); } }
        [System.ComponentModel.DisplayName("Localidad")]
        public String dom_localidad { get { return this._dom_localidad; } set { this._dom_localidad = value; atributesModify.Add("dom_localidad"); } }
        [System.ComponentModel.DisplayName("Cod Postal")]
        public String dom_codigo_postal { get { return this._dom_codigo_postal; } set { this._dom_codigo_postal = value; atributesModify.Add("dom_codigo_postal"); } }

        public List<String> getAtributeMList()
        {
            return atributesModify.Distinct().ToList();
        }

        public dynamic getMethodString(String methodName)
        {
            return this.GetType().GetProperty(methodName).GetValue(this, null); ;
        }

    }
}
