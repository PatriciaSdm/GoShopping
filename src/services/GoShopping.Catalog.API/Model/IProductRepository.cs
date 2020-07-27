using GoShopping.Core.Data;
using GoShopping.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoShopping.Catalog.API.Model
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);

        void Create(Product product);
        void Update(Product product);
    }
}
