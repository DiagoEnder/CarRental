namespace CarRental.Areas.Admin.Models
{
    public class HoaDon
    {
        public int ID { get; set; }
        public int IdCus { get; set; }
        public int IdOwner { get; set; }
        public DateTime Paymentdate { get; set; }
        public double Total { get; set; }

        public  InfoUser infoUser { get; set; }
        public  ICollection<CTHD> cTHDs { get; set; }
    }
}
