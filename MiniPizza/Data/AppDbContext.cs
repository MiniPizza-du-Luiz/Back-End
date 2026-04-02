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
        public DbSet<MarketModel> Markets { get; set; }
        public DbSet<OrderedItemModel> OrderedItems { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
    }
}