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
    class FuncionalidadesData : DataHelper<Funcionalidad>
    {
        public FuncionalidadesData(SqlConnection connection) : base(connection) { }
       List<String> allAtributes = new List<String>( new String[] {"func_codigo","func_nombre"});

       public override List<Funcionalidad> Select(out Exception exError)
        {
            List<Funcionalidad> returnValue = new List<Funcionalidad>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                

                using (SqlCommand command = new SqlCommand("SELECT "+ SqlHelper.getColumns(allAtributes) +"FROM [dbo].[funcionalidad]", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Funcionalidad f = new Funcionalidad();
                            f.fun_codigo = reader.GetInt32(0);
                            f.fun_nombre = reader.GetString(1);                            
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

       public override List<Funcionalidad> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Int32 Create(Funcionalidad instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Int32 Create(Funcionalidad instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

       public override Funcionalidad Read(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Funcionalidad Read(Funcionalidad instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Funcionalidad instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Funcionalidad instance, object otro, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Funcionalidad instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
