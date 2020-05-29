using System;
using System.Collections.Generic;
using System.Text;

namespace WherestheBread.Data.Interfaces
{
    public interface ISubActivity
    {
        int Id { get; set; }
        string Name { get; set; }
        string UserId { get; set; }
        IEnumerable<IItem> SubActivityItems { get; set; }
    }
}
