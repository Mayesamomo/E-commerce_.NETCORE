using CarWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CarWebApp.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        public string ShoppingCartSessionId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartIdSession = session.GetString("cartIdSession") ?? Guid.NewGuid().ToString();

            session.SetString("cartIdSession", cartIdSession);

            return new ShoppingCart(context) { ShoppingCartSessionId = cartIdSession };
        }

        public void AddToCart(Car car, int quantity)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.FirstOrDefault(item => item.ShoppingCartSessionId == ShoppingCartSessionId &&
                                                                                                    item.Car.CarId == car.CarId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartSessionId = ShoppingCartSessionId,
                    Car = car,
                    Quantity = 1
                };
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }

            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Car car)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Car.CarId == car.CarId && s.ShoppingCartSessionId == ShoppingCartSessionId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localAmount = shoppingCartItem.Quantity;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartSessionId == ShoppingCartSessionId)
                           .Include(s => s.Car)
                           .ToList());
        }


        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartSessionId == ShoppingCartSessionId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartSessionId == ShoppingCartSessionId)
                .Select(c => c.Car.Price * c.Quantity).Sum();
            return total;
        }
    }
}
