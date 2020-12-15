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
    public class CheckupsController : Controller
    {
        private readonly ClinicDbContext _context;
       

        public CheckupsController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Checkups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Checkups.ToListAsync());
        }

        // GET: Admin/Checkups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkup = await _context.Checkups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkup == null)
            {
                return NotFound();
            }

            return View(checkup);
        }

        // GET: Admin/Checkups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Checkups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Checkup checkup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkup);
        }

        // GET: Admin/Checkups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkup = await _context.Checkups.FindAsync(id);
            if (checkup == null)
            {
                return NotFound();
            }
            return View(checkup);
        }

        // POST: Admin/Checkups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Checkup checkup)
        {
            if (id != checkup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckupExists(checkup.Id))
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
            return View(checkup);
        }

        // GET: Admin/Checkups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkup = await _context.Checkups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkup == null)
            {
                return NotFound();
            }

            return View(checkup);
        }

        // POST: Admin/Checkups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkup = await _context.Checkups.FindAsync(id);
            _context.Checkups.Remove(checkup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckupExists(int id)
        {
            return _context.Checkups.Any(e => e.Id == id);
        }
    }
}
