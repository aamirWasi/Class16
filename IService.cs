using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class16
{
    public interface IService
    {
        ICollection<Product> Get();
        void Add(Product product);
        Product AddProduct(Product product);
        Product GetId(int id);
        void Update(Product product);
        void Delete(int id);
    }
}
