using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WheresTheBread.Data
{
    public class Activity
    {
        public Activity(string userId)
        {
            UserId = userId;
            Created = DateTime.Now;
            SubActivities = new HashSet<SubActivity>();
        }
        public Activity()
        {
            SubActivities = new HashSet<SubActivity>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTimeOffset Created { get; }
        public virtual IEnumerable<SubActivity> SubActivities { get; set; }
    }
}
