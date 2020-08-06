using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheresTheBread.DTO.SubActivityDto;

namespace WheresTheBread.Services
{
    public interface ISubActivityService
    {

        Task<bool> CreateSubActivityAsync(SubActivityCreateDto model);
        Task<bool> DeleteSubActivityAsync(int id);
        Task<SubActivityDetailDto> GetSubActivityByIdAsync(int id);
        Task<IEnumerable<SubActivityListDto>> GetSubActivitiesAsync();
        Task<bool> UpdateSubActivityAsync(SubActivityUpdateDto model);
    }
}
