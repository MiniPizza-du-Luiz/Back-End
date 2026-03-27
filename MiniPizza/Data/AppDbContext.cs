using Microsoft.EntityFrameworkCore;

namespace MiniPizza.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MiniPizza.Model.PizzaModel> Pizzas { get; set; }
    }
}