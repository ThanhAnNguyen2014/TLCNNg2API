using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNShopCore.EF;
using Microsoft.AspNetCore.Http;
using ProjectTLCNShopCore.Models.ModelView;
using AutoMapper;
using ProjectTLCNShopCore.Models.ModelContact;
using ProjectTLCNShopCore.DaoDB;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTLCNShopCore.Controllers
{
	[Route("api/[controller]")]
	public class apiController : Controller
	{
		ProjectShopAPIContext _context;
		private readonly IMapper _mapper;
		public apiController(ProjectShopAPIContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;

		}
		// Nhận tất cả các loại sản phẩm
		[HttpGet("getcategory")]
		public IActionResult Get()
		{
			List<Categories> categorie = _context.Categories.Where(x => x.IsDisplay == true && x.DisplayOrder > 0).ToList();
			if (categorie.Count == 0)
			{
				return new JsonResult(new { CategoryId="-9999" });
			}
			return new JsonResult(_mapper.Map<List<CategoriesModel>>(categorie));
		}

		// nhận các sản phẩn nằm trong một loại sản phẩm
		[HttpGet("productcate/{id}")]
		public IActionResult productcate(int id)
		{
			//List<ProductModel> product = new List<ProductModel>();
			List<Products> item = _context.Products.Where(x => x.CategoryId == id).ToList();
			if (item.Count == 0)
			{
				return new JsonResult(new { productID = "-9999" });
			}
			return new JsonResult(_mapper.Map<List<ProductModel>>(item));
		}
        // nhận thông tin contact
        [HttpPost("getcontact")]
        public IActionResult GetContactInfor([FromBody] Contact contact)
        {
            return new JsonResult(new { message = "success!" });
        }
        // lấy thông tin sản phẩm theo Id
        [HttpGet("product/{id}")]
        public IActionResult GetProduct(int id)
        {
            var pro = new MyDao(_context).GetProduct(id);
            if (pro != null)
            {
                return new JsonResult(_mapper.Map<ProductModel>(pro));
            }
            return new JsonResult(new { productID = "-9999" });
        }

    }
}
