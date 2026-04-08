using Microsoft.AspNetCore.Mvc;
using MiniPizza.Data;
using MiniPizza.Model;

namespace MiniPizza.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class OrderedItemController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrderedItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/OrderedItem/FindOrderedItems")]
        public ActionResult<List<OrderedItemModel>> FindOrderedItems()
        {
            var orderedItems = _context.OrderedItems.ToList();
            return Ok(orderedItems);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/OrderedItem/FindOrderedItemById/{id}")]
        public ActionResult<OrderedItemModel> FindOrderedItemById(int id)
        {
            var orderedItem = _context.OrderedItems.Find(id);
            if (orderedItem == null)
            {
                return NotFound("Não foi encontrado nenhum item pedido com o ID fornecido."); //Retorna o status code 404 Not Found (erro de não encontrado)
            }
            return Ok(orderedItem);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/OrderedItem/CreateOrderedItem")]  
        public ActionResult<OrderedItemModel> CreateOrderedItem(OrderedItemModel orderedItem)
        {
            if (orderedItem == null)
            {
                return BadRequest("Ocorreu um erro na Solicitação.");
            }

            _context.OrderedItems.Add(orderedItem);
            _context.SaveChanges();

            return CreatedAtAction(nameof(FindOrderedItemById), new { id = orderedItem.Id }, orderedItem); //Retorna o status code 201 Created junto com o item pedido criado
        }

        
    }
}