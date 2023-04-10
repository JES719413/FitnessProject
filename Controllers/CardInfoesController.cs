using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitness__Project.Data;
using Fitness__Project.Models;

namespace Fitness__Project.Controllers
{
    public class CardInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CardInfoes
        public async Task<IActionResult> Index()
        {
              return _context.cardInfo != null ? 
                          View(await _context.cardInfo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.cardInfo'  is null.");
        }

        // GET: CardInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cardInfo == null)
            {
                return NotFound();
            }

            var cardInfo = await _context.cardInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardInfo == null)
            {
                return NotFound();
            }

            return View(cardInfo);
        }

        // GET: CardInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,cardNum,expDate,zipCode")] CardInfo cardInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardInfo);
                await _context.SaveChangesAsync();
                
            }
            return RedirectToAction("Index", "Account", new { area = "" });
        }

        // GET: CardInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cardInfo == null)
            {
                return NotFound();
            }

            var cardInfo = await _context.cardInfo.FindAsync(id);
            if (cardInfo == null)
            {
                return NotFound();
            }
            return View(cardInfo);
        }

        // POST: CardInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,cardNum,expDate,zipCode")] CardInfo cardInfo)
        {
            if (id != cardInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardInfoExists(cardInfo.Id))
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
            return View(cardInfo);
        }

        // GET: CardInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cardInfo == null)
            {
                return NotFound();
            }

            var cardInfo = await _context.cardInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardInfo == null)
            {
                return NotFound();
            }

            return View(cardInfo);
        }

        // POST: CardInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cardInfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.cardInfo'  is null.");
            }
            var cardInfo = await _context.cardInfo.FindAsync(id);
            if (cardInfo != null)
            {
                _context.cardInfo.Remove(cardInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardInfoExists(int id)
        {
          return (_context.cardInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
