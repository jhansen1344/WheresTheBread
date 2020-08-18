using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Post(SubActivityCreateDto subActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid subactivity");
            }
            var result = await _subActivityService.CreateSubActivityAsync(subActivity);
            if (result)
            {
                return Ok("Item Created Successfully");
            }

            throw new System.Exception("Creating the subactivity failed on save");
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var subActivityList = await _subActivityService.GetSubActivitiesAsync();
            return Ok(subActivityList);
        }

        [HttpGet("{id}", Name = "GetSubActivity")]
        public async Task<IActionResult> GetSubActivity(int userId, int id)
        {
            var subActivity = await _subActivityService.GetSubActivityByIdAsync(id);

            if (subActivity == null)
                return NotFound();
            return Ok(subActivity);
        }

        [HttpPut("{id}", Name = "EditSubActivity")]
        public async Task<IActionResult> EditSubActivity(SubActivityUpdateDto subActivityUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid subactivity");
            }
            var result = await _subActivityService.UpdateSubActivityAsync(subActivityUpdate);
            if (result)
            {
                return Ok("Subactivity Created Successfully");
            }

            throw new System.Exception("Creating the subactivity failed on save");
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> DeleteSubActivity(int id)
        {
            if (await _subActivityService.DeleteSubActivityAsync(id))
                return NoContent();

            throw new System.Exception("Error deleting the subactivity");
        }
    }
}