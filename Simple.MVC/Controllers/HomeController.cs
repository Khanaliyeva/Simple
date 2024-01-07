using Microsoft.AspNetCore.Mvc;
using Simple.Business.Services.Interfaces;
using Simple.Core.Entities;
using Simple.DAL.Context;
using Simple.MVC.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Simple.MVC.Controllers
{
    public class HomeController : Controller
    {


        private readonly ICartService _service;

        public HomeController(ICartService cartService)
        {
            _service = cartService;
        }

        public async Task<IActionResult> Index()
        {
             ICollection<Cart> Carts = await _service.GetAllAsync();
            return View(Carts);
        }
    }
}


