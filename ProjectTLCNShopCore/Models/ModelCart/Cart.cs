using ProjectTLCNShopCore.EF;
using ProjectTLCNShopCore.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelCart
{
	public class Cart
	{

		private List<CartItem> lineColletion = new List<CartItem>();
		public virtual void AddItem(ProductModel product, int quantity)
		{
			CartItem line = lineColletion.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
			if (line == null)
			{
				lineColletion.Add(new CartItem
				{
					Product = product,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}
		}
		// remove a line item in cart
		public virtual void RemoveLine(Products product) => lineColletion.RemoveAll(l => l.Product.ProductID == product.ProductId);
		// caculated Sum value Price
		public virtual Nullable<decimal> ComputeTotalValue() => lineColletion.Sum(e => e.Product.UnitPrice * e.Quantity);
		public virtual void Clear() => lineColletion.Clear();
		public virtual IEnumerable<CartItem> Lines => lineColletion;
	
	}
}
