using Microsoft.EntityFrameworkCore;
using SupabaseConnection.Models;
using System;

namespace SupabaseConnection.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options) { }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("players", "public");
        }
    }
}
