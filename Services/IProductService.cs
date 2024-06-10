using BusinessObjects;
using System.Collections.Generic;

namespace Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int productId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}

