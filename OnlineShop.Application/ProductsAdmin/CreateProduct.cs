using OnlineShop.Domain.Models;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductsAdmin
{
    public class CreateProduct
    {
        private ApplicationDbContext _context;

        public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Do(Request model)
        {
            var product= new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price =decimal.Parse(model.Price)
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new Response
            {
                Id=product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
         
        }
        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
        }
        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
    }
    
}
