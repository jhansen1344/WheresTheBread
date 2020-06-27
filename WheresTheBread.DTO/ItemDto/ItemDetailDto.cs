using System;
using System.Collections.Generic;
using System.Text;

namespace WheresTheBread.DTO.ItemDto
{
    public class ItemDetailDto
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public virtual string Location { get; set; }
    }
}
