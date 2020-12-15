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
using CodeClinic.Filters;

namespace CodeClinic.Areas.Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    [Area("Admin")]
    public class DepartmentsController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly IFileManager _fileManager;

        public DepartmentsController(ClinicDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        // GET: Admin/Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        // GET: Admin/Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);
        }

        // GET: Admin/Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Upload,Icon,About,ShortAbout")] Departments departments)
        {
            if (departments.Upload == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(departments.Upload, "wwwroot/uploads/resource");
                departments.Photo = fileName;
                _context.Add(departments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departments);
        }

        // GET: Admin/Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments.FindAsync(id);
            if (departments == null)
            {
                return NotFound();
            }
            return View(departments);
        }

        // POST: Admin/Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Photo,Upload,Icon,About,ShortAbout")] Departments departments)
        {
            if (id != departments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (departments.Upload != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads/resource", departments.Photo);
                        _fileManager.Delete(oldFile);
                        var fileName = _fileManager.Upload(departments.Upload, "wwwroot/uploads/resource");
                        departments.Photo = fileName;
                    }
                    _context.Update(departments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentsExists(departments.Id))
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
            return View(departments);
        }

        // GET: Admin/Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);
        }

        // POST: Admin/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departments = await _context.Departments.FindAsync(id);
            _fileManager.Delete(departments.Photo, "wwwroot/uploads/resource");
            _context.Departments.Remove(departments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentsExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
