using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WheresTheBread.Data.Data;

namespace WheresTheBread.Data
{
    public class SubActivity
    {
        public SubActivity(string name, string userId)
        {
            Name = name;
            UserId = userId;
            SubActivityItems = new HashSet<SubActivityItemJoin>();
        }
        public SubActivity()
        {
            SubActivityItems = new HashSet<SubActivityItemJoin>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Too many characters")]
        [Display(Name = "SubActivity")]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual ICollection<SubActivityItemJoin> SubActivityItems { get; set; }
    }
}
