using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testurl2.Models;



namespace testurl2
{
    public class AppDbContext: IdentityDbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<GtMetrics> GtMetrics { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
  : base(options)
        {
        }
    }
}
