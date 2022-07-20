using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=DovizKurDb;integrated security=true; User Id=postgres; Password=1;");
        }

        public DbSet<DovizKuru> DovizKurus { get; set; }
    }
}
