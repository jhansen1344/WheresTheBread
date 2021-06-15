using System;
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
        private string _userId;

        public ItemController(IItemService service)
        {
            _itemService = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItemCreateDto item)
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid item");
            }
            var result = await _itemService.CreateItemAsync(_userId, item);
            if(result)
            {
                return Ok("Item Created Successfully");
            }

            throw new System.Exception("Creating the item failed on save");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var itemList = await _itemService.GetItemsAsync(_userId);
            return Ok(itemList);
        }

        [HttpGet("{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int id)
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var item = await _itemService.GetItemByIdAsync(_userId, id);

            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPut("{id}", Name = "EditItem")]
        public async Task<IActionResult> EditItem(ItemUpdateDto itemUpdate)
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid item");
            }
            var result = await _itemService.UpdateItemAsync(_userId, itemUpdate);
            if (result)
            {
                return NoContent();
            }

            throw new System.Exception("Creating the item failed on save");
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> DeleteItem(int id)
        {
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (await _itemService.DeleteItemAsync(_userId, id))
                return NoContent();

            throw new System.Exception("Error deleting the item");
        }
    }
}