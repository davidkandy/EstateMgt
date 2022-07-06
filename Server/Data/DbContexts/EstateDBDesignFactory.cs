using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.DbContexts
{
    public class EstateDBDesignFactory : IDesignTimeDbContextFactory<EstateDBContext>
    {
        public EstateDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstateDBContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");

            return new EstateDBContext(optionsBuilder.Options);
        }
    }
}
