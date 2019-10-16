using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class16
{
    public interface IRepository
    {
        ICollection<Product> GetAll();
        void InsertAProduct(Product product);
        Product InsertProduct(Product product);
        Product GetById(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
