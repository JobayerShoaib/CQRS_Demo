using CQRS.Application.Common.Models;
using CQRS.Application.Features.Setups.Countries.Commands.Create;
using CQRS.Application.Features.Setups.Countries.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.WebApi.Controllers.Areas.Setups
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {

            }
            var result = await Mediator.Send(new GetCompanyByIdQuery { Id=id});
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Create([FromBody] CountryCreateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await Mediator.Send(command);
            return Ok();
        }
    }
}
