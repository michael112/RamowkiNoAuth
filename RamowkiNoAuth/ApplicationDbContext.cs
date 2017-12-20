using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using RamowkiNoAuth.Models;

namespace RamowkiNoAuth
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ScheduledProgramme> ScheduledProgrammes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduledProgramme>().OwnsOne(c => c.BeginTime);
            modelBuilder.Entity<ScheduledProgramme>().HasOne(s => s.Programme).WithMany();
            modelBuilder.Entity<ScheduledProgramme>().HasOne(s => s.Day).WithMany();
            modelBuilder.Entity<WeekDay>();
            modelBuilder.Entity<DateDay>();
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
