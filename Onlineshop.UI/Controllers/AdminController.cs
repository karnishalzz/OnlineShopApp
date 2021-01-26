using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.ProductsAdmin;
using OnlineShop.Application.StockAdmin;
using Shop.Database;

namespace Onlineshop.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("products")]
        public IActionResult GetProducts() => Ok(new GetProducts(_context).Do());

        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id) => Ok(new GetProduct(_context).Do(id));
        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody]  CreateProduct.Request req) 
            => Ok(await new CreateProduct(_context).Do(req));

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct([FromBody]UpdateProduct.Request request) 
            => Ok( await new UpdateProduct(_context).Do(request));

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok(await new DeleteProduct(_context).Do(id));




        [HttpGet("stocks")]
        public IActionResult GetStocks() => Ok(new GetStock(_context).Do());

        [HttpPost("stocks")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStock.Request req)
            => Ok(await new CreateStock(_context).Do(req));

        [HttpPut("stocks")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStock.Request request)
            => Ok(await new UpdateStock(_context).Do(request));

        [HttpDelete("stocks/{id}")]
        public async Task<IActionResult> DeleteStocks(int id) => Ok(await new DeleteStock(_context).Do(id));


    }
}
