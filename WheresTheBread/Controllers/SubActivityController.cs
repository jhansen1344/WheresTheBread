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
                return BadRequest("Please submit a valid SubActivity");
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

        [HttpGet("{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int userId, int id)
        {
            var item = await _subActivityService.(id);

            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPut("{id}", Name = "EditItem")]
        public async Task<IActionResult> EditItem(SubActivityUpdateDto itemUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid item");
            }
            var result = await _subActivityService.UpdateItemAsync(itemUpdate);
            if (result)
            {
                return Ok("Item Created Successfully");
            }

            throw new System.Exception("Creating the message failed on save");
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> DeleteItem(int id)
        {
            if (await _subActivityService.DeleteItemAsync(id))
                return NoContent();

            throw new System.Exception("Error deleting the message");
        }
    }
}