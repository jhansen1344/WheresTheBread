using System;
using System.Collections.Generic;
using System.Text;
using WheresTheBread.DTO.ItemDto;

namespace WheresTheBread.DTO.SubActivityDto
{
    public class SubActivityListDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<ItemListDto> SubActivityItems { get; set; }


    }
}
