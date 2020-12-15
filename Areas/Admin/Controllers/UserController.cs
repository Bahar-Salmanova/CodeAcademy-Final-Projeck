using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeClinic.Data;
using CodeClinic.Filters;
using CodeClinic.Models;
using CodeClinic.ViewModel;
using CryptoHelper;
using Microsoft.AspNetCore.Mvc;

namespace CodeClinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ClinicDbContext _context;
        public UserController(ClinicDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                User user = _context.User.FirstOrDefault(u => u.Email == model.Email);

                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, model.Password))
                    {
                        user.Token = Crypto.HashPassword(DateTime.Now.ToString());
                        await _context.SaveChangesAsync();

                        Response.Cookies.Append("token", user.Token, new Microsoft.AspNetCore.Http.CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(30),
                            HttpOnly = true
                        });
                    }

                    return RedirectToAction("index", "home");
                }
            }

            return View(model);
        }
        public IActionResult LogOut(int Id)
        {
            User user = _context.User.FirstOrDefault(x => x.Id == Id);

            if (user != null)
            {
                Response.Cookies.Delete("token");
                return RedirectToAction("index", "Home");
            }

            return NoContent();
        }
    }
}
