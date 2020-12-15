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
    public class PatientSaysController : Controller
    {
        private readonly ClinicDbContext _context;
        private readonly IFileManager _fileManager;

        public PatientSaysController(ClinicDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        // GET: Admin/PatientSays
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientSays.ToListAsync());
        }

        // GET: Admin/PatientSays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientSay = await _context.PatientSays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientSay == null)
            {
                return NotFound();
            }

            return View(patientSay);
        }

        // GET: Admin/PatientSays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PatientSays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Desc,Upload,FullName,Position")] PatientSay patientSay)
        {
            if (patientSay.Upload == null)
            {
                ModelState.AddModelError("Uploads", "The Photo field is required.");
            }
            if (ModelState.IsValid)
            {
                var fileName = _fileManager.Upload(patientSay.Upload, "wwwroot/uploads/gallery");
                patientSay.Photo = fileName;
                _context.Add(patientSay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientSay);
        }

        // GET: Admin/PatientSays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientSay = await _context.PatientSays.FindAsync(id);
            if (patientSay == null)
            {
                return NotFound();
            }
            return View(patientSay);
        }

        // POST: Admin/PatientSays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Desc,Photo,Upload,FullName,Position")] PatientSay patientSay)
        {
            if (id != patientSay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (patientSay.Upload != null)
                    {
                        var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads/gallery", patientSay.Photo);
                        _fileManager.Delete(oldFile);
                        var fileName = _fileManager.Upload(patientSay.Upload, "wwwroot/uploads/gallery");
                        patientSay.Photo = fileName;
                    }
                    _context.Update(patientSay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientSayExists(patientSay.Id))
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
            return View(patientSay);
        }

        // GET: Admin/PatientSays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientSay = await _context.PatientSays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientSay == null)
            {
                return NotFound();
            }

            return View(patientSay);
        }

        // POST: Admin/PatientSays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientSay = await _context.PatientSays.FindAsync(id);
            _context.PatientSays.Remove(patientSay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientSayExists(int id)
        {
            return _context.PatientSays.Any(e => e.Id == id);
        }
    }
}
