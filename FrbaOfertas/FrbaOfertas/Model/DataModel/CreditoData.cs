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
    class CreditoData : DataHelper<Credito>
    {
        public CreditoData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>(new String[] { "id_carga_credito", "id_cliente", "id_tipo_pago","cred_fecha","cred_monto","cred_num_tarjeta","cre_empresa_tarjeta","cred_cod_tarjeta" });
       String Table = "[GDDS2].[credito]";

       

       public override List<Credito> Select(out Exception exError)
        {
            List<Credito> returnValue = new List<Credito>();
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
                            Credito f = new Credito();
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

       public override List<Credito> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Int32 Create(Credito instance, object otro, out Exception exError)
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
                                       " output INSERTED.id_carga_credito VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }


                        modified = (Int32)command.ExecuteScalar();

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

       public override Int32 Create(Credito instance, out Exception exError)
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

       public override Credito Read(int ID, out Exception exError)
       {
           throw new NotImplementedException();
        }

       public override Credito Read(Credito instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Update(Credito instance, out Exception exError)
       {
           throw new NotImplementedException();
        }

       public override bool Update(Credito instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Delete(int ID, out Exception exError)
       {
           throw new NotImplementedException();
       }
       public override bool Delete(Credito instance, out Exception exError)
       {
           throw new NotImplementedException();
       }
    }
}
