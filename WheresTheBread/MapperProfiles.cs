using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WheresTheBread.Data;
using WheresTheBread.DTO.ItemDto;
using WheresTheBread.DTO.SubActivityDto;

namespace WheresTheBread
{
    public class MapperProfiles : Profile
    {

        public MapperProfiles()
        {
            CreateMap<Item, ItemListDto>();
            CreateMap<Item, ItemDetailDto>();
            CreateMap<ItemUpdateDto, Item>();
            CreateMap<SubActivity, SubActivityListDto>();
            CreateMap<SubActivity, SubActivityDetailDto>();

        }

    }
}
