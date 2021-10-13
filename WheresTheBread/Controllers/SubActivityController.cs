using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WheresTheBread.DTO.SubActivityDto;
using WheresTheBread.Services;

namespace WheresTheBread.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubActivityController : ControllerBase
    {
        private readonly ISubActivityService _subActivityService;
        private string _userId;

        public SubActivityController(ISubActivityService service)
        {
            _subActivityService = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubActivityCreateDto subActivity)
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid subactivity");
            }
            var result = await _subActivityService.CreateSubActivityAsync(_userId, subActivity);
            if (result)
            {
                return Ok();
            }

            throw new System.Exception("Creating the subactivity failed on save");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var subActivityList = await _subActivityService.GetSubActivitiesAsync(_userId);
            return Ok(subActivityList);
        }

        [HttpGet("{id}", Name = "GetSubActivity")]
        public async Task<IActionResult> GetSubActivity(int id)
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var subActivity = await _subActivityService.GetSubActivityByIdAsync(_userId, id);

            if (subActivity == null)
                return NotFound();
            return Ok(subActivity);
        }

        [HttpPut("{id}", Name = "EditSubActivity")]
        public async Task<IActionResult> EditSubActivity(int id, SubActivityUpdateDto subActivityUpdate)
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid subactivity");
            }

            if(id != subActivityUpdate.Id)
            {
                return BadRequest("Unable to update subactivity");
            }
            var result = await _subActivityService.UpdateSubActivityAsync(_userId, subActivityUpdate);
            if (result)
            {
                return NoContent();
            }

            throw new System.Exception("Creating the subactivity failed on save");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteSubActivity(int id)
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (await _subActivityService.DeleteSubActivityAsync(_userId, id))
                return NoContent();

            throw new System.Exception("Error deleting the subactivity");
        }
    }
}