﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WheresTheBread.Data.Data;
using WheresTheBread.Data.Interfaces;

namespace WheresTheBread.Data
{
    public class SubActivity : ISubActivity
    {
        [Key]
        public int Id { get; set ; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "SubActivity")]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual ICollection<SubActivityItemJoin> SubActivityItems { get; set; }
    }
}
