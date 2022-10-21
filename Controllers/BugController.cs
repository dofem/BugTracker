using AutoMapper;
using BugTracker.AddRequest;
using BugTracker.DTO;
using BugTracker.Interface;
using BugTracker.Models;
using BugTracker.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BugController : ControllerBase
    {
        private IBugRepository _bugRepository;
        private IMapper _mapper;

        public BugController(IBugRepository bugRepository, IMapper mapper)
        {
            _bugRepository = bugRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBugsAsync()
        {
            var bugs = await _bugRepository.GetAllBugsAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bugdto = _mapper.Map<ICollection<BugDto>>(bugs);
            return Ok(bugdto);
        }

        [HttpGet("bugId")]
        [ActionName("GetBugByIdAsync")]
        public async Task<IActionResult> GetBugByIdAsync(int bugId)
        {
            if (!await _bugRepository.BugExistsAsync(bugId))
                return NotFound();

            var bug = await _bugRepository.GetBugByIdAsync(bugId);
            if (!ModelState.IsValid && bug != null)
                return BadRequest(ModelState);
            var bugDto = _mapper.Map<Bug>(bug);
            return Ok(bugDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBugAsync(AddBugRequest addBugRequest)
        {   if(!ValidateCreateBugAsync(addBugRequest))
            {
                return BadRequest();
            }
            var bug = new Bug()
            {
                Title = addBugRequest.Title,
                Description = addBugRequest.Description,
                Status = addBugRequest.Status,
                Severity = addBugRequest.Severity,
                DateCreated = addBugRequest.DateCreated,
                UserId = addBugRequest.UserId,
                ChannelId = addBugRequest.ChannelId
            };

            bug = await _bugRepository.CreateBugAsync(bug);
            var bugdto = _mapper.Map<BugDto>(bug);
            bugdto.Title = addBugRequest.Title;
            bugdto.Description = addBugRequest.Description;
            bugdto.Status = addBugRequest.Status;
            bugdto.Severity = addBugRequest.Severity;
            bugdto.DateCreated = addBugRequest.DateCreated;
            bugdto.UserId = addBugRequest.UserId;
            bugdto.ChannelId = addBugRequest.ChannelId;

            return CreatedAtAction(nameof(GetBugByIdAsync), new { id = bugdto.Id }, bugdto);
        }

        [HttpDelete("bugId")]
        public async Task<IActionResult> DeleteBugAsync(int bugId)
        {
            if (!await _bugRepository.BugExistsAsync(bugId))
                return NotFound();

            var bug = await _bugRepository.DeleteBugAsync(bugId);
            if (bug == null)
                return null;
            var bugDto = _mapper.Map<BugDto>(bug);
            return Ok(bugDto);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateBugAsync(int bugId, UpdateBugRequest updateBugRequest)
        {   if (!ValidateUpdateBugAsync(updateBugRequest))
            {
                return BadRequest();
            }
            if (!await _bugRepository.BugExistsAsync(bugId))
                return NotFound(bugId);

            var bug = new Bug()
            {
                Title = updateBugRequest.Title,
                Description = updateBugRequest.Description,
                Status = updateBugRequest.Status,
                Severity = updateBugRequest.Severity,
                DateCreated = updateBugRequest.DateCreated,
                UserId = updateBugRequest.UserId,
                ChannelId = updateBugRequest.ChannelId,
            };
            bug = await _bugRepository.UpdateBugAsync(bugId, bug);

            var bugDto = _mapper.Map<BugDto>(bug);
            return Ok(bugDto);

        }

        //VAlidation for Bugs Creation
        private bool ValidateCreateBugAsync(AddBugRequest addBugRequest)
        {
            if (addBugRequest == null)
            {
                ModelState.AddModelError(nameof(addBugRequest), $"Kindly fill up the entire field");
                return false;
            }

            if (string.IsNullOrEmpty(addBugRequest.Title))
            {
                ModelState.AddModelError(nameof(addBugRequest.Title), $"{nameof(addBugRequest.Title)} cannot be empty or null");
                
            }

            if (string.IsNullOrEmpty(addBugRequest.Description))
            {
                ModelState.AddModelError(nameof(addBugRequest.Description), $"{nameof(addBugRequest.Description)} cannot be empty or null");
                
            }

            if (string.IsNullOrEmpty(addBugRequest.Severity))
            {
                ModelState.AddModelError(nameof(addBugRequest.Severity), $"{nameof(addBugRequest.Severity)} cannot be empty or null");
                
            }

            if (string.IsNullOrEmpty(addBugRequest.Status))
            {
                ModelState.AddModelError(nameof(addBugRequest.Status), $"{nameof(addBugRequest.Status)} cannot be empty or null");
                
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
                return true;
        }

        //VAlidation for Bugs Creation
        private bool ValidateUpdateBugAsync(UpdateBugRequest updateBugRequest)
        {
            if (updateBugRequest == null)
            {
                ModelState.AddModelError(nameof(updateBugRequest), $"Kindly fill up the entire field");
                return false;
            }

            if (string.IsNullOrEmpty(updateBugRequest.Title))
            {
                ModelState.AddModelError(nameof(updateBugRequest.Title), $"{nameof(updateBugRequest.Title)} cannot be empty or null");

            }

            if (string.IsNullOrEmpty(updateBugRequest.Description))
            {
                ModelState.AddModelError(nameof(updateBugRequest.Description), $"{nameof(updateBugRequest.Description)} cannot be empty or null");

            }

            if (string.IsNullOrEmpty(updateBugRequest.Severity))
            {
                ModelState.AddModelError(nameof(updateBugRequest.Severity), $"{nameof(updateBugRequest.Severity)} cannot be empty or null");

            }

            if (string.IsNullOrEmpty(updateBugRequest.Status))
            {
                ModelState.AddModelError(nameof(updateBugRequest.Status), $"{nameof(updateBugRequest.Status)} cannot be empty or null");

            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }

    }
    }
