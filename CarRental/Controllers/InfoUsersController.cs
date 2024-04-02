using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;

namespace CarRental.Controllers
{
    public class InfoUsersController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly CarContext _context;

        public InfoUsersController(CarContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

       
        
        

        // GET: InfoUsers
        public async Task<IActionResult> Index()
        {
            return
                        View(_context.InfoUsers.AsNoTracking());
                         
        }

        private string UploadedFile(InfoUser user)
        {
            string uniqueFileName = null;

            


            if (user.FrontImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + user.FrontImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    user.FrontImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        private string UploadedFileGp(InfoUser user)
        {
            string uniqueFileName2 = null;

            

            if (user.FrontImage2 != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
                uniqueFileName2 = Guid.NewGuid().ToString() + "_" + user.FrontImage2.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName2);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    user.FrontImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName2;
        }





        public IActionResult Create()
        {



            InfoUser user = new InfoUser();

            
            return View(user);



        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InfoUser user)
        {
            user.IdUser = HttpContext.Session.GetInt32("IdUser") ?? 0;
            user.ImgGplx = UploadedFileGp(user);
            user.Img = UploadedFile(user);
            
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create", "DangKySP");
        }


        [HttpPost]        
        public async Task<IActionResult> CreateInfoUser(InfoUser user)
        {
            user.IdUser = (int)HttpContext.Session.GetInt32("IdUser");
            user.ImgGplx = UploadedFileGp(user);
            user.Img = UploadedFile(user);

            
            try
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return Ok(new { success = true, message = "Bạn đã đăng ký thông tin thành công" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { success = false, message = "Lỗi: " + ex.Message });
            }
        }


        
    }
}
