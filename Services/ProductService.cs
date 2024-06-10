using DataAccessLayer;
using BusinessObjects;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            using (var context = new MyStoreContext())
            {
                return context.Products.Include(p => p.Category).ToList();
            }
        }

        public Product GetProductById(int productId)
        {
            using (var context = new MyStoreContext())
            {
                return context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == productId);
            }
        }

        public void CreateProduct(Product product)
        {
            using (var context = new MyStoreContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new MyStoreContext())
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = new MyStoreContext())
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
