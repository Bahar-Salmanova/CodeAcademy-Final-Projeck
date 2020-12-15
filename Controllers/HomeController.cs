﻿using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CodeClinic.Data;
using CodeClinic.Models;
using CodeClinic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace CodeClinic.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ClinicDbContext _context;

        public HomeController( ClinicDbContext context)
        {
            _context = context;
            //_logger = logger;
        }

        public IActionResult Index()
        {    
            HomeViewModel model = new HomeViewModel
            {
                WelcomeClinic = _context.WelcomeClinics.ToList(),
                Promo = _context.Promos.Take(3).ToList(),
                ResearchClinic = _context.ResearchClinics.FirstOrDefault(),
                DiaqnosticServis = _context.DiaqnosticServis.Take(6).ToList(),
                Doctors = _context.Doctors.Include(d => d.DoctorTeamLinks).Take(4).ToList(),
                DoctorTeamLinks = _context.DoctorTeamLinks.Include(d => d.Doctor).ToList(),
                GetAppointment = _context.GetAppointments.FirstOrDefault(),
                Spesialities = _context.Spesialities.Take(4).ToList(),
                PatientSays = _context.PatientSays.ToList(),
                Checkups = _context.Checkups.Take(4).Include(c => c.CheckupSettings).ToList(),
                CheckupSettings = _context.CheckupSettings.Include(c => c.Checkup).ToList(),
                News = _context.News.Take(6).ToList(),
                Clients = _context.Clients.ToList(),
                Settings = _context.Settings.FirstOrDefault(),
                SettingLast = _context.SettingLasts.FirstOrDefault(),
              };
            return View(model);
        }
        
        [Route("{action}")]
        public IActionResult About()
        {
            AboutViewModel model = new AboutViewModel
            {
                ResearchClinic = _context.ResearchClinics.FirstOrDefault(),
                Spesialities = _context.Spesialities.Take(4).ToList(),
                
                GetAppointment = _context.GetAppointments.FirstOrDefault(),
                ClinicOpeningHours=_context.ClinicOpeningHours.ToList(),
                
               
                Doctors = _context.Doctors.Include(d => d.DoctorTeamLinks).ToList(),
                DoctorTeamLinks = _context.DoctorTeamLinks.Include(d => d.Doctor).ToList(),
                PatientSays = _context.PatientSays.Take(3).ToList(),
                Clients = _context.Clients.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Haqqımızda",
                    Links = new List<string>
                    {
                        "Ana Səhifə",
                        "Haqqımızda"
                    }

                }

            };
           return View(model);
        }

        [HttpPost]
        [Route("{action}")]
        public IActionResult About(AboutPasient aboutPasient)
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
            
        
            return Ok("Tezliklə sizə məlumat göndəriləcək.");
                
        }


        [Route("{action}")]
        public IActionResult Services()
        {
            ServisViewModel model = new ServisViewModel
            {
                DiaqnosticServis=_context.DiaqnosticServis.Take(3).ToList(),
                GetAppointment=_context.GetAppointments.FirstOrDefault(),
                Spesialities=_context.Spesialities.Take(4).ToList(),
                PatientSays=_context.PatientSays.Take(3).ToList(),
                Clients=_context.Clients.ToList(),
                BreadCrumb=new BreadCrumbViewModel
                {
                    Title="Servislər",
                    Links=new List<string>
                    {
                        "Ana Səhifə",
                        "Servislər"
                    }
}

            };
            return View(model);
        }
        [Route("{action}")]
        public IActionResult Appointment()
        {
            AppointmentViewModel model = new AppointmentViewModel
            {AboutPasients=_context.AboutPasients.ToList()           };
            ViewBag.departments = new List<SelectListItem>
            { new SelectListItem { Value = null, Text = "Seçin",Selected =true,Disabled = true },
                new SelectListItem { Value = "1", Text = "Kardiologiya" },
                new SelectListItem { Value = "2", Text = "Nevrologiya" },
                new SelectListItem { Value = "3", Text = "Urologiya"  },
                new SelectListItem { Value = "4", Text = "Ginekologiya"  },
                new SelectListItem { Value = "5", Text = "Pediatriya"  },
                new SelectListItem { Value = "6", Text = "Labaratoriya"  }
            };
     return View();
        }
        [HttpPost]
        [Route("{action}")]
        public IActionResult Appointment(Randevu randevu)
        {
            Randevu ran = new Randevu
            {
             PasientName=randevu.PasientName,
            Time=randevu.Time,
            Email=randevu.Email,
            Message=randevu.Message,
            Date=randevu.Date,
            DepartmentsId = randevu.DepartmentsId
            };
            _context.Randevu.Add(ran);

            _context.SaveChanges();

            return RedirectToAction("index");

        }
        public IActionResult NewsReadMore(int id)
        {
            NewsReadMoreViewModel model = new NewsReadMoreViewModel
            {
                Clients=_context.Clients.ToList(),
                New=_context.News
                .Where(n=>n.Id==id).FirstOrDefault(),
                News=_context.News.ToList()
            };
            return View(model);
        }
        public IActionResult CoomingSoon()
        {
            return View();
        }
    }
}
