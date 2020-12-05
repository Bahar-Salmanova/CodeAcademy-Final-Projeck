using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeClinic.Data;
using CodeClinic.Models;

namespace CodeClinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorOpeningHoursController : Controller
    {
        private readonly ClinicDbContext _context;

        public DoctorOpeningHoursController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DoctorOpeningHours
        public async Task<IActionResult> Index()
        {
            var clinicDbContext = _context.DoctorsOpeningHours.Include(d => d.Doctor);
            return View(await clinicDbContext.ToListAsync());
        }

        // GET: Admin/DoctorOpeningHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorOpeningHours = await _context.DoctorsOpeningHours
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorOpeningHours == null)
            {
                return NotFound();
            }

            return View(doctorOpeningHours);
        }

        // GET: Admin/DoctorOpeningHours/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id");
            return View();
        }

        // POST: Admin/DoctorOpeningHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Time,DoctorId")] DoctorOpeningHours doctorOpeningHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorOpeningHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorOpeningHours.DoctorId);
            return View(doctorOpeningHours);
        }

        // GET: Admin/DoctorOpeningHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorOpeningHours = await _context.DoctorsOpeningHours.FindAsync(id);
            if (doctorOpeningHours == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorOpeningHours.DoctorId);
            return View(doctorOpeningHours);
        }

        // POST: Admin/DoctorOpeningHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Time,DoctorId")] DoctorOpeningHours doctorOpeningHours)
        {
            if (id != doctorOpeningHours.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorOpeningHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorOpeningHoursExists(doctorOpeningHours.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorOpeningHours.DoctorId);
            return View(doctorOpeningHours);
        }

        // GET: Admin/DoctorOpeningHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorOpeningHours = await _context.DoctorsOpeningHours
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorOpeningHours == null)
            {
                return NotFound();
            }

            return View(doctorOpeningHours);
        }

        // POST: Admin/DoctorOpeningHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorOpeningHours = await _context.DoctorsOpeningHours.FindAsync(id);
            _context.DoctorsOpeningHours.Remove(doctorOpeningHours);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorOpeningHoursExists(int id)
        {
            return _context.DoctorsOpeningHours.Any(e => e.Id == id);
        }
    }
}
