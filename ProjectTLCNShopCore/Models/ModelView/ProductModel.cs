using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelView
{
    public class ProductModel
    {
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public decimal UnitPrice { get; set; }
		//public short UnitsInStock { get; set; }
		//public bool Discontinued { get; set; }
		public decimal Discount { get; set; }
		//public bool IsNew { get; set; }
		public string Picture { get; set; }
		public string Note { get; set; }
		//public bool IsBestSeller { get; set; }
		//public bool IsInWishList { get; set; }

		public ProductModel()
		{

		}
		public ProductModel(dynamic product)
		{
			ProductID = product.ProductID;
			ProductName = product.ProductName;
			UnitPrice = product.UnitPrice;
			
			Discount = product.Discount;
			Picture = product.Picture;
			Note = product.Note;
		}
		//public Products product { get; set; }
	}
}
