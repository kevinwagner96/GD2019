using FrbaOfertas.DataModel;
using FrbaOfertas.Helpers;
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
        List<TextBox> noNulos = new List<TextBox>();
        public Usuario returnUsuario { get; set; }        
        public  Login()
        {
            InitializeComponent();
            data = new UsuarioData(Conexion.getConexion());
            noNulos.Add(usuario);
            noNulos.Add(password);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!FormHelper.noNullList(noNulos))
                return;
            
            Usuario user = new Usuario(usuario.Text,password.Text);
            Usuario userD = data.Read(user, out exError);
            if (exError != null)            
            {
                MessageBox.Show("Error , " + exError.Message);
                return;
            }

            if (userD != null)
            {     
                this.returnUsuario = userD;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
   
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoUsuario nc = new NuevoUsuario();
            nc.ShowDialog();
            nc.Focus();
        }

        
    }
}
