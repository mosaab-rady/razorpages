using razorWebApp.Models;

namespace razorWebApp.Repositories;

public interface IProductRepository
{
	public Task<IEnumerable<Product>> GetAllProductsAsync();
	public Task<Product> GetProductAsync(Guid Id);
	public Task CreateProductAsync(Product product);
	public Task UpdateProductAsync(Guid Id, Product product);
	public Task DeleteProductAsync(Guid Id);

}