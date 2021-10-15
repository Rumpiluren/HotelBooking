using System.Threading.Tasks;

namespace WPF.HotelBooking.UI.ViewModel
{
    public interface IUserDetailViewModel
    {
        Task LoadUser(int userId);
    }
}