using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Credito
    {
        public List<String> atributesModify = new List<string>();

        Int32 _id_carga_credito;
        Int32 _id_cliente;
        Int32 _id_tipo_pago;
        DateTime _cred_fecha;
        Double _cred_monto;
        Int32 _cred_num_tarjeta;
        String _cre_empresa_tarjeta;
        Int32 _cred_cod_tarjeta;

        public Int32 id_carga_credito { get { return this._id_carga_credito; } set { this._id_carga_credito = value; atributesModify.Add("id_carga_credito"); } }
        public Int32 id_cliente { get { return this._id_cliente; } set { this._id_cliente = value; atributesModify.Add("id_cliente"); } }
        public Int32 id_tipo_pago { get { return this._id_tipo_pago; } set { this._id_tipo_pago = value; atributesModify.Add("id_tipo_pago"); } }
        [System.ComponentModel.DisplayName("Fecha")]
        public DateTime cred_fecha { get { return this._cred_fecha; } set { this._cred_fecha = value; atributesModify.Add("cred_fecha"); } }
        [System.ComponentModel.DisplayName("Monto")]
        public Double cred_monto { get { return this._cred_monto; } set { this._cred_monto = value; atributesModify.Add("cred_monto"); } }
        [System.ComponentModel.DisplayName("Numero Tarjeta")]
        public Int32 cred_num_tarjeta { get { return this._cred_num_tarjeta; } set { this._cred_num_tarjeta = value; atributesModify.Add("cred_num_tarjeta"); } }
        [System.ComponentModel.DisplayName("Nombre Empresa")]
        public String cre_empresa_tarjeta { get { return this._cre_empresa_tarjeta; } set { this._cre_empresa_tarjeta = value; atributesModify.Add("cre_empresa_tarjeta"); } }
        [System.ComponentModel.DisplayName("Codigo")]
        public Int32 cred_cod_tarjeta { get { return this._cred_cod_tarjeta; } set { this._cred_cod_tarjeta = value; atributesModify.Add("cred_cod_tarjeta"); } }


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
