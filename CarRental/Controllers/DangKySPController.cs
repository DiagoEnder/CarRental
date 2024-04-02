using CarRental.Areas.Admin.Models;
using CarRental.Areas.Admin.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Controllers
{
    public class DangKySPController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly CarContext _context;

        public DangKySPController(CarContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }



        // GET: Admin/InfoXes
        public async Task<IActionResult> Index()
        {
            
            return View(_context.InfoXes
                           .Include(h => h.Hang)
                           .Include(l => l.Loaixe)                           

                );

        }




        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {
          
            ViewBag.Hang = GetHang();
            ViewBag.Loai = GetModel();

            InfoXe loaixe = new InfoXe();
            var item = _context.TinhNangs.ToList();
            XeTinhNangViewModel m1 = new XeTinhNangViewModel();
            m1.AvailTinhNang = item.Select(vm => new CheckBoxItem()
            {
                Id = vm.Id,
                Title = vm.Name,
                IsChecked = false
            }).ToList();
            



            return View(m1);



        }

        // POST: Admin/Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(XeTinhNangViewModel xt, InfoXe ifx, XeTinhNang xxt)
        {
            List<XeTinhNang> lstxen = new List<XeTinhNang>();

            ifx.Truyendong = xt.Truyendong;
            ifx.IdLoaiXe = xt.IdLoaiXe;
            ifx.IdUser = HttpContext.Session.GetInt32("IdUser") ?? 0;
            ifx.IdHang = xt.IdHang;
            ifx.Bienso = xt.Bienso;
            ifx.LoaiNl = xt.LoaiNl;
            ifx.Mota = xt.Mota;
            ifx.Soghe = xt.Soghe;
            _context.InfoXes.Add(ifx);
            await _context.SaveChangesAsync();

            int IdXe = ifx.Id;

            foreach (var item in xt.AvailTinhNang)
            {
                if (item.IsChecked == true)
                {
                    lstxen.Add(new XeTinhNang() { Idxe = IdXe, Idtinhnang = item.Id });
                }
            }

            foreach (var item in lstxen)
            {
                _context.XeTinhNangs.Add(item);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("CreateSp");
        }


        private string UploadedFile(SanPham user)
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



        public IActionResult CreateSp()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSp(SanPham sanPham)
        {
            int idifo = (int)(_context.InfoXes.Max(x =>x.Id));
            sanPham.IdInfo = idifo;
            sanPham.IdChuXe = (int)HttpContext.Session.GetInt32("IdUser");
            sanPham.Img = UploadedFile(sanPham);
            _context.Add(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


        // GET: Admin/Hangs/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            InfoXe hang = await _context.InfoXes.Where(e => e.Id == id).FirstOrDefaultAsync();


            return PartialView("EditInfoXePartialView", hang);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InfoXe hang)
        {
            _context.Update(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var hang = new InfoXe() { Id = id };
            _context.Remove(hang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetHang()
        {
            var lstHangs = new List<SelectListItem>();
            List<Hang> hangs = _context.Hangs.ToList();

            lstHangs = hangs.Select(h => new SelectListItem()
            {
                Value = h.Id.ToString(),
                Text = h.Name
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--- Select Hãng ---"
            };

            lstHangs.Insert(0, defItem);

            return lstHangs;
        }

        private List<SelectListItem> GetModel(int hangId = 1)
        {


            List<SelectListItem> lstModel = _context.Loaixes
                .Where(c => c.HangId == hangId)
                .OrderBy(n => n.Name)
                .Select(
                    n => new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--- Select Mẫu Xe ---"
            };

            lstModel.Insert(0, defItem);

            return lstModel;
        }


        public JsonResult GetLoaiByHang(int hangId)
        {
            List<SelectListItem> loai = GetModel(hangId);
            return Json(loai);
        }


    }
}
