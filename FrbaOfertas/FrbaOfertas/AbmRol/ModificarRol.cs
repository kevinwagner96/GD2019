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

namespace FrbaOfertas.AbmRol
{
    public partial class ModificarRol : Form
    {
        Int32 id_rol;
        RolData data;
        Rol rol;
        FuncionalidadesData fdata;
        List<Funcionalidad> funcionalidades;
        Exception exError = null;
        public ModificarRol(Int32 id)
        {
            InitializeComponent();
            id_rol = id;
            data = new RolData(Conexion.getConexion());
            fdata = new FuncionalidadesData(Conexion.getConexion());
            CargarFuncionalidades();
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            rol = data.Read(id_rol,out exError);
            if (exError != null)
            {
                MessageBox.Show("Erro al cargar Rol, " + exError.Message, "Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            

            rol_nombre.Text = rol.rol_nombre;
            rol_activo.Checked = rol.rol_activo;
            int i = 0;

            funcionalidades.ForEach(delegate(Funcionalidad f)
            {
                rol.funcionalidades.ForEach(delegate(Funcionalidad f2)
                {
                    if (f.fun_codigo == f2.fun_codigo)
                        checkedListFuncionalidades.SetItemChecked(i,true);
                });
                i++;                
            });
            
        }

        private void CargarFuncionalidades()
        {
            funcionalidades = fdata.Select(out exError);
            if (exError != null)
            {
                MessageBox.Show("Erro al cargar Rol, " + exError.Message, "Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            funcionalidades.ForEach(delegate(Funcionalidad f)
            {
                checkedListFuncionalidades.Items.Add(f.fun_nombre);
            });

        }

        private void guardar_Click(object sender, EventArgs e)
        {            
            int i = 0;
            rol.rol_nombre = rol_nombre.Text;
            rol.rol_activo = rol_activo.Checked;
            rol.funcionalidades.Clear();

            funcionalidades.ForEach(delegate(Funcionalidad f)
            {
                if (checkedListFuncionalidades.GetItemChecked(i))
                    rol.funcionalidades.Add(f);

                i++;
            });
         
            data.Update(rol,  out exError);
            if (exError == null)
            {
                MessageBox.Show("ROL actualizdo exitosamente.", "Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro al actualizar Rol, " + exError.Message, "Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);    
        }
    }
}
