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
using ProjectTLCNShopCore.Models.ModelUser;

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

		// Nhan thong tin nguoi dung
		[HttpPost("getuser")]
		public IActionResult GetUser([FromBody] UserInforAuth0 user)
		{
			if (user != null)
			{
				// kiem tra nguoi dung co phai la thanh vien da dang ky
				var member = _context.Users.Where(x => x.Email == user.email).FirstOrDefault();
				if (member != null)
				{
					return new JsonResult(new { message = "You are member!" });
				}
				Users us = new Users();
				us.Email = user.email;
				us.FirstName = user.name;
				us.AvatarPicture = user.picture;
				us.IsActive = true;
				us.Lpoint = 0;
				if (user.gender == "male")
				{
					us.Sex = true; // gioi tinh nam
				}
				else us.Sex = false;
				_context.Users.Add(us);
				_context.SaveChanges();
				return new JsonResult(new { message = "Save user Success!" });
			}
			return new JsonResult(new { message = "User Infor has error!" });
		}


		[HttpPost("postcheckout")]
		public IActionResult CheckOutGet([FromBody] CheckOutInfor imv)
		{

			decimal pricediscount, total = 0;
			Customers selectCustomer = new Customers();
			Customers newCustomer = new Customers();
			Orders order = new Orders();
			if (imv != null)
			{

				// kiem tra user co la thanh vien khong?
				if (new MyDao(_context).CheckUser(imv.order.Email))
				{
					// user is member.
					// da dang nhap
					newCustomer = imv.newCustomer;
					imv.IsNewCustomer = false;
					newCustomer.UserId = new MyDao(_context).GetId(imv.order.Email); // memeber
				}
				else
				{
					newCustomer = imv.newCustomer;
					imv.IsNewCustomer = true;
					// Neu Chua login					
					newCustomer.UserId = null; // default guest(userid=2)
				}


				newCustomer.IsDeleted = false;
				newCustomer.IsDefault = false;
				//newCustomer.CustomerId = imv.newCustomer.CustomerId;
				var custom = new MyDao(_context).AddCustomer(newCustomer);
				if (custom)
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
					pricediscount = (product.Discount.Value * product.UnitPrice.Value) / 100; // tinh so tien giam gia
					total = total + pricediscount; //tong so tien cua san pham sau khi giam gia
				}
				// Luu thong tin order
				order.CustomerId = selectCustomer.CustomerId;
				order.OrderDate = DateTime.Now;
				order.ShipName = selectCustomer.FullName;
				order.ShipPhone = selectCustomer.Phone;
				order.ShipAddress = selectCustomer.Address;
				order.Freight = 20000; // phi van chuyen mat dinh khi giao hang
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
						if (new MyDao(_context).AddOrderDetail(orderdetail))
						{
							totalPrice += orderdetail.Quantity * orderdetail.UnitPrice;
							// giam so luong san pham trong kho
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
					// deleted cart.
					cart.Clear();
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

	}
}