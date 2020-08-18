using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheresTheBread.Data;
using WheresTheBread.Data.Data;
using WheresTheBread.DTO.SubActivityDto;

namespace WheresTheBread.Services
{
    public class SubActivityService : ISubActivityService

    {
        private readonly string _userId = "testUser";
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SubActivityService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> CreateSubActivityAsync(SubActivityCreateDto model)
        {
            var subActivity = new SubActivity()
            {
                UserId = "testUser",
                Name = model.Name,
                SubActivityItems= new List<SubActivityItemJoin>()
            };
            
            await _context.SubActivities.AddAsync(subActivity);

            foreach (var id in model.ItemIds)
            {
                subActivity.SubActivityItems.Add(new SubActivityItemJoin() { SubActivityId = subActivity.Id, ItemId = id });
            }
            var result = await _context.SaveChangesAsync() == 1;
            return result;

        }

        public async Task<bool> DeleteSubActivityAsync(int id)
        {
            var subActivity = await _context
                            .SubActivities
                            .SingleOrDefaultAsync(e => e.Id == id && e.UserId == _userId);
            _context.SubActivities.Remove(subActivity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<SubActivityListDto>> GetSubActivitiesAsync()
        {
            var subActivitiesFromDb = await _context.SubActivities.Where(e => e.UserId ==_userId).ToListAsync();
            var subActivitiesToReturn = _mapper.Map<List<SubActivityListDto>>(subActivitiesFromDb);
            return subActivitiesToReturn;
        }

        public async Task<SubActivityDetailDto> GetSubActivityByIdAsync(int id)
        {
            var subActivityFromDb = await _context.SubActivities.SingleOrDefaultAsync(e => e.UserId == _userId && e.Id == id);
            var subActivityToReturn = _mapper.Map<SubActivityDetailDto>(subActivityFromDb);
            return subActivityToReturn;
        }

        public async Task<bool> UpdateSubActivityAsync(SubActivityUpdateDto model)
        {
            var subactivity = await _context
                            .SubActivities
                            .SingleOrDefaultAsync(e => e.Id == model.Id && e.UserId == _userId);
            _mapper.Map(model, subactivity);
            return await _context.SaveChangesAsync() == 1;

        }
    }
}
