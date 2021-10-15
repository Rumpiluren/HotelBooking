using Autofac;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.HotelBooking.DataAccess;
using WPF.HotelBooking.UI.Data;
using WPF.HotelBooking.UI.ViewModel;

namespace WPF.HotelBooking.UI
{
    public class AutoFacContainer
    {
        public IContainer Container()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<HotelBookingDbContext>().AsSelf();
            builder.RegisterType<HotelDataService>().As<IHotelDataService>();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<UserDetailViewModel>().As<IUserDetailViewModel>();
            builder.RegisterType<RoomDetailViewModel>().As<IRoomDetailViewModel>();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            return builder.Build();
        }
    }
}
