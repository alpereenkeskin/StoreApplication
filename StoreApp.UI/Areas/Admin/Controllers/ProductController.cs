using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using StoreApp.Entites;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View(_serviceManager.ProductService.GetAllProducts(true));
        }
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoryList();
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateDto productdto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productdto.ImagePath = String.Concat("/images/", file.FileName);
                _serviceManager.ProductService.CreateProduct(productdto);
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();

        }
        private SelectList GetCategoryList()
        {
            return new SelectList(_serviceManager.CategoryService.GetAllCategories(true), "CategoryId", "CategoryName");
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            ViewBag.Categories = GetCategoryList();
            var product = _serviceManager.ProductService.GetOneProductForUpdate(id, true);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productdto, IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            productdto.ImagePath = String.Concat("/images/", file.FileName);
            _serviceManager.ProductService.UpdateProduct(productdto);
            return RedirectToAction("Index", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _serviceManager.ProductService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}