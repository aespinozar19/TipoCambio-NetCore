using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.Swagger
{

    public class SwaggerConfiguration
    {
        public const string RouterTemplate = EndpointDescription + "/swagger/{documentName}/swagger.json";
        public const string EndpointDescription = "Servicios TC";
        public const string EndpointUrl = "/swagger/v1/swagger.json";
        public const string ContactName = "Anthony E.";
        public const string ContactUrl = "anthonyespinozarivera.com";
        public const string DocNameV1 = "v1";
        public const string DocInfoTitle = "TIPO DE CAMBIO";
        public const string DocInfoVersion = "v1";
        public const string DocInfoDescription = "TC - TIPO CAMBIO";
    }
}
