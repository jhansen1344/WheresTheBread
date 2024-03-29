﻿using System.ComponentModel.DataAnnotations;

namespace WheresTheBread.DTO.ItemDto
{
    public class ItemCreateDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
