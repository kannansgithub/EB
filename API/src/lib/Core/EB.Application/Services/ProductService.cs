using EB.Domain.Entities;
using EB.Domain.Repositories;

namespace EB.Application.Services;

public class ProductService : IProductService
{
    public IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CreateProduct(ProductDetails productDetails)
    {
        if (productDetails != null)
        {
            await _unitOfWork.Products.AddAsync(productDetails);

            var result = _unitOfWork.Save();

            if (result > 0)
                return true;
            else
                return false;
        }
        return false;
    }

    public async Task<bool> DeleteProduct(string productId)
    {
        if (productId is not null)
        {
            var productDetails = await _unitOfWork.Products.GetByIdAsync(productId);
            if (productDetails != null)
            {
                await _unitOfWork.Products.DeleteAsync(productDetails);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

    public async Task<IEnumerable<ProductDetails>> GetAllProducts()
    {
        var productDetailsList = await _unitOfWork.Products.GetAllAsync();
        return productDetailsList;
    }

    public async Task<ProductDetails?> GetProductById(string productId)
    {
        if (productId is not null)
        {
            var productDetails = await _unitOfWork.Products.GetByIdAsync(productId);
            if (productDetails is not null)
            {
                return productDetails!;
            }
        }
        return null;
    }

    public async Task<bool> UpdateProduct(ProductDetails productDetails)
    {
        if (productDetails != null)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productDetails.Id);
            if (product != null)
            {
                product.ProductName = productDetails.ProductName;
                product.ProductDescription = productDetails.ProductDescription;
                product.ProductPrice = productDetails.ProductPrice;
                product.ProductStock = productDetails.ProductStock;

                await _unitOfWork.Products.UpdateAsync(product);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
}
