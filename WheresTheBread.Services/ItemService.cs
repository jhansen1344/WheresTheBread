using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WherestheBread;
using WherestheBread.Data;
using WheresTheBread.DTO.ItemDto;


namespace WheresTheBread.Services
{
    public class ItemService
    {
        private readonly string _userId;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ItemService(string userId, IMapper mapper, DataContext context)
        {
            _userId = userId;
            _mapper = mapper;
            _context = context;
        }
        //Get

        public async Task<IEnumerable<ItemListDto>> GetItems()
        {

            var itemsFromDb =  await _context.Items.Where(e => e.UserId == _userId).ToListAsync();
     
            var itemsToReturn =  _mapper.Map<IEnumerable<ItemListDto>>(itemsFromDb);
            return itemsToReturn.ToList();
        }


        // //Get By Id/

        public async Task<ItemDetailDto> GetItemById(int id)
        {
            var itemFromDb = await _context.Items.FirstOrDefaultAsync(e => e.UserId == _userId && e.Id == id);
            var itemToReturn = _mapper.Map<ItemDetailDto>(itemFromDb);
            return itemToReturn;

        }

        ////Create
        //public bool CreateItem (ItemCreateDto model)
        // {

        // }

        // //Update

        // public bool UpdateItem (ItemUpdateDto model)
        // {

        // }

        // //Delete

        // public bool DeleteItem (int itemId)
        // {

        // }
    }
}
