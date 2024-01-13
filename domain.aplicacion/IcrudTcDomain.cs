using EntidadesAplicacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.aplicacion
{
    public interface IcrudTcDomain
    {
        GenericResponse<int> SaveTCDomain(TipoCambioAplicacion tcRequestSave);
        GenericResponse<int> UpdateTCDomain(TipoCambioAplicacion tcRequestSave);
        GenericResponse<int> DeleteTCDomain(TipoCambioAplicacion tcRequestSave); 
        GenericResponse<IEnumerable<TipoCambioAplicacion>> ListTCDomain(int iMes, int iAnio);
    }
}
