using System;
using System.Collections.Generic;
using System.Text;
using WheresTheBread.Data.Data;

namespace WheresTheBread.Data.Interfaces
{
    public interface ISubActivity
    {
        int Id { get; set; }
        string Name { get; set; }
        string UserId { get; set; }
        ICollection<SubActivityItemJoin> SubActivityItems { get; set; }
    }
}
