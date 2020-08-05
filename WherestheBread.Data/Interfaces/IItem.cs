using System;
using System.Collections.Generic;
using System.Text;

namespace WheresTheBread.Data.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }
        string UserId { get; set; }

        string Name { get; set; }
        string Location { get; set; }
    }
}
