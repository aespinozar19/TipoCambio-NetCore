using EntidadesBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace TC.PERSISTENCIA
{
    public interface ItcConversion
    {
        //ConversionTC ConversionMonedaTC(int monedaOrigen, int monedaDestino,
        //    decimal monto, DateTime fecha,
        //    ref string validacionConversion, ref string messageException);

        ConversionTC ConversionMonedaTC(int monedaOrigen, int monedaDestino,
            decimal monto, DateTime fecha, int clientePreferencial,
            ref string validacionConversion, ref string messageException);
    }
}
