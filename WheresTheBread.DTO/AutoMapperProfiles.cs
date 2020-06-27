using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WherestheBread.Data;
using WheresTheBread.DTO.ItemDto;

namespace WheresTheBread.DTO
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Item, ItemListDto>();
            CreateMap<Item, ItemDetailDto>();

        }

    }
}
