﻿using FrbaOfertas.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Model
{
    public class Cliente
    {
        public List<String> atributesModify = new List<string>();

        private Int32 _id_cliente;
        private Int32 _id_domicilio;
        private Int32? _clie_usuario ;        
        private Int32 _clie_dni;
        private String _clie_nombre;
        private String _clie_apellido;
        private String _clie_email ;
        private String _clie_telefono;
        private DateTime _clie_fecha_nac;
        private String _usu_username;
        private Double _credito;
        private Boolean _activo;


        public Cliente(int p1, int p2, int p3, int p4, string p5, string p6, string p7, string p8, DateTime dateTime, double p9, bool p10)
        {
            this.id_cliente = p1;
            this.id_domicilio = p2;
            this._clie_usuario = p3;
            this.clie_dni = p4;
            this.clie_nombre = p5;
            this.clie_apellido = p6;
            this.clie_email = p7;
            this.clie_telefono = p8;
            this.clie_fecha_nac = dateTime;
            this._credito = p9;
            this._activo = p10;
        }

        public Cliente(SqlDataReader reader)
        {
            try
            {
                id_cliente = reader.GetInt32(0);
                id_domicilio = reader.GetInt32(1);
                if(!reader.IsDBNull(2))
                    clie_usuario = reader.GetInt32(2);
                if (!reader.IsDBNull(3))
                    usu_username = reader.GetString(3);
                clie_dni = (Int32)reader.GetDecimal(4);
                clie_nombre = reader.GetString(5);
                clie_apellido = reader.GetString(6);
                if (!reader.IsDBNull(7))
                    clie_email = reader.GetString(7);
                if (!reader.IsDBNull(8))
                    clie_telefono = reader.GetString(8);
                clie_fecha_nac = reader.GetDateTime(9);
                clie_credito = Decimal.ToDouble(reader.GetDecimal(10));
                clie_activo = reader.GetBoolean(11);
            }
            catch{ }


        }
        public String getColumns()
        {
           return SqlHelper.getColumns( new List<String>(new String[] { "id_cliente", "id_domicilio", "clie_usuario", "usu_username", "clie_dni", "clie_nombre", "clie_apellido", "clie_email", "clie_telefono", "clie_fecha_nac", "clie_credito", "clie_activo" }));
        }

        public Cliente()
        {
            // TODO: Complete member initialization
        }

        public Cliente(string p5, string p6, string p7, string p8)
        {
            // TODO: Complete member initialization
            this.clie_nombre = p5;
            this.clie_apellido = p6;
            this.clie_email = p7;
            this.clie_telefono = p8;
        }

        
        public Int32 id_cliente { get { return this._id_cliente; } set { this._id_cliente = value;  } }
        [System.ComponentModel.Browsable(false)]
        public Int32 id_domicilio { get { return this._id_domicilio; } set { this._id_domicilio = value; atributesModify.Add("id_domicilio"); } }
        [System.ComponentModel.Browsable(false)]
        public Int32? clie_usuario { get { return this._clie_usuario; } set { this._clie_usuario = value; atributesModify.Add("clie_usuario"); } }        
        [System.ComponentModel.DisplayName("DNI")]
        public Int32 clie_dni{ get { return this._clie_dni; }set { this._clie_dni = value; atributesModify.Add("clie_dni"); }}
        [System.ComponentModel.DisplayName("Nombre")]
        public String clie_nombre{  get { return this._clie_nombre; }  set { this._clie_nombre = value; atributesModify.Add("clie_nombre"); } }
        [System.ComponentModel.DisplayName("Apellido")]
        public String clie_apellido { get { return this._clie_apellido; } set { this._clie_apellido = value; atributesModify.Add("clie_apellido"); } }
        [System.ComponentModel.DisplayName("Email")]
        public String clie_email { get { return this._clie_email; } set { this._clie_email = value; atributesModify.Add("clie_email"); } }
        [System.ComponentModel.DisplayName("Telefono")]
        public String clie_telefono { get { return this._clie_telefono; } set { this._clie_telefono = value; atributesModify.Add("clie_telefono"); } }
        [System.ComponentModel.DisplayName("Fecha Nacimiento")]
        public DateTime clie_fecha_nac { get { return this._clie_fecha_nac; } set { this._clie_fecha_nac = value; atributesModify.Add("clie_fecha_nac"); } }
        [System.ComponentModel.DisplayName("Credito")]
        public Double clie_credito { get { return this._credito; } set { this._credito = value; atributesModify.Add("clie_credito"); } }
        [System.ComponentModel.DisplayName("Username")]
        public String usu_username { get { return this._usu_username; } set { this._usu_username = value; } }
        [System.ComponentModel.DisplayName("Activo")]
        public Boolean clie_activo { get { return this._activo; } set { this._activo = value; atributesModify.Add("clie_activo"); } }

        

        

        public List<String> getAtributeMList()
        {
            return atributesModify.Distinct().ToList();
        }

        public dynamic getMethodString(String methodName)
        {           
            return    this.GetType().GetProperty(methodName).GetValue(this, null); ;           
        }

        public void restartMList()
        {
            this.atributesModify.Clear();
        }

        public void setMethodString(String methodName,object value)
        {
            this.GetType().GetProperty(methodName).SetValue(this,value) ;
        }

    }
}
