using Microsoft.AspNetCore.Mvc;
using ShoppingCartAdminMetronic.Data;
using ShoppingCartAdminMetronic.Models;
using System.Diagnostics;

namespace ShoppingCartAdminMetronic.Controllers
{
	public class CategoryController : Controller
	{
		private readonly AppDbContext _context;
		public CategoryController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{

			return View();

		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}