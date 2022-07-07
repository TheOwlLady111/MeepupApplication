using System;
using System.Collections.Generic;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class MeetupAppDatabaseContext : DbContext
    {
        public MeetupAppDatabaseContext()
        {
        }

        public MeetupAppDatabaseContext(DbContextOptions<MeetupAppDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfig())
                .ApplyConfiguration(new RoleConfig())
                .ApplyConfiguration(new UserConfig())
                .ApplyConfiguration(new SpeakerConfig());
        }
    }
}
