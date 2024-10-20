using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Contract.Repositories;

namespace ShopProject1.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IProductRepository _productRepository;
        public CategoryViewComponent(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            var allCategories = _productRepository.GetAllCategories();
            return View(allCategories);
        }
    }
}
