using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Helpers
{
    static class  FormHelper
    {
        public static bool esNumerico(TextBox textBox)
        {
            int value;
            if (!Int32.TryParse(textBox.Text.Trim(), out value))          
                return false;
            
            return true;
        }

        public static bool noNull(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text))     
                return false;
            
            return true;
        }

        public static bool noNullList(List<TextBox> textBoxs)
        {
            foreach (TextBox textBox in textBoxs)
            {
                if (!noNull(textBox))
                {
                    MessageBox.Show("El campo " + textBox.Tag + " no puede estar vacio.", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        public static bool esNumericoList(List<TextBox> textBoxs)
        {
            foreach (TextBox textBox in textBoxs)
            {
                if (!esNumerico(textBox) && noNull(textBox))
                {
                    MessageBox.Show("El campo " + textBox.Tag + " no es numerico.", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        public static List<TextBox> getNoNulos(List<TextBox> textBoxs)
        {
            List<TextBox> datos= new List<TextBox>();
            foreach (TextBox textBox in textBoxs)
            {
                if (noNull(textBox))
                    datos.Add(textBox);
            }

            return datos;
        }

        public static object setearAtributos(List<TextBox> textBoxs,object objeto)
        {            
            foreach (TextBox textBox in textBoxs)
            {

                try
                {
                    if (objeto.GetType().GetProperty(textBox.Name).PropertyType == typeof(String))
                        objeto.GetType().GetProperty(textBox.Name).SetValue(objeto, textBox.Text);
                    else if (objeto.GetType().GetProperty(textBox.Name).PropertyType == typeof(Int32))
                        objeto.GetType().GetProperty(textBox.Name).SetValue(objeto, Int32.Parse(textBox.Text));
                    else if (objeto.GetType().GetProperty(textBox.Name).PropertyType == typeof(Int32?))
                        objeto.GetType().GetProperty(textBox.Name).SetValue(objeto, Int32.Parse(textBox.Text));
                    else if (objeto.GetType().GetProperty(textBox.Name).PropertyType == typeof(DateTime))
                        objeto.GetType().GetProperty(textBox.Name).SetValue(objeto, DateTime.Parse(textBox.Text));
                    else if (objeto.GetType().GetProperty(textBox.Name).PropertyType == typeof(Double))
                        objeto.GetType().GetProperty(textBox.Name).SetValue(objeto, Double.Parse(textBox.Text));


                }
                catch { }
            }

            return objeto;
        }

        public static object setearTextBoxs(List<TextBox> textBoxs, object objeto)
        {
            foreach (TextBox textBox in textBoxs)
            {

                try
                {
                    textBox.Text = objeto.GetType().GetProperty(textBox.Name).GetValue(objeto, null).ToString();                        
                }
                catch { }
            }

            return objeto;
        }
    }
}
