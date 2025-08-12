namespace CakeShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CakeShopDbContext _cakeShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(CakeShopDbContext cakeShopDbContext, IShoppingCart shoppingCart)
        {
            _cakeShopDbContext = cakeShopDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = item.Amount,
                    CakeId = item.Cake.CakeId,
                    Price = item.Cake.Price
                };
                order.OrderDetails.Add(orderDetail);
            }

            _cakeShopDbContext.Orders.Add(order);

            _cakeShopDbContext.SaveChanges();
        }
    }
}
