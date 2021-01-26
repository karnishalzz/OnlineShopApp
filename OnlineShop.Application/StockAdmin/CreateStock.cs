using OnlineShop.Domain.Models;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.StockAdmin
{
    public class CreateStock
    {
        private ApplicationDbContext _context;

        public CreateStock(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Do(Request model)
        {
            var stock= new Stock
            {
                Name = model.Name,
                Qty = model.Qty,
                ProductId =model.ProductId
            };

            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return new Response
            {
                Id=stock.Id,
                Name = stock.Name,
                Qty = stock.Qty.ToString(),
                ProductId = stock.ProductId.ToString()
            };
         
        }
        public class Request
        {
            public string Name { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
        }
        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Qty { get; set; }
            public string ProductId { get; set; }
        }
    }
    
}
