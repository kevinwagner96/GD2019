using FrbaOfertas.Helpers;
using FrbaOfertas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FrbaOfertas.DataModel
{
    class UsuarioData : DataHelper<Usuario>
    {
        public UsuarioData(SqlConnection connection) : base(connection) { }
        private String Table = "[GDDS2].[Usuario]";
        private String RTable = "[GDDS2].[usuario_x_rol]";
        List<String> allAtributes = new List<String>(new String[] { "id_usuario", "usu_username", "usu_cant_intentos_fallidos", "usu_activo" });

        public override List<Usuario> Select(out Exception exError)
        {
            List<Usuario> returnValue = new List<Usuario>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + " FROM " + Table, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Usuario c = new Usuario();
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

        public override List<Usuario> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            List<Usuario> returnValue = new List<Usuario>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + " FROM " + Table+" WHERE [usu_activo]=1", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Usuario c = new Usuario();
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

        public override Int32 Create(Usuario instance, object id_rol, out Exception exError)
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
                        command = new SqlCommand("INSERT INTO " + Table + " ([usu_username],[usu_contrasenia],[usu_cant_intentos_fallidos],[usu_activo])" +
                               " output INSERTED.id_usuario VALUES('" + instance.usu_username + "', HASHBYTES('SHA2_256', N'" + instance.usu_contrasenia + "'),0,1)", (SqlConnection)this.Connection, trans);

                        modified = (Int32)command.ExecuteScalar();

                        if (instance.roles.Count() > 0)
                        {
                            command.CommandText = "INSERT INTO  " + RTable + " ([id_usuario],[id_rol])" +
                                        "  output INSERTED.id_rol VALUES";
                            instance.roles.ForEach(delegate(Rol f)
                            {
                                command.CommandText += "(" + modified + "," + f.id_rol.ToString() + "),";
                            });

                            command.CommandText = command.CommandText.Remove(command.CommandText.Length - 1);
                            //modified = 
                            command.ExecuteScalar();
                        }
                        trans.Commit();
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            trans.Rollback();
                            exError = ex2;
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

        public override Int32 Create(Usuario instance,out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Usuario Read(int ID, out Exception exError)
        {
            Usuario usuario = new Usuario();
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                using (SqlCommand command2 = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + " FROM  " + Table + " WHERE id_usuario='" + ID + "'", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {

                        if (!reader.Read())
                            throw new InvalidOperationException("No existe el usuario.");

                        SqlHelper.setearAtributos(reader, allAtributes, usuario);
                        usuario.restartMList();

                        if (reader.Read())
                            throw new InvalidOperationException("Usuarios multiples.");

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
              
            return usuario;
        }

        public override Usuario Read(Usuario instance, out Exception exError)
        {
            Usuario usuario = new Usuario();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                using (SqlCommand command2 = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + " FROM  " + Table + " WHERE usu_username='" + instance.usu_username + "'", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {

                        if (!reader.Read())
                            throw new InvalidOperationException("No existe el usuario.");

                        SqlHelper.setearAtributos(reader, allAtributes, usuario);
                        usuario.restartMList();

                        if (reader.Read())
                            throw new InvalidOperationException("Usuarios multiples.");
                       
                    }
                }
                
                if (usuario.usu_cant_intentos_fallidos < 4)
                {
                    using (SqlCommand command = new SqlCommand("GDDS2.existe_usuario", (SqlConnection)this.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter parameter1 = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                        parameter1.Direction = ParameterDirection.Input;
                        parameter1.Value = instance.usu_username;
                        SqlParameter parameter2 = new SqlParameter("@Contrasenia", SqlDbType.NVarChar);
                        parameter2.Direction = ParameterDirection.Input;
                        parameter2.Value = instance.usu_contrasenia;
                        SqlParameter parameter3 = new SqlParameter("@resultado", SqlDbType.Bit);
                        parameter3.Direction = ParameterDirection.Output;

                        command.Parameters.Add(parameter1);
                        command.Parameters.Add(parameter2);
                        command.Parameters.Add(parameter3);

                        command.ExecuteNonQuery();

                        if (!Convert.ToBoolean(command.Parameters["@resultado"].Value))
                        {
                            throw new InvalidOperationException("Usuario o contraseña invalido.");                            
                        }

                        if (!usuario.usu_activo)
                            throw new InvalidOperationException("Usuario inhabilitado.");
                        

                        return usuario;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Damasiados Intentos fallidos.");
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

            return  null;
        }
        public override bool Update(Usuario instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }
        public override bool Update(Usuario instance, out Exception exError)
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
                                                    " WHERE id_usuario=" + instance.id_usuario, (SqlConnection)this.Connection, trans);
                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }

                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE " + RTable + " WHERE id_usuario=" + instance.id_usuario;
                        command.ExecuteNonQuery();

                        if (instance.roles.Count() > 0)
                        {
                            command.CommandText = "INSERT INTO  " + RTable + " ([id_usuario],[id_rol])" +
                                        "  output INSERTED.id_rol VALUES";
                            instance.roles.ForEach(delegate(Rol f)
                            {
                                command.CommandText += "(" + instance.id_usuario.ToString() + "," + f.id_rol.ToString() + "),";
                            });

                            command.CommandText = command.CommandText.Remove(command.CommandText.Length - 1);
                            Int32 modified = (Int32)command.ExecuteScalar();
                        }

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

        public override bool Delete(int ID, out Exception exError)
        {
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("UPDATE  " + Table + " SET [usu_activo]=0 WHERE id_usuario=" + ID, (SqlConnection)this.Connection))
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

        public override bool Delete(Usuario instance, out Exception exError)
        {
            throw new NotImplementedException();
        }



    }
}
