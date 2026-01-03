using Healthcare.InventoryManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.InventoryManagement.Domain.Entity;

    namespace Healthcare.InventoryManagement.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }



        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Medicine> MedicineItems { get; set; } = null!;

        public DbSet<Role> Roles { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Primary Key
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // User ↔ UserRole relationship
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)          // UserRole का एक User
                .WithMany(u => u.UserRoles)     // User के कई UserRoles
                .HasForeignKey(ur => ur.UserId);

            // Role ↔ UserRole relationship
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)          // UserRole का एक Role
                .WithMany(r => r.UserRole)     // Role के कई UserRoles
                .HasForeignKey(ur => ur.RoleId);
        }

    }

}
