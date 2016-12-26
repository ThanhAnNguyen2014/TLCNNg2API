using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using ProjectTLCNShopCore.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProjectTLCNShopCore.Areas.Admin.Utili;
using System.Drawing;
using ProjectTLCNShopCore.Areas.Admin.Dao;
using System.IO;

namespace ProjectTLCNShopCore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategorieController : Controller
	{
		private IHostingEnvironment _environment;
		ProjectShopAPIContext db;
		public CategorieController(ProjectShopAPIContext _db, IHostingEnvironment environment)
		{
			db = _db;
			_environment = environment;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View(await db.Categories.ToListAsync());

		}
		[HttpGet]
		public IActionResult Create()
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
		[HttpPost]
		public IActionResult Create(Categories categorie, ICollection<IFormFile> files)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			string tempImageURL = "";

			if (ModelState.IsValid)
			{

				var uploads = Path.Combine(_environment.WebRootPath, "Image/categories");
				foreach (var file in files)
				{
					if (file != null)
					{
						string URL = uploads + "/" + file.FileName;
						Bitmap img = convertImage.ResizeImage(Image.FromStream(file.OpenReadStream(), true, true), 620, 740);
						img.Save(URL);
						tempImageURL += "/Image/categories/" + file.FileName;
					}
				}
				categorie.Picture = tempImageURL;
				db.Categories.Add(categorie);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(categorie);
		}
		[HttpPost("Admin/Categorie/Edit/{id}")]
		public IActionResult Edit(int id, Categories catego, ICollection<IFormFile> files)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			string tempImageURL = "";
			var categorie = db.Categories.SingleOrDefault(m => m.CategoryId == id);

			if (categorie != null)
			{
				var uploads = Path.Combine(_environment.WebRootPath, "Image/categories");
				foreach (var file in files)
				{
					if (file != null)
					{
						string URL = uploads + "/" + file.FileName;
						Bitmap img = convertImage.ResizeImage(Image.FromStream(file.OpenReadStream(), true, true), 400, 400);
						img.Save(URL);
						tempImageURL += "/Image/categories/" + file.FileName;

					}
				}
			}

			categorie.CategoryName = catego.CategoryName;
			categorie.Description = catego.Description;
			categorie.DisplayOrder = catego.DisplayOrder;
			categorie.IsDisplay = catego.IsDisplay;
			categorie.Picture = tempImageURL;
			db.Categories.Update(categorie);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		// delete
		// POST: Movies/Delete/5

		[HttpGet("Admin/Categorie/Edit/{id}")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			if (id == null)
				return NotFound();
			var model = await db.Categories.SingleOrDefaultAsync(m => m.CategoryId == id);
			if (model == null)
				return NotFound();
			return View(model);
		}

		// POST: Cars/Delete/5
		// Delete an object via a POST request
		[ActionName("Delete")]
		[HttpGet("Admin/Categorie/Delete/{id}")]
		public IActionResult Delete(int? id)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return RedirectToAction("Index", "Login");
			}
			var model = db.Categories.SingleOrDefault(m => m.CategoryId == id);
			// Remove the car from the collection and save changes
			db.Categories.Remove(model);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		//// change Status
		[HttpPost("Admin/Categorie/ChangeIsDisplay/{id}")]
		public JsonResult ChangeIsDisplay(long id)
		{
			if (HttpContext.Session.GetString("UserID") == null && HttpContext.Session.GetString("Email") == null)
			{
				return Json(new
				{
					status = 0
				});
			}
			var result = new CategorieDao(db).ChangeStatus(id);
			return Json(new
			{
				status = result
			});
		}

	}
}