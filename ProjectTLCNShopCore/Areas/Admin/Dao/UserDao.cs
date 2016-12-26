using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Areas.Admin.Dao
{
    public class UserDao
    {
		ProjectShopAPIContext db;

		public UserDao(ProjectShopAPIContext _db)
		{
			db = _db;
		}
		public bool ChangeStatus(long id)
		{
			var user = db.Users.SingleOrDefault(x => x.UserId == id);
			user.IsActive = !user.IsActive;
			db.SaveChanges();
			return user.IsActive;
		}
		//public List<Users> getUser()
		//{
		//	var user = db.Users.ToList();
		//	return user;
		//}
	}
}
