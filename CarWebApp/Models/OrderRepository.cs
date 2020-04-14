using CarWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebApp.Models
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();
            foreach (var itemCart in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = itemCart.Quantity,
                    CarId = itemCart.Car.CarId,
                    Price = itemCart.Car.Price
                };

                order.OrderDetails.Add(orderDetail);
            }
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
        }
    }
}
