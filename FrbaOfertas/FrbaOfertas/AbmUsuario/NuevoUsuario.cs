﻿using FrbaOfertas.DataModel;
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
       
        UsuarioData uData;
        
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
            noNulos.Add(prov_razon_social);
            noNulos.Add(prov_CUIT);
            noNulos.Add(prov_rubro);
            noNulos.Add(prov_contacto);
            noNulos.Add(dom_calle);
            noNulos.Add(dom_ciudad);
            numericos.Add(prov_CUIT);
            numericos.Add(dom_numero);
            numericos.Add(dom_depto);
            numericos.Add(dom_piso);

            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    todos.Add((TextBox)x);
                }
            }

            uData = new UsuarioData(Conexion.getConexion());
           

           
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
       

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

            //Int32 id = uData.Create(usuario, rol, out exError);
            if (exError == null)
            {
                MessageBox.Show("Usuario  " + usuario.usu_username + " agregado exitosamente.", "Usuario nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro al agregar Usuario, " + exError.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);    
          
            
        }

        

       

        


    }
}
