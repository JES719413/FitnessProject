using Fitness__Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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



        
    
    }
}
