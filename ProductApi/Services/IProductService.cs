using ProductApi.DTOs;
using ProductApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> CreateProductAsync(CreateProductDTO productDto);
    }
}
