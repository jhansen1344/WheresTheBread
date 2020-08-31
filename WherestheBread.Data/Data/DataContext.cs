using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WheresTheBread.Data;
using WheresTheBread.Data.Data;

namespace WheresTheBread
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SubActivity> SubActivities { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

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
