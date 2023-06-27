using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Storefront.DATA.EF.Models;

namespace Storefront.UI.MVC.Controllers
{
    public class CandlesController : Controller
    {
        private readonly StoreFrontContext _context;

        public CandlesController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: Candles
        public async Task<IActionResult> Index()
        {
            var storeFrontContext = _context.Candles.Include(c => c.Category).Include(c => c.Supplier);
            return View(await storeFrontContext.ToListAsync());
        }

        public async Task<IActionResult> TiledProducts()
        {
            var storeFrontContext = _context.Candles.Include(c => c.Category).Include(c => c.Supplier);
            return View(await storeFrontContext.ToListAsync());
        }

        // GET: Candles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candles == null)
            {
                return NotFound();
            }

            var candle = await _context.Candles
                .Include(c => c.Category)
                .Include(c => c.Supplier)
                .FirstOrDefaultAsync(m => m.CandleId == id);
            if (candle == null)
            {
                return NotFound();
            }

            return View(candle);
        }

        // GET: Candles/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Address");
            return View();
        }

        // POST: Candles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandleId,CandleName,Description,Price,Quantity,SupplierId,CategoryId,CandleImage")] Candle candle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", candle.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Address", candle.SupplierId);
            return View(candle);
        }

        // GET: Candles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candles == null)
            {
                return NotFound();
            }

            var candle = await _context.Candles.FindAsync(id);
            if (candle == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", candle.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Address", candle.SupplierId);
            return View(candle);
        }

        // POST: Candles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandleId,CandleName,Description,Price,Quantity,SupplierId,CategoryId,CandleImage")] Candle candle)
        {
            if (id != candle.CandleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandleExists(candle.CandleId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", candle.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Address", candle.SupplierId);
            return View(candle);
        }

        // GET: Candles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candles == null)
            {
                return NotFound();
            }

            var candle = await _context.Candles
                .Include(c => c.Category)
                .Include(c => c.Supplier)
                .FirstOrDefaultAsync(m => m.CandleId == id);
            if (candle == null)
            {
                return NotFound();
            }

            return View(candle);
        }

        // POST: Candles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candles == null)
            {
                return Problem("Entity set 'StoreFrontContext.Candles'  is null.");
            }
            var candle = await _context.Candles.FindAsync(id);
            if (candle != null)
            {
                _context.Candles.Remove(candle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandleExists(int id)
        {
          return (_context.Candles?.Any(e => e.CandleId == id)).GetValueOrDefault();
        }
    }
}
