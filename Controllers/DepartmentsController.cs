using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeClinic.Data;
using CodeClinic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodeClinic.Controllers
{
    public class DepartmentsController : Controller
    {


        private readonly ClinicDbContext _context;

        public DepartmentsController(ILogger<DoctorsController> logger, ClinicDbContext context)
        {
            _context = context;

        }
        public IActionResult All(int id)
        {
            DepartmentDetailsViewModel model = new DepartmentDetailsViewModel
            {
                Departments = _context.Departments.Include(d => d.Doctors).ToList(),
                //DoctorOpeningHourses = _context.DoctorsOpeningHours
                //.Include(d => d.Doctor).FirstOrDefault(),
                //Doctor = _context.Doctors.Include(d => d.DoctorOpeningHours).FirstOrDefault(),

                Department = _context.Departments.Include(d => d.Doctors)
                .Where(d => d.Id == id)
                .FirstOrDefault(),
                Clients = _context.Clients.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Şöbələrimiz",
                    Links = new List<string>
                  {
                      "Ana Səhifə",
                      "Şöbələr"
                  }
                }
            };
            return View(model);
        }


        public IActionResult DepartmentDetails(int id)
        {
            DepartmentDetailsViewModel model = new DepartmentDetailsViewModel
            {
                Departments = _context.Departments.Include(d => d.Doctors).
                ToList(),
                //DoctorOpeningHourses=_context.DoctorsOpeningHours
                //.Include(d=>d.Doctor).FirstOrDefault(),
                //Doctor=_context.Doctors.Include(d=>d.DoctorOpeningHours).FirstOrDefault(),
                Department = _context.Departments.Include(d => d.Doctors)
                .Where(d => d.Id == id)
                .FirstOrDefault(),
                Clients = _context.Clients.ToList(),

            };
            return View(model);
        }
    }
};
        
        //        public IActionResult Cardiology(int id)
//        {
//            DepartmentViewModel model = new DepartmentViewModel
//            {
//               Departments = _context.Departments.Include(d => d.Doctors).ToList(),

//                Department=_context.Departments.Include(d=>d.Doctors)
//                .Where(d=>d.Id==id)
//                .FirstOrDefault(),
//                Clients = _context.Clients.ToList(),
//                BreadCrumb = new BreadCrumbViewModel
//                {
//                    Title = "Kardiologiya",
//                    Links = new List<string>
//                  {
//                      "Ana Səhifə",
//                      "Kardiologiya",

//                  }
//                }
//            };



//            return View(model);
//        }
//        public IActionResult Neurology()
//        {
//            DepartmentViewModel model = new DepartmentViewModel
//            {
//                Departments = _context.Departments.Include(d => d.Doctors).ToList(),
//                Clients = _context.Clients.ToList(),
//                BreadCrumb = new BreadCrumbViewModel
//                {
//                    Title = "Nevrologiya",
//                    Links = new List<string>
//                  {
//                      "Ana Səhifə",
//                      "Nevrologiya"
//                  }
//                }
//            };




//            return View(model);
//        }
//        public IActionResult Urology()
//        {
//          DepartmentViewModel model = new DepartmentViewModel
//            {
//                Departments = _context.Departments.Include(d => d.Doctors).ToList(),
//                Clients = _context.Clients.ToList(),
//              BreadCrumb = new BreadCrumbViewModel
//              {
//                  Title = "Urologiya",
//                  Links = new List<string>
//                  {
//                      "Ana Səhifə",
//                      "Urologiya"
//                  }
//              }
//          };
//            return View(model);
//        }
//        public IActionResult Gynecological()
//        {
//            DepartmentViewModel model = new DepartmentViewModel
//            {
//                Departments = _context.Departments.Include(d => d.Doctors).ToList(),
//                Clients = _context.Clients.ToList(),
//                BreadCrumb = new BreadCrumbViewModel
//                {
//                    Title = "Ginekologiya",
//                    Links = new List<string>
//                  {
//                      "Ana Səhifə",
//                      "Ginekologiya"
//                  }
//                }
//            };



//            return View(model);
//        }
//        public IActionResult Pediatrical()
//        {
//            DepartmentViewModel model = new DepartmentViewModel
//            {
//                Departments = _context.Departments.Include(d => d.Doctors).ToList(),
//                Clients = _context.Clients.ToList(),
//                BreadCrumb = new BreadCrumbViewModel
//                {
//                    Title = "Pediatriya",
//                    Links = new List<string>
//                  {
//                      "Ana Səhifə",
//                      "Pediatriya"
//                  }
//                }

//            };
//            return View(model);
//        }
//        public IActionResult Laboratory()
//        {
//            DepartmentViewModel model = new DepartmentViewModel
//            {
//                Departments = _context.Departments.Include(d => d.Doctors).ToList(),
//                Clients = _context.Clients.ToList(),
//                BreadCrumb = new BreadCrumbViewModel
//                {
//                    Title = "Laboratoriya",
//                    Links = new List<string>
//                  {
//                      "Ana Səhifə",
//                      "Laboratoriya"
//                  }
//                }
//            };



//            return View(model);
//        }
       

//    }
//}
