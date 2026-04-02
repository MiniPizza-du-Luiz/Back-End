using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MiniPizza.Data;
using MiniPizza.Model;

namespace MiniPizza.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _context; 
        public PizzaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PizzaModel>> BuscarPizzas()
        {
            var pizzas = _context.Pizzas.ToList();
            return Ok(pizzas);
        }
    }
        
}