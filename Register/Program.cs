using System;
using System.Collections.Generic;
using Register.Models;

namespace Register
{
	class Program
	{
		static void Main(string[] args)
		{
			var transaction = new Transaction(Discount1);

			foreach (var item in Items1)
			{
				transaction.AddItem(item);
			}

			transaction.RecalculateSubtotal();

			foreach (var item in transaction.Items)
			{
				Console.WriteLine($"{item.Description}\t{item.Price}");
			}

			Console.WriteLine($"Subtotal: {transaction.SubTotal:N2}");
			Console.WriteLine($"Total Discount {transaction.TotalDiscount:N2}");
			Console.ReadLine();
		}

		private static readonly List<Discount> Discount1 = new List<Discount>()
		{
			new Discount()
			{
				DepartmentCode = "101010",
				PercentOff = 10m
			},
			new Discount()
			{
				DepartmentCode = "101112",
				PercentOff = 15m
			}
		};

		private static readonly List<Discount> Discount2 = new List<Discount>()
		{
			new Discount()
			{
				DepartmentCode = "101010",
				PercentOff = 10m
			}
		};

		private static readonly List<Discount> Discount3 = new List<Discount>()
		{
			new Discount()
			{
				DepartmentCode = "101030",
				PercentOff = 10m
			}
		};

		private static readonly List<Discount> Discount4 = new List<Discount>()
		{
			new Discount()
			{
				DepartmentCode = "202030",
				PercentOff = 50m
			}
		};

		private static readonly List<Item> Items1 = new List<Item>()
		{
			new Item {
				Price = 25m,
				DepartmentCode = "101010",
				Description = "Book1",
				ItemId = 1
			},
			new Item {
				Price = 10.99m,
				DepartmentCode = "101112",
				Description = "Book2",
				ItemId = 2
			},
			new Item {
				Price = 12.00m,
				DepartmentCode = "101112",
				Description = "Book3",
				ItemId = 3
			}
		};

		private static readonly List<Item> Items2 = new List<Item>()
		{
			new Item()
			{
				Price = 20m,
				DepartmentCode = "101010",
				Description = "Book4",
				ItemId = 4
			},
			new Item()
			{
				Price = 10,
				DepartmentCode = "202020",
				Description = "Book5",
				ItemId = 5
			}
		};

		private static readonly List<Item> Items3 = new List<Item>()
		{
			new Item()
			{
				Price = 20m,
				DepartmentCode = "101030",
				Description = "Book6",
				ItemId = 6
			},
			new Item()
			{
				Price = 10,
				DepartmentCode = "202030",
				Description = "Book7",
				ItemId = 7
			}
		};
	}

}
