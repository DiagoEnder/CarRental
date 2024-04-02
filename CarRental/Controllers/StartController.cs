using CarRental.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using CarRental1.Migrations;
namespace CarRental.Controllers
{
    public class StartController : Controller
    {
        private readonly CarContext _context;

        public StartController(CarContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        

        public IActionResult FormLogin()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            if (check(user.Email, user.Password))
            {
                return Json(new { success = true });
            }
            else
            {
                TempData["ErrorMessage"] = "Tên người dùng hoặc mật khẩu không đúng. Vui lòng nhập lại.";
                return Json(new { success = false, message = "Tên người dùng hoặc mật khẩu không đúng. Vui lòng nhập lại." });
            }
        }


        public IActionResult Regis()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Regis(User user)
        {
            user.IdRole = 1;
            
            

            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("FormLogin");
        }

        private bool Ver(string pass,string passdata)
        {
			bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(pass, passdata);
            if (isPasswordCorrect) return true;
            return false;
		}

        private bool check(string account, string password)  
        {
			

			foreach (var Acount in _context.User)
            {
                if (Acount.Email == account && Ver(password, Acount.Password))
                {

                    int id = Acount.Id;
                    string a = Acount.UserName;




                    HttpContext.Session.SetString("UserName", a);
                    HttpContext.Session.SetInt32("IdUser", id);
                    return true;
                }
            }
            return false;
        }

    }
}
