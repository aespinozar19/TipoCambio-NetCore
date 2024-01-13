using domain.aplicacion;
using EntidadesAplicacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace apitipocambio.Controllers
{
  
    public class ConversionController : BaseController
    {
        private readonly IConversionTCDomain _IConversionTCDomain;
        public ConversionController(IConversionTCDomain IConversionTCDomain)
        {
            _IConversionTCDomain = IConversionTCDomain;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<ConversionTCApp>), (int)HttpStatusCode.OK)]
        public IActionResult ConvertirMoneda([FromBody] reqConversionTC reqConversion)
        {

            return Ok(_IConversionTCDomain.ConversionTcDomain(reqConversion));
        }
    }
}
