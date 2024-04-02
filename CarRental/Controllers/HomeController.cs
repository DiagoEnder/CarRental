using CarRental.Areas.Admin.Models;
using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using CarRental.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using CarRental.Models.ViewModel;
using NToastNotify;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {

        //private readonly IToastNotify toastNotify;
        private readonly CarContext _context;

        public HomeController(CarContext context)
        {
            _context = context;
        }

       // [Authentication]
        public IActionResult Index()
        {
            var sp = _context.SanPhams.Join(
                                _context.InfoUsers,
                                spp => spp.IdChuXe,
                                user => user.Id,
                                (spp, user) => new IndexSPViewModel
                                {
                                    Id = spp.IdInfo,
                                    IdChuXe = spp.IdChuXe,
                                    Img = user.Img,
                                    Imgxe = spp.Img,
                                    Loca = spp.Diachixe,
                                    Gia = spp.Gia,
                                    Name = spp.InfoXe.Loaixe.Name,
                                    TruyenDong = spp.InfoXe.Truyendong
                                }
                                ).Take(10).AsNoTracking().ToList();
            return View(sp);
            
        }

        

        public IActionResult Detail(int idxe, int idowner)
        {
            var sp = _context.SanPhams.Include(x => x.InfoXe)
                                                .Where(s => s.IdInfo == idxe).FirstOrDefault();

            var lsttinhnang = _context.XeTinhNangs.Include(l => l.TinhNang)
                .Where(x => x.Idxe == idxe)
                                                   .ToList();

            var info = _context.InfoXes.Include(hang => hang.Hang)
                                            .Include(loai => loai.Loaixe).Where(x => x.Id == idxe).FirstOrDefault();
            var cmt = _context.Feedbacks.Include(u => u.InfoUserOwn).Include(x =>x.InfoUserCus)
                                        .Where(x => x.IdCarOwner == idowner).OrderByDescending(x => x.Date).Take(5).ToList();

            var viewModel = new DetailsViewModel
            {
                XeTinhNang = lsttinhnang,
                SanPham = sp,
                InfoXe = info,
                Feedback = cmt,
                
                
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      

        public IActionResult DangKySP()
        {
            int userid = HttpContext.Session.GetInt32("IdUser") ?? 0;
            if(CheckInfo(userid))
            {
                return RedirectToAction("Create","DangKySP");
            }
            return RedirectToAction("Create","InfoUsers");
        }

        public bool CheckInfo( int id)
        {
            var user = _context.InfoUsers.Where(c => c.IdUser == id).FirstOrDefault();
            if(user != null)
            {
                return true;
            }
            return false;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("IdUser");
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Datxe (DonDatXe dx)
        {
            try
            {
                

                
                dx.IdCus = (int)HttpContext.Session.GetInt32("IdUser");
                
                dx.State = 1;
                dx.ngayDat = DateTime.Now.Date;
               

                _context.Add(dx);
                await _context.SaveChangesAsync();
                return Ok(new { success = true, message = "Bạn đã đạt xe thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Lỗi: " + ex.Message });
            }
        }

        public IActionResult CheckInfoUser()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");
            var check = _context.InfoUsers.FirstOrDefault(x => x.IdUser == id);
            if(check == null)
            {
                return Json(new { result = 0 });
			}

			return Json(new { result = 1 });
		}


        public IActionResult About()
        {
            return View();
        }
        
       
    }
}