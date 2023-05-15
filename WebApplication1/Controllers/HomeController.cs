using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        private readonly AppDbContext _db;

        public Users Cuser = new Users();

        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Users user)
        {

            Users x  = user;

            IEnumerable<Users> users = _db.user.ToList();



            foreach (var num in users)
            {
                if (num.Email==user.Email)
                {
                    if (num.Password==user.Password)
                    {

                        return RedirectToAction("Userpage");
                    }
                }
            }
                    
                
            return View();
        }

        public IActionResult Userpage(Users user)
        {
            
            return View(user);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}