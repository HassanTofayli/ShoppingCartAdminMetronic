﻿using Microsoft.EntityFrameworkCore;
using ShoppingCartAdminMetronic.Models;

namespace ShoppingCartAdminMetronic.Data
{
	public class SeedData
	{
		public static void SeedDatabase(AppDbContext context)
		{
			context.Database.Migrate();

			if (!context.Products.Any())
			{
				Category fruits = new Category { Name = "Fruits", Slug = "fruits", ThimbnailImage = "apple.jpg" };
				Category shirts = new Category { Name = "Shirts", Slug = "shirts", ThimbnailImage = "longsleeve.jpg" };

				context.Products.AddRange(
						new Product
						{
							Name = "Apples",
							Slug = "apples",
							Description = "Juicy apples",
							Price = 1.50M,
							Category = fruits,
							ThumbnailImage = "apple.jpg"
						},
						new Product
						{
							Name = "Oranges",
							Slug = "oranges",
							Description = "Sweet oranges",
							Price = 2.00M,
							Category = fruits,
							ThumbnailImage = "orange.jpg"
						},
						new Product
						{
							Name = "Bananas",
							Slug = "bananas",
							Description = "Ripe bananas",
							Price = 1.20M,
							Category = fruits,
							ThumbnailImage = "banana.jpg"
						},
						new Product
						{
							Name = "Strawberries",
							Slug = "strawberries",
							Description = "Fresh strawberries",
							Price = 3.00M,
							Category = fruits,
							ThumbnailImage = "strawberry.jpg"
						},
						new Product
						{
							Name = "Blueberries",
							Slug = "blueberries",
							Description = "Tasty blueberries",
							Price = 2.50M,
							Category = fruits,
							ThumbnailImage = "blueberry.jpg"
						},
						new Product
						{
							Name = "Polo Shirt",
							Slug = "polo-shirt",
							Description = "Comfortable polo shirt",
							Price = 20.00M,
							Category = shirts,
							ThumbnailImage = "polo.jpg"
						},
						new Product
						{
							Name = "T-Shirt",
							Slug = "t-shirt",
							Description = "Casual T-Shirt",
							Price = 10.00M,
							Category = shirts,
							ThumbnailImage = "tshirt.jpg"
						},
						new Product
						{
							Name = "Long Sleeve Shirt",
							Slug = "long-sleeve-shirt",
							Description = "Warm long sleeve shirt",
							Price = 25.00M,
							Category = shirts,
							ThumbnailImage = "longsleeve.jpg"
						},
						new Product
						{
							Name = "Button Down Shirt",
							Slug = "button-down-shirt",
							Description = "Formal button down shirt",
							Price = 30.00M,
							Category = shirts,
							ThumbnailImage = "buttondown.jpg"
						},
						new Product
						{
							Name = "Tank Top",
							Slug = "tank-top",
							Description = "Cool tank top",
							Price = 15.00M,
							Category = shirts,
							ThumbnailImage = "tanktop.jpg"
						},
						new Product
						{
							Name = "Grapes",
							Slug = "grapes",
							Description = "Juicy grapes",
							Price = 2.50M,
							Category = fruits,
							ThumbnailImage = "grape.jpg"
						},
						new Product
						{
							Name = "Pineapple",
							Slug = "pineapple",
							Description = "Sweet pineapple",
							Price = 3.50M,
							Category = fruits,
							ThumbnailImage = "pineapple.jpg"
						}
				);

				context.SaveChanges();
			}
		}
	}
}
