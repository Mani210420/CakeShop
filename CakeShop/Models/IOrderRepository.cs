namespace CakeShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
