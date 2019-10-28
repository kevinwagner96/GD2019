
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
        List<String> allAtributes = new List<String>(new String[] { "id_Factura", "id_proveedor", "ofer_descripcion", "ofer_cant_disp", "ofer_activo", "ofer_f_public", "ofer_f_venc", "ofer_pr_Factura", "ofer_pr_lista", "ofer_cant_x_cli" });
       String Table = "[GDDS2].[Factura]";

       

       public override List<Factura> Select(out Exception exError)
        {
            List<Factura> returnValue = new List<Factura>();
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
                            Factura f = new Factura();
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

       public override List<Factura> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            List<Factura> returnValue = new List<Factura>();
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
                            Factura c = new Factura();
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

       public override Int32 Create(Factura instance, object otro, out Exception exError)
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

       public override Int32 Create(Factura instance, out Exception exError)
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
                                       " output INSERTED.id_Factura VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

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
