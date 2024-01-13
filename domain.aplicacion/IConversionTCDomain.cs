using EntidadesAplicacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace domain.aplicacion
{
    public interface IConversionTCDomain
    {
        GenericResponse<ConversionTCApp> ConversionTcDomain(reqConversionTC reqConversion);
    }
}
