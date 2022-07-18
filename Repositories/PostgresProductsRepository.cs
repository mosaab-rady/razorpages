using Microsoft.EntityFrameworkCore;
using razorWebApp.Context;
using razorWebApp.Models;

namespace razorWebApp.Repositories;

public class PostgresProductsRepository : IProductRepository
{

	private readonly postgresContext _context;

	public PostgresProductsRepository(postgresContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Product>> GetAllProductsAsync()
	{
		var products = await _context.Products.ToListAsync();
		return products;
	}

	public async Task<Product> GetProductAsync(Guid Id)
	{
		var product = await _context.Products.FindAsync(Id);
		return product;
	}
	public async Task CreateProductAsync(Product product)
	{
		await _context.Products.AddAsync(product);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteProductAsync(Guid Id)
	{
		var ExistingProduct = await _context.Products.FindAsync(Id);
		_context.Products.Remove(ExistingProduct);
		await _context.SaveChangesAsync();
	}




	public async Task UpdateProductAsync(Guid Id, Product product)
	{
		var existingProduct = await _context.Products.FindAsync(Id);
		existingProduct = product;
		await _context.SaveChangesAsync();
	}
}
