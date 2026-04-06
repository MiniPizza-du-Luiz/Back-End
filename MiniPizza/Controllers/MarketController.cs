using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using MiniPizza.Data;
using MiniPizza.Model;


namespace MiniPizza.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class MarketController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MarketController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/Market/FindMarkets")] 
        public ActionResult<List<MarketModel>> FindMarkets()
        {
            var mercados = _context.Markets.ToList();
            return Ok(mercados);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/Market/FindMarketById/{id}")]   
        public ActionResult<MarketModel> FindMarketById(int id)
        {
            var mercado = _context.Markets.Find(id);
            if (mercado == null)
            {
                return NotFound("Não foi encontrado nenhum mercado com o ID fornecido."); //Retorna o status code 404 Not Found (erro de não encontrado)
            }
            return Ok(mercado); //Retorna o status code 200 OK junto com o mercado encontrado
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/Market/CreateMarket")]
        public ActionResult<MarketModel> CreateMarket(MarketModel market)
        {
            if (market == null)
            {
                return BadRequest("Ocorreu um erro na Solicitação.");
            }

            _context.Markets.Add(market);
            _context.SaveChanges();

            return CreatedAtAction(nameof(FindMarketById), new { id = market.Id }, market); //Retorna o status code 201 Created junto com o mercado criado
        }

    }
}