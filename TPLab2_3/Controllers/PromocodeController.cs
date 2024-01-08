using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Stories.PromoCodeStories;

namespace TPLab2_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : Controller
    {
        private readonly IMediator _mediator;

        public PromoCodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PromoCode), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreatePromoCodeStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdatePromoCodeStory story)
        {
            var response = await _mediator.Send(story);

            return Ok();
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PromoCode))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetPromoCodeByIdStory story)
        {
            var response = await _mediator.Send(story);

            if (response == null)
            {
                return NotFound("Object not found");
            }

            return Ok(response);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] DeletePromoCodeStory story)
        {
            var response = await _mediator.Send(story);

            if (response == null)
            {
                return NotFound("Object not found");
            }

            return Ok(response);
        }

    }
}
