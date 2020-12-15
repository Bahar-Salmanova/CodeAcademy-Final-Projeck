using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeClinic.Data;
using CodeClinic.Models;
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
        [Route("{action}")]
        public IActionResult Index()
        {
            ContactViewModel model = new ContactViewModel
            {
                Clients = _context.Clients.ToList(),
                Settings = _context.Settings.FirstOrDefault(),
                SettingLasts = _context.SettingLasts.ToList(),

                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Kontaktlarımız",
                    Links = new List<string>
                    {
                        "Ana Səhifə",
                        "Kontaktlar"}
                }  };


            return View(model);
        }

        [HttpPost]
        [Route("{action}")]
        public IActionResult Index(AboutPasient aboutPasient)
        {
            AboutPasient pasient = new AboutPasient
            {
                Name = aboutPasient.Name,
                Email = aboutPasient.Email,
                Telephone = aboutPasient.Telephone,
                About = aboutPasient.About
            };
            _context.AboutPasients.Add(pasient);
            _context.SaveChanges();

            return RedirectToAction("index");

        }



    } 
}
