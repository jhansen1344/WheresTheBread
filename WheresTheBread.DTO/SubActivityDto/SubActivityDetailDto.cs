using System.Collections.Generic;
using WheresTheBread.DTO.ItemDto;

namespace WheresTheBread.DTO.SubActivityDto
{
    public class SubActivityDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ItemDetailDto> Items { get; set; }
    }
}
