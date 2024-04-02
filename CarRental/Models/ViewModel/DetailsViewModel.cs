using CarRental.Areas.Admin.Models;

namespace CarRental.Models.ViewModel
{
    public class DetailsViewModel
    {
        
       public InfoXe InfoXe { get; set; }
        public SanPham SanPham { get; set; }
        public IEnumerable<XeTinhNang> XeTinhNang { get; set; }
        
        public IEnumerable<Feedback> Feedback { get; set; }
    }
}
