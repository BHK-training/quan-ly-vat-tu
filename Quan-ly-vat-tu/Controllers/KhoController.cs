using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quan_ly_vat_tu.Models;

namespace Quan_ly_vat_tu.Controllers
{
    [Authorize(Roles = "Staff, CEO")]
    public class KhoController : Controller
    {
        private readonly ApplicationContext _context;

        public KhoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Kho
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kho.ToListAsync());
        }

        // GET: Kho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho
                .FirstOrDefaultAsync(m => m.maKho == id);
            if (kho == null)
            {
                return NotFound();
            }

            return View(kho);
        }

        // GET: Kho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maKho,tenKho,diaChi")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kho);
        }

        // GET: Kho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho.FindAsync(id);
            if (kho == null)
            {
                return NotFound();
            }
            return View(kho);
        }

        // POST: Kho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("maKho,tenKho,diaChi")] Kho kho)
        {
            if (id != kho.maKho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoExists(kho.maKho))
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
            return View(kho);
        }

        // GET: Kho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kho = await _context.Kho
                .FirstOrDefaultAsync(m => m.maKho == id);
            if (kho == null)
            {
                return NotFound();
            }

            return View(kho);
        }

        // POST: Kho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kho = await _context.Kho.FindAsync(id);
            _context.Kho.Remove(kho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoExists(int id)
        {
            return _context.Kho.Any(e => e.maKho == id);
        }
    }
}
