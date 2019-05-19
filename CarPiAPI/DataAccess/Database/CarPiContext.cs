using System;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Database
{
    public partial class CarPiContext : DbContext
    {
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleByUser> RoleByUser { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }

        public CarPiContext(DbContextOptions<CarPiContext> options)
: base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS2014;Database=CarPi;User Id=CarPi;Password=CarPi");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleByUser>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleByUser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleByUser_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleByUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleByUser_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
