using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class16
{
    public class ProductService : IService
    {
        private readonly IRepository _context;

        public ProductService(IRepository service)
        {
            _context = service;
        }

        public void Add(Product product)
        {
            _context.InsertAProduct(product);
        }

        public Product AddProduct(Product product)
        {
            return _context.InsertProduct(product);
        }

        public void Delete(int id)
        {
            _context.DeleteProduct(id);
        }

        public ICollection<Product> Get()
        {
            return _context.GetAll();
        }

        public Product GetId(int id)
        {
            return _context.GetById(id);
        }

        public void Update(Product product)
        {
            _context.UpdateProduct(product);
        }
    }
}
