using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Areas.Admin.Models;
using CarRental.Areas.Admin.Models.ViewModel;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamsController : Controller
    {
        private readonly CarContext _context;

        public SanPhamsController(CarContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPhams
        public async Task<IActionResult> Index()
        {






            return View(_context.SanPhams
                           .Include(h => h.InfoXe).AsNoTracking().ToList()


                ) ;

        }




        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {
            SanPham sp = new SanPham();
           
            return PartialView("_InfoXePartialView",sp );
           



        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanPham sanPham)
        {

            sanPham.State = 1;
            _context.Add(sanPham);
            await _context.SaveChangesAsync();          
           

            return RedirectToAction("Index", "SanPhams");
        }

        // GET: Admin/Hangs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            SanPham hang = await _context.SanPhams.Where(e => e.Id == id).FirstOrDefaultAsync();


            return PartialView("EditInfoXePartialView", hang);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SanPham hang)
        {
            _context.Update(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var hang = new SanPham() { Id = id };
            _context.Remove(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        

      


       
    }
}
