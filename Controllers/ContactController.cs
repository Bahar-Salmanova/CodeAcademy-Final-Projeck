using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeClinic.Data;
using CodeClinic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeClinic.Controllers
{
    public class ContactController : Controller
    {
        private readonly ClinicDbContext _context;

        public ContactController(ILogger<ContactController> logger, ClinicDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            ContactViewModel model = new ContactViewModel
            {
                Clients = _context.Clients.ToList(),
                Settings = _context.Settings.FirstOrDefault(),
                SettingLasts = _context.SettingLasts.ToList(),
                BreadCrumb=new BreadCrumbViewModel
                {
                    Title="Kontaktlarımız",
                    Links=new List<string>
                    {
                        "Ana Səhifə",
                        "Kontaktlar"
                    }
                }
           };


            return View(model);
        }
    }
}
