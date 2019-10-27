using FrbaOfertas.AbmUsuario;
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

namespace FrbaOfertas.AbmProveedor
{
    public partial class ModificarUsuario : Form
    {
        Int32 id_usuario;
        Usuario usuario;        
        List<TextBox> noNulos= new List<TextBox>();
        List<TextBox> numericos= new List<TextBox>();
        List<TextBox> todos = new List<TextBox>();
        List<Rol> roles;
        UsuarioData uData;
        RolData rData;
       
        Exception exError = null;
        public ModificarUsuario(int id)
        {
            InitializeComponent();
            id_usuario = id;
        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {
            noNulos.Add(usu_username);
            //noNulos.Add(usu_contrasenia);
            noNulos.Add(usu_cant_intentos_fallidos);
            numericos.Add(usu_cant_intentos_fallidos);

            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    todos.Add((TextBox)x);
                }
            }

            uData = new UsuarioData(Conexion.getConexion());
            rData = new RolData (Conexion.getConexion());

            usuario = uData.Read(id_usuario, out exError);
            Dictionary<String, Object> dic = new Dictionary<String, Object>() { { "id_usuario", usuario.id_usuario } };
            List<Rol> rolesDeUsuario = rData.FilterSelect(null, dic, out exError);
            usu_activo.Checked = usuario.usu_activo;
            if (exError != null)
            {
                MessageBox.Show("Error , " + exError.Message);
                return;
            }
            FormHelper.setearTextBoxs(todos, usuario);

            roles = rData.Select(out exError);
            int i = 0;
            roles.ForEach(delegate(Rol rol)
            {
                checkedListRoles.Items.Add(rol.rol_nombre);
                rolesDeUsuario.ForEach(delegate(Rol miRol)
                {
                    if(rol.id_rol==miRol.id_rol)
                        checkedListRoles.SetItemChecked(i, true);
                });
                i++;                
            });
                        
        }
   

     

        private void guardar_Click(object sender, EventArgs e)
        {
            Boolean rolCliente = false;
            Boolean rolProveedor = false;

            if (!FormHelper.noNullList(noNulos) || !FormHelper.esNumericoList(numericos))
                return;

            //List<TextBox> datos = FormHelper.getNoNulos(todos);

            usuario.usu_username = usu_username.Text;
            Int32 cantinte=0;
            Int32.TryParse(usu_cant_intentos_fallidos.Text,out cantinte);
            usuario.usu_cant_intentos_fallidos=cantinte;
            usuario.usu_activo = usu_activo.Checked; 

            if(usu_contrasenia.Text.Count()>0)
                usuario.usu_contrasenia = usu_contrasenia.Text;

            Int32 i = 0;
            roles.ForEach(delegate(Rol f)
            {
                if (checkedListRoles.GetItemChecked(i))
                {
                    usuario.roles.Add(f);
                    if (f.rol_nombre == "CLIENTE")
                    {
                        rolCliente=true;
                    }else if(f.rol_nombre == "PROVEEDOR"){
                        rolProveedor=true;
                    }

                }

                i++;
            });


            if (!asignarRoles(rolCliente, rolProveedor))
                return;


            DialogResult result = MessageBox.Show("Seguro quiere modificar al usuario " + usuario.usu_username + ".", "Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                uData.Update(usuario, out exError);
                if (exError == null)
                {

                    this.Close();
                    //MessageBox.Show("Proveedor  " + proveedor.clie_nombre + " " + proveedor.clie_apellido + " modificado exitosamente.", "Proveedor nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);     
                }
                else
                    MessageBox.Show("Erro al modificar usuario, " + exError.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool asignarRoles(bool rolCliente, bool rolProveedor)
        {
            ClienteData cData = new ClienteData(Conexion.getConexion());
            ProveedorData pData = new ProveedorData(Conexion.getConexion());

            Dictionary<String, Object> clie = new Dictionary<String, Object>() { { "clie_usuario", usuario.id_usuario } };
            Dictionary<String, Object> prov = new Dictionary<String, Object>() { { "prove_usuario", usuario.id_usuario } };

            List<Cliente> clientes = cData.FilterSelect(new Dictionary<String, String>(), clie, out exError);
            List<Proveedor> proveedores = pData.FilterSelect(new Dictionary<String, String>(), prov, out exError);

            if(clientes.Count()>0)
                rolCliente = false;

            if (proveedores.Count() > 0)
                rolCliente = false;

            if (rolCliente || rolProveedor)
            {
                Asignaciones asignaciones = new Asignaciones(rolCliente, rolProveedor,id_usuario);
                asignaciones.Parent = this.Parent;
                var result = asignaciones.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return true;
            }
            
        }


        

       

        


    }
}
