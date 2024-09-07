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
        public FeeController(FeeService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> InsertFeeDataAsync()
        {
            BaseResponse<Fee> resp = await _service.PopulateFeeDbAsync();

            if (resp.Errors.Count > 0) {
                return StatusCode(500, resp);
            }

            return Ok(resp);
        }
    }
}
