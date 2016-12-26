using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Areas.Admin.Dao
{
    public class CategorieDao
    {
		ProjectShopAPIContext db;
		public CategorieDao(ProjectShopAPIContext _db)
		{
			db = _db;
		}
		public bool ChangeStatus(long id)
		{

			var cate = db.Categories.SingleOrDefault(x => x.CategoryId == id);
			cate.IsDisplay = !cate.IsDisplay;
			db.SaveChanges();
			return cate.IsDisplay;
		}
	}
}
