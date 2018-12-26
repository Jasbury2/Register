using System;
using System.Collections.Generic;
using System.Linq;

namespace Register.Models
{
	public class Transaction
	{
		private readonly List<Discount> _discounts;
		public List<Item> Items;
		public decimal TotalDiscount { get; set; }
		public decimal SubTotal { get; set; }

		public Transaction(List<Discount> discounts)
		{
			_discounts = discounts;
			Items = new List<Item>();
		}

		public void AddItem(Item item)
		{
			Items.Add(item);
		}

		public void RemoveItem(int itemId)
		{
			var item = Items.FirstOrDefault(i => i.ItemId == itemId);
			if (item == null)
				return;

			Items.Remove(item);
		}

		public void RecalculateSubtotal()
		{
            decimal calculatingPrice = 0;
            decimal totalDiscountCalculated = 0;

            foreach (var item in Items)
            {
                var discountCode = _discounts.FirstOrDefault(d => d.DepartmentCode == item.DepartmentCode);

                if (discountCode == null)
                {
                 calculatingPrice += item.Price;
                }

                var discount = ((discountCode.PercentOff / 100) * item.Price);
                discount = (Math.Round((100 * discount))) / 100;
                calculatingPrice += item.Price - discount;

                totalDiscountCalculated += discount; 
            }
            TotalDiscount = totalDiscountCalculated; 
            SubTotal = calculatingPrice;

		}

	}
}
