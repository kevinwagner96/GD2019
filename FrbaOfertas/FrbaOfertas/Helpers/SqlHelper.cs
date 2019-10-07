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

        public static List<String> getValuesList(List<String> list)
        {
            List<String> returned = new List<string>();
            foreach (String value in list)
            {
                returned.Add("@" + value);
            }

            return returned;
        }

    }
}
