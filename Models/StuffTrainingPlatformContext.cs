using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace training_stuff_api.Models
{
    public partial class StuffTrainingPlatformContext : DbContext
    {
        public StuffTrainingPlatformContext()
        {
        }

        public StuffTrainingPlatformContext(DbContextOptions<StuffTrainingPlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Chapter> Chapter { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=training-staff-database.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Chapter)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("FK_Chapter_Section");

            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.ChapterNavigation)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.Chapter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Chapter");

                entity.HasOne(d => d.EditedByNavigation)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.EditedBy)
                    .HasConstraintName("FK_Lesson_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
