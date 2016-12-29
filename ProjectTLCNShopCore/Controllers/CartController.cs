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
using AutoMapper;
using ProjectTLCNShopCore.Models.ModelView;

namespace ProjectTLCNShopCore.Controllers
{
	[Route("api/[controller]")]
	public class CartController : Controller
    {
		ProjectShopAPIContext _context;
		private readonly IMapper _mapper;
		//List<Products> Productsrepo = new List<Products>();
		public CartController(ProjectShopAPIContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
			

		}
		[HttpGet("addtocart/{id}")]
		public RedirectToActionResult AddToCart(int id)
		{
			Products product = _context.Products.FirstOrDefault(p => p.ProductId == id);
			ProductModel productModel= _mapper.Map<ProductModel>(product);
			if (product != null)
			{
				Cart cart = GetCart();
				cart.AddItem(productModel, 1);
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
			return new JsonResult(new {Cart=GetCart() });
		}
		
		
	}
}