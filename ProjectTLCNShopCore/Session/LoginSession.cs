using ProjectTLCNShopCore.Models.ModelUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTLCNShopCore.Session
{
	public class LoginSession
	{
		public UserInfor UserInfo { get; set; }
		public string getSessionId { get; set; }
		public string getUserId { get; set; }
		private LoginSession()
		{
			UserInfo = null;
			//getUserId=getSessionId=HttpContext.
		}
	}
	public class LoginAdminSession
	{
		//private static string sessionkey="Admin";

		public UserInfor userInfo { get; set; }
		private LoginAdminSession()
		{
			userInfo = null;
		}
		// get the current session
		//public static LoginAdminSession Current
		//{

		//	//get
		//	//{
		//	//	LoginAdminSession session = (LoginAdminSession)HttpContext.(ISession);
		//	//	if (session==null)
		//	//	{
		//	//		session = new LoginAdminSession();
		//	//		HttpContext.Session.SetString("__LoginAdminSession__","admin") = session;
		//	//	}
		//	//	return session;
		//	//}
		//	const string sessionkey = "Admin";
		//}
		//public static LoginAdminSession Current
		//{

		//	get {
		//		var value = HttpContext..GetString(sessionkey);
		//		return value;
		//	} 
		//}
	}
}
