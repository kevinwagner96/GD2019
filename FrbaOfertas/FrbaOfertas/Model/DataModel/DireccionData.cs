using FrbaOfertas.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model.DataModel
{

    class DireccionData : DataHelper<Direccion>
    {
        public DireccionData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>( new String[] {"dom_calle","dom_numero","dom_depto","dom_piso","dom_ciudad","dom_localidad","dom_codigo_postal"});

        public override List<Direccion> Select(out Exception exError)
        {
            List<Direccion> returnValue = new List<Direccion>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + "FROM [dbo].[cliente]", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        /*
                        while (reader.Read())
                            returnValue.Add(new Direccion(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                                                           reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                                                           reader.GetDateTime(8), reader.GetDouble(9), reader.GetBoolean(10)));*/
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

        public override List<Direccion> FilterSelect(List<Dictionary<String, String>> filtros, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Int32 Create(Direccion instance, out Exception exError)
        {
            Int32 modified = -1;
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Domicilio] (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                               " output INSERTED.id_domicilio VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection))
                {

                    foreach (String value in instance.getAtributeMList())
                    {
                        command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                    }


                    modified = (Int32)command.ExecuteScalar();

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

            return modified;
        }

        public override Direccion Read(int ID, out Exception exError)
        {
            Direccion d = new Direccion();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + "FROM [dbo].[Domicilio]" + " WHERE id_domicilio=" + ID, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException("No existe el cliente.");

                        SqlHelper.setearAtributos(reader, allAtributes, d);
                        d.restartMList();

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

            return d;
        }

        public override Direccion Read(Direccion instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Int32 Create(Direccion instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Direccion instance, out Exception exError)
        {
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("UPDATE [dbo].[Domicilio] SET " + SqlHelper.getUpdate(instance.getAtributeMList()) + " WHERE id_domicilio=" + instance.id_domicilio, (SqlConnection)this.Connection))
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
            throw new NotImplementedException();
        }

        public override bool Delete(Direccion instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
