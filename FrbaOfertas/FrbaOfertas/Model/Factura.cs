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
        Double _fact_importe;
        List<ItemFactura> items= new List<ItemFactura>();

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
