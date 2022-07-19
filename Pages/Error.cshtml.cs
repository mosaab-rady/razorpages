using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorWebApp.Utils;

namespace razorWebApp.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
	public string RequestId { get; set; }
	public string Message { get; set; }

	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

	private readonly ILogger<ErrorModel> _logger;

	public ErrorModel(ILogger<ErrorModel> logger)
	{
		_logger = logger;
	}

	public void OnGet()
	{
		RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

		var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

		if (exceptionHandlerPathFeature.Error is AppException)
		{
			AppException err = (AppException)exceptionHandlerPathFeature.Error;
			HttpContext.Response.StatusCode = err.statusCode;
			Message = err.Message;
		}
		else
		{
			HttpContext.Response.StatusCode = 500;
			Message = "Something Went Wrong!";
		}

	}
	public void OnPost()
	{
		RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

		var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

		if (exceptionHandlerPathFeature.Error is AppException)
		{
			AppException err = (AppException)exceptionHandlerPathFeature.Error;
			HttpContext.Response.StatusCode = err.statusCode;
			Message = err.Message;
		}
		else
		{
			HttpContext.Response.StatusCode = 500;
			Message = "Something Went Wrong!";
		}

	}
}

