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

namespace CodeClinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiaqnosticServisController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly IFileManager _fileManager;

        public DiaqnosticServisController(ClinicDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        // GET: Admin/DiaqnosticServis
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiaqnosticServis.ToListAsync());
        }

        // GET: Admin/DiaqnosticServis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaqnosticServis = await _context.DiaqnosticServis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diaqnosticServis == null)
            {
                return NotFound();
            }

            return View(diaqnosticServis);
        }

        // GET: Admin/DiaqnosticServis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DiaqnosticServis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Desc,Photo")] DiaqnosticServis diaqnosticServis)
        {
            
            if (ModelState.IsValid)
            {
                
                _context.Add(diaqnosticServis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaqnosticServis);
        }

        // GET: Admin/DiaqnosticServis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaqnosticServis = await _context.DiaqnosticServis.FindAsync(id);
            if (diaqnosticServis == null)
            {
                return NotFound();
            }
            return View(diaqnosticServis);
        }

        // POST: Admin/DiaqnosticServis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Desc,Photo")] DiaqnosticServis diaqnosticServis)
        {
            if (id != diaqnosticServis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaqnosticServis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaqnosticServisExists(diaqnosticServis.Id))
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
            return View(diaqnosticServis);
        }

        // GET: Admin/DiaqnosticServis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaqnosticServis = await _context.DiaqnosticServis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diaqnosticServis == null)
            {
                return NotFound();
            }

            return View(diaqnosticServis);
        }

        // POST: Admin/DiaqnosticServis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaqnosticServis = await _context.DiaqnosticServis.FindAsync(id);
            _context.DiaqnosticServis.Remove(diaqnosticServis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaqnosticServisExists(int id)
        {
            return _context.DiaqnosticServis.Any(e => e.Id == id);
        }
    }
}
