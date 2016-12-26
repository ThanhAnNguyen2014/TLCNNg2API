using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNShopCore.EF;
using ProjectTLCNShopCore.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;

namespace ProjectTLCNShopCore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LoginController : Controller
	{
		private readonly ProjectShopAPIContext _context;

		public LoginController(ProjectShopAPIContext context)
		{
			_context = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(UserLogin userlogin)
		{
			if (userlogin.Email == null || userlogin.Password == null)
			{
				ViewBag.Error = "Please enter Email or Password!";
			}
			else
			{
				var account = _context.Admin.Where(x => x.Email == userlogin.Email && x.Password == userlogin.Password).FirstOrDefault();
				if (account != null)
				{
					HttpContext.Session.SetString("UserID", account.AdminId.ToString());
					HttpContext.Session.SetString("Email", account.Email.ToString());
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ViewBag.Error = "Email or Password is wrong!. ";

				}
			}
			return View();
		}
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index");
		}
	}
}
