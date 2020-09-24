using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WheresTheBread.DTO.ItemDto;
using WheresTheBread.Services;

namespace WheresTheBread.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        

        public ItemController(IItemService service)
        {
            _itemService = service;
        }


        [HttpPost]
        public async Task<IActionResult> Post(string userId, ItemCreateDto item)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid item");
            }
            var result = await _itemService.CreateItemAsync(userId, item);
            if(result)
            {
                return Ok("Item Created Successfully");
            }

            throw new System.Exception("Creating the item failed on save");
        }

        [HttpGet]

        public async Task<IActionResult> Get(string userId)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();

            var itemList = await _itemService.GetItemsAsync(userId);
            return Ok(itemList);
        }

        [HttpGet("{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(string userId, int id)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();
            var item = await _itemService.GetItemByIdAsync(userId, id);

            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPut("{id}", Name = "EditItem")]
        public async Task<IActionResult> EditItem(string userId, ItemUpdateDto itemUpdate)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid item");
            }
            var result = await _itemService.UpdateItemAsync(userId, itemUpdate);
            if (result)
            {
                return Ok("Item Created Successfully");
            }

            throw new System.Exception("Creating the item failed on save");
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> DeleteItem(string userId, int id)
        {
            if (userId != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                return Unauthorized();
            if (await _itemService.DeleteItemAsync(userId, id))
                return NoContent();

            throw new System.Exception("Error deleting the item");
        }

        
    }
}