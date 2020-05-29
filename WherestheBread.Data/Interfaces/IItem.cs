using System;
using System.Collections.Generic;
using System.Text;

namespace WherestheBread.Data.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }
        string UserId { get; set; }

        string Name { get; set; }
        int? LocationId { get; set; }
        string Location { get; set; }
    }
}
