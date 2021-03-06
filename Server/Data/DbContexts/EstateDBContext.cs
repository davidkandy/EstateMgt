using Microsoft.EntityFrameworkCore;
using Server.Data.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.DbContexts
{
    public class EstateDBContext : DbContext
    {
        public EstateDBContext() : base() { }
        public EstateDBContext(DbContextOptions<EstateDBContext> options) : base(options) { }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasMany(company => company.Estate).WithOne().HasForeignKey(x => x.FKCompanyId);
            //modelBuilder.Entity<Company>().HasOne(company => company.Name);
            //modelBuilder.Entity<Estate>().HasOne(estate => estate.Name);
        }
    }
}
