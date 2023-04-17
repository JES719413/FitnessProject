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
                //Pulls membership type
                var membershipType = (from B1 in _context.Memberships
                                      where B1.email == User.Identity.Name
                                      select B1.membershipType);
                //converts query to string
                string? membershipTypeS = membershipType.SingleOrDefault();

                // pulls classes register of user
                var classCount = (from B1 in _context.classMembers
                                  where B1.memberId == User.Identity.Name
                                  select B1).Count();
                
                //Check if user is in the class
                var isInClass = await _context.classMembers
                    .Where(cm => cm.memberId == User.Identity.Name && cm.startTime == start)
                    .CountAsync();


                if (isInClass == 1)
                {
                    string messages = "You have already joined this class.";

                    return Json(new { message = messages });
                }

                if (membershipTypeS == "8-Day" && classCount >= 8)
                {
                    string messages = "Classes used. Please upgrade memberships if you would like to take more classes.";

                    return Json(new { message = messages });
                } 
                else if (membershipTypeS == "10-Day" && classCount >= 10)
                {
                    string messages = "Classes used. Please upgrade memberships if you would like to take more classes.";

                    return Json(new { message = messages });
                } else if (membershipTypeS == "15-Day" && classCount >= 15)
                {
                    string messages = "Classes used. Please upgrade memberships if you would like to take more classes.";

                    return Json(new { message = messages });
                }



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

        public async Task<IActionResult> DisplayClassMember(string title, string start, string members)
        {
            if (members == null)
            {
                List<ClassMember> classMembers = await (from B1 in _context.classMembers
                                   where B1.startTime == start
                                   select B1).ToListAsync();
                ViewBag.Title = title;
                ViewBag.Start = start;
                ViewBag.Members = classMembers;
                return View();
            }
            else
            {

                ViewBag.Title = title;
                ViewBag.Start = start;


                var classMembers = JsonConvert.DeserializeObject<List<ClassMember>>(members);

                ViewBag.Members = classMembers;

                return View();
            }
        }
        public async Task<IActionResult> Delete(int id, string title, string start, string members)
        {
            var classMember = await _context.classMembers.FindAsync(id);

            if (classMember == null)
            {
                return NotFound();
            }

            _context.classMembers.Remove(classMember);
            await _context.SaveChangesAsync();

            return RedirectToAction("DisplayClassMember", new { title = title, start = start, members = members});

        }

    }
}
