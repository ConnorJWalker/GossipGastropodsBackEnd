using Microsoft.EntityFrameworkCore;

namespace GossipGastropodsBackEnd.Entities
{
    public class GossipContext : DbContext
    {
        public GossipContext(DbContextOptions<GossipContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.GUID);

            modelBuilder.Entity<Post>().HasKey(p => p.Id);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserGuid);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
