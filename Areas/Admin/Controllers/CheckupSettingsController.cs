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
{  [TypeFilter(typeof(Auth))]
 
    
    [Area("Admin")]
    public class CheckupSettingsController : Controller
    {
        private readonly ClinicDbContext _context;

        public CheckupSettingsController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CheckupSettings
        public async Task<IActionResult> Index()
        {
            var clinicDbContext = _context.CheckupSettings.Include(c => c.Checkup);
            return View(await clinicDbContext.ToListAsync());
        }

        // GET: Admin/CheckupSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkupSetting = await _context.CheckupSettings
                .Include(c => c.Checkup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkupSetting == null)
            {
                return NotFound();
            }

            return View(checkupSetting);
        }

        // GET: Admin/CheckupSettings/Create
        public IActionResult Create()
        {
            ViewData["CheckupId"] = new SelectList(_context.Checkups, "Id", "Id");
            return View();
        }

        // POST: Admin/CheckupSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CheckupId")] CheckupSetting checkupSetting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkupSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CheckupId"] = new SelectList(_context.Checkups, "Id", "Id", checkupSetting.CheckupId);
            return View(checkupSetting);
        }

        // GET: Admin/CheckupSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkupSetting = await _context.CheckupSettings.FindAsync(id);
            if (checkupSetting == null)
            {
                return NotFound();
            }
            ViewData["CheckupId"] = new SelectList(_context.Checkups, "Id", "Id", checkupSetting.CheckupId);
            return View(checkupSetting);
        }

        // POST: Admin/CheckupSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CheckupId")] CheckupSetting checkupSetting)
        {
            if (id != checkupSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkupSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckupSettingExists(checkupSetting.Id))
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
            ViewData["CheckupId"] = new SelectList(_context.Checkups, "Id", "Id", checkupSetting.CheckupId);
            return View(checkupSetting);
        }

        // GET: Admin/CheckupSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkupSetting = await _context.CheckupSettings
                .Include(c => c.Checkup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkupSetting == null)
            {
                return NotFound();
            }

            return View(checkupSetting);
        }

        // POST: Admin/CheckupSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkupSetting = await _context.CheckupSettings.FindAsync(id);
            _context.CheckupSettings.Remove(checkupSetting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckupSettingExists(int id)
        {
            return _context.CheckupSettings.Any(e => e.Id == id);
        }
    }
}
