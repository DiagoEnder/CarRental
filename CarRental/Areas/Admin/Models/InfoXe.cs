namespace CarRental.Areas.Admin.Models
{
    public class InfoXe
    {
        public int Id { get;set; }

        public int IdHang { get;set; }
        public int IdLoaiXe { get;set; }
        public List<XeTinhNang> ListTinhNang { get;set; }
        public int IdUser { get;set; }
        
        public string Bienso { get; set; }
        public int Soghe { get; set; }
        public int Truyendong { get; set; }
        public string LoaiNl { get; set; }
        public string? Mota { get; set; }
        

        public SanPham SanPham { get; set; }
        public Hang Hang { get; set; }
        public Loaixe Loaixe { get; set; }
        
        public User User { get; set; }
        
    }
}
