using AutoMapper;
using Business.Additional;
using Business.Models;
using Business.Services;
using MeetupApp.Request;
using MeetupApp.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetupApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventService<int> _eventService;

        public EventController(IMapper mapper, IEventService<int> eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllAsync();
            var responses = _mapper.Map<List<EventModel>, List<EventResponse>>(events);
            return Ok(responses);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var eventModel = await _eventService.GetAsync(id);
            var response = _mapper.Map<EventModel, EventResponse>(eventModel);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = Policy.ForAdminOnly)]
        public async Task<IActionResult> CreateEvent([FromBody] EventRequest eventRequest)
        {
            var eventModel = _mapper.Map<EventRequest, EventModel>(eventRequest);
            await _eventService.CreateAsync(eventModel);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Policy = Policy.ForAdminOnly)]
        public async Task<IActionResult> UpdateEvent([FromRoute] int id, [FromBody] EventRequest eventRequest)
        {
            var eventModel = _mapper.Map<EventRequest, EventModel>(eventRequest);
            await _eventService.UpdateAsync(id, eventModel);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = Policy.ForAdminOnly)]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            await _eventService.DeleteAsync(id);
            return Ok();
        }
    }
}
