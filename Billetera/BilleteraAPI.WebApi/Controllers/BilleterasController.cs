using BilleteraAPI.Application.Commands;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BilleteraAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleterasController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddBilleteraAsync([FromBody] BilleteraDto billetera) 
        {
            var result = await sender.Send(new AddBilleteraCommand(billetera));
            return Ok(result);
        }

        [HttpGet("Billeteras")]
        public async Task<IActionResult> GetAllBilleterasAsync()
        {
            var result = await sender.Send(new GetAllBilleteraQuery());
            return Ok(result);
        }

        [HttpGet("Billeteras/{idBilletera}")]
        public async Task<IActionResult> GetBilleteraByIdAsync([FromRoute] int idBilletera)
        {
            var result = await sender.Send(new GetAllBilleteraByIdQuery(idBilletera));
            return Ok(result);
        }

        [HttpPut("Billeteras/{idBilletera}")]
        public async Task<IActionResult> UpdateBilleteraAsync([FromRoute] int idBilletera, [FromBody] BilleteraDto billetera)
        {
            var result = await sender.Send(new UpdateBilleteraCommand(idBilletera, billetera));
            return Ok(result);
        }


        [HttpDelete("Billeteras/{idBilletera}")]
        public async Task<IActionResult> DeleteBilleteraAsync([FromRoute] int idBilletera)
        {
            var result = await sender.Send(new DeleteBilleteraCommand(idBilletera));
            return Ok(result);
        }
    }
}
