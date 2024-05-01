using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Практическая_43_Тепляков.Context
{
    public class ContactsContext : DbContext
    {
        public DbSet<Models.Contacts> Contacts { get; set; }

        public ContactsContext()
        {
            Database.EnsureCreated();
            Contacts.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Classes.Database.Config.connection, Classes.Database.Config.version);
    }
}
