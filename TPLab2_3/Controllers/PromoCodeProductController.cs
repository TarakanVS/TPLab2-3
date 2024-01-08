using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Stories.ProductStories;
using Services.Stories.PromoCodeProductStories;

namespace TPLab2_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeProductController : Controller
    {
        private readonly IMediator _mediator;

        public PromoCodeProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PromoCodeProduct), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreatePromoCodeProductStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdatePromoCodeProductStory story)
        {
            var response = await _mediator.Send(story);

            return Ok();
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetPromoCodeProductByIdStory story)
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
        public async Task<IActionResult> Delete([FromRoute] DeletePromoCodeProductStory story)
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
