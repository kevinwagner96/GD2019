using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model.DataModel
{
    class DataGeneric
    {
        public IDbConnection Connection { get; private set; }

        public DataGeneric(IDbConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("Conexion invalida a DB.");
            this.Connection = connection;
        }

        public List<String> getAniosFacturados(out Exception exError) { 
            List<String> anios = new List<string>();

            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT DISTINCT(YEAR(fact_fecha)) FROM GDDS2.Factura", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            anios.Add( reader.GetValue(0).ToString());
                            
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



            return anios;
        }

        public List<ListFacturacion> mayorFacturacion(DateTime inicio, DateTime fin, out Exception exError)
        {
            List<ListFacturacion> listado = new List<ListFacturacion>();

            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("select * from GDDS2.listadoEstadisticoMayorFacturacion(@fecha1,@fecha2)", (SqlConnection)this.Connection))
                {
                    command.CommandType = CommandType.Text;
                    SqlParameter parameter1 = new SqlParameter("@fecha1", SqlDbType.DateTime);
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = inicio;
                    SqlParameter parameter2 = new SqlParameter("@fecha2", SqlDbType.DateTime);
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = fin;
                    

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            listado.Add(new ListFacturacion(reader));

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



            return listado;
        }

    }
}
