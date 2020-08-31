using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WheresTheBread.Data.Data
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
