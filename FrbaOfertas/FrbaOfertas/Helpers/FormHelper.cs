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

        public static bool esDecimal(TextBox textBox)
        {            
            Double d;
            if (!Double.TryParse(textBox.Text.Trim(), out d))
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
            String campos="";
            foreach (TextBox textBox in textBoxs)
            {
                if (!noNull(textBox))
                {
                    campos += textBox.Tag+", ";
                                
                }
            }
            if (campos.Count() > 0)
            {
                MessageBox.Show("Capos " + campos + " no pueden estar vacios.", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool esNumericoList(List<TextBox> textBoxs)
        {
            String campos = "";
            foreach (TextBox textBox in textBoxs)
            {
                if (!esNumerico(textBox) && noNull(textBox))
                {
                    campos += textBox.Tag + ", ";
                    
                }
            }

            if (campos.Count() > 0)
            {
                MessageBox.Show("Campos " + campos + " no son numericos.", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool esDecimalList(List<TextBox> textBoxs)
        {
            String campos = "";
            foreach (TextBox textBox in textBoxs)
            {
                if (!esNumerico(textBox) && noNull(textBox))
                {
                    campos += textBox.Tag + ", ";

                }
            }

            if (campos.Count() > 0)
            {
                MessageBox.Show("Campos " + campos + " no son decimales.", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

        public static bool esFecha(TextBox text) {
            DateTime dDate;
            if (DateTime.TryParse(text.Text, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
                return true;
            }
            else
            {
                MessageBox.Show("Campo " + text.Tag + " no es fecha.", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool fechaMayor(DateTime menor , DateTime mayor)
        {            
            if (mayor < menor ) 
            {
                MessageBox.Show("La fecha inicio es mayor a la final.", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        public static bool fechaMayorAactual(DateTime menor, DateTime mayor)
        {
            if (mayor < menor)
            {
                MessageBox.Show("La fecha de fin es mayor a la actual. Actual:"+ mayor.ToShortDateString(), "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
    }
}
