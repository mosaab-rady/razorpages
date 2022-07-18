using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorWebApp.Models;
using razorWebApp.Repositories;

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
			throw new Exception("No Product found with that ID.");
		}

		return Page();

	}
}