using System;
using TC.PERSISTENCIA;
using EntidadesAplicacion;
using EntidadesBD;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace domain.aplicacion
{
    public class crudTcDomain : IcrudTcDomain
    {
        public ITCCrud _ItcCrud { get; private set; }
        string messageException = string.Empty;
        public crudTcDomain(string CadenaConexion)
        {
            _ItcCrud = new tcCrud(CadenaConexion);
        }

        public GenericResponse<int> SaveTCDomain(TipoCambioAplicacion tcRequestSave)
        {
            GenericResponse<int> responseSaveTC = new GenericResponse<int>();
            messageException = string.Empty;
            TipoCambioEntidad modelTCDatabase = modeloRetornoApxDB(tcRequestSave);
            responseSaveTC.data = _ItcCrud.tcSaveService(modelTCDatabase, ref messageException);
            responseSaveTC.Success = responseSaveTC.data == 0 ? false : true;
            responseSaveTC.message = messageException;
            return responseSaveTC;
        }

        public GenericResponse<int> UpdateTCDomain(TipoCambioAplicacion tcRequestSave)
        {
            GenericResponse<int> responseUpdateTC = new GenericResponse<int>();
            messageException = string.Empty;
            TipoCambioEntidad modelTCDatabase = modeloRetornoApxDB(tcRequestSave);
            responseUpdateTC.Success = _ItcCrud.tcUpdateService(modelTCDatabase, ref messageException);
            responseUpdateTC.message = messageException;
            return responseUpdateTC;
        }

        public GenericResponse<int> DeleteTCDomain(TipoCambioAplicacion tcRequestSave)
        {
            GenericResponse<int> responseDeleteTC = new GenericResponse<int>();
            messageException = string.Empty;
            TipoCambioEntidad modelTCDatabase = modeloRetornoApxDB(tcRequestSave);
            responseDeleteTC.Success = _ItcCrud.tcDeleteService(modelTCDatabase, ref messageException);
            responseDeleteTC.message = messageException;
            return responseDeleteTC;
        }

        public GenericResponse<IEnumerable<TipoCambioAplicacion>> ListTCDomain(int iMes, int iAnio)
        {
            GenericResponse<IEnumerable<TipoCambioAplicacion>> responseListTC = new GenericResponse<IEnumerable<TipoCambioAplicacion>>();
            messageException = string.Empty;

            IEnumerable<TipoCambioEntidad> responseILBd = _ItcCrud.getListaTcxMoneda(iMes, iAnio, ref messageException);
            responseListTC.data = modeloListaAplicacion(responseILBd);
            responseListTC.Success = string.IsNullOrEmpty(messageException) ? true : false;
            responseListTC.message = messageException;
            return responseListTC;
        }

        #region modelo
        IEnumerable<TipoCambioAplicacion> modeloListaAplicacion(IEnumerable<TipoCambioEntidad> listaBD)
        {
            List<TipoCambioAplicacion> newListaApp = new List<TipoCambioAplicacion>();
            foreach (TipoCambioEntidad entidad in listaBD)
            {
                newListaApp.Add(new TipoCambioAplicacion()
                {
                    moneda = entidad.iIdMoneda,
                    valorCompra = entidad.dcValorCompra,
                    valorVenta = entidad.dcValorVenta,
                    dia = entidad.iDia,
                    mes = entidad.iMes,
                    anio = entidad.iAnio,
                    fechaTipoCambio = entidad.dFechaTC,
                    usuario = null
                }) ;
            }
            return newListaApp;
        }
        TipoCambioEntidad modeloRetornoApxDB(TipoCambioAplicacion reqTipoCambioap)
        {
            TipoCambioEntidad newmodelDB = new TipoCambioEntidad();
            newmodelDB.iIdMoneda = reqTipoCambioap.moneda;
            newmodelDB.dcValorCompra = reqTipoCambioap.valorCompra;
            newmodelDB.dcValorVenta = reqTipoCambioap.valorVenta;
            newmodelDB.dFechaTC = reqTipoCambioap.fechaTipoCambio;
            newmodelDB.vUsuarioRegistro = reqTipoCambioap.usuario;

            newmodelDB.dFechaTC = reqTipoCambioap.fechaTipoCambio;
            newmodelDB.vUsuarioActualiza = reqTipoCambioap.usuario;
            newmodelDB.vUsuarioElimina = reqTipoCambioap.usuario;
            return newmodelDB;
        }
        #endregion
    }
}
