using AutoMapper;
using BugTracker.AddRequest;
using BugTracker.DTO;
using BugTracker.Interface;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChannelController : Controller
    {
        private IChannelRepository _channelRepository;
        private IMapper _mapper;

        public ChannelController(IChannelRepository channelRepository,IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(ICollection<Channel>))]
        public async Task<IActionResult> GetAllPlatform()
        {
            var channels = await _channelRepository.GetAllChannelsAsync();          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var channeldto = _mapper.Map<ICollection<ChannelDto>>(channels);
            return Ok(channeldto);
        }


        [HttpGet("channelId")]
        [ActionName("GetChannelByIdAsync")]
        public async Task<IActionResult> GetChannelByIdAsync(int channelId)
        {
            if (! await _channelRepository.channelExistsAsync(channelId))
                return NotFound();

            var channel = await _channelRepository.GetChannelByIdAsync(channelId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var channelDto = _mapper.Map<ChannelDto>(channel);
            return Ok(channelDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChannelAsync(AddChannelRequest addChannelRequest)
        {   if(!ValidateCreateChannelAsync(addChannelRequest))
            {
                return BadRequest();
            }
            var channel = new Channel()
            {
                Name = addChannelRequest.Name,
            };
            channel = await _channelRepository.CreateChannelAsync(channel); 
            var channelDto = _mapper.Map<ChannelDto>(channel);
            channelDto.Name = addChannelRequest.Name;
            return CreatedAtAction(nameof(GetChannelByIdAsync),new{ id = channelDto.ChannelId },channelDto);

        }


        [HttpDelete("channelId")]
        public async Task<IActionResult> DeleteChannelAsync(int channelId)
        {
            if (!await _channelRepository.channelExistsAsync(channelId))
                return NotFound();

            var channel = await _channelRepository.DeleteChannelAsync(channelId);
            if (channel == null)
                return null;
            var channelDto = _mapper.Map<ChannelDto>(channel);
            return Ok(channelDto);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateChannelAsync(int channelId,UpdateChannelRequest updateChannelRequest)
        {   if (ValidateCreateChannelAsync(updateChannelRequest))
            {
                return BadRequest();
            }
           if(!await _channelRepository.channelExistsAsync(channelId))
                return NotFound(channelId);

            var channel = new Channel()
            {
                Name = updateChannelRequest.Name,
            };
            channel = await _channelRepository.UpdateChannelAsync(channelId, channel);

            var channelDto = _mapper.Map<ChannelDto>(channel);
            return Ok(channelDto);

        }

        //Validation
        private bool ValidateCreateChannelAsync(AddChannelRequest addChannelRequest)
        {
            if (addChannelRequest == null)
            { 
                ModelState.AddModelError(nameof(addChannelRequest), $"{addChannelRequest} cannot be empty or null");
                return false;
            }
            if (string.IsNullOrEmpty(addChannelRequest.Name))
            { 
                ModelState.AddModelError(nameof(addChannelRequest.Name), $"The name space cannot be empty");
            }
            if(ModelState.ErrorCount >0)
            {
                return false;
            }
            return true;
        }

        private bool ValidateCreateChannelAsync(UpdateChannelRequest updateChannelRequest)
        {
            if (updateChannelRequest == null)
            {
                ModelState.AddModelError(nameof(updateChannelRequest), $"{updateChannelRequest} cannot be empty or null");
                return false;
            }
            if (string.IsNullOrEmpty(updateChannelRequest.Name))
            {
                ModelState.AddModelError(nameof(updateChannelRequest.Name), $"The name space cannot be empty");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }

    }
}
