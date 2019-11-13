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

        public List<ListDescuento> mayorDescuento(DateTime inicio, DateTime fin, out Exception exError)
        {
            List<ListDescuento> listado = new List<ListDescuento>();

            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("select * from GDDS2.listadoEstadisticoProveedoresMayorDescuento(@fecha1,@fecha2)", (SqlConnection)this.Connection))
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

                            listado.Add(new ListDescuento(reader));

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

        public void entregarCompra(Int32 idProveedor,Int32  idCompra , Int32 idCliente,DateTime fecha, out Exception exError)
        {            
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                //create procedure [GDDS2].cargarEntrega(@idProveedor int, @idCompra int, @idCliente int)

                    using (SqlCommand command = new SqlCommand("[GDDS2].cargarEntrega", (SqlConnection)this.Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter parameter1 = new SqlParameter("@idProveedor", SqlDbType.Int);
                        parameter1.Direction = ParameterDirection.Input;
                        parameter1.Value = idProveedor;
                        SqlParameter parameter2 = new SqlParameter("@idCompra", SqlDbType.Int);
                        parameter2.Direction = ParameterDirection.Input;
                        parameter2.Value = idCompra;
                        SqlParameter parameter3 = new SqlParameter("@idCliente", SqlDbType.Int);
                        parameter3.Direction = ParameterDirection.Input;
                        parameter3.Value = idCliente;
                        SqlParameter parameter4 = new SqlParameter("@fechaActual", SqlDbType.NVarChar);
                        parameter4.Direction = ParameterDirection.Input;
                        parameter4.Value = fecha.ToString();

                        command.Parameters.Add(parameter1);
                        command.Parameters.Add(parameter2);
                        command.Parameters.Add(parameter3);
                        command.Parameters.Add(parameter4);

                        command.ExecuteNonQuery();
                        
                    }



            }
            catch (SqlException ex)
            {
                exError = ex;
                if (ex.Errors[0].Class == 16)
                {
                    exError = new Exception("El codigo de compra no pertenece al proveedor");
                 
                }
                if (ex.Errors[0].Class == 15)
                {
                    exError = new Exception("El cupon ya ha sido canjeado");
                }

            }
            
        }
        /*@idCliente int ,@idOferta nvarchar(50),@cantidad int,@codigoCuponResultante int output*/
        public String realizarCompra(Int32 idCliente, String idOferta, Int32 cantidad  , out Exception exError)
        {
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();



                using (SqlCommand command = new SqlCommand("[GDDS2].realizarCompra", (SqlConnection)this.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter1 = new SqlParameter("@idCliente", SqlDbType.Int);
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = idCliente;
                    SqlParameter parameter2 = new SqlParameter("@idOferta", SqlDbType.NVarChar);
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = idOferta;
                    SqlParameter parameter3 = new SqlParameter("@cantidad", SqlDbType.Int);
                    parameter3.Direction = ParameterDirection.Input;
                    parameter3.Value = cantidad;
                    SqlParameter parameter4 = new SqlParameter("@codigoCuponResultante", SqlDbType.Int);
                    parameter4.Direction = ParameterDirection.Output;

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);
                    command.Parameters.Add(parameter4);

                    command.ExecuteNonQuery();

                    return command.Parameters["@codigoCuponResultante"].Value.ToString();

                }



            }
            catch (SqlException ex)
            {                
                if (ex.Errors[0].Class == 16)
                {
                    exError = new Exception("El cliente no puede adquirir la cantidad seleccionada del producto");
                    return null;
                }
                if (ex.Errors[0].Class == 15)
                {
                    exError = new Exception("Saldo insuficiente");
                    return null;
                }
                if (ex.Errors[0].Class == 14)
                {
                    exError = new Exception("No hay Stock disponible");
                    return null;
                }
            } 

            return null;

        }


    }
}
