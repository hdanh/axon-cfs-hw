using System.Threading.Tasks;
using AxonCFS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AxonCFS.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class EventsController : BaseApiController
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            return Ok(GetUserId());
        }
    }
}