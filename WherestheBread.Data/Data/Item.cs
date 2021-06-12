using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WheresTheBread.Data.Data;

namespace WheresTheBread.Data
{
    public class Item
    {
        public Item(string userId, string name, string location)
        {
            UserId = userId;
            Name = name;
            Location = location;
            SubActivityItems = new HashSet<SubActivityItemJoin>();
        }
        public Item()
        {
            SubActivityItems = new HashSet<SubActivityItemJoin>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [Display(Name = "Item Location")]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        public string Location { get; set; }

        public virtual ICollection<SubActivityItemJoin> SubActivityItems { get; set; }
    }
}
