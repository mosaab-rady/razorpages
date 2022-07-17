using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorWebApp.Context;
using razorWebApp.Models;

namespace razorWebApp.Pages;

public class CreateProductModel : PageModel
{
	private readonly postgresContext _context;

	public CreateProductModel(postgresContext context)
	{
		_context = context;
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
		await _context.Products.AddAsync(NewProduct);
		await _context.SaveChangesAsync();

		return RedirectToPage("./Products");
	}
}

