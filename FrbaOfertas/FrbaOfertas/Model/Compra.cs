using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Compra
    {
        public List<String> atributesModify = new List<string>();

        Int32 _id_compra;
        Int32 _id_oferta;
        Int32 _id_cliente;
        DateTime _compra_fecha;
        Double _compra_precio_lista;
        Double _compra_precio_oferta;
        Int32 _compra_cantidad;
        Boolean _compra_canjeado;
        DateTime _compra_fecha_vencimiento;

        
        [System.ComponentModel.Browsable(false)]
        public Int32 id_oferta { get { return this._id_oferta; } set { this._id_oferta = value; atributesModify.Add("id_oferta"); } }
        [System.ComponentModel.Browsable(false)]
        public Int32 id_cliente { get { return this._id_cliente; } set { this._id_cliente = value; atributesModify.Add("id_cliente"); } }
        [System.ComponentModel.DisplayName("IdCompra/Cupon")]
        public Int32 id_compra { get { return this._id_compra; } set { this._id_compra = value; atributesModify.Add("id_compra"); } }
        [System.ComponentModel.DisplayName("Fecha Compra")]
        public DateTime compra_fecha { get { return this._compra_fecha; } set { this._compra_fecha = value; atributesModify.Add("compra_fecha"); } }
        [System.ComponentModel.DisplayName("Precio Lista")]
        public Double compra_precio_lista { get { return this._compra_precio_lista; } set { this._compra_precio_lista = value; atributesModify.Add("compra_precio_lista"); } }
        [System.ComponentModel.DisplayName("Precio Oferta")]
        public Double compra_precio_oferta { get { return this._compra_precio_oferta; } set { this._compra_precio_oferta = value; atributesModify.Add("compra_precio_oferta"); } }
        [System.ComponentModel.DisplayName("Cant.")]
        public Int32 compra_cantidad { get { return this._compra_cantidad; } set { this._compra_cantidad = value; atributesModify.Add("compra_cantidad"); } }
        [System.ComponentModel.DisplayName("Canjeado")]
        public Boolean compra_canjeado { get { return this._compra_canjeado; } set { this._compra_canjeado = value; atributesModify.Add("compra_canjeado"); } }               
        [System.ComponentModel.DisplayName("Fecha Vencimiento")]
        public DateTime compra_fecha_vencimiento { get { return this._compra_fecha_vencimiento; } set { this._compra_fecha_vencimiento = value; atributesModify.Add("compra_fecha_vencimiento"); } }
        


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
