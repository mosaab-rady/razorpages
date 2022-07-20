using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using razorWebApp.Models;
using razorWebApp.Repositories;
using razorWebApp.Utils;

namespace razorWebApp.Pages;

public class UpdateProductModel : PageModel
{

	private readonly IProductRepository _repository;

	public UpdateProductModel(IProductRepository repository)
	{
		_repository = repository;
	}


	public Product product;

	public async Task<IActionResult> OnGetAsync(Guid id)
	{
		product = await _repository.GetProductAsync(id);
		if (product is null)
		{
			throw new AppException("No Product found with that ID.", 404);
		}
		return Page();
	}

	[BindProperty]
	public UpdateProduct updatedProduct { get; set; }
	public async Task<IActionResult> OnPostAsync([FromRoute] Guid id)
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}

		var existingproduct = await _repository.GetProductAsync(id);
		if (existingproduct is null)
		{
			throw new AppException("No Product found with that ID.", 404);
		}

		existingproduct.Name = updatedProduct.Name ?? existingproduct.Name;
		existingproduct.Price = updatedProduct.Price;
		existingproduct.Type = updatedProduct.Type ?? existingproduct.Type;
		existingproduct.summary = updatedProduct.summary ?? existingproduct.summary;

		try
		{
			await _repository.UpdateProductAsync(id, existingproduct);
		}
		catch (DbUpdateException err)
		{
			var error = (PostgresException)err.InnerException;
			if (error.SqlState == "23505")
			{
				ModelState.AddModelError("updatedProduct.Name", "A product with that name already exist. Please use another value");
				return Page();
			}
		}


		return RedirectToPage("./Product", new { id });
	}
}