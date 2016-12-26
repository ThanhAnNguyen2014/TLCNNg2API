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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectTLCNShopCore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductsController : Controller
	{
		private IHostingEnvironment _environment;
		private readonly ProjectShopAPIContext _context;

		public ProductsController(ProjectShopAPIContext context, IHostingEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}
		// GET: Products
		public async Task<IActionResult> Index()
		{
			//var model = _context.Products.Include(p => p.Category).Include(p => p.Supplier);
			return View(await _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToListAsync());
		}



		// GET: Products/Details/5
		[HttpGet("Admin/Products/Details/{id}")]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var products = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
			var category = await _context.Categories.SingleOrDefaultAsync(m => m.CategoryId == products.CategoryId);
			var supplier = await _context.Suppliers.SingleOrDefaultAsync(m => m.SupplierId == products.SupplierId);
			ViewData["catename"] = category.CategoryName;
			ViewData["supplier"] = supplier.CompanyName;

			if (products == null)
			{
				return NotFound();
			}

			return View(products);
		}

		// GET: Products/Create
		public IActionResult Create()
		{
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");

			return View();
		}

		// POST: Products/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ProductId,AvgRating,CategoryId,Discontinued,Discount,IsDelete,IsNew,Note,Picture,ProductName,ReorderLevel,SupplierId,UnitPrice,UnitsInStock")] Products products, ICollection<IFormFile> files)
		{
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);

			string tempImageURL = "";
			if (ModelState.IsValid)
			{
				var uploads = Path.Combine(_environment.WebRootPath, "Image/products");
				foreach (var file in files)
				{
					if (file != null)
					{
						string URL = uploads + "/" + file.FileName;
						Bitmap img = convertImage.ResizeImage(Image.FromStream(file.OpenReadStream(), true, true), 600, 600);
						img.Save(URL);
						tempImageURL += "/Image/products/" + file.FileName + ";";
					}
				}
				products.Discontinued = false;
				products.IsNew = true;
				products.IsDelete = false;
				products.AvgRating = 0;
				products.Picture = tempImageURL;
				_context.Add(products);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(products);
		}

		// GET: Products/Edit/5
		[HttpGet("Admin/Products/Edit/{id}")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var products = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
			if (products == null)
			{
				return NotFound();
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
			return View(products);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost("Admin/Products/Edit/{id}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id,
			[Bind("ProductId,AvgRating,CategoryId,Discontinued,Discount,IsDelete,IsNew,Note,Picture,ProductName,ReorderLevel,SupplierId,UnitPrice,UnitsInStock")] Products products,
			ICollection<IFormFile> files)
		{

			string tempImageURL = "";
			var product = _context.Products.SingleOrDefault(m => m.ProductId == id);
			if (ModelState.IsValid)
			{
				try
				{
					if (product != null)
					{
						var uploads = Path.Combine(_environment.WebRootPath, "Image/products");
						foreach (var file in files)
						{
							if (file != null)
							{
								string URL = uploads + "/" + file.FileName;
								Bitmap img = convertImage.ResizeImage(Image.FromStream(file.OpenReadStream(), true, true), 400, 400);
								img.Save(URL);
								tempImageURL += "/Image/products/" + file.FileName + ";";
							}
						}
						product.ProductName = products.ProductName;
						product.Note = products.Note;
						product.Picture = tempImageURL;
						product.CategoryId = products.CategoryId;
						product.UnitPrice = products.UnitPrice;
						product.UnitsInStock = products.UnitsInStock;
						product.Discount = products.Discount;
						product.SupplierId = products.SupplierId;
						product.ReorderLevel = products.ReorderLevel;
						product.Discontinued = false;
						product.IsNew = true;
						product.IsDelete = false;
						product.AvgRating = 0;
						_context.Update(product);
						await _context.SaveChangesAsync();
						return RedirectToAction("Index");
					}
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductsExists(products.ProductId))
					{
						return NotFound();
					}
					else
					{
						return RedirectToAction("Error");
					}
				}
			}
			ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
			ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
			return View(products);
		}

		// GET: Products/Delete/5
		[HttpGet("Admin/Products/Delete/{id}")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var products = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
			_context.Products.Remove(products);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		//// change Status
		[HttpPost("Admin/Products/ChangeIsDisplay/{id}")]
		public JsonResult ChangeIsDisplay(long id)
		{
			var result = new ProductDao(_context).ChangeStatus(id);
			return Json(new
			{
				status = result
			});
		}

		private bool ProductsExists(int id)
		{
			return _context.Products.Any(e => e.ProductId == id);
		}
	}
}
