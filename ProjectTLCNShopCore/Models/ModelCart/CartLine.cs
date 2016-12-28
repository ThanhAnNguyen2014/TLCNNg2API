using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelCart
{
    public class CartLine
    {
		public int CartLineID { get; set; }
		public Products Product { get; set; }
		public int Quantity { get; set; }
		//public int ProductId { get; set; }
		//public int Quantity { get; set; }


	}
}
