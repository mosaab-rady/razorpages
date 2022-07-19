using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorWebApp.Models;
using razorWebApp.Repositories;
using razorWebApp.Utils;

namespace razorWebApp.Pages;

public class SingleProductModel : PageModel
{
	private readonly IProductRepository _repository;

	public SingleProductModel(IProductRepository repository)
	{
		_repository = repository;
	}


	public Product product;
	public async Task<IActionResult> OnGetAsync(Guid id)
	{
		product = await _repository.GetProductAsync(id);

		if (product is null)
		{
			throw new AppException("No product found with that ID.", 404);
		}

		return Page();

	}
}