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
    class CompraData : DataHelper<Compra>
    {
        public CompraData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>(new String[] { "id_compra", "id_oferta", "id_cliente", "compra_fecha", "compra_precio_lista", "compra_precio_oferta", "compra_cantidad", "compra_canjeado", "compra_fecha_vencimiento"});
        String Table = "[GDDS2].[Compra]";



        public override List<Compra> Select(out Exception exError)
        {
            List<Compra> returnValue = new List<Compra>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + "FROM " + Table, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Compra f = new Compra();
                            SqlHelper.setearAtributos(reader, allAtributes, f);
                            returnValue.Add(f);
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

        public override List<Compra> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            List<Compra> returnValue = new List<Compra>();
            exError = null;
            String and = "";
            if (like.Count() > 0 && exac.Count() > 0)
                and = " AND ";


            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) +
                    "FROM " + Table + " WHERE " + SqlHelper.getLikeFilter(like) +and+ "  [compra_fecha_vencimiento]>=@compra_fecha_vencimiento AND [compra_canjeado]=0 ", (SqlConnection)this.Connection))
                {
                    foreach (KeyValuePair<String, Object> value in exac)
                    {
                        command.Parameters.AddWithValue("@" + value.Key, value.Value);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Compra c = new Compra();
                            SqlHelper.setearAtributos(reader, allAtributes, c);
                            c.restartMList();
                            returnValue.Add(c);
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

        public override Int32 Create(Compra instance, object otro, out Exception exError)
        {
            Int32 modified = -1;
            SqlTransaction trans;
            SqlCommand command;
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
                        command = new SqlCommand("INSERT INTO " + Table + " (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                                       " VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
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


            return modified;
        }

        public override Int32 Create(Compra instance, out Exception exError)
        {
            Int32 modified = -1;
            SqlTransaction trans;
            SqlCommand command;
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
                        command = new SqlCommand("INSERT INTO " + Table + " (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                                       " output INSERTED.id_Compra VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
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


            return modified;
        }

        public override Compra Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Compra Read(Compra instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Compra instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Compra instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }
        public override bool Delete(Compra instance, out Exception exError)
        {
            throw new NotImplementedException();
        }
    }
}
