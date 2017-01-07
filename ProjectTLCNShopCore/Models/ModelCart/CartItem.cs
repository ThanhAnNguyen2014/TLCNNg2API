using ProjectTLCNShopCore.EF;
using ProjectTLCNShopCore.Models.ModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelCart
{
    public class CartItem
    {
		
		public int CartId { get; set; }		
		public int Quantity { get; set; }
		public string Price { get; set; }
		public ProductModel Product { get; set; }


	}
}
