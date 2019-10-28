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
    class ProveedorData : DataHelper<Proveedor>
    {
        public ProveedorData(SqlConnection connection) : base(connection) { }
        List<String> allAtributes = new List<String>(new String[] { "id_proveedor", "id_domicilio", "prove_usuario", "prov_CUIT", "prov_razon_social", "prov_email", "prov_telefono",  "prov_contacto", "prov_activo", "rubr_id" });
        List<String> conUsername = new List<String>(new String[] { "id_proveedor", "id_domicilio", "prove_usuario", "usu_username", "prov_CUIT", "prov_razon_social", "prov_email", "prov_telefono", "prov_contacto", "prov_activo", "rubr_detalle" });
       String Table = "[GDDS2].[Proveedor]";
       String RTable = "[GDDS2].[Rubro]";
       String DTable = "[GDDS2].[Domicilio]";
       String UTable = "[GDDS2].[Usuario]";

        public override List<Proveedor> Select(out Exception exError)
        {
            List<Proveedor> returnValue = new List<Proveedor>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(conUsername) + "FROM " + Table + "  LEFT JOIN " + UTable + " ON " + UTable + ".[id_usuario]=" + Table + ".[prove_usuario]  JOIN  " + RTable + " ON " + RTable + ".[rubr_id]=" + Table + ".[rubr_id] ", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnValue.Add(new Proveedor(reader));
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

        public Dictionary<Int32,String> Rubros(out Exception exError)
        {
            Dictionary<Int32, String> returnValue = new Dictionary<Int32, String>();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT [rubr_id],[rubr_detalle] FROM [GDDS2].[Rubro]", (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnValue.Add(reader.GetInt32(0),reader.GetString(1));
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

        public KeyValuePair<Int32, String> CreateRubro(String rubro,out Exception exError)
        {
            KeyValuePair<Int32, String> returnValue = new KeyValuePair<Int32, String>(0,"") ;
            exError = null;
            Int32 key;


            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("INSERT  INTO [GDDS2].[Rubro] ([rubr_detalle]) output INSERTED.rubr_id VALUES ('" + rubro + "')", (SqlConnection)this.Connection))
                {
                    key= (Int32)command.ExecuteScalar();
                }

                returnValue = new KeyValuePair<int, string>(key, rubro);
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

        public override List<Proveedor> FilterSelect(Dictionary<String, String> like, Dictionary<String, Object> exac, out Exception exError)
        {
            List<Proveedor> returnValue = new List<Proveedor>();
            exError = null;
            String and = "";

            if (like.Count() > 0 && exac.Count() > 0)
                and = "AND";


            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();



                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(conUsername) + "FROM " + Table + "  LEFT JOIN " 
                    + UTable + " ON " + UTable + ".[id_usuario]=" + Table + ".[prove_usuario]  JOIN  " + 
                    RTable + " ON " + RTable + ".[rubr_id]=" + Table + ".[rubr_id] WHERE " + SqlHelper.getLikeFilter(like) + and + SqlHelper.getExactFilter(exac), (SqlConnection)this.Connection))
                {
                    foreach (KeyValuePair<String, Object> value in exac)
                    {
                        command.Parameters.AddWithValue("@" + value.Key, value.Value);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnValue.Add(new Proveedor(reader));
                            
                           
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

        public override Int32 Create(Proveedor instance, object otro, out Exception exError)
        {
            Int32 modified = -1;
            SqlTransaction trans;
            SqlCommand command;
            Direccion direccion = (Direccion)otro;
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                
                    using ( trans = ((SqlConnection)this.Connection).BeginTransaction())
                    {
                        try
                        {
                        command = new SqlCommand("INSERT INTO "+DTable+" (" + SqlHelper.getColumns(direccion.getAtributeMList()) + ")" +
                                       " output INSERTED.id_domicilio VALUES(" + SqlHelper.getValues(direccion.getAtributeMList()) + ")", (SqlConnection)this.Connection, trans);

                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in direccion.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, direccion.getMethodString(value));
                        }


                        modified = (Int32)command.ExecuteScalar();
                        instance.id_domicilio = modified;

                        command.CommandText = "INSERT INTO " + Table + " (" + SqlHelper.getColumns(instance.getAtributeMList()) + ")" +
                                    " output INSERTED.id_proveedor VALUES(" + SqlHelper.getValues(instance.getAtributeMList()) + ")";
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }
                        modified = (Int32)command.ExecuteScalar();


                        trans.Commit();
                        }
                        catch (Exception ex2)
                        {
                            try
                            {
                                trans.Rollback();
                            }
                            catch {
                                exError = ex2;
                            }
                            exError = ex2;
                        }

                    }
                }           
            catch (InvalidOperationException invalid)
            {                
                exError = invalid;
            }


            return modified;
        }

        public override Int32 Create(Proveedor instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override Proveedor Read(int ID, out Exception exError)
        {
            Proveedor proveedor = new Proveedor();
            exError = null;

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("SELECT " + SqlHelper.getColumns(allAtributes) + "FROM " + Table + "  WHERE id_proveedor=" + ID, (SqlConnection)this.Connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())        
                            throw new InvalidOperationException("No existe el proveedor.");

                        SqlHelper.setearAtributos(reader, allAtributes, proveedor);
                        
                        proveedor.restartMList();

                        if (reader.Read())
                            throw new InvalidOperationException("Proveedors multiples.");
                                               
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
              
            return proveedor;
        }

        public override Proveedor Read(Proveedor instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Proveedor instance, out Exception exError)
        {
            SqlTransaction trans;
            SqlCommand command;            
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                using (trans = ((SqlConnection)this.Connection).BeginTransaction())
                {
                    try
                    {
                        command = new SqlCommand("UPDATE " + Table + " SET " + SqlHelper.getUpdate(instance.getAtributeMList()) +
                                                        " WHERE id_proveedor=" + instance.id_proveedor, (SqlConnection)this.Connection, trans);
                        command.CommandType = System.Data.CommandType.Text;
                        foreach (String value in instance.getAtributeMList())
                        {
                            command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                        }

                        command.ExecuteNonQuery();


                        trans.Commit();
                    }
                    catch (Exception ex2)
                    {
                        try
                        {
                            exError = ex2;
                            trans.Rollback();
                        }
                        catch
                        {
                            exError = ex2;
                        }

                    }

                }
            }
            catch (InvalidOperationException invalid)
            {
                exError = invalid;
            }


            return true;
        }

        public override bool Update(Proveedor instance,object otro ,out Exception exError)
        {
            SqlTransaction trans;
            SqlCommand command;
            Direccion direccion = (Direccion) otro;
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();

                 using ( trans = ((SqlConnection)this.Connection).BeginTransaction())
                 {
                    try
                    {
                        command = new SqlCommand("UPDATE " + Table + " SET " + SqlHelper.getUpdate(instance.getAtributeMList()) +
                                                        " WHERE id_proveedor="+instance.id_proveedor, (SqlConnection)this.Connection,trans);
                            command.CommandType = System.Data.CommandType.Text;
                            foreach (String value in instance.getAtributeMList())
                            {
                                command.Parameters.AddWithValue("@" + value, instance.getMethodString(value));
                            }

                            command.ExecuteNonQuery();

                            command.CommandText = "UPDATE " + DTable + " SET " + SqlHelper.getUpdate(direccion.getAtributeMList())
                                                + " WHERE id_domicilio=" + direccion.id_domicilio;
                       
                            foreach (String value in direccion.getAtributeMList())
                            {
                                command.Parameters.AddWithValue("@" + value, direccion.getMethodString(value));
                            }
                            
                            command.ExecuteNonQuery();

                            trans.Commit();
                        }
                        catch (Exception ex2)
                        {
                            try
                            {
                                trans.Rollback();
                            }
                            catch {
                                exError = ex2;
                            }
                
                        }

                    }
                }           
            catch (InvalidOperationException invalid)
            {                
                exError = invalid;
            }


            return true;
        }

        public override bool Delete(int ID, out Exception exError)
        {
            exError = null;
            try
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();


                using (SqlCommand command = new SqlCommand("UPDATE " + Table + " SET [prov_activo]=0 WHERE id_proveedor=" + ID, (SqlConnection)this.Connection))
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

        public override bool Delete(Proveedor instance, out Exception exError)
        {
            throw new NotImplementedException();
        }

    }
}
