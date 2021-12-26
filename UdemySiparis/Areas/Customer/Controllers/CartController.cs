using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UdemySiparis.Data.Repository.IRepository;
using UdemySiparis.Models.ViewModels;

namespace UdemySiparis.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOFWork;
        public CartVM CartVM { get; set; }

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOFWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            CartVM = new CartVM()
            {
                ListCart = _unitOFWork.Cart.GetAll(p => p.AppUserId == claim.Value, includeProperties: "Product"),
                OrderProduct = new()
            };

            foreach (var cart in CartVM.ListCart)
            {
                cart.Price = cart.Product.Price * cart.Count;
                CartVM.OrderProduct.OrderPrice += (cart.Price );
            }


            return View(CartVM);
        }
    }
}
