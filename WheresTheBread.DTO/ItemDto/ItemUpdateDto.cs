using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WheresTheBread.DTO.ItemDto
{
    public class ItemUpdateDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        public int? LocationId { get; set; }
  
    }
}
