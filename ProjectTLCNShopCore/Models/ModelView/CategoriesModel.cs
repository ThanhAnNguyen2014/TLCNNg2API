using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelView
{
    public class CategoriesModel
    {
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public string Picture { get; set; }
		public CategoriesModel(int id, string CataName, string Des, string Pictr)
		{
			CategoryId = id;
			CategoryName = CataName;
			Description = Des;
			Picture = Pictr;

		}
		public CategoriesModel() { }
	}
}
