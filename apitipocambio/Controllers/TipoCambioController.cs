using domain.aplicacion;
using EntidadesAplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace apitipocambio.Controllers
{
    public class TipoCambioController : BaseController
    {
        private readonly IcrudTcDomain _IcrudTcDomain;
        public TipoCambioController(IcrudTcDomain IcrudTcDomain)
        {
            _IcrudTcDomain = IcrudTcDomain;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<int>), (int)HttpStatusCode.OK)]
        public IActionResult GuardarTipoCambio([FromBody] TipoCambioAplicacion req)
        {
            
            return Ok(_IcrudTcDomain.SaveTCDomain(req));
        }

        [HttpPut]
        [ProducesResponseType(typeof(GenericResponse<int>), (int)HttpStatusCode.OK)]
        public IActionResult EditarTipoCambio([FromBody] TipoCambioAplicacion req)
        {
            return Ok(_IcrudTcDomain.UpdateTCDomain(req));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(GenericResponse<int>), (int)HttpStatusCode.OK)]
        public IActionResult EliminarTipoCambio([FromBody] TipoCambioAplicacion req)
        {
            return Ok(_IcrudTcDomain.DeleteTCDomain(req));
        }

        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<IEnumerable<TipoCambioAplicacion>>), (int)HttpStatusCode.OK)]
        public IActionResult ListTipoCambio(int anio, int mes)
        {
            return Ok(_IcrudTcDomain.ListTCDomain(mes,anio));            
        }

    }
}
