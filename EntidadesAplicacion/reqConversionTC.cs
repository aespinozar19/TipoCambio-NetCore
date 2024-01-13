using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAplicacion
{
    public class reqConversionTC
    {        
        //public TipoCambioAplicacion() { }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal MontoOrigen { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int MonedaOrigen { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int MonedaDestino { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime FechaTC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ClientePreferencial { get; set; }


    }
}
