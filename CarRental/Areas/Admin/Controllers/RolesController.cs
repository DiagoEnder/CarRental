using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Areas.Admin.Models;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly CarContext _context;

        public RolesController(CarContext context)
        {
            _context = context;
        }

        // GET: Admin/Roles
        public async Task<IActionResult> Index()
        {
            return View(_context.Roles.AsNoTracking());
        }




        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                Role role = new Role();
                return PartialView("_RolePartialView", role);
            }
            else
            {
                return RedirectToAction("Create", "Roles");
            }

        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            _context.Add(role);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Roles");
        }

        // GET: Admin/Hangs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            Role role = await _context.Roles.Where(e => e.Id == id).FirstOrDefaultAsync();


            return PartialView("EditRolePartialView", role);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Role role)
        {
            _context.Update(role);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var role = new Role() { Id = id };
            _context.Remove(role);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
