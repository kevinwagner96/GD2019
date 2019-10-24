using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    class TipoDePago
    {
        public List<String> atributesModify = new List<string>();

        Int32 _id_tipo_pago;
        String _tipo_pago_nombre;

        public TipoDePago(string p1, int p2)
        {
            // TODO: Complete member initialization
            this._tipo_pago_nombre = p1;
            this._id_tipo_pago = p2;
        }

        public TipoDePago()
        {
            // TODO: Complete member initialization
        }

        [System.ComponentModel.DisplayName("Codigo")]
        public Int32 id_tipo_pago { get { return this._id_tipo_pago; } set { this._id_tipo_pago = value; atributesModify.Add("id_tipo_pago"); } }
        [System.ComponentModel.DisplayName("Nombre")]
        public String tipo_pago_nombre { get { return this._tipo_pago_nombre; } set { this._tipo_pago_nombre = value; atributesModify.Add("tipo_pago_nombre"); } }
    }
}
