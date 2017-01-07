using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Models.ModelUser
{
	public class UserInforAuth0
	{
		public string name { get; set; }
		public string email { get; set; }
		public string picture { get; set; }
		public string gender { get; set; }
		public DateTime created_at { get; set; }
	}
}
