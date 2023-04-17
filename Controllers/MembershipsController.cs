using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitness__Project.Data;
using Fitness__Project.Models;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;

namespace Fitness__Project.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembershipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Memberships
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return _context.Memberships != null ?
                        View(await _context.Memberships.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Memberships'  is null.");
        }

        // GET: Memberships/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Memberships == null)
                {
                    return NotFound();
                }

                var membership = await _context.Memberships
                    .FirstOrDefaultAsync(m => m.MemberId == id);
                if (membership == null)
                {
                    return NotFound();
                }

                return View(membership);
            }
            catch
            {
                
                Problem("A error occurred while proccessing the request.");
                return View("Index", "Account");
            }
        }

        // GET: Memberships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("membershipID,startDate,status,membershipType,MemberId,firstName,lastName,email,birthday")] Membership membership)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isMember = (from B1 in _context.Memberships
                                    where B1.email == User.Identity.Name
                                    select B1).Count();
                    if (isMember == 1)
                    {
                        TempData["IsMember"] = "You are already a member.";

                        return View();
                    }
                    membership.startDate = DateTime.Now;

                    _context.Add(membership);
                    await _context.SaveChangesAsync();
                    if (membership.membershipType == "8-Day")
                    {
                        TempData["Price"] = "$99";
                    }
                    else if (membership.membershipType == "10-Day")
                    {
                        TempData["Price"] = "$150";
                    }
                    else if (membership.membershipType == "15-Day")
                    {
                        TempData["Price"] = "$200";
                    }
                    else if (membership.membershipType == "Unlimited")
                    {
                        TempData["Price"] = "$300";
                    }

                }
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Account", new { area = "" });
                }else
                {
                    return RedirectToAction("Create", "CardInfoes", new { area = "" });
                }
               
            } catch
            {
                return Problem("A error occurred while proccessing the request.");
            }
        }


        // GET: Memberships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Memberships == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            return View(membership);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("membershipID,startDate,status,membershipType,MemberId,firstName,lastName,email,birthday")] Membership membership)
        {
            try
            {
                if (id != membership.MemberId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(membership);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MembershipExists(membership.MemberId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    if(User.IsInRole("Admin"))
                    {
                        return RedirectToAction(nameof(Index));
                    }else
                    {
                        return RedirectToAction("Index", "Account", new { area = "" });
                    }
                    
                }
                return View(membership);
            }catch (DbUpdateConcurrencyException)
            {
                Problem("A error occurred while proccessing the request.");
                return View("Index", "Account");  
            }
        }

        // GET: Memberships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Memberships == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Memberships == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Memberships'  is null.");
            }
            var membership = await _context.Memberships.FindAsync(id);
            if (membership != null)
            {
                _context.Memberships.Remove(membership);
            }
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }catch (DbUpdateConcurrencyException)
            {
                return Problem("A error occurred while proccessing the request.");
                
            }
            }

        private bool MembershipExists(int id)
        {
            return (_context.Memberships?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }
    }
}
