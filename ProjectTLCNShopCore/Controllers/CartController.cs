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
		private Cart cart;
		public CartController(ProjectShopAPIContext context, IMapper mapper, Cart cartService)
		{
			_context = context;
			_mapper = mapper;
			cart = cartService;
		}

		[HttpGet("getcart")]
		public IActionResult Index()
		{
			CartViewModel cartvm = new CartViewModel();
			cartvm.Cart = cart;
			cartvm.TotalPrice = cart.ComputeTotalValue().GetValueOrDefault().ToString("c");
			return new JsonResult(cartvm);
		}
		/*	public IActionResult Index()
			{
				return new JsonResult(new { Cart = GetCart() });
			}*/

		// them san pham vao Cart
		[HttpGet("addtocart/{id}")]
		public RedirectToActionResult AddToCart(int id)
		{
			Products product = _context.Products.FirstOrDefault(p => p.ProductId == id);
			
			if (product != null)
			{
				ProductModel productModel = _mapper.Map<ProductModel>(product);
				cart.AddItem(productModel, 1);
			}
			return RedirectToAction("Index");
		}
		/*	public RedirectToActionResult AddToCart(int id)
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
			}*/
		// Xoa so luong san pham da co trong Cart
		[HttpGet("removeproduct/{id}")]
		public RedirectToActionResult UpdateCart(int id)
		{
			Products product = _context.Products.FirstOrDefault(p => p.ProductId == id);
			
			if (product != null)
			{
				ProductModel productModel = _mapper.Map<ProductModel>(product);
				cart.RemoveItem(productModel);
			}
			return RedirectToAction("Index");
		}
		/*public RedirectToActionResult UpdateCart(int id)
		{
			Products product = _context.Products.FirstOrDefault(p => p.ProductId == id);
			ProductModel productModel = _mapper.Map<ProductModel>(product);
			if (product != null)
			{
				Cart cart = GetCart();
				cart.RemoveItem(productModel);
				SaveCart(cart);
			}
			return RedirectToAction("Index");
		}*/

		// xoa dong co chua san pham trong Cart
		[HttpGet("removelinecart/{id}")]
		public RedirectToActionResult RemoveFromCart(int id)
		{
			Products product = _context.Products.FirstOrDefault(p => p.ProductId == id);
			
			if (product != null)
			{
				ProductModel productModel = _mapper.Map<ProductModel>(product);
				cart.RemoveLine(productModel);
			}
			return RedirectToAction("Index");
		}
		// xoa cart
		[HttpGet("removecart")]
		public RedirectToActionResult RemoveCart()
		{
			cart.Clear();
			return RedirectToAction("Index");
		}
		/*public RedirectToActionResult RemoveFromCart(int id)
		{
			Products product = _context.Products.FirstOrDefault(p => p.ProductId == id);
			ProductModel productModel = _mapper.Map<ProductModel>(product);
			if (product != null)
			{
				Cart cart = GetCart();
				cart.RemoveLine(productModel);
				SaveCart(cart);
			}
			return RedirectToAction("Index");
		}*/
		/*private Cart GetCart()
		{
			Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
			return cart;
		}*/
		/*private void SaveCart(Cart cart)
		{
			HttpContext.Session.SetJson("Cart", cart);
		}*/


	}
}