using FishPredictor.DB.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FishPredictor.DB
{
    public class FishContext : DbContext
    {
        public DbSet<Fish> Fishes { get; set; }

        public FishContext(DbContextOptions<FishContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FishConfiguration());

            base.OnModelCreating(modelBuilder);         
        }


    }
}