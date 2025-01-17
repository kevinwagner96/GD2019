﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas
{
    public static class ConfigurationHelper
    {
        public static string ConnectionString { get { return Properties.Settings.Default.ConexionString; } }
        public static DateTime FechaActual { get { return Properties.Settings.Default.Fecha; } }
        public static Double CreditoInicial { get { return (Double)Properties.Settings.Default.CreditoInicial; } }
        public static Int32 TokenSize { get { return (Int32)Properties.Settings.Default.OfertaTokenSize; } }
    }
}
