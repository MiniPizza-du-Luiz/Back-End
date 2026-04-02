using Microsoft.EntityFrameworkCore;
using MiniPizza.Model;

namespace MiniPizza.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PizzaModel> Pizzas { get; set; }
        public DbSet<StockModel> Stocks { get; set; }
    }
}