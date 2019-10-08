using FrbaOfertas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Helpers
{
    public static class SqlHelper
    {
        public static String getColumns(List<String> list){
            String returned = "";
            foreach (String value in list)
            {
                returned += "[" + value + "],";
            }

            return returned.Remove(returned.Length - 1);
        }

        public static String getValues(List<String> list)
        {
            String returned = "";
            foreach (String value in list)
            {
                returned += "@" + value + ",";
            }

            return returned.Remove(returned.Length - 1);
        }

        public static String getUpdate(List<String> list)
        {
            String returned = "";
            foreach (String value in list)
            {
                returned += "[" + value + "]=@" + value + ",";
            }

            return returned.Remove(returned.Length - 1);
        }

        public static List<String> getValuesList(List<String> list)
        {
            List<String> returned = new List<string>();
            foreach (String value in list)
            {
                returned.Add("@" + value);
            }

            return returned;
        }

        public static object setearAtributos(SqlDataReader reader, List<String> atributes, object objeto)
        {
            foreach (String atribute in atributes)
            {

                try
                {
                    if (objeto.GetType().GetProperty(atribute).PropertyType == typeof(String))
                        objeto.GetType().GetProperty(atribute).SetValue(objeto, (String) reader.GetValue(reader.GetOrdinal(atribute)));
                    else if (objeto.GetType().GetProperty(atribute).PropertyType == typeof(Int32))
                    {
                        try
                        {
                            objeto.GetType().GetProperty(atribute).SetValue(objeto, reader.GetInt32(reader.GetOrdinal(atribute)));
                        }
                        catch
                        {
                            objeto.GetType().GetProperty(atribute).SetValue(objeto, (Int32)reader.GetDecimal(reader.GetOrdinal(atribute)));
                        }
                    }
                    else if (objeto.GetType().GetProperty(atribute).PropertyType == typeof(Int32?))
                        objeto.GetType().GetProperty(atribute).SetValue(objeto, (Int32?)reader.GetValue(reader.GetOrdinal(atribute)));
                    else if (objeto.GetType().GetProperty(atribute).PropertyType == typeof(DateTime))
                        objeto.GetType().GetProperty(atribute).SetValue(objeto, reader.GetDateTime(reader.GetOrdinal(atribute)));
                    else if (objeto.GetType().GetProperty(atribute).PropertyType == typeof(Double))
                        objeto.GetType().GetProperty(atribute).SetValue(objeto, (Double)reader.GetDecimal(reader.GetOrdinal(atribute)));
                    else if (objeto.GetType().GetProperty(atribute).PropertyType == typeof(Boolean))
                        objeto.GetType().GetProperty(atribute).SetValue(objeto, (Boolean)reader.GetValue(reader.GetOrdinal(atribute)));


                }
                catch { }
            }

            return objeto;
        }

    }
}
