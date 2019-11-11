
using FrbaOfertas.Helpers;
using FrbaOfertas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaFacturas.Model.DataModel
{
    class FacturaData : DataHelper<Factura>
    {

        public FacturaData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>(new String[] { "id_fact", "id_proveedor", "fact_fecha", "fact_fecha_inicio", "fact_fecha_fin", "fact_importe"});
        List<String> allAtributesCompra = new List<String>(new String[] { "id_oferta", "id_compra", "id_cliente", "compra_fecha", "compra_precio_lista", "compra_precio_oferta", "compra_cantidad", "compra_canjeado", "compra_fecha_vencimiento" });
       String Table = "[GDDS2].[Factura]";
       String CTable = "[GDDS2].[Compra]";
       String OTable = "[GDDS2].[Oferta]";
       String ITable = "[GDDS2].[Item_factura]";

       

       public override List<Factura> Select(out Exception exError)
        {
            throw new NotImplementedException();
        }

        public List<Compra> SelectCompras(Factura factura,out Exception exError)
        {
            List<Compra> returnValue = new List<Compra>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT [Compra]." + SqlHelper.getColumns(allAtributesCompra) + " FROM " + CTable + " JOIN " + OTable + " ON " + OTable + ".[id_oferta]=" + CTable + ".[id_oferta] WHERE [id_proveedor]="+factura.id_proveedor
                    + " AND [compra_fecha] BETWEEN '" + factura.fact_fecha_inicio.ToShortDateString() + "' AND '" + factura.fact_fecha_fin.ToShortDateString() + "'", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Compra compra = new Compra(reader);
                            factura.addItem(new ItemFactura(factura.id_fact,compra));
                            returnValue.Add(compra);
                        }
                    }
                }
            }
            catch (InvalidOperationException invalid)
            {
                exError = invalid;
            }
            catch (Exception ex)
            {
                exError = ex;
            }

            return returnValue;
        }

       public override List<Factura> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Int32 Create(Factura instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Int32 Create(Factura instance, out Exception exError)
        {
            Int32 modified = -1;
            SqlTransaction trans;
            SqlCommand command;            
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                using (trans = ((SqlConnection)this.Connection).BeginTransaction())
                {
                    try
                    {
                        command = new SqlCommand("INSERT INTO " + Table + " (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                                       " output INSERTED.id_fact VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }


                        modified = (Int32)command.ExecuteScalar();
                        instance.id_fact = modified;

                        command.CommandText = "INSERT INTO " + ITable + " ([id_fact],[id_compra],[item_precio],[item_fecha_compra])" +
                                    " VALUES(@id_fact,@id_compra,@item_precio,@item_fecha_compra)";
                        command.Parameters.Add(new SqlParameter("@id_fact", SqlDbType.Int));
                        command.Parameters.Add(new SqlParameter("@id_compra", SqlDbType.Int));
                        command.Parameters.Add(new SqlParameter("@item_precio", SqlDbType.Decimal));
                        command.Parameters.Add(new SqlParameter("@item_fecha_compra", SqlDbType.DateTime));     
                        try
                        {
                            foreach (ItemFactura item in instance.items)
                            {
                                command.Parameters["@id_fact"].Value= modified;
                                command.Parameters["@id_compra"].Value= item.id_compra;
                                command.Parameters["@item_precio"].Value= item.item_precio;
                                command.Parameters["@item_fecha_compra"].Value= item.item_fecha_compra;                               
                                if (command.ExecuteNonQuery() != 1)
                                {
                                    //'handled as needed, 
                                    //' but this snippet will throw an exception to force a rollback
                                    throw new InvalidProgramException();
                                }
                            }
                            trans.Commit();
                        }catch (Exception) {
                        trans.Rollback();
                        throw;
                        }
                    }
                        
                    
                    catch (Exception ex2)
                    {
                        try
                        {

                            exError = ex2;
                            trans.Rollback();
                        }
                        catch
                        {
                            exError = ex2;
                        }

                    }

                }
            }
            catch (InvalidOperationException invalid)
            {
                exError = invalid;
            }


            return modified;
        }

       public override Factura Read(int ID, out Exception exError)
       {
           throw new NotImplementedException();
        }

       public override Factura Read(Factura instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Update(Factura instance, out Exception exError)
       {
           throw new NotImplementedException();
        }

       public override bool Update(Factura instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Delete(int ID, out Exception exError)
       {
           throw new NotImplementedException();
       }
       public override bool Delete(Factura instance, out Exception exError)
       {
           throw new NotImplementedException();
       }
    }
}
