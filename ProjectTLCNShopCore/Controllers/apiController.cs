using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNShopCore.EF;
using Microsoft.AspNetCore.Http;
using ProjectTLCNShopCore.Models.ModelView;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTLCNShopCore.Controllers
{
    [Route("api/[controller]")]
    public class apiController : Controller
    {
		//// GET: api/values
		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//    return new string[] { "value1", "value2" };
		//}

		//// GET api/values/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//    return "value";
		//}

		//// POST api/values
		//[HttpPost]
		//public void Post([FromBody]string value)
		//{
		//}

		//// PUT api/values/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody]string value)
		//{
		//}

		//// DELETE api/values/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
		ProjectShopAPIContext _context;
		private readonly IMapper _mapper;
		public apiController(ProjectShopAPIContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;

		}
		// Nhận tất cả các loại sản phẩm
		[HttpGet]
		public IActionResult Get()
		{
			List<Categories> categorie = _context.Categories.Where(x => x.IsDisplay == true && x.DisplayOrder > 0).ToList();
			if (categorie.Count == 0)
			{
				return NotFound( new { Message = "Not Found Product!" });
			}
			return new JsonResult(_mapper.Map<List<CategoriesModel>> (categorie));
		}

		// nhận các sản phẩn nằm trong một loại sản phẩm
		[HttpGet("productcate/{id}")]
		public IActionResult productcate(int id)
		{
			//List<ProductModel> product = new List<ProductModel>();
			List<Products> item = _context.Products.Where(x => x.CategoryId == id).ToList();
			if(item.Count==0)
			{
				return NotFound(new { Message = "Not Found Product!" });
			}
			return new JsonResult(_mapper.Map<List<ProductModel>>(item));
		}
	}
}
