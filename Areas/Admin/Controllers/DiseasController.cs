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
    public class DiseasController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly IFileManager _fileManager;

        public DiseasController(ClinicDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        // GET: Admin/Diseas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diseases.ToListAsync());
        }

        // GET: Admin/Diseas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseas = await _context.Diseases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diseas == null)
            {
                return NotFound();
            }

            return View(diseas);
        }

        // GET: Admin/Diseas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Diseas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,About,ShortAbout,Upload")] Diseas diseas)
        {
            if (diseas.Upload == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(diseas.Upload, "wwwroot/uploads/gallery");
                diseas.Photo = fileName;
                _context.Add(diseas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diseas);
        }

        // GET: Admin/Diseas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseas = await _context.Diseases.FindAsync(id);
            if (diseas == null)
            {
                return NotFound();
            }
            return View(diseas);
        }

        // POST: Admin/Diseas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,About,ShortAbout,Photo,Upload")] Diseas diseas)
        {
            if (id != diseas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (diseas.Upload != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads/gallery", diseas.Photo);
                        _fileManager.Delete(oldFile);
                        var fileName = _fileManager.Upload(diseas.Upload, "wwwroot/uploads/gallery");
                        diseas.Photo = fileName;
                    }
                    _context.Update(diseas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiseasExists(diseas.Id))
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
            return View(diseas);
        }

        // GET: Admin/Diseas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diseas = await _context.Diseases
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diseas == null)
            {
                return NotFound();
            }

            return View(diseas);
        }

        // POST: Admin/Diseas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diseas = await _context.Diseases.FindAsync(id);
            _context.Diseases.Remove(diseas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiseasExists(int id)
        {
            return _context.Diseases.Any(e => e.Id == id);
        }
    }
}
