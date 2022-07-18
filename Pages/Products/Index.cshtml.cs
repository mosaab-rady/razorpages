using Microsoft.AspNetCore.Mvc.RazorPages;
using razorWebApp.Models;
using razorWebApp.Repositories;

namespace razorWebApp.Pages;
public class ProductsModel : PageModel
{


	private readonly IProductRepository _repository;

	public ProductsModel(IProductRepository repository)
	{
		_repository = repository;
	}



	public IEnumerable<Product> _products;
	public async Task OnGetAsync()
	{
		_products = await _repository.GetAllProductsAsync();
	}



}