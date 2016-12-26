using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTLCNShopCore.EF;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTLCNShopCore.Controllers
{
	[Route("api/[controller]")]
	public class categoriesController : Controller
	{
		ProjectShopAPIContext _context;
		public categoriesController(ProjectShopAPIContext context)
		{
			_context = context;
		}
		// GET: api/values
		[HttpGet]
		public JsonResult Get()
		{
			var categorie = _context.Categories.Where(x => x.IsDisplay == true && x.DisplayOrder > 0).ToList();


			return Json(categorie);
		}

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
	}
}
