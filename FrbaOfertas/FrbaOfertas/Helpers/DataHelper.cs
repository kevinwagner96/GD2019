using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FrbaOfertas.Helpers
{
    public abstract class  DataHelper<T>
    {
        public IDbConnection Connection { get; private set; }

        public DataHelper(IDbConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("Conexion invalida a DB.");
            this.Connection = connection;
        }

        public abstract List<T> Select(out Exception exError);
        
        public abstract List<T> FilterSelect(List<Dictionary<String,String>> filtros,out Exception exError);

        public abstract Int32 Create(T instance, out Exception exError);
        
        public abstract Int32 Create(T instance,object otro, out Exception exError);

        public abstract T Read(int ID, out Exception exError);

        public abstract T Read(T instance, out Exception exError);

        public abstract bool Update(T instance, out Exception exError);

        public abstract bool Delete(int ID, out Exception exError);

        public abstract bool Delete(T instance, out Exception exError);
    }
}
