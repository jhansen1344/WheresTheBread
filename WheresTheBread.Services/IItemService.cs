using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheresTheBread.DTO.ItemDto;

namespace WheresTheBread.Services
{
    public interface IItemService
    {
        Task<bool> CreateItemAsync(string userId, ItemCreateDto model);
        Task<bool> DeleteItemAsync(string userId, int itemId);
        Task<ItemDetailDto> GetItemByIdAsync(string userId, int id);
        Task<IEnumerable<ItemListDto>> GetItemsAsync(string userId);
        Task<bool> UpdateItemAsync(string userId, ItemUpdateDto model);
    }
}
