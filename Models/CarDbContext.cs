using Microsoft.EntityFrameworkCore;
namespace CarDealerApi.Models
{
    public class CarDbContext(DbContextOptions<CarDbContext> options): DbContext(options)
    {
        public DbSet<CarItem> CarItems => Set<CarItem>();
    }
}
