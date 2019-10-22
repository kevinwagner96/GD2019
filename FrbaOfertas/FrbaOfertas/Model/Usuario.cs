using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Usuario
    {
        public List<String> atributesModify = new List<string>();

        private Int32 _id_usuario;
        private String _usu_username;
        private String _usu_contrasenia;
        private Int32 _usu_cant_intentos_fallidos;
        
        private Boolean _usu_activo;        

        public Int32 id_usuario { get { return this._id_usuario; } set { this._id_usuario = value; atributesModify.Add("id_usuario"); } }
        [System.ComponentModel.DisplayName("Nombre")]
        public String usu_username { get { return this._usu_username; } set { this._usu_username = value; atributesModify.Add("usu_username"); } }
        [System.ComponentModel.DisplayName("Contraseña")]
        public String usu_contrasenia { get { return this._usu_contrasenia; } set { this._usu_contrasenia = value; atributesModify.Add("usu_contrasenia"); } }
        [System.ComponentModel.DisplayName("Intentos Fallidos")]
        public Int32 usu_cant_intentos_fallidos { get { return this._usu_cant_intentos_fallidos; } set { this._usu_cant_intentos_fallidos = value; atributesModify.Add("usu_cant_intentos_fallidos"); } }
        [System.ComponentModel.DisplayName("Activo")]
        public Boolean usu_activo { get { return this._usu_activo; } set { this._usu_activo = value; atributesModify.Add("usu_activo"); } }

        public Usuario(string user, String p2, bool p3)
        {
            // TODO: Complete member initialization
            
            this.usu_username = (String)user;
            this.usu_contrasenia = (String)p2;
            this.usu_activo = (Boolean)p3;
            
        }

        public Usuario()
        {
            // TODO: Complete member initialization
        }

        public Usuario(string p,string pass)
        {
            // TODO: Complete member initialization
            this.usu_username = p;
            this.usu_contrasenia = pass;
        }

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
