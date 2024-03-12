using Microsoft.EntityFrameworkCore;

namespace FishPredictor
{
    public class FishContext : DbContext
    {
        public DbSet<Fish> Fishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-2O1LU4E2;database=fishDb;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
