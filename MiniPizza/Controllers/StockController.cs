using Microsoft.AspNetCore.Mvc;
using MiniPizza.Data;
using MiniPizza.Model;

namespace MiniPizza.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase 
    {
        private readonly AppDbContext _context;
        public StockController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("api/Stock/FindStocks")]
        public ActionResult<List<StockModel>> FindStocks()
        {
            var stocks = _context.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/Stock/FindStockById/{id}")]
        public ActionResult<StockModel> FindStockById(int id)
        {
            var stock = _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound("Não foi encontrado nenhum estoque com o ID fornecido."); //Retorna o status code 404 Not Found (erro de não encontrado)
            }
            return Ok(stock);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/Stock/CreateStock")]
        public ActionResult<StockModel> CreateStock(StockModel stock)
        {
            if (stock == null)
            {
                return BadRequest("Ocorreu um erro na Solicitação.");
            }

            _context.Stocks.Add(stock);
            _context.SaveChanges();

            return CreatedAtAction(nameof(FindStockById), new { id = stock.Id }, stock); //Retorna o status code 201 Created junto com o estoque criado
        }

        
    }
}