using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Bom> Bom { get; set; }
        public DbSet<ChildReference> Children { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // configures one-to-many relationship
            builder.Entity<Bom>()
                    .HasOne<ChildReference>(s => s.CurrentChildReference)
                    .WithMany(g => g.Boms)
                    .HasForeignKey(s => s.ChildReferenceId);
            //builder.Entity<ChildReference>().HasKey(t => new { t.Id, t.BomId });

            //        builder.Entity<ChildReference>()
            //.HasMany(e => e.Bom)
            //.WithOne() // make sure to specify navigation property if exists, e.g. e => e.NavProp
            //.HasForeignKey(e => new { e.Id, e.Id });
        }
    }
}
