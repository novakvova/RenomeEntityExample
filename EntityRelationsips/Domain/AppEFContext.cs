using EntityRelationsips.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsips.Domain
{
    public class AppEFContext : DbContext
    {
        DbSetup settings = 
            JsonConvert.DeserializeObject<DbSetup>(File.ReadAllText("appsettings.json"));

        #region Catalog
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Identity
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserRole>()
                .HasKey(sc => new { sc.UserId, sc.RoleId });

            modelBuilder.Entity<AppUserRole>()
                            .HasOne<AppUser>(sc => sc.User)
                            .WithMany(s => s.UserRoles)
                            .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<AppUserRole>()
                        .HasOne<AppRole>(sc => sc.Role)
                        .WithMany(s => s.UserRoles)
                        .HasForeignKey(sc => sc.RoleId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Server={settings.Host};" +
               $"Port={settings.Port};" +
               $"Database={settings.Database};" +
               $"Username={settings.UserId};" +
               $"Password={settings.Password}");



            //optionsBuilder.UseSqlServer("Server=.;" +
            //   //"Port=1433;" +
            //   "Database=dbshop;" +
            //   "Trusted_Connection=True;"
            //   );
        }
    }
}
