using System.Threading.Tasks;

namespace WPF.HotelBooking.UI.ViewModel
{
    public interface IRoomDetailViewModel
    {
        Task LoadRoom(int roomId);
    }
}