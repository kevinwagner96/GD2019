using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRubro
{
    public partial class NuevoRubro : Form
    {
        public String  rubro;
        public NuevoRubro()
        {
            InitializeComponent();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            if (rubr_detalle.Text.Count() == 0)
            {
                MessageBox.Show("Rubro es vacio.", "Rubro nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rubro = rubr_detalle.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
