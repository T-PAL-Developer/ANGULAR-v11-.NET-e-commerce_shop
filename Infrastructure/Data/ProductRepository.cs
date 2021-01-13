using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
  public class ProductRepository : IProductRepository
  {
    public Task<IReadOnlyList<Product>> GetProductAsync()
    {
      throw new System.NotImplementedException();
    }

    public Task<Product> GetProductByIdAsync(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}