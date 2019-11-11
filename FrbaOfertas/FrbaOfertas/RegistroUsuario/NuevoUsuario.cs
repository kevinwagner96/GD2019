using FrbaOfertas.AbmCliente;
using FrbaOfertas.AbmProveedor;
using FrbaOfertas.DataModel;
using FrbaOfertas.Helpers;
using FrbaOfertas.Model;
using FrbaOfertas.Model.DataModel;
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
    public partial class NuevoUsuario : Form
    {
        RolData data;
        Exception exError = null;
        List<TextBox> noNulos = new List<TextBox>();
        TextBox text;
        ClienteData dataC;
        ProveedorData dataP;
        DireccionData dataD;
        UsuarioData dataU;
        List<Rol> roles;


        public NuevoUsuario()
        {
            InitializeComponent();
            data = new RolData(Conexion.getConexion());
            noNulos.Add(usuario);
            noNulos.Add(password);
            text = new TextBox();
            text.Tag = "ROL";
            noNulos.Add(text);
        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            roles = data.SelectActivos(out exError);

            roles.ForEach(delegate(Rol f)
            {
                if(f.rol_nombre != "ADMINISTRADOR")
                    comboBox1.Items.Add(f.rol_nombre);
            });


            dataD = new DireccionData(Conexion.getConexion());
            dataC = new ClienteData(Conexion.getConexion());
            dataP = new ProveedorData(Conexion.getConexion());
            dataU = new UsuarioData(Conexion.getConexion());
        }

        private int getId_rol(String rol){
            Int32 r=-1;

            roles.ForEach(delegate(Rol f)
            {
                if (f.rol_nombre == text.Text)
                {
                    r = (Int32)f.id_rol;                    
                }
            });
            if(r>0)
                return r;
            else
                throw new Exception("No se encuentra el rol");
        }

        private void Exception()
        {
            throw new NotImplementedException();
        }

        private void Exception(string p)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text.Text = comboBox1.Text;            

            if (!FormHelper.noNullList(noNulos))
                return;



            if (comboBox1.Text == "ADMINISTRADOR")
                controller();
            else if (comboBox1.Text == "CLIENTE")
                controller(new NuevoCliente(true));
            else if (comboBox1.Text == "PROVEEDOR")
                controller(new NuevoProveedor(true));
            else 
                controller();

        }

        private void controller(NuevoCliente form)
        {            
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Int32 id_user = dataU.Create(new Usuario(usuario.Text, password.Text), getId_rol(text.Text), out exError);
                if (exError == null)
                {
                    form.returnCliente.clie_usuario = id_user;
                    dataC.Create(form.returnCliente, form.returnDireccion, out exError);
                    if (exError == null)
                    {
                        MessageBox.Show("Usuario  " + usuario.Text + " agregado exitosamente.", "Usuario nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else {
                        Exception temprana = exError;
                        dataU.Delete(id_user, out exError);
                        MessageBox.Show("Erro al agregar Usuario, " + usuario.Text + " ERROR: " + temprana.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                    
                }
                else
                    MessageBox.Show("Erro al agregar Usuario, " + usuario.Text +" ERROR: "+exError.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);                  
            }


        }

        private void controller(NuevoProveedor form)
        {
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Int32 id_user = dataU.Create(new Usuario(usuario.Text, password.Text), getId_rol(text.Text), out exError);
                if (exError == null)
                {
                    ((Proveedor)form.returnProveedor).prove_usuario = id_user;
                    dataP.Create((Proveedor)form.returnProveedor, form.returnDireccion, out exError);
                    if (exError == null)
                    {
                        MessageBox.Show("Usuario  " + usuario.Text + " agregado exitosamente.", "Usuario nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        Exception temprana = exError;
                        dataU.Delete(id_user, out exError);
                        MessageBox.Show("Erro al agregar Usuario, " + usuario.Text + " ERROR: " + temprana.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                    MessageBox.Show("Erro al agregar Usuario, " + usuario.Text + " ERROR: " + exError.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void controller()
        {
            Int32 id_user = dataU.Create(new Usuario(usuario.Text, password.Text), getId_rol(text.Text), out exError);
            if (exError == null)
            {
                MessageBox.Show("Usuario  " + usuario.Text + " agregado exitosamente.", "Usuario nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro al agregar Usuario, " + usuario.Text + " ERROR: " + exError.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
