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
    public partial class NuevoUsuario : Form
    {
        
        List<TextBox> noNulos= new List<TextBox>();
        List<TextBox> numericos= new List<TextBox>();
        List<TextBox> todos = new List<TextBox>();
        public object returnUsuario { get; set; }
        Usuario usuario;

        List<Rol> roles;
       
        UsuarioData uData;

        RolData rData;
        
        Exception exError = null;
        bool noDB=false;
        public NuevoUsuario(bool db)
        {
            InitializeComponent();
            noDB = db;
            
        }
        public NuevoUsuario()
        {
            InitializeComponent();

        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {
            noNulos.Add(usu_username);
            noNulos.Add(usu_contrasenia);            

            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    todos.Add((TextBox)x);
                }
            }

            uData = new UsuarioData(Conexion.getConexion());
            rData = new RolData(Conexion.getConexion());


            
            roles = rData.SelectActivos(out exError);     // solo los activos       
            roles.ForEach(delegate(Rol rol)
            {
                checkedListRoles.Items.Add(rol.rol_nombre);

            });
           

           
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            Boolean rolCliente = false;
            Boolean rolProveedor = false;

            if (!FormHelper.noNullList(noNulos) || !FormHelper.esNumericoList(numericos))
                return;

            //List<TextBox> datos = FormHelper.getNoNulos(todos);

            FormHelper.setearAtributos(todos, usuario);
          
            usuario.usu_activo = prov_activo.Checked;

            if (noDB)
            {
                
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            Int32 i = 0;
            roles.ForEach(delegate(Rol f)
            {
                if (checkedListRoles.GetItemChecked(i))
                {
                    usuario.roles.Add(f);
                    if (f.rol_nombre == "CLIENTE")
                    {
                        rolCliente = true;
                    }
                    else if (f.rol_nombre == "PROVEEDOR")
                    {
                        rolProveedor = true;
                    }
                }

                i++;
            });

            Int32 id = uData.Create(usuario, usuario.roles, out exError);
            if (exError == null)
            {
                MessageBox.Show("Usuario  " + usuario.usu_username + " agregado exitosamente.", "Usuario nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (!asignarRoles(rolCliente, rolProveedor,id))
                    return;

                this.Close();
            }
            else
                MessageBox.Show("Erro al agregar Usuario, " + exError.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);    
          
            
        }


        private bool asignarRoles(bool rolCliente, bool rolProveedor,int id_usuario)
        {
            ClienteData cData = new ClienteData(Conexion.getConexion());
            ProveedorData pData = new ProveedorData(Conexion.getConexion());

            Dictionary<String, Object> clie = new Dictionary<String, Object>() { { "clie_usuario", usuario.id_usuario } };
            Dictionary<String, Object> prov = new Dictionary<String, Object>() { { "prove_usuario", usuario.id_usuario } };

            List<Cliente> clientes = cData.FilterSelect(new Dictionary<String, String>(), clie, out exError);
            List<Proveedor> proveedores = pData.FilterSelect(new Dictionary<String, String>(), prov, out exError);

            if (clientes.Count() > 0)
                rolCliente = false;

            if (proveedores.Count() > 0)
                rolCliente = false;

            if (rolCliente || rolProveedor)
            {
                Asignaciones asignaciones = new Asignaciones(rolCliente, rolProveedor, id_usuario);
                asignaciones.Parent = this.Parent;
                var result = asignaciones.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }
        

       

        


    }
}
