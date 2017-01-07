using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.DaoDB
{
    public class MyDao
    {
		ProjectShopAPIContext _context;
		public MyDao(ProjectShopAPIContext context)
		{
			_context = context;
		}
		public bool AddCustomer(Customers customer)
		{

			try
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool AddOrder(Orders order)
		{
			try
			{
				_context.Orders.Add(order);
				_context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool AddOrderDetail(OrderDetails orderdetail)
		{
			try
			{
				_context.OrderDetails.Add(orderdetail);
				_context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
