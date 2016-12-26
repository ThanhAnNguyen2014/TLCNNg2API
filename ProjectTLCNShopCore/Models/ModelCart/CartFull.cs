using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelCart
{
	public class CartFull
	{
		//public int Productid { get; set; }
		//public string ProductName { get; set; }
		//public int Quantity { get; set; }
		//public Nullable<int> SupplierId { get; set; }
		//public Nullable<int> CategoryId { get; set; }
		//public string QuantityPerUnit { get; set; }
		//public string UnitPrice { get; set; }
		//public Nullable<short> UnitsInStock { get; set; }
		//public string unitInStockCart { get; set; }
		//public Nullable<short> UnitsOnOrder { get; set; }
		//public Nullable<short> ReorderLevel { get; set; }
		//public long Discount { get; set; }
		//public bool Discontinued { get; set; }
		//public string Note { get; set; }
		//public string Picture { get; set; }
		//public string sumPrice { get; set; }

		//public FullItemCart()
		//{

		//}
		//public FullItemCart(Products product, int quantity)
		//{
		//	this.Productid = product.ProductId;
		//	this.ProductName = product.ProductName;
		//	this.Quantity = quantity;
		//	this.SupplierId = product.SupplierId;
		//	this.CategoryId = product.CategoryId;
		//	this.UnitPrice = product.UnitPrice.ToString("0,0");
		//	this.UnitsInStock = product.UnitsInStock;
		//	this.ReorderLevel = product.ReorderLevel;
		//	this.Discount = long.Parse(product.Discount.ToString("0,0"));
		//	this.Discontinued = product.Discontinued;
		//	this.unitInStockCart = product.UnitsInStock > 10 ? "10+" : product.UnitsInStock.ToString();
		//	this.Note = product.Note;
		//	this.Picture = product.Picture.Split(';')[0];
		//	this.sumPrice = (product.UnitPrice * quantity).ToString("0,0");
		//}

		private List<CartLine> lineColletion = new List<CartLine>();
		public virtual void AddItem(Products product, int quantity)
		{
			CartLine line = lineColletion.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

			if (line == null)
			{
				lineColletion.Add(new CartLine
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
		public virtual void RemoveLine(Products product) => lineColletion.RemoveAll(l => l.Product.ProductId == product.ProductId);
		// caculated Sum value Price
		public virtual decimal? ComputeTotalValue() => lineColletion.Sum(e => e.Product.UnitPrice * e.Quantity);
		public virtual void Clear() => lineColletion.Clear();
		public virtual IEnumerable<CartLine> Lines => lineColletion;
	}
}
