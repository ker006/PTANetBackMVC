using Domain.Entities;
using Infrastructure.DTOs.Common;
using Infrastructure.DTOs.Fee;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics.Contracts;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeeController : ControllerBase
    {
        private readonly FeeService _service;
        private readonly ILogger<FeeController> _logger;

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> InsertFeeDataAsync()
        {
            _logger.LogInformation("Start population");
            BaseResponse<Fee> resp = await _service.PopulateFeeDb();

            if (resp == null) {
                resp = new BaseResponse<Fee>
                {
                    Errors = new List<string> { "Error - ActionsHistoricRequest object is null." },
                    Total = 0
                };

                return StatusCode(500, string.Join(Environment.NewLine, resp.Errors));
            }

            return Ok("Populated " + resp.Total + " Fees");
        }
    }
}
