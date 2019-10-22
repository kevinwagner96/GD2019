using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    class Factura
    {
        Int32 _id_fact;
        Int32 _id_proveedor;
        DateTime _fact_fecha;
        DateTime _fact_fecha_inicio;
        DateTime _fact_fecha_fin;
        Double _fact_importe;
        List<ItemFactura> items= new List<ItemFactura>();
    }
}
