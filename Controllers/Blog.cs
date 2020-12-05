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
    public class Blog : Controller
    {

        private readonly ClinicDbContext _context;

        public Blog(ILogger<DoctorsController> logger, ClinicDbContext context)
        {
            _context = context;

        }

        public IActionResult Index(int id)
        {
            BlogViewModel model = new BlogViewModel
            {
                News=_context.News.ToList(),
                Diseas=_context.Diseases.ToList(),
                Clients=_context.Clients.ToList(),
                BreadCrumb=new BreadCrumbViewModel
                {
                    Title="Bloglarımız",
                    Links=new List<string>
                    {
                        "Ana Səhifə",
                        "Bloglarımız"
                   }
                }


            };

            return View(model);
        }
        [Route("/{controller}/{action}/{id?}")]
        public IActionResult BlogReadMore(int id)
        {

            BlogReadMoreViewModel model = new BlogReadMoreViewModel
            { 
                Diseas=_context.Diseases
            .Where(d=>d.Id==id)
            .FirstOrDefault(),
                Diseases=_context.Diseases.ToList(),
                Clients=_context.Clients.ToList(),
                BreadCrumb = new BreadCrumbViewModel
                {
                    Title = "Klinikamız",
                    Links = new List<string>
                    {
                        "Ana Səhifə",
                        "Klinikamız"

                    }
                }


            };
           return View(model);

        }
    }
}
