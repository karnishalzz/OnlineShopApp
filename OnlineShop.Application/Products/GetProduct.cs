﻿using Microsoft.EntityFrameworkCore;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Application.Products
{
    public class GetProduct
    {
        private ApplicationDbContext _context;

        public GetProduct(ApplicationDbContext context)
        {
            _context = context;
        }
        public ProductViewModel Do(string name)=>
            _context.Products
                .Where(x=>x.Name==name)
                .Include(x=>x.Stock)
                .Select(x => new ProductViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Price = $"$ {x.Price.ToString("N2")}",
                    Stock=x.Stock.Select(y=>new StockViewModel
                    {
                        Id = y.Id,
                        Name = y.Name,
                        InStock = y.Qty>0
                    })
                    
                })
            .FirstOrDefault();
      
        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
        public class StockViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool InStock { get; set; }
        }
    }
}
