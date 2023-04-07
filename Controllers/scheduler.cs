using Fitness__Project.Data;
using Fitness__Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Fitness__Project.Controllers
{
    public class scheduler : Controller
    {

        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public scheduler(ApplicationDbContext context, UserManager<IdentityUser> userMrg)
        {
            _context = context;
            _userManager = userMrg;
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

            if (User.IsInRole("Admin"))
            {
                var classMembers = await (from B1 in _context.classMembers
                                          where B1.startTime == start
                                          select B1).ToListAsync();

                var serializedMembers = JsonConvert.SerializeObject(classMembers);
                string message = string.Empty;

                
                return Json(new { redirectToUrl = Url.Action("DisplayClassMember", "scheduler", new { title = title, start = start, members = serializedMembers }), message = message });

               
            }
            else
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



                return Json(new { message = message });
            }
        }

        public IActionResult DisplayClassMember(string title, string start, string members)
        {
            ViewBag.Title = title;
            ViewBag.Start = start;


            var classMembers = JsonConvert.DeserializeObject<List<ClassMember>>(members);

            ViewBag.Members = classMembers;

            return View();
        }


    }
}
