using FrbaOfertas.Helpers;
using FrbaOfertas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model.DataModel
{
    class EntregaData : DataHelper<Entrega>
    {
        public EntregaData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>(new String[] { "id_Entrega", "id_oferta", "id_cliente", "Entrega_fecha", "Entrega_precio_lista", "Entrega_precio_oferta", "Entrega_cantidad", "Entrega_canjeado", "Entrega_fecha_vencimiento"});
        String Table = "[GDDS2].[Entrega]";



        public override List<Entrega> Select(out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override List<Entrega> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Int32 Create(Entrega instance,  out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Int32 Create(Entrega instance,object otro, out Exception exError)
        {/*
            Int32 modified = -1;
            SqlTransaction trans;
            SqlCommand command;
            DateTime fecha = (DateTime)otro;
            //Direccion direccion = (Direccion)otro;
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                using (trans = ((SqlConnection)this.Connection).BeginTransaction())
                {
                    try
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        
                        command = ("SELECT " + SqlHelper.getColumns(allAtributes) +
                        "FROM " + Table + " WHERE " + SqlHelper.getLikeFilter(like) +and+ "  [compra_fecha_vencimiento]>=@compra_fecha_vencimiento AND [compra_canjeado]=0 ";
                        
                        
                        command = new SqlCommand("INSERT INTO " + Table + " (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                                       " output INSERTED.id_Entrega VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }


                        command.ExecuteNonQuery();

                        trans.Commit();
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
                        exError = ex2;
                    }

                }
            }
            catch (InvalidOperationException invalid)
            {
                exError = invalid;
            }


            return modified;*/
            throw new NotImplementedException();
        }


        public override Entrega Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Entrega Read(Entrega instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Entrega instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Entrega instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }
        public override bool Delete(Entrega instance, out Exception exError)
        {
            throw new NotImplementedException();
        }
    }
}
