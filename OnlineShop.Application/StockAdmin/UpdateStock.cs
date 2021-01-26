using OnlineShop.Domain.Models;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.StockAdmin
{
    public class UpdateStock
    {
        private ApplicationDbContext _context;

        public UpdateStock(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Do(Request model)
        {

            var stocks = new List<Stock>();
            foreach(var i in model.Stock)
            {
                stocks.Add(new Stock
                {
                    Id=i.Id,
                    Name=i.Name,
                    Qty=i.Qty,
                    ProductId=i.ProductId,
                });
            }
            _context.Stocks.UpdateRange(stocks);
            await _context.SaveChangesAsync();
            return new Response()
            {
                Stock=model.Stock
            };
        }
        public class StockViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
        }
        public class Request
        {
           public IEnumerable<StockViewModel> Stock { get; set; }
        }
        public class Response
        {
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
    
}
