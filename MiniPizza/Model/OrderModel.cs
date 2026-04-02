namespace MiniPizza.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDelivered { get; set; }
        
    }
}