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
                entity.Property(p => p.Theme).IsRequired().HasColumnType("number(1)");
            });

            modelBuilder.Entity<SentEmail>(entity => { 
                entity.ToTable("SentEmail");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Recipient).IsRequired().HasMaxLength(150);
                entity.Property(p => p.Subject).IsRequired().HasMaxLength(255);
                entity.Property(p => p.Body).IsRequired().HasMaxLength(255);
                entity.Property(p => p.TimeStamp).IsRequired().HasColumnType("date");
                entity.Property(p => p.SendDate).IsRequired().HasColumnType("date");
                entity.Property(p => p.Viewed).IsRequired().HasColumnType("number(1)");
                entity.Property(p => p.Scheduled).IsRequired().HasColumnType("number(1)");
                entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.IdUser).IsRequired();
            });

            modelBuilder.Entity<ReceivedEmail>(entity =>
            {
                entity.ToTable("ReceivedEmail");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Sender).IsRequired().HasMaxLength(150);
                entity.Property(p => p.Recipient).IsRequired().HasMaxLength(150);
                entity.Property(p => p.Subject).IsRequired().HasMaxLength(255);
                entity.Property(p => p.Body).IsRequired().HasMaxLength(255);
                entity.Property(p => p.Timestamp).IsRequired().HasColumnType("date");
            });

            modelBuilder.Entity<TrashedEmail>(entity =>
            {
                entity.ToTable("TrashedEmail");
                entity.HasKey(p => p.Id);
                entity.HasOne(e => e.ReceivedEmail).WithMany().HasForeignKey(e => e.IdReceivedEmail).IsRequired();
                entity.HasOne(e => e.SentEmail).WithMany().HasForeignKey(e => e.IdSentEmail).IsRequired();
                entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.IdUser).IsRequired();
            });

            modelBuilder.Entity<FavoriteSentEmail>(entity =>
            {
                entity.ToTable("FavoriteSentEmail");
                entity.HasKey(p => p.Id);
                entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.IdUser).IsRequired();
                entity.HasOne(e => e.ReceivedEmail).WithMany().HasForeignKey(e => e.IdReceivedEmail).IsRequired();
            });
        }
    }
}
