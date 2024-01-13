using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAplicacion
{
    public class ConversionTCApp
    { 
        //public TipoCambioAplicacion() { }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal MontoOrigen { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MonedaOrigen { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MonedaDestino { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime FechaTipoCambio { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal MontoDestino { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal TipoCambioCompra { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal TipoCambioVenta { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ClientePreferencial { get; set; }

    }
}
