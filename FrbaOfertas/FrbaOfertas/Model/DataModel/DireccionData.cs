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
        String allAtributes = "[id_cliente],[id_domicilio],[id_usuario],[clie_dni],[clie_nombre],[clie_apellido],[clie_email],[clie_telefono],[clie_fecha_nac],[clie_credito],[clie_activo]";

        public override List<Direccion> Select(out Exception exError)
        {
            List<Direccion> returnValue = new List<Direccion>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + allAtributes + "FROM [dbo].[cliente]", (SqlConnection)this.Connection))
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
            throw new NotImplementedException();
        }

        public override Direccion Read(Direccion instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Direccion instance, out Exception exError)
        {
            throw new NotImplementedException();
            /*
             * SqlCommand tCommand = new SqlCommand();
                tCommand.Connection = new SqlConnection("YourConnectionString");
                tCommand.CommandText = "UPDATE players SET name = @name, score = @score, active = @active WHERE jerseyNum = @jerseyNum";

                tCommand.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar).Value = "Smith, Steve");
                tCommand.Parameters.Add(new SqlParameter("@score", System.Data.SqlDbType.Int).Value = "42");
                tCommand.Parameters.Add(new SqlParameter("@active", System.Data.SqlDbType.Bit).Value = true);
                tCommand.Parameters.Add(new SqlParameter("@jerseyNum", System.Data.SqlDbType.Int).Value = "99");

                tCommand.ExecuteNonQuery();
             * */
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
