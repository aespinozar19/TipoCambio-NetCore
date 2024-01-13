using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesBD
{
    public class ConversionTC
    {
        public decimal MontoOrigen { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public DateTime FechaTipoCambio { get; set; }
        public decimal MontoDestino { get; set; }
        public decimal TipoCambioCompra { get; set; }
        public decimal TipoCambioVenta { get; set; }

        public int ClientePreferencial { get; set; }
    }
}
