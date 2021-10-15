using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.HotelBooking.UI.Data;
using WPF.HotelBooking.UI.ViewModel;

namespace WPF.HotelBooking.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var autoDaxContainerClassInstance = new AutoFacContainer();
            var iocContainer = autoDaxContainerClassInstance.Container();
            var mainWindow = iocContainer.Resolve<MainWindow>();
            mainWindow.Show();

        }
    }
}
