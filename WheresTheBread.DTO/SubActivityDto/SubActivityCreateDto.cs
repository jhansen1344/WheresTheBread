using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WheresTheBread.Data;

namespace WheresTheBread.DTO.SubActivityDto
{
    public class SubActivityCreateDto
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "SubActivity Name")]
        public string Name { get; set; }

        public virtual IEnumerable<int> ItemIds { get; set; }
    }
}
