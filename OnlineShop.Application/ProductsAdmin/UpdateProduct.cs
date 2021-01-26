using OnlineShop.Domain.Models;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductsAdmin
{
    public class UpdateProduct
    {
        private ApplicationDbContext _context;

        public UpdateProduct(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Do(Request model)
        {

            var product = _context.Products.FirstOrDefault(x => x.Id == model.Id);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = decimal.Parse(model.Price);

     
            await _context.SaveChangesAsync();
            return new Response()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
        public class Request
        {
            public int Id { get; set; }
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
