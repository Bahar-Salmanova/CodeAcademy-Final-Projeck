using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeClinic.Data;
using CodeClinic.Models;
using CodeClinic.Filters;

namespace CodeClinic.Areas.Admin.Controllers
{
    [TypeFilter(typeof(Auth))]
    [Area("Admin")]
    public class ClinicOpeningHoursController : Controller
    {
        private readonly ClinicDbContext _context;

        public ClinicOpeningHoursController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ClinicOpeningHours
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClinicOpeningHours.ToListAsync());
        }

        // GET: Admin/ClinicOpeningHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicOpeningHours = await _context.ClinicOpeningHours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicOpeningHours == null)
            {
                return NotFound();
            }

            return View(clinicOpeningHours);
        }

        // GET: Admin/ClinicOpeningHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ClinicOpeningHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,Date")] ClinicOpeningHours clinicOpeningHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinicOpeningHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinicOpeningHours);
        }

        // GET: Admin/ClinicOpeningHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicOpeningHours = await _context.ClinicOpeningHours.FindAsync(id);
            if (clinicOpeningHours == null)
            {
                return NotFound();
            }
            return View(clinicOpeningHours);
        }

        // POST: Admin/ClinicOpeningHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,Date")] ClinicOpeningHours clinicOpeningHours)
        {
            if (id != clinicOpeningHours.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicOpeningHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicOpeningHoursExists(clinicOpeningHours.Id))
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
            return View(clinicOpeningHours);
        }

        // GET: Admin/ClinicOpeningHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicOpeningHours = await _context.ClinicOpeningHours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicOpeningHours == null)
            {
                return NotFound();
            }

            return View(clinicOpeningHours);
        }

        // POST: Admin/ClinicOpeningHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clinicOpeningHours = await _context.ClinicOpeningHours.FindAsync(id);
            _context.ClinicOpeningHours.Remove(clinicOpeningHours);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicOpeningHoursExists(int id)
        {
            return _context.ClinicOpeningHours.Any(e => e.Id == id);
        }
    }
}
