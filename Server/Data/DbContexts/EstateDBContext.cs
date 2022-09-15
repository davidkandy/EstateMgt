using Microsoft.EntityFrameworkCore;
using Server.Data.CoreEntities;
using Shared.Models.DTOs.Admin;
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EstateDto>().HasData(new EstateDto
            {
                Id = Guid.Parse("{CFB88E29-4744-48C0-94FA-B25B92DEA314}"),
                Name = "xY0n",
                City = "Abuja",
                Country = "",
                Description = "",
                Geolocation = "",
                PostalCode = "",
                Size = 100,
                State = "",
                Status = "",
                Street = ""                 
            });

            //modelBuilder.Entity<Company>().HasMany(company => company.Estate).WithOne().HasForeignKey(x => x.FKCompanyId);
            //modelBuilder.Entity<Company>().HasOne(company => company.Name);
            //modelBuilder.Entity<Estate>().HasOne(estate => estate.Name);
        }
    }
}
