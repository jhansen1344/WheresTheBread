using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WherestheBread.Data.Interfaces;

namespace WherestheBread.Data
{
    public class Item : IItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set ; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "Item Name")]
        public string Name { get; set ; }
        [ForeignKey(nameof(Location))]
        public int? LocationId { get ; set ; }
        [Display(Name = "Item Location")]
        public virtual string Location { get ; set ; }
    }
}
