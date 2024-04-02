namespace CarRental.Areas.Admin.Models
{
    public class Loaixe
    {
        public int Id { get; set; }
        public int  HangId { get; set; }

        public string Name { get; set; }

        public ICollection<InfoXe> InfoXe { get; set; }
        public Hang Hang { get; set; }
    }
          
}
