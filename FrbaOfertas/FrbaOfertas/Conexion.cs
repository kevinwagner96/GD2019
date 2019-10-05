using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public static class Conexion
    {
        private static string conectionString = FrbaOfertas.ConfigurationHelper.ConnectionString.ToString();

        public static SqlConnection getConexion()
        {
            return new SqlConnection(conectionString);
        }
    }
}


