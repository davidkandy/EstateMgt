using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.DbContexts
{
    public class EstateDBContext : DbContext
    {
        public EstateDBContext() : base() {}

        public EstateDBContext(DbContextOptions<EstateDBContext> options) : base(options) {}

        public DbSet<Estate> Estates { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
