using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WherestheBread.Data.Interfaces;

namespace WherestheBread.Data
{
    public class SubActivity : ISubActivity
    {
        [Key]
        public int Id { get; set ; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual IEnumerable<Item> SubActivityItems { get; set; }
    }
}
