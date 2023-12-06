using Hwork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hwork.DAL
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connetitonstring = $"Server=NIJATAZIZ\\SQLEXPRESS;Database=EDU;Trusted_Connection=true";
            optionsBuilder.UseSqlServer(connetitonstring);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Experts> Experts { get; set; } 
        public DbSet<Positions> Positions { get; set; }
    }
}
