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

namespace FrbaOfertas.Interface
{
    public partial class Tus_roles : Form
    {
        List<Rol> roles;
        public object seleccionado { get; set; }

        public Tus_roles(object roles)
        {
            InitializeComponent();
            this.roles = (List<Rol>)roles;
            
        }

        private void Tus_roles_Load(object sender, EventArgs e)
        {
            roles.ForEach(delegate(Rol f)
            {
                comboBox1.Items.Add(f.rol_nombre);
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Count() < 1)
            {
                MessageBox.Show("Selecciones un rol.");
                return;
            }

            roles.ForEach(delegate(Rol f)
            {
                if (f.rol_nombre == comboBox1.Text)
                    seleccionado = f;
            });

      
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
