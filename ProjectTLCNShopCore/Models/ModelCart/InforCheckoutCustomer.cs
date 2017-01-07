using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelCart
{
    public class InforCheckoutCustomer
    {
		public string name;
		public string phone;
		public string email;
		public string address;
		public InforCheckoutCustomer()
		{

		}
		public InforCheckoutCustomer(string name, string phone, string email, string address)
		{
			this.name = name;
			this.phone = phone;
			this.email = email;
			this.address = address;
		}
	}
}
