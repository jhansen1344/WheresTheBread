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

namespace WheresTheBread.Services
{
    public class ItemService : IItemService
    {
        private readonly string _userId;
        private readonly IMapper _mapper;
        private readonly DataContext _context;


        public ItemService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        //Get

        public async Task<IEnumerable<ItemListDto>> GetItemsAsync()
        {

            var itemsFromDb = await _context.Items.Where(e => e.UserId == _userId).ToListAsync();

            var itemsToReturn = _mapper.Map<IEnumerable<ItemListDto>>(itemsFromDb);
            return itemsToReturn.ToList();
        }


        // //Get By Id/

        public async Task<ItemDetailDto> GetItemByIdAsync(int id)
        {
            var itemFromDb = await _context.Items.SingleOrDefaultAsync(e => e.UserId == _userId && e.Id == id);
            var itemToReturn = _mapper.Map<ItemDetailDto>(itemFromDb);
            return itemToReturn;

        }

        ////Create
        public async Task<bool> CreateItemAsync(ItemCreateDto model)
        {
            var item = new Item()
            {
                UserId = "testUser",
                Name = model.Name,
                Location = model.Location
            };
            await _context.Items.AddAsync(item);
            var result = await _context.SaveChangesAsync() == 1;
            return result;

        }

        // //Update

        public async Task<bool> UpdateItem(ItemUpdateDto model)
        {
            var item = await _context
                            .Items
                            .SingleOrDefaultAsync(e => e.Id == model.Id && e.UserId == _userId);
            _mapper.Map(model, item);
            return await _context.SaveChangesAsync() == 1;
        }

        // //Delete

        public async Task<bool> DeleteItem(int itemId)
        {
            var item = await _context
                            .Items
                            .SingleOrDefaultAsync(e => e.Id == itemId && e.UserId == _userId);
            _context.Items.Remove(item);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
