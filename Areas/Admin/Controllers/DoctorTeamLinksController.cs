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
    public class DoctorTeamLinksController : Controller
    {
        private readonly ClinicDbContext _context;

        public DoctorTeamLinksController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DoctorTeamLinks
        public async Task<IActionResult> Index()
        {
            var clinicDbContext = _context.DoctorTeamLinks.Include(d => d.Doctor);
            return View(await clinicDbContext.ToListAsync());
        }

        // GET: Admin/DoctorTeamLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorTeamLink = await _context.DoctorTeamLinks
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorTeamLink == null)
            {
                return NotFound();
            }

            return View(doctorTeamLink);
        }

        // GET: Admin/DoctorTeamLinks/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id");
            return View();
        }

        // POST: Admin/DoctorTeamLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Icon,Url,DoctorId")] DoctorTeamLink doctorTeamLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorTeamLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorTeamLink.DoctorId);
            return View(doctorTeamLink);
        }

        // GET: Admin/DoctorTeamLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorTeamLink = await _context.DoctorTeamLinks.FindAsync(id);
            if (doctorTeamLink == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorTeamLink.DoctorId);
            return View(doctorTeamLink);
        }

        // POST: Admin/DoctorTeamLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Icon,Url,DoctorId")] DoctorTeamLink doctorTeamLink)
        {
            if (id != doctorTeamLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorTeamLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorTeamLinkExists(doctorTeamLink.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", doctorTeamLink.DoctorId);
            return View(doctorTeamLink);
        }

        // GET: Admin/DoctorTeamLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorTeamLink = await _context.DoctorTeamLinks
                .Include(d => d.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctorTeamLink == null)
            {
                return NotFound();
            }

            return View(doctorTeamLink);
        }

        // POST: Admin/DoctorTeamLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorTeamLink = await _context.DoctorTeamLinks.FindAsync(id);
            _context.DoctorTeamLinks.Remove(doctorTeamLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorTeamLinkExists(int id)
        {
            return _context.DoctorTeamLinks.Any(e => e.Id == id);
        }
    }
}
