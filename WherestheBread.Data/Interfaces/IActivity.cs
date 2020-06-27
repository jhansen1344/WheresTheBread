using System;
using System.Collections.Generic;
using System.Text;

namespace WherestheBread.Data.Interfaces
{
    public interface IActivity
    {
        int Id { get; set; }
        string UserId { get; set; }
        DateTimeOffset Created { get; }
        IEnumerable<SubActivity> SubActivities {get; set;}
    }
}
