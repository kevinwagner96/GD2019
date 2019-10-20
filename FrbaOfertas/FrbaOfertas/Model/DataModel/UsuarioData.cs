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
        List<String> allAtributes = new List<String>(new String[] { "id_usuario","usu_username", "usu_contrasenia", "usu_cant_intentos_fallidos", "usu_activo" });

        public override List<Usuario> Select(out Exception exError)
        {
            List<Usuario> returnValue = new List<Usuario>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                /*
                using (SqlCommand command = new SqlCommand("SELECT "+ SqlHelper.getColumns(allAtributes) + " FROM "FROM "+Table + " WHERE usu_username="+instance.id_usuario, (SqlConnection)this.Connection))
                {
                    if (!reader.Read())
                        throw new InvalidOperationException("No existe el cliente.");

                    SqlHelper.setearAtributos(reader, allAtributes, d);
                    d.restartMList();

                    if (reader.Read())
                        throw new InvalidOperationException("Clientes multiples.");
                }
                */
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
            Usuario usuario = new Usuario();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT "+ SqlHelper.getColumns(allAtributes) + " FROM "+Table + " WHERE usu_username="+instance.id_usuario, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
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
