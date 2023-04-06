using Fitness__Project.Data;
using Fitness__Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;

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


        public IActionResult JoinClass(string title, string start)
        {
            // List<ClassMember> classMembers = new List<ClassMember>();

            ClassMember newMember = new ClassMember();




            //var classNum = (from B1 in _context.classMembers
              //              where B1.startTime == start
               //            select B1).Count();
                            
           /// if (classNum <= 10) 
          //  {
                newMember.ClassName = title;
                newMember.startTime = start;
                newMember.memberId = User.Identity.Name;


                _context.classMembers.Add(newMember);

           // }

           


            return View();
        }
        
    
    }
}
