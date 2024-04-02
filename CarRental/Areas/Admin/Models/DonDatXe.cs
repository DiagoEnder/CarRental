namespace CarRental.Areas.Admin.Models
{
    public class DonDatXe
    {
        public int ID { get; set; }
        public int IdSp { get; set; }
        public int IdCus { get; set; }
        public int IdOwner { get; set; }
        public string? Location { get; set; }
        public DateTime ngayDat { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
        public int State { get; set; }
        

        public SanPham SanPham { get; set; }
        public InfoUser infoUserOwner { get; set; }
        public InfoUser InfoUserCus { get; set; }   


    }
}
