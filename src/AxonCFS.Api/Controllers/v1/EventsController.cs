using System;
using System.Threading.Tasks;
using AxonCFS.Application.BindingModels;
using AxonCFS.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AxonCFS.Api.Controllers.v1
{
    /// <summary>
    /// Events controller.
    /// </summary>
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

        /// <summary>
        /// Get events by criteria.
        /// </summary>
        /// <param name="responder">Responder</param>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <param name="offset">Offset</param>
        /// <param name="limit">Limit</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEvents(
            string responder = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            int offset = 0,
            int limit = 20)
        {
            var result = await _eventService.GetEventByCriteria(GetUserId(), responder, fromDate, toDate, offset, limit);

            if (!result.Succeed)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }

        /// <summary>
        /// Create new event
        /// </summary>
        /// <param name="model">Create event binding model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEvent(PostEventBindingModel model)
        {
            var result = await _eventService.CreateEvent(GetUserId(), model);

            if (!result.Succeed)
                return BadRequest(result.Message);

            return Ok(result.Content);
        }
    }
}