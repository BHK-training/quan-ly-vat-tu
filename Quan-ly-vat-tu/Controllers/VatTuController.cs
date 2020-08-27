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
    [Authorize(Roles = "CEO")]
    public class VatTuController : Controller
    {
        private readonly ApplicationContext _context;

        public VatTuController(ApplicationContext context)
        {
            _context = context;
        }


        // GET: VatTu
        public async Task<IActionResult> Index()
        { 
            return View(await _context.VatTu.ToListAsync());
        }

        // GET: VatTu/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new VatTu());
            }
            else
            {

                return View(_context.VatTu.Find(id));
            }
        }

       


        // POST: VatTu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("maVatTu,tenVatTu,soLuong,gia,maKho")] VatTu vatTu)
        {
            if (ModelState.IsValid)
            {
                if (vatTu.maVatTu == 0)
                {
                    _context.Add(vatTu);
                }
                else
                {
                    _context.Update(vatTu);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vatTu);
        }

        // GET: VatTu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var vatTu = await _context.VatTu.FindAsync(id);
            _context.VatTu.Remove(vatTu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        
    }
}
