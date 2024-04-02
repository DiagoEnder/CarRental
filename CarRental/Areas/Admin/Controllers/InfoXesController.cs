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
    public class InfoXesController : Controller
    {
        private readonly CarContext _context;

        public InfoXesController(CarContext context)
        {
            _context = context;
        }

        // GET: Admin/InfoXes
        public async Task<IActionResult> Index()
        {


            List<SelectListItem> user = new List<SelectListItem>();
            user = _context.User.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id.ToString() }).ToList();

            ViewBag.User = user;


            ViewBag.Hang = GetHang();
            ViewBag.Loai = GetModel();
            return View(_context.InfoXes
                           .Include(h => h.Hang)
                           .Include(l => l.Loaixe)
                           .Include(u => u.User)

                );

        }




        // GET: Admin/Hangs/Create
        public IActionResult Create()
        {

            List<SelectListItem> user = new List<SelectListItem>();
            user = _context.User.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id.ToString() }).ToList();

            ViewBag.User = user;


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
            //return PartialView("_InfoXePartialView", loaixe);
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
            ifx.IdUser = xt.IdUser;
            ifx.IdHang = xt.IdHang;
            ifx.Bienso = xt.Bienso;
            ifx.LoaiNl = xt.LoaiNl;
            ifx.Mota = xt.Mota;
            ifx.Soghe = xt.Soghe;
            _context.InfoXes.Add(ifx);
            await _context.SaveChangesAsync();

            int IdXe = ifx.Id;

            foreach(var item in xt.AvailTinhNang)
            {
                if(item.IsChecked == true)
                {
                    lstxen.Add(new XeTinhNang() { Idxe = IdXe, Idtinhnang = item.Id });
                }
            }

            foreach( var item in lstxen)
            {
                _context.XeTinhNangs.Add(item);
            }
             await _context.SaveChangesAsync();

            return RedirectToAction("Index", "InfoXes");
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
                Text = "----Select Hãng----"
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
                        Text= n.Name
                    }).ToList() ;

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Mẫu Xe----"
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
