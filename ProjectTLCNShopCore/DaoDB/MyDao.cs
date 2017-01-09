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
		public bool CheckUser(string email)
		{
			var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
			if (user != null)
			{
				return true;
			}
			return false;
		}
		// get Id user by Email
		public int GetId(string email)
		{
			var user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
			return user.UserId;
		}

        // get product by Id
        public Products GetProduct(int id)
        {
            var pro = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (pro!=null)
            {
                return pro;
            }
            return null;
        }
	}
}
