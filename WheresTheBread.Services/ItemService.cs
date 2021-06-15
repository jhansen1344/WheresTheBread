using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WheresTheBread.Data;
using WheresTheBread.DTO.ItemDto;

namespace WheresTheBread.Services
{
    public class ItemService : IItemService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ItemService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ItemListDto>> GetItemsAsync(string userId)
        {
            return await _context.Items
                .Where(i => i.UserId == userId)
                .ProjectTo<ItemListDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ItemDetailDto> GetItemByIdAsync(string userId, int id)
        {
            return await _context.Items
                .Where(i => i.UserId == userId && i.Id == id)
                .ProjectTo<ItemDetailDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> CreateItemAsync(string userId, ItemCreateDto model)
        {
            var item = new Item(userId, model.Name, model.Location);
            
            await _context.Items.AddAsync(item);
            
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateItemAsync(string userId, ItemUpdateDto model)
        {
            var item = await _context.Items
                .SingleOrDefaultAsync(e => e.Id == model.Id && e.UserId == userId);
            
            _mapper.Map(model, item);
            
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteItemAsync(string userId, int itemId)
        {
            var item = await _context.Items
                .SingleOrDefaultAsync(i => i.Id == itemId && i.UserId == userId);
            
            _context.Items.Remove(item);
            
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
