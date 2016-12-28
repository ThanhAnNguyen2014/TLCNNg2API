using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelCart
{
	public class CartFull
	{

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
		public virtual Nullable<decimal> ComputeTotalValue() => lineColletion.Sum(e => e.Product.UnitPrice * e.Quantity);
		public virtual void Clear() => lineColletion.Clear();
		public virtual IEnumerable<CartLine> Lines => lineColletion;
		//public int ProductId { get; set; }
		//public string ProductName { get; set; }
		//public int Quantity { get; set; }
		//public Nullable<int> SupplierID { get; set; }
		//public Nullable<int> CategoryID { get; set; }
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

		//public CartFull() { }
		//public CartFull(Products pro, int quatity)
		//{
		//	this.ProductId = pro.ProductId;
		//	this.ProductName = pro.ProductName;
		//	this.Quantity = quatity;
		//	this.SupplierID = pro.SupplierId;
		//	this.CategoryID = pro.CategoryId;
		//	this.UnitPrice = pro.UnitPrice.GetValueOrDefault().ToString("0,0");
		//	this.UnitsInStock = pro.UnitsInStock;
		//	this.ReorderLevel = pro.ReorderLevel;
		//	this.Discount = long.Parse(pro.Discount.GetValueOrDefault().ToString("0,0"));
		//	this.Discontinued = pro.Discontinued;
		//	this.unitInStockCart = pro.UnitsInStock > 10 ? "10+" : pro.UnitsInStock.ToString();
		//	this.Note = pro.Note;
		//	this.Picture = pro.Picture.Split(';')[0];
		//	this.sumPrice = (pro.UnitPrice * quatity).GetValueOrDefault().ToString("0,0");
		//}
	}
}
