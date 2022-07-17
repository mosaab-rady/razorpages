using Microsoft.EntityFrameworkCore;
using razorWebApp.Models;

namespace razorWebApp.Context;

public class postgresContext : DbContext
{
	public postgresContext(DbContextOptions<postgresContext> options) : base(options)
	{
	}

	public DbSet<Product> Products { get; set; }
}