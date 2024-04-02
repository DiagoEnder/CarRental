using CarRental.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminManageController : Controller
	{
		private readonly CarContext _context;

		public AdminManageController(CarContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var slUser = _context.User.Count();

			var slChuxe = _context.User.Where(x => x.IdRole == 2).Count();

			var TongDoanhThu = _context.HoaDons.Sum(x => x.Total);

			double loinhuan = TongDoanhThu * 0.133;

			List<HoaDon> hd = _context.HoaDons.ToList();

			ViewBag.User = slUser;
			ViewBag.Chuxe = slChuxe;
			ViewBag.Tong = TongDoanhThu;
			ViewBag.Loinhuan = loinhuan;



			return View(hd);
		}
	}
}
