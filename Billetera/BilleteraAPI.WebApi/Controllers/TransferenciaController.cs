using BilleteraAPI.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static BilleteraAPI.Application.Commands.TransferenciaBilleteraCommand;

namespace BilleteraAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> TransferBilleteraAsync([FromBody] TransferenciaDto transferencia)
        {
            var result = await sender.Send(new TransferirBilleteraCommand(transferencia));
            return Ok(result);
        }
    }
}
