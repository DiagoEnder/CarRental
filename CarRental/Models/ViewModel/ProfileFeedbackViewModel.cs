

using CarRental.Areas.Admin.Models;

namespace CarRental.Models.ViewModel
{
    public class ProfileFeedbackViewModel
    {
        public InfoUser InfoUser { get; set; }
        public List<Feedback> Feedback { get; set; }
    }
}
