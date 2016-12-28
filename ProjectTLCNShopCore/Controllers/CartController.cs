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
		private IProductRepository repository;
		public CartController(IProductRepository repo)
		{
			repository = repo;
		}
		public RedirectToActionResult AddToCart(int productId, string returnUrl)
		{
			Products product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				CartFull cart = GetCart();
				cart.AddItem(product, 1);

				SaveCart(cart);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
		public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
		{
			Products product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				CartFull cart = GetCart();
				cart.RemoveLine(product);
				SaveCart(cart);
			}
			return RedirectToAction("Index", new { returnUrl });
		}
		public JsonResult Index()
		{
			CartFull cart = GetCart();
			return Json(cart);
		}
		private CartFull GetCart()
		{
			CartFull cart = HttpContext.Session.GetJson<CartFull>("CartFull") ?? new CartFull();
			return cart;
		}
		private void SaveCart(CartFull cart)
		{
			HttpContext.Session.SetJson("CartFull", cart);
		}


		//public JsonResult Index()
		//{
		//	List<CartLine> cart = GetCart();
		//	return Json(cart);
		//}

		//private CartLine GetCart()
		//{
		//	//context.Session.SetString("key2", "value");
		//	//List<CartLine> listCarts = context.Session.GetString("key2") as Enumerable<CartLine>;
		//	//List<CartLine> cart = new List<CartLine>();
		//	CartLine cart = new CartLine();
		//	if (HttpContext.Session.IsExists("cart"))
		//	{
		//		cart = HttpContext.Session.Get<CartLine>("cart");
		//	}
		//	cart.ProductId = 1;
		//	cart.Quantity = 12000;
		//	List<CartLine> cartline = new List<CartLine>();
		//	cartline.Add(cart);
		//	HttpContext.Session.Set("cart", cart);
		//	return cart;
		//}
		/*private List<CartLine> GetCart()
		{
			List<CartLine> list = new List<CartLine>();
			CartLine cart = HttpContext.Session.GetJson<CartLine>("cart");
			if (cart == null)
			{
				// khoi tao gio hang
				cart = new CartLine() { ProductId = 1, Quantity = 1 };
				HttpContext.Session.SetJson("cart", cart);
				
			};
			//byte[] list = HttpContext.Session.Get("cart");
			//if(list!=null&& list.Length > 0)
			//{
			//	string json = System.Text.Encoding.UTF8.GetString(list);
			//	return JsonConvert.DeserializeObject<CartLine>(json);
			//	//cart = HttpContext.Session.Get("cart");
			//}
			//var cart = new List<CartLine>();
			//list.Add(new CartLine { ProductId = 1, Quantity = 12 });
			//list.Add(new CartLine { ProductId = 2, Quantity = 13 });
			//list.Add(new CartLine { ProductId = 3, Quantity = 1 });
			//list.Add(new CartLine { ProductId = 4, Quantity = 11 });	
			list.Add(cart);		
			return list;
		}*/
	}
}