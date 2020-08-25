using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WheresTheBread.Data;
using WheresTheBread.Data.Data;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubActivityItemJoin>()
                .HasKey(t => new { t.SubActivityId, t.ItemId });

            modelBuilder.Entity<SubActivityItemJoin>()
                .HasOne(pt => pt.Item)
                .WithMany(p => p.SubActivityItems)
                .HasForeignKey(pt => pt.ItemId);

            modelBuilder.Entity<SubActivityItemJoin>()
                .HasOne(pt => pt.SubActivity)
                .WithMany(t => t.SubActivityItems)
                .HasForeignKey(pt => pt.SubActivityId);
        }

    }
}
