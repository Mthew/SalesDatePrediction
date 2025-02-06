using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Feature.Product.Queries.GetAll;
using SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll;
using System.Net;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllProductVM>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMessage()
        {
            var response = await _mediator.Send(new GetAllProductQuery());
            return Ok(response);
        }
    }
}
