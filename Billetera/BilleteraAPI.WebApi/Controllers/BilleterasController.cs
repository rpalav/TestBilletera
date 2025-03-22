using BilleteraAPI.Application.Commands;
using BilleteraAPI.Application.Dtos;
using BilleteraAPI.Application.Queries;
using BilleteraAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    }
}
