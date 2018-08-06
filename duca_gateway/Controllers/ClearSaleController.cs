using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using duca_gateway.Mocks.ClearSale;
namespace duca_gateway.Controllers
{
    [Route("api/[controller]")]
    public class ClearSaleController : Controller
    {
        [HttpPost]
        public IActionResult validPayment([FromBody] Payment paym)
        {
            if (paym == null)
            {
                return BadRequest();
            }
            OrderStatus os = new OrderStatus();

            if (paym.CardEndNumber == "")
            {

                os.ID = "1";
                os.Status = "RPM";
                return new ObjectResult(os);
            }


            os.ID = "1";
            os.Status = "APA";
            return new ObjectResult(os);
        }

    }
}