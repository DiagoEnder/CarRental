using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Areas.Admin.Models;
using Microsoft.CodeAnalysis.Scripting;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly CarContext _context;

        public UsersController(CarContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<SelectListItem> role = new List<SelectListItem>();
            role = _context.Roles.Select(x => new SelectListItem { Text = x.NameRole, Value = x.Id.ToString() }).ToList();
            ViewBag.Role = role;
            return View(_context.User
                           .Include(h => h.role)

                );

        }




        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {          
            User user = new User();

            return PartialView("_UserPartialView", user);
            //return View();



        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User loai)
		{
            var pass = loai.Password;
            loai.Password = BCrypt.Net.BCrypt.HashPassword(pass);

			_context.Add(loai);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Users");
        }

        // GET: Admin/Hangs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            User user = await _context.User.Where(e => e.Id == id).FirstOrDefaultAsync();


            return PartialView("EditUserPartialView", user);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User hang)
        {
            _context.Update(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var hang = new User() { Id = id };
            _context.Remove(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

       
    }
}
