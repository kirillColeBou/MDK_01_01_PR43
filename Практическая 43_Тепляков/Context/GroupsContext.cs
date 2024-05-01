using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Практическая_43_Тепляков.Context
{
    public class GroupsContext : DbContext
    {
        public DbSet<Models.Groups> Groups { get; set; }

        public GroupsContext()
        {
            Database.EnsureCreated();
            Groups.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Classes.Database.Config.connection, Classes.Database.Config.version);
    }
}
