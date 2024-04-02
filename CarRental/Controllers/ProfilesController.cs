using CarRental.Areas.Admin.Models;
using CarRental.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly CarContext _context;

        public ProfilesController(CarContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;

        }
        // GET: UsersController

        public ActionResult Index()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");
            var users = _context.InfoUsers.Where(x => x.IdUser == id)
               .AsNoTracking().FirstOrDefault();

            if (users != null)
            {
                return View(users);
            }
            ViewBag.Noti = "Null";
            return View();
        }
        public ActionResult Acc()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");
            var users = _context.InfoUsers.Where(x => x.IdUser == id)
               .AsNoTracking().FirstOrDefault();

            return PartialView("_AccountPartialView", users);
        }

        public IActionResult ListAllChuyenDi()
        {
            return PartialView("_IndexListChuyenDiPartialView");
        }




        public ActionResult Chuyendi()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");
            List<DonDatXe> dx = _context.DonDatXes.Where(x => x.IdCus == id && x.State == 1)
                                        .Include(x => x.infoUserOwner).Include(s => s.SanPham)
                                        .ToList();
            return PartialView("_ChuyendiPartialView", dx);
        }

        public ActionResult Chuyendidabihuy()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");
            List<DonDatXe> dx = _context.DonDatXes.Where(x => x.IdCus == id && x.State == 0)
                                        .Include(x => x.infoUserOwner).Include(s => s.SanPham)
                                        .ToList();
            return PartialView("_ChuyendidahuyPartialView", dx);
        }



        public ActionResult Chuyendihientai()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");
            var dx = _context.DonDatXes
                                        .Include(s => s.SanPham)
                                        .Include(x => x.infoUserOwner)
                                        .Where(x => x.IdCus == id && x.State == 2).OrderByDescending(x => x.ngayDat)
                                        .ToList();
            return PartialView("_ChuyendihientaiPartialView", dx);
            
        }

        public IActionResult ThanhToan(int Id)
        {
            var chitiet = _context.DonDatXes.Include(s => s.SanPham)
                                        .Where(x => x.ID == Id).FirstOrDefault();

            DateTime checkin = new DateTime();
            DateTime checkout = new DateTime();

            if (chitiet!=null)
            {
                checkin = chitiet.checkin;
                checkout = chitiet.checkout;
                TimeSpan ngay = checkout - checkin;
                var totalday = ngay.TotalDays;
                double totalgia = chitiet.SanPham.Gia * totalday;

                ViewBag.TotalGia = totalgia;
                ViewBag.TotalDay = totalday;

            }




            return View(chitiet);
        }



        [HttpPost]
        public async Task<IActionResult> ThanhToan(int Idchu, double Total, int Id)
        {

            HoaDon hd = new HoaDon();
            hd.IdCus = (int)HttpContext.Session.GetInt32("IdUser");
            hd.IdOwner = Idchu;
            hd.Total = Total;
            hd.Paymentdate = DateTime.Now.Date;

            DonDatXe updateddx = _context.DonDatXes.FirstOrDefault(x => x.ID == Id);

            if (updateddx != null)
            {
                updateddx.State = 4;
                _context.Update(updateddx);
                await _context.SaveChangesAsync();

            }

            try
            {
                _context.Add(hd);
                await _context.SaveChangesAsync();
                return Ok(new { success = true, message = "Bạn đã đạt xe thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Lỗi: " + ex.Message });
            }

        }


        public IActionResult StateXe()
        {
            int idchu = (int)HttpContext.Session.GetInt32("IdUser");
            var state = _context.DonDatXes.Include(s => s.SanPham).Include(u => u.InfoUserCus)
                                            .Where(x => x.IdOwner == idchu && x.State == 1).OrderByDescending(x => x.ngayDat).ToList();


            return PartialView("_DuyetXePartialView", state);
        }

        [HttpPost]
        public IActionResult UploadedFile(IFormFile FrontImage)
        {
            string uniqueFileName = null;

            if (FrontImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Upload");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + FrontImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    FrontImage.CopyTo(fileStream);
                }
            }

            return Json(uniqueFileName);
        }

        [HttpPost]
        public IActionResult UpdateState(int Id, int State)
        {
            var ddx = _context.DonDatXes.Where(x => x.ID == Id).FirstOrDefault();
            try
            {
                ddx.State = State;
                _context.Update(ddx);
                _context.SaveChanges();

                return Ok(new { success = "Thanh cong" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Lỗi: " + ex.Message });

            }

        }

        public IActionResult Matkhau()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");
            var mk = _context.User.Where(x => x.Id == id).FirstOrDefault();

            return PartialView("_MKPartialView", mk);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMK(int Id, string mk)
        {
            var user = _context.User.Where(x => x.Id == Id).FirstOrDefault();
            user.Password = mk;
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return Ok(new { success = "Thanh cong" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Lỗi: " + ex.Message });
            }
        }



        public ActionResult EditImg(int id)
        {
            var user = _context.InfoUsers.Where(x => x.Id == id);
            return PartialView("_UpdateImgPartialView", user);
        }




        [HttpPost]

        public IActionResult Edit(string Img)
        {

            var Id = (int)HttpContext.Session.GetInt32("IdUser");
            var user = _context.InfoUsers.Where(x => x.IdUser == Id).FirstOrDefault();
            var reimg = Img;
            try
            {


                user.Img = Img;
                _context.Update(user);
                _context.SaveChanges();
                return Json(reimg);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Lỗi: " + ex.Message });
            }
        }

        public IActionResult History()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");

            var histhuexe = _context.DonDatXes.Include(s => s.SanPham)
                                                .Include(x => x.infoUserOwner)
                                                .Where(x => x.IdCus == id && x.State == 4).ToList();

            return PartialView("_HistoryThuePartialView", histhuexe);
        }

        public IActionResult chuyenxedathanhtoan()
        {
            int id = (int)HttpContext.Session.GetInt32("IdUser");

            var histhuexe = _context.DonDatXes.Include(s => s.SanPham)
                                                .Include(x => x.infoUserOwner)
                                                .Where(x => x.IdCus == id && x.State == 4).ToList();

            return PartialView("_ChuyenXeDaThanhToanPartialView", histhuexe);
        }

        public IActionResult UserOwnerVoting(int Id)
        {
            var owner = _context.InfoUsers.Where(x => x.IdUser == Id).FirstOrDefault();

            var cmt = _context.Feedbacks.Where(x => x.IdCarOwner == Id).ToList();

            ProfileFeedbackViewModel model = new ProfileFeedbackViewModel
            {
                InfoUser = owner,
                Feedback = cmt
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCmt(Feedback feedback)
        {

            feedback.Date = DateTime.Now;
            feedback.IdCus = (int)HttpContext.Session.GetInt32("IdUser");


            _context.Add(feedback);

            await _context.SaveChangesAsync();



            return Ok();
        }

        public IActionResult GetFeedbackcList(int IdOwner)
        {
            var listdata = _context.Feedbacks.Include(x => x.InfoUserCus)
                                                .Where(x => x.IdCarOwner == IdOwner).ToList();

            return PartialView("_FeedbackList", listdata);
        }


        public IActionResult testing ()
        {
            return Json(1);
        }
    }
}
