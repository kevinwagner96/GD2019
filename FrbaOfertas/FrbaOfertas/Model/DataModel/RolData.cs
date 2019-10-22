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
    class RolData : DataHelper<Rol>
    {
        public RolData(SqlConnection connection) : base(connection) { }
       List<String> allAtributes = new List<String>( new String[] {"id_rol","rol_nombre","rol_activo"});
       String RUTable = "[GDDS2].[usuario_x_rol]";
        String Table = "[GDDS2].[Rol]";
       String RFTable = "[GDDS2].[rol_funcionalidad]";
       String FTable = "[GDDS2].[funcionalidad]";
       

       public override List<Rol> Select(out Exception exError)
        {
            List<Rol> returnValue = new List<Rol>();
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
                            Rol f = new Rol();
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

       public override List<Rol> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            List<Rol> returnValue = new List<Rol>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT ["+"Rol"+"]." + SqlHelper.getColumns(allAtributes) + ",[id_usuario] FROM " + Table + " JOIN " + RUTable + " ON " + RUTable + ".[id_rol] = " + Table + ".[id_rol]  WHERE " + SqlHelper.getExactFilter(exac), (SqlConnection)this.Connection))
                {
                    foreach (KeyValuePair<String, Object> value in exac)
                    {
                        command.Parameters.AddWithValue("@" + value.Key, value.Value);
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rol f = new Rol();
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

       public override Int32 Create(Rol instance, object otro, out Exception exError)
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
                                       " output INSERTED.id_rol VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }


                        modified = (Int32)command.ExecuteScalar();

                        command.CommandText = "INSERT INTO "+RFTable+" ([id_rol],[func_codigo])" +
                                    "  output INSERTED.id_rol VALUES";
                        instance.funcionalidades.ForEach(delegate(Funcionalidad f)
                        {
                            command.CommandText += "(" + modified.ToString() + "," + f.fun_codigo.ToString() + "),";
                        });

                        command.CommandText = command.CommandText.Remove(command.CommandText.Length - 1);

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

       public override Int32 Create(Rol instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Rol Read(int ID, out Exception exError)
        {
            Rol d = new Rol();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT [Rol].[id_rol],[rol_nombre],[rol_activo],[func_nombre],funcionalidad.func_codigo"+
                        " FROM " + Table + " LEFT JOIN " + RFTable + " ON rol_funcionalidad.id_rol = Rol.id_rol" +
                        " LEFT JOIN " + FTable + " ON rol_funcionalidad.func_codigo = funcionalidad.func_codigo WHERE [Rol].[id_rol]=" + ID, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException("No existe el rol.");

                        d.id_rol = reader.GetInt32(0);
                        d.rol_nombre = reader.GetString(1);
                        d.rol_activo = reader.GetBoolean(2);
                        d.restartMList();

                        try
                        {
                            d.funcionalidades.Add(new Funcionalidad(reader.GetString(3), reader.GetInt32(4)));


                            while (reader.Read())
                            {
                                d.funcionalidades.Add(new Funcionalidad(reader.GetString(3), reader.GetInt32(4)));
                            }
                        }
                        catch { }

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

            return d;
        }

       public override Rol Read(Rol instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Update(Rol instance, out Exception exError)
        {
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
                        command = new SqlCommand("UPDATE "+Table+" SET " + SqlHelper.getUpdate(instance.getAtributeMList()) +
                                                    " WHERE id_rol=" + instance.id_rol, (SqlConnection)this.Connection, trans);
                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }

                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM " + RFTable + " WHERE id_rol=" + instance.id_rol;

                        command.ExecuteNonQuery();
                        if (instance.funcionalidades.Count() > 0)
                        {
                            command.CommandText = "INSERT INTO  " + RFTable + " ([id_rol],[func_codigo])" +
                                        "  output INSERTED.id_rol VALUES";
                            instance.funcionalidades.ForEach(delegate(Funcionalidad f)
                            {
                                command.CommandText += "(" + instance.id_rol.ToString() + "," + f.fun_codigo.ToString() + "),";
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

       public override bool Update(Rol instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("UPDATE  " + Table + " SET [rol_activo]=0 WHERE id_rol=" + ID, (SqlConnection)this.Connection))
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

        public override bool Delete(Rol instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
