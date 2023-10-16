using ColorMixes.Infrastructure.Data;
using ColorMixesApi.Core.Helpers;
using ColorMixesApi.Core.Services;
using ColorMixesApi.Infrastructure.DTOs.Color;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ColorMixesApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("CreateColor")]
        public async Task<ActionResult<ServiceResponse<GetColorDto>>> CreateColor(CreateColorDto color)
        {
            var response = await _colorService.CreateColor(color);

            return Ok(response);
        }

        [HttpGet("GetColorByName")]
        public async Task<ActionResult<ServiceResponse<GetColorDto>>> GetColorByName(string name)
        {
            var response = await _colorService.GetColorByName(name);

            return Ok(response);
        }
    }
}
