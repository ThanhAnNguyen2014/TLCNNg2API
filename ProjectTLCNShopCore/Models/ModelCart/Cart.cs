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
		// remove item with quantity
		public virtual void RemoveItem(ProductModel product)
		{
			CartItem line = lineColletion.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
			if (line == null)
			{
				// san pham khong co trong gio hang
				return;
			}
			else
			{
				if (line.Quantity == 1)
				{
					RemoveLine(product);
				}
				else
				{
					line.Quantity = line.Quantity - 1;
				}
				
			}
		}
		// remove a line item in cart
		public virtual void RemoveLine(ProductModel product) => lineColletion.RemoveAll(l => l.Product.ProductID == product.ProductID);
		// caculated Sum value Price
		public virtual Nullable<decimal> ComputeTotalValue() => lineColletion.Sum(e => e.Product.UnitPrice * e.Quantity);
		public virtual void Clear() => lineColletion.Clear();
		public virtual IEnumerable<CartItem> Lines => lineColletion;
	
	}
}
