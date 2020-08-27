using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WheresTheBread.Data;

namespace WheresTheBread.DTO.SubActivityDto
{
    public class SubActivityUpdateDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "SubActivity")]
        public string Name { get; set; }
        public virtual IEnumerable<int> ItemIds { get; set; }
    }
}
