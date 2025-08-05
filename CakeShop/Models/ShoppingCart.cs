
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly CakeShopDbContext _cakeShopDbContext;

        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(CakeShopDbContext cakeShopDbContext)
        {
            _cakeShopDbContext = cakeShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<HttpContextAccessor>()?.HttpContext?.Session;

            CakeShopDbContext context = services.GetService<CakeShopDbContext>() ?? throw new Exception("Error Initializing");

            string cartId = session?.GetString("cartId") ?? Guid.NewGuid().ToString();

            session?.SetString("cartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Cake cake)
        {
            var shoppingCartItem = _cakeShopDbContext.ShoppingCartItems.SingleOrDefault(c => c.Cake.CakeId == cake.CakeId && c.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Cake = cake,
                    Amount = 1
                };
                _cakeShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _cakeShopDbContext.SaveChanges();
        }

        public int RemoveFromCart(Cake cake)
        {
            var shoppingCartItem = _cakeShopDbContext.ShoppingCartItems.SingleOrDefault(c => c.Cake.CakeId == cake.CakeId && c.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _cakeShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _cakeShopDbContext.SaveChanges();
            return localAmount;
        }

        public void ClearCart()
        {
            var cartItems = _cakeShopDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);
            _cakeShopDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _cakeShopDbContext.SaveChanges();

        }

        public decimal GetShoppingCartTotal()
        {
            var total = _cakeShopDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(c => c.Cake.Price * c.Amount).Sum();
            return total;
        }

        public List<ShoppingCartItem> shoppingCartItems()
        {
            return ShoppingCartItems ?? _cakeShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Cake).ToList();
        }
    }
}
