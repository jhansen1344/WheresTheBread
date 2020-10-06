using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheresTheBread.Data;
using WheresTheBread.DTO.ItemDto;
using WheresTheBread;
using System.Security.Claims;
using AutoMapper.QueryableExtensions;

namespace WheresTheBread.Services
{
    public class ItemService : IItemService
    {
        //private readonly string _userId = "testUser";
        private readonly IMapper _mapper;
        private readonly DataContext _context;


        public ItemService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        //Get

        public async Task<IEnumerable<ItemListDto>> GetItemsAsync(string userId)
        {

            List<Item> itemsFromDb = await _context.Items.Where(e => e.UserId == userId).ToListAsync();

            var itemsToReturn = _mapper.Map<List<ItemListDto>>(itemsFromDb);
            return itemsToReturn;
        }


        // //Get By Id/

        public async Task<ItemDetailDto> GetItemByIdAsync(string userId, int id)
        {
            return await _context.Items
                .Where(e => e.UserId == userId && e.Id == id)
                .ProjectTo<ItemDetailDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        ////Create
        public async Task<bool> CreateItemAsync(string userId, ItemCreateDto model)
        {
            var item = new Item()
            {
                UserId = userId,
                Name = model.Name,
                Location = model.Location
            };
            await _context.Items.AddAsync(item);
            var result = await _context.SaveChangesAsync() == 1;
            return result;

        }

        // //Update

        public async Task<bool> UpdateItemAsync(string userId, ItemUpdateDto model)
        {
            var item = await _context
                            .Items
                            .SingleOrDefaultAsync(e => e.Id == model.Id && e.UserId == userId);
            _mapper.Map(model, item);
            return await _context.SaveChangesAsync() == 1;
        }

        // //Delete

        public async Task<bool> DeleteItemAsync(string userId, int itemId)
        {
            var item = await _context
                            .Items
                            .SingleOrDefaultAsync(e => e.Id == itemId && e.UserId == userId);
            _context.Items.Remove(item);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
