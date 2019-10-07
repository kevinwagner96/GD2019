using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Usuario
    {

        [System.ComponentModel.DisplayName("Usuario")]        
        public String userName { get; set; }
        [System.ComponentModel.DisplayName("Contraseña")]
        public String contrasenia { get; set; }
        [System.ComponentModel.DisplayName("Intentos Fallidos")]        
        public Int32 cantIntentosFallidos { get; set; }      
        [System.ComponentModel.DisplayName("Activo")]        
        public Boolean activo { get; set; }

        public Usuario(string user, int p2, bool p3)
        {
            // TODO: Complete member initialization
            this.userName = (String) user;
            this.cantIntentosFallidos = (Int32)p2;
            this.activo = (Boolean)p3;
            
        }

    }



}
