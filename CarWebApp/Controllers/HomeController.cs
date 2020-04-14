using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarWebApp.Models;
using CarWebApp.VIewModels;
using CarWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CarWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Cars.Include(g => g.Manufacturer);
            return View(await appDbContext.ToListAsync());
        }
    }
}
