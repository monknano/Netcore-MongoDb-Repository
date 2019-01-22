using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExRepository.Models;
using ExRepository.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace ExRepository.Controllers {

	[Route("api/[controller]")]
	public class ProductController : Controller {
		private readonly IProductRepository productRepository;

		public ProductController(IProductRepository productRepository) {
			this.productRepository = productRepository;
		}
		// GET 
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get() {
			var result = this.productRepository.AsQueryable();
			return new OkObjectResult(result);
		}

		// GET
		[HttpGet("{id}")]
		public ActionResult<string> Get(string id) {
			var result = this.productRepository.GetById(id);
			return new OkObjectResult(result);
		}

		// POST 
		[HttpPost]
		public async Task<IActionResult> Post(ProductModel model) {
			try
			{
				await this.productRepository.AddAsync(model);
				return Ok();
			} catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}


		}

		// PUT 
		[HttpPut]
		public async Task<IActionResult> Put(ProductModel model) {
			try
			{
				await this.productRepository.UpdateAsync(model);
				return Ok();
			} catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE 
		[HttpDelete("{id}")]
		public void Delete(string id) => this.productRepository.Delete(id);

		//get by guid
		[HttpGet("getguid/{guid}")]
		public async Task<IActionResult> GetByGuId(string guid)
		{
			try
			{
				var result =await this.productRepository.GetByFieldAsync("GuId", guid);
				return Ok(result);
			}catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// get by product name
		[HttpGet("name")]
		public async Task<IActionResult> GetByName(string name)
		{
			try
			{
				var result = await this.productRepository.WhereAsync(x => x.Product == name);
				return Ok(result);
			}catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		
    }
}