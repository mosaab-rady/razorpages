using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Npgsql;
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
	public async Task<IActionResult> OnPost()
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}

		var NewProduct = new Product()
		{
			Name = Product.Name,
			Price = Product.Price,
			Type = Product.Type,
			summary = Product.summary
		};
		try
		{
			await _repository.CreateProductAsync(NewProduct);
		}
		catch (DbUpdateException err)
		{
			var error = (PostgresException)err.InnerException;
			if (error.SqlState == "23505")
			{
				ModelState.AddModelError("Product.Name", "A product with that name already exist. Please use another value");
				return Page();
			}
		}
		return RedirectToPage("Index");
	}
}

