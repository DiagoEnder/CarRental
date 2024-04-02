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
    public class TinhNangsController : Controller
    {
        private readonly CarContext _context;

        public TinhNangsController(CarContext context)
        {
            _context = context;
        }

        // GET: Admin/TinhNangs
        public async Task<IActionResult> Index()
        {
            return View(_context.TinhNangs.AsNoTracking());
        }




        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                TinhNang tn = new TinhNang();
                return PartialView("_TinhNangPartialView", tn);
            }
            else
            {
                return RedirectToAction("Create", "TinhNangs");
            }

        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TinhNang tn)
        {
            _context.Add(tn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "TinhNangs");
        }

        // GET: Admin/Hangs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            TinhNang tn = await _context.TinhNangs.Where(e => e.Id == id).FirstOrDefaultAsync();


            return PartialView("EditHangPartialView", tn);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TinhNang hang)
        {
            _context.Update(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var tn = new TinhNang() { Id = id };
            _context.Remove(tn);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
    }
}
