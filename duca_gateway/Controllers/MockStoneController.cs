using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using duca_gateway.Mocks.StoneDc;
using System.Net;

namespace duca_gateway.Controllers
{
    [Route("api/[controller]")]
    public class MockStoneController : Controller
    {
        [HttpPost]
        public IActionResult addTransactionStone([FromBody] Stone stn)
        {
            if (stn == null)
            {
                return BadRequest();
            }

            if (stn.MerchantKey == "" || stn.MerchantKey == null)
            {
                ErrorReport er = new ErrorReport();
                er.Category = "Key Invalida";
                ErrorItemCollection[] eic = new ErrorItemCollection[1];
                eic[0] = new ErrorItemCollection();
                eic[0].Description = "Chave de utilização inválida";
                eic[0].ErrorCode = 1;
                eic[0].ErrorField = "Merchant-Key";
                er.ErrorItemCollection = eic;

                stn.ErrorReport = er;
                return new ObjectResult(stn);
            }


            return CreatedAtRoute("GetTransacaoStone", new {trans = stn }, stn);
        }

        [HttpGet("{trans}", Name = "GetTransacaoStone")]
        public IActionResult getId(Stone stn)
        {
            var a = stn;
            return new ObjectResult(stn);
        }
    }
}
