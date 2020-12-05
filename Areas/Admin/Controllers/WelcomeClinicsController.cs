using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeClinic.Data;
using CodeClinic.Models;
using CodeClinic.Helpers;
using System.IO;

namespace CodeClinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WelcomeClinicsController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly IFileManager _fileManager;

        public WelcomeClinicsController(ClinicDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        // GET: Admin/WelcomeClinics
        public async Task<IActionResult> Index()
        {
            return View(await _context.WelcomeClinics.ToListAsync());
        }

        // GET: Admin/WelcomeClinics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomeClinic = await _context.WelcomeClinics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcomeClinic == null)
            {
                return NotFound();
            }

            return View(welcomeClinic);
        }

        // GET: Admin/WelcomeClinics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WelcomeClinics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,About,Upload,Title,Desc")] WelcomeClinic welcomeClinic)
        {
            if (welcomeClinic.Upload == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(welcomeClinic.Upload, "wwwroot/uploads/main-slider");
                welcomeClinic.Photo = fileName;
                _context.Add(welcomeClinic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(welcomeClinic);
        }

        // GET: Admin/WelcomeClinics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomeClinic = await _context.WelcomeClinics.FindAsync(id);
            if (welcomeClinic == null)
            {
                return NotFound();
            }
            return View(welcomeClinic);
        }

        // POST: Admin/WelcomeClinics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,About,Title,Desc,Photo,Upload")] WelcomeClinic welcomeClinic)
        {
            if (id != welcomeClinic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (welcomeClinic.Upload != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads/main-slider", welcomeClinic.Photo);
                        _fileManager.Delete(oldFile);
                        var fileName = _fileManager.Upload(welcomeClinic.Upload, "wwwroot/uploads/main-slider");
                        welcomeClinic.Photo = fileName;
                    }
                    _context.Update(welcomeClinic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WelcomeClinicExists(welcomeClinic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(welcomeClinic);
        }

        // GET: Admin/WelcomeClinics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var welcomeClinic = await _context.WelcomeClinics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (welcomeClinic == null)
            {
                return NotFound();
            }

            return View(welcomeClinic);
        }

        // POST: Admin/WelcomeClinics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var welcomeClinic = await _context.WelcomeClinics.FindAsync(id);
            _context.WelcomeClinics.Remove(welcomeClinic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WelcomeClinicExists(int id)
        {
            return _context.WelcomeClinics.Any(e => e.Id == id);
        }
    }
}
