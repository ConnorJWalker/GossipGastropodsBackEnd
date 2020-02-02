using GossipGastropodsBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace GossipGastropodsBackEnd.Entities
{
    public interface IGossipContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Like> Likes { get; set; }
    }

    public class GossipContext : DbContext, IGossipContext
    {
        public GossipContext(DbContextOptions<GossipContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.GUID);

            modelBuilder.Entity<PostBase>().HasKey(p => p.Id);
            modelBuilder.Entity<PostBase>().HasDiscriminator<string>("PostType");


            modelBuilder.Entity<Post>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserGuid);
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserGuid);

            modelBuilder.Entity<Like>().HasKey(l => l.Id);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Owner)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserGuid);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
