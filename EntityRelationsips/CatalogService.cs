using EntityRelationsips.Domain.Entities;
using EntityRelationsips.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRelationsips
{
    public class ProducAddModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }


    public class CatalogService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CatalogService(ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public void AddProduct(ProducAddModel model)
        {
            var category = _categoryRepository
                .Get(x => x.Name == model.Category).FirstOrDefault();
            if(category == null)
            {
                category = new Category();
                category.Name = model.Category;
                _categoryRepository.Add(category);
            }
            var product = new Product();
            product.Name = model.Name;
            product.Price = model.Price;
            product.CategoryId = category.Id;
            _productRepository.Add(product);

        }
    }
}
