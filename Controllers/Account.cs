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

            ViewBag.ClassList = classList;

            return View();
        }
    }
}
