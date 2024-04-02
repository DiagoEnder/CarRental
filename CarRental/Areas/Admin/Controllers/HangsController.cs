using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Areas.Admin.Models;
using System.Runtime.Intrinsics.Arm;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangsController : Controller
    {
        private readonly CarContext _context;

        public HangsController(CarContext context)
        {
            _context = context;
        }

        // GET: Admin/Hangs
        public async Task<IActionResult> Index()
        {
            return View(_context.Hangs.AsNoTracking());
        }

      
        

        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                Hang hang = new Hang();
                return PartialView("_HangPartialView", hang);
            }
            else
            {
                return RedirectToAction("Create", "Hangs");
            }
           
        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hang hang)
        {                   
                _context.Add(hang);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Hangs");  
        }

        // GET: Admin/Hangs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            Hang hang = await _context.Hangs.Where(e => e.Id == id).FirstOrDefaultAsync();


            return PartialView("EditHangPartialView", hang);
        }

        
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Hang hang)
        {
            _context.Update(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

      
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var hang = new Hang() { Id = id };
            _context.Remove(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HangExists(int id)
        {
          return (_context.Hangs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
