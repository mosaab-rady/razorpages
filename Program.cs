using Microsoft.EntityFrameworkCore;
using razorWebApp.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


// confugure DBContext
builder.Services.AddDbContext<postgresContext>(options =>
 options
 				.UseNpgsql(builder.Configuration.GetConnectionString("ApiContext"))
				.UseSnakeCaseNamingConvention()
				.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
				.EnableSensitiveDataLogging()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
	app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
