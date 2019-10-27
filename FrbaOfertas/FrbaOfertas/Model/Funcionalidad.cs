﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Funcionalidad
    {
        public List<String> atributesModify = new List<string>();

        Int32 _fun_codigo;
        String _fun_nombre;


        public Funcionalidad(string p1, int p2)
        {
            // TODO: Complete member initialization
            this._fun_nombre = p1;
            this._fun_codigo = p2;
        }

        public Funcionalidad()
        {
            // TODO: Complete member initialization
        }

        [System.ComponentModel.DisplayName("Codigo")]
        public Int32 fun_codigo { get { return this._fun_codigo; } set { this._fun_codigo = value; atributesModify.Add("_fun_codigo"); } }
        [System.ComponentModel.DisplayName("Nombre")]
        public String fun_nombre { get { return this._fun_nombre; } set { this._fun_nombre = value; atributesModify.Add("_fun_nombre"); } }
    }
}
