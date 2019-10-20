using FrbaOfertas.DataModel;
using FrbaOfertas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.RegistroUsuario
{
    public partial class Login : Form
    {
        UsuarioData data;
        List<TextBox> todos = new List<TextBox>();
        Exception exError = null;
        public Usuario returnUsuario { get; set; }        
        public  Login()
        {
            InitializeComponent();
            data = new UsuarioData(Conexion.getConexion());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LOGIN
            /*
            Usuario user = new Usuario(usuario.Text);
            Usuario userD = data.Read(user, out exError);
            if (exError != null)            
            {
                MessageBox.Show("No se pudo obtener el usuario, " + exError.Message);
                return;
            }

            if(userD.usu_contrasenia = password)
            */
            this.returnUsuario = new Usuario("KEVIN");            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
