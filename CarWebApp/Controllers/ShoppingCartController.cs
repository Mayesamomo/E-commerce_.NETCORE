using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWebApp.Models;
using CarWebApp.VIewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ICarRepository carRepository, ShoppingCart shoppingCart)
        {
            _carRepository = carRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel();
            shoppingCartViewModel.ShoppingCart = _shoppingCart;
            shoppingCartViewModel.ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal();
            return View(shoppingCartViewModel);
        }
        public RedirectToActionResult AddToShoppingCart(int carId)
        {
            var car = _carRepository.GetCarById(carId);
            if (car != null)
            {
                _shoppingCart.AddToCart(car, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int carId)
        {
            var car= _carRepository.GetCarById(carId);
            if (car != null)
            {
                _shoppingCart.RemoveFromCart(car);
            }
            return RedirectToAction("Index");

        }
        public RedirectToActionResult ClearShoppingCart()
        {
            _shoppingCart.ClearCart();

            return RedirectToAction("Index");
        }
    }
}