using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Factura
    {

        public List<String> atributesModify = new List<string>();


        Int32 _id_fact;
        Int32 _id_proveedor;
        DateTime _fact_fecha;
        DateTime _fact_fecha_inicio;
        DateTime _fact_fecha_fin;
        Double _fact_importe=0;
        List<ItemFactura> _items= new List<ItemFactura>();

        public Int32 id_fact { get { return this._id_fact; } set { this._id_fact = value; } }

        public Int32 id_proveedor { get { return this._id_proveedor; } set { this._id_proveedor = value; atributesModify.Add("id_proveedor"); } }

        public DateTime fact_fecha { get { return this._fact_fecha; } set { this._fact_fecha = value; atributesModify.Add("fact_fecha"); } }

        public DateTime fact_fecha_inicio { get { return this._fact_fecha_inicio; } set { this._fact_fecha_inicio = value; atributesModify.Add("fact_fecha_inicio"); } }

        public DateTime fact_fecha_fin { get { return this._fact_fecha_fin; } set { this._fact_fecha_fin = value; atributesModify.Add("fact_fecha_fin"); } }

        public Double fact_importe { get { return this._fact_importe; } set { this._fact_importe = value; atributesModify.Add("fact_importe"); } }

        public List<ItemFactura> items { get { return this._items; } set { this._items = value; } }

        public void addItem(ItemFactura item) 
        {
            items.Add(item);
            fact_importe+=item.item_precio;
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
