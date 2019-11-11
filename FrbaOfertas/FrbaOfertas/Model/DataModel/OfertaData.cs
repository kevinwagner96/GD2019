using FrbaOfertas.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model.DataModel
{
    class OfertaData : DataHelper<Oferta>
    {
        public OfertaData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>(new String[] { "id_oferta", "id_proveedor", "ofer_descripcion", "ofer_cant_disp", "ofer_activo", "ofer_f_public", "ofer_f_venc", "ofer_pr_oferta", "ofer_pr_lista", "ofer_cant_x_cli" });
       String Table = "[GDDS2].[Oferta]";

       

       public override List<Oferta> Select(out Exception exError)
        {
            List<Oferta> returnValue = new List<Oferta>();
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
                            Oferta f = new Oferta();
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

       public override List<Oferta> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            List<Oferta> returnValue = new List<Oferta>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) +
                    "FROM " + Table + " WHERE " + SqlHelper.getLikeFilter(like) + " [ofer_f_public]<=@ofer_f_public AND [ofer_f_venc]>=@ofer_f_public AND [ofer_activo]=1 ", (SqlConnection)this.Connection))
                {
                    foreach (KeyValuePair<String, Object> value in exac)
                    {
                        command.Parameters.AddWithValue("@" + value.Key, value.Value);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Oferta c = new Oferta();
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

       public override Int32 Create(Oferta instance, object otro, out Exception exError)
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
                        command = new SqlCommand("INSERT INTO " + Table+" (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
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

       public override Int32 Create(Oferta instance, out Exception exError)
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
                                       " output INSERTED.id_oferta VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

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

       public override Oferta Read(int ID, out Exception exError)
       {
           throw new NotImplementedException();
        }

       public override Oferta Read(Oferta instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Update(Oferta instance, out Exception exError)
       {
           throw new NotImplementedException();
        }

       public override bool Update(Oferta instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Delete(int ID, out Exception exError)
       {
           throw new NotImplementedException();
       }
       public override bool Delete(Oferta instance, out Exception exError)
       {
           throw new NotImplementedException();
       }
    }
}
