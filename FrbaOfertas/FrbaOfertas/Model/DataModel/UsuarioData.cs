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
        private String table = "[dbo].[usuario]";
        private String userName = "[usu_nombre]";
        private String userId = "[usu_id]";
        private String habilitado = "[habilitado]";
        private String password = "[usu_password]";

        public override List<Usuario> Select(out Exception exError)
        {
            List<Usuario> returnValue = new List<Usuario>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                

                using (SqlCommand command = new SqlCommand("SELECT [usu_nombre],[usu_id],[habilitado] FROM [dbo].[usuario]", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            returnValue.Add(new Usuario(reader.GetString(0), reader.GetInt32(1), reader.GetBoolean(2)));
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

        public override List<Usuario> FilterSelect(Dictionary<String, String> filtros, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Int32 Create(Usuario instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Int32 Create(Usuario instance, object otro,out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Usuario Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Usuario Read(Usuario instance, out Exception exError)
        {
            throw new NotImplementedException();
        }
        public override bool Update(Usuario instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }
        public override bool Update(Usuario instance, out Exception exError)
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

        public override bool Delete(Usuario instance, out Exception exError)
        {
            throw new NotImplementedException();
        }



    }
}
