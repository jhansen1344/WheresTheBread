using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WherestheBread.Data.Interfaces;

namespace WherestheBread.Data
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
        public virtual IEnumerable<ISubActivity> SubActivities { get; set; }
    }
}
