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
    public class FeedbacksController : Controller
    {
        private readonly CarContext _context;

        public FeedbacksController(CarContext context)
        {
            _context = context;
        }

        // GET: Admin/Feedbacks
        public async Task<IActionResult> Index()
        {
            
            return View(_context.Feedbacks
                           

                );

        }




        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {

            
            

            Feedback loaixe = new Feedback();

            //return PartialView("_FeedbackPartialView", loaixe);
            return View();



        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Feedback loai)
        {

            loai.IdCus = 1;
            loai.IdCarOwner = 5;
            loai.Date = DateTime.Now;
            _context.Add(loai);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Feedback");
        }

        // GET: Admin/Hangs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            Feedback hang = await _context.Feedbacks.Where(e => e.Id == id).FirstOrDefaultAsync();


            return PartialView("EditHangPartialView", hang);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Feedback hang)
        {
            _context.Update(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var hang = new Feedback() { Id = id };
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
