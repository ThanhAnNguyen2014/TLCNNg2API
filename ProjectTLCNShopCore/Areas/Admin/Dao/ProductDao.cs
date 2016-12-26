using ProjectTLCNShopCore.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Areas.Admin.Dao
{
    public class ProductDao
    {
		ProjectShopAPIContext db;

		public ProductDao(ProjectShopAPIContext _db)
		{
			db = _db;
		}
		public bool ChangeStatus(long id)
		{
			var cate = db.Products.SingleOrDefault(x => x.ProductId == id);
			cate.IsDelete = !cate.IsDelete;
			db.SaveChanges();
			return cate.IsDelete;
		}
	}
}
