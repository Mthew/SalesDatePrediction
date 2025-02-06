using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Feature.Shipper.Queries.GetAll;
using SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll;
using System.Net;

namespace SalesDatePrediction.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipperController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ShipperController> _logger;

        public ShipperController(ILogger<ShipperController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllShipperVM>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMessage()
        {
            var response = await _mediator.Send(new GetAllShipperQuery());
            return Ok(response);
        }
    }
}
