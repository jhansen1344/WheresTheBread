using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WheresTheBread.Data;

namespace WheresTheBread
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SubActivity> SubActivities { get; set; }
        public DbSet<Activity> Activities { get; set; }

    }
}
