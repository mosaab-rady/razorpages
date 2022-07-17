using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace razorWebApp.Models;


[Index(nameof(Name), IsUnique = true)]
public class Product
{
	[Key]
	public Guid Id { get; set; }
	[Required]
	public string Name { get; set; }
	[Required]
	public decimal Price { get; set; }
	[Required]
	public string Type { get; set; }
	public string summary { get; set; }
}


public record CreateProduct(
										[Required] string Name,
										[Range(1, 1000)] decimal Price,
										[Required] string Type,
										string summary
										);

public record UpdateProduct(
													string Name,
													decimal Price,
													string Type,
													string summary
													);