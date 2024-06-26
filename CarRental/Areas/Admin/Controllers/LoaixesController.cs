﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Areas.Admin.Models;
using System.Data;

namespace CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaixesController : Controller
    {
        private readonly CarContext _context;

        public LoaixesController(CarContext context)
        {
            _context = context;
        }

        // GET: Admin/Hangs
        public async Task<IActionResult> Index()
        {
            List<SelectListItem> hangxe = new List<SelectListItem>();
            hangxe = _context.Hangs.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Hang = hangxe;
            return View(_context.Loaixes
                           .Include(h => h.Hang)
                           
                );

        }




        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {

            List<SelectListItem> hangxe = new List<SelectListItem>();
            hangxe = _context.Hangs.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Hang = hangxe;

            Loaixe loaixe = new Loaixe();
           
            return PartialView("_LoaixePartialView", loaixe);
            //return View();
           
           

        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Loaixe loai)
        {
            _context.Add(loai);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Loaixes");
        }

        // GET: Admin/Hangs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            Loaixe hang = await _context.Loaixes.Where(e => e.Id == id).FirstOrDefaultAsync();


            return PartialView("EditHangPartialView", hang);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Loaixe hang)
        {
            _context.Update(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var hang = new Loaixe() { Id = id };
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
