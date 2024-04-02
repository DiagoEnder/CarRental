namespace CarRental.Areas.Admin.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int IdCus { get; set; }
        public int IdCarOwner { get; set; }
        public DateTime Date { get ; set; }
        public string Noidung { get; set; }
        public int Danhgia { get; set; }

        public InfoUser InfoUserCus { get; set; }
        public InfoUser InfoUserOwn { get; set; }
    }
}
