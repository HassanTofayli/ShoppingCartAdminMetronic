﻿using Microsoft.AspNetCore.Mvc;
using ShoppingCartAdminMetronic.Data;
using ShoppingCartAdminMetronic.Models;
using ShoppingCartAdminMetronic.Models.ViewModels;

namespace ShoppingCartAdminMetronic.Controllers
{
	public class CartController : Controller
	{
		private readonly AppDbContext _context;

		public CartController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

			CartViewModel cartVM = new()
			{
				CartItems = cart,
				GrandTotal = cart.Sum(x => x.Quantity * x.Price)
			};
			return View(cartVM);
		}

		public async Task<IActionResult> Add(long id)
		{
			Product product = await _context.Products.FindAsync(id) ?? new Product();

			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

			CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

			if (cartItem == null)
			{
				cart.Add(new CartItem(product));
			}
			else
			{
				cartItem.Quantity += 1;
			}

			HttpContext.Session.SetJson("Cart", cart);
			TempData["Success"] = "The product has been added";
			ViewBag.sum = cart?.Sum(x => x.Quantity * x.Price) ?? 0;

			return Redirect(Request.Headers["Referer"].ToString());
		}

		public IActionResult Decrease(long id)
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

			CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

			if (cartItem.Quantity > 1)
			{
				cartItem.Quantity -= 1;
			}
			else
			{
				cart.RemoveAll(c => c.ProductId == id);
			}

			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

			TempData["Success"] = "The product has been removed";
			ViewBag.sum = cart?.Sum(x => x.Quantity * x.Price) ?? 0;

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Remove(long id)
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");


			cart.RemoveAll(c => c.ProductId == id);


			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

			TempData["Success"] = "The product has been removed";
			ViewBag.sum = cart?.Sum(x => x.Quantity * x.Price) ?? 0;

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Clear(long id)
		{
			HttpContext.Session.Remove("Cart");
			ViewBag.sum = 0;

			return RedirectToAction("Index");
		}
	}
}