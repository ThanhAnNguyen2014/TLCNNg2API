using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNShopCore.EF;
using ProjectTLCNShopCore.Repository;
using ProjectTLCNShopCore.Models.ModelCart;
using Microsoft.AspNetCore.Http;
using ProjectTLCNShopCore.Infrastructure;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace ProjectTLCNShopCore.Controllers
{
	[Route("api/[controller]")]
	public class CartController : Controller
    {
		ProjectShopAPIContext _context;

		List<Products> Productsrepo = new List<Products>();
		public CartController(ProjectShopAPIContext context)
		{
			_context = context;
			

		}
		[HttpPost("addtocart/{id}")]
		public RedirectToActionResult AddToCart(int productId)
		{
			Products product = Productsrepo.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				Cart cart = GetCart();
				cart.AddItem(product, 1);
				SaveCart(cart);
			}
			return RedirectToAction("Index");
		}
		private Cart GetCart()
		{
			Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
			return cart;
		}
		private void SaveCart(Cart cart)
		{
			HttpContext.Session.SetJson("Cart", cart);
		}
		[HttpGet("getCart")]
		public IActionResult Index()
		{
			return new JsonResult(new {
				Cart = GetCart()
			});
		}
		
		
	}
}