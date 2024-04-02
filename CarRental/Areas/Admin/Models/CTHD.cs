namespace CarRental.Areas.Admin.Models
{
    public class CTHD
    {
        public int ID { get; set; }
        public int IDHD { get; set; }
        public int IdSp { get; set; }
        public double Gia { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public HoaDon HoaDoncs { get; set; }
        public SanPham SanPham { get; set; }
        

    }
}
