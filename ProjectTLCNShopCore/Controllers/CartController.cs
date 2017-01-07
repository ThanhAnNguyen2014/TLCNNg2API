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
using ProjectTLCNShopCore.DaoDB;

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
			cartvm.TotalPrice = cart.ComputeTotalValue();
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
		public IActionResult CartNull()
		{
			return new JsonResult(new { message = "You have no items in your shopping cart" });
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

		[HttpPost("getcheckout")]
		public IActionResult CheckOutGet([FromBody] CheckOutInfor imv)
		{

			decimal discount, total=0;
			Customers selectCustomer = new Customers();
			Customers newCustomer = new Customers();
			Orders order = new Orders();
			if (imv != null)
			{

				imv.IsNewCustomer = true;
				// Neu Chua login
				newCustomer = imv.newCustomer;
				newCustomer.UserId = 2; // default guest(userid=2)
				newCustomer.IsDeleted = false;
				newCustomer.IsDefault = false;
				newCustomer.CustomerId = imv.newCustomer.CustomerId;
				var custom = new MyDao(_context).AddCustomer(newCustomer);
				if(custom)
				{
					selectCustomer = newCustomer;
					order.Email = imv.order.Email;
				}
				else
				{
					return new JsonResult(new { Message = "Server Error! Customer unsaved!" });
				}
				//lấy giỏ hàng
				CartViewModel cartvm = new CartViewModel();
				cartvm.Cart = cart;
				cartvm.TotalPrice = cart.ComputeTotalValue();
				if (cart.Lines.Count() == 0 || cartvm.TotalPrice == "0,000 VNĐ")
				{
					return RedirectToAction("CartNull");
				}
				else
				{
					imv.Carts = cartvm;
				}
				foreach (var i in cart.Lines)
				{
					Products product = _context.Products.Where(n => n.ProductId == i.Product.ProductID && n.IsDelete == false).FirstOrDefault();
					discount = product.UnitPrice.Value - (product.Discount.Value * product.UnitPrice.Value) / 100; // tinh so tien giam gia
					total = total+ discount;
				}
				// Luu thong tin order
				order.CustomerId = selectCustomer.CustomerId;
				order.OrderDate = DateTime.Now;
				order.ShipName = selectCustomer.FullName;
				order.ShipPhone = selectCustomer.Phone;
				order.ShipAddress = selectCustomer.Address;
				order.Freight = 20000; // phi van chuyen mat dinh
				order.Note = "";// mat dinh khong ghi chu
				order.PaymentMethodId = 1;// mat dinh thanh toan la 1
				order.IsPaid = false;
				order.TotalDiscount = total;
				//order.TotalDiscount=cartvm.TotalPrice
				var od = new MyDao(_context).AddOrder(order);
				decimal totalPrice = 0;
				if (od)
				{
					int orderid = order.OrderId;
					
					foreach (var i in cart.Lines)
					{
						OrderDetails orderdetail = new OrderDetails();
						orderdetail.OrderId = orderid;
						orderdetail.ProductId = i.Product.ProductID;
						orderdetail.Quantity = short.Parse(i.Quantity.ToString());
						orderdetail.UnitPrice = decimal.Parse(i.Product.UnitPrice.ToString());
						orderdetail.Discount = float.Parse(i.Product.Discount.ToString());
						if(new MyDao(_context).AddOrderDetail(orderdetail))
						{
							totalPrice += orderdetail.Quantity * orderdetail.UnitPrice;
							Products product = _context.Products.Where(n => n.ProductId == i.Product.ProductID && n.IsDelete == false).FirstOrDefault();
							product.UnitsInStock = short.Parse((product.UnitsInStock - orderdetail.Quantity).ToString());
							_context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
							_context.SaveChanges();
						}
						else
						{
							return new JsonResult(new { message = "Error saving order information!" });
						}
						


					}
					order.TotalPrice = totalPrice + order.Freight - order.TotalDiscount;
					_context.Orders.Update(order);
					_context.SaveChanges();
					return Ok(200);
				}
				else
				{
					return new JsonResult(new { Message = "Server Error!" });
				}
			}
			else
			return new JsonResult(new { Message = "Server Error!" });
		}
		//public IActionResult CheckOutGet([FromBody] InforCheckoutCustomer inforCus)
		//{
		//	CheckOutInfor checkoutinfor = new CheckOutInfor();
		//	Customers selectCustomer = new Customers();
		//	Customers newCustomer = new Customers();
		//	Orders order = new Orders();
		//	OrderDetails orderDetail = new OrderDetails();
		//	if (ModelState.IsValid)
		//	{
		//		if (inforCus != null)
		//		{

		//			checkoutinfor.IsNewCustomer = true;
		//			checkoutinfor.newCustomer.FullName = inforCus.name;
		//			checkoutinfor.newCustomer.Phone = inforCus.phone;
		//			newCustomer = checkoutinfor.newCustomer;
		//			// Neu chua dang nhap
		//			newCustomer.UserId = 2; // default guest
		//			newCustomer.IsDeleted = false;
		//			newCustomer.IsDefault = false;
		//			var result = new MyDao(_context).AddCustomer(newCustomer);
		//			if (result)
		//			{
		//				return new JsonResult(new { message = "Save Success!" });
		//			}
		//		}



		//		return new JsonResult(new { message = "CheckOut Success!, Thank you!" });
		//	}

		//	return new JsonResult(new { message = "You have not entered information!" });
		//}
		[HttpGet("getcheckout")]
		public IActionResult CheckOut()
		{
			CheckOutInfor infor = new CheckOutInfor();
			// get Cart 
			CartViewModel cartvm = new CartViewModel();
			cartvm.Cart = cart;
			cartvm.TotalPrice = cart.ComputeTotalValue();
			infor.Carts = cartvm;
			return new JsonResult(infor);
		}
		[HttpPost("addcustomer")]
		public IActionResult AddCustomer([FromBody] Customers custom)
		{
			if (custom != null)
			{
				Customers cus = new Customers();
				cus.FullName = custom.FullName;
				cus.Address = custom.Address;
				cus.Phone = custom.Phone;
				//cus.IsDefault = false;
				cus.IsDeleted = false;
				cus.UserId = 2;
				_context.Customers.Add(cus);
				_context.SaveChanges();
				return new JsonResult(new { message = "Success!" });
			}
			return new JsonResult(new { message = "Error!" });
		}
	}
}