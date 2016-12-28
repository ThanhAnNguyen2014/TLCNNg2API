using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNShopCore.EF;
using Microsoft.EntityFrameworkCore;
using ProjectTLCNShopCore.Areas.Admin.Dao;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTLCNShopCore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UsersController : Controller
	{
		private readonly ProjectShopAPIContext _context;

		public UsersController(ProjectShopAPIContext context)
		{
			_context = context;
		}

		// GET: Users
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View(await _context.Users.ToListAsync());
		}

		// GET: Users/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			if (id == null)
			{
				return NotFound();
			}

			var users = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
			if (users == null)
			{
				return NotFound();
			}

			return View(users);
		}

		// GET: Users/Create
		public IActionResult Create()
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}

		// POST: Users/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("UserId,AvatarPicture,Birthday,CoverPicture,Email,FirstName,IsActive,LastName,Looked,Lpoint,Password,PhoneNumber,ReferUserId,Sex,Token")] Users users)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			if (ModelState.IsValid)
			{
				_context.Add(users);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(users);
		}

		// GET: Users/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			if (id == null)
			{
				return NotFound();
			}

			var users = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
			if (users == null)
			{
				return NotFound();
			}
			return View(users);
		}

		// POST: Users/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("UserId,AvatarPicture,Birthday,CoverPicture,Email,FirstName,IsActive,LastName,Looked,Lpoint,Password,PhoneNumber,ReferUserId,Sex,Token")] Users users)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			if (id != users.UserId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(users);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!UsersExists(users.UserId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("Index");
			}
			return View(users);
		}

		// GET: Users/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			if (id == null)
			{
				return NotFound();
			}

			var users = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
			if (users == null)
			{
				return NotFound();
			}

			return View(users);
		}

		// POST: Users/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			var users = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
			_context.Users.Remove(users);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		// Lock User
		[HttpPost("Admin/Users/ChangeIsDisplay/{id}")]
		public JsonResult ChangeIsDisplay(long id)
		{
			var result = new UserDao(_context).ChangeStatus(id);
			return Json(new
			{
				status = result
			});
		}

		private bool UsersExists(int id)
		{
			return _context.Users.Any(e => e.UserId == id);
		}
	}
}
