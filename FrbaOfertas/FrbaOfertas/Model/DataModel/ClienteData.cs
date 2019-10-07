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
        String allAtributes = "[id_cliente],[id_domicilio],[id_usuario],[clie_dni],[clie_nombre],[clie_apellido],[clie_email],[clie_telefono],[clie_fecha_nac],[clie_credito],[clie_activo]";

        public override List<Cliente> Select(out Exception exError)
        {
            List<Cliente> returnValue = new List<Cliente>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                

                using (SqlCommand command = new SqlCommand("SELECT "+ allAtributes +"FROM [dbo].[Cliente]", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente c = new Cliente();
                            c.id_cliente = reader.GetInt32(0);
                            c.id_domicilio=reader.GetInt32(1);
                            c.id_usuario = reader.GetValue(2) == System.DBNull.Value ? -1 : (Int32)reader.GetInt32(2);
                            c.clie_dni = reader.GetValue(3) == System.DBNull.Value ? -1 : (Int32)reader.GetSqlDecimal(3);                                                   
                            c.clie_nombre= reader.GetString(4);
                            c.clie_apellido= reader.GetString(5);
                            c.clie_email= reader.GetString(6);
                            c.clie_telefono= reader.GetString(7);
                            c.clie_fecha_nac=(Convert.ToDateTime(reader["clie_fecha_nac"]));
                            c.clie_credito = reader.GetSqlDecimal(9).ToDouble();
                            c.clie_activo= reader.GetBoolean(10);
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

        public override List<Cliente> FilterSelect(List<Dictionary<String, String>> filtros, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Int32 Create(Cliente instance, out Exception exError)
        {
            Int32 modified = -1;
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                

                using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Cliente] ("+SqlHelper.getColumns(instance.getAtributeMList())+")"+
                               " output INSERTED.id_cliente VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")", (SqlConnection)this.Connection))
                {

                    foreach (String value in instance.getAtributeMList())
                    {                      
                        command.Parameters.AddWithValue( "@"+value,instance.getMethodString(value));
                    }


                    modified=(Int32) command.ExecuteScalar();
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

        public override Cliente Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Cliente Read(Cliente instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Cliente instance, out Exception exError)
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

        public override bool Delete(Cliente instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
