using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemySiparis.Data.Repository.IRepository;
using UdemySiparis.Models;

namespace UdemySiparis.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Authorize(Roles ="Admin")]
     public class CategoryController : Controller
     {
          private readonly IUnitOfWork _unitOfWork;

          public CategoryController(IUnitOfWork unitOfWork)
          {
               _unitOfWork = unitOfWork;
          }


          public IActionResult Index()
          {
               IEnumerable<Category> categoryList = _unitOfWork.Category.GetAll();
               return View(categoryList);
          }

          public IActionResult Create()
          {
               return View();
          }

          [HttpPost]
          public IActionResult Create(Category category)
          {
               if (ModelState.IsValid)
               {
                    _unitOfWork.Category.Add(category);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
               }
               return View(category);
          }

          public IActionResult Edit(int? id)
          {
               if (id == null || id <= 0)
               {
                    return NotFound();
               }

               var category = _unitOfWork.Category.GetFirstOrDefault(x=>x.Id == id);

               if (category == null)
               {
                    return NotFound();
               }

               return View(category);
          }


          [HttpPost]
          public IActionResult Edit(Category category)
          {
               if (ModelState.IsValid)
               {
                    _unitOfWork.Category.Update(category);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
               }

               return View(category);
          }


          public IActionResult Delete(int id)
          {
               if (id == null || id <= 0)
               {
                    return NotFound();
               }

               var category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);

               if (category == null)
               {
                    return NotFound();
               }

               _unitOfWork.Category.Remove(category);
               _unitOfWork.Save();
               return RedirectToAction("Index");
          }



     }
}
