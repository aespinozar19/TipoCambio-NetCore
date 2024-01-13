using EntidadesBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace TC.PERSISTENCIA
{
    public interface ITCCrud
    {
        IEnumerable<TipoCambioEntidad> getListaTcxMoneda(int mes, int anio, ref string messageException);
        bool tcDeleteService(TipoCambioEntidad tcRequest, ref string messageException);
        bool tcUpdateService(TipoCambioEntidad tcRequest, ref string messageException);
        int tcSaveService(TipoCambioEntidad tcRequest, ref string messageException);
    }
}
