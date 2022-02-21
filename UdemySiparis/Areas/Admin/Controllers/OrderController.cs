using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemySiparis.Data.Repository.IRepository;
using UdemySiparis.Models.ViewModels;

namespace UdemySiparis.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderVM OrderVM { get; set; }

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var orderList = _unitOfWork.OrderProduct.GetAll(x=>x.OrderStatus != "Delivered");
            return View(orderList);
        }


        public IActionResult Details(int Id)
        {
            OrderVM = new OrderVM
            {
                OrderProduct = _unitOfWork.OrderProduct.GetFirstOrDefault(o => o.Id == Id, includeProperties: "AppUser"),
                OrderDetails = _unitOfWork.OrderDetails.GetAll(d => d.OrderProductId == Id, includeProperties: "Product")
            };
            return View(OrderVM);
        }

        [HttpPost]
        public IActionResult Delivered(OrderVM orderVM)
        {
            var orderProduct = _unitOfWork.OrderProduct.GetFirstOrDefault(o => o.Id == orderVM.OrderProduct.Id);

            orderProduct.OrderStatus = "Delivered";

            _unitOfWork.OrderProduct.Update(orderProduct);
            _unitOfWork.Save();

            return RedirectToAction("Details","Order", new {Id = orderVM.OrderProduct.Id});
        }

        [HttpPost]
        public IActionResult CancelOrder(OrderVM orderVM)
        {
            var orderProduct = _unitOfWork.OrderProduct.GetFirstOrDefault(o => o.Id == orderVM.OrderProduct.Id);

            orderProduct.OrderStatus = "Cancel";

            _unitOfWork.OrderProduct.Update(orderProduct);
            _unitOfWork.Save();


            return RedirectToAction("Details", "Order", new { Id = orderVM.OrderProduct.Id });
        }

        [HttpPost]
        public IActionResult UpdateOrderDetails(OrderVM orderVM)
        {
            var orderProduct = _unitOfWork.OrderProduct.GetFirstOrDefault(o => o.Id == orderVM.OrderProduct.Id);

            orderProduct.Address = orderVM.OrderProduct.Address;
            orderProduct.PostalCode = orderVM.OrderProduct.PostalCode;
            orderProduct.CellPhone = orderVM.OrderProduct.CellPhone;
            orderProduct.Name = orderVM.OrderProduct.Name;

            _unitOfWork.OrderProduct.Update(orderProduct);
            _unitOfWork.Save();

            return RedirectToAction("Details", "Order", new { Id = orderVM.OrderProduct.Id });
        }



    }
}


//v97-2-2