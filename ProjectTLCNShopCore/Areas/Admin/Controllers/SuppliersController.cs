using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNShopCore.EF;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTLCNShopCore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SuppliersController : Controller
	{
		private readonly ProjectShopAPIContext _context;

		public SuppliersController(ProjectShopAPIContext context)
		{
			_context = context;
		}

		// GET: Suppliers
		public async Task<IActionResult> Index()
		{
			return View(await _context.Suppliers.ToListAsync());
		}

		// GET: Suppliers/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var suppliers = await _context.Suppliers.SingleOrDefaultAsync(m => m.SupplierId == id);
			if (suppliers == null)
			{
				return NotFound();
			}

			return View(suppliers);
		}

		// GET: Suppliers/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Suppliers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("SupplierId,Address,City,CompanyName,ContactName,Country,Fax,HomePage,Phone")] Suppliers suppliers)
		{
			if (ModelState.IsValid)
			{
				_context.Add(suppliers);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(suppliers);
		}

		// GET: Suppliers/Edit/5
		[HttpGet("Admin/Suppliers/Edit/{id}")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var suppliers = await _context.Suppliers.SingleOrDefaultAsync(m => m.SupplierId == id);
			if (suppliers == null)
			{
				return NotFound();
			}
			return View(suppliers);
		}

		// POST: Suppliers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[ValidateAntiForgeryToken]
		[HttpPost("Admin/Suppliers/Edit/{id}")]
		public async Task<IActionResult> Edit(int id, [Bind("SupplierId,Address,City,CompanyName,ContactName,Country,Fax,HomePage,Phone")] Suppliers suppliers)
		{
			var supp = _context.Suppliers.SingleOrDefault(m => m.SupplierId == id);
			supp.CompanyName = suppliers.CompanyName;
			supp.Address = suppliers.Address;
			supp.City = suppliers.City;
			supp.ContactName = suppliers.ContactName;
			supp.Country = suppliers.Country;
			supp.Fax = suppliers.Fax;
			supp.HomePage = suppliers.HomePage;
			supp.Phone = suppliers.Phone;

			_context.Update(supp);
			await _context.SaveChangesAsync();


			return RedirectToAction("Index");

		}

		// GET: Suppliers/Delete/5
		[HttpGet("Admin/Suppliers/Delete/{id}")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var suppliers = await _context.Suppliers.SingleOrDefaultAsync(m => m.SupplierId == id);
			if (suppliers == null)
			{
				return NotFound();
			}
			_context.Suppliers.Remove(suppliers);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");

		}



		private bool SuppliersExists(int id)
		{
			return _context.Suppliers.Any(e => e.SupplierId == id);
		}
	}
}
