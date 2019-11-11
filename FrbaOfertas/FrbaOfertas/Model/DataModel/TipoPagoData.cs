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
    class TipoPagoData : DataHelper<TipoDePago>
    {
        public TipoPagoData(SqlConnection connection) : base(connection) { }

       List<String> allAtributes = new List<String>( new String[] {"id_tipo_pago","tipo_pago_nombre"});
       String Table = "[GDDS2].[Tipo_pago]";

       public override List<TipoDePago> Select(out Exception exError)
        {
            List<TipoDePago> returnValue = new List<TipoDePago>();
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
                            TipoDePago f = new TipoDePago(reader.GetString(1), reader.GetInt32(0));                                                                         
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

       public override List<TipoDePago> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Int32 Create(TipoDePago instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Int32 Create(TipoDePago instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override TipoDePago Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override TipoDePago Read(TipoDePago instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(TipoDePago instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(TipoDePago instance, object otro, out Exception exError)
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


                using (SqlCommand command = new SqlCommand("DELETE FROM "+Table+" WHERE id_tipo_pago=" + ID, (SqlConnection)this.Connection))
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

        public override bool Delete(TipoDePago instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
