using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WheresTheBread.Data;
using WheresTheBread.Data.Data;
using WheresTheBread.DTO.ItemDto;
using WheresTheBread.DTO.SubActivityDto;

namespace WheresTheBread.Services
{
    public class SubActivityService : ISubActivityService

    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SubActivityService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> CreateSubActivityAsync(string userId, SubActivityCreateDto model)
        {
            var subActivity = new SubActivity(model.Name, userId);

            subActivity.SubActivityItems = await _context.Items
                .Where(i => model.ItemIds.Contains(i.Id))
                .Select(item => new SubActivityItemJoin()
                {
                    Item = item,
                    SubActivity = subActivity
                })
                .ToListAsync();
            
            await _context.SubActivities.AddAsync(subActivity);

            return await _context.SaveChangesAsync() == model.ItemIds.Count() + 1;
        }

        public async Task<bool> DeleteSubActivityAsync(string userId, int id)
        {
            var subActivity = await _context
                .SubActivities
                .SingleOrDefaultAsync(s => s.Id == id && s.UserId == userId);

            _context.SubActivities.Remove(subActivity);
            
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<SubActivityListDto>> GetSubActivitiesAsync(string userId)
        {
            var subActivitiesFromDb = await _context.SubActivities
                .Where(s => s.UserId == userId)
                .Include(subActivity => subActivity.SubActivityItems)
                .ToListAsync();
            
            var subActivitiesToReturn = _mapper.Map<List<SubActivityListDto>>(subActivitiesFromDb);
            
            return subActivitiesToReturn;
        }

        public async Task<IEnumerable<ItemDetailDto>> GetSubActivitiyItems(string userId, List<int> subActivityIds)
        {
            var listOfItems = await _context.SubActivities
                .Where(subActivity => subActivityIds.Contains(subActivity.Id))
                .Include(subActivity => subActivity.SubActivityItems)
                .ThenInclude(subActivityItems => subActivityItems.Item)
                .Select(subActivity => _mapper.Map<ItemDetailDto>(subActivity.SubActivityItems))
                .ToListAsync();
            
            return listOfItems;
        }

        public async Task<SubActivityDetailDto> GetSubActivityByIdAsync(string userId, int id)
        {
            var subActivityFromDb = await _context.SubActivities
                .Include(subActivity => subActivity.SubActivityItems)
                .ThenInclude(subActivityItems => subActivityItems.Item)
                .SingleOrDefaultAsync(e => e.UserId == userId && e.Id == id);
            
            var subActivityToReturn = _mapper.Map<SubActivityDetailDto>(subActivityFromDb);
            
            subActivityToReturn.Items = _mapper.Map<List<ItemDetailDto>>(subActivityFromDb.SubActivityItems);
            
            return subActivityToReturn;
        }

        public async Task<bool> UpdateSubActivityAsync(string userId, SubActivityUpdateDto model)
        {
            var subActivity = await _context
                .SubActivities
                .Include(subActivity => subActivity.SubActivityItems)
                .SingleOrDefaultAsync(s => s.Id == model.Id && s.UserId == userId);
            
            _mapper.Map(model, subActivity);

            subActivity.SubActivityItems.Clear();

            subActivity.SubActivityItems = await _context.Items
                .Where(i => model.ItemIds.Contains(i.Id))
                .Select(item => new SubActivityItemJoin()
                {
                    Item = item,
                    SubActivity = subActivity
                })
                .ToListAsync();
            
            return await _context.SaveChangesAsync() == model.ItemIds.Count();
        }
    }
}
