using Fitness__Project.Models;
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
        public DbSet<Unlimited> Unlimited { get; set; }
        public DbSet<_15_Day> _15_Days { get; set; }
        public DbSet<_10_Day> _10_Days { get; set; }
        public DbSet<_8_Day> _8_Days { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}