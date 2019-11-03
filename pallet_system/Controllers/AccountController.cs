using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pallet_system.Controllers
{
    /// <summary>
    /// TODO: Add authentication
    /// </summary>
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}