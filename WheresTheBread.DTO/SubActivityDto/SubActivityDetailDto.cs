using System;
using System.Collections.Generic;
using System.Text;
using WheresTheBread.DTO.ItemDto;

namespace WheresTheBread.DTO.SubActivityDto
{
    public class SubActivityDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<ItemDetailDto> SubActivityItems { get; set; }
    }
}
