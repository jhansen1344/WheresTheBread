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
    }
}