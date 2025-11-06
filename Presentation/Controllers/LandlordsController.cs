using Business.Application.Landlords;
using Business.Application.Landlords.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Landlords;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class LandlordsController : ControllerBase
    {
        private readonly ILandlordService _landlordService;

        public LandlordsController(ILandlordService s) 
        {
            _landlordService = s;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddLandlordRequest req)
        {
           
            var result = await _landlordService.AddAsync(req.ToCommand());
            if(!result.IsSuccess)
            {
                return BadRequest(result.Error.Message);
            }

            return CreatedAtAction(nameof(GetById), new {id= result.Value }, new {id= result.Value});
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _landlordService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                switch(result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
            }

            return Ok(result.Value);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UpdateLandlordRequest req)
        {

            var result = await _landlordService.UpdateAsync(req.ToCommand(id));
            if (!result.IsSuccess)
            {
                switch (result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
            }
            return Ok(result.Value);
        }
    }
}





