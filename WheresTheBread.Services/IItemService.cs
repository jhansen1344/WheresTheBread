using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheresTheBread.DTO.ItemDto;

namespace WheresTheBread.Services
{
    public interface IItemService
    {
        Task<bool> CreateItemAsync(ItemCreateDto model);
        Task<bool> DeleteItem(int itemId);
        Task<ItemDetailDto> GetItemByIdAsync(int id);
        Task<IEnumerable<ItemListDto>> GetItemsAsync();
        Task<bool> UpdateItem(ItemUpdateDto model);
    }
}
