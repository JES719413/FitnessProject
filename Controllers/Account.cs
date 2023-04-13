using Fitness__Project.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

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
                            select new { className = B1.ClassName, classTime = B1.startTime };
            var membership = (from B1 in _context.Memberships
                              where B1.email == User.Identity.Name
                              select B1.membershipType);
            var status = (from B1 in _context.Memberships
                          where B1.email == User.Identity.Name
                          select B1.status);
            var startDate = (from B1 in _context.Memberships
                             where B1.email == User.Identity.Name
                             select B1.startDate);
            string membershipType = membership.SingleOrDefault();
            string Status = status.SingleOrDefault();
            DateTime StartDate = startDate.SingleOrDefault();

            var user = User.Identity.Name;

            ViewBag.Status = Status;
            ViewBag.StartDate = StartDate;
            ViewBag.Membership = membershipType;
            ViewBag.User = user;
            ViewBag.ClassList = classList;

            return View();
        }
    }
}
