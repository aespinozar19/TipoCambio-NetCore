using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAplicacion
{
    public class TipoCambioAplicacion
    {
        //public TipoCambioAplicacion() { }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int moneda { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal valorCompra { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal valorVenta { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int dia { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int mes { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int anio { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime fechaTipoCambio { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string usuario { get; set; }

    }
}
