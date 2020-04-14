using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApp.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;

       
        /// Injecting Role Manager
        
        
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}