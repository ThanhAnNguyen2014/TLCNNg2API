using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTLCNShopCore.EF;

namespace ProjectTLCNShopCore.Models.ModelCart
{
    public class CheckOutInfor
    {
		
		public bool IsLogged { get; set; }
		public IEnumerable<Customers> customers { get; set; }
		public Customers defaultCustomer { set; get; }
		public Customers newCustomer { set; get; }
		public bool IsNewCustomer { get; set; }
		public Orders order { get; set; }
		public CartViewModel Carts { get; set; }
		public CheckOutInfor()
		{
			IsLogged = false;
			
		}
	}
}

