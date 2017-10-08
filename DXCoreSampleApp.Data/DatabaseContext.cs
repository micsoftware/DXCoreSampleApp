using DXCoreSampleApp.Common.Domain;
using DXCoreSampleApp.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DXCoreSampleApp.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
            Database.EnsureCreated();            
        }

        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
