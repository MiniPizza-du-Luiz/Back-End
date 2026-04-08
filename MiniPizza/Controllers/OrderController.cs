using Microsoft.AspNetCore.Mvc;
using MiniPizza.Data;
using MiniPizza.Model;

namespace MiniPizza.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("api/Order/FindOrders")]
        public ActionResult<List<OrderModel>> FindOrders()
        {
            var orders = _context.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/Order/FindOrderById/{id}")]    
        public ActionResult<OrderModel> FindOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound("Não foi encontrado nenhum pedido com o ID fornecido."); //Retorna o status code 404 Not Found (erro de não encontrado)
            }
            return Ok(order);
        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("api/Order/CreateOrder")]
        public ActionResult<OrderModel> CreateOrder(OrderModel order)
        {
            if (order == null)
            {
                return BadRequest("Ocorreu um erro na Solicitação.");
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            return CreatedAtAction(nameof(FindOrderById), new { id = order.Id }, order); //Retorna o status code 201 Created junto com o pedido criado
        }
        
    }
}