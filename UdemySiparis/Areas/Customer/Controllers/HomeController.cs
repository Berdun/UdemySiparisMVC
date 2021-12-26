﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UdemySiparis.Data.Repository.IRepository;
using UdemySiparis.Models;

namespace UdemySiparis.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Cart cart = new Cart()
            {
                Count = 1,
                ProductId = productId,
                Product = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == productId, includeProperties: "Category"),
            };

            return View(cart);
        }    
        
        [HttpPost]
        public IActionResult Details(Cart cart)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            cart.AppUserId = claim.Value;

            Cart cartDb = _unitOfWork.Cart.GetFirstOrDefault(p=>p.AppUserId == claim.Value && p.ProductId == cart.ProductId);

            _unitOfWork.Cart.Add(cart);
            _unitOfWork.Save();

            //if (cartDb == null)
            //{
                
            //    //Kaydet - Sessionda Sepetteki ürün adetini sakla
            //}
            //else
            //{
            //    //Countu Gelen kadar artır Kaydet
            //}

            return RedirectToAction("Index");
        }


    }
}