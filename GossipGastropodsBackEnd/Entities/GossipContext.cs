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
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post);

            modelBuilder.Entity<Comment>().HasKey(c => c.Id);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
