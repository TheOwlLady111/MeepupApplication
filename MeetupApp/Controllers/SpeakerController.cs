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
    [Authorize(Policy = Policy.ForAdminOnly)]
    public class SpeakerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISpeakerService<int> _speakerService;

        public SpeakerController(IMapper mapper, ISpeakerService<int> speakerService)
        {
            _mapper = mapper;
            _speakerService = speakerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpeakers()
        {
            var speakers = await _speakerService.GetAllAsync();
            var speakersResult = _mapper.Map<List<SpeakerModel>, List<SpeakerResponse>>(speakers);
            return Ok(speakersResult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSpeaker([FromRoute] int id)
        {
            var speaker = await _speakerService.GetAsync(id);
            var speakerResult = _mapper.Map<SpeakerModel, SpeakerResponse>(speaker);
            return Ok(speakerResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSpeaker([FromRoute] int id, [FromBody] SpeakerRequest speakerRequest)
        {
            var speaker = _mapper.Map<SpeakerRequest, SpeakerModel>(speakerRequest);
            await _speakerService.UpdateAsync(id, speaker);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpeaker([FromBody] SpeakerRequest speakerRequest)
        {
            var speaker = _mapper.Map<SpeakerRequest, SpeakerModel>(speakerRequest);
            await _speakerService.CreateAsync(speaker);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSpeaker([FromRoute] int id)
        {
            await _speakerService.DeleteAsync(id);
            return Ok();
        }


    }
}
