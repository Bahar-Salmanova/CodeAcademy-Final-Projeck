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
    public class DoctorsController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly IFileManager _fileManager;

        public DoctorsController(ClinicDbContext context ,IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        // GET: Admin/Doctors
        public async Task<IActionResult> Index()
        {
            var clinicDbContext = _context.Doctors.Include(d => d.Departments);
            return View(await clinicDbContext.ToListAsync());
        }

        // GET: Admin/Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Departments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Admin/Doctors/Create
        public IActionResult Create()
        {
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: Admin/Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Education,Speciality,Experience,Address,Timing,Phone,Email,Website,About,Upload,Position,DepartmentsId,IsHome")] Doctor doctor)
        {
            if (doctor.Upload == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(doctor.Upload, "wwwroot/uploads/gallery");
                doctor.Photo = fileName;
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", doctor.DepartmentsId);
            return View(doctor);
        }

        // GET: Admin/Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", doctor.DepartmentsId);
            return View(doctor);
        }

        // POST: Admin/Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Education,Speciality,Experience,Address,Timing,Phone,Email,Website,About,Photo,Upload,Position,DepartmentsId,IsHome")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (doctor.Upload != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads/gallery", doctor.Photo);
                        _fileManager.Delete(oldFile);
                        var fileName = _fileManager.Upload(doctor.Upload , "wwwroot/uploads/gallery");
                        doctor.Photo = fileName;
                    }
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            ViewData["DepartmentsId"] = new SelectList(_context.Departments, "Id", "Id", doctor.DepartmentsId);
            return View(doctor);
        }

        // GET: Admin/Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Departments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Admin/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _fileManager.Delete(doctor.Photo, "wwwroot/uploads/gallery");
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
