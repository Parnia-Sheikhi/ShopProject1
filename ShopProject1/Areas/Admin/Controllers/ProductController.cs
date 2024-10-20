using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;

namespace ShopProject1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[controller]/[action]")]
    [Authorize]

    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductRepository productRepository, IWebHostEnvironment env)
        {
            _productRepository = productRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_productRepository.GetAllProducts());
        }

        public IActionResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var result = _productRepository.GetById(productId);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Product product, IFormFile files)
        {
            if (files?.Length > 0)
            {
                string filePath = $"{_env.WebRootPath}\\images\\{files.FileName}";
                long size = files.Length;

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyToAsync(stream).Wait();
                }
                product.ImageUrl = files.FileName;
            }
            if (ModelState.IsValid)
            {
                _productRepository.SaveProduct(product);
                TempData["message"] = $"{product.Name} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            { 
                return View(product);
            }
        }

        public IActionResult Delete(int productId)
        {
            _productRepository.DeleteProduct(productId);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
    }
}
