using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WheresTheBread.Data;
using WheresTheBread.Data.Data;
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
            CreateMap<SubActivity, SubActivityListDto>()
                .ForMember(dest =>
                    dest.ItemCount,
                    opt =>opt.MapFrom(src =>src.SubActivityItems.Count));
            CreateMap<SubActivity, SubActivityDetailDto>();
            CreateMap<SubActivityItemJoin, ItemDetailDto >()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest =>
                    dest.Location,
                    opt => opt.MapFrom(src => src.Item.Location));
            CreateMap<SubActivityUpdateDto, SubActivity>();
            //.ForMember(dest =>
            //dest.SubActivityItems,
            //opt => opt.MapFrom(src => src.SubActivityItems));

        }

    }
}
