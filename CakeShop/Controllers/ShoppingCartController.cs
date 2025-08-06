using CakeShop.Models;
using CakeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICakeRepository _cakeRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(ICakeRepository cakeRepository, IShoppingCart shoppingCart)
        {
            _cakeRepository = cakeRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int cakeId)
        {
            var selectedCake = _cakeRepository.AllCakes.FirstOrDefault(c => c.CakeId == cakeId);
            if (selectedCake != null)
            {
                _shoppingCart.AddToCart(selectedCake);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int cakeId) 
        {
            var deleteCake = _cakeRepository.AllCakes.FirstOrDefault(c =>c.CakeId == cakeId);
            if(deleteCake != null)
            {
                _shoppingCart.RemoveFromCart(deleteCake);
            }
            return RedirectToAction("Index");
        }
    }
}
