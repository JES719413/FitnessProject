using Fitness__Project.Data;
using Fitness__Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace Fitness__Project.Controllers
{
    public class Account : Controller
    {
        private readonly ApplicationDbContext _context;

        public Account(ApplicationDbContext context)
        {
            _context = context;
            
        }



        public IActionResult Index()
        {

            var classList = from B1 in _context.classMembers
                            where B1.memberId == User.Identity.Name
                            select new { className = B1.ClassName, classTime = B1.startTime , ID = B1.Id};
            var membership = (from B1 in _context.Memberships
                              where B1.email == User.Identity.Name
                              select B1.membershipType);
            var status = (from B1 in _context.Memberships
                          where B1.email == User.Identity.Name
                          select B1.status);
            var startDate = (from B1 in _context.Memberships
                             where B1.email == User.Identity.Name
                             select B1.startDate);
            var membershipID = (from B1 in _context.Memberships
                                where B1.email == User.Identity.Name
                                select B1.MemberId);


            string firstName = (from B1 in _context.Memberships
                        where B1.email == User.Identity.Name
                        select B1.firstName).SingleOrDefault();
            var lastName = (from B1 in _context.Memberships
                            where B1.email == User.Identity.Name
                            select B1.lastName).SingleOrDefault();
            int membershipIDs = membershipID.SingleOrDefault();


            string membershipType = membership.SingleOrDefault();
            string Status = status.SingleOrDefault();
            DateTime StartDate = startDate.SingleOrDefault();

            

            ViewBag.Status = Status;
            ViewBag.StartDate = StartDate;
            ViewBag.Membership = membershipType;
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.ClassList = classList;
            ViewBag.ID = membershipIDs;
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var classMember = await _context.classMembers.FindAsync(id);

            if (classMember == null)
            {
                return NotFound();
            }

            _context.classMembers.Remove(classMember);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Account");

        }
    }
}
