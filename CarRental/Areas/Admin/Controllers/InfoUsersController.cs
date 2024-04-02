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
    public class InfoUsersController : Controller
    {
        private readonly CarContext _context;

        public InfoUsersController(CarContext context)
        {
            _context = context;
        }

        // GET: Admin/InfoUsers
        public async Task<IActionResult> Index()
        {
              return _context.InfoUsers != null ? 
                          View(await _context.InfoUsers.ToListAsync()) :
                          Problem("Entity set 'CarContext.InfoUsers'  is null.");
        }

        // GET: Admin/InfoUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InfoUsers == null)
            {
                return NotFound();
            }

            var infoUser = await _context.InfoUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoUser == null)
            {
                return NotFound();
            }

            return View(infoUser);
        }

        // GET: Admin/InfoUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/InfoUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUser,Name,CCCD,GPLX,ImgGplx,Img,Ngaysinh,GioiTinh")] InfoUser infoUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoUser);
        }

        // GET: Admin/InfoUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InfoUsers == null)
            {
                return NotFound();
            }

            var infoUser = await _context.InfoUsers.FindAsync(id);
            if (infoUser == null)
            {
                return NotFound();
            }
            return View(infoUser);
        }

        // POST: Admin/InfoUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,Name,CCCD,GPLX,ImgGplx,Img,Ngaysinh,GioiTinh")] InfoUser infoUser)
        {
            if (id != infoUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoUserExists(infoUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(infoUser);
        }

        // GET: Admin/InfoUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InfoUsers == null)
            {
                return NotFound();
            }

            var infoUser = await _context.InfoUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoUser == null)
            {
                return NotFound();
            }

            return View(infoUser);
        }

        // POST: Admin/InfoUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InfoUsers == null)
            {
                return Problem("Entity set 'CarContext.InfoUsers'  is null.");
            }
            var infoUser = await _context.InfoUsers.FindAsync(id);
            if (infoUser != null)
            {
                _context.InfoUsers.Remove(infoUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoUserExists(int id)
        {
          return (_context.InfoUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
