using EB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.Application.Services;

public interface IProductService
{
    Task<bool> CreateProduct(ProductDetails productDetails);

    Task<IEnumerable<ProductDetails>> GetAllProducts();

    Task<ProductDetails> GetProductById(string productId);

    Task<bool> UpdateProduct(ProductDetails productDetails);

    Task<bool> DeleteProduct(string productId);
}
