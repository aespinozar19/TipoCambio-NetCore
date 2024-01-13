using Dapper;
using EntidadesBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace TC.PERSISTENCIA
{
    public class tcConversion : ItcConversion
    {
        private readonly string _ConexionDB;
        public tcConversion(string dbConexion) => _ConexionDB = dbConexion;

        public ConversionTC ConversionMonedaTC( int monedaOrigen, int monedaDestino,
            decimal monto ,DateTime fecha , int clientePreferencial,
            ref string validacionConversion ,ref string messageException)
        {
            ConversionTC responseConversion = new ConversionTC();
            using (var connection = new SqlConnection(_ConexionDB))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                try
                {
                    parameters.Add("@MonedaOrigen", value: monedaOrigen, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameters.Add("@MonedaDestino", value: monedaDestino, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    parameters.Add("@MontoOrigen", value: monto, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    parameters.Add("@FechaTC", value: fecha, dbType: DbType.DateTime, direction: ParameterDirection.Input);

                    parameters.Add("@ClientePreferencial", value: clientePreferencial, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    parameters.Add("@Mensaje", value: string.Empty, dbType: DbType.String, direction: ParameterDirection.InputOutput);



                    responseConversion = connection.QueryFirst<ConversionTC>("SP_BUSCAR_TC_ORIGEN_DESTINO", param: parameters, commandTimeout: 10, commandType: CommandType.StoredProcedure);

                    validacionConversion = parameters.Get<string>("@Mensaje");
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
            return responseConversion;
        }
    }
}
