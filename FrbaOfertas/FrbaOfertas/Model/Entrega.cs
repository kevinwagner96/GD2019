using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Entrega
    {

        public List<String> atributesModify = new List<string>();


        Int32 _id_entrega;
        DateTime _ent_fecha;
        Int32 _id_compra;
        Int32 _id_cliente;

        
        public Int32 id_entrega { get { return this._id_entrega; } set { this._id_entrega = value; atributesModify.Add("id_entrega"); } }
        
        public DateTime ent_fecha { get { return this._ent_fecha; } set { this._ent_fecha = value; atributesModify.Add("ent_fecha"); } }
        
        public Int32 id_compra { get { return this._id_compra; } set { this._id_compra = value; atributesModify.Add("id_compra"); } }
        
        public Int32 id_cliente { get { return this._id_cliente; } set { this._id_cliente = value; atributesModify.Add("id_cliente"); } }


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
