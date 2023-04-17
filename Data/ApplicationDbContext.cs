using Fitness__Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fitness__Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public DbSet<CardInfo> cardInfo { get; set; }
      
        public DbSet<ClassMember> classMembers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Guid gr = Guid.NewGuid();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = gr.ToString(),
                Name = "Admin",
                NormalizedName = "Admin"
            });

            var hasher = new PasswordHasher<IdentityUser>();
            Guid g = Guid.NewGuid();

            builder.Entity<IdentityUser>().HasData(

                new IdentityUser
                {
                    Id = g.ToString(),
                    UserName = "Admin@admin.com",
                    NormalizedUserName = "Admin@admin.com",
                    Email = "Admin@admin.com",
                    NormalizedEmail = "Admin@admin.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin1$")

                }
            );

            builder.Entity<IdentityUserRole<String>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = gr.ToString(),
                        UserId = g.ToString()
                    }
                );
        }
    }
}