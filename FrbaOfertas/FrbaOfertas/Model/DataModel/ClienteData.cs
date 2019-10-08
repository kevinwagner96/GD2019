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
       List<String> allAtributes = new List<String>( new String[] {"id_cliente","id_domicilio","id_usuario","clie_dni","clie_nombre","clie_apellido","clie_email","clie_telefono","clie_fecha_nac","clie_credito","clie_activo"});

        public override List<Cliente> Select(out Exception exError)
        {
            List<Cliente> returnValue = new List<Cliente>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                

                using (SqlCommand command = new SqlCommand("SELECT "+ SqlHelper.getColumns(allAtributes) +"FROM [dbo].[Cliente]", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente c = new Cliente();
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

        public override List<Cliente> FilterSelect(Dictionary<String, String> filtros, out Exception exError)
        {
            List<Cliente> returnValue = new List<Cliente>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + "FROM [dbo].[Cliente] WHERE "+SqlHelper.getLikeFilter(filtros), (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente c = new Cliente();
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
                        command = new SqlCommand("INSERT INTO [dbo].[Domicilio] (" + SqlHelper.getColumns(direccion.getAtributeMList()) + ")" +
                                       " output INSERTED.id_domicilio VALUES(" + SqlHelper.getValues(direccion.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in direccion.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, direccion.getMethodString(value));
                        }


                        modified = (Int32)command.ExecuteScalar();
                        instance.id_domicilio = modified;

                        command.CommandText = "INSERT INTO [dbo].[Cliente] (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
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


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + "FROM [dbo].[Cliente]"+" WHERE id_cliente="+ID, (SqlConnection)this.Connection))
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
            
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("UPDATE [dbo].[Cliente] SET " + SqlHelper.getUpdate(instance.getAtributeMList()) + " WHERE id_cliente="+instance.id_cliente, (SqlConnection)this.Connection))
                {

                    foreach (String value in instance.getAtributeMList())
                    {
                        command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                    }


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

        public override bool Delete(int ID, out Exception exError)
        {
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("UPDATE [dbo].[Cliente] SET [clie_activo]=0 WHERE id_cliente=" + ID, (SqlConnection)this.Connection))
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
