using Newtonsoft.Json;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Application.Cart
{
    public class AddToCart
    {
        private ISession _session;
        public AddToCart(ISession session)
        {
            _session = session;
        }
        public class Request
        {
            public int StockId { get; set; }
            public int Qty { get; set; }
        }
        public void Do(Request request)
        {
            var cartList = new List<CartProduct>();
            var stringObject = _session.GetString("cart");

            if (!string.IsNullOrEmpty(stringObject))
            {
                cartList= JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);
            }

            if (cartList.Any(x => x.StockId == request.StockId))
            {
                cartList.Find(x => x.StockId == request.StockId).Oty += request.Qty;
            }
            else
            {
                cartList.Add(new CartProduct
                {
                    StockId=request.StockId,
                    Oty=request.Qty
                });
            }
          
            stringObject = JsonConvert.SerializeObject(cartList);
            
            _session.SetString("cart", request);
        }
    }
}
