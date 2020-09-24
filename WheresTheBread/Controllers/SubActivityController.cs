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


        public SubActivityController(ISubActivityService service)
        {
            _subActivityService = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string userId, SubActivityCreateDto subActivity)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid subactivity");
            }
            var result = await _subActivityService.CreateSubActivityAsync(userId, subActivity);
            if (result)
            {
                return Ok("Item Created Successfully");
            }

            throw new System.Exception("Creating the subactivity failed on save");
        }

        [HttpGet]

        public async Task<IActionResult> Get(string userId)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();
            var subActivityList = await _subActivityService.GetSubActivitiesAsync(userId);
            return Ok(subActivityList);
        }

        [HttpGet("{id}", Name = "GetSubActivity")]
        public async Task<IActionResult> GetSubActivity(string userId, int id)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();
            var subActivity = await _subActivityService.GetSubActivityByIdAsync(userId, id);

            if (subActivity == null)
                return NotFound();
            return Ok(subActivity);
        }

        [HttpPut("{id}", Name = "EditSubActivity")]
        public async Task<IActionResult> EditSubActivity(string userId, int id, SubActivityUpdateDto subActivityUpdate)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid subactivity");
            }

            if(id != subActivityUpdate.Id)
            {
                return BadRequest("Unable to update subactivity");
            }
            var result = await _subActivityService.UpdateSubActivityAsync(userId, subActivityUpdate);
            if (result)
            {
                return Ok("Subactivity Created Successfully");
            }

            throw new System.Exception("Creating the subactivity failed on save");
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> DeleteSubActivity(string userId, int id)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();
            if (await _subActivityService.DeleteSubActivityAsync(userId, id))
                return NoContent();

            throw new System.Exception("Error deleting the subactivity");
        }
    }
}