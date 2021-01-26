using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
