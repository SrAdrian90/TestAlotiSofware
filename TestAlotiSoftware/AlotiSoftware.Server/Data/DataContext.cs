using AlotiSoftware.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlotiSoftware.Server.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<BusinessUnit> BusinessUnits { get; set; }

        public DbSet<Request> Requests { get; set; }

    }
}
