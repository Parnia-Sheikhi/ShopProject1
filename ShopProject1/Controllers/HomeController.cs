using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;
using ShopProject1.Models;

namespace ShopProject1.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private int PageSize = 6;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("/")]
        public IActionResult Index(string category, int page = 1)
        {
            HomeViewModel model = new HomeViewModel();
            model.Category = category;
            model.Result = _productRepository.GetPageData(category, page, PageSize);

            return View("Index",model);
        }
    }
}
