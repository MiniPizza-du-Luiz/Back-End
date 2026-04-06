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

        [HttpGet("api/Pizza/FindPizzas")]
        public ActionResult<List<PizzaModel>> FindPizzas()
        {
            var pizzas = _context.Pizzas.ToList();
            return Ok(pizzas);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/Pizza/FindPizzaById/{id}")]
        public ActionResult<PizzaModel> FindPizzaById(int id)
        {
            var pizza = _context.Pizzas.Find(id);
            if (pizza == null)
            {
                return NotFound("Não foi encontrada nenhuma pizza com o ID fornecido."); //Retorna o status code 404 Not Found (erro de não encontrado)
            }
            return Ok(pizza); //Retorna o status code 200 OK junto com a pizza encontrada
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/Pizza/CreatePizza")]
        public ActionResult<PizzaModel> CreatePizza(PizzaModel pizza)
        {
            if (pizza == null)
            {
                return BadRequest("Ocorreu um erro na Solicitação.");
            }

            _context.Pizzas.Add(pizza);
            _context.SaveChanges();

            return CreatedAtAction(nameof(FindPizzaById), new { id = pizza.Id }, pizza); //Retorna o status code 201 Created junto com a pizza criada
        
        }
    }
        
}