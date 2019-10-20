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
    public partial class NuevoRol : Form
    {
        FuncionalidadesData data;
        RolData dataRol;
        Exception exError = null;
        List<Funcionalidad> funcionalidades;

        public NuevoRol()
        {
            InitializeComponent();
            data = new FuncionalidadesData(Conexion.getConexion());
        }

        private void NuevoRol_Load(object sender, EventArgs e)
        {
            CargarFuncionalidades();
        }

        private void CargarFuncionalidades()
        {
            funcionalidades = data.Select(out exError);
            funcionalidades.ForEach(delegate(Funcionalidad f)
            {
                checkedListFuncionalidades.Items.Add(f.fun_nombre);
            });
            
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            int i = 0;
            rol.rol_nombre = rol_nombre.Text;
            rol.rol_activo = rol_activo.Checked;

            funcionalidades.ForEach(delegate(Funcionalidad f)
            {
                if (checkedListFuncionalidades.GetItemChecked(i))
                    rol.funcionalidades.Add(f);

                i++;
            });

            dataRol= new RolData(Conexion.getConexion());
            dataRol.Create(rol, null, out exError);
            if (exError == null)
            {
                MessageBox.Show("ROL  agregado exitosamente.", "Rol nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro al agregar Rol, " + exError.Message, "Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);    

        }
    }
}
