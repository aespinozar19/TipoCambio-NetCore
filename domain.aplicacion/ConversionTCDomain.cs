using EntidadesAplicacion;
using EntidadesBD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TC.PERSISTENCIA;

namespace domain.aplicacion
{
    public class ConversionTCDomain : IConversionTCDomain
    {
        public ItcConversion _ItcConversion { get; private set; }
        string messageException = string.Empty;
        public ConversionTCDomain(string CadenaConexion)
        {
            _ItcConversion = new tcConversion(CadenaConexion);
        }

        //public GenericResponse<ConversionTCApp> ConversionTcDomain(reqConversionTC reqConversion)
        //{
        //    GenericResponse<ConversionTCApp> responseConversion = new GenericResponse<ConversionTCApp>();
        //    messageException = string.Empty;
        //    string validacionConversion = string.Empty;
        //    ConversionTC responseConversionTC = _ItcConversion.ConversionMonedaTC(reqConversion.MonedaOrigen , reqConversion.MonedaDestino,            reqConversion.MontoOrigen, reqConversion.FechaTC,            ref  validacionConversion,ref messageException);
        //    responseConversion.Success = StatusConversion(validacionConversion,messageException);
        //    responseConversion.message = MesageConversion(validacionConversion, messageException);
        //    responseConversion.data = ModelConversionTC(responseConversionTC);
        //    return responseConversion;
        //}

        public GenericResponse<ConversionTCApp> ConversionTcDomain(reqConversionTC reqConversion)
        {
            GenericResponse<ConversionTCApp> responseConversion = new GenericResponse<ConversionTCApp>();
            messageException = string.Empty;
            string validacionConversion = string.Empty;
            ConversionTC responseConversionTC = _ItcConversion.ConversionMonedaTC(reqConversion.MonedaOrigen, reqConversion.MonedaDestino, reqConversion.MontoOrigen, reqConversion.FechaTC, reqConversion.ClientePreferencial, ref validacionConversion, ref messageException);
            responseConversion.Success = StatusConversion(validacionConversion, messageException);
            responseConversion.message = MesageConversion(validacionConversion, messageException);
            responseConversion.data = ModelConversionTC(responseConversionTC);
            return responseConversion;
        }
        private ConversionTCApp ModelConversionTC(ConversionTC reqConversionBD)
        {
            ConversionTCApp newMOdelConversion = new ConversionTCApp();

            newMOdelConversion.MontoOrigen = reqConversionBD.MontoOrigen;
            newMOdelConversion.MonedaOrigen = reqConversionBD.MonedaOrigen;
            newMOdelConversion.MonedaDestino = reqConversionBD.MonedaDestino;
            newMOdelConversion.FechaTipoCambio = reqConversionBD.FechaTipoCambio;
                newMOdelConversion.MontoDestino = reqConversionBD.MontoDestino;
            newMOdelConversion.TipoCambioCompra = reqConversionBD.TipoCambioCompra;
                 newMOdelConversion.TipoCambioVenta = reqConversionBD.TipoCambioVenta;

            newMOdelConversion.ClientePreferencial = reqConversionBD.ClientePreferencial;



            return newMOdelConversion;
        }


        private string MesageConversion(string validacion, string excepcion)
        {
            if (!string.IsNullOrEmpty(excepcion)) return excepcion;
            if (!string.IsNullOrEmpty(validacion)) return validacion;
            return string.Empty;
        }
        private bool StatusConversion(string validacion , string excepcion)
        {
            int validacionResponse = string.IsNullOrEmpty(validacion) ? 0 : 1;
            validacionResponse+= string.IsNullOrEmpty(excepcion) ? 0 : 1;

            return validacionResponse ==0 ? true : false;
        }
    }
}
