using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorWebApp.Context;
using razorWebApp.Models;
using razorWebApp.Repositories;

namespace razorWebApp.Pages;

public class CreateProductModel : PageModel
{
	private readonly IProductRepository _repository;

	public CreateProductModel(IProductRepository repository)
	{
		_repository = repository;
	}

	public void OnGet()
	{

	}

	[BindProperty]
	public CreateProduct Product { get; set; }
	public async Task<IActionResult> OnPost(CreateProduct product)
	{

		if (!ModelState.IsValid)
		{
			return Page();
		}

		var NewProduct = new Product()
		{
			Name = product.Name,
			Price = product.Price,
			Type = product.Type,
			summary = product.summary
		};
		await _repository.CreateProductAsync(NewProduct);
		return RedirectToPage("./Products");
	}
}

