using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WheresTheBread.Data.Interfaces;

namespace WheresTheBread.Data
{
    public class Activity : IActivity
    {
        [Key]
        public int Id { get ; set ; }
        [Required]
        public string UserId { get; set; }
        public DateTimeOffset Created
        {
            get
            { return DateTimeOffset.Now; }
        }
        public virtual IEnumerable<SubActivity> SubActivities { get; set; }
    }
}
