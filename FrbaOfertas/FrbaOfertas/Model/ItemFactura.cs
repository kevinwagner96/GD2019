using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class ItemFactura
    {
        public List<String> atributesModify = new List<string>();

        Int32 _id_fact;
        Int32 _id_compra;
        Double _item_precio;
        DateTime _item_fecha_compra;

        public ItemFactura(int p1, int p2, double p3, DateTime dateTime)
        {
            // TODO: Complete member initialization
            this._id_fact = p1;
            this._id_compra = p2;
            this._item_precio = p3;
            this._item_fecha_compra = dateTime;
        }

        public ItemFactura(Int32 id_factura,Compra compra)
        {
            id_fact = id_factura;
            id_compra = compra.id_compra;
            item_precio = compra.compra_precio_oferta * compra.compra_cantidad;
            item_fecha_compra = compra.compra_fecha;
        }

        public Int32 id_fact { get { return this._id_fact; } set { this._id_fact = value; atributesModify.Add("id_fact"); } }

        public Int32 id_compra { get { return this._id_compra; } set { this._id_compra = value; atributesModify.Add("id_compra"); } }

        public Double item_precio { get { return this._item_precio; } set { this._item_precio = value; atributesModify.Add("item_precio"); } }

        public DateTime item_fecha_compra { get { return this._item_fecha_compra; } set { this._item_fecha_compra = value; atributesModify.Add("item_fecha_compras"); } }


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
