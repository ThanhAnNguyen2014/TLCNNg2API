using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTLCNShopCore.EF;

namespace ProjectTLCNShopCore.Models.ModelCart
{
    public class CheckOutInfor
    {
		//public int id;
		//public string name;
		//public string phone;
		//public string email;
		//public string address;
		//public CheckOutInfor()
		//{

		//}
		//public CheckOutInfor(int id, string name, string phone, string email, string address)
		//{
		//	this.id = id;
		//	this.name = name;
		//	this.phone = phone;
		//	this.email = email;
		//	this.address = address;
		//}
		public bool IsLogged { get; set; }
		public IEnumerable<Customers> customers { get; set; }
		public Customers defaultCustomer { set; get; }
		public Customers newCustomer { set; get; }
		public bool IsNewCustomer { get; set; }
		public Orders order { get; set; }
		public CartViewModel Carts { get; set; }
		//public ProjectTLCNShopCore.Models.ModelUser.AddressModel addressModel { get; set; }
		//	public int LPoint { get; set; }
		public CheckOutInfor()
		{
			IsLogged = false;
			//LPoint = 0;
		}

		//public CheckOutInfor(IEnumerable<Customers> cus, Orders order, CartViewModel cart)
		//{
		//	IsLogged = false;
		//	customers = cus;
		//	this.order = order;
		//	this.Carts = cart;
		//}

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

