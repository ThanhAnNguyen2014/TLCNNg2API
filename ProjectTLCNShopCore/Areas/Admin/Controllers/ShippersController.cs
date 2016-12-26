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
	public class ShippersController : Controller
	{
		private readonly ProjectShopAPIContext _context;

		public ShippersController(ProjectShopAPIContext context)
		{
			_context = context;
		}

		// GET: Shippers
		public async Task<IActionResult> Index()
		{
			return View(await _context.Shippers.ToListAsync());
		}

		// GET: Shippers/Details/5
		[HttpGet("Admin/Shippers/Details/{id}")]
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var shippers = await _context.Shippers.SingleOrDefaultAsync(m => m.ShipperId == id);
			if (shippers == null)
			{
				return NotFound();
			}

			return View(shippers);
		}

		// GET: Shippers/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Shippers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Create([Bind("ShipperId,CompanyName,Description,Phone")] Shippers shippers)
		{
			if (ModelState.IsValid)
			{
				_context.Add(shippers);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(shippers);
		}

		// GET: Shippers/Edit/5
		[HttpGet("Admin/Shippers/Edit/{id}")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var shippers = await _context.Shippers.SingleOrDefaultAsync(m => m.ShipperId == id);
			if (shippers == null)
			{
				return NotFound();
			}
			return View(shippers);
		}

		// POST: Shippers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

		[ValidateAntiForgeryToken]
		[HttpPost("Admin/Shippers/Edit/{id}")]
		public async Task<IActionResult> Edit(int id, [Bind("ShipperId,CompanyName,Description,Phone")] Shippers shippers)
		{
			var shipper = _context.Shippers.SingleOrDefault(m => m.ShipperId == id);
			shipper.CompanyName = shippers.CompanyName;
			shipper.Description = shippers.Description;
			shipper.Phone = shippers.Phone;
			_context.Update(shipper);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");

		}

		// GET: Shippers/Delete/5
		[HttpGet("Admin/Shippers/Delete/{id}")]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var shippers = await _context.Shippers.SingleOrDefaultAsync(m => m.ShipperId == id);
			if (shippers == null)
			{
				return NotFound();
			}
			_context.Shippers.Remove(shippers);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}


		private bool ShippersExists(int id)
		{
			return _context.Shippers.Any(e => e.ShipperId == id);
		}
	}
}
