using asp.net_laboratorna12_shchedrov.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace asp.net_laboratorna12_shchedrov.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
