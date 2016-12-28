using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelUser
{
    public class AddressModel
    {
		public SelectList CityID { get; set; }
		public SelectList DistrictID { get; set; }
		public SelectList WardID { get; set; }
		public string CityIDValue { get; set; }
		public string DistrictIDValue { get; set; }
		public string WardIDValue { get; set; }
	}
}
