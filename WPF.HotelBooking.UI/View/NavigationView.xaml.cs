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
using WPF.HotelBooking.UI.ViewModel;

namespace WPF.HotelBooking.UI.View
{
    /// <summary>
    /// Interaction logic for NavigationView.xaml
    /// </summary>
    public partial class NavigationView : UserControl
    {
        private readonly MainViewModel _viewModel;
        public NavigationView(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }
    }
}
