namespace CakeShop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Cake cake);
        int RemoveFromCart(Cake cake);
        List<ShoppingCartItem> shoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
