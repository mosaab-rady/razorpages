using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorWebApp.Models;
using razorWebApp.Repositories;
using razorWebApp.Utils;

namespace razorWebApp.Pages;


[BindProperties]
public class DeleteModel : PageModel
{
	private readonly IProductRepository _repository;

	public DeleteModel(IProductRepository repository)
	{
		_repository = repository;
	}

	public Product product;
	public async Task<PageResult> OnGet([FromRoute] Guid id)
	{
		product = await _repository.GetProductAsync(id);
		if (product is null)
		{
			throw new AppException("No product found with that ID.", 404);
		}
		return Page();
	}


	public async Task<RedirectToPageResult> OnPost([FromRoute] Guid id)
	{
		product = await _repository.GetProductAsync(id);
		if (product is null) throw new AppException("No product found with that ID.", 404);
		await _repository.DeleteProductAsync(id);
		return RedirectToPage("Index");
	}
}