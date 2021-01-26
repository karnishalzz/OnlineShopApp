using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineShop.Domain.Models;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Application.Cart
{
    public class GetCart
    {
        private ISession _session;
        private ApplicationDbContext _context;
        public GetCart(ISession session,ApplicationDbContext context)
        {
            _session = session;
            _context = context;
        }
        public class Response
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public int Qty { get; set; }
            public int StockId { get; set; }
            
        }
        public IEnumerable<Response> Do()
        {

            var stringObject = _session.GetString("cart");
            if (string.IsNullOrEmpty(stringObject))
                return new List<Response>();

            var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

            var response = _context.Stocks
                .Include(x => x.Product)
                .Where(x => cartList.Any(y=>y.StockId==x.Id))
                .Select(x => new Response
                {
                    Name = x.Product.Name,
                    Price = $"$ {x.Product.Price.ToString("N2")}",
                    StockId = x.Id,
                    Qty = cartList.FirstOrDefault(y=>y.StockId==x.Id).Oty,
                })
                .ToList();


            return response();
        }
    }
}
