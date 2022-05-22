using Microsoft.AspNetCore.Mvc;
using Tringle.Core.DTOs.ResponseDtos;

namespace Tringle.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseContoller : ControllerBase
    {
        [NonAction]
        public IActionResult CreateResult(NoContentResponseDto dto)
        {
            if (dto.StatusCode == 204) { return new ObjectResult(null) { StatusCode = dto.StatusCode }; }
            return new ObjectResult(dto) { StatusCode = dto.StatusCode };
        }

        [NonAction]
        public IActionResult CreateResult<T>(ContentResponseDto<T> dto)
        {
            if (dto.StatusCode == 204) { return new ObjectResult(null) { StatusCode = dto.StatusCode }; }
            return new ObjectResult(dto) { StatusCode = dto.StatusCode };
        }
    }
}
