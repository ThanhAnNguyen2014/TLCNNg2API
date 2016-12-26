using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNShopCore.EF;
using Microsoft.AspNetCore.Http;

namespace ProjectTLCNShopCore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private readonly ProjectShopAPIContext _context;

		public HomeController(ProjectShopAPIContext context)
		{
			_context = context;
		}
		// GET: /<controller>/
		public IActionResult Index()
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
	}
}