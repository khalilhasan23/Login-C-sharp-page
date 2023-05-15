using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Register : Controller
    {
        public Register(AppDbContext db) {

            _db = db;
        
        }

        private readonly AppDbContext _db;
        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Users user) {

            if (ModelState.IsValid)
            {
                _db.user.Add(user);
                _db.SaveChanges();
                return RedirectToAction("", "");
            }
            return View();
            
        }
    }
}
