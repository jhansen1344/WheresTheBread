using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheresTheBread.Data;
using WheresTheBread.Data.Data;
using WheresTheBread.DTO.ItemDto;
using WheresTheBread.DTO.SubActivityDto;

namespace WheresTheBread.Services
{
    public class SubActivityService : ISubActivityService

    {
        //private readonly string _userId = "testUser";
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SubActivityService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> CreateSubActivityAsync(string userId, SubActivityCreateDto model)
        {
            var subActivity = new SubActivity()
            {
                UserId = userId,
                Name = model.Name,
                SubActivityItems= new List<SubActivityItemJoin>()
            };
            
            
            var itemToAdd = new Item();
            foreach (var id in model.ItemIds)
            {
                itemToAdd = _context.Items.Find(id);
                subActivity.SubActivityItems.Add(new SubActivityItemJoin()
                {
                    Item = itemToAdd,
                    SubActivity = subActivity
                });
            }
            await _context.SubActivities.AddAsync(subActivity);

            var result = await _context.SaveChangesAsync() == model.ItemIds.Count() +1;

            return result;

        }

        public async Task<bool> DeleteSubActivityAsync(string userId, int id)
        {
            var subActivity = await _context
                            .SubActivities
                            .SingleOrDefaultAsync(e => e.Id == id && e.UserId == userId);
            _context.SubActivities.Remove(subActivity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<SubActivityListDto>> GetSubActivitiesAsync(string userId)
        {
            var subActivitiesFromDb = await _context.SubActivities.Where(e => e.UserId ==userId).Include(subActivity => subActivity.SubActivityItems).ToListAsync();
            var subActivitiesToReturn = _mapper.Map<List<SubActivityListDto>>(subActivitiesFromDb);
            return subActivitiesToReturn;
        }

        public async Task<IEnumerable<ItemDetailDto>> GetSubActivitiyItems(string userId, List<int> subActivityIds)
        {
            List<ItemDetailDto> listOfItems = new List<ItemDetailDto>();
            foreach (var subId in subActivityIds)
            {
                var subActivityFromDb = await _context.SubActivities.Include(subActivity => subActivity.SubActivityItems).ThenInclude(subActivityItems => subActivityItems.Item).SingleOrDefaultAsync(e => e.UserId == userId && e.Id == subId);

                listOfItems = _mapper.Map<List<ItemDetailDto>>(subActivityFromDb.SubActivityItems);
            }

            return listOfItems;

        }

        public async Task<SubActivityDetailDto> GetSubActivityByIdAsync(string userId, int id)
        {
            var subActivityFromDb = await _context.SubActivities.Include(subActivity => subActivity.SubActivityItems).ThenInclude(subActivityItems => subActivityItems.Item).SingleOrDefaultAsync(e => e.UserId == userId && e.Id == id);
           
                //.Include(subActivity => subActivity.SubActivityItems).ThenInclude(subActivityItems => subActivityItems.Item);
            var subActivityToReturn = _mapper.Map<SubActivityDetailDto>(subActivityFromDb);
            subActivityToReturn.Items = _mapper.Map<List<ItemDetailDto>>(subActivityFromDb.SubActivityItems);
            //subActivityToReturn.SubActivityItems = _mapper.Map<List<ItemListDto>>(subActivityFromDb.SubActivityItems.Item)
            return subActivityToReturn;
        }

        public async Task<bool> UpdateSubActivityAsync(string userId, SubActivityUpdateDto model)
        {
            var subActivity = await _context
                            .SubActivities
                            .Include(subActivity => subActivity.SubActivityItems)
                            .SingleOrDefaultAsync(e => e.Id == model.Id && e.UserId == userId);
            _mapper.Map(model, subActivity);

            subActivity.SubActivityItems.Clear();
            var itemToAdd = new Item();
            foreach (var id in model.ItemIds)
            {
                itemToAdd = _context.Items.Find(id);
                subActivity.SubActivityItems.Add(new SubActivityItemJoin()
                {
                    Item = itemToAdd,
                    SubActivity = subActivity
                });
            }
            var result = await _context.SaveChangesAsync() == model.ItemIds.Count() + 1;

            return result;
        }
    }
}
