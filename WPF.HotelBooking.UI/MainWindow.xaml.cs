using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.HotelBooking.UI.View;
using WPF.HotelBooking.UI.ViewModel;

namespace WPF.HotelBooking.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    
    {
        private readonly MainViewModel _viewModel;
        public NavigationView _navigationView;
        public RoomDetailView _roomView;
        public UserDetailView _userView;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _roomView = new RoomDetailView(viewModel);
            _userView = new UserDetailView(viewModel);
            _navigationView = new NavigationView(viewModel);

            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Column1.Content = _navigationView;
            Column3.Content = _roomView;
            await _viewModel.Load();
        }
    }
}

