using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    class Rol
    {
        public List<String> atributesModify = new List<string>();


        Int32 _id_rol;
        String _rol_nombre;
        Boolean _activo;
        List<Funcionalidad> _funcionalidades = new List<Funcionalidad>();


        public Int32 id_rol { get { return this._id_rol; } set { this._id_rol = value; atributesModify.Add("id_rol"); } }
        [System.ComponentModel.DisplayName("Nombre")]
        public String rol_nombre { get { return this._rol_nombre; } set { this._rol_nombre = value; atributesModify.Add("rol_nombre"); } }
        [System.ComponentModel.DisplayName("Activo")]
        public Boolean rol_activo { get { return this._activo; } set { this._activo = value; atributesModify.Add("rol_activo"); } }
        [System.ComponentModel.Browsable(false)]
        public List<Funcionalidad> funcionalidades { get { return this._funcionalidades; } set { this._funcionalidades = value; } }


        public List<String> getAtributeMList()
        {
            return atributesModify.Distinct().ToList();
        }

        public dynamic getMethodString(String methodName)
        {
            return this.GetType().GetProperty(methodName).GetValue(this, null); ;
        }

        public void restartMList()
        {
            this.atributesModify.Clear();
        }

        public void setMethodString(String methodName, object value)
        {
            this.GetType().GetProperty(methodName).SetValue(this, value);
        }
    }
}
