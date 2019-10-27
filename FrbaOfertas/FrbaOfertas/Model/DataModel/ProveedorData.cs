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
    class ProveedorData : DataHelper<Proveedor>
    {
        public ProveedorData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>(new String[] { "id_proveedor", "id_domicilio", "prove_usuario", "prov_CUIT", "prov_razon_social", "prov_email", "prov_telefono", "prov_rubro", "prov_contacto", "prov_activo" });
       String Table = "[GDDS2].[Proveedor]";
       String DTable = "[GDDS2].[Domicilio]";

        public override List<Proveedor> Select(out Exception exError)
        {
            List<Proveedor> returnValue = new List<Proveedor>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                

                using (SqlCommand command = new SqlCommand("SELECT "+ SqlHelper.getColumns(allAtributes) +"FROM "+Table, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor c = new Proveedor();
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

        public override List<Proveedor> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            List<Proveedor> returnValue = new List<Proveedor>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) +
                    "FROM "+Table+" WHERE " + SqlHelper.getLikeFilter(like) + SqlHelper.getExactFilter(exac), (SqlConnection)this.Connection))
                {
                    foreach (KeyValuePair<String, Object> value in exac)
                    {
                        command.Parameters.AddWithValue("@" + value.Key, value.Value);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor c = new Proveedor();
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

        public override Int32 Create(Proveedor instance, object otro, out Exception exError)
        {
            Int32 modified = -1;
            SqlTransaction trans;
            SqlCommand command;
            Direccion direccion = (Direccion)otro;
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                
                    using ( trans = ((SqlConnection)this.Connection).BeginTransaction())
                    {
                        try
                        {
                        command = new SqlCommand("INSERT INTO "+DTable+" (" + SqlHelper.getColumns(direccion.getAtributeMList()) + ")" +
                                       " output INSERTED.id_domicilio VALUES(" + SqlHelper.getValues(direccion.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in direccion.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, direccion.getMethodString(value));
                        }


                        modified = (Int32)command.ExecuteScalar();
                        instance.id_domicilio = modified;

                        command.CommandText = "INSERT INTO " + Table + " (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                                    " output INSERTED.id_proveedor VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")";
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
                            catch {
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

        public override Int32 Create(Proveedor instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Proveedor Read(int ID, out Exception exError)
        {
            Proveedor proveedor = new Proveedor();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + "FROM " + Table + " WHERE id_proveedor=" + ID, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())        
                            throw new InvalidOperationException("No existe el proveedor.");
                                                
                        SqlHelper.setearAtributos(reader, allAtributes, proveedor);
                        proveedor.restartMList();

                        if (reader.Read())
                            throw new InvalidOperationException("Proveedors multiples.");
                                               
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
              
            return proveedor;
        }

        public override Proveedor Read(Proveedor instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Proveedor instance, out Exception exError)
        {
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
                        command = new SqlCommand("UPDATE " + Table + " SET " + SqlHelper.getUpdate(instance.getAtributeMList()) +
                                                        " WHERE id_proveedor=" + instance.id_proveedor, (SqlConnection)this.Connection, trans);
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

                    }

                }
            }
            catch (InvalidOperationException invalid)
            {
                exError = invalid;
            }


            return true;
        }

        public override bool Update(Proveedor instance,object otro ,out Exception exError)
        {
            SqlTransaction trans;
            SqlCommand command;
            Direccion direccion = (Direccion) otro;
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                 using ( trans = ((SqlConnection)this.Connection).BeginTransaction())
                 {
                    try
                    {
                        command = new SqlCommand("UPDATE " + Table + " SET " + SqlHelper.getUpdate(instance.getAtributeMList()) +
                                                        " WHERE id_proveedor="+instance.id_proveedor, (SqlConnection)this.Connection,trans);
                            command.CommandType = System.Data.CommandType.Text;
                            foreach (String value in instance.getAtributeMList())
                            {
                                command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                            }

                            command.ExecuteNonQuery();

                            command.CommandText = "UPDATE " + DTable + " SET " + SqlHelper.getUpdate(direccion.getAtributeMList())
                                                + " WHERE id_domicilio=" + direccion.id_domicilio;
                       
                            foreach (String value in direccion.getAtributeMList())
                            {
                                command.Parameters.AddWithValue("@" + value, direccion.getMethodString(value));
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
                            catch {
                                exError = ex2;
                            }
                
                        }

                    }
                }           
            catch (InvalidOperationException invalid)
            {                
                exError = invalid;
            }


            return true;
        }

        public override bool Delete(int ID, out Exception exError)
        {
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("UPDATE " + Table + " SET [prov_activo]=0 WHERE id_proveedor=" + ID, (SqlConnection)this.Connection))
                {

                    command.ExecuteNonQuery();
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

            return true;
        }

        public override bool Delete(Proveedor instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
