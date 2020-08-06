using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WheresTheBread.Data.Interfaces;

namespace WheresTheBread.Data
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

        [Display(Name = "Item Location")]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        public string Location { get ; set ; }

        //public virtual List<SubActivity> SubActivities { get; set; }
    }
}
