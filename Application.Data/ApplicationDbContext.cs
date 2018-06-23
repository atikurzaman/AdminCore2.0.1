
using Application.Data.EntityConfiguration;
using Application.Domain;
using Application.Domain.Membership;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<Menu> Menus { get; set; }        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Category> ProductAttributes { get; set; }
        public DbSet<Category> ProductAttributeItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {                   
            builder.RemovePluralizingTableNameConvention();            
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration( new RoleMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration( new UserLoginMap());
            builder.ApplyConfiguration(new UserClaimMap());
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new UserTokenMap());
            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new ProductAttributeConfiguration());
            builder.ApplyConfiguration(new ProductAttributeItemConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(local);Initial Catalog=DotNetCoreDB;User Id=sa;Password=123456;Integrated Security=True;MultipleActiveResultSets=true;");            
        }
    }
}
