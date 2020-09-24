using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheresTheBread.DTO.SubActivityDto;

namespace WheresTheBread.Services
{
    public interface ISubActivityService
    {

        Task<bool> CreateSubActivityAsync(string userId, SubActivityCreateDto model);
        Task<bool> DeleteSubActivityAsync(string userId, int id);
        Task<SubActivityDetailDto> GetSubActivityByIdAsync(string userId, int id);
        Task<IEnumerable<SubActivityListDto>> GetSubActivitiesAsync(string userId);
        Task<bool> UpdateSubActivityAsync(string userId, SubActivityUpdateDto model);
    }
}
