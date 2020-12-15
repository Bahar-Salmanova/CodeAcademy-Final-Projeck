using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeClinic.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CodeClinic.Areas.Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
