using Microsoft.Identity.Client;

namespace CarRental.Areas.Admin.Models.ViewModel
{
    public class XeTinhNangViewModel
    {
        public int Id { get; set; }

        public int IdHang { get; set; }
        public int IdLoaiXe { get; set; }
        
        public int IdUser { get; set; }

        public string Bienso { get; set; }
        public int Soghe { get; set; }
        public int Truyendong { get; set; }
        public string LoaiNl { get; set; }
        public string? Mota { get; set; }
        public List<CheckBoxItem> AvailTinhNang { get; set; }
    }
}
