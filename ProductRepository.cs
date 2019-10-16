using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class16
{
    public class ProductRepository : IRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public void DeleteProduct(int id)
        {
            var product = GetById(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(x => x.Id == id);
        }

        public void InsertAProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product InsertProduct(Product product)
        {
            var add = _context.Products.Add(product);
            _context.SaveChanges();
            product.Id = add.Entity.Id;
            return product;
        }

        public void UpdateProduct(Product product)
        {
            var update = GetById(product.Id);
            update.Name = product.Name;
            update.Price = product.Price;
            _context.Products.Update(update);
            _context.SaveChanges();
        }
    }
}
