using System;
using Microsoft.EntityFrameworkCore;

namespace GossipGastropodsBackEnd.Entities
{
    public class GossipContext : DbContext
    {
        public GossipContext(DbContextOptions<GossipContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.GUID);
        }

        public DbSet<User> Users { get; set; }
    }
}
