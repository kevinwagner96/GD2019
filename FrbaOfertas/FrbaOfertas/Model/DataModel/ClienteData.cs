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
    class ClienteData : DataHelper<Cliente>
    {
        public ClienteData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>(new String[] { "id_cliente", "id_domicilio", "clie_usuario", "clie_dni", "clie_nombre", "clie_apellido", "clie_email", "clie_telefono", "clie_fecha_nac", "clie_credito", "clie_activo" });
        List<String> conUsername = new List<String>(new String[] { "id_cliente", "id_domicilio", "clie_usuario", "usu_username", "clie_dni", "clie_nombre", "clie_apellido", "clie_email", "clie_telefono", "clie_fecha_nac", "clie_credito", "clie_activo" });
        String Table = "[GDDS2].[Cliente]";
        String DTable = "[GDDS2].[Domicilio]";
        String UTable = "[GDDS2].[Usuario]";

        public override List<Cliente> Select(out Exception exError)
        {
            List<Cliente> returnValue = new List<Cliente>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(conUsername) + " FROM " + Table + " LEFT JOIN " + UTable + " ON " + UTable + ".[id_usuario]=" + Table + ".[clie_usuario] ", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            returnValue.Add( new Cliente(reader));
                            
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

        public override List<Cliente> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            List<Cliente> returnValue = new List<Cliente>();
            exError = null;
            String and = "";

            if (like.Count() > 0 && exac.Count() > 0)
                and = "AND";

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(conUsername) +
                    " FROM " + Table + " LEFT JOIN " + UTable + " ON " + UTable + ".[id_usuario]=" + Table + ".[clie_usuario] WHERE " + SqlHelper.getLikeFilter(like) + and + SqlHelper.getExactFilter(exac), (SqlConnection)this.Connection))
                {
                    foreach (KeyValuePair<String, Object> value in exac)
                    {
                        command.Parameters.AddWithValue("@" + value.Key, value.Value);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnValue.Add(new Cliente(reader));
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

        public override Int32 Create(Cliente instance, object otro, out Exception exError)
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
                        command = new SqlCommand("INSERT INTO "+DTable+  " (" + SqlHelper.getColumns(direccion.getAtributeMList()) + ")" +
                                       " output INSERTED.id_domicilio VALUES(" + SqlHelper.getValues(direccion.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in direccion.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, direccion.getMethodString(value));
                        }


                        modified = (Int32)command.ExecuteScalar();
                        instance.id_domicilio = modified;

                        command.CommandText = "INSERT INTO " + Table + " (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                                    " output INSERTED.id_cliente VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")";
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

                                exError = ex2;
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


            return modified;
        }

        public override Int32 Create(Cliente instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Cliente Read(int ID, out Exception exError)
        {
            Cliente cliente = new Cliente();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + "FROM " + Table +" WHERE id_cliente="+ID, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())        
                            throw new InvalidOperationException("No existe el cliente.");
                                                
                        SqlHelper.setearAtributos(reader, allAtributes, cliente);
                        cliente.restartMList();

                        if (reader.Read())
                            throw new InvalidOperationException("Clientes multiples.");
                                               
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
              
            return cliente;
        }

        public override Cliente Read(Cliente instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Cliente instance, out Exception exError)
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
                                                    " WHERE id_cliente=" + instance.id_cliente, (SqlConnection)this.Connection, trans);
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

        public override bool Update(Cliente instance,object otro ,out Exception exError)
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
                            command  = new SqlCommand("UPDATE " + Table +" SET " + SqlHelper.getUpdate(instance.getAtributeMList()) +
                                                        " WHERE id_cliente="+instance.id_cliente, (SqlConnection)this.Connection,trans);
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


                using (SqlCommand command = new SqlCommand("UPDATE " + Table + " SET [clie_activo]=0 WHERE id_cliente=" + ID, (SqlConnection)this.Connection))
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

        public override bool Delete(Cliente instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
