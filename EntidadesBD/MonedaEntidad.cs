using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesBD
{
    internal class MonedaEntidad
    {
        //public MonedaEntidad() { }
        public int intIdMoneda { get; set; }
        public string strDescripcionMoneda { get; set; }
        public string strMonedaISO { get; set; }
        public bool bolEstadoMoneda { get; set; }

        //Auditoria
        public string strUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string strUsuarioActualiza { get; set; }
        public DateTime? FechaActualiza { get; set; }
        public string strUsuarioElimina { get; set; }
        public DateTime? FechaElimina { get; set; }

    }
}
