using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelUser
{
	public class UserInfor
	{
		public int UserID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int IsAdmin { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public UserInfor()
		{

		}
		public UserInfor(int UserId, string name, string email, int isAdmin, string firstName)
		{
			UserID = UserId;
			Name = name;
			Email = email;
			IsAdmin = isAdmin;
		}
	}
}
