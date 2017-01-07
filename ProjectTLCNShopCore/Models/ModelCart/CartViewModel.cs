using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelCart
{
    public class CartViewModel
    {
		public Cart Cart { get; set; }
		public string TotalPrice { get; set; }

		//public CartViewModel(Cart Cart, string total) {
		//	this.Cart = Cart;
		//	this.TotalPrice = total;
		//}
		public CartViewModel()
		{

		}
	}
}
