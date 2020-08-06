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
        public async Task<IActionResult> Post(ItemCreateDto item)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid item");
            }
            var result = await _itemService.CreateItemAsync(item);
            if(result)
            {
                return Ok("Item Created Successfully");
            }

            throw new System.Exception("Creating the message failed on save");
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var itemList = await _itemService.GetItemsAsync();
            return Ok(itemList);
        }

        [HttpGet("{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int userId, int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);

            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPut("{id}", Name = "EditItem")]
        public async Task<IActionResult> EditItem(ItemUpdateDto itemUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please submit a valid item");
            }
            var result = await _itemService.UpdateItemAsync(itemUpdate);
            if (result)
            {
                return Ok("Item Created Successfully");
            }

            throw new System.Exception("Creating the message failed on save");
        }

        [HttpPost("{id}")]

        public async Task<IActionResult> DeleteItem(int id)
        {
            if (await _itemService.DeleteItemAsync(id))
                return NoContent();

            throw new System.Exception("Error deleting the message");
        }

        
    }
}