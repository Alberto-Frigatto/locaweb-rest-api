using locaweb_rest_api.Models;
using Microsoft.EntityFrameworkCore;

namespace locaweb_rest_api.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SentEmail> SentEmails { get; set; }
        public DbSet<ReceivedEmail> ReceivedEmails { get; set; }
        public DbSet<FavoriteSentEmail> FavoriteSentEmails { get; set; }
        public DbSet<TrashedEmail> TrashedEmails { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.ToTable("User");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Email).IsRequired().HasMaxLength(255);
                entity.Property(p => p.FullName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Password).IsRequired().HasMaxLength(255);
                entity.Property(p => p.Image).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Language).IsRequired().HasMaxLength(2);
                entity.Property(p => p.Theme).IsRequired();
            });
        }
    }
}
