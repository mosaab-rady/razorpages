using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorWebApp.Context;
using razorWebApp.Models;

namespace razorWebApp.Pages;
public class ProductsModel : PageModel
{
	private readonly postgresContext _context;


	public IEnumerable<Product> _products;

	public ProductsModel(postgresContext context)
	{
		_context = context;
	}


	public async Task OnGetAsync()
	{
		var products = await _context.Products.ToListAsync();
		_products = products;
	}
}