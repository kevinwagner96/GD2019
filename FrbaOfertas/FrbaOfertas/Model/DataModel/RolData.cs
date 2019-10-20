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

       public override List<Rol> Select(out Exception exError)
        {
            List<Rol> returnValue = new List<Rol>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                

                using (SqlCommand command = new SqlCommand("SELECT "+ SqlHelper.getColumns(allAtributes) +"FROM [dbo].[Rol]", (SqlConnection)this.Connection))
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
            throw new NotImplementedException();
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
                        command = new SqlCommand("INSERT INTO [dbo].[Rol] (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                                       " output INSERTED.id_rol VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }


                        modified = (Int32)command.ExecuteScalar();                        

                        command.CommandText = "INSERT INTO [dbo].[rol_funcionalidad] ([id_rol],[func_codigo])" +
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
            throw new NotImplementedException();
        }

       public override Rol Read(Rol instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Update(Rol instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override bool Update(Rol instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Rol instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
