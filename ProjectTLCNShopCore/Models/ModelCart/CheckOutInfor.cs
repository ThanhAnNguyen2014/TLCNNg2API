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
		public List<CartFull> products { get; set; }
		public ProjectTLCNShopCore.Models.ModelUser.AddressModel addressModel { get; set; }
		public int LPoint { get; set; }
		public CheckOutInfor()
		{
			IsLogged = false;
			LPoint = 0;
		}

		public CheckOutInfor(IEnumerable<Customers> cus, Orders order, List<CartFull> products)
		{
			IsLogged = false;
			customers = cus;
			this.order = order;
			this.products = products;
		}

		public string getAddress(Customers customer)
		{
			if (customer != null)
				return customer.FullName + " - " + customer.Phone
					+ " - " + customer.Address + " - " + customer.City;
			else
				return "";
		}
	}
}
