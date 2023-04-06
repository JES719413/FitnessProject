using Fitness__Project.Data;
using Fitness__Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fitness__Project.Controllers
{
    public class scheduler : Controller
    {

        private readonly ApplicationDbContext _context;

        public scheduler(ApplicationDbContext context)
        {
            _context = context;
        }





        public IActionResult Index()
        {
            var result = _context.Classes.ToArrayAsync();
            ViewBag.Result = result;
            


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JoinClass(string title, string start)
        {
           

            ClassMember newMember = new ClassMember();


            string message = string.Empty;

            var classNum = (from B1 in _context.classMembers
                          where B1.startTime == start
                           select B1).Count();
                            
            if (classNum <= 10) 
           {
                newMember.ClassName = title;
                newMember.startTime = start;
                newMember.memberId = User.Identity.Name;


                _context.classMembers.Add(newMember);
                await _context.SaveChangesAsync();

                message = "Class Joined";
               
            }
            else
            {
                message = "Class Full";
                
            }
           


            return Json(new { message = message});
        }
        
    
    }
}
