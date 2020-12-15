using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeClinic.Data;
using CodeClinic.Models;
using CodeClinic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodeClinic.Controllers
{
    public class DoctorsController : Controller
    {

        //private readonly ILogger<DoctorsController> _logger;
        private readonly ClinicDbContext _context;

        public DoctorsController( ClinicDbContext context)
        {
            _context = context;
            //_logger = logger;
        }

        
        public IActionResult Index(int id)
        {
            DoctorsViewModel model = new DoctorsViewModel
            {
                Doctors = _context.Doctors.Include(d => d.DoctorTeamLinks).Take(6).ToList(),
                DoctorTeamLinks = _context.DoctorTeamLinks.Include(d => d.Doctor).ToList(),
                PatientSay = _context.PatientSays.Take(3).ToList(),
               Randevu=_context.Randevu.ToList(),
               Randevus=_context.Randevu.FirstOrDefault(),
                AppointmentKind=_context.AppointmentKind.ToList(),
                ClinicOpeningHours = _context.ClinicOpeningHours.ToList(),
                AppointmentTimes = _context.AppointmentTimes.ToList(),
                
                Clients = _context.Clients.ToList(),
                BreadCrumb=new BreadCrumbViewModel
                {
                    Title="Həkimlərimiz",
                    Links=new List<string>
                    {
                        "Ana Səhifə",
                        "Həkimlərimiz"
                    }

                }
            };
            return View(model);
        }
        [Route("/{controller}/{action}/{id?}")]
        public IActionResult DoctorDetails(int id)
        {
            DoctorDetailsViewModel model = new DoctorDetailsViewModel
            {
               
                Doctors = _context.Doctors.Include(d => d.DoctorTeamLinks).Include(d=>d.DoctorOpeningHours)
                .Where(d=>d.Id==id)
                .FirstOrDefault(),
                //DoctorOpeningHours=_context.DoctorsOpeningHours.Include(d=>d.Doctor).ToList(),
                DoctorOpeningHourses=_context.DoctorsOpeningHours.FirstOrDefault(d=>d.DoctorId==id),
                
                Doctor = _context.Doctors.Include(d => d.DoctorTeamLinks).Take(4).ToList(),

               
                DoctorTeamLinks = _context.DoctorTeamLinks.Include(d => d.Doctor).Take(4).ToList(),

                Clients =_context.Clients.ToList(),
                BreadCrumb=new BreadCrumbViewModel
                {
                    Title="Həkimlərimizi Tanıyaq",
                    Links=new List<string>
                    {
                        "Ana Səhifə",
                       "Həkimlərimizi Tanıyaq"
                    }
                }

            };
     return View(model);
            
        }
        
        [HttpPost]
        [Route("/{controller}/{action}/{id?}")]
        public IActionResult DoctorDetails(AboutPasient aboutPasient)
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
