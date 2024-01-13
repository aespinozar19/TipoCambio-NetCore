using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using EntidadesBD;

namespace TC.PERSISTENCIA
{
    public class tcCrud : ITCCrud
    {
        private readonly string _ConexionDB;
        public tcCrud(string dbConexion) => _ConexionDB = dbConexion;

        public IEnumerable<TipoCambioEntidad> getListaTcxMoneda(int mes , int anio , ref string messageException)
        {
            IEnumerable<TipoCambioEntidad> resListatipoCambio = null;
            using (var connection = new SqlConnection(_ConexionDB))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                try
                {
                    parameters.Add("@MES", value: mes, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameters.Add("@ANIO", value: anio, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    resListatipoCambio= connection.Query<TipoCambioEntidad>("SP_LISTA_TC", param: parameters, commandTimeout: 10, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    messageException = ex.ToString();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }


            return resListatipoCambio;
        }

        public bool tcDeleteService(TipoCambioEntidad tcRequest, ref string messageException)
        {
            bool responseDeletetC = false;
            messageException = string.Empty;
            using (var connection = new SqlConnection(_ConexionDB))
            {
                connection.Open();
                var parameters = new DynamicParameters();

                try
                {
                    parameters.Add("@iIdMoneda", value: tcRequest.iIdMoneda, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameters.Add("@vUsuarioElimina", value: tcRequest.vUsuarioElimina, dbType: DbType.String, direction: ParameterDirection.Input);
                    parameters.Add("@dFechaTC", value: tcRequest.dFechaTC, dbType: DbType.DateTime, direction: ParameterDirection.Input);


                    var response = connection.Query<object>("SP_ELIMINA_TC", param: parameters, commandTimeout: 10, commandType: CommandType.StoredProcedure);
                    responseDeletetC = true;

                }
                catch (Exception ex)
                {
                    messageException = ex.ToString();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return responseDeletetC;
        }


        public bool tcUpdateService(TipoCambioEntidad tcRequest, ref string messageException)
        {
            bool responseIdTC = false;
            messageException = string.Empty;
            using (var connection = new SqlConnection(_ConexionDB))
            {
                connection.Open();
                var parameters = new DynamicParameters();

                try
                {
                    parameters.Add("@iIdMoneda", value: tcRequest.iIdMoneda, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameters.Add("@dcValorCompra", value: tcRequest.dcValorCompra, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    parameters.Add("@dcValorVenta", value: tcRequest.dcValorVenta, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    parameters.Add("@dFechaTC", value: tcRequest.dFechaTC, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    parameters.Add("@vUsuarioModifica", value: tcRequest.vUsuarioActualiza, dbType: DbType.String, direction: ParameterDirection.Input);

                    var response = connection.Query<object>("SP_ACTUALIZAR_TC", param: parameters, commandTimeout: 10, commandType: CommandType.StoredProcedure);
                    responseIdTC = true;

                }
                catch (Exception ex)
                {
                    messageException = ex.ToString();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return responseIdTC;
        }
        public int tcSaveService(TipoCambioEntidad tcRequest, ref string messageException)
        {
            int responseIdTC = 0;
            messageException = string.Empty;
            using (var connection = new SqlConnection(_ConexionDB))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                try
                {
                    parameters.Add("@iIdMoneda", value: tcRequest.iIdMoneda, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameters.Add("@dcValorCompra", value: tcRequest.dcValorCompra, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    parameters.Add("@dcValorVenta", value: tcRequest.dcValorVenta, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    parameters.Add("@dFechaTC", value: tcRequest.dFechaTC, dbType: DbType.DateTime, direction: ParameterDirection.Input);

                    parameters.Add("@vUsuarioRegistro", value: tcRequest.vUsuarioRegistro, dbType: DbType.String, direction: ParameterDirection.Input);

                    parameters.Add("@IdTC", value: 0, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);

                    var response = connection.Query<object>("SP_CREAR_TC", param: parameters, commandTimeout:10, commandType: CommandType.StoredProcedure);
                    responseIdTC =  parameters.Get<int>("@IdTC") ;

                }
                catch (Exception ex)
                {
                    messageException = ex.ToString();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return responseIdTC;
        }
    }
}
