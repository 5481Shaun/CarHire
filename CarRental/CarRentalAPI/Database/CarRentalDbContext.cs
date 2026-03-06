using CarRentalAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Database
{
  public class CarRentalDbContext: DbContext
  {
    public CarRentalDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
    {
        
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User_Role>()
               .HasOne(x => x.User)
               .WithMany(y => y.UserRoles)
               .HasForeignKey(x => x.UserId);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}
