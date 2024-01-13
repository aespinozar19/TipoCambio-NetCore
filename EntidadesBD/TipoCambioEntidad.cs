using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesBD
{
    public class TipoCambioEntidad
    { 
        //public TipoCambioEntidad() { }  
        public int iIdMoneda { get; set; }
        public decimal dcValorCompra { get; set; }
        public decimal dcValorVenta { get; set; }
        public int iDia { get; set; }
        public int iMes { get; set; }
        public int iAnio { get; set; }
        public DateTime dFechaTC { get; set; }
        public bool bEstado { get; set; }
        //Auditoria
        public string vUsuarioRegistro { get; set; }        
        public DateTime dFechaRegistro { get; set; }
        public string vUsuarioActualiza { get; set; }
        public DateTime? dFechaActualiza { get; set; }
        public string vUsuarioElimina { get; set; }
        public DateTime? dFechaElimina { get; set; }


    }
}
